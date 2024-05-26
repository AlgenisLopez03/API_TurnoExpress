using GestorDeTurnos.Application.Dtos.Review;
using GestorDeTurnos.Application.Extensions;
using GestorDeTurnos.Domain.Entities;
using System.Linq.Expressions;

namespace GestorDeTurnos.Application.Specification
{
    public class ReviewSpecification : Specification<Review>
    {
        public ReviewSpecification(ReviewFilterAndPaginationDto request) : base(request)
        {
            #region Establishment

            if (request.Establishment != null)
            {
                Expression<Func<Review, bool>> expression = i => i.Establishment.BusinessName.Contains(request.Establishment);
                Criteria = Criteria is null ? expression : Criteria.And(expression);
            }

            #endregion Establishment
        }
    }
}