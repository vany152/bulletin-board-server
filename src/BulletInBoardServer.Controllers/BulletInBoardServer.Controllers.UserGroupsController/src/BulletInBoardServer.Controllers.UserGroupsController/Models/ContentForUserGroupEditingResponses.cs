/*
 * API Шлюз. Группы пользователей
 *
 * API шлюза для управления группами пользователей
 *
 * The version of the OpenAPI document: 1.0.0
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
        /// Ответы: getUsergroupUpdateContentForbidden - Пользователь не имеет права запрашивать данные для редактирования групп пользователей userGroupDoesNotExist - В качестве id группы пользователей прикреплен несуществующий в базе id 
        /// </summary>
        /// <value>Ответы: getUsergroupUpdateContentForbidden - Пользователь не имеет права запрашивать данные для редактирования групп пользователей userGroupDoesNotExist - В качестве id группы пользователей прикреплен несуществующий в базе id </value>
        [TypeConverter(typeof(CustomEnumConverter<ContentForUserGroupEditingResponses>))]
        [JsonConverter(typeof(Newtonsoft.Json.Converters.StringEnumConverter))]
        public enum ContentForUserGroupEditingResponses
        {
            
            /// <summary>
            /// Enum GetUsergroupUpdateContentForbidden for getUsergroupUpdateContentForbidden
            /// </summary>
            [EnumMember(Value = "getUsergroupUpdateContentForbidden")]
            GetUsergroupUpdateContentForbidden = 1,
            
            /// <summary>
            /// Enum UserGroupDoesNotExist for userGroupDoesNotExist
            /// </summary>
            [EnumMember(Value = "userGroupDoesNotExist")]
            UserGroupDoesNotExist = 2
        }
}
