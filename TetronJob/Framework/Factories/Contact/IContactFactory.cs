using Application.Models;
using Framework.CQRS.Command.Contact;

namespace Framework.Factories.Contact
{
    public interface IContactFactory
    {
        Task<PaginatedList<TViewModel>> GetPagedSearchWithSizeAsync<TViewModel>
        (PaginatedSearchWithSize pagination,
            CancellationToken cancellationToken = default);
        Task<Response> InsertMessageAsync(InsertContactCommand command);
    }
}
