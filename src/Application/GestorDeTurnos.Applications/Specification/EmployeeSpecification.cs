
using GestorDeTurnos.Application.Dtos.Employee;
using GestorDeTurnos.Application.Extensions;
using GestorDeTurnos.Domain.Entities;
using System.Linq.Expressions;

namespace GestorDeTurnos.Application.Specification
{
    public class EmployeeSpecification : Specification<Employees>
    {
        public EmployeeSpecification(EmployeeFilterAndPaginationDto request) : base(request)
        {
            #region UserId

            if (request.UserId != null)
            {
                Expression<Func<Employees, bool>> expression = i => i.UserId.Equals(request.UserId);
                Criteria = Criteria is null ? expression : Criteria.And(expression);
            }
            #endregion

            #region EstablishmentId

            if (request.EstablishmentId != null)
            {
                Expression<Func<Employees, bool>> expression = i => i.EstablishmentId.Equals(request.EstablishmentId);
                Criteria = Criteria is null ? expression : Criteria.And(expression);
            }

            #endregion

            #region Available

            if (request.Availabe != false)
            {
                Expression<Func<Employees, bool>> expression = i => i.Availabe.Equals(request.Availabe);
                Criteria = Criteria is null ? expression : Criteria.And(expression);
            }

            #endregion
        }
    }
}
