/*
 * API Шлюз. Группы пользователей
 *
 * API шлюза для управления группами пользователей
 *
 * The version of the OpenAPI document: 0.1.0
 *
 * Generated by: https://openapi-generator.tech
 */

using System;
using System.Runtime.Serialization;
using System.Text;

namespace BulletInBoardServer.Controllers.UserGroupsController.Models
{ 
    /// <summary>
    /// 
    /// </summary>
    [DataContract]
    public class CheckableUserSummaryDto : IEquatable<CheckableUserSummaryDto>
    {
        /// <summary>
        /// Идентификатор пользователя
        /// </summary>
        /// <value>Идентификатор пользователя</value>
        [DataMember(Name="id", EmitDefaultValue=false)]
        public Guid Id { get; set; }

        /// <summary>
        /// Имя пользователя
        /// </summary>
        /// <value>Имя пользователя</value>
        [DataMember(Name="firstName", EmitDefaultValue=false)]
        public string FirstName { get; set; }

        /// <summary>
        /// Фамилия пользователя
        /// </summary>
        /// <value>Фамилия пользователя</value>
        [DataMember(Name="secondName", EmitDefaultValue=false)]
        public string SecondName { get; set; }

        /// <summary>
        /// Отчество пользователя
        /// </summary>
        /// <value>Отчество пользователя</value>
        [DataMember(Name="patronymic", EmitDefaultValue=true)]
        public string? Patronymic { get; set; }

        /// <summary>
        /// Выбран ли пользователь
        /// </summary>
        /// <value>Выбран ли пользователь</value>
        [DataMember(Name="isChecked", EmitDefaultValue=true)]
        public bool IsChecked { get; set; }

        /// <summary>
        /// Returns the string presentation of the object
        /// </summary>
        /// <returns>String presentation of the object</returns>
        public override string ToString()
        {
            var sb = new StringBuilder();
            sb.Append("class CheckableUserSummaryDto {\n");
            sb.Append("  Id: ").Append(Id).Append("\n");
            sb.Append("  FirstName: ").Append(FirstName).Append("\n");
            sb.Append("  SecondName: ").Append(SecondName).Append("\n");
            sb.Append("  Patronymic: ").Append(Patronymic).Append("\n");
            sb.Append("  IsChecked: ").Append(IsChecked).Append("\n");
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
            return obj.GetType() == GetType() && Equals((CheckableUserSummaryDto)obj);
        }

        /// <summary>
        /// Returns true if CheckableUserSummaryDto instances are equal
        /// </summary>
        /// <param name="other">Instance of CheckableUserSummaryDto to be compared</param>
        /// <returns>Boolean</returns>
        public bool Equals(CheckableUserSummaryDto other)
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
                    FirstName == other.FirstName ||
                    FirstName != null &&
                    FirstName.Equals(other.FirstName)
                ) && 
                (
                    SecondName == other.SecondName ||
                    SecondName != null &&
                    SecondName.Equals(other.SecondName)
                ) && 
                (
                    Patronymic == other.Patronymic ||
                    Patronymic != null &&
                    Patronymic.Equals(other.Patronymic)
                ) && 
                (
                    IsChecked == other.IsChecked ||
                    
                    IsChecked.Equals(other.IsChecked)
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
                    if (FirstName != null)
                    hashCode = hashCode * 59 + FirstName.GetHashCode();
                    if (SecondName != null)
                    hashCode = hashCode * 59 + SecondName.GetHashCode();
                    if (Patronymic != null)
                    hashCode = hashCode * 59 + Patronymic.GetHashCode();
                    
                    hashCode = hashCode * 59 + IsChecked.GetHashCode();
                return hashCode;
            }
        }

        #region Operators
        #pragma warning disable 1591

        public static bool operator ==(CheckableUserSummaryDto left, CheckableUserSummaryDto right)
        {
            return Equals(left, right);
        }

        public static bool operator !=(CheckableUserSummaryDto left, CheckableUserSummaryDto right)
        {
            return !Equals(left, right);
        }

        #pragma warning restore 1591
        #endregion Operators
    }
}
