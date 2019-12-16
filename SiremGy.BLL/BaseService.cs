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

        ~BaseService()
        {
            Dispose(false);
        }

        public ValueTask DisposeAsync()
        {
            return _repository.DisposeAsync();
        }
    }
}
