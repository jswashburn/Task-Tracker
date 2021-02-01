using System;
using System.Collections.Generic;
using System.Xml.Serialization;
using System.IO;
using static TaskTracker.Menu;

namespace TaskTracker
{
    class Program
    {
        static List<Task> Tasks { get; set; } = new List<Task>();
        static List<Worker> Workers { get; set; } = new List<Worker>();
        static XmlSerializer serializer = new XmlSerializer(typeof(List<Task>));

        static void Main(string[] args)
        {
            LoadTasks();
            ShowMainMenu();
        }

        static void SaveTasks(List<Task> tasks)
        {
            // Serialize Tasks to file stream
            using Stream stream = File.Open("./tasks.xml", FileMode.OpenOrCreate, FileAccess.Write, FileShare.None);
            serializer.Serialize(stream, tasks);
        }

        static void LoadTasks()
        {
            // Open file stream and deserialize to Tasks
            using Stream stream = File.OpenRead("./tasks.xml");
            Tasks = (List<Task>)serializer.Deserialize(stream);
        }
    }
}
