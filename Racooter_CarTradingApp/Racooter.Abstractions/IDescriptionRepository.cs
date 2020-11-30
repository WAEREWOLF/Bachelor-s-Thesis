using LogicModel;
using System;
using System.Collections.Generic;
using System.Text;

namespace Racooter.Abstractions
{
    public interface IDescriptionRepository : IRepository<Description>
    {
        Description GetDescriptionById(Guid descriptionId);
    }
}
