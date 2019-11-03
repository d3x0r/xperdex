using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using xperdex.core.interfaces;

namespace SessionManager
{
	class OpenCloseSessionForIssue : IReflectorVariable
	{
		string IReflectorVariable.Name
		{
			get { return "<Session Issue State>"; }
		}

		string IReflectorVariable.Text
		{
			get { return SessionManagementState.open_for_issue ? "Open" : "Closed"; }
		}
	}

	class OpenCloseSessionForSales : IReflectorVariable
	{
		string IReflectorVariable.Name
		{
			get { return "<Session Sales State>"; }
		}

		string IReflectorVariable.Text
		{
			get { return SessionManagementState.open_for_sales ? "Open" : "Closed"; }
		}
	}

	class OpenCloseSessionForPlay : IReflectorVariable
	{
		string IReflectorVariable.Name
		{
			get { return "<Session Play State>"; }
		}

		string IReflectorVariable.Text
		{
			get { return SessionManagementState.open_for_play ? "Open" : "Closed"; }
		}
	}

	class CommandOpenCloseSessionForIssue : IReflectorVariable
	{
		string IReflectorVariable.Name
		{
			get { return "<Session Issue Command>"; }
		}

		string IReflectorVariable.Text
		{
			get { return !SessionManagementState.open_for_issue ? "Open" : "Close"; }
		}
	}

	class CommandOpenCloseSessionForSales : IReflectorVariable
	{
		string IReflectorVariable.Name
		{
			get { return "<Session Sales Command>"; }
		}

		string IReflectorVariable.Text
		{
			get { return !SessionManagementState.open_for_sales ? "Open" : "Close"; }
		}
	}

	class CommandOpenCloseSessionForPlay : IReflectorVariable
	{
		string IReflectorVariable.Name
		{
			get { return "<Session Play Command>"; }
		}

		string IReflectorVariable.Text
		{
			get { return !SessionManagementState.open_for_play ? "Open" : "Close"; }
		}
	}

}
