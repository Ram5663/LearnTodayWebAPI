using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Web.Http;
using LearnTodayWebAPI.Models;

namespace LearnTodayWebAPI.Controllers
{
    public class AdminController : ApiController
    {
        LearnTodayWebAPIDbContext dbContext = new LearnTodayWebAPIDbContext();
        [HttpGet]
        public IEnumerable<Course> GetAllCourses()
        {
           
            List<Course> list = dbContext.Courses.ToList();
            return list;
        }

        [HttpGet]
        public HttpResponseMessage GetCourseById(int id)
        {
            

            Course courseId = dbContext.Courses.Find(id);
            if (courseId != null)
            {
                return Request.CreateResponse(HttpStatusCode.OK, courseId);
            }
            return Request.CreateResponse(HttpStatusCode.NotFound, "Searched Data not Found");
        }
    }
}
