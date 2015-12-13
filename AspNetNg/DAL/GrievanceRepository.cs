using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace AspNetNg.DAL
{
    public class GrievanceRepository : RepositoryBase<DogContext>
    {
        public GrievanceRepository() : base() { }

        public GrievanceRepository(string connection) : base(connection) { }
    }
}