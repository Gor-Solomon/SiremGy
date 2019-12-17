using AutoMapper;
using SiremGy.BLL.Exceptions;
using SiremGy.BLL.Interfaces;
using SiremGy.BLL.Interfaces.Common;
using System;
using System.Text;
using System.Threading.Tasks;


namespace SiremGy.BLL
{
    public abstract class BaseService<TRepository> : IBaseService where TRepository : IDisposable, IAsyncDisposable
    {
        protected readonly IMapper _mapper;
        protected readonly TRepository _repository;
        private bool _disposed = false;

        public BaseService(TRepository repository, IMapper mapper)
        {
            _repository = repository;
            this._mapper = mapper;
        }

        protected string createExceptionMessage (params string[] args)
        {
            var builder = new StringBuilder();
            foreach (var arg in args)
                builder.Append($"{arg}{Environment.NewLine}");

            return builder.ToString();
        }

        public void Dispose()
        {
            Dispose(true);
            GC.SuppressFinalize(this);
        }

        protected virtual void Dispose(bool disposing)
        {
            if (!_disposed)
            {
                _repository.Dispose();
                _disposed = true;
            }
        }
     
        public ValueTask DisposeAsync()
        {
            return _repository.DisposeAsync();
        }

        ~BaseService()
        {
            Dispose(false);
        }
    }
}
