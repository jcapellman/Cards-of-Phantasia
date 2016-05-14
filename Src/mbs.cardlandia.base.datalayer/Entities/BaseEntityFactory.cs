using System.Data.Entity;

namespace mbs.cardlandia.baseabstractions.datalayer.Entities {
    public class BaseEntityFactory : DbContext
    {
        public BaseEntityFactory(string conString) : base(conString) {  }
    }
}