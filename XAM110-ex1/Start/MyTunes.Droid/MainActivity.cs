using Android.App;
using Android.OS;
using System.Linq;

namespace MyTunes
{
	[Activity(Label = "@string/app_name", MainLauncher = true, Icon = "@drawable/icon")]
	public class MainActivity : ListActivity
	{
		async protected override void OnCreate(Bundle bundle)
		{
			base.OnCreate(bundle);

            var data = await SongLoader.Load();
            
            ListAdapter = new ListAdapter<Song>()
            {
                DataSource = data.ToList(),
                TextProc = s=> s.Name,
                DetailTextProc = s=> s.Artist + " - " + s.Album,
            };

			//ListAdapter = new ListAdapter<string>() {
			//	DataSource = new[] { "One", "Two", "Three" }
			//};


		}
	}
}


