﻿using System.Linq;
using System.Threading.Tasks;
using CSharpCourse.Lecture13.Demo.Linq2DB.DbContexts;
using LinqToDB;
using Microsoft.AspNetCore.Mvc;

namespace CSharpCourse.Lecture13.Demo.Linq2DB.Controllers
{
    public class MessengerController : Controller
    {
        private readonly MessengerDbContext _messengerDbContext;
        
        public MessengerController(MessengerDbContext messengerDbContext)
        {
            _messengerDbContext = messengerDbContext;
        }

        [HttpGet("messages/{chatId:int}")]
        public async Task<ActionResult> GetAllMessages(int chatId)
        {
            var messagesForChat = await _messengerDbContext.Messages
                .Where(it => it.ChatId == chatId)
                .ToListAsync();
            
            //_messengerDbContext.Messages.UpdateAsync();

            return Ok(messagesForChat);
        }
    }
}