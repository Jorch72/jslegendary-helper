using System.Collections.Generic;

namespace Edition
{
    public class EditionBLC : IEditionBLC
    {
        private IEditionDAO _dao;

        public EditionBLC(IEditionDAO dao)
        {
            _dao = dao;
        }

        public List<Edition> GetEditions()
        {
            return _dao.GetEditions();
        }

        public Edition GetEdition(string editionName)
        {
            return _dao.GetEdition(editionName);
        }

        public Edition PostEdition(Edition edition)
        {
            var result = _dao.GetEdition(edition.Name);

            if(result == null)
                return _dao.InsertEdition(edition);
            else
                return _dao.UpdateEdition(edition);
        }
        
        public List<Edition> PostEditions(List<Edition> editions)
        {
            var result = new List<Edition>();

            foreach(var edition in editions)
            {
                var exists = _dao.GetEdition(edition.Name);

                if(exists == null)
                    result.Add(_dao.InsertEdition(edition));
                else
                    result.Add(_dao.UpdateEdition(edition));
            }

            return result;
        }
    }
}