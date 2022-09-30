using Microsoft.AspNetCore.Components;
using Microsoft.AspNetCore.Components.Web;

namespace BoredApiClient.Components.Theme;

public partial class ThemeButton
{
    [Parameter]
    public EventCallback<MouseEventArgs> OnClick { get; set; }
}