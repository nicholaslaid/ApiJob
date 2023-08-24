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

                if (Config.tempLisJob.Count > 0)
                {
                    result.data = JsonConvert.SerializeObject(Config.tempLisJob);
                    result.success = true;
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
                result.errorMessage = ErrorCode.UnhandledException.ToString() + " - " + ex.Message;
            }

            return new JsonResult(result);
        }

        [HttpGet]
        [Route("Get")]
        public JsonResult Get(int id)
        {
            Result result = new Result();
            Job job = new Job();

            try
            {
                job = Config.tempLisJob.Find(x => x.id == id);

                if (job != null && job.id > 0)
                {
                    result.data = JsonConvert.SerializeObject(job);
                    result.success = true;
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
                result.errorCode = Convert.ToInt32(ErrorCode.UnknownError);
                result.errorMessage = ErrorCode.UnknownError.ToString() + " - " + ex.Message;

            }

            return new JsonResult(result);

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
            catch (Exception ex)
            {
                result.success = false;
                result.errorCode = Convert.ToInt32(ErrorCode.UnhandledException);
                result.errorMessage = ErrorCode.UnhandledException.ToString() + " - " + ex.Message;
            }

            return new JsonResult(result);
        }

        [HttpPut]
        [Route("Update")]
        public JsonResult Update(Job job)
        {
            Result result = new Result();
            int idx = -1;

            try
            {
                idx = Config.tempLisJob.FindIndex(x => x.id == job.id);

                if (idx >= 0)
                {
                    Config.tempLisJob[idx] = job;
                    result.success = true;
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
                result.errorMessage = ErrorCode.UnhandledException.ToString() + " - " + ex.Message;
            }

            return new JsonResult(result);
        }

        [HttpDelete]
        [Route("Delete")]
        public JsonResult Delete(int id)
        {
            Result result = new Result();
            int idx = -1;

            try
            {
                idx = Config.tempLisJob.FindIndex(x => x.id == id);

                if (idx >= 0)
                {
                    Config.tempLisJob.RemoveAt(idx);
                    result.success = true; 
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
                result.errorMessage = ErrorCode.UnhandledException.ToString() + " - " + ex.Message;
            }

            return new JsonResult(result);
        }
    }
}
