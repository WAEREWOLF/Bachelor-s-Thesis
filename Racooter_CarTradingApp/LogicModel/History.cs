using System;
using System.Collections;
using System.Collections.Generic;

namespace LogicModel
{
    public class History
    {
        public Guid HistoryId { get; set; }
        public ICollection<HistoryItem> HistoryItems { get; set; } 
    }
}