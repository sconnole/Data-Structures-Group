using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace Data_Structures_Group.Controllers
{
    public class StackController : Controller
    {
        static Stack<string> myStack = new Stack<string>();
        // GET: Stack
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
            myStack.Push("New Entry " + (myStack.Count + 1)); //Adds one item to the stack
            ViewBag.Status = "Added " + myStack.Peek(); //Displays the top item on the stack
            return View("Index"); //Then reroutes to the index view
        }

        public ActionResult AddMany()
        {
            myStack.Clear(); //Remove all items in the stack 
            for (int i = 0; i < 2000; i++)
            {
                myStack.Push("New Entry " + (myStack.Count + 1));
            } //Loops through 2000 times to add new entries

            ViewBag.Status = "Added " + myStack.Count + " items"; //Displays how many items were added to the stack

            return View("Index");
        }
        public ActionResult Display ()
        {
            if (myStack.Count == 0) //Checks to see if there is anything in the stack
            {
                ViewBag.Status = "There are no items to display";
                return View("Index");
            }
            ViewBag.Status = "All Items:";
            ViewBag.Stack = myStack; //Sends the stack to the viewbag so that it can be displayed
            return View("Index");
        }
        
        public ActionResult Clear ()
        {
            myStack.Clear(); //Clears all items
            ViewBag.Status = "All items removed from stack";
            return View("Index");
        }

        public ActionResult Search ()
        {
            System.Diagnostics.Stopwatch sw = new System.Diagnostics.Stopwatch(); //Code from Professor Anderson

            sw.Start();
            if (myStack.Contains("New Entry 1000"))
            {
                ViewBag.Status = "Item Found";
            }
            myStack.Contains("New Entry 1000"); //Looks for 'New Entry 1000'
            if (myStack.Count == 0) //If there is nothing in the stack, the item can't be found
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