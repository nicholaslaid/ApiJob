using Microsoft.AspNetCore.Mvc;
using ApiJob.Models;
using ApiJob.Global;
using Newtonsoft.Json;
using Microsoft.AspNetCore.Connections.Features;

namespace ApiJob.Controllers
{

    [ApiController]
    [Route("api/job")]
    public class JobController : Controller
    {
        [HttpGet]
        [Route("GetAll")]
       public JsonResult GetAll()
        {
            Result result = new Result();

            try
            {
                if(Config.tempLisJob.Count > 0)
                {
                    result.success = true;
                    result.data = JsonConvert.SerializeObject(Config.tempLisJob);

                }
                else
                {
                    result.success = false;
                    result.errorCode = Convert.ToInt32(ErrorCode.JobNotFoundError);
                    result.errorMessage = ErrorCode.JobNotFoundError.ToString();

                }
            }
            catch (Exception ex)
            {
                result.success = false;
                result.errorCode = Convert.ToInt32(ErrorCode.UnhandledException);
                result.errorMessage = ErrorCode.UnhandledException.ToString() + ex.Message;

            }

            return new JsonResult (result);
        }

        [HttpPost]
        [Route("Add")]

        public JsonResult Add(Job job)
        {
            Result result = new Result();

            try
            {
                job.id = Config.tempLisJob.Count + 1;
                Config.tempLisJob.Add(job);
                result.success = true;
            }
            catch(Exception ex)
            {
                result.success = false;
                result.errorCode = Convert.ToInt32(ErrorCode.UnhandledException);
                result.errorMessage = ErrorCode.UnhandledException.ToString() + ex.Message;
            }




            return new JsonResult(result);
        }
    }
}
