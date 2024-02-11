using Application.Models;
using Framework.CQRS.Query.Article;
using Framework.Factories.Contact;
using MediatR;

namespace Framework.CQRS.Query.Contact
{
    public class GetContactsQuery : IRequest<PaginatedList<Contact>>
    {
        public PaginatedSearchWithSize? Paginated { set; get; }
    }

    public class GetContactsQueryHandler : IRequestHandler<GetContactsQuery, PaginatedList<Contact>>
    {
        private readonly IContactFactory _contactFactory;

        public GetContactsQueryHandler(IContactFactory contactFactory)
        {
            _contactFactory = contactFactory;
        }
        public async Task<PaginatedList<Contact>> Handle(GetContactsQuery request, CancellationToken cancellationToken)
        {
            return await _contactFactory.GetPagedSearchWithSizeAsync<Contact>(request.Paginated!, cancellationToken);
        }
    }

    public class Contact
    {
        public Guid Id { set; get; }
        public string? FullName { set; get; }
        public string? Title { set; get; }
        public string? PhoneNumber { set; get; }
        public string? Message { set; get; }
    }
}
