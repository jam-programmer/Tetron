using Application.Models;
using Domain.Enums;
using Framework.CQRS.Command.Slider;
using Framework.CQRS.Query.Slider;

namespace Framework.Factories.Slider
{
    public interface ISliderFactory
    {
        Task<PaginatedList<TViewModel>> GetPagedSearchWithSizeAsync<TViewModel>
        (PaginatedWithSize pagination,
            CancellationToken cancellationToken = default);

        Task<Response> InsertSlideAsync(InsertSliderCommand command, CancellationToken cancellation);
        Task<Response> UpdateSlideAsync(UpdateSliderCommand command, CancellationToken cancellation);
        Task<Response> DeleteSlideAsync(DeleteSliderCommand command, CancellationToken cancellation);
        Task<UpdateSliderCommand> GetSlideByIdAsync(GetSlideByIdQuery request, CancellationToken cancellation);

        Task<List<Image>> GetImagesAsync(PositionEnum position);
    }
}
