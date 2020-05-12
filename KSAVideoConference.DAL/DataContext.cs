using KSAVideoConference.CommonBL;
using KSAVideoConference.Entity.AppModel;
using KSAVideoConference.Entity.AuthModel;
using Microsoft.EntityFrameworkCore;
using System;
using static KSAVideoConference.CommonBL.EnumModel;

namespace KSAVideoConference.DAL
{
    public class DataContext : DbContext
    {
        public DataContext(DbContextOptions<DataContext> options) : base(options)
        {
        }

        public DbSet<Attachment> Attachment { get; set; }
        public DbSet<AttachmentType> AttachmentType { get; set; }
        public DbSet<Group> Group { get; set; }
        public DbSet<GroupMember> GroupMember { get; set; }
        public DbSet<GroupMessage> GroupMessage { get; set; }
        public DbSet<MemberType> MemberType { get; set; }
        public DbSet<User> User { get; set; }
        public DbSet<UserContact> UserContact { get; set; }
        public DbSet<AccessLevel> AccessLevel { get; set; }
        public DbSet<ControlLevel> ControlLevel { get; set; }
        public DbSet<SystemUser> SystemUser { get; set; }
        public DbSet<SystemUserPermission> SystemUserPermission { get; set; }
        public DbSet<SystemView> SystemView { get; set; }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.Entity<User>()
                        .HasMany(a => a.MyUserContacts)
                        .WithOne(a => a.User)
                        .HasForeignKey(a => a.Fk_User);

            modelBuilder.Entity<User>()
                        .HasMany(a => a.MeInUserContacts)
                        .WithOne(a => a.Contact)
                        .HasForeignKey(a => a.Fk_Contact);

            modelBuilder.Entity<AccessLevel>()
           .HasData(
               new AccessLevel
               {
                   Id = (int)AccessLevelEnum.FullAccess,
                   Name = "FullAccess",
                   CreatedBy = AppMainData.SeedData
               },
               new AccessLevel
               {
                   Id = (int)AccessLevelEnum.ControlAccess,
                   Name = "ControlAccess",
                   CreatedBy = AppMainData.SeedData
               },
               new AccessLevel
               {
                   Id = (int)AccessLevelEnum.ViewAccess,
                   Name = "ViewAccess",
                   CreatedBy = AppMainData.SeedData
               }
           );

            modelBuilder.Entity<ControlLevel>()
           .HasData(
               new ControlLevel
               {
                   Id = (int)ControlLevelEnum.All,
                   Name = "All",
                   CreatedBy = AppMainData.SeedData
               },
               new ControlLevel
               {
                   Id = (int)ControlLevelEnum.Owner,
                   Name = "Owner",
                   CreatedBy = AppMainData.SeedData
               }
           );

            modelBuilder.Entity<SystemView>()
             .HasData(
                 new SystemView
                 {
                     Id = (int)SystemViewEnum.Home,
                     Name = "Home",
                     CreatedBy = AppMainData.SeedData
                 },
                 new SystemView
                 {
                     Id = (int)SystemViewEnum.SystemView,
                     Name = "SystemView",
                     CreatedBy = AppMainData.SeedData
                 },
                 new SystemView
                 {
                     Id = (int)SystemViewEnum.SystemUser,
                     Name = "SystemUser",
                     CreatedBy = AppMainData.SeedData
                 }
             );

            modelBuilder.Entity<SystemUser>()
              .HasData(
                  new SystemUser
                  {
                      Id = 1,
                      Email = AppMainData.SeedData,
                      FullName = "Admin",
                      JopTitle = "Admin",
                      Password = RandomGenerator.RandomKey(),
                      CreatedBy = AppMainData.SeedData,
                      IsActive = true
                  }
              );

            modelBuilder.Entity<SystemUserPermission>()
              .HasData(
                  new SystemUserPermission
                  {
                      Id = 1,
                      Fk_SystemUser = 1,
                      Fk_AccessLevel = 1,
                      Fk_ControlLevel = 1,
                      Fk_SystemView = 1,
                      CreatedBy = AppMainData.SeedData
                  },
                  new SystemUserPermission
                  {
                      Id = 2,
                      Fk_SystemUser = 1,
                      Fk_AccessLevel = 1,
                      Fk_ControlLevel = 1,
                      Fk_SystemView = 2,
                      CreatedBy = AppMainData.SeedData
                  },
                  new SystemUserPermission
                  {
                      Id = 3,
                      Fk_SystemUser = 1,
                      Fk_AccessLevel = 1,
                      Fk_ControlLevel = 1,
                      Fk_SystemView = 3,
                      CreatedBy = AppMainData.SeedData
                  }
              );
        }
    }
}
