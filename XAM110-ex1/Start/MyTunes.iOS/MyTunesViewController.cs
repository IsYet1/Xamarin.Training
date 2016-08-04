using UIKit;
using System.Linq;

namespace MyTunes
{
	public class MyTunesViewController : UITableViewController
	{
		public override void ViewDidLayoutSubviews()
		{
			base.ViewDidLayoutSubviews();

			if (UIDevice.CurrentDevice.CheckSystemVersion(7,0)) {
				TableView.ContentInset = new UIEdgeInsets (20, 0, 0, 0);
			}
		}

		async public override void ViewDidLoad()
		{
			//TableView.Source = new ViewControllerSource<string>(TableView) {
			//	DataSource = new string[] { "One", "Two", "Three" },
			//};

			base.ViewDidLoad();

            var songs = await SongLoader.Load();

            TableView.Source = new ViewControllerSource<Song>(TableView)
            {
                DataSource = songs.ToList(),
                TextProc = s=> s.Name,
                DetailTextProc = s => s.Artist + " - " + s.Album,
            };
            
		}
	}

}

