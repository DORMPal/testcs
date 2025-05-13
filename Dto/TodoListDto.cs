using System;
using System.Collections.Generic;
using System.Security.Authentication;

namespace Todolist.Dto
{
    public class TodoListDto
    {
        public TodoListDto(Guid id, string title, string description, DateTime? createdAt, DateTime? updatedAt)
        {
            Id = id;
            Title = title;
            Description = description;
            CreatedAt = createdAt;
            UpdatedAt = updatedAt;
        }
        
        public Guid Id { get; set; }
        public string Title { get; set; }
        public string Description { get; set; }
        public DateTime? CreatedAt { get; set; }
        public DateTime? UpdatedAt { get; set; }
    }

    public class CreateOrUpdateTodoListDto
    {
        public string Title { get; set; }
        public string Description { get; set; }
    }
}