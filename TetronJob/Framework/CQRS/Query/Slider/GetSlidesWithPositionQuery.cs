using Domain.Enums;
using Framework.Factories.Slider;
using MediatR;

namespace Framework.CQRS.Query.Slider
{
    public class GetSlidesWithPositionQuery:IRequest<List<Image>>
    {
        public PositionEnum Position { set; get; }
    }

    public class GetSlidesWithPositionQueryHandler : IRequestHandler<GetSlidesWithPositionQuery, List<Image>>
    {
        private readonly ISliderFactory _sliderFactory;

        public GetSlidesWithPositionQueryHandler(ISliderFactory sliderFactory)
        {
            _sliderFactory = sliderFactory;
        }
        public async Task<List<Image>> Handle(GetSlidesWithPositionQuery request, CancellationToken cancellationToken)
        {
            return await _sliderFactory.GetImagesAsync(request.Position);
        }
    }
    public class Image
    {
        public string? SliderImagePath { set; get; }
        public string? SliderAlt { set; get; }
        public string? SliderLink { set; get; }
        public Guid? Id { set; get; }
    }
}
