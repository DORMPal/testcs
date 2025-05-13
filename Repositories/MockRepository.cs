using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text.Json;
using Todolist.Dto;
using Todolist.Models;

namespace Todolist.Repositories
{
    public class MockRepository : IRepository
    {
        private string _filePath = "data.json";
        private List<TodolistModel> _data;

        public MockRepository()
        {
            LoadData();
        }

        private void LoadData()
        {
            if (File.Exists(_filePath))
            {
                var json = File.ReadAllText(_filePath);
                Console.WriteLine(json);
                _data = JsonSerializer.Deserialize<List<TodolistModel>>(json) ?? new List<TodolistModel>();
            }
            else
            {
                Console.WriteLine("file doesn't exist");
                _data = new List<TodolistModel>();
                SaveData(); // Create empty file
            }
        }

        private void SaveData()
        {
            var json = JsonSerializer.Serialize(_data, new JsonSerializerOptions { WriteIndented = true });
            File.WriteAllText(_filePath, json);
        }

        public List<TodolistModel> GetAll()
        {
            //LoadData();
            return _data;
        }

        public TodolistModel GetById(Guid id) => _data.FirstOrDefault(x => x.Id == id);

        public Error Create(TodolistModel data)
        {
            data.Id = Guid.NewGuid();
            data.CreatedAt = DateTime.Now;
            _data.Add(data);
            SaveData();
            return null;
        }

        public Error Update(TodolistModel data)
        {
            var existing = _data.FirstOrDefault(x => x.Id == data.Id);
            if (existing == null) return new Error { Message = "Not found" };
            existing.Title = data.Title;
            existing.Description = data.Description;
            existing.UpdatedAt = DateTime.Now;
            SaveData();
            return null;
        }

        public Error Delete(Guid id)
        {
            var toDelete = _data.FirstOrDefault(x => x.Id == id);
            if (toDelete == null) return new Error { Message = "Not found" };
            _data.Remove(toDelete);
            SaveData();
            return null;
        }
    }
}
