using KSAVideoConference.Entity.AppModel;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Linq;
using System.Threading.Tasks;

namespace KSAVideoConference.AppAdmin.ViewModel
{
    public class UserViewModel
    {
        public User User { get; set; }

        [DisplayName("جهات الاتصال الخاصه بي ")]
        public List<int> SelectedUserContacts { get; set; } = new List<int>();
    }
}
