using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;

namespace SiremGy.API.Controllers
{
//    [Route("api/[controller]")]
//    [ApiController]
//    public class ValuesController : ControllerBase, IDisposable
//    {
////        private readonly DataContext _dataContext;
//        private readonly CancellationTokenSource _cancelSource;

//        public ValuesController(DataContext dataContext)
//        {
//            //_dataContext = dataContext;
//            _cancelSource = new CancellationTokenSource();
//        }

//        // GET: api/Values
//        [HttpGet]
//        public async Task<IActionResult> GetValues()
//        {
//            var result = await _dataContext.Values.ToListAsync(_cancelSource.Token);
//            return Ok(result);
//        }


//        [HttpGet("{id}")]
//        public async Task<IActionResult> GetValue(int id)
//        {
//            var result = await _dataContext.Values.FirstOrDefaultAsync(x => x.Id == id, _cancelSource.Token);
//            return Ok(result);
//        }

//        // POST: api/Values
//        [HttpPost]
//        public void Post([FromBody] string value)
//        {
//        }

//        // PUT: api/Values/5
//        [HttpPut("{id}")]
//        public void Put(int id, [FromBody] string value)
//        {
//        }

//        // DELETE: api/ApiWithActions/5
//        [HttpDelete("{id}")]
//        public void Delete(int id)
//        {
//        }

//        public void Dispose()
//        {
//            _cancelSource.Dispose();
//        }
//    }
}
