using Microsoft.AspNetCore.Mvc;
using People.Api.Controllers;
using People.Business.Interfaces;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace People.Api.V1.Controllers
{
    [ApiVersion("1.0", Deprecated = true)]
    [Route("api/v{version:apiVersion}/test")]
    public class TestController : MainController
    {
        public TestController(INotifier notifier) : base(notifier)
        {
        }

        [HttpGet]
        public string Valor()
        {
            return "I'm the Api V1";
        }
    }
}
