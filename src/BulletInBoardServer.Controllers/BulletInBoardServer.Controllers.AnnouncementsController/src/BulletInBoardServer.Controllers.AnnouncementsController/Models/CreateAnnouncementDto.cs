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
    public class CreateAnnouncementDto : IEquatable<CreateAnnouncementDto>
    {
        /// <summary>
        /// Текстовое содержимое объявления
        /// </summary>
        /// <value>Текстовое содержимое объявления</value>
        [DataMember(Name="content", EmitDefaultValue=false)]
        public string Content { get; set; }

        /// <summary>
        /// Идентификаторы пользователей, для которых создается объявление
        /// </summary>
        /// <value>Идентификаторы пользователей, для которых создается объявление</value>
        [DataMember(Name="userIds", EmitDefaultValue=false)]
        public List<Guid> UserIds { get; set; }

        /// <summary>
        /// Идентификаторы вложений, прикрепляемых к объявлению
        /// </summary>
        /// <value>Идентификаторы вложений, прикрепляемых к объявлению</value>
        [DataMember(Name="attachmentIds", EmitDefaultValue=false)]
        public List<Guid> AttachmentIds { get; set; }

        /// <summary>
        /// Срок отложенной публикации объявления
        /// </summary>
        /// <value>Срок отложенной публикации объявления</value>
        [DataMember(Name="delayedPublishingAt", EmitDefaultValue=true)]
        public DateTime? DelayedPublishingAt { get; set; }

        /// <summary>
        /// Срок отложенного сокрытия объявления
        /// </summary>
        /// <value>Срок отложенного сокрытия объявления</value>
        [DataMember(Name="delayedHidingAt", EmitDefaultValue=true)]
        public DateTime? DelayedHidingAt { get; set; }

        /// <summary>
        /// Returns the string presentation of the object
        /// </summary>
        /// <returns>String presentation of the object</returns>
        public override string ToString()
        {
            var sb = new StringBuilder();
            sb.Append("class CreateAnnouncementDto {\n");
            sb.Append("  Content: ").Append(Content).Append("\n");
            sb.Append("  UserIds: ").Append(UserIds).Append("\n");
            sb.Append("  AttachmentIds: ").Append(AttachmentIds).Append("\n");
            sb.Append("  DelayedPublishingAt: ").Append(DelayedPublishingAt).Append("\n");
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
            return obj.GetType() == GetType() && Equals((CreateAnnouncementDto)obj);
        }

        /// <summary>
        /// Returns true if CreateAnnouncementDto instances are equal
        /// </summary>
        /// <param name="other">Instance of CreateAnnouncementDto to be compared</param>
        /// <returns>Boolean</returns>
        public bool Equals(CreateAnnouncementDto other)
        {
            if (other is null) return false;
            if (ReferenceEquals(this, other)) return true;

            return 
                (
                    Content == other.Content ||
                    Content != null &&
                    Content.Equals(other.Content)
                ) && 
                (
                    UserIds == other.UserIds ||
                    UserIds != null &&
                    other.UserIds != null &&
                    UserIds.SequenceEqual(other.UserIds)
                ) && 
                (
                    AttachmentIds == other.AttachmentIds ||
                    AttachmentIds != null &&
                    other.AttachmentIds != null &&
                    AttachmentIds.SequenceEqual(other.AttachmentIds)
                ) && 
                (
                    DelayedPublishingAt == other.DelayedPublishingAt ||
                    DelayedPublishingAt != null &&
                    DelayedPublishingAt.Equals(other.DelayedPublishingAt)
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
                    if (Content != null)
                    hashCode = hashCode * 59 + Content.GetHashCode();
                    if (UserIds != null)
                    hashCode = hashCode * 59 + UserIds.GetHashCode();
                    if (AttachmentIds != null)
                    hashCode = hashCode * 59 + AttachmentIds.GetHashCode();
                    if (DelayedPublishingAt != null)
                    hashCode = hashCode * 59 + DelayedPublishingAt.GetHashCode();
                    if (DelayedHidingAt != null)
                    hashCode = hashCode * 59 + DelayedHidingAt.GetHashCode();
                return hashCode;
            }
        }

        #region Operators
        #pragma warning disable 1591

        public static bool operator ==(CreateAnnouncementDto left, CreateAnnouncementDto right)
        {
            return Equals(left, right);
        }

        public static bool operator !=(CreateAnnouncementDto left, CreateAnnouncementDto right)
        {
            return !Equals(left, right);
        }

        #pragma warning restore 1591
        #endregion Operators
    }
}
