﻿using System.ComponentModel.DataAnnotations;

namespace EducationBlog.Dtos
{
    public class BlogAddDto
    {
        [Required,MaxLength(100)]
        public string Header { get; set; }
        [Required]
        public string Body { get; set; }
    }
}