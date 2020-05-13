using System.Collections.Generic;
using System.Threading.Tasks;

namespace KSAVideoConference.BaseRepository
{
    public interface ILanguage<T>
    {
        Task<T> GetByIDAsync(T Source, int Fk_Language);

        Task<List<T>> GetAllAsync(int Fk_Language);
    }
}
