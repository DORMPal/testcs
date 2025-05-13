using System;
using System.Collections.Generic;
using System.Linq;
using Todolist.Dto;
using Todolist.Models;

namespace Todolist.Repositories
{
    public class MockRepository : IRepository
    {
        private readonly List<TodolistModel> _data;

        public MockRepository()
        {
            // 👇 mock ข้อมูลที่ใช้โชว์
            _data = new List<TodolistModel>
            {
                new TodolistModel
                {
                    Id = Guid.NewGuid(),
                    Title = "Mock Task 1",
                    Description = "This is a mocked task",
                    CreatedAt = DateTime.Now,
                    UpdatedAt = null
                },
                new TodolistModel
                {
                    Id = Guid.NewGuid(),
                    Title = "Mock Task 2",
                    Description = "Another mocked task",
                    CreatedAt = DateTime.Now,
                    UpdatedAt = null
                }
            };
        }

        public List<TodolistModel> GetAll() => _data;

        public TodolistModel GetById(Guid id) => _data.FirstOrDefault(x => x.Id == id);

        public Error Create(TodolistModel data)
        {
            data.Id = Guid.NewGuid();
            data.CreatedAt = DateTime.Now;
            _data.Add(data);
            return null;
        }

        public Error Update(TodolistModel data)
        {
            var existing = _data.FirstOrDefault(x => x.Id == data.Id);
            if (existing == null) return new Error { Message = "Not found" };
            existing.Title = data.Title;
            existing.Description = data.Description;
            existing.UpdatedAt = DateTime.Now;
            return null;
        }

        public Error Delete(Guid id)
        {
            var toDelete = _data.FirstOrDefault(x => x.Id == id);
            if (toDelete == null) return new Error { Message = "Not found" };
            _data.Remove(toDelete);
            return null;
        }
    }
}
