using Biletall;
using Grpc.Core;
using System.Threading.Tasks;

namespace Server.Services
{
    public class DemoService : BiletallGrpc.BiletallGrpcBase
    {
        public override Task<GetGunesinNeredenVuracagiResponse> GetGunesinNeredenVuracagi
            (GetGunesinNeredenVuracagiRequest request,
            ServerCallContext context)
        {
            //TODO : gerçek algoritma yapılmalı.

            return Task.FromResult(new GetGunesinNeredenVuracagiResponse()
            {
                Sonuc = "Sağ"
            });
        }
    }
}
