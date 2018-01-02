using EducationBlog.Dtos;
using EducationBlog.Models;
using EducationBlog.Models.Domain;
using Microsoft.Ajax.Utilities;
using System;
using System.Collections;
using System.Collections.Generic;
using System.Data.Entity;
using System.Linq;
using System.Threading.Tasks;

namespace EducationBlog.Service
{
    public interface IBlogService
    {
        Task<bool> Add(BlogAddDto model);
        Task<IList<BlogGetDto>> Get(string body = null, string header = null);
        Task<bool> Update(Guid id,BlogUpdateDto model);
        Task<bool> Delete(Guid id);
    }
    public class BlogService:IBlogService
    {
        private EducationBlogDBContext _context = null;

        public BlogService()
        {
            _context = new EducationBlogDBContext();
        }

        public async Task<bool> Add(BlogAddDto model)
        {
            try
            {
                Blog entity = new Blog
                {
                    Body = model.Body,
                    Header = model.Header,
                    Id = Guid.NewGuid()
                };

                _context.Blog.Add(entity);
                await _context.SaveChangesAsync();
                
                return true;
            }
            catch (Exception)
            {
                return false;
            }
        }

        public async Task<IList<BlogGetDto>> Get(string body = null, string header = null)
        {
            var query = _context.Blog.AsQueryable();

            if (!String.IsNullOrWhiteSpace(body))
                query = query.Where(x => x.Body.Contains(body));
            if (!String.IsNullOrWhiteSpace(header))
                query = query.Where(x => x.Header.Contains(header));

            var result = await query
                .Select(s => new BlogGetDto
                {
                    Id = s.Id,
                    Header = s.Header,
                    Body = s.Body
                })
                .ToListAsync();

            return result;
        }

        public async Task<bool> Update(Guid id, BlogUpdateDto model)
        {
            try
            {
                var query = _context.Blog.FirstOrDefault(x => x.Id == id);

                query.Body = model.Body;
                query.Header = model.Header;

                await _context.SaveChangesAsync();

                return true;
            }
            catch (Exception)
            {
                return false;
            }
        }

        public async Task<bool> Delete(Guid id)
        {
            try
            {
                var query = _context.Blog.FirstOrDefault(x => x.Id == id);
                _context.Blog.Remove(query);

                await _context.SaveChangesAsync();

                return true;
            }
            catch (Exception)
            {
                return false;
            } 
        }
    }
}