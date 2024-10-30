using ChezMeeksInventory.Features;
using Fluxor.Blazor.Web.Components;
using Microsoft.AspNetCore.Components;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using static ChezMeeksInventory.Features.RoomFeature.State;

namespace ChezMeeksInventory.Components.Pages.RoomPage
{
    public partial class Edit : FluxorComponent
    {
        [Parameter] public RoomRequest Room { get; set; } = RoomRequest.Empty();
        [Parameter] public EventCallback<RoomRequest> SaveRoomCallback { get; set; } = default!;
        [Inject] public Fluxor.IDispatcher FluxorDispatcher { get; set; } = default!;

        public async Task SaveRoom() =>
            await SaveRoomCallback.InvokeAsync(Room);
    }
}
