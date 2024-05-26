using GestorDeTurnos.Application.Constants;
using GestorDeTurnos.Application.Enums;
using GestorDeTurnos.Domain.Entities;

namespace GestorDeTurnos.Persistence.Seeds
{
    /// <summary>
    /// Provides a seed of default values for Statues.
    /// </summary>
    public static class StatusSeed
    {
        public static readonly List<Status> DefaultValues = new List<Status>
        {
            new Status
            {
                Id = (int)StatusType.Pending,
                Name = StatusType.Pending.ToString()
            },
            new Status
            {
                Id = (int)StatusType.Attending,
                Name = StatusType.Attending.ToString()
            },
            new Status
            {
                Id = (int)StatusType.Attended,
                Name = StatusType.Attended.ToString()
            },
            new Status
            {
                Id = (int)StatusType.Canceled,
                Name = StatusType.Canceled.ToString()
            }
        };

    }
}