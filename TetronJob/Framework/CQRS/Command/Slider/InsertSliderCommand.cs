
using Application.Models;
using FluentValidation;
using Framework.Common;
using Framework.Factories.Slider;
using MediatR;
using Microsoft.AspNetCore.Http;

namespace Framework.CQRS.Command.Slider
{
    public class InsertSliderCommand:IRequest<Response>
    {
        public IFormFile SliderImage { set; get; }
        public string? SliderAlt { set; get; }
        public string? SliderLink { set; get; }
        public PositionSliderEnum Position { set; get; }
    }

    public class InsertSliderCommandHandler : IRequestHandler<InsertSliderCommand, Response>
    {
        private readonly ISliderFactory _sliderFactory;

        public InsertSliderCommandHandler(ISliderFactory sliderFactory)
        {
            _sliderFactory = sliderFactory;
        }
        public async Task<Response> Handle(InsertSliderCommand request, CancellationToken cancellationToken)
        {
            return await _sliderFactory.InsertSlideAsync(request, cancellationToken);
        }
    }
    public class InsertSliderValidation:BaseValidator<InsertSliderCommand>
    {
        public InsertSliderValidation()
        {
            RuleFor(f => f.SliderImage).NotNull()
                .WithMessage("تصویر را بارگذاری نمائید.");

            RuleFor(f => f.Position).NotNull().NotEmpty()
                .WithMessage("موقعیت بنر را انتخاب کنید.");

            


        }
    }
}
