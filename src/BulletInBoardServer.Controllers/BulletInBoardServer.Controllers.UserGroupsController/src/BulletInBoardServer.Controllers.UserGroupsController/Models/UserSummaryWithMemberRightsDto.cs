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
    /// Пользователь с правами в группе пользователей
    /// </summary>
    [DataContract]
    public class UserSummaryWithMemberRightsDto : IEquatable<UserSummaryWithMemberRightsDto>
    {
        /// <summary>
        /// Gets or Sets User
        /// </summary>
        [DataMember(Name="user", EmitDefaultValue=true)]
        public UserSummaryDto User { get; set; }

        /// <summary>
        /// Gets or Sets Rights
        /// </summary>
        [DataMember(Name="rights", EmitDefaultValue=false)]
        public MemberRightsDto Rights { get; set; }

        /// <summary>
        /// Returns the string presentation of the object
        /// </summary>
        /// <returns>String presentation of the object</returns>
        public override string ToString()
        {
            var sb = new StringBuilder();
            sb.Append("class UserSummaryWithMemberRightsDto {\n");
            sb.Append("  User: ").Append(User).Append("\n");
            sb.Append("  Rights: ").Append(Rights).Append("\n");
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
            return obj.GetType() == GetType() && Equals((UserSummaryWithMemberRightsDto)obj);
        }

        /// <summary>
        /// Returns true if UserSummaryWithMemberRightsDto instances are equal
        /// </summary>
        /// <param name="other">Instance of UserSummaryWithMemberRightsDto to be compared</param>
        /// <returns>Boolean</returns>
        public bool Equals(UserSummaryWithMemberRightsDto other)
        {
            if (other is null) return false;
            if (ReferenceEquals(this, other)) return true;

            return 
                (
                    User == other.User ||
                    User != null &&
                    User.Equals(other.User)
                ) && 
                (
                    Rights == other.Rights ||
                    Rights != null &&
                    Rights.Equals(other.Rights)
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
                    if (User != null)
                    hashCode = hashCode * 59 + User.GetHashCode();
                    if (Rights != null)
                    hashCode = hashCode * 59 + Rights.GetHashCode();
                return hashCode;
            }
        }

        #region Operators
        #pragma warning disable 1591

        public static bool operator ==(UserSummaryWithMemberRightsDto left, UserSummaryWithMemberRightsDto right)
        {
            return Equals(left, right);
        }

        public static bool operator !=(UserSummaryWithMemberRightsDto left, UserSummaryWithMemberRightsDto right)
        {
            return !Equals(left, right);
        }

        #pragma warning restore 1591
        #endregion Operators
    }
}
