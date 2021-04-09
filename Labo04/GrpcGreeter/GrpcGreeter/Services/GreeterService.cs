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
                Message = "Za gorami, za lasami mieszkala sobie Daria Hornik, a obok Kamil Graczyk. Oboje postanowili pojsc " +
                "na Informatyke i dostali kolejno numery albumu 246700 i 246994. Pewnego dnia, byl to 29.03.2021r., wlaczyli " +
                "sobie gRPC na komputerze: " + request.Name + " i poszli na Rozproszone Systemy Informatyczne."
            });
        }

        public override Task<CheckPointsReply> CheckPoints(CheckPointsRequest request, ServerCallContext context)
        {
            double a = request.A;
            double b = request.B;
            double c = request.C;
            double x = request.X;
            double y = request.Y;

            Console.WriteLine($"New request: line(a: {a}, b: {b}, c: {c}) point(x: {x}, y: {y})");

            bool belongsTo;
            double d = Math.Abs(a * x + b * y + c) / Math.Sqrt(Math.Pow(a, 2) + Math.Pow(b, 2));
            belongsTo = d == 0;

            return Task.FromResult(new CheckPointsReply
            {
                A = a,
                B = b,
                C = c,
                X = x,
                Y = y,
                BelongsTo = belongsTo
            });
        }
    }
}
