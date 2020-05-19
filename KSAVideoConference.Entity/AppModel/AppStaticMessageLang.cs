using System.ComponentModel;
using System.ComponentModel.DataAnnotations;

namespace KSAVideoConference.Entity.AppModel
{
    public class AppStaticMessageLang : LangModel<AppStaticMessage>
    {
        [Required(ErrorMessage = "العنصر مطلوب")]
        [DisplayName("القيمه")]
        public string Value { get; set; }
    }
}
