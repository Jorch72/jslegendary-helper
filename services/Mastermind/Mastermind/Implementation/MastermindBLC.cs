using System.Collections.Generic;

namespace Mastermind
{
    public class MastermindBLC : IMastermindBLC
    {
        private IMastermindDAO _dao;

        public MastermindBLC(IMastermindDAO dao)
        {
            _dao = dao;
        }

        public Mastermind GetMastermind(string name)
        {
            return _dao.GetMastermind(name);
        }

        public List<Mastermind> GetMasterminds()
        {
            return _dao.GetMasterminds();
        }

        public Mastermind PostMastermind(Mastermind mastermind)
        {
            var result = _dao.GetMastermind(mastermind.Name);

            if(result == null)
                return _dao.InsertMastermind(mastermind);
            else
                return _dao.UpdateMastermind(mastermind);
        }
        
        public List<Mastermind> PostMasterminds(List<Mastermind> masterminds)
        {
            var result = new List<Mastermind>();

            foreach(var mastermind in masterminds)
            {
                var exists = _dao.GetMastermind(mastermind.Name);

                if(exists == null)
                    result.Add(_dao.InsertMastermind(mastermind));
                else
                    result.Add(_dao.UpdateMastermind(mastermind));
            }

            return result;
        }
    }
}