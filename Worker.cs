using System;
using System.Collections.Generic;
using System.Runtime.Serialization; // Needed to make objects serializable (ISerializable)

namespace TaskTrackerConsoleApp
{
    public class Worker : ISerializable
    {
        public string Name { get; set; }
        public string Status { get; set; }
        public List<Task> AssignedTasks { get; set; }
        public DateTime Birthday { get; set; }

        Worker() { } // Parameterless constructor is required for XML serialization

        public Worker(string name, List<Task> assignedTasks, DateTime birthday)
        {
            Name = name.ToLower().Trim();
            AssignedTasks = assignedTasks;
            Birthday = birthday;
        }

        // Part of the ISerializable interface needed to serialize (save) classes
        public void GetObjectData(SerializationInfo info, StreamingContext context)
        {
            info.AddValue("Name", Name);
            info.AddValue("Status", Status);
            info.AddValue("AssignedTasks", AssignedTasks);
        }

        // Overrides the default ToString behavior, provides string representation of Worker
        public override string ToString()
        {
            return $"Worker {Name} | CurrentTasks: {AssignedTasks}";
        }
    }
}