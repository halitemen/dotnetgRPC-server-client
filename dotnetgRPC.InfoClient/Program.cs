using dotnetgRPC.Protos;
using Grpc.Core;
using Grpc.Net.Client;
using System;
using System.Threading;
using System.Threading.Tasks;

namespace dotnetgRPC.InfoClient
{
    class Program
    {
        static async Task Main(string[] args)
        {

            Thread.Sleep(TimeSpan.FromSeconds(5));
            var channel = GrpcChannel.ForAddress("https://localhost:5001");
            var client = new SensorService.SensorServiceClient(channel);

            using (var serverStreamingCall = client.SendInformation(new SendInformationRequest()))
            {
                while (await serverStreamingCall.ResponseStream.MoveNext())
                {
                    var serverResponse = serverStreamingCall.ResponseStream.Current;
                    if (serverResponse != null)
                    {
                        Console.WriteLine($"MAC: {serverResponse.Mac} Battery Level: {serverResponse.Batterylevel}");
                    }
                }
            }
        }
    }
}
