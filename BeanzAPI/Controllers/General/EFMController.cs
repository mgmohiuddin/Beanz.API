using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Configuration;
using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Beanz.API.Controllers.General
{
    [Route("api/[controller]")]
    [ApiController]
    public class EFMController : ControllerBase
    {
        public IConfiguration Configuration { get; }
        public EFMController(IConfiguration configuration)
        {
            Configuration = configuration;
        }
        // GET api/values
        [HttpGet]
        public ActionResult<IEnumerable<string>> Get()
        {
            return new string[] { "EFM", "ERROR FILE MAMAGER" };
        }

        // GET api/values/5
        [HttpGet("{id}")]
        public async Task<ActionResult<IEnumerable<string>>> Get(int id)
        { 
            // id means number of days to minus and see the error log of that date
           //var strpath = @"C:\Users\Jano\Documents\thermopylae.txt";
            string content = "File Not Found, No Errors on that Day!";
            string LogRollingPath = Configuration.GetSection("BeanzLog").GetValue<string>("Location");
            string LogFileName = "log-" + GetFileLogName(id)+ ".txt";
            var strpath = LogRollingPath;

            var files = Directory.GetFiles(strpath);
            strpath += LogFileName;
            var filesCollection =  files.Where(c => c.Contains(LogFileName));
            if(filesCollection.Count()>0)
            {
                using (var fs = new FileStream(strpath, FileMode.Open, FileAccess.Read, FileShare.ReadWrite))
                {
                    using (var sr = new StreamReader(fs, Encoding.UTF8))
                    {
                        content = await sr.ReadToEndAsync();
                    }
                }
            } 
            // string content = File.ReadAllText(path, Encoding.UTF8);
            return Content(content);
        }

        private  string GetFileLogName(int DaysToMinus)
        {
            DateTime dateToFindFile = DateTime.Today;
            if(DaysToMinus>0)
            {
                dateToFindFile = DateTime.Now.AddDays(-DaysToMinus);
            }
            string sDay = dateToFindFile.Day.ToString();
            string sMonth = dateToFindFile.Month.ToString();
            string sYear = dateToFindFile.Year.ToString();
            
            while(sDay.Length<2)
            {
                sDay = "0" + sDay;
            }
            while (sMonth.Length < 2)
            {
                sMonth = "0" + sMonth;
            }
            if(sYear.Length == 2)
            {
                sYear = "20" + sYear;
            }
            string sfileName = sYear + sMonth + sDay;
            return  sfileName;
        }


        // POST api/values
        [HttpPost]
        public void Post([FromBody] string value)
        {
        }

        // PUT api/values/5
        [HttpPut("{id}")]
        public void Put(int id, [FromBody] string value)
        {
        }

        // DELETE api/values/5
        [HttpDelete("{id}")]
        public void Delete(int id)
        {
        }
    }
}
