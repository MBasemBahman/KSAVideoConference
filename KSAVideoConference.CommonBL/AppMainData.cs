namespace KSAVideoConference.CommonBL
{
    public class AppMainData
    {
        public static string DomainName { get; set; }

        public static string WebRootPath { get; set; }

        public static string Email { get; set; }

        public static string SeedData { get; set; } = "seed@app.com";
    }

    public class EnumModel
    {
        public enum SystemViewEnum
        {
            Home = 1,
            SystemView = 2,
            SystemUser = 3
        };

        public enum AccessLevelEnum
        {
            FullAccess = 1,
            ControlAccess = 2,
            ViewAccess = 3
        };

        public enum ControlLevelEnum
        {
            All = 1,
            Owner = 2
        };

        public enum LanguageEnum
        {
            English = 1,
            Arabic = 2,
        };

        public enum AppStaticMessageEnum
        {
            Common = 1,
            UnAuth = 2,
            UnActive = 3,
            InCompleteData = 4,
            NotOwner = 5,
            NotActiveGroup = 6,
            JoinGroup = 7,
            OwnerCantExit = 8,
            DuplicateNumber = 9
        };
    }
}
