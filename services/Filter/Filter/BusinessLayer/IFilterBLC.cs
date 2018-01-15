using System.Collections.Generic;

namespace Filter
{
    public interface IFilterBLC
    {
        Filter GetFilter(UserFilter userFilter);
    }
}