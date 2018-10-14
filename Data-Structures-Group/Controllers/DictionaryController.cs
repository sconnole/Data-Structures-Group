using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace Data_Structures_Group.Controllers
{
    public class DictionaryController : Controller
    {
        static Dictionary<int, string> myDictionary = new Dictionary<int, string>();
        // GET: Dictionary
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
            myDictionary.Add(myDictionary.Count, "New Entry " + (myDictionary.Count + 1)); //Adds one item to the Dictionary
            ViewBag.Status = "Added " + myDictionary.Values.Last(); //Displays the top item on the Dictionary
            return View("Index"); //Then reroutes to the index view
        }

        public ActionResult AddMany()
        {
            myDictionary.Clear(); //Remove all items in the Dictionary 
            for (int i = 0; i < 2000; i++)
            {
                myDictionary.Add(myDictionary.Count, "New Entry " + (myDictionary.Count + 1));
            } //Loops through 2000 times to add new entries

            ViewBag.Status = "Added " + myDictionary.Count + " items"; //Displays how many items were added to the Dictionary

            return View("Index");
        }
        public ActionResult Display()
        {
            if (myDictionary.Count == 0) //Checks to see if there is anything in the Dictionary
            {
                ViewBag.Status = "There are no items to display";
                return View("Index");
            }
            ViewBag.Status = "All Items:";
            ViewBag.Dictionary = myDictionary; //Sends the Dictionary to the viewbag so that it can be displayed
            return View("Index");
        }

        public ActionResult Clear()
        {
            myDictionary.Clear(); //Clears all items
            ViewBag.Status = "All items removed from Dictionary";
            return View("Index");
        }

        public ActionResult Search()
        {
            System.Diagnostics.Stopwatch sw = new System.Diagnostics.Stopwatch(); //Code from Professor Anderson

            sw.Start();
            if (myDictionary.ContainsValue("New Entry 1000"))//Looks for 'New Entry 1000'
            {
                ViewBag.Status = "Item Found";
            }
            else //If there is nothing in the Dictionary, the item can't be found
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