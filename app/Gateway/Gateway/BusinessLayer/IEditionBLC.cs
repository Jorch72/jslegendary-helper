using System.Collections.Generic;
using System.Threading.Tasks;

namespace Gateway
{
    public interface IEditionBLC
    {
        Task<List<Edition>> GetEditions();
    }
}