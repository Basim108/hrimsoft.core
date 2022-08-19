using System;
using System.Runtime.Serialization;

namespace Hrimsoft.Core.Exceptions
{
    /// <inheritdoc />
    /// <summary>
    /// Any error related to wrong or missed configuration
    /// </summary>
    [Serializable]
    public class ConfigurationException : Exception
    {
        /// <inheritdoc />
        public ConfigurationException()
            : base("Something wrong with application configuration")
        {
        }

        /// <inheritdoc />
        public ConfigurationException(string message) : base(message)
        {
        }

        /// <inheritdoc />
        public ConfigurationException(string message, Exception innerException)
            : base(message, innerException)
        {
        }

        /// <inheritdoc />
        public ConfigurationException(string sectionName, string key)
            : base($"Configuration is wrong. Section name is '{sectionName ?? "root"}' key name is '{key}'")
        {
            this.ConfigurationSection = sectionName ?? "root";
            this.ConfigurationKey = key;
        }

        /// <summary>
        /// Initializes a new instance of the <see cref="T:System.ApplicationException"></see> class with serialized data.
        /// </summary>
        /// <param name="info">The object that holds the serialized object data.</param>
        /// <param name="context">The contextual information about the source or destination.</param>
        protected ConfigurationException(SerializationInfo info, StreamingContext context)
            : base(info, context)
        {
            if (info == null)
                throw new ArgumentNullException(nameof(info));

            this.ConfigurationSection = info.GetString(nameof(this.Section));
            this.ConfigurationKey = info.GetString(nameof(this.Key));
        }

        /// <summary>
        /// Serialize current instance of exception
        /// </summary>
        /// <param name="info">The object that holds the serialized object data.</param>
        /// <param name="context">The contextual information about the source or destination.</param>
        public override void GetObjectData(SerializationInfo info, StreamingContext context)
        {
            if (info == null)
                throw new ArgumentNullException(nameof(info));

            base.GetObjectData(info, context);

            info.AddValue(nameof(this.Section), this.Section);
            info.AddValue(nameof(this.Key), this.Key);
        }

        /// <summary>
        /// ConfigurationName of the section that is missing or contains wrong configuration
        /// </summary>
        protected string ConfigurationSection;

        /// <summary>
        /// ConfigurationName of the section that is missing or contains wrong configuration
        /// </summary>
        public string Section => ConfigurationSection;

        /// <summary>
        /// ConfigurationName of the configuration key that is missing or contains wrong value
        /// </summary>
        public string Key => ConfigurationKey;

        /// <summary>
        /// ConfigurationName of the configuration key that is missing or contains wrong value
        /// </summary>
        protected string ConfigurationKey;
    }
}