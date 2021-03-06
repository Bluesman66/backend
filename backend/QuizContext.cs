﻿using backend.Models;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace backend
{
    public class QuizContext : DbContext
    {
		public QuizContext(DbContextOptions<QuizContext> options) : base(options) {}

		public DbSet<Question> Qestions { get; set; }

		public DbSet<Quiz> Quiz { get; set; }
	}
}
