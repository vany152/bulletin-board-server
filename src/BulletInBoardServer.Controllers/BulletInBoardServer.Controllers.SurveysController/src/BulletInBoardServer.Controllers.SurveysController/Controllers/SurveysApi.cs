/*
 * API Шлюз. Опросы
 *
 * API шлюза для управления опросами
 *
 * The version of the OpenAPI document: 1.0.0
 *
 * Generated by: https://openapi-generator.tech
 */

using System;
using System.ComponentModel.DataAnnotations;
using BulletInBoardServer.Controllers.SurveysController.Attributes;
using BulletInBoardServer.Controllers.SurveysController.Models;
using Microsoft.AspNetCore.Mvc;

namespace BulletInBoardServer.Controllers.SurveysController.Controllers
{ 
    /// <summary>
    /// 
    /// </summary>
    [ApiController]
    public abstract class SurveysApiController : ControllerBase
    { 
        /// <summary>
        /// Закрыть опрос
        /// </summary>
        /// <param name="xUserId"></param>
        /// <param name="body"></param>
        /// <response code="200">Ok</response>
        /// <response code="400">Bad Request</response>
        /// <response code="401">Unauthorized</response>
        /// <response code="403">Forbidden</response>
        /// <response code="404">Not Found</response>
        /// <response code="409">Conflict</response>
        /// <response code="500">Internal Server Error</response>
        [HttpPost]
        [Route("/api/surveys/close-survey")]
        [Consumes("application/json")]
        [ValidateModelState]
        [ProducesResponseType(statusCode: 403, type: typeof(CloseSurveyForbidden))]
        [ProducesResponseType(statusCode: 404, type: typeof(CloseSurveyNotFound))]
        [ProducesResponseType(statusCode: 409, type: typeof(CloseSurveyConflict))]
        public abstract IActionResult CloseSurvey([FromHeader][Required()]Guid xUserId, [FromBody]Guid body);

        /// <summary>
        /// Создать опрос
        /// </summary>
        /// <param name="xUserId"></param>
        /// <param name="rootUserGroupId">Корневая группа пользователей, от которой запрашивается операция</param>
        /// <param name="createSurveyDto"></param>
        /// <response code="201">Created</response>
        /// <response code="401">Unauthorized</response>
        /// <response code="403">Forbidden</response>
        /// <response code="500">Internal Server Error</response>
        [HttpPost]
        [Route("/api/surveys/create")]
        [Consumes("application/json")]
        [ValidateModelState]
        [ProducesResponseType(statusCode: 201, type: typeof(Guid))]
        [ProducesResponseType(statusCode: 403, type: typeof(CreateSurveyForbidden))]
        public abstract IActionResult CreateSurvey([FromHeader][Required()]Guid xUserId, [FromHeader][Required()]Guid rootUserGroupId, [FromBody]CreateSurveyDto createSurveyDto);

        /// <summary>
        /// Скачать результаты опроса
        /// </summary>
        /// <param name="xUserId"></param>
        /// <param name="id">Идентификатор опроса</param>
        /// <param name="filetype">Тип файла с результатами опроса</param>
        /// <response code="200">Ok</response>
        /// <response code="400">Bad Request</response>
        /// <response code="401">Unauthorized</response>
        /// <response code="403">Forbidden</response>
        /// <response code="404">Not Found</response>
        /// <response code="409">Conflict</response>
        /// <response code="500">Internal Server Error</response>
        [HttpGet]
        [Route("/api/surveys/download-results/{id}/{filetype}")]
        [ValidateModelState]
        [ProducesResponseType(statusCode: 200, type: typeof(DownloadSurveyResultsOk))]
        [ProducesResponseType(statusCode: 400, type: typeof(DownloadSurveyResultsForbidden))]
        [ProducesResponseType(statusCode: 403, type: typeof(DownloadSurveyResultsForbidden))]
        [ProducesResponseType(statusCode: 404, type: typeof(DownloadSurveyResultsNotFound))]
        [ProducesResponseType(statusCode: 409, type: typeof(DownloadSurveyResultsConflict))]
        public abstract IActionResult DownloadSurveyResults([FromHeader][Required()]Guid xUserId, [FromRoute (Name = "id")][Required]Guid id, [FromRoute (Name = "filetype")][Required]string filetype);

        /// <summary>
        /// Проголосовать в опросе
        /// </summary>
        /// <param name="xUserId"></param>
        /// <param name="voteInSurveyDto"></param>
        /// <response code="200">Ok</response>
        /// <response code="400">Bad Request</response>
        /// <response code="401">Unauthorized</response>
        /// <response code="403">Forbidden</response>
        /// <response code="404">Not Found</response>
        /// <response code="409">Conflict</response>
        /// <response code="500">Internal Server Error</response>
        [HttpPost]
        [Route("/api/surveys/vote")]
        [Consumes("application/json")]
        [ValidateModelState]
        [ProducesResponseType(statusCode: 403, type: typeof(VoteInQuestionForbidden))]
        [ProducesResponseType(statusCode: 404, type: typeof(VoteInQuestionNotFound))]
        [ProducesResponseType(statusCode: 409, type: typeof(VoteInQuestionConflict))]
        public abstract IActionResult VoteInSurvey([FromHeader][Required()]Guid xUserId, [FromBody]VoteInSurveyDto voteInSurveyDto);
    }
}
