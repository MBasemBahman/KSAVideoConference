using System.ComponentModel;
using System.ComponentModel.DataAnnotations;

namespace KSAVideoConference.Entity.AppModel
{
    public class AppStaticMessageLang : LangModel<AppStaticMessage>
    {
        [Required]
        [DisplayName("Value")]
        public string Value { get; set; }
    }
}
