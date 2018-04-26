using System;

namespace Commandable
{
    [AttributeUsage(AttributeTargets.Method, Inherited = false, AllowMultiple = false)]
    public abstract class BaseCommandAttribute : Attribute
    {
        /// <summary>
        /// Gets the description of the command.
        /// </summary>
        public string Description { get; }

        protected BaseCommandAttribute(string description)
        {
            Description = description;
        }
    }

    /// <summary>
    /// Marks the method as the default command action.
    /// </summary>
    public sealed class DefaultCommandAttribute : BaseCommandAttribute
    {
        public DefaultCommandAttribute(string description) : base(description) { }
    }

    /// <summary>
    /// Marks the method as the command action.
    /// </summary>
    public sealed class CommandAttribute : BaseCommandAttribute
    {
        /// <summary>
        /// Gets or sets the command name. This property is optional.
        /// </summary>
        public string CommandName { get; set; }

        public CommandAttribute(string description) : base(description) { }
    }
}
