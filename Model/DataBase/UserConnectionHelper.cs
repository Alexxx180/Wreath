using System;
using System.Collections.Generic;
using System.IO;
using Serilog;

namespace Wreath.Model.DataBase
{
    internal static class UserConnectionHelper
    {
        private static string _appDirectory => Directory.GetParent(Environment.CurrentDirectory).Parent.Parent.FullName;

        internal static bool FileConnection()
        {
            bool connectionSuccessful = false;
            string name = _appDirectory + "/Resources/Login.txt";
            if (File.Exists(name))
            {
                Pair<string, string> initials = ReadFromTextFile(name);
                connectionSuccessful = MySQL.TestConnection(initials.Name, initials.Value);
            }
            return connectionSuccessful;
        }

        internal static bool Connect()
        {
            bool connectionSuccessful = false;
            EntryWindow entry = new EntryWindow();
            while (!connectionSuccessful && entry.ShowDialog().Value)
            {
                connectionSuccessful = MySQL.TestConnection(entry.Login, entry.Pass);
                if (!connectionSuccessful)
                    entry = new EntryWindow();
            }
            if (entry.MemberMe)
                WriteToTextFile(entry.Login, entry.Pass);
            return connectionSuccessful;
        }

        internal static void SetConfiguration()
        {
            Pair<string, string> config = ReadFromTextFile(_appDirectory + "/Config.txt");
            MySQL.SetConfig(config.Name, config.Value);
        }

        private static Pair<string, string> ReadFromTextFile(string name)
        {
            Pair<string, string> initials = new Pair<string, string>();
            List<string> lines = new List<string>();
            try
            {
                using (StreamReader reader = new StreamReader(name))
                {
                    string line;
                    while ((line = reader.ReadLine()) != null)
                        lines.Add(line);
                }
                if (lines.Count >= 2)
                {
                    initials.Name = lines[0];
                    initials.Value = lines[1];
                }
            }
            catch (IOException exception)
            {
                Log.Error("Unable to read user data from file: " + exception.Message);
            }
            return initials;
        }

        private static void WriteToTextFile(string name, string pass)
        {
            try
            {
                File.WriteAllLines(_appDirectory + "/Resources/Login.txt",
                    new List<string> { name, pass });
            }
            catch (IOException exception)
            {
                Log.Error("Unable to write user data in file: " + exception.Message);
            }
        }
    }
}