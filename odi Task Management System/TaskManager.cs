using System;
using System.Collections.Generic;
using System.Linq;

namespace TaskManagerApp
{
    public class TaskManager
    {
        private readonly List<Task> tasks = new List<Task>();

        public void AddTask(Task task)
        {
            tasks.Add(task);
        }

        public void ViewTasks()
        {
            if (tasks.Count == 0)
            {
                Console.WriteLine("No tasks available.");
                return;
            }

            Console.WriteLine("\nTask List:");
            foreach (var task in tasks)
            {
                Console.WriteLine(task);
            }
        }

        public void SearchTasks(string query)
        {
            if (string.IsNullOrEmpty(query))
            {
                Console.WriteLine("Search query cannot be empty.");
                return;
            }

            var results = tasks
                .Where(t => t.Title.ToLower().Contains(query.ToLower()))
                .ToList();

            if (results.Count == 0)
            {
                Console.WriteLine("No tasks found.");
            }
            else
            {
                Console.WriteLine("\nSearch Results:");
                foreach (var task in results)
                {
                    Console.WriteLine(task);
                }
            }
        }

        public void SortTasksByDueDate()
        {
            tasks.Sort((x, y) => x.DueDate.CompareTo(y.DueDate));
            Console.WriteLine("Tasks sorted by due date.");
        }

        public List<Task> GetTasks() => tasks;
    }
}
