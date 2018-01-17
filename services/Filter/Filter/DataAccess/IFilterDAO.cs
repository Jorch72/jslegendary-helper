using System.Collections.Generic;

namespace Filter
{
    public interface IFilterDAO
    {
        List<Filter> GetFilters();
        Filter GetFilter(int players);
    }
}