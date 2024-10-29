using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Common.Domain
{
    public class Room
    {
        public Room() { }
        private Room(Guid id, string name)
        {
            ID = id;
            Name = name;
        }
        public Guid ID { get; set; }
        public string Name { get; set; } = default!;

        public List<Space> Spaces { get; set; } = default!;

        public static Room CreateRoom(Guid id, string name) => new (id, name);

        public Room Update(string name)
        {
            this.Name = name;
            return this;
        }
    }
}
