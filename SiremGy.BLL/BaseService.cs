using AutoMapper;
using SiremGy.BLL.Exceptions;
using SiremGy.BLL.Interfaces;
using SiremGy.BLL.Interfaces.Common;
using System;
using System.Text;
using System.Threading.Tasks;


namespace SiremGy.BLL
{
    public abstract class BaseService : IBaseService 
    {

        public BaseService()
        {

        }

        protected string CreateExceptionMessage (params string[] args)
        {
            var builder = new StringBuilder();
            foreach (var arg in args)
                builder.Append($"{arg}{Environment.NewLine}");

            return builder.ToString();
        }
    }
}
