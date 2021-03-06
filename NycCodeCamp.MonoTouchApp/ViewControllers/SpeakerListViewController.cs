using System;
using System.Linq;
using CodeCamp.Core.Entities;
using System.Collections.Generic;
using MonoTouch.UIKit;

namespace NycCodeCamp.MonoTouchApp
{
	public class SpeakerListViewController : ListControllerBase
	{
		private IList<Speaker> _speakers;
		
		public SpeakerListViewController(IList<Speaker> speakers)
		{
			_speakers = speakers;
		}
		
		public override void ViewDidLoad()
		{
			base.ViewDidLoad ();
			
			Title = "Speakers";
			TableView.Source = new SpeakerTableViewSource(this, _speakers);
		}
		
		private class SpeakerTableViewSource : UITableViewSource
		{
			private IList<Speaker> _speakers;
			private SpeakerListViewController _hostController;
			private const string SPEAKER_CELL = "speakerCell";
			
			public SpeakerTableViewSource (SpeakerListViewController hostController, IList<Speaker> speakers)
			{
				_speakers = speakers.OrderBy(speaker => speaker.Name).ToList();
				_hostController = hostController;
			}
			
			public override int RowsInSection(UITableView tableview, int section)
			{
				return _speakers.Count;
			}

			public override UITableViewCell GetCell(UITableView tableView, MonoTouch.Foundation.NSIndexPath indexPath)
			{
				var cell = tableView.DequeueReusableCell(SPEAKER_CELL)
							?? new UITableViewCell(UITableViewCellStyle.Default, SPEAKER_CELL);
				var speaker = _speakers[indexPath.Row];
				
				cell.TextLabel.Text = speaker.Name;
				cell.Accessory = UITableViewCellAccessory.DisclosureIndicator;
				cell.BackgroundView = new UIView(cell.Frame) { BackgroundColor = UIColor.White };
				
				return cell;
			}
			
			public override void RowSelected(UITableView tableView, MonoTouch.Foundation.NSIndexPath indexPath)
			{
				var selectedSpeaker = _speakers[indexPath.Row];
				var speakerController = new SpeakerViewController(selectedSpeaker);
				
				_hostController.NavigationController.PushViewController(
					speakerController, true);
			}
			
			public override float GetHeightForRow(UITableView tableView, MonoTouch.Foundation.NSIndexPath indexPath)
			{
				return 55;
			}
		}
	}
}

