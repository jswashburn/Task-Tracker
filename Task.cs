using System;
using System.Collections.Generic;
using System.Runtime.Serialization; // Needed to make objects serializable (ISerializable)

namespace TaskTracker
{
    public class Task : ISerializable
    {
        private string _name;
        private List<Employee> _workersAssigned;
        private DateTime _dateCreated;
        private DateTime? _dateCompleted;
        private bool _complete;
        public string Name { get => this._name; set => _name = value; }
        public List<Employee> WorkersAssigned { get => this._workersAssigned; set => _workersAssigned = value; }
        public DateTime DateCreated { get => this._dateCreated; set => _dateCreated = value; }
        public DateTime? DateCompleted { get => this._dateCompleted; set => _dateCompleted = value; }
        public bool Complete { get => this._complete; set => _complete = value; }

        Task() { } // Parameterless constructor is required for XML serialization

        public Task(string name, List<Employee> workersAssigned = null)
        {
            Name = name.ToLower().Trim();
            WorkersAssigned = workersAssigned;
            DateCreated = DateTime.Now;
            DateCompleted = null;
            Complete = false;
        }

        // Part of the ISerializable interface needed to serialize (save) classes
        public void GetObjectData(SerializationInfo info, StreamingContext context)
        {
            info.AddValue("Name", Name);
            info.AddValue("WorkersAssigned", WorkersAssigned);
            info.AddValue("DateCreated", DateCreated);
            info.AddValue("DateCompleted", DateCompleted);
            info.AddValue("Complete", Complete);
        }

        // Overrides the default ToString behavior, provides string representation of Task
        public override string ToString()
        {
            return $"Task: {Name} | Created {DateCreated} | {(Complete ? "Complete" : "Incomplete")}";
        }
    }
}