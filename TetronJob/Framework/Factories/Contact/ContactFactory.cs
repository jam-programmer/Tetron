using Application.Models;
using Application.Reports.Contact;
using Application.Services.Contact;
using Domain.Entities;
using Framework.CQRS.Command.Contact;
using Mapster;

namespace Framework.Factories.Contact
{
    public class ContactFactory : IContactFactory
    {
        private readonly IContactReport _report;
        private readonly IContactService _service;

        public ContactFactory(IContactReport report, IContactService service)
        {
            _report = report;
            _service = service;
        }

        public async Task<PaginatedList<TViewModel>> GetPagedSearchWithSizeAsync<TViewModel>(PaginatedSearchWithSize pagination,
            CancellationToken cancellationToken = default)
        {
            return await _report.GetAllPaginatedAsync<TViewModel>(pagination, cancellationToken);
        }

        public async Task<Response> InsertMessageAsync(InsertContactCommand command)
        {
            ContactUsEntity contact = new ContactUsEntity();
            contact = command.Adapt<ContactUsEntity>();
            return await _service.InsertAsync(contact);
        }
    }
}
