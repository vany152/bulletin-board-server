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

namespace BulletInBoardServer.Controllers.UserGroupsController.Models
{ 
        /// <summary>
        /// Ответы:   getUsergroupDetailsForbidden - Пользователь не имеет права запрашивать детали группы пользователей   userGroupDoesNotExist - В качестве id группы пользователей прикреплен несуществующий в базе id  
        /// </summary>
        /// <value>Ответы:   getUsergroupDetailsForbidden - Пользователь не имеет права запрашивать детали группы пользователей   userGroupDoesNotExist - В качестве id группы пользователей прикреплен несуществующий в базе id  </value>
        [TypeConverter(typeof(CustomEnumConverter<GetUsergroupDetailsResponses>))]
        [JsonConverter(typeof(Newtonsoft.Json.Converters.StringEnumConverter))]
        public enum GetUsergroupDetailsResponses
        {
            
            /// <summary>
            /// Enum GetUsergroupDetailsForbidden for getUsergroupDetailsForbidden
            /// </summary>
            [EnumMember(Value = "getUsergroupDetailsForbidden")]
            GetUsergroupDetailsForbidden = 1,
            
            /// <summary>
            /// Enum UserGroupDoesNotExist for userGroupDoesNotExist
            /// </summary>
            [EnumMember(Value = "userGroupDoesNotExist")]
            UserGroupDoesNotExist = 2
        }
}
