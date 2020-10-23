using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading;
using System.Threading.Tasks;
using Biletall;
using Microsoft.Extensions.Hosting;
using Microsoft.Extensions.Logging;

namespace Client
{
    public class Worker : BackgroundService
    {
        private readonly ILogger<Worker> _logger;
        private readonly BiletallGrpc.BiletallGrpcClient _biletallGrpcClient;

        public Worker(ILogger<Worker> logger, Biletall.BiletallGrpc.BiletallGrpcClient biletallGrpcClient)
        {
            _logger = logger;
            _biletallGrpcClient = biletallGrpcClient;
        }

        protected override async Task ExecuteAsync(CancellationToken stoppingToken)
        {
            while (!stoppingToken.IsCancellationRequested)
            {

                var response = await _biletallGrpcClient.GetGunesinNeredenVuracagiAsync(new GetGunesinNeredenVuracagiRequest()
                {
                    KalkisNoktaId = 1,
                    VarisNoktaId = 2
                }, cancellationToken: stoppingToken);

                await Console.Out.WriteLineAsync(response.Sonuc);

                _logger.LogInformation("Worker running at: {time}", DateTimeOffset.Now);
                await Task.Delay(1000, stoppingToken);
            }
        }
    }
}
