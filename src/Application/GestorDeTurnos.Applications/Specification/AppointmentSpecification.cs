using GestorDeTurnos.Application.Dtos.Appointment;
using GestorDeTurnos.Application.Extensions;
using GestorDeTurnos.Domain.Entities;
using System.Linq.Expressions;

namespace GestorDeTurnos.Application.Specification
{
    public class AppointmentSpecification : Specification<Appointment>
    {
        public AppointmentSpecification(AppointmentFilterAndPaginationDto request) : base(request)
        {
            #region Establishment

            if (request.Establishment != null)
            {
                Expression<Func<Appointment, bool>> expression = i => i.Establishment.BusinessName.Contains(request.Establishment);
                Criteria = Criteria is null ? expression : Criteria.And(expression);
            }

            #endregion Establishment
        }
    }
}