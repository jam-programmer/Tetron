using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Domain.Entities;
using Framework.ViewModels.User;
using Mapster;

namespace Framework.Mapping.User
{
    public static class UserMap
    {
        public static TypeAdapterConfig ConfigUpdate (){
            var config=new TypeAdapterConfig();

            config.NewConfig<UserEntity,UpdateUserViewModel>()
                .Map(v=>v.UserName,e=>e.UserName)
                .Map(v=>v.FullName,e=>e.FullName)
                .Map(v=>v.PhoneNumber,e=>e.PhoneNumber)
                .Map(v=>v.Email,e=>e.Email)
                .Map(v=>v.Birthday,e=>e.Birthday)
                

                .Compile();


            return config;
        }
    }
}
