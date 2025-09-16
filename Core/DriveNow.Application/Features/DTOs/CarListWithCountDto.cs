using DriveNow.Application.Features.Mediator.Results.CarPricingResults;

namespace DriveNow.Application.Features.DTOs
{
    public class CarListWithCountDto
    {
        public List<GetPublishedCarPricingWithCarQueryResult> Cars { get; set; }
        public int TotalCount { get; set; }
    }
}