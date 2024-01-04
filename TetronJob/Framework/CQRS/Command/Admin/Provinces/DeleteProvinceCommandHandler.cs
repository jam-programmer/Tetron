using Application.Models;
using Framework.Factories.Province;

using Framework.ViewModels.Province;
using MediatR;

namespace Framework.CQRS.Command.Admin.Provinces
{
    public class DeleteProvinceCommandHandler : IRequestHandler<DeleteProvinceViewModel, Response>
    {
        private readonly IProvincesFactory _provincesFactory;

        public DeleteProvinceCommandHandler(IProvincesFactory provincesFactory)
        {
            _provincesFactory = provincesFactory;
        }
        public async Task<Response> Handle(DeleteProvinceViewModel request, CancellationToken cancellationToken)
        {
            return await _provincesFactory.DeleteProvinceAsync(request, cancellationToken);
        }
    }
}
