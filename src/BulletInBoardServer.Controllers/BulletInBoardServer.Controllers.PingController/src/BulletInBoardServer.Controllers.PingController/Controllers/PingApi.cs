/*
 * Ping
 *
 * Проверка доступности сервиса
 *
 * The version of the OpenAPI document: 1.0.0
 *
 * Generated by: https://openapi-generator.tech
 */

using BulletInBoardServer.Controllers.PingController.Attributes;
using Microsoft.AspNetCore.Mvc;
using Swashbuckle.AspNetCore.Annotations;

namespace BulletInBoardServer.Controllers.PingController.Controllers
{ 
    /// <summary>
    /// 
    /// </summary>
    [ApiController]
    public abstract class PingApiController : ControllerBase
    { 
        /// <summary>
        /// 
        /// </summary>
        /// <response code="200">Ok</response>
        [HttpGet]
        [Route("/api/ping")]
        [ValidateModelState]
        [SwaggerOperation("Ping")]
        [SwaggerResponse(statusCode: 200, type: typeof(string), description: "Ok")]
        public abstract IActionResult Ping();
    }
}