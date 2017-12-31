﻿using EducationBlog.Dtos;
using EducationBlog.Service;
using System.Threading.Tasks;
using System.Web.Http;

namespace EducationBlog.Controllers
{
    //  [Authorize]
    [RoutePrefix("api/Blog")]
    public class BlogController: ApiController
    {
        private IBlogService _blogService = null;

        public BlogController()
        {
            _blogService = new BlogService();
        }
        [Route("Add")]
        public async Task<IHttpActionResult> Add(BlogAddDto model)
        {
            bool result = await _blogService.Add(model);

            if (!result)
                return BadRequest();

            return Ok();
        }
    }
}