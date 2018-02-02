﻿using System;
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

		[HttpPost]
		public void Post([FromBody]Question question)
		{
			this.context.Qestions.Add(question);
			this.context.SaveChanges();
		}
	}
}