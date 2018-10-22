using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.EntityFrameworkCore;

namespace Api.controllers
{
    public class FeedPostDataRepository : IFeedPostDataRepository
    {
        private FeedPostsDbContext _context { get; set; }

        public FeedPostDataRepository(FeedPostsDbContext context)
        {
            _context = context;
        }

        public async Task Add(Post p)
        {
           await _context.AddAsync(p);
           await _context.SaveChangesAsync();
        }

        public async Task<IEnumerable<Post>> GetAll()
        {
            return await _context.Posts.ToListAsync();
        }
    }

    public interface IFeedPostDataRepository
    {
        Task<IEnumerable<Post>> GetAll();

        Task Add(Post p);
    }
}