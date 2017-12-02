using System.Data.Entity;
using Try1975.Nevlabs.Entities;

namespace Try1975.Nevlabs.QueryProcessors
{
    public class PersonQuery : TypedQuery<PersonEntity, int>, IPersonQuery
    {
        public PersonQuery(DbContext db) : base(db)
        {
        }
    }
}