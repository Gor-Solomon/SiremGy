using AutoMapper;
using SiremGy.BLL.Interfaces;
using SiremGy.DAL.Entities;
using SiremGy.DAL.Interfaces;
using System;
using System.Collections.Generic;
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

        protected Exception CreateException(params string[] args)
        {
            var builder = new StringBuilder();
            foreach (var arg in args)
                builder.Append($"{arg}{Environment.NewLine}");

            return new Exception(builder.ToString());
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
