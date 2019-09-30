using System.IO;
using System.Threading.Tasks;
using Android;
using Android.Content;
using Android.Media;
using Android.Support.V4.App;
using Android.Support.V4.Content;
using Java.IO;

using Xamarin.Forms;
using XDemo.Droid;
using XDemo.Paint;
using Environment = Android.OS.Environment;
using File = Java.IO.File;

[assembly: Dependency(typeof(PhotoLibrary))]
namespace XDemo.Droid
{
    public class PhotoLibrary : IPhotoLibrary
    {

        public Task<System.IO.Stream> PickPhotoAsync()
        {
            // Define the Intent for getting images
            Intent intent = new Intent();
            intent.SetType("image/*");
            intent.SetAction(Intent.ActionGetContent);

            // Start the picture-picker activity (resumes in MainActivity.cs)
            MainActivity.Instance.StartActivityForResult(
                Intent.CreateChooser(intent, "Select Picture"),
                MainActivity.PickImageId);

            // Save the TaskCompletionSource object as a MainActivity property
            MainActivity.Instance.PickImageTaskCompletionSource = new TaskCompletionSource<System.IO.Stream>();

            // Return Task object
            return MainActivity.Instance.PickImageTaskCompletionSource.Task;
        }


        public async Task<bool> SavePhotoAsnyc(byte[] data, string folder, string filename)
        {
            try
            {
                if (ContextCompat.CheckSelfPermission(MainActivity.Instance, Manifest.Permission.WriteExternalStorage) != PermissionChecker.PermissionGranted)
                {
                    ActivityCompat.RequestPermissions(MainActivity.Instance, new string[] { Manifest.Permission.WriteExternalStorage }, 1000);
                }


                File picturesDirectory = Environment.GetExternalStoragePublicDirectory(Environment.DirectoryPictures);
                File folderDirectory;

                if (!string.IsNullOrEmpty(folder))
                {
                    folderDirectory = new File(picturesDirectory.ToString(), folder);
                    folderDirectory.Mkdirs();
                }
                else
                {
                    folderDirectory = picturesDirectory;
                }

                using (File bitmapFile = new File("/storage/emulated/0/Download", filename))
                {
                    bitmapFile.CreateNewFile();

                    using (FileStream outputStream = new FileStream(bitmapFile.ToString(), FileMode.Open))
                    {


                        await outputStream.WriteAsync(data);
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
