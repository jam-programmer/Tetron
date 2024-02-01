using Application.Models;
using Application.Reports.Picture;
using Application.Reports.Placement;
using Application.Reports.UserAddress;
using Application.Services.Picture;
using Application.Services.Placement;
using Domain.Entities;
using Domain.Enums;
using Framework.Common;
using Framework.Common.Application.Core;
using Framework.CQRS.Command.Master.Placement;
using Framework.CQRS.Query.Introduction;
using Framework.CQRS.Query.Placement;
using Mapster;

namespace Framework.Factories.Placement
{
    public class PlacementFactory : IPlacementFactory
    {
        private readonly IUserAddressReport _addressReport;
        private readonly IPlacementService _placementService;
        private readonly IPictureService _pictureService;
        private readonly IPlacementReport _placementReport;
        private readonly IPictureReport _pictureReport;

        public PlacementFactory(IUserAddressReport addressReport, IPlacementService placementService, IPictureService pictureService, IPlacementReport placementReport, IPictureReport pictureReport)
        {
            _addressReport = addressReport;
            _placementService = placementService;
            _pictureService = pictureService;
            _placementReport = placementReport;
            _pictureReport = pictureReport;
        }
        public async Task<List<CQRS.Query.Placement.Placement>> GetPlacementsWithFilter(GetPlacementWithFilterQuery query)
        {
            var model = await _placementReport.GetPlacements(query.Filter.CityId, query.Filter.ProvinceId,
                query.Filter.Search);
            List<CQRS.Query.Placement.Placement> placements =
                model.Adapt<List<CQRS.Query.Placement.Placement>>();
            return placements;
        }

        public async Task<Response> InsertPlacementAsync(InsertPlacementCommand command, CancellationToken cancellation)
        {
            PlacementEntity placement = command.Adapt<PlacementEntity>();
            placement.PlacementImage = FileProcessing.FileUpload(command.PlacementImage,
                null, "Placement");
            var user = await _addressReport.GetUserAddressByIdAsync(command.UserId!.Value);
            placement.CityId = user!.CityId;
            placement.ProvinceId = user!.ProvinceId;
            placement.Condition = ConvertEnum.ConvertCondition(command.Condition);
            var result = await _placementService.InsertAsync(placement, cancellation);
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

        public async Task<PaginatedList<TCommand>> GetPagedSearchWithSizeAsync<TCommand>(PaginatedSearchWithSize pagination,
            CancellationToken cancellationToken = default)
        {
            return await _placementReport.GetAllPaginatedAsync<TCommand>(pagination, cancellationToken);
        }

        public async Task<Response> UpdatePlacementAsync(UpdatePlacementCommand command, CancellationToken cancellation)
        {
            var model = await _placementReport.GetByIdAsync(command.Id, cancellation);
            model = command.Adapt<PlacementEntity>(); model.Condition = ConvertEnum.ConvertCondition(command.Condition);
            model.PlacementImage =
                    FileProcessing.FileUpload(command.PlacementImageFile, command.PlacementImage, "Placement");
            if (model.UserId != command.UserId)
            {
                var user = await _addressReport.GetUserAddressByIdAsync(command.UserId!.Value);
                model.CityId = user!.CityId;
                model.ProvinceId = user!.ProvinceId;
            }

            return await _placementService.UpdateAsync(model, cancellation);
        }

        public async Task<Response> DeletePlacementAsync(DeletePlacementCommand command, CancellationToken cancellation)
        {
            var model = await _placementReport.GetByIdAsync(command.Id, cancellation);
            FileProcessing.RemoveFile(model.PlacementImage!, "Placement");
            return await _placementService.DeleteAsync(model, cancellation);
        }

        public async Task<UpdatePlacementCommand> GetPlacementByIdAsync(GetPlacementByIdQuery request, CancellationToken cancellation)
        {
            var model = await _placementReport.GetByIdAsync(request.Id, cancellation);
            UpdatePlacementCommand command = model.Adapt<UpdatePlacementCommand>();
            return command;
        }


        public async Task Change(Guid id, ConditionEnum condition, CancellationToken cancellation)
        {
            var model = await _placementReport.GetByIdAsync(id, cancellation);
            model.Condition = condition;
            await _placementService.UpdateAsync(model, cancellation);
        }

        public async Task<PlacementDetail> GetPlacementDetailByIdAsync(Guid id)
        {
            PlacementDetail placement = new();
            var model = await _placementReport.GetByIdAsync(id);
            placement = model.Adapt<PlacementDetail>();
            placement.CityName = model.City.Name;
            placement.ProvinceName = model.Province.Name;
            placement.UserFullName = model.User.FullName;

            var pictures = await _pictureReport.GetByParentIdAsync(id);
            if (pictures != null && pictures.Count > 0)
            {
                foreach (var picture in pictures)
                {
                    placement!.Images!.Add(picture.Path!);
                }
            }
            return placement;
        }
    }
}
