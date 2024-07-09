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
            #region User

            if (request.UserId != null)
            {
                Expression<Func<Appointment, bool>> expression = i => i.UserId.Equals(request.UserId);
                Criteria = Criteria is null ? expression : Criteria.And(expression);
            }

            #endregion User

            #region Establishment

            if (request.EstablishmentId != null)
            {
                Expression<Func<Appointment, bool>> expression = i => i.EstablishmentId.Equals(request.EstablishmentId);
                Criteria = Criteria is null ? expression : Criteria.And(expression);
            }

            #endregion Establishment

            #region Service

            if (request.ServiceId != null)
            {
                Expression<Func<Appointment, bool>> expression = i => i.ServiceId.Equals(request.ServiceId);
                Criteria = Criteria is null ? expression : Criteria.And(expression);
            }

            #endregion Service

            #region Status

            if (request.Status != null)
            {
                Expression<Func<Appointment, bool>> expression = i => i.StatusId.Equals((int)request.Status);
                Criteria = Criteria is null ? expression : Criteria.And(expression);
            }

            #endregion Status

            #region Employee

            if (request.EmployeeId != null)
            {
                Expression<Func<Appointment, bool>> expression = i => i.EmployeeId.Equals(request.EmployeeId);
                Criteria = Criteria is null ? expression : Criteria.And(expression);
            }

            #endregion Employee
        }

    }
}