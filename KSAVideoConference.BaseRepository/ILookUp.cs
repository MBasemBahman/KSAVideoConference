using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;

namespace KSAVideoConference.BaseRepository
{
    public interface ILookUp
    {
        Task<List<dynamic>> GetLookUpAsync();
    }
}
