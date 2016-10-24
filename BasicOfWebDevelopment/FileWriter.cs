using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Web;

namespace BasicOfWebDevelopment
{
    public class FileWriter
    {
        private static FileWriter instance;
        private static object threadLock = new object();
        private static string path = @"log.txt";
        private FileWriter()
        { }

        public static FileWriter getInstance()
        {
            if (instance == null)
            { 
                instance = new FileWriter();
                if (!File.Exists(path))
                {
                    File.Create(path);
                }
            }
            return instance;
        }

        public bool WriteInformation(string ip, string method, string url)
        {
            lock (threadLock)
            {
                try
                {
                    using (System.IO.StreamWriter file = new System.IO.StreamWriter(path, true))
                    {
                        file.WriteLine("Ip: " + ip);
                        file.WriteLine("Method: " + method);
                        file.WriteLine("Url: " + url);
                        file.WriteLine("");
                    }
                    return true;
                }
                catch(Exception ex)
                {
                    Console.WriteLine(ex.StackTrace);
                    return false;
                }
            }
        }
    }
}