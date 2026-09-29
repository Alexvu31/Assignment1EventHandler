using Assignment1EventHandler.Models;
using Microsoft.AspNetCore.Mvc;

namespace Assignment1EventHandler.Controllers
{
    public class EventManagerController : Controller
    {
        // Hardcoded events to simulate database persistence
        private static List<Event> events = new List<Event>
        {
            new Event
            {
                Id = 1,
                Title = "ASP.NET Core Workshop",
                Date = new DateTime(2026, 10, 5, 10, 0, 0),
                Location = "Room 101",
                Attendees = new List<Attendee>
                {
                    new Attendee
                    {
                        Name = "John Smith",
                        Email = "john@example.com"
                    }
                }
            },

            new Event
            {
                Id = 2,
                Title = "C# Programming Seminar",
                Date = new DateTime(2026, 10, 10, 13, 30, 0),
                Location = "Room 202",
                Attendees = new List<Attendee>()
            },

            new Event
            {
                Id = 3,
                Title = "Web Development Meetup",
                Date = new DateTime(2026, 10, 15, 18, 0, 0),
                Location = "Room 303",
                Attendees = new List<Attendee>()
            }
        };


        // Displays all events
        public IActionResult Index()
        {
            ViewData["Title"] = "Event Manager";
            ViewData["Description"] = "Manage events and their attendees.";

            return View(events);
        }


        // Displays the attendees for a specific event
        public IActionResult ManageAttendees(int id)
        {
            // Find the event using LINQ/lambda
            Event? selectedEvent = events.FirstOrDefault(e => e.Id == id);

            if (selectedEvent == null)
            {
                return NotFound();
            }

            ViewData["Title"] = "Manage Attendees";
            ViewData["EventName"] = selectedEvent.Title;

            return View(selectedEvent);
        }


        // Processes the signup form
        [HttpPost]
        public IActionResult ManageAttendees(int id, Attendee attendee)
        {
            // Find the event using LINQ/lambda
            Event? selectedEvent = events.FirstOrDefault(e => e.Id == id);

            if (selectedEvent == null)
            {
                return NotFound();
            }

            if (ModelState.IsValid)
            {
                selectedEvent.Attendees.Add(attendee);
            }

            return View(selectedEvent);
        }
    }
}