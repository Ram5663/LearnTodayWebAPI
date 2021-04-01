using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Web.Http;
using LearnTodayWebAPI.Models;

namespace LearnTodayWebAPI.Controllers
{
    public class StudentController : ApiController
    {
        LearnTodayWebAPIDbContext dbContext = new LearnTodayWebAPIDbContext();
        [HttpGet]
        public IEnumerable<Course> GetAllCourses()
        {

            List<Course> list = dbContext.Courses.OrderBy(c => c.Start_Date).ToList();
            return list;
        }

        [HttpPost]
        public HttpResponseMessage PostStudent([FromBody] Student model)
        {

            try
            {
                dbContext.Students.Add(model);
                dbContext.SaveChanges();
                return Request.CreateResponse(HttpStatusCode.Created, model);
            }
            catch (Exception ex)
            {
                return Request.CreateResponse(HttpStatusCode.BadRequest, ex);
            }
        }

        [HttpDelete]
        public HttpResponseMessage DeleteStudentEnrollment(int id)
        {
            Student student = dbContext.Students.Find(id);
            try
            {
                if (student != null)
                {
                    dbContext.Students.Remove(student);
                    dbContext.SaveChanges();
                    return Request.CreateResponse(HttpStatusCode.OK);
                }
                else
                {
                    return Request.CreateResponse(HttpStatusCode.NotFound, "No enrollement information found");
                }
            }
            catch (Exception ex)
            {

                return Request.CreateResponse(HttpStatusCode.BadRequest, ex);
            }

        }
    }
}
