using System.IO;
using System.Net.NetworkInformation;
using System.Threading.Tasks;
using MediatR.Pipeline;

namespace Core.Domain._Shared.CQRS.AOP
{
    public class ConstrainedRequestPostProcessor<TRequest, TResponse>
        : IRequestPostProcessor<TRequest, TResponse>
        where TRequest : Ping
    {
        private readonly TextWriter _writer;

        public ConstrainedRequestPostProcessor(TextWriter writer)
        {
            _writer = writer;
        }

        public Task Process(TRequest request, TResponse response)
        {
            return _writer.WriteLineAsync("- All Done with Ping");
        }
    }
}
