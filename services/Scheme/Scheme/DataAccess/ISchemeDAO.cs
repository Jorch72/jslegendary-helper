using System.Collections.Generic;

namespace Scheme
{
    public interface ISchemeDAO
    {
        List<Scheme> GetSchemes();
        Scheme GetScheme(string name);
        Scheme InsertScheme(Scheme scheme);
        Scheme UpdateScheme(Scheme scheme);
    }
}