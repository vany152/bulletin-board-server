/*
 * API Шлюз. Опросы
 *
 * API шлюза для управления опросами
 *
 * The version of the OpenAPI document: 1.0.0
 *
 * Generated by: https://openapi-generator.tech
 */

using System;
using System.Runtime.Serialization;
using System.Text;

namespace BulletInBoardServer.Controllers.SurveysController.Models
{ 
    /// <summary>
    /// 
    /// </summary>
    [DataContract]
    public class CreateAnswerDto : IEquatable<CreateAnswerDto>
    {
        /// <summary>
        /// Порядковый номер варианта ответа в списке вариантов ответов
        /// </summary>
        /// <value>Порядковый номер варианта ответа в списке вариантов ответов</value>
        [DataMember(Name="serial", EmitDefaultValue=true)]
        public int Serial { get; set; }

        /// <summary>
        /// текстовое содержимое варианта ответа
        /// </summary>
        /// <value>текстовое содержимое варианта ответа</value>
        [DataMember(Name="content", EmitDefaultValue=false)]
        public string Content { get; set; }

        /// <summary>
        /// Returns the string presentation of the object
        /// </summary>
        /// <returns>String presentation of the object</returns>
        public override string ToString()
        {
            var sb = new StringBuilder();
            sb.Append("class CreateAnswerDto {\n");
            sb.Append("  Serial: ").Append(Serial).Append("\n");
            sb.Append("  Content: ").Append(Content).Append("\n");
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
            return obj.GetType() == GetType() && Equals((CreateAnswerDto)obj);
        }

        /// <summary>
        /// Returns true if CreateAnswerDto instances are equal
        /// </summary>
        /// <param name="other">Instance of CreateAnswerDto to be compared</param>
        /// <returns>Boolean</returns>
        public bool Equals(CreateAnswerDto other)
        {
            if (other is null) return false;
            if (ReferenceEquals(this, other)) return true;

            return 
                (
                    Serial == other.Serial ||
                    
                    Serial.Equals(other.Serial)
                ) && 
                (
                    Content == other.Content ||
                    Content != null &&
                    Content.Equals(other.Content)
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
                    
                    hashCode = hashCode * 59 + Serial.GetHashCode();
                    if (Content != null)
                    hashCode = hashCode * 59 + Content.GetHashCode();
                return hashCode;
            }
        }

        #region Operators
        #pragma warning disable 1591

        public static bool operator ==(CreateAnswerDto left, CreateAnswerDto right)
        {
            return Equals(left, right);
        }

        public static bool operator !=(CreateAnswerDto left, CreateAnswerDto right)
        {
            return !Equals(left, right);
        }

        #pragma warning restore 1591
        #endregion Operators
    }
}
