using AutoMapper;
using KSAVideoConference.DAL;
using KSAVideoConference.Repository.AppRepository;
using KSAVideoConference.Repository.AuthRepository;

namespace KSAVideoConference.Repository
{
    public class AppUnitOfWork
    {
        private readonly DataContext DataContext;
        private readonly IMapper _Mapper;

        public AppUnitOfWork(DataContext DataContext, IMapper Mapper)
        {
            this.DataContext = DataContext;
            _Mapper = Mapper;
        }

        public AccessLevelRepository AccessLevelRepository => new AccessLevelRepository(DataContext, _Mapper);
        public ControlLevelRepository ControlLevelRepository => new ControlLevelRepository(DataContext, _Mapper);
        public SystemUserPermissionRepository SystemUserPermissionRepository => new SystemUserPermissionRepository(DataContext, _Mapper);
        public SystemUserRepository SystemUserRepository => new SystemUserRepository(DataContext, _Mapper);
        public SystemViewRepository SystemViewRepository => new SystemViewRepository(DataContext, _Mapper);
        public AttachmentRepository AttachmentRepository => new AttachmentRepository(DataContext, _Mapper);
        public AttachmentTypeRepository AttachmentTypeRepository => new AttachmentTypeRepository(DataContext, _Mapper);
        public GroupMemberRepository GroupMemberRepository => new GroupMemberRepository(DataContext, _Mapper);
        public GroupMessageRepository GroupMessageRepository => new GroupMessageRepository(DataContext, _Mapper);
        public GroupRepository GroupRepository => new GroupRepository(DataContext, _Mapper);
        public MemberTypeRepository MemberTypeRepository => new MemberTypeRepository(DataContext, _Mapper);
        public UserContactRepository UserContactRepository => new UserContactRepository(DataContext, _Mapper);
        public UserRepository UserRepository => new UserRepository(DataContext, _Mapper);
        public LanguageRepository LanguageRepository => new LanguageRepository(DataContext, _Mapper);
        public AppStaticWordRepository AppStaticWordRepository => new AppStaticWordRepository(DataContext, _Mapper);
        public AppStaticMessageRepository AppStaticMessageRepository => new AppStaticMessageRepository(DataContext, _Mapper);

    }
}
