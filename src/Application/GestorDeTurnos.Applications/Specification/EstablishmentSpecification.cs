using GestorDeTurnos.Application.Dtos.Establishment;
using GestorDeTurnos.Application.Extensions;
using GestorDeTurnos.Domain.Entities;
using System.Linq.Expressions;

namespace GestorDeTurnos.Application.Specification
{
    public class EstablishmentSpecification : Specification<Establishment>
    {
        public EstablishmentSpecification(EstablishmentFilterAndPaginationDto request) : base(request)
        {
            #region UserID

            if (request.UserID != null)
            {
                Expression<Func<Establishment, bool>> expression = i => i.UserId.Equals(request.UserID);
                Criteria = Criteria is null ? expression : Criteria.And(expression);
            }

            #endregion UserID

            #region BusinessName

            if (request.BusinessName != null)
            {
                Expression<Func<Establishment, bool>> expression = i => i.BusinessName.Contains(request.BusinessName);
                Criteria = Criteria is null ? expression : Criteria.And(expression);
            }

            #endregion BusinessName

            #region Description

            if (request.Description != null)
            {
                Expression<Func<Establishment, bool>> expression = i => i.Description.Contains(request.Description);
                Criteria = Criteria is null ? expression : Criteria.And(expression);
            }

            #endregion Description
        }
    }
}