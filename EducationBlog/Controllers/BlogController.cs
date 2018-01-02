using EducationBlog.Dtos;
using EducationBlog.Service;
using System;
using System.Collections.Generic;
using System.Threading.Tasks;
using System.Web.Http;
using System.Web.Http.Description;

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
        [Route("Get"), ResponseType(typeof(IEnumerable<BlogGetDto>))]
        public async Task<IHttpActionResult> Get(string body = null, string header = null)
        {
            var result = await _blogService.Get(body,header);

            return Ok(result);
        }
        [Route("Update"),HttpPut]
        public async Task<IHttpActionResult> Update(Guid id,BlogUpdateDto model)
        {
            bool result = await _blogService.Update(id, model);

            if (!result)
                return BadRequest();

            return Ok();
        }
        [Route("Delete")]
        public async Task<IHttpActionResult> Delete(Guid id)
        {
            bool result = await _blogService.Delete(id);

            if (!result)
                return BadRequest();

            return Ok();
        }
    }
}
