/*
 * API Шлюз. Объявления
 *
 * API шлюза для управления объявлениями
 *
 * The version of the OpenAPI document: 1.0.0
 *
 * Generated by: https://openapi-generator.tech
 */

using System;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.Serialization;
using System.Text;

namespace BulletInBoardServer.Controllers.AnnouncementsController.Models
{ 
    /// <summary>
    /// 
    /// </summary>
    [DataContract]
    public class SurveyDetailsDto : IEquatable<SurveyDetailsDto>
    {
        /// <summary>
        /// Идентификатор опроса
        /// </summary>
        /// <value>Идентификатор опроса</value>
        [DataMember(Name="id", EmitDefaultValue=false)]
        public Guid Id { get; set; }

        /// <summary>
        /// Проголосовал ли в опросе пользователь, запросивший детали опроса
        /// </summary>
        /// <value>Проголосовал ли в опросе пользователь, запросивший детали опроса</value>
        [DataMember(Name="isVotedByRequester", EmitDefaultValue=true)]
        public bool IsVotedByRequester { get; set; }

        /// <summary>
        /// Открыт ли опрос
        /// </summary>
        /// <value>Открыт ли опрос</value>
        [DataMember(Name="isOpen", EmitDefaultValue=true)]
        public bool IsOpen { get; set; } = true;

        /// <summary>
        /// Анонимен ли опрос
        /// </summary>
        /// <value>Анонимен ли опрос</value>
        [DataMember(Name="isAnonymous", EmitDefaultValue=true)]
        public bool IsAnonymous { get; set; } = false;

        /// <summary>
        /// Открыты ли результаты опроса до закрытия
        /// </summary>
        /// <value>Открыты ли результаты опроса до закрытия</value>
        [DataMember(Name="resultsOpenBeforeClosing", EmitDefaultValue=true)]
        public bool ResultsOpenBeforeClosing { get; set; }

        /// <summary>
        /// Проголосовавшие в опросе пользователи
        /// </summary>
        /// <value>Проголосовавшие в опросе пользователи</value>
        [DataMember(Name="voters", EmitDefaultValue=false)]
        public List<UserSummaryDto> Voters { get; set; }

        /// <summary>
        /// Время окончания голосования (если задано)
        /// </summary>
        /// <value>Время окончания голосования (если задано)</value>
        [DataMember(Name="autoClosingAt", EmitDefaultValue=true)]
        public DateTime? AutoClosingAt { get; set; }

        /// <summary>
        /// Фактическое время окончания голосования (если голосование завершено)
        /// </summary>
        /// <value>Фактическое время окончания голосования (если голосование завершено)</value>
        [DataMember(Name="voteFinishedAt", EmitDefaultValue=true)]
        public DateTime? VoteFinishedAt { get; set; }

        /// <summary>
        /// Вопросы опроса
        /// </summary>
        /// <value>Вопросы опроса</value>
        [DataMember(Name="questions", EmitDefaultValue=false)]
        public List<QuestionDetailsDto> Questions { get; set; }

        /// <summary>
        /// Returns the string presentation of the object
        /// </summary>
        /// <returns>String presentation of the object</returns>
        public override string ToString()
        {
            var sb = new StringBuilder();
            sb.Append("class SurveyDetailsDto {\n");
            sb.Append("  Id: ").Append(Id).Append("\n");
            sb.Append("  IsVotedByRequester: ").Append(IsVotedByRequester).Append("\n");
            sb.Append("  IsOpen: ").Append(IsOpen).Append("\n");
            sb.Append("  IsAnonymous: ").Append(IsAnonymous).Append("\n");
            sb.Append("  ResultsOpenBeforeClosing: ").Append(ResultsOpenBeforeClosing).Append("\n");
            sb.Append("  Voters: ").Append(Voters).Append("\n");
            sb.Append("  AutoClosingAt: ").Append(AutoClosingAt).Append("\n");
            sb.Append("  VoteFinishedAt: ").Append(VoteFinishedAt).Append("\n");
            sb.Append("  Questions: ").Append(Questions).Append("\n");
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
            return obj.GetType() == GetType() && Equals((SurveyDetailsDto)obj);
        }

        /// <summary>
        /// Returns true if SurveyDetailsDto instances are equal
        /// </summary>
        /// <param name="other">Instance of SurveyDetailsDto to be compared</param>
        /// <returns>Boolean</returns>
        public bool Equals(SurveyDetailsDto other)
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
                    IsVotedByRequester == other.IsVotedByRequester ||
                    
                    IsVotedByRequester.Equals(other.IsVotedByRequester)
                ) && 
                (
                    IsOpen == other.IsOpen ||
                    
                    IsOpen.Equals(other.IsOpen)
                ) && 
                (
                    IsAnonymous == other.IsAnonymous ||
                    
                    IsAnonymous.Equals(other.IsAnonymous)
                ) && 
                (
                    ResultsOpenBeforeClosing == other.ResultsOpenBeforeClosing ||
                    
                    ResultsOpenBeforeClosing.Equals(other.ResultsOpenBeforeClosing)
                ) && 
                (
                    Voters == other.Voters ||
                    Voters != null &&
                    other.Voters != null &&
                    Voters.SequenceEqual(other.Voters)
                ) && 
                (
                    AutoClosingAt == other.AutoClosingAt ||
                    AutoClosingAt != null &&
                    AutoClosingAt.Equals(other.AutoClosingAt)
                ) && 
                (
                    VoteFinishedAt == other.VoteFinishedAt ||
                    VoteFinishedAt != null &&
                    VoteFinishedAt.Equals(other.VoteFinishedAt)
                ) && 
                (
                    Questions == other.Questions ||
                    Questions != null &&
                    other.Questions != null &&
                    Questions.SequenceEqual(other.Questions)
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
                    
                    hashCode = hashCode * 59 + IsVotedByRequester.GetHashCode();
                    
                    hashCode = hashCode * 59 + IsOpen.GetHashCode();
                    
                    hashCode = hashCode * 59 + IsAnonymous.GetHashCode();
                    
                    hashCode = hashCode * 59 + ResultsOpenBeforeClosing.GetHashCode();
                    if (Voters != null)
                    hashCode = hashCode * 59 + Voters.GetHashCode();
                    if (AutoClosingAt != null)
                    hashCode = hashCode * 59 + AutoClosingAt.GetHashCode();
                    if (VoteFinishedAt != null)
                    hashCode = hashCode * 59 + VoteFinishedAt.GetHashCode();
                    if (Questions != null)
                    hashCode = hashCode * 59 + Questions.GetHashCode();
                return hashCode;
            }
        }

        #region Operators
        #pragma warning disable 1591

        public static bool operator ==(SurveyDetailsDto left, SurveyDetailsDto right)
        {
            return Equals(left, right);
        }

        public static bool operator !=(SurveyDetailsDto left, SurveyDetailsDto right)
        {
            return !Equals(left, right);
        }

        #pragma warning restore 1591
        #endregion Operators
    }
}
