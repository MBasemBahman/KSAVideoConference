using KSAVideoConference.CommonBL;
using System;
using System.ComponentModel;
using System.ComponentModel.DataAnnotations;

namespace KSAVideoConference.Entity
{
    public class BaseModel
    {
        [Key]
        [DisplayName("المعرف")]
        public int Id { get; set; }

        [DisplayName("أنشئت في")]
        [DataType(DataType.DateTime)]
        [DisplayFormat(DataFormatString = "{0:dd/MM/yyyy hh:mm tt}")]
        public DateTime CreatedAt { get; set; } = LocalCurrentTime.GetLocalCurrentTime();

        [DisplayName("انشأ من قبل")]
        public string CreatedBy { get; set; } = AppMainData.Email;

        [DisplayName("آخر تعديل في")]
        [DataType(DataType.DateTime)]
        [DisplayFormat(DataFormatString = "{0:dd/MM/yyyy hh:mm tt}")]
        public DateTime LastModifiedAt { get; set; } = LocalCurrentTime.GetLocalCurrentTime();

        [DisplayName("التعديل الأخير من قبل")]
        public string LastModifiedBy { get; set; } = AppMainData.Email;
    }
}
