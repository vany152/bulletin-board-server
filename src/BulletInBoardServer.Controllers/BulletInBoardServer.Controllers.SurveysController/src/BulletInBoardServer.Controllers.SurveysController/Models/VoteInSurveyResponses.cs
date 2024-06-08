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
        /// Ответы:   votingForbidden - Пользователь не имеет права голосовать в опросе   surveyDoesNotExist - Опрос не существует   surveyClosed - Опрос закрыт   surveyAlreadyVoted - Голос в опросе уже отдан   cannotSelectMultipleAnswersInSingleChoiceQuestion - В вопросе с единственным выбором нельзя выбрать несколько вариантов ответов   presentedQuestionsDoesntMatchSurveyQuestions - Список представленных вопросов не соответствует фактическому списку вопросов опроса   presentedVotesDoesntMatchQuestionAnswers - Список выбранных вариантов ответов для одного или нескольких вопросов не включается в список вариантов ответов вопроса 
        /// </summary>
        /// <value>Ответы:   votingForbidden - Пользователь не имеет права голосовать в опросе   surveyDoesNotExist - Опрос не существует   surveyClosed - Опрос закрыт   surveyAlreadyVoted - Голос в опросе уже отдан   cannotSelectMultipleAnswersInSingleChoiceQuestion - В вопросе с единственным выбором нельзя выбрать несколько вариантов ответов   presentedQuestionsDoesntMatchSurveyQuestions - Список представленных вопросов не соответствует фактическому списку вопросов опроса   presentedVotesDoesntMatchQuestionAnswers - Список выбранных вариантов ответов для одного или нескольких вопросов не включается в список вариантов ответов вопроса </value>
        [TypeConverter(typeof(CustomEnumConverter<VoteInSurveyResponses>))]
        [JsonConverter(typeof(Newtonsoft.Json.Converters.StringEnumConverter))]
        public enum VoteInSurveyResponses
        {
            
            /// <summary>
            /// Enum VotingForbidden for votingForbidden
            /// </summary>
            [EnumMember(Value = "votingForbidden")]
            VotingForbidden = 1,
            
            /// <summary>
            /// Enum SurveyDoesNotExist for surveyDoesNotExist
            /// </summary>
            [EnumMember(Value = "surveyDoesNotExist")]
            SurveyDoesNotExist = 2,
            
            /// <summary>
            /// Enum SurveyClosed for surveyClosed
            /// </summary>
            [EnumMember(Value = "surveyClosed")]
            SurveyClosed = 3,
            
            /// <summary>
            /// Enum SurveyAlreadyVoted for surveyAlreadyVoted
            /// </summary>
            [EnumMember(Value = "surveyAlreadyVoted")]
            SurveyAlreadyVoted = 4,
            
            /// <summary>
            /// Enum CannotSelectMultipleAnswersInSingleChoiceQuestion for cannotSelectMultipleAnswersInSingleChoiceQuestion
            /// </summary>
            [EnumMember(Value = "cannotSelectMultipleAnswersInSingleChoiceQuestion")]
            CannotSelectMultipleAnswersInSingleChoiceQuestion = 5,
            
            /// <summary>
            /// Enum PresentedQuestionsDoesntMatchSurveyQuestions for presentedQuestionsDoesntMatchSurveyQuestions
            /// </summary>
            [EnumMember(Value = "presentedQuestionsDoesntMatchSurveyQuestions")]
            PresentedQuestionsDoesntMatchSurveyQuestions = 6,
            
            /// <summary>
            /// Enum PresentedVotesDoesntMatchQuestionAnswers for presentedVotesDoesntMatchQuestionAnswers
            /// </summary>
            [EnumMember(Value = "presentedVotesDoesntMatchQuestionAnswers")]
            PresentedVotesDoesntMatchQuestionAnswers = 7
        }
}
