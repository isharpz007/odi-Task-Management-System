using System;
using System.Collections.Generic;
using System.IO;
using System.Runtime.Serialization.Formatters.Binary;

namespace TaskManagerApp
{
    public class TaskDataHandler
    {
        public static void SaveTasks(string filePath, List<Task> tasks)
        {
            try
            {
                using (var stream = new FileStream(filePath, FileMode.Create))
                {
                    var formatter = new BinaryFormatter();
                    formatter.Serialize(stream, tasks);
                }
            }
            catch (Exception ex)
            {
                Console.WriteLine($"Error saving tasks: {ex.Message}");
            }
        }

        public static List<Task> LoadTasks(string filePath)
        {
            if (!File.Exists(filePath)) return new List<Task>();

            try
            {
                using (var stream = new FileStream(filePath, FileMode.Open))
                {
                    var formatter = new BinaryFormatter();
                    return (List<Task>)formatter.Deserialize(stream);
                }
            }
            catch (Exception ex)
            {
                Console.WriteLine($"Error loading tasks: {ex.Message}");
                return new List<Task>();
            }
        }
    }
}
