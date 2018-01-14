using System.Collections.Generic;

namespace Scheme
{
    public interface ISchemeBLC
    {
        List<Scheme> GetSchemes();
        Scheme GetScheme(string name);
        Scheme PostScheme(Scheme scheme);
        List<Scheme> PostSchemes(List<Scheme> schemes);
    }
}