using System;

namespace TaskManagerApp
{
    // Ensure only one definition of AddTaskCommand
    public class AddTaskCommand : Command
    {
        public override void Execute(TaskManager taskManager)
        {
            try
            {
                Console.Write("Enter Task Title: ");
                string title = Console.ReadLine()?.Trim();
                if (string.IsNullOrEmpty(title))
                {
                    throw new ArgumentException("Title cannot be empty.");
                }

                Console.Write("Enter Due Date (yyyy-mm-dd): ");
                if (!DateTime.TryParse(Console.ReadLine()?.Trim(), out var dueDate))
                {
                    throw new ArgumentException("Invalid date format.");
                }

                Console.Write("Enter Priority (High/Medium/Low): ");
                string priority = Console.ReadLine()?.Trim();
                if (string.IsNullOrEmpty(priority) ||
                    !(priority.Equals("High", StringComparison.OrdinalIgnoreCase) ||
                      priority.Equals("Medium", StringComparison.OrdinalIgnoreCase) ||
                      priority.Equals("Low", StringComparison.OrdinalIgnoreCase)))
                {
                    throw new ArgumentException("Priority must be High, Medium, or Low.");
                }

                taskManager.AddTask(new Task(title, dueDate, priority));
                Console.WriteLine("Task added successfully!");
            }
            catch (Exception ex)
            {
                Console.WriteLine($"Error: {ex.Message}");
            }
        }
    }
}
