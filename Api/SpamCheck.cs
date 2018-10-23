using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Api.controllers;

namespace Api
{
    public class SpamCheck : ISpamCheck
    {
        private readonly IFeedPostDataRepository _repository;
        
        public SpamCheck(
            IFeedPostDataRepository repository)
        {
            _repository = repository;
        }
        public async Task<bool> IsSpam(Post message)
        {
            var spamTime = message.Datum.AddSeconds(-3);
            try
            {
                Post lastPost = await _repository.GetLast();
                if (lastPost.Datum > spamTime)
                {
                   return true;
                }
            }
            catch
            {
                return false;
            }

            return false;
        }
    }

    public interface ISpamCheck
    {
        Task<bool> IsSpam(Post message);
    }
}
