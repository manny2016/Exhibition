
namespace Exhibition.Core.Configuration
{
    using System;
    using System.IO;
    using Exhibition.Core.Models;
    using System.Collections.Generic;
    using System.Linq;
    using System.ServiceModel;
    using Exhibition.Core.Services;

    public static class ExhibitionConfiguration
    {
        const string PATH_SETTINGS = @"Configuration";
        const string FILENAME_SETTINGS = "settings.json";

        static readonly string[] EXTENSION_VIDEO_RESOURCE = new string[] { ".avi", ".mp4", ".mpeg" };
        static readonly string[] EXTENSION_POWERPOINT_RESOURCE = new string[] { ".ppt", ".pptx" };
        static readonly string[] EXTENSION_WORD_RESOURCE = new string[] { ".word", ".word" };

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
                    new Locator() { Name="01", DisplayName="法制课件", Root=@"Resources\法制课件" },
                    new Locator(){ Name="02", DisplayName="青少年权益保护协会", Root = @"Resources\青少年权益保护协会"},
                    new Locator() { Name="03",DisplayName="法制小视频", Root = @"Resources\法制小视频" },
                    new Locator() { Name ="04",DisplayName="九韵少年司法", Root = @"Resources\九韵少年司法"}
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
                    }).ToArray();//获取视频 PPT，文件集合
                    var images = Directory.GetDirectories(sub.ResLocation).Select(directory =>
                    {
                        var resource = new Resource()
                        {
                            FullName = directory,
                            Name = directory.Replace(sub.ResLocation, string.Empty).TrimStart('\\'),
                            Type = ResourceType.ImageFolder
                        };
                        return resource;
                    }).ToArray();
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
            if (EXTENSION_VIDEO_RESOURCE.Any(o => o.Equals(info.Extension, StringComparison.OrdinalIgnoreCase)))
                return ResourceType.Video;
            if (EXTENSION_POWERPOINT_RESOURCE.Any(o => o.Equals(info.Extension, StringComparison.OrdinalIgnoreCase)))
                return ResourceType.PowerPoint;
            if (EXTENSION_WORD_RESOURCE.Any(o => o.Equals(info.Extension, StringComparison.OrdinalIgnoreCase)))
                return ResourceType.Word;
            return ResourceType.NotSupport;
        }

        private static ServiceHost host = null;

        public static void HostOperationSerivceViaConfiguration()
        {
            host = new ServiceHost(typeof(OperationService));
            host.Opened += delegate
            {
                Console.WriteLine("Operation Service has begun to listen ... ...");
            };
            host.Open();
            //using (ServiceHost calculatorSerivceHost = new ServiceHost(typeof(OperationService)))
            //{
            //    calculatorSerivceHost.Opened += delegate
            //    {
            //        Console.WriteLine("Calculator Service has begun to listen ... ...");
            //    };

            //    calculatorSerivceHost.Open();
            //    Console.Read();
            //}
        }


    }
}
