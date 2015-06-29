using System;
using StackExchange.Exceptional.Extensions;

namespace StackExchange.Exceptional
{
    /// <summary>
    /// Represents an application info message
    /// </summary>
    [Serializable]
    public class Info : ILogItem
    {
        /// <summary>
        /// The Id on this info message, strictly for primary keying on persistent stores
        /// </summary>
        public long Id { get; set; }

        /// <summary>
        /// Unique identifier for this log item, gernated on the server it came from
        /// </summary>
        public Guid GUID { get; set; }

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
        /// Date this log item was deleted (for stores that support deletion and retention, e.g. SQL)
        /// </summary>
        public DateTime? DeletionDate { get; set; }

        /// <summary>
        /// The hash that describes this log item
        /// </summary>
        public int? ItemHash { get; set; }

        /// <summary>
        /// The number of newer log items that have been discarded because they match this log item and fall within the configured 
        /// "IgnoreSimilarExceptionsThreshold" TimeSpan value.
        /// </summary>
        public int? DuplicateCount { get; set; }

        /// <summary>
        /// Gets the info message
        /// </summary>
        public string Message { get; set; }

        /// <summary>
        /// Reflects if the log item is protected from deletion
        /// </summary>
        public bool IsProtected { get; set; }

        /// <summary>
        /// Default constructor
        /// </summary>
        private Info()
        {
            ApplicationName = ErrorStore.ApplicationName;
            MachineName = Environment.MachineName;
            CreationDate = DateTime.UtcNow;
            GUID = Guid.NewGuid();
            DuplicateCount = 1;
        }

        /// <summary>
        /// Initialize a new instance of the Info class.
        /// </summary>
        /// <param name="message">Info message</param>
        /// <param name="applicationName">Name of the application that log this message</param>
        public Info(string message, string applicationName = null)
            : this()
        {
            if (message.IsNullOrEmpty())
                throw new ArgumentNullException("message");

            if (applicationName != null)
                ApplicationName = applicationName;

            Message = message;
            ItemHash = GetHash();
        }

        /// <summary>
        /// Gets a unique-enough hash of this log item.  Stored as a quick comparison mehanism to rollup duplicate log items.
        /// </summary>
        /// <returns>"Unique" hash for this log item</returns>
        public int? GetHash()
        {
            if (!Message.HasValue()) return null;

            var result = Message.GetHashCode();
            if (MachineName.HasValue())
                result = (result * 397) ^ MachineName.GetHashCode();

            return result;
        }
    }
}