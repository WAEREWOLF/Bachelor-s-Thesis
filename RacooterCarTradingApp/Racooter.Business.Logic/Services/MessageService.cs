using Racooter.DataAccess.Repositories;
using Racooter.DataAccess.UnitOfWork;
using Racooter.DataTransferObjects.Announcement;
using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;

namespace Racooter.Business.Logic.Services
{
    public interface IMessageService
    {
        Task AddFirstMessage(string id, string CurrentUserId);
        Task<List<KeyValuePair<string, string>>> GetAllUsersForMessages(string userId);
        Task<List<MessageDto>> GetUserMessages(string senderId, string receiverId);
        Task SaveMessage(string messageText, string receiverId, string currentUserId);
    }
    public class MessageService: IMessageService
    {
        private readonly IMessageRepository _messageRepository;
        private readonly IUnitOfWork _unitOfWork;
        public MessageService(IMessageRepository messageRepository, IUnitOfWork unitOfWork)
        {
            _messageRepository = messageRepository;
            _unitOfWork = unitOfWork;
        }

        public async Task AddFirstMessage(string id, string CurrentUserId)
        {
            await _messageRepository.AddFirstMessage(id, CurrentUserId);
        }

        public async Task<List<KeyValuePair<string, string>>> GetAllUsersForMessages(string userId)
        {
            return await _messageRepository.GetAllUsersForMessages(userId);
        }

        public async Task<List<MessageDto>> GetUserMessages(string senderId, string receiverId)
        {
            return await _messageRepository.GetUserMessages(senderId, receiverId);
        }

        public async Task SaveMessage(string messageText, string receiverId, string currentUserId)
        {
            await _messageRepository.SaveMessage(messageText, receiverId, currentUserId);
            _unitOfWork.Commit();
        }
    }
}
