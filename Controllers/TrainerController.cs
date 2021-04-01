using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Web.Http;
using LearnTodayWebAPI.Models;

namespace LearnTodayWebAPI.Controllers
{
    public class TrainerController : ApiController
    {
        LearnTodayWebAPIDbContext dbContext = new LearnTodayWebAPIDbContext();
        [HttpPost]
        public HttpResponseMessage TrainerSignUp([FromBody] Trainer model)
        {
            try
            {
                dbContext.Trainers.Add(model);
                dbContext.SaveChanges();
                return Request.CreateResponse(HttpStatusCode.Created, model);
            }
            catch (Exception ex)
            {
                return Request.CreateResponse(HttpStatusCode.BadRequest, ex);
            }
        }

        [HttpPut]
        public HttpResponseMessage UpdatePassword(int id, [FromBody] Trainer model)
        {
            Trainer trainer = dbContext.Trainers.Find(id);
            try
            {
                if (model != null && trainer != null)
                {
                    trainer.Password = model.Password;
                    dbContext.SaveChanges();
                    return Request.CreateResponse(HttpStatusCode.Created, "Data updated successfully");
                }
                else
                {
                    return Request.CreateResponse(HttpStatusCode.NotFound, "Searched Data not Found");
                }
            }
            catch (Exception ex)
            {
                return Request.CreateResponse(HttpStatusCode.BadRequest, ex);
            }
        }
    }
}
