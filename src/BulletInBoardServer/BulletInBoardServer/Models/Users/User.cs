﻿namespace BulletInBoardServer.Models.Users;

/// <summary>
/// Пользователь системы
/// </summary>
public class User
{
    /// <summary>
    /// Идентификатор пользователя
    /// </summary>
    public Guid Id { get; set; }
    
    /// <summary>
    /// Имя пользователя
    /// </summary>
    public string FirstName { get; set; }
    
    /// <summary>
    /// Фамилия пользователя
    /// </summary>
    public string SecondName { get; set; }
    
    /// <summary>
    /// Отчество пользователя
    /// </summary>
    public string? Patronymic { get; set; }



    public User(Guid id, string firstName, string secondName, string? patronymic = null)
    {
        if (string.IsNullOrWhiteSpace(firstName))
            throw new ArgumentException("Имя не может быть пустым или null");
        if (string.IsNullOrWhiteSpace(secondName))
            throw new ArgumentException("Фамилия не может быть пустой или null");
        if (patronymic is not null && string.IsNullOrWhiteSpace(patronymic))
            throw new ArgumentException("Отчество не может быть пустым");
        
        Id = id;
        FirstName = firstName;
        SecondName = secondName;
        Patronymic = patronymic;
    }

    public User(string name, string secondName, string? patronymic = null)
        : this(Guid.NewGuid(), name, secondName, patronymic)
    {
    }
}