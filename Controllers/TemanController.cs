using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using WEBAPICoba4.Models;

namespace WEBAPICoba4.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class TemanController : ControllerBase
    {
        private TemanContext _context;

        public TemanController(TemanContext context)
        {
            this._context = context;
        }

        // GET: api/User
        [HttpGet]
        public ActionResult<IEnumerable<TemanItem>> GetTemanItems()
        {
            _context = HttpContext.RequestServices.GetService(typeof(TemanContext)) as TemanContext;
            //return new string[] { "value1", "value2" };
            return _context.GetAllTeman();
        }

        //Get : api/user/{id}
        [HttpGet("{id}", Name = "Get")]
        public ActionResult<IEnumerable<TemanItem>> GetTemanItem(String id)
        {
            _context = HttpContext.RequestServices.GetService(typeof(TemanContext)) as TemanContext;
            return _context.GetTeman(id);
        }


        //[HttpPost]
        //public IHttpAcceptedResult Teman;
    }
}