using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Components;
using System.Net.Http;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Components.Authorization;
using Microsoft.AspNetCore.Components.Forms;
using Microsoft.AspNetCore.Components.Routing;
using Microsoft.AspNetCore.Components.Web;
using Microsoft.AspNetCore.Components.Web.Virtualization;
using Microsoft.JSInterop;
using KK.BusinessCards.Apps.BlazorServer;
using KK.BusinessCards.Apps.BlazorServer.Shared;
using KK.BusinessCards.Apps.BlazorServer.ViewModels;

namespace KK.BusinessCards.Apps.BlazorServer.BlazorComponents
{
    public partial class CardEditor
    {
        [Parameter]
        public CardListViewModel DataContext { get; set; }
    }
}