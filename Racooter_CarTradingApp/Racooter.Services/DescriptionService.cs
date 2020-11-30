using Racooter.Abstractions;
using System;
using System.Collections.Generic;
using System.Text;

namespace Racooter.Services
{
    public class DescriptionService
    {
        private readonly IDescriptionRepository descriptionRepository;

        public DescriptionService(IDescriptionRepository descriptionRepository)
        {
            this.descriptionRepository = descriptionRepository;
        }
    }
}
