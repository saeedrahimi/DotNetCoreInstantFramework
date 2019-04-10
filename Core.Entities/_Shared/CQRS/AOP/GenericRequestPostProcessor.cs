﻿using System.IO;
using System.Threading.Tasks;
using MediatR.Pipeline;

namespace Core.Domain._Shared.CQRS.AOP
{
    public class GenericRequestPostProcessor<TRequest, TResponse> : IRequestPostProcessor<TRequest, TResponse>
    {
        private readonly TextWriter _writer;

        public GenericRequestPostProcessor(TextWriter writer)

        {
            _writer = writer;
        }

        public Task Process(TRequest request, TResponse response)
        {
            return _writer.WriteLineAsync("- All Done");
        }
    }
}
