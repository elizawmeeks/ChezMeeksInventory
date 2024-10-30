using ChezMeeksInventory.Features;
using Fluxor;
using Fluxor.Blazor.Web.Components;
using Microsoft.AspNetCore.Components;
using static ChezMeeksInventory.Features.RoomFeature.State;

namespace ChezMeeksInventory.Components.Pages.RoomPage
{
    public partial class Rooms : FluxorComponent
    {
        [Inject] public IState<RoomFeature.State> State { get; set; } = default!;
        [Inject] public Fluxor.IDispatcher FluxorDispatcher { get; set; } = default!;

        protected override void OnInitialized()
        {
            base.OnInitialized();
            FluxorDispatcher.Dispatch(new RoomFeature.Initialize());
        } 

        public void AddRoomComponent() =>
            FluxorDispatcher.Dispatch(new RoomFeature.AddRoomComponent());

        public void DeleteRoom(RoomRequest room) => 
            FluxorDispatcher.Dispatch(new RoomFeature.DeleteRoom(room));

        public void SaveRoom(RoomRequest room) =>
            FluxorDispatcher.Dispatch(new RoomFeature.SaveRoom(room));

        public void SetRoomToEditMode(RoomRequest room) =>
            FluxorDispatcher.Dispatch(new RoomFeature.SetRoomToEditMode(room.ID));
    }
}