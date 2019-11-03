using System.Collections.Generic;

namespace OpenSkiePOS
{
	internal class POS_Register
	{
		/// <summary>
		/// a list of buttons which were pressed during this last transaction
		/// </summary>
		public List<POS_ItemButton> pressed;

		/// <summary>
		/// The general container of all buttons in this register.
		/// </summary>
		public List<POS_ItemButton> AllButtons;


		static POS_Register register;
		internal POS_Register Register
		{
			get
			{
				if( register == null )
					register = new POS_Register();
				return register;
			}
		}

		private POS_Register()
		{

		}

		public void Clear()
		{
			pressed.Clear();
		}

		public void Commit()
		{
			// perform pos commit sales here.
			{
			}

			Clear();
		}



	}
}
