using KSAVideoConference.Repository;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace KSAVideoConference.AppAdmin.Services
{
    public class ViewAuthorization
    {
        private readonly AppUnitOfWork _UnitOfWork;

        public ViewAuthorization(AppUnitOfWork UnitOfWork)
        {
            _UnitOfWork = UnitOfWork;
        }
        public int GetAccessLevel(string ViewName)
        {
            //return _UnitOfWork.SystemUserPermissionRepository.GetAccessLevel(AppMainData.Email, ViewName);
            return 1;
        }
    }
}
