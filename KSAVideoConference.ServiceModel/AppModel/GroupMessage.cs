﻿using System.ComponentModel;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace KSAVideoConference.ServiceModel.AppModel
{
    public class GroupMessageModel : BaseModel
    {
        [ForeignKey(nameof(User))]
        [DisplayName(nameof(User))]
        public int Fk_User { get; set; }

        [DisplayName("المستخدم")]
        public UserModel User { get; set; }

        [ForeignKey(nameof(Group))]
        [DisplayName(nameof(Group))]
        public int Fk_Group { get; set; }

        [DisplayName("المجموعه")]
        public GroupModel Group { get; set; }

        [Required(ErrorMessage = "العنصر مطلوب")]
        [DataType(DataType.MultilineText)]
        public string Message { get; set; }

        [ForeignKey(nameof(Attachment))]
        [DisplayName(nameof(Attachment))]
        public int? Fk_Attachment { get; set; }

        [DisplayName("الملف المرفق")]
        public AttachmentModel Attachment { get; set; }
    }
}
