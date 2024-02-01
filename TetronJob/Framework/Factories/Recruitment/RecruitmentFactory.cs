using Application.Models;
using Application.Reports.Picture;
using Application.Reports.Recruitment;
using Application.Reports.UserAddress;
using Application.Services.Picture;
using Application.Services.Recruitment;
using Domain.Entities;
using Domain.Enums;
using Framework.Common;
using Framework.Common.Application.Core;
using Framework.CQRS.Command.Master.Recruitment;
using Framework.CQRS.Query.Placement;
using Framework.CQRS.Query.Recruitment;
using Mapster;

namespace Framework.Factories.Recruitment
{
    public class RecruitmentFactory : IRecruitmentFactory
    {
        private readonly IRecruitmentReport _report;
        private readonly IRecruitmentService _service;
        private readonly IPictureService _pictureService;
        private readonly IUserAddressReport _addressReport;
        private readonly IPictureReport _pictureReport;

        public RecruitmentFactory(IRecruitmentReport report, IRecruitmentService service, IPictureService pictureService, IUserAddressReport addressReport, IPictureReport pictureReport)
        {
            _report = report;
            _service = service;
            _pictureService = pictureService;
            _addressReport = addressReport;
            _pictureReport = pictureReport;
        }


        public async Task<List<CQRS.Query.Recruitment.Recruitment>> GetRecruitmentsWithFilter(GetRecruitmentWithFilterQuery query)
        {
            var model = await _report.GetRecruitments(query.Filter.CityId, query.Filter.ProvinceId,
                query.Filter.Search);
            List<CQRS.Query.Recruitment.Recruitment> recruitment =
                model.Adapt<List<CQRS.Query.Recruitment.Recruitment>>();
            return recruitment;
        }

        public async Task<Response> InsertRecruitmentAsync(InsertRecruitmentCommand command, CancellationToken cancellation)
        {
            RecruitmentEntity recruitment = command.Adapt<RecruitmentEntity>();
            recruitment.RecruitmentImage = FileProcessing.FileUpload(command.RecruitmentImage, null, "Recruitment");
            var user = await _addressReport.GetUserAddressByIdAsync(command.UserId);
            recruitment.CityId = user!.CityId;
            recruitment.ProvinceId = user!.ProvinceId;
            recruitment.Condition = ConvertEnum.ConvertCondition(command.Condition);
            var result = await _service.InsertAsync(recruitment, cancellation);
            if (result.IsSuccess == false)
            {
                return result;
            }

            if (command.Gallery != null)
            {
                foreach (var item in command.Gallery)
                {
                    PictureEntity picture = new();
                    picture.ParentId = recruitment.Id;
                    picture.Path = FileProcessing.FileUpload(item, null, "Gallery");
                    await _pictureService.InsertAsync(picture);

                }
            }

            return Response.Succeded();
        }

        public async Task<PaginatedList<TCommand>> GetPagedSearchWithSizeAsync<TCommand>(PaginatedSearchWithSize pagination,
            CancellationToken cancellationToken = default)
        {
            return await _report.GetAllPaginatedAsync<TCommand>(pagination, cancellationToken);
        }

        public async Task<Response> UpdateRecruitmentAsync(UpdateRecruitmentCommand command,
            CancellationToken cancellation)
        {
            var model = await _report.GetByIdAsync(command.Id, cancellation);
            model = command.Adapt<RecruitmentEntity>();
            model.RecruitmentImage =
                FileProcessing.FileUpload(command.RecruitmentImageFile,
                    command.RecruitmentImage, "Recruitment");
            model.Condition = ConvertEnum.ConvertCondition(command.Condition);
            if (model.UserId != command.UserId)
            {
                var user = await _addressReport.GetUserAddressByIdAsync(command.UserId!);
                model.CityId = user!.CityId;
                model.ProvinceId = user!.ProvinceId;
            }

            return await _service.UpdateAsync(model, cancellation);
        }

        public async Task<Response> DeleteRecruitmentAsync(DeleteRecruitmentCommand command, CancellationToken cancellation)
        {
            var model = await _report.GetByIdAsync(command.Id, cancellation);
            FileProcessing.RemoveFile(model.RecruitmentImage!, "Recruitment");
            return await _service.DeleteAsync(model, cancellation);
        }

        public async Task<UpdateRecruitmentCommand> GetRecruitmentByIdAsync(GetRecruitmentByIdQuery request, CancellationToken cancellation)
        {
            var model = await _report.GetByIdAsync(request.Id, cancellation);
            UpdateRecruitmentCommand recruitment = model.Adapt<UpdateRecruitmentCommand>();
            return recruitment;
        }


        public async Task Change(Guid id, ConditionEnum condition, CancellationToken cancellation)
        {
            var model = await _report.GetByIdAsync(id, cancellation);
            model.Condition = condition;
            await _service.UpdateAsync(model, cancellation);
        }

        public async Task<RecruitmentDetail> GetRecruitmentDetailByIdAsync(Guid id)
        {

            RecruitmentDetail recruitment = new();
            var model = await _report.GetByIdAsync(id);
            recruitment = model.Adapt<RecruitmentDetail>();
            recruitment.CityName = model.City.Name;
            recruitment.ProvinceName = model.Province.Name;
            recruitment.UserFullName = model.User.FullName;

            var pictures = await _pictureReport.GetByParentIdAsync(id);
            if (pictures != null && pictures.Count > 0)
            {
                foreach (var picture in pictures)
                {
                    recruitment!.Images!.Add(picture.Path!);
                }
            }
            return recruitment;
        }
    }
}
