using System.Collections.Generic;

namespace Filter
{
    public class FilterBLC : IFilterBLC
    {
        public Filter GetFilter(UserFilter userFilter)
        {
            int villains = 0, henchmen = 0;

            switch(userFilter.Players)
            {
                case 2:
                    villains = 2;
                    henchmen = 1;
                    break;
                case 3:
                    villains = 3;
                    henchmen = 1;
                    break;
                case 4:
                    villains = 3;
                    henchmen = 2;
                    break;
                case 5:
                    villains = 4;
                    henchmen = 2;
                    break;
            }

            var filter = new Filter 
            {
                Players = userFilter.Players,
                MaxMasterminds = 1,
                MaxVillains = villains,
                MaxHenchmen = henchmen,
                Editions = userFilter.Editions
            };

            return filter;
        }
    }
}