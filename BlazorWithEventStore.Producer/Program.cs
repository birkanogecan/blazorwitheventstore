using EventStore.ClientAPI;
using System;
using System.Net;
using System.Text;
using System.Threading.Tasks;

namespace BlazorWithEventStore.Producer
{
    class Program
    {
        
        static void Main(string[] args)
        {
            Console.WriteLine("Produce Some Words!");

            while (1 == 1)
            {
                var text = Console.ReadLine();
                
                var result = ProduceEvent(text);

                Console.WriteLine($"created event - {text} -" + result.Id);
            }
        }

        static Task<WriteResult> ProduceEvent(string data)
        {
            var connection = EventStoreConnection.Create(new IPEndPoint(IPAddress.Loopback, 1113));
            connection.ConnectAsync().Wait();

            var myEvent = new EventData(Guid.NewGuid(), "testEvent", false,
                           Encoding.UTF8.GetBytes(data),
                           Encoding.UTF8.GetBytes("created event data from producer"));
            var result = connection.AppendToStreamAsync("test-stream", ExpectedVersion.Any, myEvent);

            return result;
        }
    }
}
