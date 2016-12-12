using System;

namespace UserAccessSystem.Services.Exceptions {
    public class FailedToAddObjectToDatabaseException : Exception {
        public FailedToAddObjectToDatabaseException(string message) : base(message) {
        }
    }
}