using Grpc.Core;
using Microsoft.Extensions.Logging;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace GrpcGreeter
{
    public class GreeterService : Greeter.GreeterBase
    {
        private readonly ILogger<GreeterService> _logger;
        public GreeterService(ILogger<GreeterService> logger)
        {
            _logger = logger;
        }

        public override Task<HelloReply> SayHello(HelloRequest request, ServerCallContext context)
        {

            return Task.FromResult(new HelloReply
            {
                Message = "Za gorami, za lasami mieszkala sobie Daria Hornik, a obok Kamil Graczyk. Obaj postanowili pojsc na Informatyke " +
                "i dostali kolejno numery albumu 246700 i 246994. " +
                  "Pewnego dnia, byl to 29.03.2021r., wlaczyli sobie gRPC na komputerze: " + request.Name + " i poszli na Rozproszone " +
                  "Systemy Informatyczne."
            });
        }
    }
}
