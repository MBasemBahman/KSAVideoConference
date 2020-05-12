using AutoMapper;
using System;
using System.Collections.Generic;
using System.Text;

namespace KSAVideoConference.Repository.AutoMapper
{
    public class AutoMapping : Profile
    {
        public AutoMapping()
        {
            //CreateMap<SystemUser, SystemUser>()
            //    .ForMember(dest => dest.Id, opt => opt.Ignore())
            //    .ForMember(dest => dest.SystemUserPermissions, opt => opt.Ignore())
            //    .ForMember(dest => dest.CreatedAt, opt => opt.Ignore())
            //    .ForMember(dest => dest.CreatedBy, opt => opt.Ignore());
        }
    }
}
