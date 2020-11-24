using System;
using System.Collections;
using System.Collections.Generic;

namespace LogicModel
{
    public class History : BaseIdentifier
    {
        public ICollection<HistoryItem> HistoryItems { get; set; } 
    }
}