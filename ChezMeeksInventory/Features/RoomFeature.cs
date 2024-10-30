using ChezMeeksInventory.Components.Pages.RoomPage;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Fluxor;
using Common.Domain;
using System.Collections.ObjectModel;
using Common.Infrastructure.Extensions;
using Common.Infrastructure;
using Microsoft.Extensions.Logging;
using static ChezMeeksInventory.Features.RoomFeature.State;
using System.Runtime.CompilerServices;

namespace ChezMeeksInventory.Features
{
    public static class RoomFeature
    {
        public class Feature : Feature<State>
        {
            public override string GetName() => nameof(RoomFeature);
            protected override State GetInitialState() => new();
        }

        public record State
        {
            public bool RoomsInitialized { get; init; } = false;
            public ReadOnlyCollection<RoomRequest> Rooms { get; init; } = new ReadOnlyCollection<RoomRequest>([]);

            public record RoomRequest
            {
                public RoomRequest(Guid id, string name, bool editMode = false)
                {
                    ID = id;
                    Name = name;
                    EditMode = editMode;
                }
                public Guid ID { get; init; }
                public string Name { get; set; } = default!;
                public bool EditMode { get; init; } = false;
                public static RoomRequest Empty() => new (Guid.NewGuid(), string.Empty);
                public static RoomRequest From(Room room) =>
                    new(room.ID, room.Name);

                public static ReadOnlyCollection<RoomRequest> From(IEnumerable<Room> rooms) =>
                    rooms.Select(From).ToReadOnlyCollection();

                public static RoomRequest Update(RoomRequest currentRoom, RoomRequest updateRoom) =>
                    currentRoom.ID.Equals(updateRoom.ID) ? updateRoom : currentRoom;

                public static RoomRequest SetEditMode(RoomRequest room, bool editMode) =>
                    room with { EditMode = editMode };
            }
        }

        public static class Reducers
        {
            [ReducerMethod]
            public static State OnRoomsLoaded(State state, RoomsLoaded roomsLoaded) =>
                state with
                {
                    RoomsInitialized = true,
                    Rooms = RoomRequest.From(roomsLoaded.Rooms)
                };

            [ReducerMethod]
            public static State OnAddRoomComponent(State state, AddRoomComponent _) =>
                state with
                {
                    Rooms = state.Rooms.ToList().Append(RoomRequest.Empty()).ToReadOnlyCollection()
                };

            [ReducerMethod]
            public static State OnSetRoomToEditMode(State state, SetRoomToEditMode setRoomToEditMode) => 
                state with
                {
                    Rooms = state.Rooms
                                 .Select(room => room.ID.Equals(setRoomToEditMode.ID) 
                                                        ? RoomRequest.SetEditMode(room, true) 
                                                        : room)
                                 .ToReadOnlyCollection()
                };

            [ReducerMethod]
            public static State OnSaveRoom(State state, SaveRoom saveRoom) =>
                state with
                {
                    Rooms = state.Rooms
                                 .Select(room => RoomRequest.Update(room, RoomRequest.SetEditMode(saveRoom.Room, false)))
                                 .ToReadOnlyCollection()
                };

            [ReducerMethod]
            public static State OnDeleteRoom(State state, DeleteRoom deleteAction)
            {
                var editedRooms = state.Rooms.Where(room => !room.ID.Equals(deleteAction.Room.ID)).ToReadOnlyCollection();
                return state with
                {
                    Rooms = editedRooms
                };
            }
        }

        public class Effects(Repository repository, ILogger<Effects> logger)
        {
            private readonly Repository _repository = repository;
            private readonly ILogger<Effects> _logger = logger;

            [EffectMethod]
            public async Task Initialize(Initialize _, Fluxor.IDispatcher fluxorDispatcher)
            {
                fluxorDispatcher.Dispatch(new RoomsLoaded(_repository.Rooms()));
                await Task.CompletedTask;
            }

            [EffectMethod]
            public async Task SaveRoom(SaveRoom action, Fluxor.IDispatcher _)
            {
                var rooms = _repository.Rooms();
                var roomExists = rooms.Where(room => room.ID.Equals(action.Room.ID)).Any();

                if (roomExists)
                {
                    var room = rooms.Where(room => room.ID.Equals(action.Room.ID)).First();
                    _repository.UpdateRoom(room.Update(action.Room.Name));
                }
                else
                    _repository.CreateRoom(Room.CreateRoom(action.Room.ID, action.Room.Name));

                _repository.SaveChanges();
                await Task.CompletedTask;
            } 

            [EffectMethod]
            public async Task DeleteRoom(DeleteRoom action, Fluxor.IDispatcher _)
            {
                var rooms = _repository.Rooms();
                var deletedRoom = rooms.Where(room => room.ID.Equals(action.Room.ID)); 

                if (deletedRoom.Any())
                {
                    _repository.DeleteRoom(deletedRoom.First()); 
                    _repository.SaveChanges();
                }

                await Task.CompletedTask;
            }
        }

        //Actions
        public record Initialize;
        public record RoomsLoaded(IEnumerable<Room> Rooms);
        public record SaveRoom(RoomRequest Room);
        public record DeleteRoom(RoomRequest Room);
        public record AddRoomComponent();
        public record SetRoomToEditMode(Guid ID);
    }
}
