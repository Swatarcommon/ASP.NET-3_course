using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ConsoleClient
{
    class Program
    {
        static void Main(string[] args)
        {
            TestClient client = new TestClient();
            client.sendGet();
            client.sendPost();
            client.sendPut();
            Console.ReadLine();
        }
    }
}
