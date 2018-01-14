using System.Collections.Generic;

namespace Edition
{
    public interface IEditionDAO
    {
        List<Edition> GetEditions();
        Edition GetEdition(string editionName);
        Edition InsertEdition(Edition edition);
        Edition UpdateEdition(Edition edition);
    }
}