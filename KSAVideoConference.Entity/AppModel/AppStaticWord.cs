using System.Collections.Generic;
using System.ComponentModel;
using System.ComponentModel.DataAnnotations;

namespace KSAVideoConference.Entity.AppModel
{
    public class AppStaticWord : BaseModel
    {
        [Required]
        [DisplayName("Key")]
        public string Key { get; set; }

        [Required]
        [DisplayName("Value")]
        public string Value { get; set; }

        public ICollection<AppStaticWordLang> AppStaticWordLangs { get; set; }
    }
}
