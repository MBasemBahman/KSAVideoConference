using System.ComponentModel;
using System.ComponentModel.DataAnnotations;

namespace KSAVideoConference.Entity.AppModel
{
    public class AppStaticWordLang : LangModel<AppStaticWord>
    {
        [Required(ErrorMessage = "العنصر مطلوب")]
        [DisplayName("القيمه")]
        public string Value { get; set; }
    }
}
