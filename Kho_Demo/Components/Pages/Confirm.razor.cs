using Microsoft.AspNetCore.Components;
using Microsoft.JSInterop;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Kho_Demo.Components.Pages
{
    public partial class Confirm
    {
        [Inject] private NavigationManager Nav { get; set; } = default!;
        [Inject] private IJSRuntime JS { get; set; } = default!;
        public void OnConfirm()
        {
            Nav.NavigateTo($"/");
        }
    }
}
