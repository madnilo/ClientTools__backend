using System;
namespace PartsTrader.ClientTools.API.Domain
{
    public class PartSummary
    {
        public string Title { get; set; }
        public string Thumbnail { get; set; }
        public string Image { get; set; }
        public string Price { get; set; }
        public string PartNo { get; set; }
        public string Condition { get; set; }
        public bool Genuine { get; set; }
        public string Description { get; set; }
    }
}
