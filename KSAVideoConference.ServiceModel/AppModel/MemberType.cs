using System.Collections.Generic;

namespace KSAVideoConference.ServiceModel.AppModel
{
    public class MemberTypeModel : BaseModel
    {
        public string Name { get; set; }

        public ICollection<GroupMemberModel> GroupMembers { get; set; }
    }
}
