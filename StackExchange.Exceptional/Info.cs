using System;
using StackExchange.Exceptional.Extensions;

namespace StackExchange.Exceptional
{
    /// <summary>
    /// Represents an application info message
    /// </summary>
    [Serializable]
    public class Info
    {
        /// <summary>
        /// The Id on this info message, strictly for primary keying on persistent stores
        /// </summary>
        public long Id { get; set; }

        /// <summary>
        /// Gets the name of the application that log this message
        /// </summary>
        public string ApplicationName { get; set; }

        /// <summary>
        /// Gets the hostname of where the message was logged
        /// </summary>
        public string MachineName { get; set; }

        /// <summary>
        /// Gets the time in UTC that the info message was logged
        /// </summary>
        public DateTime CreationDate { get; set; }

        /// <summary>
        /// Gets the info message
        /// </summary>
        public string Message { get; set; }

        /// <summary>
        /// Default ctor
        /// </summary>
        public Info()
        {
            ApplicationName = ErrorStore.ApplicationName;
            MachineName = Environment.MachineName;
            CreationDate = DateTime.UtcNow;
        }

        /// <summary>
        /// Initialize a new instance of the Info class.
        /// </summary>
        /// <param name="message">Info message</param>
        /// <param name="applicationName">Name of the application that log this message</param>
        public Info(string message, string applicationName = null) : this()
        {
            if (message.IsNullOrEmpty())
                throw new ArgumentNullException("message");

            ApplicationName = applicationName ?? ErrorStore.ApplicationName;
            MachineName = Environment.MachineName;
            CreationDate = DateTime.UtcNow;
            this.Message = message;
        }
    }
}