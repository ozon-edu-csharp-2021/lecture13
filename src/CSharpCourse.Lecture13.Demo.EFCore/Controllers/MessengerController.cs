using System.Linq;
using System.Threading.Tasks;
using CSharpCourse.Lecture13.Demo.EFCore.DbContexts;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;

namespace CSharpCourse.Lecture13.Demo.EFCore.Controllers
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
                .AsNoTracking()
                .ToListAsync();

            return Ok(messagesForChat);
        }
    }
}