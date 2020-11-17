using System.Web;
using System.Web.Optimization;

namespace WiseBet
{
    public class BundleConfig
    {
        // For more information on bundling, visit https://go.microsoft.com/fwlink/?LinkId=301862
        public static void RegisterBundles(BundleCollection bundles)
        {
            bundles.Add(new ScriptBundle("~/bundles/jquery").Include(
                        "~/Scripts/jquery-1.12.4.min.js"));

           // bundles.Add(new ScriptBundle("~/bundles/jqueryval").Include(
            //            "~/Scripts/jquery.validate*"));

            // Use the development version of Modernizr to develop with and learn from. Then, when you're
            // ready for production, use the build tool at https://modernizr.com to pick only the tests you need.
            bundles.Add(new ScriptBundle("~/bundles/modernizr").Include(
                        "~/Scripts/modernizr-3.7.1.min.js"));

            bundles.Add(new ScriptBundle("~/bundles/bootstrap").Include(
                      "~/Scripts/popper.min.js",
                      "~/Scripts/bootstrap.min.js"));

            bundles.Add(new ScriptBundle("~/bundles/js").Include(
                      "~/Scripts/plugins.js",
                      "~/Scripts/slick.min.js",
                      "~/Scripts/ajax-contact.js",
                      "~/Scripts/waypoints.min.js",
                      "~/Scripts/jquery.counterup.min.js",
                      "~/Scripts/jquery.magnific-popup.min.js",
                      "~/Scripts/jquery.easing.min.js",
                      "~/Scripts/scrolling-nav.js",
                      "~/Scripts/wow.min.js",
                      "~/Scripts/particles.min.js",
                      "~/Scripts/main.js"));

            bundles.Add(new StyleBundle("~/Content/css").Include(
                      "~/Content/animate.css",
                      "~/Content/bootstrap.min.css",
                      "~/Content/font-awesome.min.css",
                      "~/Content/LineIcons.css",
                      "~/Content/magnific-popup.css",
                      "~/Content/slick.css",
                      "~/Content/default.css",
                      "~/Content/style.css"));

            bundles.Add(new StyleBundle("~/Content/xml").Include(
                      "~/Content/xml/lotto1.xml"));
        }
    }
}
