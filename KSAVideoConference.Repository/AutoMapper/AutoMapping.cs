﻿using AutoMapper;
using KSAVideoConference.Entity;
using KSAVideoConference.Entity.AppModel;
using KSAVideoConference.Entity.AuthModel;
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
                .ForMember(dest => dest.NotificationToken, opt => opt.Ignore())
                .ForMember(dest => dest.Fk_Language, opt => opt.Ignore())
                .ForMember(dest => dest.Language, opt => opt.Ignore())
                .ForMember(dest => dest.ImageURL, opt => opt.Ignore())
                .ForMember(dest => dest.Language, opt => opt.Ignore())
                .ForMember(dest => dest.Groups, opt => opt.Ignore())
                .ForMember(dest => dest.GroupMembers, opt => opt.Ignore())
                .ForMember(dest => dest.GroupMessages, opt => opt.Ignore())
                .ForMember(dest => dest.MyUserContacts, opt => opt.Ignore())
                .ForMember(dest => dest.MeInUserContacts, opt => opt.Ignore())
                .ForMember(dest => dest.CreatedAt, opt => opt.Ignore())
                .ForMember(dest => dest.CreatedBy, opt => opt.Ignore());

            CreateMap<SystemView, SystemView>()
               .ForMember(dest => dest.Id, opt => opt.Ignore())
               .ForMember(dest => dest.SystemUserPermissions, opt => opt.Ignore())
               .ForMember(dest => dest.CreatedAt, opt => opt.Ignore())
               .ForMember(dest => dest.CreatedBy, opt => opt.Ignore());

            CreateMap<MemberType, MemberType>()
               .ForMember(dest => dest.Id, opt => opt.Ignore())
               .ForMember(dest => dest.GroupMembers, opt => opt.Ignore())
               .ForMember(dest => dest.CreatedAt, opt => opt.Ignore())
               .ForMember(dest => dest.CreatedBy, opt => opt.Ignore());

            CreateMap<Language, Language>()
               .ForMember(dest => dest.Id, opt => opt.Ignore())
               .ForMember(dest => dest.AppStaticMessageLangs, opt => opt.Ignore())
               .ForMember(dest => dest.AppStaticWordLangs, opt => opt.Ignore())
               .ForMember(dest => dest.Users, opt => opt.Ignore())
               .ForMember(dest => dest.CreatedAt, opt => opt.Ignore())
               .ForMember(dest => dest.CreatedBy, opt => opt.Ignore());

            CreateMap<GroupMember, GroupMember>()
               .ForMember(dest => dest.Id, opt => opt.Ignore())
               .ForMember(dest => dest.Fk_Group, opt => opt.Ignore())
               .ForMember(dest => dest.Fk_User, opt => opt.Ignore())
               .ForMember(dest => dest.Group, opt => opt.Ignore())
               .ForMember(dest => dest.User, opt => opt.Ignore())
               .ForMember(dest => dest.MemberType, opt => opt.Ignore())
               .ForMember(dest => dest.CreatedAt, opt => opt.Ignore())
               .ForMember(dest => dest.CreatedBy, opt => opt.Ignore());

            CreateMap<AppStaticMessage, AppStaticMessage>()
               .ForMember(dest => dest.Id, opt => opt.Ignore())
               .ForMember(dest => dest.AppStaticMessageLangs, opt => opt.Ignore())
               .ForMember(dest => dest.CreatedAt, opt => opt.Ignore())
               .ForMember(dest => dest.CreatedBy, opt => opt.Ignore());

            CreateMap<AppStaticMessageLang, AppStaticMessageLang>()
               .ForMember(dest => dest.Id, opt => opt.Ignore())
               .ForMember(dest => dest.Fk_Source, opt => opt.Ignore())
               .ForMember(dest => dest.Fk_Language, opt => opt.Ignore())
               .ForMember(dest => dest.Source, opt => opt.Ignore())
               .ForMember(dest => dest.Language, opt => opt.Ignore())
               .ForMember(dest => dest.CreatedAt, opt => opt.Ignore())
               .ForMember(dest => dest.CreatedBy, opt => opt.Ignore());

            CreateMap<AppStaticWord, AppStaticWord>()
               .ForMember(dest => dest.Id, opt => opt.Ignore())
               .ForMember(dest => dest.AppStaticWordLangs, opt => opt.Ignore())
               .ForMember(dest => dest.CreatedAt, opt => opt.Ignore())
               .ForMember(dest => dest.CreatedBy, opt => opt.Ignore());

            CreateMap<AppStaticWordLang, AppStaticWordLang>()
               .ForMember(dest => dest.Id, opt => opt.Ignore())
               .ForMember(dest => dest.Fk_Source, opt => opt.Ignore())
               .ForMember(dest => dest.Fk_Language, opt => opt.Ignore())
               .ForMember(dest => dest.Source, opt => opt.Ignore())
               .ForMember(dest => dest.Language, opt => opt.Ignore())
               .ForMember(dest => dest.CreatedAt, opt => opt.Ignore())
               .ForMember(dest => dest.CreatedBy, opt => opt.Ignore());

            CreateMap<GroupMessage, GroupMessage>()
               .ForMember(dest => dest.Id, opt => opt.Ignore())
               .ForMember(dest => dest.User, opt => opt.Ignore())
               .ForMember(dest => dest.Group, opt => opt.Ignore())
               .ForMember(dest => dest.Attachment, opt => opt.Ignore())
               .ForMember(dest => dest.Fk_Attachment, opt => opt.Ignore())
               .ForMember(dest => dest.CreatedAt, opt => opt.Ignore())
               .ForMember(dest => dest.CreatedBy, opt => opt.Ignore());

            CreateMap<Attachment, Attachment>()
               .ForMember(dest => dest.Id, opt => opt.Ignore())
               .ForMember(dest => dest.AttachmentURL, opt => opt.Ignore())
               .ForMember(dest => dest.CreatedAt, opt => opt.Ignore())
               .ForMember(dest => dest.CreatedBy, opt => opt.Ignore());


            CreateMap<Group, Group>()
               .ForMember(dest => dest.Id, opt => opt.Ignore())
               .ForMember(dest => dest.LogoURL, opt => opt.Ignore())
               .ForMember(dest => dest.Creator, opt => opt.Ignore())
               .ForMember(dest => dest.SessionId, opt => opt.Ignore())
               .ForMember(dest => dest.GroupMembers, opt => opt.Ignore())
               .ForMember(dest => dest.GroupMessages, opt => opt.Ignore())
               .ForMember(dest => dest.CreatedAt, opt => opt.Ignore())
               .ForMember(dest => dest.CreatedBy, opt => opt.Ignore());

            //////////////////// Service Model ///////////////////////////

            // MemberType
            CreateMap<MemberType, MemberTypeModel>()
               .ForMember(dest => dest.GroupMembers, opt => opt.Ignore())
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

            CreateMap<IUserContactModel, UserContact>()
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
