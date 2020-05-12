using System.ComponentModel;
using System.ComponentModel.DataAnnotations.Schema;

namespace KSAVideoConference.Entity.AuthModel
{
    public class SystemUserPermission : BaseModel
    {
        [ForeignKey(nameof(SystemView))]
        [DisplayName(nameof(SystemView))]
        public int Fk_SystemView { get; set; }

        [DisplayName("الصفحه")]
        public SystemView SystemView { get; set; }

        [ForeignKey(nameof(SystemUser))]
        [DisplayName(nameof(SystemUser))]
        public int Fk_SystemUser { get; set; }

        [DisplayName("المستخدم")]
        public SystemUser SystemUser { get; set; }

        [ForeignKey(nameof(AccessLevel))]
        [DisplayName(nameof(AccessLevel))]
        public int Fk_AccessLevel { get; set; }

        public AccessLevel AccessLevel { get; set; }

        [ForeignKey(nameof(ControlLevel))]
        [DisplayName(nameof(ControlLevel))]
        public int Fk_ControlLevel { get; set; }

        public ControlLevel ControlLevel { get; set; }
    }
}
