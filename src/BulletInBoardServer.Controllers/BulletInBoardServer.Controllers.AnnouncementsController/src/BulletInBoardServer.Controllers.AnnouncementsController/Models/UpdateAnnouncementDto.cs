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
using System.ComponentModel.DataAnnotations;
using System.Runtime.Serialization;
using System.Text;

namespace BulletInBoardServer.Controllers.AnnouncementsController.Models
{ 
    /// <summary>
    /// 
    /// </summary>
    [DataContract]
    public class UpdateAnnouncementDto : IEquatable<UpdateAnnouncementDto>
    {
        /// <summary>
        /// Идентификатор обновляемого объявления
        /// </summary>
        /// <value>Идентификатор обновляемого объявления</value>
        [Required]
        [DataMember(Name="id", EmitDefaultValue=false)]
        public Guid Id { get; set; }

        /// <summary>
        /// Текстовое содержимое объявления. Null, если значение свойства не изменилось
        /// </summary>
        /// <value>Текстовое содержимое объявления. Null, если значение свойства не изменилось</value>
        [DataMember(Name="content", EmitDefaultValue=true)]
        public string? Content { get; set; }

        /// <summary>
        /// Gets or Sets AudienceIds
        /// </summary>
        [DataMember(Name="audienceIds", EmitDefaultValue=true)]
        public UpdateIdentifierListDto AudienceIds { get; set; }

        /// <summary>
        /// Gets or Sets AttachmentIds
        /// </summary>
        [DataMember(Name="attachmentIds", EmitDefaultValue=true)]
        public UpdateIdentifierListDto AttachmentIds { get; set; }

        /// <summary>
        /// Было ли изменено значение момента отложенной публикации
        /// </summary>
        /// <value>Было ли изменено значение момента отложенной публикации</value>
        [Required]
        [DataMember(Name="delayedPublishingAtChanged", EmitDefaultValue=true)]
        public bool DelayedPublishingAtChanged { get; set; }

        /// <summary>
        /// Момент отложенной публикации объявления. Null, если отложенная публикация не предполагается
        /// </summary>
        /// <value>Момент отложенной публикации объявления. Null, если отложенная публикация не предполагается</value>
        [DataMember(Name="delayedPublishingAt", EmitDefaultValue=true)]
        public DateTime? DelayedPublishingAt { get; set; }

        /// <summary>
        /// Было ли изменено значение момента отложенного сокрытия
        /// </summary>
        /// <value>Было ли изменено значение момента отложенного сокрытия</value>
        [Required]
        [DataMember(Name="delayedHidingAtChanged", EmitDefaultValue=true)]
        public bool DelayedHidingAtChanged { get; set; }

        /// <summary>
        /// Момент отложенного сокрытия объявления. Null, если отложенное сокрытие не предполагается
        /// </summary>
        /// <value>Момент отложенного сокрытия объявления. Null, если отложенное сокрытие не предполагается</value>
        [DataMember(Name="delayedHidingAt", EmitDefaultValue=true)]
        public DateTime? DelayedHidingAt { get; set; }

        /// <summary>
        /// Returns the string presentation of the object
        /// </summary>
        /// <returns>String presentation of the object</returns>
        public override string ToString()
        {
            var sb = new StringBuilder();
            sb.Append("class UpdateAnnouncementDto {\n");
            sb.Append("  Id: ").Append(Id).Append("\n");
            sb.Append("  Content: ").Append(Content).Append("\n");
            sb.Append("  AudienceIds: ").Append(AudienceIds).Append("\n");
            sb.Append("  AttachmentIds: ").Append(AttachmentIds).Append("\n");
            sb.Append("  DelayedPublishingAtChanged: ").Append(DelayedPublishingAtChanged).Append("\n");
            sb.Append("  DelayedPublishingAt: ").Append(DelayedPublishingAt).Append("\n");
            sb.Append("  DelayedHidingAtChanged: ").Append(DelayedHidingAtChanged).Append("\n");
            sb.Append("  DelayedHidingAt: ").Append(DelayedHidingAt).Append("\n");
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
            return obj.GetType() == GetType() && Equals((UpdateAnnouncementDto)obj);
        }

        /// <summary>
        /// Returns true if UpdateAnnouncementDto instances are equal
        /// </summary>
        /// <param name="other">Instance of UpdateAnnouncementDto to be compared</param>
        /// <returns>Boolean</returns>
        public bool Equals(UpdateAnnouncementDto other)
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
                    Content == other.Content ||
                    Content != null &&
                    Content.Equals(other.Content)
                ) && 
                (
                    AudienceIds == other.AudienceIds ||
                    AudienceIds != null &&
                    AudienceIds.Equals(other.AudienceIds)
                ) && 
                (
                    AttachmentIds == other.AttachmentIds ||
                    AttachmentIds != null &&
                    AttachmentIds.Equals(other.AttachmentIds)
                ) && 
                (
                    DelayedPublishingAtChanged == other.DelayedPublishingAtChanged ||
                    
                    DelayedPublishingAtChanged.Equals(other.DelayedPublishingAtChanged)
                ) && 
                (
                    DelayedPublishingAt == other.DelayedPublishingAt ||
                    DelayedPublishingAt != null &&
                    DelayedPublishingAt.Equals(other.DelayedPublishingAt)
                ) && 
                (
                    DelayedHidingAtChanged == other.DelayedHidingAtChanged ||
                    
                    DelayedHidingAtChanged.Equals(other.DelayedHidingAtChanged)
                ) && 
                (
                    DelayedHidingAt == other.DelayedHidingAt ||
                    DelayedHidingAt != null &&
                    DelayedHidingAt.Equals(other.DelayedHidingAt)
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
                    if (Content != null)
                    hashCode = hashCode * 59 + Content.GetHashCode();
                    if (AudienceIds != null)
                    hashCode = hashCode * 59 + AudienceIds.GetHashCode();
                    if (AttachmentIds != null)
                    hashCode = hashCode * 59 + AttachmentIds.GetHashCode();
                    
                    hashCode = hashCode * 59 + DelayedPublishingAtChanged.GetHashCode();
                    if (DelayedPublishingAt != null)
                    hashCode = hashCode * 59 + DelayedPublishingAt.GetHashCode();
                    
                    hashCode = hashCode * 59 + DelayedHidingAtChanged.GetHashCode();
                    if (DelayedHidingAt != null)
                    hashCode = hashCode * 59 + DelayedHidingAt.GetHashCode();
                return hashCode;
            }
        }

        #region Operators
        #pragma warning disable 1591

        public static bool operator ==(UpdateAnnouncementDto left, UpdateAnnouncementDto right)
        {
            return Equals(left, right);
        }

        public static bool operator !=(UpdateAnnouncementDto left, UpdateAnnouncementDto right)
        {
            return !Equals(left, right);
        }

        #pragma warning restore 1591
        #endregion Operators
    }
}
