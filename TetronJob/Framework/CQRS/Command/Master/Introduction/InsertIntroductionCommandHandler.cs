using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Application.Models;
using Framework.Factories.Introduction;
using MediatR;
using Microsoft.AspNetCore.Http;

namespace Framework.CQRS.Command.Master.Introduction
{
    public class InsertIntroductionCommandHandler:IRequestHandler<InsertIntroductionCommand,Response>
    {
        private readonly IIntroductionFactory _introductionFactory;

        public InsertIntroductionCommandHandler(IIntroductionFactory introductionFactory)
        {
            _introductionFactory = introductionFactory;
        }
        public async Task<Response> Handle(InsertIntroductionCommand request, CancellationToken cancellationToken)
        {
            return await _introductionFactory.InsertIntroductionAsync(request, cancellationToken);
        }
    } public class InsertIntroductionCommand:IRequest<Response>
    {
        public List<IFormFile>? Gallery { set; get; } = new();
        public Guid UserId { set; get; }
        public string? IntroductionPhoneNumber { set; get; }
        public string? IntroductionTitle { set; get; }
        public IFormFile? IntroductionImage { set; get; }
        public string? IntroductionDescription { set; get; }
       

        public List<Guid> Skills { set; get; } = new List<Guid>();

    }
}
