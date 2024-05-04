/*
 * API Шлюз. Группы пользователей
 *
 * API шлюза для управления группами пользователей
 *
 * The version of the OpenAPI document: 0.0.3
 *
 * Generated by: https://openapi-generator.tech
 */

using System.ComponentModel;
using System.Runtime.Serialization;
using BulletInBoardServer.Controllers.UserGroupsController.Converters;
using Newtonsoft.Json;
using Newtonsoft.Json.Converters;

namespace BulletInBoardServer.Controllers.UserGroupsController.Models
{ 
        /// <summary>
        /// Ответы:   getOwnedUsergroupsForbidden - Пользователь не имеет права получать список групп пользователей, которыми управляет 
        /// </summary>
        /// <value>Ответы:   getOwnedUsergroupsForbidden - Пользователь не имеет права получать список групп пользователей, которыми управляет </value>
        [TypeConverter(typeof(CustomEnumConverter<GetOwnedUsergroupsResponses>))]
        [JsonConverter(typeof(StringEnumConverter))]
        public enum GetOwnedUsergroupsResponses
        {
            
            /// <summary>
            /// Enum GetOwnedUsergroupsForbidden for getOwnedUsergroupsForbidden
            /// </summary>
            [EnumMember(Value = "getOwnedUsergroupsForbidden")]
            GetOwnedUsergroupsForbidden = 1
        }
}
