using KSAVideoConference.CommonBL;
using Microsoft.AspNetCore.Hosting;
using Microsoft.AspNetCore.Http;
using Microsoft.Extensions.Configuration;

namespace KSAVideoConference.AppAdmin.Services
{
    public class AppSetting
    {
        public IConfiguration _Configuration { get; }
        private readonly ISession _Session;
        private readonly IWebHostEnvironment _HostingEnvironment;


        public AppSetting(IConfiguration Configuration, IHttpContextAccessor HttpContextAccessor, IWebHostEnvironment HostingEnvironment)
        {
            _Configuration = Configuration;
            _Session = HttpContextAccessor.HttpContext.Session;
            _HostingEnvironment = HostingEnvironment;

            AppMainData.WebRootPath = _HostingEnvironment.WebRootPath;
            AppMainData.DomainName = _Configuration.GetValue<string>("DomainName");
            AppMainData.Email = _Session.GetString("Email");
        }
    }
}
