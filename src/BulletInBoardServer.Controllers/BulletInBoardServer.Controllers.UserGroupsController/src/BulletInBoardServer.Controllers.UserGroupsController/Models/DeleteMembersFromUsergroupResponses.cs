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
        /// Ответы:   addMembersToUsergroupForbidden - Пользователь не имеет права удалить пользователя из группы пользователей   userIsAdmin - В качестве одного из id прикреплен id пользователя, являющегося администратором этой группы пользователей 
        /// </summary>
        /// <value>Ответы:   addMembersToUsergroupForbidden - Пользователь не имеет права удалить пользователя из группы пользователей   userIsAdmin - В качестве одного из id прикреплен id пользователя, являющегося администратором этой группы пользователей </value>
        [TypeConverter(typeof(CustomEnumConverter<DeleteMembersFromUsergroupResponses>))]
        [JsonConverter(typeof(Newtonsoft.Json.Converters.StringEnumConverter))]
        public enum DeleteMembersFromUsergroupResponses
        {
            
            /// <summary>
            /// Enum RemoveUsersFromUsergroupForbidden for removeUsersFromUsergroupForbidden
            /// </summary>
            [EnumMember(Value = "removeUsersFromUsergroupForbidden")]
            RemoveUsersFromUsergroupForbidden = 1,
            
            /// <summary>
            /// Enum UserIsAdmin for userIsAdmin
            /// </summary>
            [EnumMember(Value = "userIsAdmin")]
            UserIsAdmin = 2
        }
}
