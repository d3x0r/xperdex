using System.Collections.Generic;
using System.Windows.Forms;
using OpenSkie.Scheduler;
using OpenSkie.Scheduler.Controls.Common.Textboxes;
using xperdex.classes;

namespace OpenSkieScheduler3.Controls
{
	public static class ControlList
	{
		public static List<Control> controls = new List<Control>();
		public static List<MyTextBox> names = new List<MyTextBox>();
		public static List<DataGridView> current_complex_data = new List<DataGridView>();

		public delegate void UpdateDataSourceEvent();
		public static event UpdateDataSourceEvent UpdateDataSource;

		static ScheduleDataSet _data;
		public static ScheduleDataSet schedule
		{
			get
			{
				if( _data == null )
				{
					_data = OpenSkieSchedule.last_created_schedule;
					if( _data == null )
						_data = new ScheduleDataSet();
				}
				//MessageBox.Show( "Resulting " + _data );
				return _data;
			}
			set
			{
				_data = value;
			}
		}
        static ScheduleCurrents _current;
        public static ScheduleCurrents data
        {
            get
            {
                if( _current == null )
                	_current = ScheduleCurrents.last_created_currents;

				if( _data == null )
					_data = OpenSkieSchedule.last_created_schedule;
						
				if( _data == null )
					_data = new ScheduleDataSet();

				if( _current == null )
					_current = new ScheduleCurrents( _data );
				return _current;
            }
            set
            {
                _current = value;
            }
        }


		public static void UpdateDataSources()
		{
			if( UpdateDataSource != null )
				UpdateDataSource();
		}

		public static void UpdateText( string member_name )
		{
			foreach( MyTextBox box in names )
			{
				if( box.fieldname == member_name )
				{
					box.UpdateBindings();
				}
			}
		}
	}
}
