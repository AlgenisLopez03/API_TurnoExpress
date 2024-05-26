using GestorDeTurnos.Application.Dtos.Report;
using GestorDeTurnos.Application.Extensions;
using GestorDeTurnos.Domain.Entities;
using System.Linq.Expressions;

namespace GestorDeTurnos.Application.Specification
{
    public class ReportSpecification : Specification<Report>
    {
        public ReportSpecification(ReportFilterAndPaginationDto request) : base(request)
        {
            #region Establishment

            if (request.Establishment != null)
            {
                Expression<Func<Report, bool>> expression = i => i.Establishment.BusinessName.Contains(request.Establishment);
                Criteria = Criteria is null ? expression : Criteria.And(expression);
            }

            #endregion Establishment
        }
    }
}