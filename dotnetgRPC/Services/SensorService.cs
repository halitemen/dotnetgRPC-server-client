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
        public override Task<SensorDataReply> Sensor(SensorDataRequest request, ServerCallContext context)
        {
            Console.WriteLine($"Sensor Mac: { request.Mac}");

            return Task.FromResult(new SensorDataReply
            {
                RawData = "02010408FFA55A000500000E4C5F"
            });
        }
    }
}
