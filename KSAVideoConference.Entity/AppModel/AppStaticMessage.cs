using System.Collections.Generic;
using System.ComponentModel;
using System.ComponentModel.DataAnnotations;

namespace KSAVideoConference.Entity.AppModel
{
    public class AppStaticMessage : BaseModel
    {
        [Required]
        [DisplayName("Key")]
        public string Key { get; set; }

        [Required]
        [DisplayName("Value")]
        public string Value { get; set; }

        public ICollection<AppStaticMessageLang> AppStaticWordLangs { get; set; }
    }
}
