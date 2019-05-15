using System;
using System.Collections.Generic;

namespace PartsTrader.ClientTools.API.Model.DTO
{
    public class PartDetailsDTO
    {
        public string Title { get; set; }
        public string Thumbnail { get; set; }
        public string Image { get; set; }
        public string Price { get; set; }
        public string PartNumber { get; set; }
        public string Condition { get; set; }
        public bool Genuine { get; set; }
        public string Description { get; set; }
        public List<PartSummaryDTO> Equivalents { get; set; }
    }
}
