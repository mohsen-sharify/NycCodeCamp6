using System;
using TinyMessenger;

namespace CodeCamp.Core.Messaging.Messages
{
	public class FoundUpdatedScheduleMessage : TinyMessageBase
	{
		public FoundUpdatedScheduleMessage(object sender)
			: base(sender)
		{
		}
	}
}

