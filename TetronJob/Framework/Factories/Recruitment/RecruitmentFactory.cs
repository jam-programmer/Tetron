using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Application.Models;
using Application.Reports.User;
using Application.Reports.UserAddress;
using Application.Services.Picture;
using Application.Services.Recruitment;
using Domain.Entities;
using Domain.Enums;
using Framework.Common.Application.Core;
using Framework.CQRS.Command.Master.Recruitment;
using Mapster;

namespace Framework.Factories.Recruitment
{
    public class RecruitmentFactory: IRecruitmentFactory
    {
        private readonly IRecruitmentService _service;
        private readonly IPictureService _pictureService;
        private readonly IUserAddressReport _addressReport;

        public RecruitmentFactory(IRecruitmentService service, IPictureService pictureService, IUserAddressReport addressReport)
        {
            _service = service;
            _pictureService = pictureService;
            _addressReport = addressReport;
        }

        public async Task<Response> InsertRecruitmentAsync(InsertRecruitmentCommand command, CancellationToken cancellation)
        {
            RecruitmentEntity recruitment =  command.Adapt<RecruitmentEntity>();
            recruitment.RecruitmentImage = FileProcessing.FileUpload(command.RecruitmentImage, null, "Recruitment");
            var user = await _addressReport.GetUserAddressByIdAsync(command.UserId);
            recruitment.CityId = user!.CityId;
            recruitment.ProvinceId=user!.ProvinceId;
            recruitment.Condition = ConditionEnum.Waiting;
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
    }
}
