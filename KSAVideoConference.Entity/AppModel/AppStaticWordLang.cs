using System.ComponentModel;
using System.ComponentModel.DataAnnotations;

namespace KSAVideoConference.Entity.AppModel
{
    public class AppStaticWordLang : LangModel<AppStaticWord>
    {
        [Required]
        [DisplayName("Value")]
        public string Value { get; set; }
    }
}
