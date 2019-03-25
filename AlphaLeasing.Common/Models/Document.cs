using AlphaLeasing.Common.Entity;

namespace AlphaLeasing.Common.Models
{
    public class Document : ElementWithId
    {
        public virtual string Name { get; set; }

        public virtual string Date { get; set; }
        
        public virtual User User { get; set; }

        public virtual int UserId { get; set; }

        public virtual string Link { get; set; }
    }
}