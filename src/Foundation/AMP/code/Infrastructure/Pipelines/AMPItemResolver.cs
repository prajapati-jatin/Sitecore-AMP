using Sitecore.Abstractions;
using Sitecore.Configuration;
using Sitecore.Data.ItemResolvers;
using Sitecore.Data.Items;
using Sitecore.Diagnostics;
using Sitecore.Pipelines.HttpRequest;
using Sitecore.SecurityModel;
using Sitecore.Sites;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace Sitecore.Foundation.AMP.Infrastructure.Pipelines
{
    /// <summary>
    /// Resolves the Sitecore item from the URL of the page.
    /// </summary>
    public class AMPItemResolver : HttpRequestProcessor
    {
        public override void Process(HttpRequestArgs args)
        {
            Assert.ArgumentNotNull(args, nameof(args));
            using(ProfileSection profileSection = new ProfileSection("Resolve Sitecore item from AMP URL."))
            {
                var localPath = args.LocalPath.ToLower();
                if (!String.IsNullOrEmpty(localPath) && args.LocalPath.StartsWith(Constants.AMPPrefix))
                {
                    var path = localPath.Replace(Constants.AMPPrefix, Constants.URLSepatator);
                    var itemPath = String.Format("{0}{1}", Sitecore.Context.Site.StartPath, path);
                    Sitecore.Data.Items.Item item = Sitecore.Context.Database.GetItem(itemPath);
                    if (item != null)
                    {
                        Sitecore.Context.Item = item;
                        Tracer.Info($"Item resolved from AMP URL: {localPath}");
                    }
                    else
                    {
                        Tracer.Warning($"No item found from AMP URL: {localPath}");
                    }
                }
            }
        }
    }
}