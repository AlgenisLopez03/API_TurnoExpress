using Asp.Versioning;
using GestorDeTurnos.Application.Dtos.Review;
using GestorDeTurnos.Application.Interfaces.Services;
using GestorDeTurnos.Application.Pagination;
using GestorDeTurnos.Application.Specification;
using GestorDeTurnos.Application.Wrappers;
using GestorDeTurnos.Domain.Entities;
using GestorDeTurnos.Persistence.DbContexts;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;

namespace GestorDeTurnos.API.Controllers
{
    [ApiVersion("1.0")]
    [Route("api/v{version:apiVersion}/[controller]")]
    [ApiController]
    [Authorize]
    public class ReviewsController : ControllerBase
    {
        private readonly IReviewService _reviewService;

        public ReviewsController(ApplicationDbContext context, IReviewService reviewService)
        {
            _reviewService = reviewService;
        }

        [HttpGet]
        public async Task<ActionResult<ApiResponse<PagedCollection<ReviewListDto>>>> GetAllReviewsAsync([FromQuery] ReviewFilterAndPaginationDto request)
        {
            var pagedReviews = await _reviewService.GetAllProjectedWithPaginationAsync<ReviewListDto, ReviewSpecification>(request);
            var response = new ApiResponse<PagedCollection<ReviewListDto>>(pagedReviews);
            return Ok(response);
        }

        [HttpGet("{id}")]
        public async Task<ActionResult<ApiResponse<ReviewDetailDto>>> GetReview(int id)
        {
            var data = await _reviewService.GetByIdProjectedAsync<ReviewDetailDto>(id);
            var response = new ApiResponse<ReviewDetailDto?>(data);
            return Ok(response);
        }

        [HttpPut("{id}")]
        public async Task<IActionResult> PutReview(int id, UpdateReviewDto request)
        {
            await _reviewService.UpdateAsync(id, request);
            return NoContent();
        }

        [HttpPost]
        public async Task<ActionResult> PostReview(CreateReviewDto review)
        {
            var newReview = await _reviewService.CreateAsync(review);
            var response = new ApiResponse<Review>(newReview);
            return CreatedAtAction("GetReview", new { id = newReview.Id }, response);
        }

        [HttpDelete("{id}")]
        public async Task<ActionResult> DeleteReview(int id)
        {
            await _reviewService.DeleteAsync(id);
            return NoContent();
        }
    }
}