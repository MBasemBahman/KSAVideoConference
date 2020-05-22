using System.Collections.Generic;
using System.ComponentModel;
using System.ComponentModel.DataAnnotations;

namespace KSAVideoConference.Entity.AppModel
{
    public class AppStaticMessage : BaseModel
    {
        [Required(ErrorMessage = "العنصر مطلوب")]
        [DisplayName("المفتاح")]
        public string Key { get; set; }

        [Required(ErrorMessage = "العنصر مطلوب")]
        [DisplayName("القيمه")]
        public string Value { get; set; }

        public ICollection<AppStaticMessageLang> AppStaticMessageLangs { get; set; }
    }
}
