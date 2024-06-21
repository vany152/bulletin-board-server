/*
 * API Шлюз. Опросы
 *
 * API шлюза для управления опросами
 *
 * The version of the OpenAPI document: 1.0.0
 *
 * Generated by: https://openapi-generator.tech
 */

using System.ComponentModel;
using System.Runtime.Serialization;
using BulletInBoardServer.Controllers.SurveysController.Converters;
using Newtonsoft.Json;

namespace BulletInBoardServer.Controllers.SurveysController.Models
{ 
        /// <summary>
        /// Ответы:   surveyResultsAccessForbidden - Пользователь не имеет права получить результаты этого опроса   surveyDoesNotExist - Опрос не существует   announcementWithSurveyNotYetPublished - Объявление с опросом еще не опубликовано 
        /// </summary>
        /// <value>Ответы:   surveyResultsAccessForbidden - Пользователь не имеет права получить результаты этого опроса   surveyDoesNotExist - Опрос не существует   announcementWithSurveyNotYetPublished - Объявление с опросом еще не опубликовано </value>
        [TypeConverter(typeof(CustomEnumConverter<GetSurveysResultsResponses>))]
        [JsonConverter(typeof(Newtonsoft.Json.Converters.StringEnumConverter))]
        public enum GetSurveysResultsResponses
        {
            
            /// <summary>
            /// Enum SurveyResultsAccessForbidden for surveyResultsAccessForbidden
            /// </summary>
            [EnumMember(Value = "surveyResultsAccessForbidden")]
            SurveyResultsAccessForbidden = 1,
            
            /// <summary>
            /// Enum SurveyDoesNotExist for surveyDoesNotExist
            /// </summary>
            [EnumMember(Value = "surveyDoesNotExist")]
            SurveyDoesNotExist = 2,
            
            /// <summary>
            /// Enum AnnouncementWithSurveyNotYetPublished for announcementWithSurveyNotYetPublished
            /// </summary>
            [EnumMember(Value = "announcementWithSurveyNotYetPublished")]
            AnnouncementWithSurveyNotYetPublished = 3
        }
}