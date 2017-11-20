using System.Web.Optimization;

namespace ABPCMS.Web
{
    public static class BundleConfig
    {
        public static void RegisterBundles(BundleCollection bundles)
        {
            bundles.IgnoreList.Clear();

            bundles.Add(
                new StyleBundle("~/Bundles/account-vendor/css")
                    .Include("~/fonts/roboto/roboto.css", new CssRewriteUrlTransform())
                    .Include("~/fonts/material-icons/materialicons.css", new CssRewriteUrlTransform())
                    .Include("~/lib/bootstrap/dist/css/bootstrap.css", new CssRewriteUrlTransform())
                    .Include("~/lib/toastr/toastr.css", new CssRewriteUrlTransform())
                    .Include("~/lib/sweetalert/dist/sweetalert.css", new CssRewriteUrlTransform())
                    .Include("~/lib/famfamfam-flags/dist/sprite/famfamfam-flags.css", new CssRewriteUrlTransform())
                    .Include("~/lib/font-awesome/css/font-awesome.css", new CssRewriteUrlTransform())
                    .Include("~/lib/Waves/dist/waves.css", new CssRewriteUrlTransform())
                    .Include("~/lib/animate.css/animate.css", new CssRewriteUrlTransform())
                    .Include("~/css/materialize.css", new CssRewriteUrlTransform())
                    .Include("~/css/style.css", new CssRewriteUrlTransform())
                    .Include("~/Views/Account/_Layout.css", new CssRewriteUrlTransform())
            );

            bundles.Add(
                new ScriptBundle("~/Bundles/account-vendor/js/bottom")
                    .Include(
                        "~/lib/json2/json2.js",
                        "~/lib/jquery/dist/jquery.js",
                        "~/lib/bootstrap/dist/js/bootstrap.js",
                        "~/lib/moment/min/moment-with-locales.js",
                        "~/lib/jquery-validation/dist/jquery.validate.js",
                        "~/lib/blockUI/jquery.blockUI.js",
                        "~/lib/toastr/toastr.js",
                        "~/lib/sweetalert/dist/sweetalert-dev.js",
                        "~/lib/spin.js/spin.js",
                        "~/lib/spin.js/jquery.spin.js",
                        "~/lib/Waves/dist/waves.js",
                        "~/lib/abp-web-resources/Abp/Framework/scripts/abp.js",
                        "~/lib/abp-web-resources/Abp/Framework/scripts/libs/abp.jquery.js",
                        "~/lib/abp-web-resources/Abp/Framework/scripts/libs/abp.toastr.js",
                        "~/lib/abp-web-resources/Abp/Framework/scripts/libs/abp.blockUI.js",
                        "~/lib/abp-web-resources/Abp/Framework/scripts/libs/abp.spin.js",
                        "~/lib/abp-web-resources/Abp/Framework/scripts/libs/abp.sweet-alert.js",
                        "~/js/admin.js",
                        "~/js/main.js"
                    )
            );

            //VENDOR RESOURCES

            //~/Bundles/vendor/css
            bundles.Add(
                new StyleBundle("~/Bundles/vendor/css")
                .Include("~/fonts/roboto/roboto.css", new CssRewriteUrlTransform())
                .Include("~/fonts/material-icons/materialicons.css", new CssRewriteUrlTransform())
                .Include("~/lib/bootstrap/dist/css/bootstrap.css", new CssRewriteUrlTransform())
                .Include("~/lib/bootstrap-select/dist/css/bootstrap-select.css", new CssRewriteUrlTransform())
                .Include("~/lib/toastr/toastr.css", new CssRewriteUrlTransform())
                .Include("~/lib/sweetalert/dist/sweetalert.css", new CssRewriteUrlTransform())
                .Include("~/lib/famfamfam-flags/dist/sprite/famfamfam-flags.css", new CssRewriteUrlTransform())
                .Include("~/lib/font-awesome/css/font-awesome.css", new CssRewriteUrlTransform())
                .Include("~/lib/Waves/dist/waves.css", new CssRewriteUrlTransform())
                .Include("~/lib/animate.css/animate.css", new CssRewriteUrlTransform())
                .Include("~/css/materialize.css", new CssRewriteUrlTransform())
                .Include("~/css/style.css", new CssRewriteUrlTransform())
                .Include("~/css/themes/all-themes.css", new CssRewriteUrlTransform())
                .Include("~/Views/Shared/_Layout.css", new CssRewriteUrlTransform())
            );

            //~/Bundles/vendor/bottom (Included in the bottom for fast page load) 模板页
            bundles.Add(
                new ScriptBundle("~/Bundles/vendor/js/bottom")
                    .Include(
                        "~/lib/json2/json2.js",
                         "~/Scripts/jquery-2.2.0.js",
                        "~/lib/jquery/dist/jquery.js",
                        "~/lib/bootstrap/dist/js/bootstrap.js",
                        "~/Scripts/Content/bootstrap-table/bootstrap-table.js",
                        "~/Scripts/Content/bootstrap-table/locale/bootstrap-table-zh-CN.js",
                        "~/lib/moment/min/moment-with-locales.js",
                        "~/lib/jquery-validation/dist/jquery.validate.js",
                        "~/lib/blockUI/jquery.blockUI.js",
                        "~/lib/toastr/toastr.js",
                        "~/lib/sweetalert/dist/sweetalert-dev.js",
                        "~/lib/spin.js/spin.js",
                        "~/lib/spin.js/jquery.spin.js",
                        "~/lib/bootstrap-select/dist/js/bootstrap-select.js",
                        "~/lib/jquery-slimscroll/jquery.slimscroll.js",
                        "~/lib/Waves/dist/waves.js",
                        "~/lib/push.js/push.js",
                        "~/lib/abp-web-resources/Abp/Framework/scripts/abp.js",
                        "~/lib/abp-web-resources/Abp/Framework/scripts/libs/abp.jquery.js",
                        "~/lib/abp-web-resources/Abp/Framework/scripts/libs/abp.toastr.js",
                        "~/lib/abp-web-resources/Abp/Framework/scripts/libs/abp.blockUI.js",
                        "~/lib/abp-web-resources/Abp/Framework/scripts/libs/abp.spin.js",
                        "~/lib/abp-web-resources/Abp/Framework/scripts/libs/abp.sweet-alert.js",
                        "~/js/admin.js",
                        "~/js/main.js",
                        "~/Views/Shared/_Layout.js",
                        "~/lib/signalr/jquery.signalR.js"
 
                    )
                );

            //Home-Index Bundles
            bundles.Add(
                new ScriptBundle("~/Bundles/home-index")
                    .Include(
                        "~/lib/jquery-countTo/jquery.countTo.js",
                        "~/lib/raphael/raphael.js",
                        "~/lib/morris.js/morris.js",
                        "~/lib/chart.js/dist/Chart.bundle.js",
                        "~/lib/Flot/jquery.flot.js",
                        "~/lib/Flot/jquery.flot.resize.js",
                        "~/lib/Flot/jquery.flot.pie.js",
                        "~/lib/Flot/jquery.flot.categories.js",
                        "~/lib/Flot/jquery.flot.time.js",
                        "~/lib/jquery-sparkline/dist/jquery.sparkline.js",
                        "~/Views/Home/Index.js"
                    )
            );

            //APPLICATION RESOURCES

            //~/Bundles/css
            bundles.Add(
                new StyleBundle("~/Bundles/css")
                    .Include("~/css/main.css")
                );
        }
    }
}