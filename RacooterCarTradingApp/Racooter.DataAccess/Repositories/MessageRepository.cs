using Microsoft.EntityFrameworkCore;
using Racooter.DataAccess.DbContext;
using Racooter.DataAccess.Models;
using Racooter.DataAccess.Repository;
using Racooter.DataTransferObjects.Announcement;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Racooter.DataAccess.Repositories
{
    
    public interface IMessageRepository
    {
        Task AddFirstMessage(string id, string CurrentUserId);
        Task<List<KeyValuePair<string, string>>> GetAllUsersForMessages(string userId);
        Task<List<MessageDto>> GetUserMessages(string senderId, string receiverId);
        Task SaveMessage(string messageText, string receiverId, string currentUserId);
    }
    public class MessageRepository: Repository<Message>, IMessageRepository
    {
        private readonly RacooterDbContext _context;
        public MessageRepository(RacooterDbContext context):base(context)
        {
            _context = context;
        }

        public async Task AddFirstMessage(string id, string CurrentUserId)
        {
            if (!string.IsNullOrEmpty(id))
            {
                var isAlready = await _context.Messages.Where(x => x.Recipient == id && x.CreatedBy==CurrentUserId).AnyAsync();
                if (!isAlready)
                {
                    //first message
                    var msg = new Message();
                    msg.CreatedBy = CurrentUserId;
                    msg.CreatedDate = DateTime.Now;
                    msg.IsRead = true;
                    msg.MessageText = "I want to start a conversation...";
                    msg.Recipient = id;
                    _context.Messages.Add(msg);
                    await _context.SaveChangesAsync();
                }
            }
        }

        public async Task<List<KeyValuePair<string, string>>> GetAllUsersForMessages(string userId)
        {
            List<KeyValuePair<string, string>> list = new List<KeyValuePair<string, string>>();

            var userIds = await _context.Messages.Where(x => x.CreatedBy == userId).Select(x => x.Recipient).Distinct().ToListAsync();
            var senderUserIds = await _context.Messages.Where(x => x.Recipient == userId).Select(x => x.CreatedBy).Distinct().ToListAsync();

            userIds.AddRange(senderUserIds);
            userIds = userIds.Where(x => x != userId).Distinct().ToList();

            var users = await _context.Users.Where(x => userIds.Contains(x.Id)).Select(x => new
            {
                UserId = x.Id,
                Name = x.UserName
            }).ToListAsync();

            foreach (var item in users)
            {
                list.Add(new KeyValuePair<string, string>(item.UserId, item.Name));
            }
            return list;
        }

        public async Task<List<MessageDto>> GetUserMessages(string senderId, string receiverId)
        {
            List<MessageDto> list = new List<MessageDto>();
            list = await _context.Messages.
                Where(x => (x.CreatedBy == senderId && x.Recipient == receiverId) || (x.Recipient == senderId && x.CreatedBy == receiverId) && !string.IsNullOrEmpty(x.MessageText))
                .Select(x => new MessageDto
                {
                    CreatedBy = x.CreatedBy,
                    Recipient = x.Recipient,
                    CreatedDate = x.CreatedDate,
                    MessageText = x.MessageText
                }).ToListAsync();
            return list;
        }

        public async Task SaveMessage(string messageText, string receiverId, string currentUserId)
        {
            var msg = new Message()
            {
                CreatedBy = currentUserId,
                CreatedDate = DateTime.Now,
                IsRead = true,
                MessageText = messageText,
                Recipient = receiverId
            };
            _context.Messages.Add(msg);

        }


    }
}
