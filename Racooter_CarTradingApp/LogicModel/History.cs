using System;
using System.Collections;
using System.Collections.Generic;

namespace LogicModel
{
    public class History : BaseIdentifier
    {
        public virtual ICollection<HistoryItem> HistoryItems { get; set; } 
    }
}