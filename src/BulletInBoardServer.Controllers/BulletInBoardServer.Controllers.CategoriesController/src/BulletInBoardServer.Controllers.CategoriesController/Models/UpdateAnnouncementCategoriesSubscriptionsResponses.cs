/*
 * API Шлюз. Категории объявлений
 *
 * API Шлюза для управления категориями объявлений
 *
 * The version of the OpenAPI document: 0.0.4
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
        /// Ответы:   updateSubscriptionsForbidden - Пользователь не имеет права получить список категорий объявлений, на которые подписан   categoriesDoNotExist - В качестве одного или нескольких id категорий объявлений прикреплен несуществующий в базе id
        /// </summary>
        /// <value>Ответы:   updateSubscriptionsForbidden - Пользователь не имеет права получить список категорий объявлений, на которые подписан   categoriesDoNotExist - В качестве одного или нескольких id категорий объявлений прикреплен несуществующий в базе id</value>
        [TypeConverter(typeof(CustomEnumConverter<UpdateAnnouncementCategoriesSubscriptionsResponses>))]
        [JsonConverter(typeof(Newtonsoft.Json.Converters.StringEnumConverter))]
        public enum UpdateAnnouncementCategoriesSubscriptionsResponses
        {
            
            /// <summary>
            /// Enum UpdateSubscriptionsForbidden for updateSubscriptionsForbidden
            /// </summary>
            [EnumMember(Value = "updateSubscriptionsForbidden")]
            UpdateSubscriptionsForbidden = 1,
            
            /// <summary>
            /// Enum CategoriesDoNotExist for categoriesDoNotExist
            /// </summary>
            [EnumMember(Value = "categoriesDoNotExist")]
            CategoriesDoNotExist = 2
        }
}