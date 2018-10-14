using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace Data_Structures_Group.Controllers
{
    public class QueueController : Controller
    {
        // GET: Queue
        static Queue<string> myQueue = new Queue<string>();
        
        public ActionResult Index()
        {
            if (ViewBag.Status == null)
            {
                ViewBag.Status = "Click a button on the right!";
            }
            return View();
        }
        public ActionResult AddOne()
        {
            myQueue.Enqueue("New Entry " + (myQueue.Count + 1)); //Adds one item to the Queue
            ViewBag.Status = "Added New Entry " + myQueue.Count; //Displays the top item on the Queue
            return View("Index"); //Then reroutes to the index view
        }

        public ActionResult AddMany()
        {
            myQueue.Clear(); //Remove all items in the Queue 
            for (int i = 0; i < 2000; i++)
            {
                myQueue.Enqueue("New Entry " + (myQueue.Count + 1));
            } //Loops through 2000 times to add new entries

            ViewBag.Status = "Added " + myQueue.Count + " items"; //Displays how many items were added to the Queue

            return View("Index");
        }
        public ActionResult Display()
        {
            if (myQueue.Count == 0) //Checks to see if there is anything in the Queue
            {
                ViewBag.Status = "There are no items to display";
                return View("Index");
            }
            ViewBag.Status = "All Items:";
            ViewBag.Queue = myQueue; //Sends the Queue to the viewbag so that it can be displayed
            return View("Index");
        }

        public ActionResult Clear()
        {
            myQueue.Clear(); //Clears all items
            ViewBag.Status = "All items removed from Queue";
            return View("Index");
        }

        public ActionResult Search()
        {
            System.Diagnostics.Stopwatch sw = new System.Diagnostics.Stopwatch(); //Code from Professor Anderson

            sw.Start();
            if (myQueue.Contains("New Entry 1000"))//Looks for 'New Entry 1000'
            {
                ViewBag.Status = "Item Found";
            }
            else //If there is nothing in the Queue, the item can't be found
            {
                ViewBag.Status = "Item not found";
            }

            sw.Stop();
            TimeSpan ts = sw.Elapsed;
            ViewBag.StopWatch = ts; //Sends the time span to a stopwatch to the ViewBag.Stopwatch

            return View("Index");
        }
    }
}