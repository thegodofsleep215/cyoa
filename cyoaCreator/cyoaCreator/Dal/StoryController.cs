using Newtonsoft.Json;
using System.Collections.Generic;
using System.Text;
using System.Web.Http;
using System.Web.Http.Results;

namespace cyoaCreator
{
    [RoutePrefix("Story")]
    public class StoryController : ApiController
    {
        [HttpGet]
        public IHttpActionResult Get()
        {
            var dal = StoryFactory.CreateStoryDal();
            return new JsonResult<List<Story>>(dal.GetAll(), new JsonSerializerSettings(), Encoding.UTF8, this);
        }

        [HttpGet]
        [Route("{id}")]
        public IHttpActionResult Get(int id)
        {
            var dal = StoryFactory.CreateStoryDal();
            return new JsonResult<Story>(dal.Get(id), new JsonSerializerSettings(), Encoding.UTF8, this);
        }

        [HttpPost]
        public IHttpActionResult Post([FromBody]Story story)
        {
            var dal = StoryFactory.CreateStoryDal();
            var id = dal.Insert(story);
            return new JsonResult<int>(id, new JsonSerializerSettings(), Encoding.UTF8, this);
        }

        [HttpPut]
        public IHttpActionResult Put([FromBody]Story story)
        {
            var dal = StoryFactory.CreateStoryDal();
            dal.Update(story);
            return new OkResult(this);
        }
    }
}
