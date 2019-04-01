
namespace Exhibition.Core.Configuration
{
    using System;
    using System.IO;
    using Exhibition.Core.Models;
    using System.Collections.Generic;
    using System.Linq;
    using System.ServiceModel;
    using Exhibition.Core.Services;

    using System.ServiceModel.Description;
    using Exhibition.Core.Utilities;

    public static class ExhibitionConfiguration
    {
        const string PATH_SETTINGS = @"Configuration";
        const string FILENAME_SETTINGS = "settings.json";





        public static Settings GetSettings()
        {
            var settings = new Settings();
            var path = Path.Combine(Environment.CurrentDirectory, PATH_SETTINGS);
            if (!Directory.Exists(path))
            {
                Directory.CreateDirectory(path);
            }
            if (!File.Exists(Path.Combine(Environment.CurrentDirectory, PATH_SETTINGS, FILENAME_SETTINGS)))
            {
                settings = GetDefaultSettings();
                Update(settings);
                return settings;
            }
            else
            {
                using (var stream = new FileStream(Path.Combine(Environment.CurrentDirectory, PATH_SETTINGS, FILENAME_SETTINGS), FileMode.Open, FileAccess.Read))
                {
                    var reader = new StreamReader(stream);
                    settings = reader.ReadToEnd().DeserializeToObject<Settings>();
                }

            }
            return settings;
        }
        private static Settings GetDefaultSettings()
        {
            var settings = new Settings()
            {
                DefaultMonitor = 2,
                Locates = new Locator[] {
                    new Locator() { Name="01-01", DisplayName=@"法制课件\预防校园欺凌", Root=@"assets\法制课件\预防校园欺凌" },
                    new Locator() { Name="01-02", DisplayName=@"法制课件\预防性侵", Root=@"assets\法制课件\预防性侵" },
                    new Locator() { Name="01-03", DisplayName=@"法制课件\预防毒品犯罪", Root=@"assets\法制课件\预防毒品犯罪" },
                    new Locator() { Name="01-04", DisplayName=@"法制课件\预防网络犯罪", Root=@"assets\法制课件\预防网络犯罪" },
                    new Locator() { Name="01-05", DisplayName=@"法制课件\预防网络犯罪", Root=@"assets\法制课件\其他法制宣传" },
                    new Locator() { Name="02", DisplayName=@"法制小视频", Root=@"assets\法制小视频" },
                    new Locator() { Name="03", DisplayName=@"氿韵少年司法", Root=@"assets\氿韵少年司法" },
                }
            };
            foreach (var locator in settings.Locates)
            {
                var path = Path.Combine(Environment.CurrentDirectory, locator.Root);
                if (!Directory.Exists(path))
                    Directory.CreateDirectory(path);
            }
            return settings;
        }
        static void Update(Settings settings)
        {
            var path = Path.Combine(Environment.CurrentDirectory, PATH_SETTINGS, FILENAME_SETTINGS);
            if (File.Exists(path))
            {
                File.Delete(path);
            }
            using (var stream = new FileStream(path, FileMode.Create))
            {
                var writer = new StreamWriter(stream);
                writer.Write(settings.SerializeToJson());
                writer.Flush();
            }
        }

        public static IEnumerable<Navigation> GenernateNavigations()
        {
            var settings = GetSettings();
            foreach (var locator in settings.Locates)
            {
                yield return LoadResource(locator);
            }
        }
        public static Navigation LoadResource(Locator locator)
        {
            var navigation = new Navigation()
            {
                Name = locator.Name,
                ResLocation = locator.Root,
                Resources = new Resource[] { }
            };
            var root = Path.Combine(Environment.CurrentDirectory, locator.Root);
            var directory = new DirectoryInfo(root);
            var resources = directory.GetFiles().Select((info) =>
            {
                var resource = new Resource();
                var type = PredicateResourceType(info.Extension);
                if (type == ResourceType.NotSupport) return null;
                var names = info.Name.Split('.')[0].Split('-');
                resource.FullName = info.FullName.Replace(Environment.CurrentDirectory, string.Empty).TrimStart('\\');
                resource.Name = info.Name;
                resource.DisplayName = names.Length > 1 ? names[1] : names[0];
                resource.Type = type;
                if (type == ResourceType.Video)
                {
                    resource.ImageUrl = CaptureFrame.Capture(resource.FullName, new System.Drawing.Size(640, 317), 10);
                }
                return resource;
            }).Where(resource => resource != null);

            var images = directory.GetDirectories()
                .Select(ctx =>
                {
                    var resource = new Resource();
                    if (ctx.GetFiles().All((info) =>
                    {
                        return Constants.EXTENSION_IMAGE_RESOURCE.Any(ex => ex.Equals(info.Extension, StringComparison.OrdinalIgnoreCase));
                    }))
                    {
                        var names = ctx.Name.Split('-');
                        resource.FullName = ctx.FullName.Replace(Environment.CurrentDirectory, string.Empty);
                        resource.Type = ResourceType.ImageFolder;
                        resource.Name = ctx.Name;
                        resource.DisplayName = names.Length > 1 ? names[1] : names[0];
                        return resource;
                    }
                    return null;
                })
                .Where(ctx => ctx != null);

            var merge = new List<Resource>();
            merge.AddRange(resources);
            merge.AddRange(images);
            navigation.Resources = merge.ToArray();
            return navigation;
        }

        private static ResourceType PredicateResourceType(string extension)
        {
            if (Constants.EXTENSION_VIDEO_RESOURCE.Any(o => o.Equals(extension, StringComparison.OrdinalIgnoreCase)))
                return ResourceType.Video;
            if (Constants.EXTENSION_POWERPOINT_RESOURCE.Any(o => o.Equals(extension, StringComparison.OrdinalIgnoreCase)))
                return ResourceType.PowerPoint;
            if (Constants.EXTENSION_WORD_RESOURCE.Any(o => o.Equals(extension, StringComparison.OrdinalIgnoreCase)))
                return ResourceType.Word;
            if (Constants.EXTENSION_WEBPAGE_PAGE_RESOURCE.Any(o => o.Equals(extension, StringComparison.OrdinalIgnoreCase)))
                return ResourceType.WebPage;
            return ResourceType.NotSupport;
        }


        public static bool IsSpecificFolder(DirectoryInfo directory, string[] extensions)
        {
            if (IsEmplyFolder(directory)) return false;
            return directory.GetFiles().All(info =>
            {
                return extensions.Any(o => o.Equals(info.Extension));
            });

        }
        private static bool IsEmplyFolder(DirectoryInfo directory)
        {
            if (directory.GetFiles() == null || directory.GetFiles().Count().Equals(0)) return true;
            return false;
        }

        private static ServiceHost host = null;

        public static void HostOperationSerivceViaConfiguration()
        {
            var host = new ServiceHost(typeof(OperationService));
            host.Opened += delegate
            {
                Console.WriteLine("Operation Service has begun to listen ... ...");
            };
            host.Open();
        }

        public static string GetEndpoint(string method, string key = "endpoint")
        {
            var url = System.Configuration.ConfigurationManager.AppSettings[key];
            if (string.IsNullOrEmpty(url))
                url = "http://localhost:8888/api/OperationService/{0}";

            return string.Format(url, method);
        }
    }
}
