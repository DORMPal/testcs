using System;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace Todolist.Models
{
    [Table("todolists")]
    public class TodolistModel
    {
        public  Guid Id { get; set; }
        
        [Column(name: "title", TypeName = "varchar(100)")]
        [Required]
        public string Title { get; set; }
        
        [Column(name: "description", TypeName = "varchar(200)")]
        [Required]
        public string Description { get; set; }
        
        [Column(name: "created_at")]
        [Required]
        public DateTime CreatedAt { get; set; }
        
        [Column(name: "updated_at")]
        public DateTime? UpdatedAt { get; set; }
    }
}