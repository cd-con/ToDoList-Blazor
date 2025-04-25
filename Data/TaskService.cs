using Microsoft.EntityFrameworkCore;
using Zavod.Database;

namespace Zavod.Data
{
    /// <summary>
    /// Logic for interaction w/ database.
    /// </summary>
    public class TaskService
    {
        private readonly AppDbContext _context;

        public TaskService(AppDbContext context) => _context = context;

        public async Task<List<TaskModel>> GetTasksAsync() => await _context.Tasks.ToListAsync();

        public async Task AddTaskAsync(TaskModel task)
        {
            _context.Tasks.Add(task);
            await _context.SaveChangesAsync();
        }

        public async Task UpdateTaskAsync(TaskModel task)
        {
            _context.Entry(task).State = EntityState.Modified;
            await _context.SaveChangesAsync();
        }

        public async Task DeleteTaskAsync(int id)
        {
            var task = await _context.Tasks.FindAsync(id);
            if (task != null)
            {
                _context.Tasks.Remove(task);
                await _context.SaveChangesAsync();
            }
        }
    }
}