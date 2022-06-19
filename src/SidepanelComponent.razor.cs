using Microsoft.AspNetCore.Components;
using System;
using System.Collections.Generic;
using System.Linq;

namespace Append.Blazor.Sidepanel
{
	public partial class SidepanelComponent : ComponentBase
	{
        [Inject] protected ISidepanelService Sidepanel { get; set; }

		[Parameter]
        public RenderFragment ChildContent { get; set; }

        [Parameter]
        public string Title { get; set; }

        [Parameter]
        public string SubTitle { get; set; }

		public void Open()
        {
            Sidepanel.Open(Title, ChildContent, SubTitle);
        }

        public void Close()
        {
            Sidepanel.Close();
        }
	}
}
