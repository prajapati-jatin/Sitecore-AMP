using Sitecore.Diagnostics;
using Sitecore.Mvc.Extensions;
using Sitecore.Mvc.Presentation;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace Sitecore.Foundation.AMP.Mvc.Helpers
{
    public class AMPHelper
    {
        public virtual Sitecore.Data.Items.Item CurrentItem
        {
            get
            {
                Rendering currentRendering = this.CurrentRendering;
                if(currentRendering == null)
                {
                    return PageContext.Current.Item;
                }
                return currentRendering.Item;
            }
        }

        public virtual Rendering CurrentRendering
        {
            get
            {
                return RenderingContext.CurrentOrNull.ValueOrDefault<RenderingContext, Rendering>((RenderingContext context) => context.Rendering);
            }
        }

        protected HtmlHelper HtmlHelper
        {
            get;set;
        }

        public AMPHelper(HtmlHelper htmlHelper)
        {
            Assert.ArgumentNotNull(htmlHelper, nameof(htmlHelper));
            this.HtmlHelper = htmlHelper;
        }
    }
}