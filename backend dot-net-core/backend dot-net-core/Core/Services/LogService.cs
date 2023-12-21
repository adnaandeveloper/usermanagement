using System;
using System.Security.Claims;
using backend_dot_net_core.Core.DbContext;
using backend_dot_net_core.Core.Dtos.Log;
using backend_dot_net_core.Core.Entities;
using backend_dot_net_core.Core.Interfaces;
using Microsoft.EntityFrameworkCore;

namespace backend_dot_net_core.Core.Services
{
    public class LogService : ILogService
    {

        private readonly ApplicationDbContext _context;

        public LogService(ApplicationDbContext context) { _context = context; }

        public async Task  SaveNewLog(string Username, string Description)
        {
            var newLog = new Log()
            {
                UserName = Username,
                Description = Description,
            };

            await _context.Logs.AddAsync(newLog);
            await _context.SaveChangesAsync();

        }

        public async Task<IEnumerable<GetLogDto>> GetLogsAync()
        {
            var logs = await _context.Logs
                .Select(q => new GetLogDto
                {
                    CreatedAt = q.CreatedAt,
                    Description = q.Description,
                    UserName = q.UserName,

                })
                .OrderByDescending(q => q.CreatedAt)
                .ToListAsync();

            return logs;

        }

        public async Task<IEnumerable<GetLogDto>> GetMyLogsAync(ClaimsPrincipal User)
        {

            var logs = await _context.Logs
                .Where(q => q.UserName == User.Identity.Name)
                .Select(q => new GetLogDto
                {
                    CreatedAt = q.CreatedAt,
                    Description = q.Description,
                    UserName = q.UserName,

                })
                .OrderByDescending(q => q.CreatedAt)
                .ToListAsync();

            return logs;

        }

      
    }
}

