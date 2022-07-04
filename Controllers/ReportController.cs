using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using SLI.API.Domain;

namespace SLI.API.Controllers
{
    //https://localhost:7297/api/report
    [Route("api/[controller]")]
    [ApiController]
    public class ReportController : ControllerBase
    {
        private readonly DataContext _dataContext;
        public ReportController(DataContext dataContext)
        {
            _dataContext = dataContext;
        }

        [HttpGet]
        public IActionResult GetReports()
        {
            var ctx = _dataContext.Reports.ToList();
            return Ok(ctx);
        }
        [HttpGet("id")]
        public IActionResult GetReports(int id)
        {
            var ctx = _dataContext.Reports.FirstOrDefault(x => x.Id == id);
            return Ok(ctx);
        }

        [HttpPost("id")]
        public IActionResult AddReport([FromBody] Reports reports)
        {
            var ctx = _dataContext.Reports.Add(reports);
            return Ok(ctx);
        }

        [HttpPut("id")]
        public IActionResult EditReport(int id, [FromBody] Reports reports)
        {
            var data = _dataContext.Reports.Find(id);
            data.Id = reports.Id;
            data.NameExport = reports.NameExport;
            data.GetDateTimeExport = reports.GetDateTimeExport;
            data.UserNameExport = reports.UserNameExport;
            data.LocalName = reports.LocalName;

            _dataContext.Update(data);
            return Ok(data);
        }

        [HttpDelete("id")]
        public IActionResult DelateReport(int id)
        {
            var ctx = _dataContext.Reports.Find(id);

            if (ctx != null)
                return BadRequest("nie znaleziono");

            var tcr = _dataContext.Reports.Remove(ctx);
            return Ok(tcr);
        }
    }
}
