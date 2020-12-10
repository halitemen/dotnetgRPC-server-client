using dotnetgRPC.Protos;
using Grpc.Net.Client;
using System;
using System.Threading;
using System.Threading.Tasks;

namespace dotnetgRPC.Client
{
    class Program
    {
        static void Main(string[] args)
        {
            Thread.Sleep(TimeSpan.FromSeconds(5));
            var channel = GrpcChannel.ForAddress("https://localhost:5001");
            var sensorClient = new SensorService.SensorServiceClient(channel);

            var response = sensorClient.Sensor(new SensorDataRequest
            {
                Mac = "ED67385ADF54"
            });

            Console.WriteLine(response.RawData);
            Console.ReadKey();
        }
    }
}
