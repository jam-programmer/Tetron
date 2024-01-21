using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Application.Models;
using Application.Reports.Skill;
using Application.Reports.UserAddress;
using Application.Services.Introduction;
using Application.Services.Picture;
using Application.Services.Placement;
using Application.Services.SkillIntroduction;
using Domain.Entities;
using Domain.Enums;
using Framework.Common.Application.Core;
using Framework.CQRS.Command.Master.Introduction;
using Mapster;

namespace Framework.Factories.Introduction
{
    public class IntroductionFactory: IIntroductionFactory
    {
        private readonly IUserAddressReport _addressReport;
        private readonly IIntroductionService _introductionService;
        private readonly IPictureService _pictureService;
        private readonly ISkillIntroductionService _introductionSkillService;
        private readonly ISkillReport _skillReport;

        public IntroductionFactory(IUserAddressReport addressReport, IIntroductionService introductionService, IPictureService pictureService, ISkillIntroductionService introductionSkillService, ISkillReport skillReport)
        {
            _addressReport = addressReport;
            _introductionService = introductionService;
            _pictureService = pictureService;
            _introductionSkillService = introductionSkillService;
            _skillReport = skillReport;
        }
        public async Task<Response> InsertIntroductionAsync(InsertIntroductionCommand command, CancellationToken cancellationToken)
        {
            IntroductionEntity introduction = command.Adapt<IntroductionEntity>();
            var user = await _addressReport.GetUserAddressByIdAsync(command.UserId!);
            introduction.CityId = user!.CityId;
            introduction.ProvinceId = user!.ProvinceId;
            introduction.Condition = ConditionEnum.Waiting;
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
                skillIntroduction.IntroductionId= introduction.Id;
                skillIntroduction.SkillId = item;
                await _introductionSkillService.InsertAsync(skillIntroduction);
            }
            return Response.Succeded();
        }
    }
}
