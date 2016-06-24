using QueueSystem1.BAL;
using QueueSystem1.DAL.DomainEntity;
using QueueSystem1.ViewModels;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace QueueSystem1.Controllers
{
	public class ReportController : Controller
	{
		//
		// GET: /Report/
		public ActionResult GetReport(DateTime? reportDate = null)
        //public ActionResult GetReport(DateTime reportDate)
		{
            ReportQueueDataViewModel viewModel = new ReportQueueDataViewModel();
			//viewModel.ReportDate = reportDate;

            ReportService rService = new ReportService();
		    DateTime rDate = reportDate.HasValue ? reportDate.Value : DateTime.Now.Date;
            ReportQueueData rDataDomain = rService.GetReport(rDate);

            viewModel = new ReportQueueDataViewModel(rDataDomain, rDate);


			//return View("index", viewModel);

            return View("index",viewModel);
		}
	}
}