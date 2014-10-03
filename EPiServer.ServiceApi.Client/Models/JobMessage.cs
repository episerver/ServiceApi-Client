using System;

namespace EPiServer.Integration.Client.Models
{
    public enum MessageType
    {
        /// <summary>
        /// The message is a transient progress message. Progress messages will be immediately
        /// overwritten by the next message, and will not be persisted in the log.
        /// </summary>
        Progress,
        /// <summary>
        /// The message contains debugging output.
        /// </summary>
        Debug,
        /// <summary>
        /// The message is informational.
        /// </summary>
        Info,
        /// <summary>
        /// The message contains a warning.
        /// </summary>
        Warning,
        /// <summary>
        /// The message indicates overall success. Success should only be used for the final message in the log.
        /// </summary>
        Success,
        /// <summary>
        /// The message indicates overall failure. Failure should only be used for the final message in the log.
        /// </summary>
        Error
    }

    public class JobMessage
    {
        /// <summary>   Gets or sets the timestamp of the message, in UTC. </summary>
        /// <value> The timestamp UTC. </value>
        public DateTime TimestampUtc { get; set; }

        /// <summary>   Gets or sets the type of the message. </summary>
        /// <value> The type of the message. </value>
        public MessageType MessageType { get; set; }

        /// <summary>   Gets or sets the content of the message. </summary>
        /// <value> The message. </value>
        public string Message { get; set; }

        /// <summary>   Gets or sets the name of the current stage of processing. </summary>
        /// <value> The name of the stage. </value>
        public string StageName { get; set; }

        /// <summary>   Gets or sets the index (zero based) of the current stage. </summary>
        /// <value> The stage index. </value>
        public int StageIndex { get; set; }

        /// <summary>   Gets or sets the number of stages in the task. </summary>
        /// <value> The number of stages. </value>
        public int StageCount { get; set; }

        /// <summary>   Gets or sets the current progress within the current stage of execution. </summary>
        /// <value> The stage progress. </value>
        public int StageProgress { get; set; }

        /// <summary>
        /// Gets or sets the value of <see cref="P:StageProgress"/> that indicates completion of the
        /// current stage.
        /// </summary>
        /// <value> The stage total progress. </value>
        public int StageTotalProgress { get; set; }

        /// <summary>
        /// Gets or sets the exception resulting in failure of the task, or null if the message is not a
        /// failure message.
        /// </summary>
        /// <value> The exception. </value>
        public Exception Exception { get; set; }

        /// <summary>
        /// Gets or sets the exception message from <see cref="P:Exception"/>, or null if
        /// <see cref="Exception"/> is null.
        /// </summary>
        /// <value> A message describing the exception. </value>
        public string ExceptionMessage { get; set; }

        /// <summary>
        /// Gets or sets the stack trace from <see cref="P:Exception"/>, or null if
        /// <see cref="Exception"/> is null.
        /// </summary>
        /// <value> The exception stack trace. </value>
        public string ExceptionStackTrace { get; set; }

        /// <summary>   Default constructor. </summary>
        /// <remarks>    </remarks>
        public JobMessage()
        {
        }
    }
}
