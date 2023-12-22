using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using backend_dot_net_core.Core.Dtos.Message;
using backend_dot_net_core.Core.Interfaces;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;

// For more information on enabling Web API for empty projects, visit https://go.microsoft.com/fwlink/?LinkID=397860

namespace backend_dot_net_core.Controllers
{
    [Route("api/[controller]")]
    public class MessagesController : Controller
    {
        private IMessageService _messageService;
        public MessagesController (IMessageService messageService)
        {
            _messageService =messageService;
        }

        [HttpPost]
        [Route("create")]
        [Authorize("Every boddy is welcome")]
        public async Task<IActionResult> CreateNewMessage([FromBody] CreateMessageDto createMessageDto)
        {
            var result = await _messageService.CreateNewMessageAsync(User, createMessageDto);
            if (result.IsSucceed)
                return Ok(result.Message);

            return StatusCode(result.StatusCode, result.Message);


        }



        [HttpPost]
        [Route("mine")]
        [Authorize]
        public async Task<ActionResult<IEnumerable<GetMessageDto>>> GetMyMessages()
        {
            var messages = await _messageService.GetMyMessagesAsync(User);
            return Ok(messages);
        } 





    }
}

