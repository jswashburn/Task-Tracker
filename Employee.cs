using System;
using System.Collections.Generic;
using System.Runtime.Serialization; // Needed to make objects serializable (ISerializable)

namespace TaskTracker
{
    public class Employee : ISerializable
    {
        private string _name;
        private string _status;
        private List<Task> _assignedTasks;
        private DateTime _birthday;
        public string Name { get => this._name; set => _name = value; }
        public string Status { get => this._status; set => _status = value; }
        public List<Task> AssignedTasks { get => this._assignedTasks; set => _assignedTasks = value; }
        public DateTime Birthday { get => this._birthday; set => _birthday = value; }

        Employee() { } // Parameterless constructor is required for XML serialization

        public Employee(string name, DateTime birthday, List<Task> assignedTasks = null)
        {
            Name = name;
            AssignedTasks = assignedTasks != null ? assignedTasks : new List<Task>();
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
            string task = "There are no assigned tasks";
            if (AssignedTasks.Count == 0)
            {
                return $"Employee: {Name} |  Birthday:  {Birthday} |  CurrentTasks: {task}";
            }
            else
            {
                task = "";
                for(int t = 0; t < AssignedTasks.Count; t++)
                {
                    task += AssignedTasks[t].Name + "; ";
                }
                return $"Employee: {Name} |  Birthday:  {Birthday} |  CurrentTasks: {task}";
            }
        }
    }
}