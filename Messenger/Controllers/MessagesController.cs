using Messenger.Data;
using Messenger.Data.Entities;
using Messenger.Models;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Logging;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text.Json;
using System.Threading.Tasks;

namespace Messenger.Controllers
{
    [Authorize]
    [ApiController]
    [Route("[controller]")]
    public class MessagesController : ControllerBase
    {
        private readonly ApplicationDbContext db;
        private readonly ILogger<MessagesController> logger;

        public MessagesController(ApplicationDbContext db,
            ILogger<MessagesController> logger)
        {
            this.db = db;
            this.logger = logger;
        }

        [HttpGet]
        public IAsyncEnumerable<Message> GetMessages(int id)
        {
            try
            {
                return db.Messages.AsQueryable()
                   .Where(m => m.Employee.Id == id)
                   .AsAsyncEnumerable();
            }
            catch (System.Exception ex)
            {
                logger.LogError(ex, "Error on retrieving  employees");

                return AsyncEnumerable.Empty<Message>();
            }
        }

        // GET: MessagesController/Details/5
        public ActionResult Details(int id)
        {
            return Ok();
        }

        /// <summary>
        /// Send message to employee
        /// </summary>
        /// <param name="id">Employee id</param>
        /// <param name="message">TEst message</param>
        /// <returns>Status</returns>
        [HttpPost]
        public async Task<IActionResult> Send(MessageDTO messageDTO)
        {
            await db.Messages.AddAsync(new Message
            {
                Employee = db.Employes.Find(messageDTO.Id),
                Text = messageDTO.Message
            });
            await db.SaveChangesAsync();

            return Ok();
        }
    }
}
