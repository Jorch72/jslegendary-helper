using System.Collections.Generic;

namespace Scheme
{
    public class SchemeBLC : ISchemeBLC
    {
        private ISchemeDAO _dao;

        public SchemeBLC(ISchemeDAO dao)
        {
            _dao = dao;
        }

        public List<Scheme> GetSchemes()
        {
            return _dao.GetSchemes();
        }

        public Scheme GetScheme(string name)
        {
            return _dao.GetScheme(name);
        }

        public Scheme PostScheme(Scheme scheme)
        {
            var result = _dao.GetScheme(scheme.Name);

            if(result == null)
                return _dao.InsertScheme(scheme);
            else
                return _dao.UpdateScheme(scheme);
        }
        
        public List<Scheme> PostSchemes(List<Scheme> schemes)
        {
            var result = new List<Scheme>();

            foreach(var scheme in schemes)
            {
                var exists = _dao.GetScheme(scheme.Name);

                if(exists == null)
                    result.Add(_dao.InsertScheme(scheme));
                else
                    result.Add(_dao.UpdateScheme(scheme));
            }

            return result;
        }
    }
}