/*
 * API Шлюз. Объявления
 *
 * API шлюза для управления объявлениями
 *
 * The version of the OpenAPI document: 0.0.2
 *
 * Generated by: https://openapi-generator.tech
 */

using System;
using BulletInBoardServer.Controllers.AnnouncementsController.Attributes;
using BulletInBoardServer.Controllers.AnnouncementsController.Models;
using Microsoft.AspNetCore.Mvc;

namespace BulletInBoardServer.Controllers.AnnouncementsController.Controllers
{ 
    /// <summary>
    /// 
    /// </summary>
    [ApiController]
    public abstract class AnnouncementsApiController : ControllerBase
    { 
        /// <summary>
        /// Создать объявление
        /// </summary>
        /// <param name="createAnnouncementDto"></param>
        /// <response code="201">Created</response>
        /// <response code="400">Bad Request</response>
        /// <response code="401">Unauthorized</response>
        /// <response code="403">Forbidden</response>
        /// <response code="404">Not Found</response>
        /// <response code="409">Conflict</response>
        /// <response code="500">Internal Server Error</response>
        [HttpPost]
        [Route("/api/announcements/create")]
        [Consumes("application/json")]
        [ValidateModelState]
        [ProducesResponseType(statusCode: 201, type: typeof(CreateAnnouncementCreated))]
        [ProducesResponseType(statusCode: 400, type: typeof(CreateAnnouncement400Response))]
        [ProducesResponseType(statusCode: 403, type: typeof(CreateAnnouncementForbidden))]
        [ProducesResponseType(statusCode: 404, type: typeof(CreateAnnouncementNotFound))]
        [ProducesResponseType(statusCode: 409, type: typeof(CreateAnnouncementConflict))]
        public abstract IActionResult CreateAnnouncement([FromBody]CreateAnnouncementDto createAnnouncementDto);

        /// <summary>
        /// Удалить объявление
        /// </summary>
        /// <param name="body"></param>
        /// <response code="200">Ok</response>
        /// <response code="400">Bad Request</response>
        /// <response code="401">Unauthorized</response>
        /// <response code="403">Forbidden</response>
        /// <response code="404">Not Found</response>
        /// <response code="500">Internal Server Error</response>
        [HttpDelete]
        [Route("/api/announcements/delete")]
        [Consumes("application/json")]
        [ValidateModelState]
        [ProducesResponseType(statusCode: 403, type: typeof(DeleteAnnouncementForbidden))]
        [ProducesResponseType(statusCode: 404, type: typeof(DeleteAnnouncementNotFound))]
        public abstract IActionResult DeleteAnnouncement([FromBody]Guid body);

        /// <summary>
        /// Получить подробности о выбранном объявлении
        /// </summary>
        /// <param name="body"></param>
        /// <response code="200">Ok</response>
        /// <response code="400">Bad Request</response>
        /// <response code="401">Unauthorized</response>
        /// <response code="403">Forbidden</response>
        /// <response code="404">Not Found</response>
        /// <response code="500">Internal Server Error</response>
        [HttpGet]
        [Route("/api/announcements/get-details")]
        [Consumes("application/json")]
        [ValidateModelState]
        [ProducesResponseType(statusCode: 200, type: typeof(GetAnnouncementDetailsOk))]
        [ProducesResponseType(statusCode: 403, type: typeof(GetAnnouncementDetailsForbidden))]
        [ProducesResponseType(statusCode: 404, type: typeof(GetAnnouncementDetailsNotFound))]
        public abstract IActionResult GetAnnouncementDetails([FromBody]Guid body);

        /// <summary>
        /// Получить список объявлений, ожидающих отложенное сокрытие
        /// </summary>
        /// <response code="200">Ok</response>
        /// <response code="401">Unauthorized</response>
        /// <response code="403">Forbidden</response>
        /// <response code="500">Internal Server Error</response>
        [HttpGet]
        [Route("/api/announcements/delayed-hidden/get-list")]
        [ValidateModelState]
        [ProducesResponseType(statusCode: 200, type: typeof(GetDelayedHiddenAnnouncementListOk))]
        [ProducesResponseType(statusCode: 403, type: typeof(GetDelayedHiddenAnnouncementListForbidden))]
        public abstract IActionResult GetDelayedHiddenAnnouncementList();

        /// <summary>
        /// Получить список объявлений, ожидающих отложенную публикацию
        /// </summary>
        /// <response code="200">Ok</response>
        /// <response code="401">Unauthorized</response>
        /// <response code="403">Forbidden</response>
        /// <response code="500">Internal Server Error</response>
        [HttpGet]
        [Route("/api/announcements/delayed-publishing/get-list")]
        [ValidateModelState]
        [ProducesResponseType(statusCode: 200, type: typeof(GetDelayedPublishingAnnouncementListOk))]
        [ProducesResponseType(statusCode: 403, type: typeof(GetDelayedPublishingAnnouncementListForbidden))]
        public abstract IActionResult GetDelayedPublishingAnnouncementList();

