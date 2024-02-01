using Application.Models;
using Application.Reports.Slider;
using Application.Services.Slider;
using Domain.Entities;
using Domain.Enums;
using Framework.Common;
using Framework.Common.Application.Core;
using Framework.CQRS.Command.Slider;
using Framework.CQRS.Query.Slider;
using Mapster;

namespace Framework.Factories.Slider
{
    public class SliderFactory : ISliderFactory
    {
        private readonly ISliderService _service;
        private readonly ISliderReport _report;

        public SliderFactory(ISliderService service, ISliderReport report)
        {
            _service = service;
            _report = report;
        }
        public async Task<PaginatedList<TViewModel>> GetPagedSearchWithSizeAsync<TViewModel>(PaginatedWithSize pagination,
            CancellationToken cancellationToken = default)
        {
            return await _report.GetAllPaginatedAsync<TViewModel>(pagination, cancellationToken);
        }

        public async Task<Response> InsertSlideAsync(InsertSliderCommand command, CancellationToken cancellation)
        {
            SliderEntity slider = new SliderEntity();
            slider.Position = ConvertEnum.ConvertPosition(command.Position);
            slider.SliderAlt = command.SliderAlt;
            slider.SliderLink = command.SliderLink;
            slider.SliderImagePath = FileProcessing.FileUpload(command.SliderImage, null, "Slider");
            var response = await _service.InsertAsync(slider, cancellation);
            return response;
        }

        public async Task<Response> UpdateSlideAsync(UpdateSliderCommand command, CancellationToken cancellation)
        {
            var slider = await _report.GetByIdAsync(command.Id, cancellation);
            slider.SliderImagePath = FileProcessing.FileUpload(command.SliderImageFile, command.SliderImage, "Slider");
            slider.Position = ConvertEnum.ConvertPosition(command.Position);
            slider.SliderAlt = command.SliderAlt;
            slider.SliderLink = command.SliderLink;
            if (command.SliderImageFile != null)
            {
                FileProcessing.RemoveFile(command.SliderImage, "Slider");
            }
        
            var response = await _service.UpdateAsync(slider, cancellation);
            return response;
        }

        public async Task<Response> DeleteSlideAsync(DeleteSliderCommand command, CancellationToken cancellation)
        {
            var slider = await _report.GetByIdAsync(command.Id, cancellation);
            FileProcessing.RemoveFile(slider.SliderImagePath, "Slider");
            var response = await _service.DeleteAsync(slider, cancellation);
            return response;
        }

        public async Task<UpdateSliderCommand> GetSlideByIdAsync(GetSlideByIdQuery request, CancellationToken cancellation)
        {
            var slider = await _report.GetByIdAsync(request.Id, cancellation);
            UpdateSliderCommand update = new UpdateSliderCommand();
            update.SliderAlt = slider.SliderAlt;
            update.SliderLink = slider.SliderLink;
            update.SliderImage = slider.SliderImagePath;
            update.Id = slider.Id;
            update.Position = ConvertEnum.ConvertPositionSlider(slider.Position);
            return update;
        }

        public async Task<List<Image>> GetImagesAsync(PositionEnum position)
        {
           var model= await _report.GetWithPositionAsync(position);
           List<Image> images = model.Adapt<List<Image>>();
           return images;
        }
    }
}
