using System.Web.Optimization;

namespace JW2005
{
    public class BundleConfig
    {
        // For more information on bundling, visit http://go.microsoft.com/fwlink/?LinkId=301862
        public static void RegisterBundles(BundleCollection bundles)
        {
            bundles.Add(new ScriptBundle("~/Bundles/jquery").Include("~/Scripts/jquery-{version}.js"));

            // Use the development version of Modernizr to develop with and learn from. Then, when you're
            // ready for production, use the build tool at http://modernizr.com to pick only the tests you need.
            bundles.Add(new ScriptBundle("~/Bundles/modernizr").Include("~/Scripts/modernizr-{version}.js"));

            bundles.Add(new ScriptBundle("~/Bundles/bootstrap").Include("~/Scripts/bootstrap.js"));

            bundles.Add(new StyleBundle("~/Content/bootstrap").Include(
                "~/Content/bootstrap.css",
                "~/Content/font-awesome.css"));

            bundles.Add(new StyleBundle("~/Content/site-windows").Include(
                "~/Content/site.css",
                "~/Content/site-windows.css"));

            bundles.Add(new StyleBundle("~/Content/site-osx").Include(
                "~/Content/site.css",
                "~/Content/site-osx.css"));

            bundles.Add(new StyleBundle("~/Content/site-linux").Include(
                "~/Content/site.css",
                "~/Content/site-linux.css"));
        }
    }
}