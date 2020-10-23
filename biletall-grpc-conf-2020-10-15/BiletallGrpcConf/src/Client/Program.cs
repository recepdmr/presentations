using System;
using System.ComponentModel;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Hosting;
using static Biletall.BiletallGrpc;

namespace Client
{
    public static class Program
    {
        public static void Main(string[] args)
        {
            CreateHostBuilder(args).Build().Run();
        }

        public static IHostBuilder CreateHostBuilder(string[] args) =>
            Host.CreateDefaultBuilder(args)
                .ConfigureServices((hostContext, services) =>
                {
                    services.AddHostedService<Worker>();

                    // This switch must be set before creating the GrpcChannel/HttpClient.
                    AppContext.SetSwitch(
                        "System.Net.Http.SocketsHttpHandler.Http2UnencryptedSupport", true);


                    services.AddGrpcClient<BiletallGrpcClient>(opt =>
                    {
                        opt.Address = new Uri("http://localhost:5000/");
                    });
                });
    }
}
