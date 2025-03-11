using System;

namespace EventEaseApp.Services
{
    public class UserSessionService
    {
        public string UserId { get; private set; }
        public DateTime SessionStartTime { get; private set; }

        public UserSessionService()
        {
            StartSession("User123"); // Example user ID
        }

        public void StartSession(string userId)
        {
            UserId = userId;
            SessionStartTime = DateTime.Now;
        }

        public void EndSession()
        {
            UserId = null;
            SessionStartTime = DateTime.MinValue;
        }

        public bool IsSessionActive()
        {
            return !string.IsNullOrEmpty(UserId);
        }
    }
}