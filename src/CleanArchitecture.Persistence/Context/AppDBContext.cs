using System;
using CleanArchitecture.Domain.Entities;
using Microsoft.EntityFrameworkCore;

namespace CleanArchitecture.Persistence.Context
{
	public class AppDBContext: DbContext
	{
		public AppDBContext(DbContextOptions<AppDBContext> options): base(options)
		{

		}
		public DbSet <User> Users { get; set; }
	}
}

