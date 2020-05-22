using KSAVideoConference.CommonBL;
using Microsoft.AspNetCore.Hosting;
using Microsoft.Extensions.Configuration;

namespace KSAVideoConference.AppAdmin.Services
{
    public class AppSetting
    {
        public IConfiguration _Configuration { get; }
        private readonly IWebHostEnvironment _HostingEnvironment;


        public AppSetting(IConfiguration Configuration, IWebHostEnvironment HostingEnvironment)
        {
            _Configuration = Configuration;
            _HostingEnvironment = HostingEnvironment;

            AppMainData.WebRootPath = _HostingEnvironment.WebRootPath;
            AppMainData.DomainName = _Configuration.GetValue<string>("DomainName");
        }
    }
}
