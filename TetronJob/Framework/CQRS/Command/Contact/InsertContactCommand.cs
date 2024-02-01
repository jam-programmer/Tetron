using Application.Models;
using Application.Reports.Contact;
using Framework.Factories.Contact;
using MediatR;

namespace Framework.CQRS.Command.Contact
{
    public class InsertContactCommand:IRequest<Response>
    {
        public string? FullName { set; get; }
        public string? Title { set; get; }
        public string? PhoneNumber { set; get; }
        public string? Message { set; get; }
    }

    public class InsertContactCommandHandler : IRequestHandler<InsertContactCommand, Response>
    {
        private readonly IContactFactory _contactFactory;

        public InsertContactCommandHandler(IContactFactory contactFactory)
        {
            _contactFactory = contactFactory;
        }
        public async Task<Response> Handle(InsertContactCommand request, CancellationToken cancellationToken)
        {
            return await _contactFactory.InsertMessageAsync(request);
        }
    }
}
