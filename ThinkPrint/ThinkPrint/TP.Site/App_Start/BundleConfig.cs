using System.Web;
using System.Web.Optimization;

namespace TP.Site
{
    public class BundleConfig
    {
        // 有关绑定的详细信息，请访问 http://go.microsoft.com/fwlink/?LinkId=301862
        public static void RegisterBundles(BundleCollection bundles)
        {
            bundles.Add(new ScriptBundle("~/bundles/jquery").Include(
                        "~/Scripts/jquery-{version}.js"));

            bundles.Add(new ScriptBundle("~/bundles/jqueryval").Include(
                        "~/Scripts/jquery.validate*"));

            // 使用要用于开发和学习的 Modernizr 的开发版本。然后，当你做好
            // 生产准备时，请使用 http://modernizr.com 上的生成工具来仅选择所需的测试。
            bundles.Add(new ScriptBundle("~/bundles/modernizr").Include(
                        "~/Scripts/modernizr-*"));

            bundles.Add(new ScriptBundle("~/bundles/bootstrap").Include(
                      "~/Scripts/bootstrap.js",
                      "~/Scripts/respond.js"));

            bundles.Add(new ScriptBundle("~/bundles/backstretch").Include(
                     "~/Scripts/jquery.backstretch.js"));

            bundles.Add(new ScriptBundle("~/bundles/slidebars").Include(
                      "~/Scripts/jquery.metisMenu.js",
                      "~/Scripts/jquery.scrollTo.js",
                     "~/Scripts/slidebars.js"));

            bundles.Add(new ScriptBundle("~/bundles/initScript").Include(
                  "~/Scripts/json2.js",
                 "~/JS/Shared/sharedScript.js",
                 "~/JS/Shared/defaultDeleteScript.js"
           ));

             bundles.Add(new ScriptBundle("~/bundles/login").Include(
                     "~/JS/login.js"));


            bundles.Add(new StyleBundle("~/Content/css").Include(
                      "~/Content/bootstrap.css",
                      "~/Content/font-awesome.css",
                      "~/Content/slidebars.css",
                      "~/Content/site.css",
                      "~/Content/style-responsive.css",
                      "~/Content/bootstrap-reset.css"
                      ));

            // 将 EnableOptimizations 设为 false 以进行调试。有关详细信息，
            // 请访问 http://go.microsoft.com/fwlink/?LinkId=301862
            BundleTable.EnableOptimizations = false;
        }
    }
}
