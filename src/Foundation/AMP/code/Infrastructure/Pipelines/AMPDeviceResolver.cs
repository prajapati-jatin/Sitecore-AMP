using Sitecore.Data;
using Sitecore.Data.Items;
using Sitecore.Diagnostics;
using Sitecore.Pipelines.HttpRequest;
using Sitecore.Sites;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace Sitecore.Foundation.AMP.Infrastructure.Pipelines
{
    public class AMPDeviceResolver : HttpRequestProcessor
    {
        public AMPDeviceResolver() { }

        public override void Process(HttpRequestArgs args)
        {
            Assert.ArgumentNotNull(args, nameof(args));
            using (ProfileSection profileSection = new ProfileSection("Resolve AMP device."))
            {
                Database database = Context.Database;
                SiteContext site = Context.Site;
                if (database != null)
                {
                    //Get the ampDevice from Site context
                    if (site.Properties[Constants.AMPDevice] != null)
                    {
                        DeviceItem deviceItem = database.Resources.Devices[site.Properties[Constants.AMPDevice]];
                        if (Context.RawUrl.ToLower().EndsWith(Constants.AMPPrefix))
                        {
                            Context.Device = deviceItem;
                            Tracer.Info(String.Format("Device set to \"{0}\".", deviceItem.Name));
                        }
                    }
                }
            }
        }
    }
}