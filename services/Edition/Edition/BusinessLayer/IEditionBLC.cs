using System.Collections.Generic;

namespace Edition
{
    public interface IEditionBLC
    {
        List<Edition> GetEditions();
        Edition GetEdition(string editionName);
        Edition PostEdition(Edition edition);
        List<Edition> PostEditions(List<Edition> editions);
    }
}