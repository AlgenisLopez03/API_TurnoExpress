
using GestorDeTurnos.Application.Dtos.JobApplication;
using GestorDeTurnos.Domain.Entities;
using GestorDeTurnos.Application.Extensions;
using System.Linq.Expressions;


namespace GestorDeTurnos.Application.Specification
{
    public class JobApplicationSpecification : Specification<JobApplication>
    {
        public JobApplicationSpecification(JobApplicationFilterAndPaginationDto request) : base(request) 
        {
            #region UserId

            if (request.UserId != null)
            {
                Expression<Func<JobApplication, bool>> expression = i => i.UserId.Equals(request.UserId);
                Criteria = Criteria is null ? expression : Criteria.And(expression);
            }

            #endregion UserId

            #region EstablishmentId

            if (request.EstablishmentId != null)
            {
                Expression<Func<JobApplication, bool>> expression = i => i.EstablishmentId.Equals(request.EstablishmentId);
                Criteria = Criteria is null ? expression : Criteria.And(expression);
            }

            #endregion EstablishmentId

            #region Status

            if (request.Status != null)
            {
                Expression<Func<JobApplication, bool>> expression = i => i.Status.Equals(request.Status);
                Criteria = Criteria is null ? expression : Criteria.And(expression);
            }

            #endregion Status
        }
    }
}
