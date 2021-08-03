using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using GloboTicket.TicketManagement.Application.Contracts.Persistence;
using GloboTicket.TicketManagement.Domain.Entities;
using Microsoft.EntityFrameworkCore;

namespace GloboTicket.TicketManagement.Persistence.Repositories
{
    public class CategoryRepository : BaseRepository<Category>, ICategoryRepository
    {
        public CategoryRepository(GloboTicketDbContext dbContext) : base(dbContext)
        {

        }

        public async Task<List<Category>> GetCategoriesWithEvents(bool includePassedEvents)
        {
            List<Category> allCategories =  await dbContext.Categories.Include(c => c.Events).ToListAsync();

            if (!includePassedEvents)
            {
                allCategories.ForEach(c => c.Events.ToList().RemoveAll(e => e.Date < DateTime.Today));
            }

            return allCategories;
        }
    }
}