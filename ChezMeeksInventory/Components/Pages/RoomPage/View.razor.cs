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
        //[Parameter] public EventCallback<RoomRequest> SaveRoomCallback { get; set; } = default!;
        [Parameter] public EventCallback<RoomRequest> SetRoomToEditModeCallback { get; set; } = default!;
        [Inject] public Fluxor.IDispatcher FluxorDispatcher { get; set; } = default!;

        public async Task SetRoomToEditMode() => 
            await SetRoomToEditModeCallback.InvokeAsync(Room);

        //public async Task SaveRoom() => 
        //    await SaveRoomCallback.InvokeAsync(Room);

        public async Task DeleteRoom() => 
            await DeleteRoomCallback.InvokeAsync(Room);
    }
}