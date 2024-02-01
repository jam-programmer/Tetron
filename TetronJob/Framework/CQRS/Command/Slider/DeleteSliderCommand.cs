using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Application.Models;
using Framework.Factories.Slider;
using MediatR;

namespace Framework.CQRS.Command.Slider
{
    public class DeleteSliderCommand:IRequest<Response>
    {
        public Guid Id { set; get; }
    }

    public class DeleteSliderCommandHandler : IRequestHandler<DeleteSliderCommand, Response>
    {
        private readonly ISliderFactory _sliderFactory;

        public DeleteSliderCommandHandler(ISliderFactory sliderFactory)
        {
            _sliderFactory = sliderFactory;
        }
        public async Task<Response> Handle(DeleteSliderCommand request, CancellationToken cancellationToken)
        {
            return await _sliderFactory.DeleteSlideAsync(request, cancellationToken);
        }
    }
}
