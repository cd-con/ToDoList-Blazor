using System.ComponentModel.DataAnnotations;

namespace Zavod.Data
{
    public enum TaskPriority
    {
        Low,
        Medium,
        High
    }

    public class TaskModel
    {
        public int Id { get; set; }
        public string Title { get; set; }
        public string? Description { get; set; }
        public DateTime CreatedAt { get; set; }
        public DateTime? CompletedAt { get; set; }
        public bool IsActive { get; set; }

        public TaskPriority Priority { get; set; } = TaskPriority.Medium;

        public List<string> Tags { get; set; } = new(); // —охран€ютс€ как JSON строка или в отдельной таблице
    }
}
