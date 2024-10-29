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
    //public partial class Edit : FluxorComponent
    //{
    //    public Edit() 
    //    {
    //        _name = Room.Name;
    //    }
    //    [Parameter] public RoomRequest Room { get; set; } = RoomRequest.Empty();
    //    [Inject] public Fluxor.IDispatcher FluxorDispatcher { get; set; } = default!;
    //    private string _name { get; set; }

    //    public async Task SaveName()
    //    {
    //        Room = RoomRequest.SetEditMode(Room, false);
    //        FluxorDispatcher.Dispatch(new RoomFeature.SaveRoom(Room, _name));
    //        await Task.CompletedTask;
    //    }
    //}
}
