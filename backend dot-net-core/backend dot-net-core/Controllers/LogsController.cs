using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using backend_dot_net_core.Core.Constants;
using backend_dot_net_core.Core.Dtos.Log;
using backend_dot_net_core.Core.Interfaces;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;

// For more information on enabling MVC for empty projects, visit https://go.microsoft.com/fwlink/?LinkID=397860

namespace backend_dot_net_core.Controllers
{
    public class LogsController : Controller
    {
        private readonly ILogService _logService;
        public LogsController(ILogService logService)
        {
            _logService = logService;

        }

        [HttpGet("Owner or Admin")]
        [Authorize(Roles = StaticUserRoles.OwnerAdmin)]
        public async Task<ActionResult<IEnumerable<GetLogDto>>> GetLogs()
        {
            var logs = await _logService.GetLogsAsync();
            return Ok(logs);
        }

        [HttpGet]
        [Route("mine")] // any body with login can see
        [Authorize]
        public async Task<ActionResult<IEnumerable<GetLogDto>>> GetMyLogs()
        {
            var logs = await _logService.GetMyLogsAsync(User);
            return Ok(logs);
        }

    }
}

