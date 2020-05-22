using AutoMapper;
using KSAVideoConference.BaseRepository;
using KSAVideoConference.CommonBL;
using KSAVideoConference.DAL;
using KSAVideoConference.Entity.AppModel;
using Microsoft.AspNetCore.Http;
using Microsoft.EntityFrameworkCore;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace KSAVideoConference.Repository.AppRepository
{
    public class GroupMessageRepository : AppBaseRepository<GroupMessage>
    {
        private readonly DataContext DBContext;
        private readonly IMapper _Mapper;

        public GroupMessageRepository(DataContext DBContext, IMapper Mapper) : base(DBContext)
        {
            this.DBContext = DBContext;
            _Mapper = Mapper;
        }

        public async Task<List<GroupMessage>> GetAllAsyncIclude(string CreatedBy)
        {
            return await DBContext.GroupMessage
                                  .Where(a => a.CreatedBy == CreatedBy)
                                  .Include(a => a.Group)
                                  .Include(a => a.User)
                                  .Include(a => a.Attachment)
                                  .ToListAsync();

        }
        public async Task<List<GroupMessage>> GetAllAsyncIclude()
        {
            return await DBContext.GroupMessage
                                  .Include(a => a.Group)
                                  .Include(a => a.User)
                                  .Include(a => a.Attachment)
                                  .ToListAsync();
        }

        public async Task<GroupMessage> GetByIDAsyncIclude(int id)
        {
            return await DBContext.GroupMessage
                                  .Where(a => a.Id == id)
                                  .Include(a => a.Group)
                                  .Include(a => a.User)
                                  .Include(a => a.Attachment)
                                  .FirstOrDefaultAsync();
        }

        public async Task UploudFile(GroupMessage GroupMessage, IFormFile File)
        {
            if (File != null)
            {
                ImgManager ImgManager = new ImgManager(AppMainData.WebRootPath);

                Attachment Attachment = new Attachment
                {
                    Name = File.FileName,
                    Type = File.ContentType,
                    Length = File.Length
                };

                DBContext.Add(Attachment);
                await DBContext.SaveChangesAsync();

                string FileURL = await ImgManager.UploudImageAsync(AppMainData.DomainName, Attachment.Id.ToString(), File, "Uploud/Attachment");

                if (!string.IsNullOrEmpty(FileURL))
                {
                    Attachment.AttachmentURL = FileURL;
                    GroupMessage.Fk_Attachment = Attachment.Id;
                    await DBContext.SaveChangesAsync();
                }
                else
                {
                    DBContext.Attachment.Remove(Attachment);
                    await DBContext.SaveChangesAsync();
                }
            }
        }
    }
}
