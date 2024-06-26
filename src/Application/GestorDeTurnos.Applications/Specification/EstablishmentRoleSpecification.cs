
using GestorDeTurnos.Application.Dtos.EstablishmentRole;
using GestorDeTurnos.Application.Extensions;
using GestorDeTurnos.Application.Interfaces;
using GestorDeTurnos.Domain.Entities;
using System.Linq.Expressions;

namespace GestorDeTurnos.Application.Specification
{
    public class EstablishmentRoleSpecification : Specification<EstablishmentRoles>
    {
        public EstablishmentRoleSpecification(EstablishmentRoleFilterAndPaginationDto request) : base(request)
        {
            #region EstablishmentTypeId

            if (request.EstablishmentTypeId != null)
            {
                Expression<Func<EstablishmentRoles, bool>> expression = i => i.EstablishmentTypeId.Equals(request.EstablishmentTypeId);
                Criteria = Criteria is null ? expression : Criteria.And(expression);
            }

            #endregion
            #region EstablishmentType

            if (request.EstablishmentType != null)
            {
                Expression<Func<EstablishmentRoles, bool>> expression = i => i.EstablishmentType.TypeName.Contains(request.EstablishmentType);
                Criteria = Criteria is null ? expression : Criteria.And(expression);
            }

            #endregion
        }
    }
}