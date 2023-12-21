using System;
using System.Security.Claims;
using backend_dot_net_core.Core.DbContext;
using backend_dot_net_core.Core.Dtos.General;
using backend_dot_net_core.Core.Dtos.Message;
using backend_dot_net_core.Core.Entities;
using backend_dot_net_core.Core.Interfaces;
using Microsoft.AspNetCore.Identity;
using Microsoft.EntityFrameworkCore;

namespace backend_dot_net_core.Core.Services
{
    public class MessageService : IMessageService
    {
        private readonly ApplicationDbContext _context;
        private readonly ILogService _LogService;
        private readonly UserManager<ApplicationUser> _userManager;

    public MessageService(ApplicationDbContext context, ILogService logService, UserManager<ApplicationUser> userManager)
        {
            _context = context;
            _LogService = logService;
            _userManager = userManager;

        }

        public async Task<GeneralServiceResponseDto> CreateNewMessageAsync(ClaimsPrincipal User, CreateMessageDto createMessage)
        {
            if (User.Identity.Name == createMessage.ReceiverUserName)

                return new GeneralServiceResponseDto()
                {
                    IsSucceed = false,
                    StatusCode = 400,
                    Message = "Sender and Receiver can not be the same!"
                };

            var IsReceiverUserNameValid = _userManager.Users.Any(q => q.UserName == createMessage.ReceiverUserName);
            if (!IsReceiverUserNameValid)
                return new GeneralServiceResponseDto()
                {
                    IsSucceed = false,
                    StatusCode = 400,
                    Message = "Receiver UserName is not valid"
                };

            

            Message newMessage = new Message()
            {
                SenderUserName = User.Identity.Name,
                ReceiverUserName = createMessage.ReceiverUserName,
                Text = createMessage.Text
        };

            await _context.Messages.AddAsync(newMessage);
            await _context.SaveChangesAsync();
            await _LogService.SaveNewLog(User.Identity.Name, "Send Message");

            return new GeneralServiceResponseDto()
            {
                IsSucceed = true,
                StatusCode = 2001,
                Message = "The Message saved Successfully"
            };

        }

        public async Task<IEnumerable<GetMessageDto>> GetMessagesAsync()
        {
            var messages = await _context.Messages
                .Select(q => new GetMessageDto()
                {
                    Id = q.Id,
                    SenderUserName = q.SenderUserName,
                    ReceiverUserName = q.ReceiverUserName,
                    Text = q.Text,
                    CreatedAt = q.CreatedAt

                })
                .OrderByDescending(q => q.CreatedAt)
                .ToListAsync();

            return messages;
        }

        public async Task<IEnumerable<GetMessageDto>> GetMyMessagesAsync(ClaimsPrincipal User)
        {
            var loggedInUser = User.Identity.Name;
            var messages = await _context.Messages
               .Where (q => q.SenderUserName == loggedInUser || q.ReceiverUserName == loggedInUser)
               .Select(q => new GetMessageDto()
               {
                   Id = q.Id,
                   SenderUserName = q.SenderUserName,
                   ReceiverUserName = q.ReceiverUserName,
                   Text = q.Text,
                   CreatedAt = q.CreatedAt

               })
               .OrderByDescending(q => q.CreatedAt)
               .ToListAsync();

            return messages;

        }
    }
}

