using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ConsoleClient
{

    class TestClient
    {

        const string PATH_TO_API = "http://172.16.193.234:44108/Lab_01/";

        public void sendGet() {
            Console.WriteLine("1. Test Get Query");
            Console.Write("Enter A param: ");
            int FirstNum = Convert.ToInt32(Console.ReadLine());
            Console.Write("Enter B param: ");
            int SecondNum = Convert.ToInt32(Console.ReadLine());

            var request = System.Net.WebRequest.Create(PATH_TO_API + ".lnz?ParmA=" +
                                    Convert.ToInt32(FirstNum) + "&ParmB=" +
                                    Convert.ToInt32(SecondNum));
            request.Method = "GET";
            var response = request.GetResponse();

            using (var stream = new StreamReader(response.GetResponseStream() ?? throw new InvalidOperationException(), Encoding.UTF8))
            {
                Console.WriteLine("Res:");
                Console.WriteLine(stream.ReadToEnd());
                Console.WriteLine();
            }
        }

        public void sendPost()
        {
            Console.WriteLine("2. Test Post Query");
            Console.Write("Enter A param: ");
            int FirstNum = Convert.ToInt32(Console.ReadLine());
            Console.Write("Enter B param: ");
            int SecondNum = Convert.ToInt32(Console.ReadLine());

            var request = System.Net.WebRequest.Create(PATH_TO_API + ".faf?ParmA=" +
                                    Convert.ToInt32(FirstNum) + "&ParmB=" +
                                    Convert.ToInt32(SecondNum));
            request.Method = "POST";
            request.ContentLength = 0;
            var response = request.GetResponse();

            using (var stream = new StreamReader(response.GetResponseStream() ?? throw new InvalidOperationException(), Encoding.UTF8))
            {
                Console.WriteLine("Res:");
                Console.WriteLine(stream.ReadToEnd());
                Console.WriteLine();
            }
        }

        public void sendPut()
        {
            Console.WriteLine("3. Test Put Query");
            Console.Write("Enter A param: ");
            int FirstNum = Convert.ToInt32(Console.ReadLine());
            Console.Write("Enter B param: ");
            int SecondNum = Convert.ToInt32(Console.ReadLine());

            var request = System.Net.WebRequest.Create(PATH_TO_API + ".lnz?ParmA=" +
                                    Convert.ToInt32(FirstNum) + "&ParmB=" +
                                    Convert.ToInt32(SecondNum));
            request.Method = "PUT";
            request.ContentLength = 0;
            var response = request.GetResponse();

            using (var stream = new StreamReader(response.GetResponseStream() ?? throw new InvalidOperationException(), Encoding.UTF8))
            {
                Console.WriteLine("Res:");
                Console.WriteLine(stream.ReadToEnd());
                Console.WriteLine();
            }
        }
    }
}
