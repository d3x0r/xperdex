
namespace xperdex.classes
{
#if asdf
	public class DataConnection
	{
		DsnConnection primary;
		DsnConnection backup;

		public delegate void PrimaryFailed( );
		public delegate void PrimaryRecovered();
		public delegate void BackupAvailable();
		public delegate void BackupUnavailable();

		List<PrimaryRecovered> recover;


		public DataConnection()
		{
			
		}
	}
#endif
}
