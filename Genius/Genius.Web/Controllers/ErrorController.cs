namespace Genius.Web.Controllers
{
    using System;
    using System.Collections.Generic;
    using System.Linq;
    using System.Threading.Tasks;
    using Microsoft.AspNetCore.Mvc;

    [Route("Error")]
    public class ErrorController : Controller
    {
        [HttpGet]
        [Route("NotFound")]
        public IActionResult ResourceNotFound()
        {
            return View();
        }
    }
}