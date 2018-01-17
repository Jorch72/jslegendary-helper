using System.Collections.Generic;

namespace Filter
{
    public class FilterBLC : IFilterBLC
    {
        private IFilterDAO _dao;

        public FilterBLC(IFilterDAO dao)
        {
            _dao = dao;
        }

        public Filter GetFilter(UserFilter userFilter)
        {
            var filter = _dao.GetFilter(userFilter.Players);
            filter.Editions = userFilter.Editions;

            return filter;
        }
    }
}