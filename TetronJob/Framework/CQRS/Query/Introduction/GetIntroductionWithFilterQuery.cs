using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Framework.Factories.Introduction;
using MediatR;

namespace Framework.CQRS.Query.Introduction
{
    public class GetIntroductionWithFilterQuery:IRequest<List<Introduction>>
    {
        public Filter Filter { set; get; }
    }

    public class GetIntroductionWithFilterQueryHandler :
        IRequestHandler<GetIntroductionWithFilterQuery, List<Introduction>>
    {
        private readonly IIntroductionFactory _introductionFactory;

        public GetIntroductionWithFilterQueryHandler(IIntroductionFactory introductionFactory)
        {
            _introductionFactory = introductionFactory;
        }
        public async Task<List<Introduction>> Handle(GetIntroductionWithFilterQuery request, CancellationToken cancellationToken)
        {
            return await _introductionFactory.GetIntroductionsWithFilter(request);
        }
    }
    
    public class Introduction
    {
        public string? IntroductionImage { set; get; }
        public Guid? Id { set; get; }
       
        public string? IntroductionPhoneNumber { set; get; }
        public string? IntroductionTitle { set; get; }
    }
    public class Filter
    {
        public Guid? ProvinceId { get; set; }
        public Guid? CityId { get; set; }
        public string? @Search { get; set; }
    }
}
