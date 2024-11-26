using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Common.Domain
{
    public class Space
    {
        public Space() { }
        public Guid ID { get; set; }
        public string Name { get; set; } = default!;

        public Room Room { get; set; } = default!;
        public List<Item> Items { get; set; } = default!;
    }
}
