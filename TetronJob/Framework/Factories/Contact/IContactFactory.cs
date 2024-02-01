using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Application.Models;
using Framework.CQRS.Command.Contact;

namespace Framework.Factories.Contact
{
    public interface IContactFactory
    {
        Task<Response> InsertMessageAsync(InsertContactCommand command);
    }
}
