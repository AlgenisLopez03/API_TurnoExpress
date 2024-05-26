using GestorDeTurnos.Application.Dtos.Service;
using GestorDeTurnos.Application.Extensions;
using GestorDeTurnos.Domain.Entities;
using System.Linq.Expressions;

namespace GestorDeTurnos.Application.Specification
{
    public class ServiceSpecification : Specification<Service>
    {
        public ServiceSpecification(ServiceFilterAndPaginationDto request) : base(request)
        {
            #region Establishment

            if (request.Establishment != null)
            {
                Expression<Func<Service, bool>> expression = i => i.Establishment.BusinessName.Contains(request.Establishment);
                Criteria = Criteria is null ? expression : Criteria.And(expression);
            }

            #endregion Establishment

            #region Service

            if (request.Service != null)
            {
                Expression<Func<Service, bool>> expression = i => i.ServiceName.Contains(request.Service);
                Criteria = Criteria is null ? expression : Criteria.And(expression);
            }

            #endregion Service
        }
    }
}