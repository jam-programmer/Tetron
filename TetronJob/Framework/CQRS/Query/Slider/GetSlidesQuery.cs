using Application.Models;
using Framework.Factories.Slider;
using MediatR;

namespace Framework.CQRS.Query.Slider
{
    public class GetSlidesQuery : IRequest<PaginatedList<ImageViewModel>>
    {
        public PaginatedWithSize? Paginated { set; get; }
    }


    public class GetSlidesQueryHandler : IRequestHandler<GetSlidesQuery, PaginatedList<ImageViewModel>>
    {
        private readonly ISliderFactory _sliderFactory;

        public GetSlidesQueryHandler(ISliderFactory sliderFactory)
        {
            _sliderFactory = sliderFactory;
        }
        public async Task<PaginatedList<ImageViewModel>> Handle(GetSlidesQuery request, CancellationToken cancellationToken)
        {
            return await _sliderFactory.GetPagedSearchWithSizeAsync<ImageViewModel>(request.Paginated,
                cancellationToken);
        }
    }


    public class ImageViewModel
    {
        public Guid Id { get; set; }
        public string SliderImagePath { set; get; }
        public string SliderAlt { set; get; }
    }
}
