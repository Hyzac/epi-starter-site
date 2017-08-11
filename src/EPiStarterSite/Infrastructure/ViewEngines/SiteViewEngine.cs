using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Web;
using System.Web.Hosting;
using System.Web.Mvc;

namespace EPiStarterSite.Infrastructure.ViewEngines
{
    public class SiteViewEngine : RazorViewEngine
    {
        /*
         Placeholders:
         *      {2} - Name of the Mvc area
         *      {1} - Name of the controller
         *      {0} - Name of the action (name of the partial view)
         */

        public SiteViewEngine()
        {
            var featureFolders = new[]
                {
                    "~/Features/{0}.cshtml",
                    "~/Features/{1}{0}.cshtml",
                    "~/Features/{1}/{0}.cshtml",
                    "~/Features/{1}/Views/{0}.cshtml",
                    "~/Features/{1}/Views/{1}.cshtml",
                }
                .Union(SubFeatureFolders("~/Features"))
                .ToArray();

            ViewLocationFormats = ViewLocationFormats
                .Union(featureFolders)
                .ToArray();

            PartialViewLocationFormats = PartialViewLocationFormats
                .Union(featureFolders)
                .ToArray();
        }

        private IEnumerable<string> SubFeatureFolders(string rootFolder)
        {
            var rootPath = HostingEnvironment.MapPath(rootFolder);
            if (rootPath == null)
                return Enumerable.Empty<string>();

            var featureFolders = Directory.GetDirectories(rootPath)
                .Select(GetDirectory);

            var features = featureFolders.Select(a => new
            {
                a.Name,
                Features = Directory.GetDirectories(a.FullName)
                    .Select(GetDirectoryName)
            });

            return features.SelectMany(feature =>
            {
                return new[]
                    {
                        $"{rootFolder}/{feature.Name}/{{0}}.cshtml",
                        $"{rootFolder}/{feature.Name}/{{1}}{{0}}.cshtml",
                        $"{rootFolder}/{feature.Name}/Views/{{1}}{{0}}.cshtml",
                        $"{rootFolder}/{feature.Name}/Views/{{1}}/{{0}}.cshtml"
                    }
                    .Union(
                        feature.Features
                            .SelectMany(subFfeature => new[]
                            {
                                $"{rootFolder}/{feature.Name}/{subFfeature}/{{0}}.cshtml",
                                $"{rootFolder}/{feature.Name}/{subFfeature}/{{1}}{{0}}.cshtml",
                                $"{rootFolder}/{feature.Name}/{subFfeature}/Views/{{1}}/{{0}}.cshtml",
                                $"{rootFolder}/{feature.Name}/{subFfeature}/Views/{{1}}{{0}}.cshtml"
                            }));
            });
        }

        private string GetDirectoryName(string path)
        {
            return GetDirectory(path).Name;
        }

        private DirectoryInfo GetDirectory(string path)
        {
            return new DirectoryInfo(path);
        }
    }
}