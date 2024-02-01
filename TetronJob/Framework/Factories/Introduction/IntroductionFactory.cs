using Application.Models;
using Application.Reports.Introduction;
using Application.Reports.Skill;
using Application.Reports.SkillIntroduction;
using Application.Reports.UserAddress;
using Application.Services.Introduction;
using Application.Services.Picture;
using Application.Services.SkillIntroduction;
using Domain.Entities;
using Domain.Enums;
using Framework.Common;
using Framework.Common.Application.Core;
using Framework.CQRS.Command.Master.Introduction;
using Framework.CQRS.Query.Introduction;
using Mapster;
using static Microsoft.EntityFrameworkCore.DbLoggerCategory.Database;

namespace Framework.Factories.Introduction
{
    public class IntroductionFactory : IIntroductionFactory
    {
        private readonly IIntroductionReport _introductionReport;
        private readonly IUserAddressReport _addressReport;
        private readonly IIntroductionService _introductionService;
        private readonly IPictureService _pictureService;
        private readonly ISkillIntroductionService _introductionSkillService;
        private readonly ISkillReport _skillReport;

        private readonly ISkillIntroductionReport _skillIntroductionReport;

        public IntroductionFactory(IIntroductionReport introductionReport, IUserAddressReport addressReport, IIntroductionService introductionService, IPictureService pictureService, ISkillIntroductionService introductionSkillService, ISkillReport skillReport, ISkillIntroductionReport skillIntroductionReport)
        {
            _introductionReport = introductionReport;
            _addressReport = addressReport;
            _introductionService = introductionService;
            _pictureService = pictureService;
            _introductionSkillService = introductionSkillService;
            _skillReport = skillReport;
            _skillIntroductionReport = skillIntroductionReport;
        }


        public async Task<Response> InsertIntroductionAsync(InsertIntroductionCommand command, CancellationToken cancellationToken)
        {
            IntroductionEntity introduction = command.Adapt<IntroductionEntity>();
            var user = await _addressReport.GetUserAddressByIdAsync(command.UserId!);
            introduction.CityId = user!.CityId;
            introduction.ProvinceId = user!.ProvinceId;
            introduction.IntroductionImage = FileProcessing.FileUpload(
                command.IntroductionImage, null, "Introduction");
            introduction.Condition = ConvertEnum.ConvertCondition(command.Condition);
            var result = await _introductionService.InsertAsync(introduction, cancellationToken);
            if (result.IsSuccess == false)
            {
                return result;
            }

            if (command.Gallery != null)
            {
                foreach (var item in command.Gallery)
                {
                    PictureEntity picture = new();
                    picture.ParentId = introduction.Id;
                    picture.Path = FileProcessing.FileUpload(item, null, "Gallery");
                    await _pictureService.InsertAsync(picture);

                }
            }

            foreach (var item in command.Skills)
            {

                SkillIntroductionEntity skillIntroduction = new();
                skillIntroduction.IntroductionId = introduction.Id;
                skillIntroduction.SkillId = item;
                await _introductionSkillService.InsertAsync(skillIntroduction);
            }
            return Response.Succeded();
        }

        public async Task<List<CQRS.Query.Introduction.Introduction>>
            GetIntroductionsWithFilter(GetIntroductionWithFilterQuery query)
        {
            var model = await _introductionReport.GetIntroductions(query.Filter.CityId, query.Filter.ProvinceId,
                query.Filter.Search);
            List<CQRS.Query.Introduction.Introduction> introductions =
                model.Adapt<List<CQRS.Query.Introduction.Introduction>>();
            return introductions;
        }

        public async Task<PaginatedList<TCommand>> GetPagedSearchWithSizeAsync<TCommand>(PaginatedSearchWithSize pagination, CancellationToken cancellationToken = default)
        {
            return await _introductionReport.GetAllPaginatedAsync<TCommand>(pagination, cancellationToken);
        }

        public async Task<Response> UpdateIntroductionAsync(UpdateIntroductionCommand Command, CancellationToken cancellation)
        {
            var introduction = await _introductionReport.GetByIdAsync(Command.Id, cancellation);
            introduction = Command.Adapt<IntroductionEntity>();
            if (introduction.UserId != Command.UserId)
            {
                var user = await _addressReport.GetUserAddressByIdAsync(Command.UserId!);
                introduction.CityId = user!.CityId;
                introduction.ProvinceId = user!.ProvinceId;
            }
            introduction.IntroductionImage = FileProcessing
                .FileUpload(Command.IntroductionImageFile, Command.IntroductionImage, "Introduction");

            introduction.Condition = ConvertEnum.ConvertCondition(Command.Condition);
            var skills = await _skillIntroductionReport.GetSkillsByIntroductionIdAsync(Command.Id);
            if (skills != null)
            {
                await _introductionSkillService.DeleteAsync(skills);
                List<SkillIntroductionEntity> skillIntroduction = new();
                foreach (var item in Command.Skills)
                {
                    skillIntroduction.Add(new SkillIntroductionEntity
                    {
                        SkillId = item,
                        IntroductionId = Command.Id
                    });
                }

                await _introductionSkillService.InsertAsync(skillIntroduction);
            }
            return await _introductionService.UpdateAsync(introduction, cancellation);

        }

        public async Task<Response> DeleteIntroductionAsync(DeleteIntroductionCommand Command, CancellationToken cancellation)
        {
            var introduction = await _introductionReport.GetByIdAsync(Command.Id, cancellation);
            FileProcessing.RemoveFile(introduction.IntroductionImage!, "Introduction");
            var deleteIntroduction = await _introductionService.DeleteAsync(introduction, cancellation);


            var skills =
                await _skillIntroductionReport.GetSkillsByIntroductionIdAsync(Command.Id);
            if (skills != null)
            {

                await _introductionSkillService.DeleteAsync(skills);
            }

            return deleteIntroduction;
        }

        public async Task<UpdateIntroductionCommand> GetIntroductionByIdAsync(GetIntroductionByIdQuery request, CancellationToken cancellation)
        {
            var introduction = await _introductionReport.GetByIdAsync(request.Id, cancellation);
            UpdateIntroductionCommand command = introduction.Adapt<UpdateIntroductionCommand>();
            var skills = await _skillIntroductionReport.GetSkillsOfIntroductionAsync(request.Id);
            command.Skills = skills;
            return command;
        }

        public async Task Change(Guid id, ConditionEnum condition, CancellationToken cancellation)
        {
            var model = await _introductionReport.GetByIdAsync(id,cancellation);
            model.Condition= condition;
          var res=  await _introductionService.UpdateAsync(model,cancellation);
        }
    }
}
