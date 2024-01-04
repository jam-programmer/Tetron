using Application.Models;
using Framework.Factories.Province;

using Framework.ViewModels.Province;
using MediatR;

namespace Framework.CQRS.Command.Admin.Provinces
{
    public class UpdateProvinceCommandHandler : IRequestHandler<UpdateProvinceViewModel, Response>
    {
        private readonly IProvincesFactory _provincesFactory;

        public UpdateProvinceCommandHandler(IProvincesFactory provincesFactory)
        {
            _provincesFactory = provincesFactory;
        }
        public async Task<Response> Handle(UpdateProvinceViewModel request, CancellationToken cancellationToken)
        {
            return await _provincesFactory.UpdateProvinceAsync(request, cancellationToken);
        }
    }
}
