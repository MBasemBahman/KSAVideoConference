using KSAVideoConference.CommonBL;
using System;
using System.ComponentModel;
using System.ComponentModel.DataAnnotations;

namespace KSAVideoConference.ServiceModel
{
    public class BaseModel
    {
        [Key]
        [DisplayName("المعرف")]
        public int Id { get; set; }

        [DisplayName("أنشئت في")]
        public string CreatedAt { get; set; }

        [DisplayName("آخر تعديل في")]
        public string LastModifiedAt { get; set; }
    }
}
