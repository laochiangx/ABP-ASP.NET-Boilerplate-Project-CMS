using System.Web.Optimization;

namespace JCMS.Web
{
    public static class BundleConfig
    {
        public static void RegisterBundles(BundleCollection bundles)
        {
            bundles.IgnoreList.Clear();

            //ACCOUNT BUNDLES
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

            //~/Bundles/App/vendor/css
            bundles.Add(
                new StyleBundle("~/Bundles/App/vendor/css")
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
                    .Include("~/css/themes/all-themes.css", new CssRewriteUrlTransform())
                );

            //~/Bundles/App/vendor/js
            bundles.Add(
                new ScriptBundle("~/Bundles/App/vendor/js")
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
                        "~/lib/bootstrap-select/dist/js/bootstrap-select.js",
                        "~/lib/jquery-slimscroll/jquery.slimscroll.js",
                        "~/lib/Waves/dist/waves.js",
                        "~/lib/push.js/push.js",
                      
                        "~/Scripts/angular.min.js",
                        "~/Scripts/angular-animate.min.js",
                        "~/Scripts/angular-sanitize.min.js",
                        "~/Scripts/angular-ui-router.min.js",
                        "~/Scripts/angular-ui/ui-bootstrap.min.js",
                        "~/Scripts/angular-ui/ui-bootstrap-tpls.min.js",
                        "~/Scripts/angular-ui/ui-utils.min.js",

                        "~/Abp/Framework/scripts/abp.js",
                        "~/Abp/Framework/scripts/libs/abp.jquery.js",
                        "~/Abp/Framework/scripts/libs/abp.toastr.js",
                        "~/Abp/Framework/scripts/libs/abp.blockUI.js",
                        "~/Abp/Framework/scripts/libs/abp.spin.js",
                        "~/Abp/Framework/scripts/libs/abp.sweet-alert.js",
                        "~/Abp/Framework/scripts/libs/angularjs/abp.ng.js",

                        "~/js/admin.js",
                        "~/js/main.js",

                        "~/Scripts/jquery.signalR-2.2.1.min.js"
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
                        "~/lib/jquery-sparkline/dist/jquery.sparkline.js"
                    )
            );

            //APPLICATION RESOURCES

            //~/Bundles/App/Main/css
            bundles.Add(
                new StyleBundle("~/Bundles/App/Main/css")
                    .IncludeDirectory("~/App/Main", "*.css", true)
                );

            //~/Bundles/App/Main/js
            bundles.Add(
                new ScriptBundle("~/Bundles/App/Main/js")
                    .IncludeDirectory("~/Common/Scripts", "*.js", true)
                    .IncludeDirectory("~/App/Main", "*.js", true)
                );
        }
    }
}