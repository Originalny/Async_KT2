using System;
using System.Collections.Generic;
using System.Linq;
using System.ServiceModel;
using System.Text;
using System.Threading.Tasks;
using Async_KT2;

namespace Shared
{
    internal class Program
    {
        static void Main(string[] args)
        {
            Uri baseAdress = new Uri("net.pipe://localhost/messagepipe");

            using (ServiceHost host = new ServiceHost(typeof(MessageService), baseAdress))
            {
                host.AddServiceEndpoint(typeof(IMessageService), new NetNamedPipeBinding(), baseAdress);

                host.Open();

                Console.WriteLine("Receiver is running. Waiting for messages...");
                Console.WriteLine("Press any key to close this app.");

                Console.ReadLine();
                host.Close();
            };
        }
    }
}
