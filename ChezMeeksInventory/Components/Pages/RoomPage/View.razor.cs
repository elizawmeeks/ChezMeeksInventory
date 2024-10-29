using ChezMeeksInventory.Features;
using Fluxor;
using Fluxor.Blazor.Web.Components;
using Microsoft.AspNetCore.Components;
using Microsoft.AspNetCore.Components.Web;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using static ChezMeeksInventory.Features.RoomFeature.State;

namespace ChezMeeksInventory.Components.Pages.RoomPage
{
    public partial class View : FluxorComponent
    {
        [Parameter] public RoomRequest Room { get; set; } = RoomRequest.Empty();
        [Parameter] public EventCallback<RoomRequest> DeleteRoomCallback { get; set; } = default!;
        [Inject] public Fluxor.IDispatcher FluxorDispatcher { get; set; } = default!;
        private string _name = string.Empty;

        public async Task SaveName()
        {
            Room = RoomRequest.SetEditMode(Room, false);
            FluxorDispatcher.Dispatch(new RoomFeature.SaveRoom(Room));
            await Task.CompletedTask;
        }

        public async Task SetEditMode()
        {
            Room = RoomRequest.SetEditMode(Room, true);
            FluxorDispatcher.Dispatch(new RoomFeature.SetRoomToEditMode(Room.ID));
            await Task.CompletedTask;
        }

        public async Task DeleteRoom() => 
            await DeleteRoomCallback.InvokeAsync(Room);
    }
}