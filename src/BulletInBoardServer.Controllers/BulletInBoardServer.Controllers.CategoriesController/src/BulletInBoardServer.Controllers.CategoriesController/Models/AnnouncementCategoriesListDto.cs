/*
 * API Шлюз. Категории объявлений
 *
 * API Шлюза для управления категориями объявлений
 *
 * The version of the OpenAPI document: 0.0.4
 *
 * Generated by: https://openapi-generator.tech
 */

using System;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.Serialization;
using System.Text;

namespace BulletInBoardServer.Controllers.CategoriesController.Models
{ 
    /// <summary>
    /// 
    /// </summary>
    [DataContract]
    public class AnnouncementCategoriesListDto : IEquatable<AnnouncementCategoriesListDto>
    {
        /// <summary>
        /// Gets or Sets Categories
        /// </summary>
        [DataMember(Name="categories", EmitDefaultValue=false)]
        public List<AnnouncementCategoryDetailsDto> Categories { get; set; }

        /// <summary>
        /// Returns the string presentation of the object
        /// </summary>
        /// <returns>String presentation of the object</returns>
        public override string ToString()
        {
            var sb = new StringBuilder();
            sb.Append("class AnnouncementCategoriesListDto {\n");
            sb.Append("  Categories: ").Append(Categories).Append("\n");
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
            return obj.GetType() == GetType() && Equals((AnnouncementCategoriesListDto)obj);
        }

        /// <summary>
        /// Returns true if AnnouncementCategoriesListDto instances are equal
        /// </summary>
        /// <param name="other">Instance of AnnouncementCategoriesListDto to be compared</param>
        /// <returns>Boolean</returns>
        public bool Equals(AnnouncementCategoriesListDto other)
        {
            if (other is null) return false;
            if (ReferenceEquals(this, other)) return true;

            return 
                (
                    Categories == other.Categories ||
                    Categories != null &&
                    other.Categories != null &&
                    Categories.SequenceEqual(other.Categories)
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
                    if (Categories != null)
                    hashCode = hashCode * 59 + Categories.GetHashCode();
                return hashCode;
            }
        }

        #region Operators
        #pragma warning disable 1591

        public static bool operator ==(AnnouncementCategoriesListDto left, AnnouncementCategoriesListDto right)
        {
            return Equals(left, right);
        }

        public static bool operator !=(AnnouncementCategoriesListDto left, AnnouncementCategoriesListDto right)
        {
            return !Equals(left, right);
        }

        #pragma warning restore 1591
        #endregion Operators
    }
}