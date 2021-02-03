﻿using System;
using System.Collections.Generic;
using System.Runtime.Serialization; // Needed to make objects serializable (ISerializable)

namespace TaskTracker
{
    public class Employee : ISerializable
    {
        public string Name { get; set; }
        public string Status { get; set; }

        public List<Task> AssignedTasks { get; set; }
        public DateTime Birthday { get; set; }

        public Employee() { } // Parameterless constructor is required for XML serialization

        public Employee(string name, DateTime birthday, List<Task> assignedTasks = null)
        {
            Name = name;
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
            return $"Employee {Name} | CurrentTasks: {AssignedTasks}";
        }
    }
}