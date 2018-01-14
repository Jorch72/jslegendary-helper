using System.Collections.Generic;
using System.Threading.Tasks;

namespace Gateway
{
    public interface IEditionDAO
    {
        Task<List<Edition>> GetEditions();
    }
}