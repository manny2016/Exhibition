using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Drawing;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading;
using System.Threading.Tasks;

namespace Exhibition.Core.Utilities
{
    public class CaptureFrame
    {
        public static string Capture(string relativeVideoName, Size size, int cutTimeFrame)
        {
            var fullName = Path.Combine(Environment.CurrentDirectory, relativeVideoName);
            var thumbnail = fullName.Replace(new FileInfo(fullName).Extension, ".jpg");
            if (File.Exists(thumbnail)) return thumbnail;

            var formatSize = $"{size.Width}*{size.Height}";
            var ffmpeg = Path.Combine(Environment.CurrentDirectory, "ffmpeg", "ffmpeg.exe");

            var startInfo = new ProcessStartInfo(ffmpeg);
            startInfo.WindowStyle = ProcessWindowStyle.Hidden;
            startInfo.Arguments = " -i " + fullName + " -y -f image2 -ss " + cutTimeFrame + " -t 0.001 -s " + formatSize + " " + thumbnail;
            try
            {
                Process.Start(startInfo);
                Thread.Sleep(1000);
                return thumbnail;
            }
            catch (Exception re)
            {
                return string.Empty;
            }
        }
    }
}
