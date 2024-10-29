using Fluxor.Blazor.Web.Components;
using Microsoft.AspNetCore.Components;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ChezMeeksInventory.Components.Layout
{
    public partial class NavMenu : FluxorComponent
    {
        [Inject] public NavigationManager NavigationManager { get; set; } = default!;
    }
}