        /// <summary>
        /// Получить список скрытых объявлений
        /// </summary>
        /// <response code="200">Ok</response>
        /// <response code="401">Unauthorized</response>
        /// <response code="403">Forbidden</response>
        /// <response code="500">Internal Server Error</response>
        [HttpGet]
        [Route("/api/announcements/hidden/get-list")]
        [ValidateModelState]
        [ProducesResponseType(statusCode: 200, type: typeof(GetHiddenAnnouncementListOk))]
        [ProducesResponseType(statusCode: 403, type: typeof(GetHiddenAnnouncementListForbidden))]
        public abstract IActionResult GetHiddenAnnouncementList();

        /// <summary>
        /// Получить список опубликованных объявлений
        /// </summary>
        /// <response code="200">Ok</response>
        /// <response code="401">Unauthorized</response>
        /// <response code="403">Forbidden</response>
        /// <response code="500">Internal Server Error</response>
        [HttpGet]
        [Route("/api/announcements/published/get-list")]
        [ValidateModelState]
        [ProducesResponseType(statusCode: 200, type: typeof(GetPostedAnnouncementListOk))]
        [ProducesResponseType(statusCode: 403, type: typeof(GetPostedAnnouncementListForbidden))]
        public abstract IActionResult GetPostedAnnouncementList();

        /// <summary>
        /// Скрыть опубликованное объявление
        /// </summary>
        /// <param name="body"></param>
        /// <response code="200">Ok</response>
        /// <response code="400">Bad Request</response>
        /// <response code="401">Unauthorized</response>
        /// <response code="403">Forbidden</response>
        /// <response code="404">Not Found</response>
        /// <response code="409">Conflict</response>
        /// <response code="500">Internal Server Error</response>
        [HttpPost]
        [Route("/api/announcements/published/hide")]
        [Consumes("application/json")]
        [ValidateModelState]
        [ProducesResponseType(statusCode: 403, type: typeof(HidePostedAnnouncementForbidden))]
        [ProducesResponseType(statusCode: 404, type: typeof(HidePostedAnnouncementNotFound))]
        [ProducesResponseType(statusCode: 409, type: typeof(HidePostedAnnouncementConflict))]
        public abstract IActionResult HidePostedAnnouncement([FromBody]Guid body);

        /// <summary>
        /// Сразу опубликовать отложенное объявление
        /// </summary>
        /// <param name="body"></param>
        /// <response code="200">Ok</response>
        /// <response code="400">Bad Request</response>
        /// <response code="401">Unauthorized</response>
        /// <response code="403">Forbidden</response>
        /// <response code="404">Not Found</response>
        /// <response code="500">Internal Server Error</response>
        [HttpPost]
        [Route("/api/announcements/delayed-publishing/publish-immediately")]
        [Consumes("application/json")]
        [ValidateModelState]
        [ProducesResponseType(statusCode: 403, type: typeof(PublishImmediatelyDelayedPublishingAnnouncementForbidden))]
        [ProducesResponseType(statusCode: 404, type: typeof(PublishImmediatelyDelayedPublishingAnnouncementNotFound))]
        public abstract IActionResult PublishImmediatelyDelayedPublishingAnnouncement([FromBody]Guid body);

        /// <summary>
        /// Восстановить скрытое объявление
        /// </summary>
        /// <param name="body"></param>
        /// <response code="200">Ok</response>
        /// <response code="400">Bad Request</response>
        /// <response code="401">Unauthorized</response>
        /// <response code="403">Forbidden</response>
        /// <response code="404">Not Found</response>
        /// <response code="409">Conflict</response>
        /// <response code="500">Internal Server Error</response>
        [HttpPost]
        [Route("/api/announcements/hidden/restore")]
        [Consumes("application/json")]
        [ValidateModelState]
        [ProducesResponseType(statusCode: 403, type: typeof(RestoreHiddenAnnouncementForbidden))]
        [ProducesResponseType(statusCode: 404, type: typeof(RestoreHiddenAnnouncementNotFound))]
        [ProducesResponseType(statusCode: 409, type: typeof(RestoreHiddenAnnouncementConflict))]
        public abstract IActionResult RestoreHiddenAnnouncement([FromBody]Guid body);

        /// <summary>
        /// Редактировать объявление
        /// </summary>
        /// <param name="updateAnnouncementDto"></param>
        /// <response code="200">Ok</response>
        /// <response code="400">Bad Request</response>
        /// <response code="401">Unauthorized</response>
        /// <response code="403">Forbidden</response>
        /// <response code="404">Not Found</response>
        /// <response code="409">Conflict</response>
        /// <response code="500">Internal Server Error</response>
        [HttpPut]
        [Route("/api/announcements/update")]
        [Consumes("application/json")]
        [ValidateModelState]
        [ProducesResponseType(statusCode: 400, type: typeof(UpdateAnnouncementBadRequest))]
        [ProducesResponseType(statusCode: 403, type: typeof(UpdateAnnouncementForbidden))]
        [ProducesResponseType(statusCode: 404, type: typeof(UpdateAnnouncementNotFound))]
        [ProducesResponseType(statusCode: 409, type: typeof(UpdateAnnouncementConflict))]
        public abstract IActionResult UpdateAnnouncement([FromBody]UpdateAnnouncementDto updateAnnouncementDto);
    }
}
