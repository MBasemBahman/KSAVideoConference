using System.ComponentModel;
using System.ComponentModel.DataAnnotations.Schema;

namespace KSAVideoConference.Entity
{
    public class LangModel<T> : BaseModel
    {
        [ForeignKey(nameof(Source))]
        [DisplayName(nameof(Source))]
        public int Fk_Source { get; set; }

        [DisplayName("Source")]
        public T Source { get; set; }

        [ForeignKey(nameof(Language))]
        [DisplayName(nameof(Language))]
        public int Fk_Language { get; set; }

        [DisplayName("Language")]
        public Language Language { get; set; }
    }
}
