namespace ExBuddy.Logging
{
	using ExBuddy.Interfaces;
	using System.Windows.Media;

	public class LogColors : ILogColors
	{
		#region ILogColors Members

		public virtual Color Error
		{
			get { return Colors.Red; }
		}

		public virtual Color Info
		{
			get { return Colors.DarkKhaki; }
	    }

	    public virtual Color Warn
	    {
	        get { return Colors.PaleVioletRed; }
	    }

	    public virtual Color Mew
	    {
	        get { return Colors.DeepPink; }
	    }

        #endregion ILogColors Members
    }
}