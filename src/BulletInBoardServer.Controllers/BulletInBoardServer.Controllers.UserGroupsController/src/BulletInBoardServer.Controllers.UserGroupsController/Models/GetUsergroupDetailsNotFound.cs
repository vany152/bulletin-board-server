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
using System.Runtime.Serialization;
using System.Text;
using Newtonsoft.Json;

namespace BulletInBoardServer.Controllers.UserGroupsController.Models
{ 
    /// <summary>
    /// 
    /// </summary>
    [DataContract]
    public class GetUsergroupDetailsNotFound : IEquatable<GetUsergroupDetailsNotFound>
    {
        /// <summary>
        /// Gets or Sets Code
        /// </summary>
        [DataMember(Name="code", EmitDefaultValue=true)]
        public GetUsergroupDetailsResponses Code { get; set; }

        /// <summary>
        /// Returns the string presentation of the object
        /// </summary>
        /// <returns>String presentation of the object</returns>
        public override string ToString()
        {
            var sb = new StringBuilder();
            sb.Append("class GetUsergroupDetailsNotFound {\n");
            sb.Append("  Code: ").Append(Code).Append("\n");
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
            return obj.GetType() == GetType() && Equals((GetUsergroupDetailsNotFound)obj);
        }

        /// <summary>
        /// Returns true if GetUsergroupDetailsNotFound instances are equal
        /// </summary>
        /// <param name="other">Instance of GetUsergroupDetailsNotFound to be compared</param>
        /// <returns>Boolean</returns>
        public bool Equals(GetUsergroupDetailsNotFound other)
        {
            if (other is null) return false;
            if (ReferenceEquals(this, other)) return true;

            return 
                (
                    Code == other.Code ||
                    
                    Code.Equals(other.Code)
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
                    
                    hashCode = hashCode * 59 + Code.GetHashCode();
                return hashCode;
            }
        }

        #region Operators
        #pragma warning disable 1591

        public static bool operator ==(GetUsergroupDetailsNotFound left, GetUsergroupDetailsNotFound right)
        {
            return Equals(left, right);
        }

        public static bool operator !=(GetUsergroupDetailsNotFound left, GetUsergroupDetailsNotFound right)
        {
            return !Equals(left, right);
        }

        #pragma warning restore 1591
        #endregion Operators
    }
}
