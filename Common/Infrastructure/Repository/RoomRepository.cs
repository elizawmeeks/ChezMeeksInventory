using Common.Domain;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Common.Infrastructure
{
    public partial class Repository
    {
        public void CreateRoom(Room room) =>
            _context.Add(room);

        public IEnumerable<Room> Rooms() =>
            _context.Rooms;

        public void UpdateRoom(Room room) =>
            _context.Update(room);

        public void DeleteRoom(Room room) =>
            _context.Remove(room);
    }
}
