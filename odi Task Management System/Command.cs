using System;

namespace TaskManagerApp
{
    // Abstract Command class to be inherited by specific commands like AddTaskCommand
    public abstract class Command
    {
        public abstract void Execute(TaskManager taskManager);
    }
}
