using AutoMapper;
using GestorDeTurnos.Application.Dtos.Review;
using GestorDeTurnos.Domain.Entities;

namespace GestorDeTurnos.Application.Mapping
{
    public class ReviewProfile : Profile
    {
        public ReviewProfile()
        {
            CreateMap<CreateReviewDto, Review>();
            CreateMap<UpdateReviewDto, Review>();
            CreateMap<Review, ReviewListDto>();
            CreateMap<Review, ReviewDetailDto>();
        }
    }
}