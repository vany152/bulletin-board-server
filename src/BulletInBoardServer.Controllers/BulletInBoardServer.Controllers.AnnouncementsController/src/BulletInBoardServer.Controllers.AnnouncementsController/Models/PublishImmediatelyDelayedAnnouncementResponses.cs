/*
 * API Шлюз. Объявления
 *
 * API шлюза для управления объявлениями
 *
 * The version of the OpenAPI document: 1.0.0
 *
 * Generated by: https://openapi-generator.tech
 */

using System.ComponentModel;
using System.Runtime.Serialization;
using BulletInBoardServer.Controllers.AnnouncementsController.Converters;
using Newtonsoft.Json;

namespace BulletInBoardServer.Controllers.AnnouncementsController.Models
{ 
        /// <summary>
        /// Ответы:    immediatePublishingForbidden - Пользователь не имеет права незамедлительно опубликовать отложенное объявление   announcementDoesNotExist - Объявление не существует 
        /// </summary>
        /// <value>Ответы:    immediatePublishingForbidden - Пользователь не имеет права незамедлительно опубликовать отложенное объявление   announcementDoesNotExist - Объявление не существует </value>
        [TypeConverter(typeof(CustomEnumConverter<PublishImmediatelyDelayedAnnouncementResponses>))]
        [JsonConverter(typeof(Newtonsoft.Json.Converters.StringEnumConverter))]
        public enum PublishImmediatelyDelayedAnnouncementResponses
        {
            
            /// <summary>
            /// Enum ImmediatePublishingForbidden for immediatePublishingForbidden
            /// </summary>
            [EnumMember(Value = "immediatePublishingForbidden")]
            ImmediatePublishingForbidden = 1,
            
            /// <summary>
            /// Enum AnnouncementDoesNotExist for announcementDoesNotExist
            /// </summary>
            [EnumMember(Value = "announcementDoesNotExist")]
            AnnouncementDoesNotExist = 2
        }
}
