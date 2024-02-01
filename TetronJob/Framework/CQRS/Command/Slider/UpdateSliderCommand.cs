using MediatR;
using Application.Models;
using Framework.Common;
using Microsoft.AspNetCore.Http;
using FluentValidation;
using Framework.Factories.Slider;

namespace Framework.CQRS.Command.Slider
{
    public class UpdateSliderCommand : IRequest<Response>
    {
        public Guid Id { set; get; }
        public IFormFile? SliderImageFile { set; get; }
        public string SliderImage { set; get; }
        public string? SliderAlt { set; get; }
        public string? SliderLink { set; get; }
        public PositionSliderEnum Position { set; get; }
    }

    public class UpdateSliderCommandHandler : IRequestHandler<UpdateSliderCommand, Response>
    {
        private readonly ISliderFactory _sliderFactory;

        public UpdateSliderCommandHandler(ISliderFactory sliderFactory)
        {
            _sliderFactory = sliderFactory;
        }
        public async Task<Response> Handle(UpdateSliderCommand request, CancellationToken cancellationToken)
        {
            return await _sliderFactory.UpdateSlideAsync(request, cancellationToken);
        }
    }
    public class UpdateSliderValidation : BaseValidator<UpdateSliderCommand>
    {
        public UpdateSliderValidation()
        {
           

            RuleFor(f => f.Position).NotNull().NotEmpty()
                .WithMessage("موقعیت بنر را انتخاب کنید.");
        }
    }
}
