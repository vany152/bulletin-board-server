/*
 * API Шлюз. Группы пользователей
 *
 * API шлюза для управления группами пользователей
 *
 * The version of the OpenAPI document: 1.0.0
 *
 * Generated by: https://openapi-generator.tech
 */

using System;
using System.ComponentModel.DataAnnotations;
using System.Runtime.Serialization;
using System.Text;

namespace BulletInBoardServer.Controllers.UserGroupsController.Models
{ 
    /// <summary>
    /// DTO для обновления группы пользователей
    /// </summary>
    [DataContract]
    public class UpdateUserGroupDto : IEquatable<UpdateUserGroupDto>
    {
        /// <summary>
        /// Идентификатор группы пользователей
        /// </summary>
        /// <value>Идентификатор группы пользователей</value>
        [Required]
        [DataMember(Name="id", EmitDefaultValue=false)]
        public Guid Id { get; set; }

        /// <summary>
        /// Новое название группы пользователей
        /// </summary>
        /// <value>Новое название группы пользователей</value>
        [DataMember(Name="name", EmitDefaultValue=true)]
        public string? Name { get; set; }

        /// <summary>
        /// Изменен ли администратор группы. True, если изменен
        /// </summary>
        /// <value>Изменен ли администратор группы. True, если изменен</value>
        [Required]
        [DataMember(Name="adminChanged", EmitDefaultValue=true)]
        public bool AdminChanged { get; set; }

        /// <summary>
        /// Новый идентификатор администратора. Null отправляется для удаления администратора
        /// </summary>
        /// <value>Новый идентификатор администратора. Null отправляется для удаления администратора</value>
        [DataMember(Name="adminId", EmitDefaultValue=true)]
        public Guid? AdminId { get; set; }

        /// <summary>
        /// Gets or Sets Members
        /// </summary>
        [DataMember(Name="members", EmitDefaultValue=true)]
        public UpdateMemberListDto Members { get; set; }

        /// <summary>
        /// Returns the string presentation of the object
        /// </summary>
        /// <returns>String presentation of the object</returns>
        public override string ToString()
        {
            var sb = new StringBuilder();
            sb.Append("class UpdateUserGroupDto {\n");
            sb.Append("  Id: ").Append(Id).Append("\n");
            sb.Append("  Name: ").Append(Name).Append("\n");
            sb.Append("  AdminChanged: ").Append(AdminChanged).Append("\n");
            sb.Append("  AdminId: ").Append(AdminId).Append("\n");
            sb.Append("  Members: ").Append(Members).Append("\n");
            sb.Append("}\n");
            return sb.ToString();
        }

        /// <summary>
        /// Returns the JSON string presentation of the object
        /// </summary>
        /// <returns>JSON string presentation of the object</returns>
        public string ToJson()
        {
            return Newtonsoft.Json.JsonConvert.SerializeObject(this, Newtonsoft.Json.Formatting.Indented);
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
            return obj.GetType() == GetType() && Equals((UpdateUserGroupDto)obj);
        }

        /// <summary>
        /// Returns true if UpdateUserGroupDto instances are equal
        /// </summary>
        /// <param name="other">Instance of UpdateUserGroupDto to be compared</param>
        /// <returns>Boolean</returns>
        public bool Equals(UpdateUserGroupDto other)
        {
            if (other is null) return false;
            if (ReferenceEquals(this, other)) return true;

            return 
                (
                    Id == other.Id ||
                    Id != null &&
                    Id.Equals(other.Id)
                ) && 
                (
                    Name == other.Name ||
                    Name != null &&
                    Name.Equals(other.Name)
                ) && 
                (
                    AdminChanged == other.AdminChanged ||
                    
                    AdminChanged.Equals(other.AdminChanged)
                ) && 
                (
                    AdminId == other.AdminId ||
                    AdminId != null &&
                    AdminId.Equals(other.AdminId)
                ) && 
                (
                    Members == other.Members ||
                    Members != null &&
                    Members.Equals(other.Members)
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
                    if (Id != null)
                    hashCode = hashCode * 59 + Id.GetHashCode();
                    if (Name != null)
                    hashCode = hashCode * 59 + Name.GetHashCode();
                    
                    hashCode = hashCode * 59 + AdminChanged.GetHashCode();
                    if (AdminId != null)
                    hashCode = hashCode * 59 + AdminId.GetHashCode();
                    if (Members != null)
                    hashCode = hashCode * 59 + Members.GetHashCode();
                return hashCode;
            }
        }

        #region Operators
        #pragma warning disable 1591

        public static bool operator ==(UpdateUserGroupDto left, UpdateUserGroupDto right)
        {
            return Equals(left, right);
        }

        public static bool operator !=(UpdateUserGroupDto left, UpdateUserGroupDto right)
        {
            return !Equals(left, right);
        }

        #pragma warning restore 1591
        #endregion Operators
    }
}