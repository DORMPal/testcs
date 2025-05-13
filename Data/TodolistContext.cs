using Microsoft.EntityFrameworkCore;
using Todolist.Models;

namespace Todolist.Data
{
    public class TodolistContext : DbContext
    {
        public TodolistContext(DbContextOptions<TodolistContext> options) : base(options)
        {
        }
        
        public DbSet<TodolistModel> TodoLists { get; set; }
    }
}