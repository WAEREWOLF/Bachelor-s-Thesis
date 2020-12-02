using LogicModel;
using System;
using System.Collections.Generic;
using System.Text;

namespace Racooter.Model
{
    public class AnnouncementImage : BaseIdentifier
    {
        public string Name { get; set; }
        public byte[] ImageData { get; set; }
    }
}
