using KSAVideoConference.AppAdmin.Filters;
using KSAVideoConference.AppAdmin.Models;
using KSAVideoConference.AppAdmin.Services;
using KSAVideoConference.AppAdmin.ViewModel;
using KSAVideoConference.DAL;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Logging;
using System.Diagnostics;
using System.Linq;
using static KSAVideoConference.CommonBL.EnumModel;

namespace KSAVideoConference.AppAdmin.Controllers
{
    public class HomeController : Controller
    {
        private readonly ILogger<HomeController> _logger;
        private readonly DataContext _DBContext;
        private readonly AppSetting _AppSetting;

        public HomeController(ILogger<HomeController> logger, DataContext DBContext, AppSetting AppSetting)
        {
            _logger = logger;
            _DBContext = DBContext;
            _AppSetting = AppSetting;
        }

        [Authorize((int)AccessLevelEnum.ViewAccess)]
        public IActionResult Index()
        {
            HomeViewModel Home = new HomeViewModel
            {
                Group = _DBContext.Group.Count(),
                User = _DBContext.User.Count(),
                AvgGroupMember = _DBContext.GroupMember.Count() / _DBContext.Group.Count()
            };
            return View(Home);
        }

        [ResponseCache(Duration = 0, Location = ResponseCacheLocation.None, NoStore = true)]
        public IActionResult UnAuthorized()
        {
            return View();
        }

        [ResponseCache(Duration = 0, Location = ResponseCacheLocation.None, NoStore = true)]
        public IActionResult Error()
        {
            return View(new ErrorViewModel { RequestId = Activity.Current?.Id ?? HttpContext.TraceIdentifier });
        }

    }
}
