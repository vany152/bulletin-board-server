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
using System.ComponentModel.DataAnnotations;
using System.Runtime.Serialization;
using System.Text;

namespace BulletInBoardServer.Controllers.SurveysController.Models
{ 
    /// <summary>
    /// DTO для запроса выгрузки результатов опроса
    /// </summary>
    [DataContract]
    public class DownloadSurveyResultsRequestDto : IEquatable<DownloadSurveyResultsRequestDto>
    {
        /// <summary>
        /// Идентификатор опроса
        /// </summary>
        /// <value>Идентификатор опроса</value>
        [Required]
        [DataMember(Name="surveyId", EmitDefaultValue=false)]
        public Guid SurveyId { get; set; }

        /// <summary>
        /// Тип файла с результатами опроса
        /// </summary>
        /// <value>Тип файла с результатами опроса</value>
        [Required]
        [DataMember(Name="fileType", EmitDefaultValue=false)]
        public string FileType { get; set; }

        /// <summary>
        /// Returns the string presentation of the object
        /// </summary>
        /// <returns>String presentation of the object</returns>
        public override string ToString()
        {
            var sb = new StringBuilder();
            sb.Append("class DownloadSurveyResultsRequestDto {\n");
            sb.Append("  SurveyId: ").Append(SurveyId).Append("\n");
            sb.Append("  FileType: ").Append(FileType).Append("\n");
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
            return obj.GetType() == GetType() && Equals((DownloadSurveyResultsRequestDto)obj);
        }

        /// <summary>
        /// Returns true if DownloadSurveyResultsRequestDto instances are equal
        /// </summary>
        /// <param name="other">Instance of DownloadSurveyResultsRequestDto to be compared</param>
        /// <returns>Boolean</returns>
        public bool Equals(DownloadSurveyResultsRequestDto other)
        {
            if (other is null) return false;
            if (ReferenceEquals(this, other)) return true;

            return 
                (
                    SurveyId == other.SurveyId ||
                    SurveyId != null &&
                    SurveyId.Equals(other.SurveyId)
                ) && 
                (
                    FileType == other.FileType ||
                    FileType != null &&
                    FileType.Equals(other.FileType)
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
                    if (SurveyId != null)
                    hashCode = hashCode * 59 + SurveyId.GetHashCode();
                    if (FileType != null)
                    hashCode = hashCode * 59 + FileType.GetHashCode();
                return hashCode;
            }
        }

        #region Operators
        #pragma warning disable 1591

        public static bool operator ==(DownloadSurveyResultsRequestDto left, DownloadSurveyResultsRequestDto right)
        {
            return Equals(left, right);
        }

        public static bool operator !=(DownloadSurveyResultsRequestDto left, DownloadSurveyResultsRequestDto right)
        {
            return !Equals(left, right);
        }

        #pragma warning restore 1591
        #endregion Operators
    }
}
