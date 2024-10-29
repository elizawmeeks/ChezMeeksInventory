using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Common.Domain
{
    public class Item
    {
        public Item() { }
        public Guid ID { get; set; }
        //public Guid SpaceID { get; set; } = default!;
        public string Name { get; set; } = default!;

        public Space Space { get; set; } = default!;
    }
}
