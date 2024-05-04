/*
 * API Шлюз. Группы пользователей
 *
 * API шлюза для управления группами пользователей
 *
 * The version of the OpenAPI document: 0.0.3
 *
 * Generated by: https://openapi-generator.tech
 */

using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Runtime.Serialization;
using System.Text;
using Newtonsoft.Json;

namespace BulletInBoardServer.Controllers.UserGroupsController.Models
{ 
    /// <summary>
    /// 
    /// </summary>
    [DataContract]
    public class CreateUserGroupDto : IEquatable<CreateUserGroupDto>
    {
        /// <summary>
        /// Название группы пользователей
        /// </summary>
        /// <value>Название группы пользователей</value>
        [Required]
        [DataMember(Name="name", EmitDefaultValue=false)]
        public string Name { get; set; }

        /// <summary>
        /// Идентификатор администратора группы пользователей
        /// </summary>
        /// <value>Идентификатор администратора группы пользователей</value>
        [DataMember(Name="adminId", EmitDefaultValue=true)]
        public Guid? AdminId { get; set; }

        /// <summary>
        /// Идентификаторы участников группы пользователей
        /// </summary>
        /// <value>Идентификаторы участников группы пользователей</value>
        [DataMember(Name="memberIds", EmitDefaultValue=false)]
        public List<Guid> MemberIds { get; set; }

        /// <summary>
        /// Идентификаторы групп пользователей, являющихся родителями создаваемой
        /// </summary>
        /// <value>Идентификаторы групп пользователей, являющихся родителями создаваемой</value>
        [DataMember(Name="parentIds", EmitDefaultValue=false)]
        public List<Guid> ParentIds { get; set; }

        /// <summary>
        /// Идентификаторы групп пользователей, являющихся дочерними создаваемой
        /// </summary>
        /// <value>Идентификаторы групп пользователей, являющихся дочерними создаваемой</value>
        [DataMember(Name="childIds", EmitDefaultValue=false)]
        public List<Guid> ChildIds { get; set; }

        /// <summary>
        /// Returns the string presentation of the object
        /// </summary>
        /// <returns>String presentation of the object</returns>
        public override string ToString()
        {
            var sb = new StringBuilder();
            sb.Append("class CreateUserGroupDto {\n");
            sb.Append("  Name: ").Append(Name).Append("\n");
            sb.Append("  AdminId: ").Append(AdminId).Append("\n");
            sb.Append("  MemberIds: ").Append(MemberIds).Append("\n");
            sb.Append("  ParentIds: ").Append(ParentIds).Append("\n");
            sb.Append("  ChildIds: ").Append(ChildIds).Append("\n");
            sb.Append("}\n");
            return sb.ToString();
        }

        /// <summary>
        /// Returns the JSON string presentation of the object
        /// </summary>
        /// <returns>JSON string presentation of the object</returns>
        public string ToJson()
        {
            return JsonConvert.SerializeObject(this, Formatting.Indented);
        }

        /// <summary>
        /// Returns true if objects are equal
        /// </summary>
        /// <param name="obj">Object to be compared</param>
        /// <returns>Boolean</returns>
        public override bool Equals(object obj)
        {
            if (obj is null) return false;
            if (ReferenceEquals(this, obj)) return true;
            return obj.GetType() == GetType() && Equals((CreateUserGroupDto)obj);
        }

        /// <summary>
        /// Returns true if CreateUserGroupDto instances are equal
        /// </summary>
        /// <param name="other">Instance of CreateUserGroupDto to be compared</param>
        /// <returns>Boolean</returns>
        public bool Equals(CreateUserGroupDto other)
        {
            if (other is null) return false;
            if (ReferenceEquals(this, other)) return true;

            return 
                (
                    Name == other.Name ||
                    Name != null &&
                    Name.Equals(other.Name)
                ) && 
                (
                    AdminId == other.AdminId ||
                    AdminId != null &&
                    AdminId.Equals(other.AdminId)
                ) && 
                (
                    MemberIds == other.MemberIds ||
                    MemberIds != null &&
                    other.MemberIds != null &&
                    MemberIds.SequenceEqual(other.MemberIds)
                ) && 
                (
                    ParentIds == other.ParentIds ||
                    ParentIds != null &&
                    other.ParentIds != null &&
                    ParentIds.SequenceEqual(other.ParentIds)
                ) && 
                (
                    ChildIds == other.ChildIds ||
                    ChildIds != null &&
                    other.ChildIds != null &&
                    ChildIds.SequenceEqual(other.ChildIds)
                );
        }

        /// <summary>
        /// Gets the hash code
        /// </summary>
        /// <returns>Hash code</returns>
        public override int GetHashCode()
        {
            unchecked // Overflow is fine, just wrap
            {
                var hashCode = 41;
                // Suitable nullity checks etc, of course :)
                    if (Name != null)
                    hashCode = hashCode * 59 + Name.GetHashCode();
                    if (AdminId != null)
                    hashCode = hashCode * 59 + AdminId.GetHashCode();
                    if (MemberIds != null)
                    hashCode = hashCode * 59 + MemberIds.GetHashCode();
                    if (ParentIds != null)
                    hashCode = hashCode * 59 + ParentIds.GetHashCode();
                    if (ChildIds != null)
                    hashCode = hashCode * 59 + ChildIds.GetHashCode();
                return hashCode;
            }
        }

        #region Operators
        #pragma warning disable 1591

        public static bool operator ==(CreateUserGroupDto left, CreateUserGroupDto right)
        {
            return Equals(left, right);
        }

        public static bool operator !=(CreateUserGroupDto left, CreateUserGroupDto right)
        {
            return !Equals(left, right);
        }

        #pragma warning restore 1591
        #endregion Operators
    }
}
