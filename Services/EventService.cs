using EventEaseApp.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace EventEaseApp.Services
{
    public class EventService
    {
        private List<Event> events = new List<Event>
        {
            new Event { Id = 1, Name = "Event 1", Date = new DateTime(2025, 3, 15), Location = "New York" },
            new Event { Id = 2, Name = "Event 2", Date = new DateTime(2025, 4, 20), Location = "Los Angeles" },
            new Event { Id = 3, Name = "Event 3", Date = new DateTime(2025, 5, 10), Location = "Chicago" },
            new Event { Id = 4, Name = "Event 4", Date = new DateTime(2025, 3, 15), Location = "New York" },
            new Event { Id = 5, Name = "Event 5", Date = new DateTime(2025, 4, 20), Location = "Los Angeles" },
            new Event { Id = 6, Name = "Event 6", Date = new DateTime(2025, 5, 10), Location = "Chicago" },
            new Event { Id = 7, Name = "Event 7", Date = new DateTime(2025, 3, 15), Location = "New York" },
            new Event { Id = 8, Name = "Event 8", Date = new DateTime(2025, 4, 20), Location = "Los Angeles" },
            new Event { Id = 9, Name = "Event 9", Date = new DateTime(2025, 5, 10), Location = "Chicago" },
            new Event { Id = 10, Name = "Event 10", Date = new DateTime(2025, 3, 15), Location = "New York" },
            new Event { Id = 11, Name = "Event 11", Date = new DateTime(2025, 3, 15), Location = "New York" },
            new Event { Id = 12, Name = "Event 12", Date = new DateTime(2025, 4, 20), Location = "Los Angeles" },
            new Event { Id = 13, Name = "Event 13", Date = new DateTime(2025, 5, 10), Location = "Chicago" },
            new Event { Id = 14, Name = "Event 14", Date = new DateTime(2025, 3, 15), Location = "New York" }
        };

        public event Action OnChange;

        public Task<Event> GetEventByIdAsync(int eventId)
        {
            var eventItem = events.FirstOrDefault(e => e.Id == eventId);
            if (eventItem == null)
            {
                throw new InvalidOperationException($"Event with Id {eventId} not found.");
            }
            return Task.FromResult(eventItem);
        }

        public Task<List<Event>> GetEventsAsync()
        {
            return Task.FromResult(events);
        }

        public void UpdateEvent(Event updatedEvent)
        {
            var eventItem = events.FirstOrDefault(e => e.Id == updatedEvent.Id);
            if (eventItem != null)
            {
                eventItem.Name = updatedEvent.Name;
                eventItem.Date = updatedEvent.Date;
                eventItem.Location = updatedEvent.Location;
                NotifyStateChanged();
            }
        }

        private void NotifyStateChanged() => OnChange?.Invoke();
    }
}