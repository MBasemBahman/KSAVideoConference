using KSAVideoConference.Entity.AppModel;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Linq;
using System.Threading.Tasks;

namespace KSAVideoConference.AppAdmin.ViewModel
{
    public class GroupViewModel
    {
        public Group Group { get; set; }

        [DisplayName("اعضاء المجموعة")]
        public List<int> SelectedGroupMembers { get; set; } = new List<int>();
    }
}
