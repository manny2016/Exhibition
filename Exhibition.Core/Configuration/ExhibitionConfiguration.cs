
namespace Exhibition.Core.Configuration
{
    using System;
    using System.IO;
    using Exhibition.Core.Models;
    using System.Collections.Generic;
    using System.Linq;
    using System.ServiceModel;
    using Exhibition.Core.Services;
    using static Exhibition.Core.CrosEnabledService.CorsEnabledServiceHostFactory;
    using Exhibition.Core.CrosEnabledService;
    using System.ServiceModel.Description;

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
                settings = GetDefaultSettings();
                Update(settings);
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
                    new Locator() { Name="01", DisplayName="法制课件", Root=@"assets\法制课件" },
                    new Locator(){ Name="02", DisplayName="青少年权益保护协会", Root = @"assets\青少年权益保护协会"},
                    new Locator() { Name="03",DisplayName="法制小视频", Root = @"assets\法制小视频" },
                    new Locator() { Name ="04",DisplayName="九韵少年司法", Root = @"assets\九韵少年司法"}
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
        private static Navigation LoadResource(Locator locator)
        {
            var navigation = new Navigation()
            {
                Name = locator.Name,
                DisplayName = locator.DisplayName,
                ResLocation = locator.Root,
                Children = new Navigation[] { }
            };
            var root = Path.Combine(Environment.CurrentDirectory, locator.Root);
            var directories = Directory.GetDirectories(root);
            if (directories != null && directories.Count() > 0)
            {
                navigation.Children = directories.Select(o =>
                {
                    var images = new List<Resource>();
                    var h5 = new List<Resource>();
                    var sub = new Navigation() { Name = o.Replace(root, string.Empty).TrimStart('\\'), DisplayName = o.Replace(root, string.Empty).TrimStart('\\') };
                    sub.ResLocation = o;
                    var nonImageCollection = Directory.GetFiles(sub.ResLocation).Select(file =>
                    {
                        var fileInfo = new FileInfo(file);
                        return new Resource()
                        {
                            FullName = file,
                            Name = fileInfo.Name,
                            Type = PredicateResourceType(fileInfo)
                        };
                    }).Where(resource => resource.Type != ResourceType.NotSupport).ToArray();//获取视频 PPT，文件集合
                    if (IsSpecificFolder(new DirectoryInfo(o), Constants.EXTENSION_IMAGE_RESOURCE))
                    {
                        var imagedir = new DirectoryInfo(o);
                        images.Add(new Resource()
                        {
                            Name = imagedir.Name.Split('-')[1],
                            Type = ResourceType.ImageFolder,
                            FullName = sub.ResLocation,
                            ImageUrl = imagedir.GetFiles()[0].FullName
                        });
                    }

                    var list = new List<Resource>();
                    list.AddRange(nonImageCollection);
                    list.AddRange(images);
                    sub.Resources = list.ToArray();
                    return sub;
                }).ToArray();
            }
            return navigation;

        }

        private static ResourceType PredicateResourceType(FileInfo info)
        {
            if (Constants.EXTENSION_VIDEO_RESOURCE.Any(o => o.Equals(info.Extension, StringComparison.OrdinalIgnoreCase)))
                return ResourceType.Video;
            if (Constants.EXTENSION_POWERPOINT_RESOURCE.Any(o => o.Equals(info.Extension, StringComparison.OrdinalIgnoreCase)))
                return ResourceType.PowerPoint;
            if (Constants.EXTENSION_WORD_RESOURCE.Any(o => o.Equals(info.Extension, StringComparison.OrdinalIgnoreCase)))
                return ResourceType.Word;
            if (Constants.EXTENSION_WEBPAGE_PAGE_RESOURCE.Any(o => o.Equals(info.Extension, StringComparison.OrdinalIgnoreCase)))
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

            var host = new CorsEnabledServiceHost(typeof(OperationService));
            host.Opened += delegate
            {
                Console.WriteLine("Operation Service has begun to listen ... ...");
            };
            host.Open();
        }


    }
}
