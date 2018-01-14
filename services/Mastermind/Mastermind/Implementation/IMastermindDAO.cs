using System.Collections.Generic;

namespace Mastermind
{
    public interface IMastermindDAO
    {
        Mastermind GetMastermind(string name);
        List<Mastermind> GetMasterminds();
        Mastermind InsertMastermind(Mastermind mastermind);
        Mastermind UpdateMastermind(Mastermind mastermind);
    }
}