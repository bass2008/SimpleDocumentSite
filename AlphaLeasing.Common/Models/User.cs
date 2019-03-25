using AlphaLeasing.Common.Entity;
using System.Collections.Generic;

namespace AlphaLeasing.Common.Models
{
    public class User : ElementWithId
    {
        public virtual string Login { get; set; }

        public virtual string Password { get; set; }

        public virtual IList<Document> Documents { get; set; }
    }
}
