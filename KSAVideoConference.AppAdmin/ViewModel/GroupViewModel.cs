using KSAVideoConference.Entity.AppModel;
using System.Collections.Generic;
using System.ComponentModel;

namespace KSAVideoConference.AppAdmin.ViewModel
{
    public class GroupViewModel
    {
        public Group Group { get; set; }

        [DisplayName("اعضاء المجموعة")]
        public List<int> SelectedGroupMembers { get; set; } = new List<int>();
    }
}
