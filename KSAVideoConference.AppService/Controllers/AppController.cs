using AutoMapper;
using KSAVideoConference.DAL;
using KSAVideoConference.Entity.AppModel;
using KSAVideoConference.Repository;
using KSAVideoConference.ServiceModel;
using KSAVideoConference.ServiceModel.AppModel;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Logging;
using System;
using System.Collections.Generic;
using System.Text.Encodings.Web;
using System.Text.Json;
using System.Text.Unicode;
using System.Threading.Tasks;

namespace KSAVideoConference.AppService.Controllers
{
    [ApiExplorerSettings(GroupName = "App")]
    [ApiController]
    [Route("api/[controller]/v{version:apiVersion}")]
    [ApiVersion("1.0")]
    public class AppController : ControllerBase
    {
        private readonly ILogger<AppController> _logger;
        private readonly DataContext _DBContext;
        private readonly AppUnitOfWork _UnitOfWork;
        private readonly IMapper _Mapper;

        public AppController(ILogger<AppController> logger, DataContext dataContext,
                            AppUnitOfWork unitOfWork, IMapper mapper)
        {
            _logger = logger;
            _DBContext = dataContext;
            _UnitOfWork = unitOfWork;
            _Mapper = mapper;
        }

        /// <summary>
        /// Get : All Member Types 
        /// </summary>
        [HttpGet]
        [Route("GetMemberTypes")]
        public async Task<PagedList<MemberTypeModel>> GetMemberTypes([FromQuery] Paging paging, [FromQuery]Guid Token)
        {
            string ActionName = ControllerContext.RouteData.Values["action"].ToString();
            List<MemberTypeModel> returnData = new List<MemberTypeModel>();
            PagedList<MemberTypeModel> PagedData = PagedList<MemberTypeModel>.Create(returnData, paging.PageNumber, paging.PageSize);
            Status Status = new Status();

            try
            {
                User UserDB = await _UnitOfWork.UserRepository.GetByTokenAsync(Token);
                if (UserDB == null)
                {
                    Status.ErrorMessage = "لم يتم التعرف عليك";
                }
                else if (!UserDB.IsActive)
                {
                    Status.ErrorMessage = "لقد تم وقف حسابك على التطبيق";
                }
                else
                {
                    List<MemberType> Data = await _UnitOfWork.MemberTypeRepository.GetAllAsync();

                    IEnumerable<MemberType> OrderData = OrderBy<MemberType>.OrderData(Data, paging.OrderBy);

                    _Mapper.Map(OrderData, returnData);

                    PagedData = PagedList<MemberTypeModel>.Create(returnData, paging.PageNumber, paging.PageSize);

                    PaginationMetaData<MemberTypeModel> PaginationMetaData = new PaginationMetaData<MemberTypeModel>(PagedData)
                    {
                        PrevoisPageLink = (PagedData.HasPrevious) ? Url.Link(ActionName, new { paging.OrderBy, pageNumber = (paging.PageNumber - 1), paging.PageSize }) : null,
                        NextPageLink = (PagedData.HasNext) ? Url.Link(ActionName, new { paging.OrderBy, pageNumber = (paging.PageNumber + 1), paging.PageSize }) : null
                    };

                    Response.Headers.Add("X-Pagination", JsonSerializer.Serialize(PaginationMetaData).Replace(@"\u0026", "&"));

                    Status = new Status(true);
                }
            }
            catch (Exception ex)
            {
                Status.ExceptionMessage = ex.Message;
            }

            Response.Headers.Add("X-Status", JsonSerializer.Serialize(Status, new JsonSerializerOptions() { Encoder = JavaScriptEncoder.Create(UnicodeRanges.All) }));

            return PagedData;
        }
    }
}