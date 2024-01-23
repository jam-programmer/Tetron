using Application.Models;
using Application.Reports.Placement;
using Application.Reports.UserAddress;
using Application.Services.Picture;
using Application.Services.Placement;
using Domain.Entities;
using Domain.Enums;
using Framework.Common.Application.Core;
using Framework.CQRS.Command.Master.Placement;
using Framework.CQRS.Query.Placement;
using Mapster;

namespace Framework.Factories.Placement
{
    public class PlacementFactory: IPlacementFactory
    {
        private readonly IUserAddressReport _addressReport;
        private readonly IPlacementService _placementService;
        private readonly IPictureService _pictureService;
        private readonly IPlacementReport _placementReport;

        public PlacementFactory(IUserAddressReport addressReport, IPlacementService placementService, IPictureService pictureService, IPlacementReport placementReport)
        {
            _addressReport = addressReport;
            _placementService = placementService;
            _pictureService = pictureService;
            _placementReport = placementReport;
        }

        public async Task<List<CQRS.Query.Placement.Placement>> GetPlacementsWithFilter(GetPlacementWithFilterQuery query)
        {
            var model = await _placementReport.GetPlacements(query.Filter.CityId, query.Filter.ProvinceId,
                query.Filter.Search);
            List<CQRS.Query.Placement.Placement> placements =
                model.Adapt<List<CQRS.Query.Placement.Placement>>();
            return placements;
        }

        public async Task<Response> InsertPlacementAsync(InsertPlacementCommand command,CancellationToken cancellation)
        {
            PlacementEntity placement = command.Adapt<PlacementEntity>();
            placement.PlacementImage = FileProcessing.FileUpload(command.PlacementImage, null, "Placement");
            var user = await _addressReport.GetUserAddressByIdAsync(command.UserId!.Value);
            placement.CityId = user!.CityId;
            placement.ProvinceId = user!.ProvinceId;
            placement.Condition = ConditionEnum.Waiting;
            var result = await _placementService.InsertAsync(placement,cancellation);
            if (result.IsSuccess == false)
            {
                return result;
            }

            if (command.Gallery != null)
            {
                foreach (var item in command.Gallery)
                {
                    PictureEntity picture = new();
                    picture.ParentId = placement.Id;
                    picture.Path = FileProcessing.FileUpload(item, null, "Gallery");
                    await _pictureService.InsertAsync(picture);

                }
            }

            return Response.Succeded();
        }
    }
}
