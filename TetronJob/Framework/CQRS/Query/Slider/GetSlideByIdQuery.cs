using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Framework.CQRS.Command.Slider;
using Framework.Factories.Slider;
using MediatR;

namespace Framework.CQRS.Query.Slider
{
    public class GetSlideByIdQuery:IRequest<UpdateSliderCommand>
    {
        public Guid Id { get; set; }
    }

    public class GetSlideByIdQueryHandler : IRequestHandler<GetSlideByIdQuery, UpdateSliderCommand>
    {
        private readonly ISliderFactory _sliderFactory;

        public GetSlideByIdQueryHandler(ISliderFactory sliderFactory)
        {
            _sliderFactory = sliderFactory;
        }
        public async Task<UpdateSliderCommand> Handle(GetSlideByIdQuery request, CancellationToken cancellationToken)
        {
            return await _sliderFactory.GetSlideByIdAsync(request, cancellationToken);
        }
    }
}
