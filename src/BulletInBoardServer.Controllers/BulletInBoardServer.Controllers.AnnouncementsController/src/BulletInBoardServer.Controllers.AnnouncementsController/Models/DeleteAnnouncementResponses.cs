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
        /// Ответы:   announcementDeletionForbidden - Пользователь не имеет права удалить объявление   announcementDoesNotExist - Объявление не существует 
        /// </summary>
        /// <value>Ответы:   announcementDeletionForbidden - Пользователь не имеет права удалить объявление   announcementDoesNotExist - Объявление не существует </value>
        [TypeConverter(typeof(CustomEnumConverter<DeleteAnnouncementResponses>))]
        [JsonConverter(typeof(Newtonsoft.Json.Converters.StringEnumConverter))]
        public enum DeleteAnnouncementResponses
        {
            
            /// <summary>
            /// Enum AnnouncementDeletionForbidden for announcementDeletionForbidden
            /// </summary>
            [EnumMember(Value = "announcementDeletionForbidden")]
            AnnouncementDeletionForbidden = 1,
            
            /// <summary>
            /// Enum AnnouncementDoesNotExist for announcementDoesNotExist
            /// </summary>
            [EnumMember(Value = "announcementDoesNotExist")]
            AnnouncementDoesNotExist = 2
        }
}
