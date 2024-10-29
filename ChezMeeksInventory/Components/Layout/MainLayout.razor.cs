using Microsoft.Maui.Controls;
using MudBlazor;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;


namespace ChezMeeksInventory.Components.Layout
{
    public partial class MainLayout
    {
        MudTheme ChezMeeks = new MudTheme()
        {
            PaletteLight = new PaletteLight()
            {
                Primary = MudBlazor.Colors.Blue.Default,
                Secondary = MudBlazor.Colors.Green.Accent4,
                AppbarBackground = MudBlazor.Colors.Red.Default,
            },
            PaletteDark = new PaletteDark()
            {
                Primary = "#2C1B47",
                Secondary = "#724C9D",
                Tertiary = "#DCCAE9",
                White = "#DCCAE9",
                Surface = "#2C1B47" //mudpaper color
            }
        };
    }
}
