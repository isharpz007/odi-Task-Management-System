using System;

namespace TaskManagerApp
{
    [Serializable]
    public class Task
    {
        public string Title { get; private set; }
        public DateTime DueDate { get; private set; }
        public string Priority { get; private set; }

        public Task(string title, DateTime dueDate, string priority)
        {
            Title = title;
            DueDate = dueDate;
            Priority = priority;
        }

        public override string ToString()
        {
            return $"{Title} (Due: {DueDate.ToShortDateString()}, Priority: {Priority})";
        }
    }
}
