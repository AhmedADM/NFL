﻿using System.Web;
using System.Web.Optimization;

namespace NFL
{
    public class BundleConfig
    {
        // For more information on bundling, visit http://go.microsoft.com/fwlink/?LinkId=301862
        public static void RegisterBundles(BundleCollection bundles)
        {
            bundles.Add(new ScriptBundle("~/bundles/jquery").Include(
                        "~/Scripts/jquery-{version}.js"));

            bundles.Add(new ScriptBundle("~/bundles/jqueryval").Include(
                        "~/Scripts/jquery.validate*"));

            bundles.Add(new ScriptBundle("~/bundles/jqueryUnobtrusiveAjax").Include(
                        "~/Scripts/jquery.unobtrusive-*"));

            // Use the development version of Modernizr to develop with and learn from. Then, when you're
            // ready for production, use the build tool at http://modernizr.com to pick only the tests you need.
            bundles.Add(new ScriptBundle("~/bundles/modernizr").Include(
                        "~/Scripts/modernizr-*"));

            bundles.Add(new ScriptBundle("~/bundles/bootstrap").Include(
                      "~/Scripts/bootstrap.js",
                      "~/Scripts/respond.js"));

           

            bundles.Add(new StyleBundle("~/Content/css").Include(
                      "~/Content/bootstrap.css",
                      "~/Content/site.css"));


            //Additional Liberaries

            //Bootstap Datepicker
            bundles.Add(new ScriptBundle("~/bundles/bootstrap-datepickerJS").Include(
                     "~/Scripts/bootstrap-datepicker.js"));


            bundles.Add(new StyleBundle("~/bundles/bootstrap-datepickerCSS").Include(
                          "~/Content/bootstrap-datepicker.css"));


            //Bootbox
            bundles.Add(new ScriptBundle("~/bundles/BootboxJS").Include(
                   "~/Scripts/bootbox.js"));



        }
    }
}