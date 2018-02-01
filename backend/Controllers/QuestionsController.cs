using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using backend.Models;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace backend.Controllers
{
    [Produces("application/json")]
    [Route("api/Questions")]
    public class QuestionsController : Controller
    {
		[HttpGet]
		public IEnumerable<Question> Get()
		{
			return new Question[] {
				new Question() { Text = "hello"},
				new Question() { Text = "hi"}
			};
		}

		[HttpPost]
		public void Post([FromBody]Question question)
		{

		}
	}
}