using System.Collections.Generic;

namespace Mastermind
{
    public interface IMastermindBLC
    {
        Mastermind GetMastermind(string name);
        List<Mastermind> GetMasterminds();
        Mastermind PostMastermind(Mastermind mastermind);
        List<Mastermind> PostMasterminds(List<Mastermind> masterminds);
    }
}