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
    public class ContentForAnnouncementUpdatingDto : IEquatable<ContentForAnnouncementUpdatingDto>
    {
        /// <summary>
        /// Идентификатор объявления
        /// </summary>
        /// <value>Идентификатор объявления</value>
        [DataMember(Name="id", EmitDefaultValue=false)]
        public Guid Id { get; set; }

        /// <summary>
        /// Автор объявления
        /// </summary>
        /// <value>Автор объявления</value>
        [DataMember(Name="authorName", EmitDefaultValue=false)]
        public string AuthorName { get; set; }

        /// <summary>
        /// Количество просмотревших объявление пользователей
        /// </summary>
        /// <value>Количество просмотревших объявление пользователей</value>
        [DataMember(Name="viewsCount", EmitDefaultValue=true)]
        public int ViewsCount { get; set; }

        /// <summary>
        /// Размер аудитории объявления
        /// </summary>
        /// <value>Размер аудитории объявления</value>
        [DataMember(Name="audienceSize", EmitDefaultValue=true)]
        public int AudienceSize { get; set; }

        /// <summary>
        /// Текстовое содержимое объявления
        /// </summary>
        /// <value>Текстовое содержимое объявления</value>
        [DataMember(Name="content", EmitDefaultValue=false)]
        public string Content { get; set; }

        /// <summary>
        /// Gets or Sets AudienceHierarchy
        /// </summary>
        [DataMember(Name="audienceHierarchy", EmitDefaultValue=false)]
        public UsergroupHierarchyDto AudienceHierarchy { get; set; }

        /// <summary>
        /// Массив опросов объявления
        /// </summary>
        /// <value>Массив опросов объявления</value>
        [DataMember(Name="surveys", EmitDefaultValue=true)]
        public List<SurveyDetailsDto> Surveys { get; set; }

        /// <summary>
        /// Момент публикации объявления. Объявление не является опубликованным, если null
        /// </summary>
        /// <value>Момент публикации объявления. Объявление не является опубликованным, если null</value>
        [DataMember(Name="publishedAt", EmitDefaultValue=true)]
        public DateTime? PublishedAt { get; set; }

        /// <summary>
        /// Момент сокрытия объявления. Объявление не является скрытым, если null
        /// </summary>
        /// <value>Момент сокрытия объявления. Объявление не является скрытым, если null</value>
        [DataMember(Name="hiddenAt", EmitDefaultValue=true)]
        public DateTime? HiddenAt { get; set; }

        /// <summary>
        /// Момент отложенного сокрытия объявления. Объявление не будет скрыто автоматически, если null
        /// </summary>
        /// <value>Момент отложенного сокрытия объявления. Объявление не будет скрыто автоматически, если null</value>
        [DataMember(Name="delayedHidingAt", EmitDefaultValue=true)]
        public DateTime? DelayedHidingAt { get; set; }

        /// <summary>
        /// Момент отложенной публикации объявления. Объявление не будет опубликовано автоматически, если null
        /// </summary>
        /// <value>Момент отложенной публикации объявления. Объявление не будет опубликовано автоматически, если null</value>
        [DataMember(Name="delayedPublishingAt", EmitDefaultValue=true)]
        public DateTime? DelayedPublishingAt { get; set; }

        /// <summary>
        /// Returns the string presentation of the object
        /// </summary>
        /// <returns>String presentation of the object</returns>
        public override string ToString()
        {
            var sb = new StringBuilder();
            sb.Append("class ContentForAnnouncementUpdatingDto {\n");
            sb.Append("  Id: ").Append(Id).Append("\n");
            sb.Append("  AuthorName: ").Append(AuthorName).Append("\n");
            sb.Append("  ViewsCount: ").Append(ViewsCount).Append("\n");
            sb.Append("  AudienceSize: ").Append(AudienceSize).Append("\n");
            sb.Append("  Content: ").Append(Content).Append("\n");
            sb.Append("  AudienceHierarchy: ").Append(AudienceHierarchy).Append("\n");
            sb.Append("  Surveys: ").Append(Surveys).Append("\n");
            sb.Append("  PublishedAt: ").Append(PublishedAt).Append("\n");
            sb.Append("  HiddenAt: ").Append(HiddenAt).Append("\n");
            sb.Append("  DelayedHidingAt: ").Append(DelayedHidingAt).Append("\n");
            sb.Append("  DelayedPublishingAt: ").Append(DelayedPublishingAt).Append("\n");
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
            return obj.GetType() == GetType() && Equals((ContentForAnnouncementUpdatingDto)obj);
        }

        /// <summary>
        /// Returns true if ContentForAnnouncementUpdatingDto instances are equal
        /// </summary>
        /// <param name="other">Instance of ContentForAnnouncementUpdatingDto to be compared</param>
        /// <returns>Boolean</returns>
        public bool Equals(ContentForAnnouncementUpdatingDto other)
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
                    AuthorName == other.AuthorName ||
                    AuthorName != null &&
                    AuthorName.Equals(other.AuthorName)
                ) && 
                (
                    ViewsCount == other.ViewsCount ||
                    
                    ViewsCount.Equals(other.ViewsCount)
                ) && 
                (
                    AudienceSize == other.AudienceSize ||
                    
                    AudienceSize.Equals(other.AudienceSize)
                ) && 
                (
                    Content == other.Content ||
                    Content != null &&
                    Content.Equals(other.Content)
                ) && 
                (
                    AudienceHierarchy == other.AudienceHierarchy ||
                    AudienceHierarchy != null &&
                    AudienceHierarchy.Equals(other.AudienceHierarchy)
                ) && 
                (
                    Surveys == other.Surveys ||
                    Surveys != null &&
                    other.Surveys != null &&
                    Surveys.SequenceEqual(other.Surveys)
                ) && 
                (
                    PublishedAt == other.PublishedAt ||
                    PublishedAt != null &&
                    PublishedAt.Equals(other.PublishedAt)
                ) && 
                (
                    HiddenAt == other.HiddenAt ||
                    HiddenAt != null &&
                    HiddenAt.Equals(other.HiddenAt)
                ) && 
                (
                    DelayedHidingAt == other.DelayedHidingAt ||
                    DelayedHidingAt != null &&
                    DelayedHidingAt.Equals(other.DelayedHidingAt)
                ) && 
                (
                    DelayedPublishingAt == other.DelayedPublishingAt ||
                    DelayedPublishingAt != null &&
                    DelayedPublishingAt.Equals(other.DelayedPublishingAt)
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
                    if (AuthorName != null)
                    hashCode = hashCode * 59 + AuthorName.GetHashCode();
                    
                    hashCode = hashCode * 59 + ViewsCount.GetHashCode();
                    
                    hashCode = hashCode * 59 + AudienceSize.GetHashCode();
                    if (Content != null)
                    hashCode = hashCode * 59 + Content.GetHashCode();
                    if (AudienceHierarchy != null)
                    hashCode = hashCode * 59 + AudienceHierarchy.GetHashCode();
                    if (Surveys != null)
                    hashCode = hashCode * 59 + Surveys.GetHashCode();
                    if (PublishedAt != null)
                    hashCode = hashCode * 59 + PublishedAt.GetHashCode();
                    if (HiddenAt != null)
                    hashCode = hashCode * 59 + HiddenAt.GetHashCode();
                    if (DelayedHidingAt != null)
                    hashCode = hashCode * 59 + DelayedHidingAt.GetHashCode();
                    if (DelayedPublishingAt != null)
                    hashCode = hashCode * 59 + DelayedPublishingAt.GetHashCode();
                return hashCode;
            }
        }

        #region Operators
        #pragma warning disable 1591

        public static bool operator ==(ContentForAnnouncementUpdatingDto left, ContentForAnnouncementUpdatingDto right)
        {
            return Equals(left, right);
        }

        public static bool operator !=(ContentForAnnouncementUpdatingDto left, ContentForAnnouncementUpdatingDto right)
        {
            return !Equals(left, right);
        }

        #pragma warning restore 1591
        #endregion Operators
    }
}
