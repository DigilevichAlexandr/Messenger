using Messenger.Data;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Messenger.Controllers
{
    [Authorize]
    [ApiController]
    [Route("[controller]")]
    public class MessagesController : ControllerBase
    {
        private readonly ApplicationDbContext db;

        public MessagesController(ApplicationDbContext db)
        {
            this.db = db;
        }

        // GET: MessagesController
        public ActionResult Index()
        {
            return Ok();
        }

        // GET: MessagesController/Details/5
        public ActionResult Details(int id)
        {
            return Ok();
        }

        // GET: MessagesController/Create
        public ActionResult Create()
        {
            return Ok();
        }

        // POST: MessagesController/Create
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Create(IFormCollection collection)
        {
            try
            {
                return RedirectToAction(nameof(Index));
            }
            catch
            {
                return Ok();
            }
        }

        // GET: MessagesController/Edit/5
        public ActionResult Edit(int id)
        {
            return Ok();
        }

        // POST: MessagesController/Edit/5
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Edit(int id, IFormCollection collection)
        {
            try
            {
                return RedirectToAction(nameof(Index));
            }
            catch
            {
                return Ok();
            }
        }

        // GET: MessagesController/Delete/5
        public ActionResult Delete(int id)
        {
            return Ok();
        }

        // POST: MessagesController/Delete/5
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Delete(int id, IFormCollection collection)
        {
            try
            {
                return RedirectToAction(nameof(Index));
            }
            catch
            {
                return Ok();
            }
        }
    }
}
