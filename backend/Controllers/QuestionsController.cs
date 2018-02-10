using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using backend.Models;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;

namespace backend.Controllers
{
    [Produces("application/json")]
    [Route("api/Questions")]
    public class QuestionsController : Controller
    {
		readonly QuizContext context;

		public QuestionsController(QuizContext context)
		{
			this.context = context;
		}

		[HttpGet]
		public IEnumerable<Question> Get()
		{
			return this.context.Qestions;			
		}

		[HttpGet("{quizId}")]
		public IEnumerable<Question> Get([FromRoute] int quizId)
		{
			return this.context.Qestions.Where(q => q.QuizId == quizId);
		}

		[HttpPost]
		public async Task<IActionResult> Post([FromBody]Question question)
		{
			var quiz = context.Quiz.SingleOrDefault<Quiz>(q => q.ID == question.QuizId);

			if (quiz == null)
				return NotFound();

			this.context.Qestions.Add(question);
			await this.context.SaveChangesAsync();
			return Ok(question);
		}

		[HttpPut("{id}")]
		public async Task<IActionResult> Put(int id, [FromBody]Question question)
		{
			if (id != question.ID)
				return BadRequest();
			this.context.Entry(question).State = EntityState.Modified;
			await this.context.SaveChangesAsync();
			return Ok(question);
		}		
	}
}