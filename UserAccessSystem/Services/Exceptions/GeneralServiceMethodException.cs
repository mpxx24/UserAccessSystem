using System;

namespace UserAccessSystem.Services.Exceptions {
    public class GeneralServiceMethodException : Exception {
        public GeneralServiceMethodException(string message, Exception innerException) : base(message, innerException) {
        }
    }
}