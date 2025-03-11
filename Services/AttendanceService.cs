using EventEaseApp.Models;
using System.Collections.Generic;
using System.Linq;

namespace EventEaseApp.Services
{
    public class AttendanceService
    {
        private readonly Dictionary<int, List<RegistrationModel>> attendance = new Dictionary<int, List<RegistrationModel>>();

        public void AddParticipant(int eventId, RegistrationModel participant)
        {
            if (!attendance.ContainsKey(eventId))
            {
                attendance[eventId] = new List<RegistrationModel>();
            }
            attendance[eventId].Add(participant);
        }

        public List<RegistrationModel> GetParticipants(int eventId)
        {
            if (attendance.ContainsKey(eventId))
            {
                return attendance[eventId];
            }
            return new List<RegistrationModel>();
        }
    }
}