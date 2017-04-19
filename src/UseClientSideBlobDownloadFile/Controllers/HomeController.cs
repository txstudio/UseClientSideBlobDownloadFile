using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Hosting;

namespace UseClientSideBlobDownloadFile.Controllers
{
    public class HomeController : Controller
    {
        private readonly IHostingEnvironment _enviroment;
        private readonly CustomerReport _customerReport;

        public HomeController(IHostingEnvironment enviroment)
        {
            this._enviroment = enviroment;

            this._customerReport = new CustomerReport(this._enviroment);
        }

        public IActionResult Index()
        {
            var _query = this._customerReport.DefaultQuery();

            return View(_query);
        }

        [HttpPost]
        public IActionResult GetPdf([FromBody]CustomerReportQuery query)
        {
            var _result = this._customerReport.GetPdf(query);

            return Json(_result);
        }
        
        
    }
}
