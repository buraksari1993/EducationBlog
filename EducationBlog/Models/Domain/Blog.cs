using System;
using System.ComponentModel.DataAnnotations;

namespace EducationBlog.Models.Domain
{
    public class Blog
    {
        public Guid Id { get; set; }
        [Required, MaxLength(100)]
        public string Header { get; set; }
        [Required]
        public string Body { get; set; }
    }
}