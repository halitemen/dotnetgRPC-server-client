using dotnetgRPC.Protos;
using Grpc.Core;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace dotnetgRPC.Services
{
    public class SensorService : Protos.SensorService.SensorServiceBase
    {
        //unary rpc
        public override Task<SensorDataReply> Sensor(SensorDataRequest request, ServerCallContext context)
        {
            Console.WriteLine($"Sensor Mac: { request.Mac}");

            return Task.FromResult(new SensorDataReply
            {
                RawData = "02010408FFA55A000500000E4C5F"
            });
        }

        //Server Streaming RPC
        public override async Task SendInformation(SendInformationRequest request, IServerStreamWriter<SendInformationReply> responseStream, ServerCallContext context)
        {
            while (!context.CancellationToken.IsCancellationRequested)
            {
                var list = Initialize.GetInfo();
                foreach (var item in list)
                {
                    var response = new SendInformationReply
                    {
                        Mac = item.Key,
                        Batterylevel = item.Value
                    };
                    await responseStream.WriteAsync(response);
                }
            }
        }
    }
}
