using System;

namespace StackExchange.Exceptional
{
    /// <summary>
    /// Represents an application log item.
    /// </summary>
    public interface ILogItem
    {
        /// <summary>
        /// The Id on this info message, strictly for primary keying on persistent stores
        /// </summary>
        long Id { get; set; }

        /// <summary>
        /// Unique identifier for this log item, gernated on the server it came from
        /// </summary>
        Guid GUID { get; set; }

        /// <summary>
        /// Gets the name of the application that log this message
        /// </summary>
        string ApplicationName { get; set; }

        /// <summary>
        /// Gets the hostname of where the message was logged
        /// </summary>
        string MachineName { get; set; }

        /// <summary>
        /// Gets the time in UTC that the info message was logged
        /// </summary>
        DateTime CreationDate { get; set; }

        /// <summary>
        /// Date this log item was deleted (for stores that support deletion and retention, e.g. SQL)
        /// </summary>
        DateTime? DeletionDate { get; set; }

        /// <summary>
        /// The hash that describes this log item
        /// </summary>
        int? ItemHash { get; set; }

        /// <summary>
        /// The number of newer log items that have been discarded because they match this log item and fall within the configured 
        /// "IgnoreSimilarExceptionsThreshold" TimeSpan value.
        /// </summary>
        int? DuplicateCount { get; set; }

        /// <summary>
        /// Gets the info message
        /// </summary>
        string Message { get; set; }

        /// <summary>
        /// Reflects if the log item is protected from deletion
        /// </summary>
        bool IsProtected { get; set; }
    }
}