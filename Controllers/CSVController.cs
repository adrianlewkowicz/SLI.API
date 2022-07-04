using ClosedXML.Excel;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using SLI.API.Domain;
using System.Text;

namespace SLI.API.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class CSVController : ControllerBase
    {
        private readonly DataContext _datacontext;
        public CSVController(DataContext datacontext)
        {
            _datacontext = datacontext;
        }

        private List<Reports> reports = new List<Reports>
        {
            new Reports {Id = 1, LocalName="test1", NameExport="Export excel", UserNameExport="AdrianL" },
            new Reports {Id = 2, LocalName="test2", NameExport="Export excel2", UserNameExport="AdrianL2" },
            new Reports {Id = 3, LocalName="test3", NameExport="Export excel3", UserNameExport="AdrianL3" }
        };
        [HttpGet]
        public  IActionResult Csv()
        {
            var ctx = new StringBuilder();
            ctx.AppendLine("id, LocalName, NameExport, UserNameExport");
            foreach(var report in reports)
            {
                ctx.AppendLine($"{report.Id}, {report.LocalName}, {report.NameExport}, {report.UserNameExport}");
            }

            return File(Encoding.UTF8.GetBytes(ctx.ToString()), "text/csv", "report.csv");
        }
        [HttpGet]
        public IActionResult Excel()
        {
            using(var xtc = new XLWorkbook())
            {
                var work = xtc.Worksheets.Add("Reports");
                var current = 1;
                work.Cell(current, 1).Value = "Id";
                work.Cell(current, 2).Value = "LocalName";
                work.Cell(current, 3).Value = "NameExport";
                work.Cell(current, 4).Value = "UserNameExport";
                foreach(var rep in reports)
                {
                    current++;
                    work.Cell(current, 1).Value = rep.Id;
                    work.Cell(current, 2).Value = rep.LocalName;
                    work.Cell(current, 3).Value = rep.NameExport;
                    work.Cell(current, 4).Value = rep.UserNameExport;
                }

                using(var stream = new MemoryStream())
                {
                   xtc.SaveAs(stream);
                    var content = stream.ToArray();

                    return File(content, "application/vnd.openxmlformats-officedocument.spreadsheetml.sheet", "reports.xlsx");
                }
            }
        }
    }
}
