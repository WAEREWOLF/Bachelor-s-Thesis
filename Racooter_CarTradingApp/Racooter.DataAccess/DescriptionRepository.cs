using LogicModel;
using Racooter.Abstractions;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace Racooter.DataAccess
{
    public class DescriptionRepository : BaseRepository<Description>, IDescriptionRepository
    {
        public DescriptionRepository(RacooterCarTradingDbContext dbContext) : base(dbContext)
        {
        }
        
        public Description GetDescriptionById(Guid descriptionId)
        {
            return dbContext.Descriptions.Where(d => d.Id == descriptionId).FirstOrDefault();
        }
    }
}
