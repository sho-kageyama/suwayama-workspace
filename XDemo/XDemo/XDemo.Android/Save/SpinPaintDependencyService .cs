using System;

using System.Threading.Tasks;
using Android.Media;
using Android.OS;
using Java.IO;
using XDemo.Paint;
using Xamarin.Forms;
using Environment = Android.OS.Environment;
using Android.Support.V4.Content;
using Android.Support.V4.App;
using Android;

[assembly: Dependency(typeof(XDemo.Droid.SpinPaintDependencyService))]
namespace XDemo.Droid
{
    public class SpinPaintDependencyService : ISpinPaintDependencyService
    {
        public async Task<bool> SaveBitmap(byte[] buffer, string filename)
        {
            try
            {
                if (ContextCompat.CheckSelfPermission(MainActivity.Instance, Manifest.Permission.WriteExternalStorage) != PermissionChecker.PermissionGranted)
                {
                    ActivityCompat.RequestPermissions(MainActivity.Instance, new string[] { Manifest.Permission.WriteExternalStorage }, 1000);
                }


                File picturesDirectory = Environment.GetExternalStoragePublicDirectory(Environment.DirectoryPictures);
                File spinPaintDirectory = new File(picturesDirectory, "SpinPaint");
                spinPaintDirectory.Mkdirs();

                using (File bitmapFile = new File(spinPaintDirectory, filename))
                {
                    bitmapFile.CreateNewFile();

                    using (FileOutputStream outputStream = new FileOutputStream(bitmapFile))
                    {
                        await outputStream.WriteAsync(buffer);
                    }

                    // Make sure it shows up in the Photos gallery promptly.
                    MediaScannerConnection.ScanFile(MainActivity.Instance,
                                                    new string[] { bitmapFile.Path },
                                                    new string[] { "image/png", "image/jpeg" }, null);
                }
            }
            catch
            {
                return false;
            }

            return true;
        }
    }
}