namespace GestorDeTurnos.Application.Exceptions
{
    /// <summary>
    /// Represents errors that occur when a specified entity or resource is not found. This custom exception is typically used
    /// in data access layers or service layers to indicate that a requested item does not exist.
    /// </summary>
    public class NotFoundException : ApplicationException
    {
        /// <summary>
        /// Initializes a new instance of the <see cref="NotFoundException"/> class with the specified entity name and key.
        /// This constructor is used when an entity with a specific identifier is not found.
        /// </summary>
        /// <param name="name">The name of the entity that was not found.</param>
        /// <param name="key">The key or identifier of the entity that was not found.</param>
        public NotFoundException(string name, object? key) : base($"{name} with id ({key}) was not found")
        {
        }

        /// <summary>
        /// Initializes a new instance of the <see cref="NotFoundException"/> class with the specified entity name.
        /// This constructor is used when an entity of a certain type is not found, without specifying an identifier.
        /// </summary>
        /// <param name="name">The name of the entity type that was not found.</param>
        public NotFoundException(string name) : base($"{name} was not found")
        {
        }
    }
}