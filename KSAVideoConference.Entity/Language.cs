using KSAVideoConference.Entity.AppModel;
using System.Collections.Generic;
using System.ComponentModel;
using System.ComponentModel.DataAnnotations;

namespace KSAVideoConference.Entity
{
    public class Language : BaseModel
    {
        [Required(ErrorMessage = "العنصر مطلوب")]
        [DisplayName("اسم اللغه")]
        public string Name { get; set; }

        public ICollection<AppStaticMessageLang> AppStaticMessageLangs { get; set; }

        public ICollection<AppStaticWordLang> AppStaticWordLangs { get; set; }

        public ICollection<User> Users { get; set; }
    }
}
