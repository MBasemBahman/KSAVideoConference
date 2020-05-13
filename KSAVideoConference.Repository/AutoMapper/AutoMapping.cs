using AutoMapper;
using KSAVideoConference.Entity.AppModel;
using KSAVideoConference.ServiceModel.AppModel;
using System;
using System.Globalization;

namespace KSAVideoConference.Repository.AutoMapper
{
    public class AutoMapping : Profile
    {
        public AutoMapping()
        {
            //////////////////// App Model ///////////////////////////
            CreateMap<User, User>()
                .ForMember(dest => dest.Id, opt => opt.Ignore())
                .ForMember(dest => dest.Token, opt => opt.Ignore())
                .ForMember(dest => dest.ImageURL, opt => opt.Ignore())
                .ForMember(dest => dest.Language, opt => opt.Ignore())
                .ForMember(dest => dest.Groups, opt => opt.Ignore())
                .ForMember(dest => dest.GroupMembers, opt => opt.Ignore())
                .ForMember(dest => dest.GroupMessages, opt => opt.Ignore())
                .ForMember(dest => dest.MyUserContacts, opt => opt.Ignore())
                .ForMember(dest => dest.MeInUserContacts, opt => opt.Ignore())
                .ForMember(dest => dest.CreatedAt, opt => opt.Ignore())
                .ForMember(dest => dest.CreatedBy, opt => opt.Ignore());

            //////////////////// Service Model ///////////////////////////

            // MemberType
            CreateMap<MemberType, MemberTypeModel>()
               .ForMember(dest => dest.Id, opt => opt.Ignore())
               .ForMember(dest => dest.GroupMembers, opt => opt.Ignore())
               .ForMember(dest => dest.CreatedAt, opt => opt.Ignore());

            // AttachmentType
            CreateMap<AttachmentType, AttachmentTypeModel>()
               .ForMember(dest => dest.Id, opt => opt.Ignore())
               .ForMember(dest => dest.Attachments, opt => opt.Ignore())
               .ForMember(dest => dest.CreatedAt, opt => opt.Ignore());

            // User
            CreateMap<User, UserModel>()
                .ForMember(dest => dest.Language, opt => opt.Ignore())
                .ForMember(dest => dest.Groups, opt => opt.Ignore())
                .ForMember(dest => dest.GroupMembers, opt => opt.Ignore())
                .ForMember(dest => dest.GroupMessages, opt => opt.Ignore())
                .ForMember(dest => dest.MyUserContacts, opt => opt.Ignore())
                .ForMember(dest => dest.MeInUserContacts, opt => opt.Ignore());

            CreateMap<IUserModel, User>()
                .ForMember(dest => dest.Id, opt => opt.Ignore());

            //Group
            CreateMap<Group, GroupModel>()
                .ForMember(dest => dest.Creator, opt => opt.Ignore())
                .ForMember(dest => dest.GroupMembers, opt => opt.Ignore())
                .ForMember(dest => dest.GroupMessages, opt => opt.Ignore());

            CreateMap<IGroupModel, Group>()
                .ForMember(dest => dest.Id, opt => opt.Ignore());

            //GroupMember
            CreateMap<GroupMember, GroupMemberModel>()
                .ForMember(dest => dest.User, opt => opt.Ignore())
                .ForMember(dest => dest.Group, opt => opt.Ignore())
                .ForMember(dest => dest.MemberType, opt => opt.Ignore());

            CreateMap<IGroupMemberModel, GroupMember>()
                .ForMember(dest => dest.Id, opt => opt.Ignore());

            //GroupMessage
            CreateMap<GroupMessage, GroupMessageModel>()
                .ForMember(dest => dest.User, opt => opt.Ignore())
                .ForMember(dest => dest.Group, opt => opt.Ignore())
                .ForMember(dest => dest.Attachment, opt => opt.Ignore());

            CreateMap<IGroupMessageModel, GroupMessage>()
                .ForMember(dest => dest.Id, opt => opt.Ignore());
        }
    }

    public class DateTimeTypeConverter : ITypeConverter<DateTime, string>
    {
        string ITypeConverter<DateTime, string>.Convert(DateTime source, string destination, ResolutionContext context)
        {
            if (source != null)
            {
                return source.ToString("dd/MM/yyyy");
            }

            return " ";
        }
    }

    public class TimeTypeConverter : ITypeConverter<TimeSpan, string>
    {
        string ITypeConverter<TimeSpan, string>.Convert(TimeSpan source, string destination, ResolutionContext context)
        {
            if (source != null)
            {
                return DateTime.Parse(source.ToString()).ToString("HH:mm");
            }

            return " ";
        }
    }

    public class StringTypeConverter : ITypeConverter<string, string>
    {
        string ITypeConverter<string, string>.Convert(string source, string destination, ResolutionContext context)
        {
            if (source != null)
            {
                return source;
            }

            return "";
        }
    }

    public class DoubleTypeConverter : ITypeConverter<double, int>
    {
        public int Convert(double source, int destination, ResolutionContext context)
        {
            return (int)source;
        }

    }

    public class DateConvertTypeConverter : ITypeConverter<string, DateTime>
    {
        DateTime ITypeConverter<string, DateTime>.Convert(string source, DateTime destination, ResolutionContext context)
        {
            string dt = DateTime.ParseExact(source, "dd/MM/yyyy", CultureInfo.InvariantCulture)
                        .ToString("MM/dd/yyyy", CultureInfo.InvariantCulture);

            return DateTime.Parse(dt);
        }
    }
}
