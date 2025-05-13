using System;
using System.Collections.Generic;
using System.Linq;
using Microsoft.EntityFrameworkCore;
using Todolist.Dto;
using Todolist.Models;
using Todolist.Data;

namespace Todolist.Repositories
{
    public class TodoListRepository : IRepository
    {
        private readonly TodolistContext _todolistContext;

        public TodoListRepository(TodolistContext todolistContext)
        {
            _todolistContext = todolistContext;
        }

        public List<TodolistModel> GetAll()
        {
            return _todolistContext.TodoLists.ToList();
        }

        public TodolistModel GetById(Guid id)
        {
            return _todolistContext.TodoLists.Find(id);
        }

        public Error Create(TodolistModel data)
        {
            try
            {
                _todolistContext.TodoLists.Add(data);
                _todolistContext.SaveChanges();
                return null;
            }
            catch (Exception e)
            {
                return new Error {Message = e.InnerException.Message};
            }
        }
        
        public Error Update(TodolistModel data)
        {
            try
            {
                _todolistContext.TodoLists.Attach(data);
                _todolistContext.Entry(data).Property(d => d.Title).IsModified = true;
                _todolistContext.Entry(data).Property(d => d.Description).IsModified = true;
                _todolistContext.Entry(data).Property(d => d.UpdatedAt).IsModified = true;
                _todolistContext.SaveChanges();
                return null;
            }
            catch (Exception e)
            {
                return new Error {Message = e.Message};
            }
        }
        
        public Error Delete(Guid id)
        {
            try
            {
                _todolistContext.TodoLists.Remove(new TodolistModel {Id = id});
                _todolistContext.SaveChanges();
                return null;
            }
            catch (Exception e)
            {
                return new Error {Message = e.InnerException.Message};
            }
        }
    }
}