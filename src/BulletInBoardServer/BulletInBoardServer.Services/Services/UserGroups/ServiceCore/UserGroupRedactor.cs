﻿using BulletInBoardServer.Domain;
using BulletInBoardServer.Domain.Models.UserGroups;
using BulletInBoardServer.Domain.Models.UserGroups.Exceptions;
using BulletInBoardServer.Services.Services.UserGroups.Exceptions;
using BulletInBoardServer.Services.Services.UserGroups.Models;
using BulletInBoardServer.Services.Services.Users.Exceptions;
using Microsoft.EntityFrameworkCore;
using Npgsql;

// ReSharper disable InconsistentNaming

namespace BulletInBoardServer.Services.Services.UserGroups.ServiceCore;

/// <summary>
/// Класс-редактор группы пользователей
/// </summary>
/// <param name="dbContext">Контекст базы данных</param>
public class UserGroupRedactor(ApplicationDbContext dbContext)
{
    /// <summary>
    /// Редактировать группу пользователей
    /// </summary>
    /// <param name="edit">Объект с данными для редактирования группы пользователей</param>
    /// <exception cref="UserGroupDoesNotExistException">Группа пользователей не существует</exception>
    /// <exception cref="UserGroupNameEmptyException">Название группы пользователей пустое</exception>">
    public void Edit(EditUserGroup edit)
    {
        var userGroup = LoadUserGroupSummary(edit.Id);

        if (edit.Name is not null)
            userGroup.SetName(edit.Name);

        if (edit.AdminChanged)
            userGroup.AdminId = edit.AdminId;

        if (edit.Members is not null)
            ApplyMembersChanging(edit);

        try
        {
            dbContext.SaveChanges();
        }
        catch (DbUpdateException err)
        {
            if (err.InnerException is not PostgresException inner)
                throw;

            switch (inner)
            {
                case { SqlState: "23503", ConstraintName: "member_rights_user_id_fkey" }:
                    throw new UserDoesNotExistException(err);
                case { SqlState: "23503", ConstraintName: "usergroups_admin_id_fkey" }:
                    throw new UserDoesNotExistException(err);
                default:
                    throw;
            }
        }
    }

    /// <summary>
    /// Добавить участников в группу пользователей
    /// </summary>
    /// <param name="add">Объект с необходимой для добавления информацией</param>
    /// <exception cref="UserIsAdminException">В группу пользователей нельзя добавить участника, являющегося администратором этой группы</exception>
    /// <exception cref="UserIsAlreadyMemberOfUserGroup">Участник уже состоит в группе</exception>
    /// <exception cref="UserDoesNotExistException">Пользователь не существует в БД</exception>
    /// <exception cref="UserGroupDoesNotExistException">Группа пользователей не существует в БД</exception>
    public void AddMembers(AddUserGroupMembers add)
    {
        var userGroup = LoadUserGroupSummary(add.UserGroupId);
        if (add.Members.Any(smr => smr.UserId == userGroup.AdminId))
            throw new UserIsAdminException();
        
        AddMembers(add.UserGroupId, add.Members);

        try
        {
            dbContext.SaveChanges();
        }
        catch (DbUpdateException err)
        {
            if (err.InnerException is not PostgresException inner)
                throw;

            switch (inner)
            {
                case { SqlState: "23505", ConstraintName: "member_rights_pkey" }:
                    throw new UserIsAlreadyMemberOfUserGroup(err);
                case { SqlState: "23503", ConstraintName: "member_rights_user_id_fkey" }:
                    throw new UserDoesNotExistException();
                case { SqlState: "23503", ConstraintName: "member_rights_usergroup_id_fkey" }:
                    throw new UserGroupDoesNotExistException();
                default:
                    throw;
            }
        }
    }

    /// <summary>
    /// Удалить участников из группы пользователей
    /// </summary>
    /// <param name="delete">Объект с необходимой для удаления информацией</param>
    /// <exception cref="UserIsAdminException">Из группы пользователей нельзя удалить участника, являющегося администратором этой группы</exception>
    public void DeleteMembers(DeleteUserGroupMembers delete)
    {
        var userGroup = LoadUserGroupSummary(delete.UserGroupId);
        if (delete.MemberIds.Any(id => id == userGroup.AdminId))
            throw new UserIsAdminException();
        
        DeleteMembers(delete.UserGroupId, delete.MemberIds);

        try
        {
            dbContext.SaveChanges();
        }
        catch (DbUpdateException err)
        {
            if (err.InnerException is not PostgresException inner)
                throw;

            switch (inner)
            {
                case { SqlState: "23503", ConstraintName: "member_rights_user_id_fkey" }:
                    throw new UserDoesNotExistException();
                case { SqlState: "23503", ConstraintName: "member_rights_usergroup_id_fkey" }:
                    throw new UserGroupDoesNotExistException();
            }
        }
    }



    private UserGroup LoadUserGroupSummary(Guid id)
    {
        var usergroup = dbContext.UserGroups.FirstOrDefault(ug => ug.Id == id);
        if (usergroup is null)
            throw new UserGroupDoesNotExistException();

        return usergroup;
    }
    
    private void ApplyMembersChanging(EditUserGroup edit)
    {
        if (edit.Members is null)
            return;

        var toRemove = edit.Members.IdsToRemove;
        var toAdd = edit.Members.NewMembers;

        if (toRemove is not null)
            DeleteMembers(edit.Id, toRemove);

        if (toAdd is null) 
            return;

        var userGroupSummary = LoadUserGroupSummary(edit.Id);
        if (toAdd.Any(u => u.UserId == userGroupSummary.AdminId))
            throw new AdminCannotBeOrdinaryMemberException();
        AddMembers(edit.Id, toAdd);
    }

    private void DeleteMembers(Guid userGroupId, IEnumerable<Guid> toRemove) =>
        dbContext.MemberRights
            .Where(smr => smr.UserGroupId == userGroupId && toRemove.Contains(smr.UserId))
            .ExecuteDelete();

    private void AddMembers(Guid userGroupId, IEnumerable<SingleMemberRights> toAdd)
    {
        foreach (var newMember in toAdd)
        {
            newMember.UserGroupId = userGroupId;
            dbContext.MemberRights.Add(newMember);
        }
    }
}