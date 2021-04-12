using Plugin.Media;
using Plugin.Media.Abstractions;

using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

using Xamarin.Forms;
namespace XF_UsingCamera_Sqlite
{
    public partial class MainPage : ContentPage
    {
        Users user = null;
        string picpath = "";
        public MainPage()
        {
            InitializeComponent();

        }

        private async void TakePhotoButton_OnClicked(object sender, EventArgs e)
        {
            await CrossMedia.Current.Initialize();
            if (!CrossMedia.Current.IsCameraAvailable || !CrossMedia.Current.IsTakePhotoSupported)
            {
                await DisplayAlert("No camera", ":(No camera available.", "Ok");
                return;
            }
            var file = await CrossMedia.Current.TakePhotoAsync(
                new StoreCameraMediaOptions
                {
                    SaveToAlbum = true,
                });
            if (file == null)
                return;
            picpath = file.AlbumPath;
            PathLabel.Text = picpath;

            MainImage.Source = ImageSource.FromStream(() =>
            {
                var stream = file.GetStream();
                file.Dispose();
                return stream;
            });
        }

        private async void PickPhotoButton_OnClicked(object sender, EventArgs e)
        {
            await CrossMedia.Current.Initialize();
            if (!CrossMedia.Current.IsPickPhotoSupported)
            {
                await DisplayAlert("Oops", "Picker photo is not support", "Ok");
                return;
            }
            var file = await CrossMedia.Current.PickPhotoAsync();
            if (file == null)
                return;
            picpath = file.AlbumPath;
            PathLabel.Text = picpath;
            MainImage.Source = ImageSource.FromStream(() =>
            {
                var stream = file.GetStream();
                file.Dispose();
                return stream;
            });
        }

        private async void TakeVideoButton_OnClicked(object sender, EventArgs e)
        {
            await CrossMedia.Current.Initialize();
            if (!CrossMedia.Current.IsCameraAvailable || !CrossMedia.Current.IsTakePhotoSupported)
            {
                await DisplayAlert("No camera", ":(No camera available.", "Ok");
                return;
            }
            var file = await CrossMedia.Current.TakeVideoAsync(
                new StoreVideoOptions
                {
                    SaveToAlbum = true,


                    Quality = VideoQuality.Medium,
                });
            if (file == null)
                return;
            picpath = file.AlbumPath;
            PathLabel.Text = picpath;
            MainImage.Source = ImageSource.FromStream(() =>
            {
                var stream = file.GetStream();
                file.Dispose();
                return stream;
            });
        }

        private async void PickVideoButton_OnClicked(object sender, EventArgs e)
        {
            await CrossMedia.Current.Initialize();
            if (!CrossMedia.Current.IsPickVideoSupported)
            {
                await DisplayAlert("Oops", "Picker Video is not support", "Ok");
                return;
            }
            var file = await CrossMedia.Current.PickVideoAsync();
            if (file == null)
                return;

            picpath = file.AlbumPath;
            PathLabel.Text = picpath;
            MainImage.Source = ImageSource.FromStream(() =>
            {
                var stream = file.GetStream();
                file.Dispose();
                return stream;
            });
        }

        private async void CreateAccount_Clicked(object sender, EventArgs e)
        {
            if (!string.IsNullOrEmpty(Username.Text))
            {
                user = new Users()
                {
                    Username = Username.Text,
                    PicturesPath = picpath
                };

                //Add New Users
                await App.SQLiteObj.SaveItemAsync(user);


            }
        }
    }
}
