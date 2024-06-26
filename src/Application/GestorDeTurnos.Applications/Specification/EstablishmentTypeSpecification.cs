
using GestorDeTurnos.Application.Dtos.EstablishmentType;
using GestorDeTurnos.Application.Extensions;
using GestorDeTurnos.Domain.Entities;
using System.Linq.Expressions;

namespace GestorDeTurnos.Application.Specification
{
    public class EstablishmentTypeSpecification : Specification<EstablishmentTypes>
    {
        public EstablishmentTypeSpecification(EstablishmentTypeFilterAndPaginationDto request) : base(request)
        {
            #region TypeName

            if (request.TypeName != null)
            {
                Expression<Func<EstablishmentTypes, bool>> expression = i => i.TypeName.Contains(request.TypeName);
                Criteria = Criteria is null ? expression : Criteria.And(expression);
            }

            #endregion
        }
    }
}
