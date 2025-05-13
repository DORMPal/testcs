using System;
using System.Collections.Generic;
using Todolist.Dto;
using Todolist.Models;

namespace Todolist.Repositories
{
    public interface IRepository
    {
        List<TodolistModel> GetAll();
        TodolistModel GetById(Guid id);

        Error Create(TodolistModel data);
        
        Error Update(TodolistModel data);
        
        Error Delete(Guid id);
    }
}

