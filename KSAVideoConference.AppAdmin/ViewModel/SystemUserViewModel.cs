using KSAVideoConference.Entity.AuthModel;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Linq;
using System.Threading.Tasks;

namespace KSAVideoConference.AppAdmin.ViewModel
{
    public class SystemUserViewModel
    {
        public SystemUser SystemUser { get; set; }

        [DisplayName("Contorl Level")]
        public int Fk_ContorlLevel { get; set; }

        [DisplayName("Full Access Views")]
        public List<int> SelectedFullAccess { get; set; }

        [DisplayName("Control Access Views")]
        public List<int> SelectedControlAccess { get; set; }

        [DisplayName("View Access Views")]
        public List<int> SelectedViewAccess { get; set; }
    }
}
