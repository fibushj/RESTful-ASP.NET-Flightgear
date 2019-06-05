using Ex3.Models;
using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using System.Net;
using System.Web;
using System.Web.Mvc;

namespace Ex3.Controllers
{
    public class DisplayController : Controller
    {
        public ActionResult Index()
        {
            return View();
        }

        /* deciding whether it's the case of the first or the fourth address - and redirecting accordingly */
        public ActionResult Decide(string param1, string param2)
        {
            IPAddress ip;
            bool isIPAddress = IPAddress.TryParse(param1, out ip);
            if (isIPAddress)
            {
                return SinglePoint(param1, Int32.Parse(param2));
            }
            else
            {
                return Load(param1, Int32.Parse(param2));
            }
        }

        public ActionResult SinglePoint(string ip, int port)
        {
            MyModel.Instance.ConnectToSimulator(ip, port);
            return View("SinglePoint");

        }

        /* serving the first address */
        [HttpPost]
        public string GetLocation()
        {
            return MyModel.Instance.ReceiveCoordinates();
        }

        /* getting the location (+throttle+rudder) and saving it to the file specified by filename */
        [HttpPost]
        public string GetLocation1(string filename)
        {
            return MyModel.Instance.SaveValues(filename);
        }

        /* getting the location (+throttle+rudder) from the file at line specified by index */
        [HttpPost]
        public string GetLocation2(string filename, int index)
        {
            return MyModel.Instance.LoadValues(filename, index);
        }


        /* serving the second address */
        public ActionResult MultiplePoints (string ip, int port, int interval)
        {
            MyModel.Instance.ConnectToSimulator(ip, port);
            ViewBag.interval = interval;
            return View();
        }

        /* serving the third address */
        public ActionResult Save(string ip, int port, int interval, int duration, string filename)
        {
            MyModel.Instance.ConnectToSimulator(ip, port);
            ViewBag.interval = interval;
            ViewBag.duration = duration;
            ViewBag.filename = filename;
            return View();
        }

        /* serving the fourth address */
        public ActionResult Load(string filename, int interval)
        {
            ViewBag.filename = filename;
            ViewBag.interval = interval;
            ViewBag.numOfLines = MyModel.Instance.GetNumOfValues(filename);
            return View("Load");
        }       
    }
}