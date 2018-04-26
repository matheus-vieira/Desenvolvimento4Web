using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using TodoMvc.Data;
using TodoMvc.Models;
using Microsoft.EntityFrameworkCore;

namespace TodoMvc.Services
{
    public class ToDoItemService : ITodoItemService
    {
        private readonly ApplicationDbContext _context;

        public ToDoItemService(ApplicationDbContext context)
        {
            _context = context;
        }

        public async Task<IEnumerable<ToDoItem>> GetIncompleteItemsAsync(ApplicationUser user)
        {
            var items = await _context.Items
                .Where(x =>
                    x.IsDone == false &&
                    x.OwnerId == user.Id)
                .ToArrayAsync();

            return items;
        }

        public async Task<bool> AddItemAsync(NewToDoItem newToDoItem, ApplicationUser user)
        {
            var entity = new ToDoItem
            {
                Id = Guid.NewGuid(),
                OwnerId = user.Id,
                IsDone = false,
                Title = newToDoItem.Title,
                DueAt = newToDoItem.DueAt
            };

            _context.Items.Add(entity);

            var saveResult = await _context.SaveChangesAsync();

            return saveResult == 1;
        }

        public async Task<bool> MarkDoneAsync(Guid id, ApplicationUser user)
        {
            var item = await _context.Items
                .Where(x =>
                    x.Id == id &&
                    x.OwnerId == user.Id)
                .SingleOrDefaultAsync();

            if (item == null)
                return false;

            item.IsDone = true;

            var saveResult = await _context
                .SaveChangesAsync();

            // One entity should
            // have been updated
            return saveResult == 1;
        }
    }
}