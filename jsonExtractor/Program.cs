using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Runtime.Serialization;
using Newtonsoft.Json;
using System.IO;
using System.Net;

namespace jsonExtractor
{
    internal class Entity
    {
        internal string id;
        internal string HashCode;
    }

    class Program
    {
        static void Main(string[] args)
        {
            WebClient client = new WebClient();
            Console.WriteLine("Username/Email: ");
            string userName = Console.ReadLine();
            Console.WriteLine("Password: ");
            string passWord = Console.ReadLine();
            Console.Clear();
            string credentials = Convert.ToBase64String(Encoding.ASCII.GetBytes(userName + ":" + passWord));
            client.Headers[HttpRequestHeader.Authorization] = string.Format("Basic {0}", credentials);
            string json = client.DownloadString("https://trello.com/card/58c822b801f0d689c50c11e9/dolls-room.json");
            Console.WriteLine(json);
            Console.ReadLine();
        }
    }
}
