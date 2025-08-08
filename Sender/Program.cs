using System;
using System.Collections.Generic;
using System.Linq;
using System.ServiceModel;
using System.Text;
using System.Threading.Tasks;
using Async_KT2;

namespace Sender_net
{
    internal class Program
    {
        static void Main(string[] args)
        {
            const string BASE_ADRESS = "net.pipe://localhost/messagepipe";

            var binding = new NetNamedPipeBinding();
            var endPoint = new EndpointAddress(BASE_ADRESS);
            var factory = new ChannelFactory<IMessageService>(binding, endPoint);

            IMessageService service = factory.CreateChannel();

            Console.WriteLine("Type any message...");
            Console.WriteLine("Empty string will close this app.");

            while (true)
            {
                string text = Console.ReadLine();

                if (string.IsNullOrWhiteSpace(text)) break;

                try
                {
                    service.SendMessage(text);
                }
                catch (Exception ex)
                {
                    Console.WriteLine("Sending error!\n" + ex.Message);
                    break;
                }
            }

            ((IClientChannel)service).Close();
            factory.Close();
        }
    }
}
