/*
 * API Шлюз. Категории объявлений
 *
 * API Шлюза для управления категориями объявлений
 *
 * The version of the OpenAPI document: 0.0.2
 *
 * Generated by: https://openapi-generator.tech
 */

using System.ComponentModel;
using System.Runtime.Serialization;
using BulletInBoardServer.Controllers.CategoriesController.Converters;
using Newtonsoft.Json;

namespace BulletInBoardServer.Controllers.CategoriesController.Models
{ 
        /// <summary>
        /// Ответы:   nameIsNullOrEmpty - Название категории объявлений null, пустое или состоит только из пробельных символов   colorIsInvalidHex - Код цвета передан не в HEX формате    announcementCategoryCreationForbidden - Пользователь не имеет права создать категорию объявлений 
        /// </summary>
        /// <value>Ответы:   nameIsNullOrEmpty - Название категории объявлений null, пустое или состоит только из пробельных символов   colorIsInvalidHex - Код цвета передан не в HEX формате    announcementCategoryCreationForbidden - Пользователь не имеет права создать категорию объявлений </value>
        [TypeConverter(typeof(CustomEnumConverter<CreateAnnouncementCategoryResponses>))]
        [JsonConverter(typeof(Newtonsoft.Json.Converters.StringEnumConverter))]
        public enum CreateAnnouncementCategoryResponses
        {
            
            /// <summary>
            /// Enum NameIsNullOrEmpty for nameIsNullOrEmpty
            /// </summary>
            [EnumMember(Value = "nameIsNullOrEmpty")]
            NameIsNullOrEmpty = 1,
            
            /// <summary>
            /// Enum ColorIsInvalidHex for colorIsInvalidHex
            /// </summary>
            [EnumMember(Value = "colorIsInvalidHex")]
            ColorIsInvalidHex = 2,
            
            /// <summary>
            /// Enum AnnouncementCategoryCreationForbidden for announcementCategoryCreationForbidden
            /// </summary>
            [EnumMember(Value = "announcementCategoryCreationForbidden")]
            AnnouncementCategoryCreationForbidden = 3
        }
}
