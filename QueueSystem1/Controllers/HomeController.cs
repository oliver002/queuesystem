using QueueSystem1.BAL;
using QueueSystem1.DAL.DomainEntity;
using QueueSystem1.Models.QueueData;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace QueueSystem1.Controllers
{
    public class HomeController : Controller
    {
        public ActionResult Index()
        {
            //QueueService service = new QueueService();
            //service.PutIntoQueue("A");
            return View();
        }

        [HttpPost]
        public ActionResult TakeNumber(QueueDataServiceTypeRequest queueTake)
        {
            QueueService service = new QueueService();
            service.PutIntoQueue(queueTake.ServiceType);
            return Json(new { Message = "Success"});
        }

        [HttpPost]
        public ActionResult StartServing(QueueDataServiceTypeRequest queueStartServe)
        {
            QueueService service = new QueueService();
            QueueData data = service.StartServing(queueStartServe.ServiceType);
            return Json(data);
        }
        
        [HttpPost]
        public ActionResult CancelServing(QueueDataUpdate queueCancelServe)
        {
            QueueService service = new QueueService();
            service.CancelServing(queueCancelServe.ServiceType, queueCancelServe.ServiceNumber);
            return Json(new { Message = "Success update CancelServing" });
        }

        [HttpPost]
        public ActionResult Served(QueueDataUpdate queueServed)
        {
            QueueService service = new QueueService();
            service.Served(queueServed.ServiceType, queueServed.ServiceNumber);
            return Json(new { Message = "Success update Served" });
        }

        [HttpGet]
        public ActionResult GetWaitingList()
        {
            QueueService service = new QueueService();
            var waitingList = service.GetWaitingList();
            return Json(waitingList, JsonRequestBehavior.AllowGet);
        }


        public ActionResult Enter()
        {
            return View();
        }

        public ActionResult Client()
        {
            return View();
        }

        public ActionResult Inside()
        {
            return View();
        }
    }
}