using System;
using System.Collections.Generic;

namespace TaskManagerApp
{
    class Program
    {
        static void Main(string[] args)
        {
            TaskManager taskManager = new TaskManager();
            string filePath = "tasks.bin";

            // Load tasks from file if available
            try
            {
                var savedTasks = TaskDataHandler.LoadTasks(filePath);
                savedTasks.ForEach(task => taskManager.AddTask(task));
            }
            catch (Exception ex)
            {
                Console.WriteLine($"Error loading tasks: {ex.Message}");
            }

            Console.WriteLine("Task Management System");
            Console.WriteLine("1. Add Task\n2. View Tasks\n3. Search Tasks\n4. Sort Tasks\n5. Save & Exit");

            while (true)
            {
                Console.Write("\nChoose an option: ");
                string choice = Console.ReadLine()?.Trim();

                try
                {
                    switch (choice)
                    {
                        case "1":
                            var addCommand = new AddTaskCommand();
                            addCommand.Execute(taskManager);
                            break;
                        case "2":
                            taskManager.ViewTasks();
                            break;
                        case "3":
                            Console.Write("Enter search term: ");
                            string query = Console.ReadLine();
                            taskManager.SearchTasks(query);
                            break;
                        case "4":
                            taskManager.SortTasksByDueDate();
                            break;
                        case "5":
                            TaskDataHandler.SaveTasks(filePath, taskManager.GetTasks());
                            Console.WriteLine("Tasks saved. Exiting...");
                            return;
                        default:
                            Console.WriteLine("Invalid choice. Please try again.");
                            break;
                    }
                }
                catch (Exception ex)
                {
                    Console.WriteLine($"An error occurred: {ex.Message}");
                }
            }
        }
    }
} 
