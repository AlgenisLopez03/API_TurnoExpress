using AutoMapper;
using GestorDeTurnos.Application.Interfaces.Repositories;
using GestorDeTurnos.Application.Interfaces.Services;
using GestorDeTurnos.Domain.Entities;
using Microsoft.AspNetCore.Http;

namespace GestorDeTurnos.Application.Services
{
    public class ReviewService : ServiceBase<Review>, IReviewService
    {
        public ReviewService(IAsyncRepository<Review> repository, IMapper mapper, IHttpContextAccessor httpContextAccessor)
            : base(repository, mapper, httpContextAccessor)
        {
        }
    }
}