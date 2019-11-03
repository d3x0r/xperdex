using System;
using System.Collections.Generic;
using System.Text;
using OpenSkieScheduler.BingoGameDefs.Pattern_Editor;

namespace OpenSkie.Scheduler.Controls
{
	public class PatternListFilterBlock: PatternBlock
	{
		public PatternListFilterBlock()
		{
			this.bits = 0;
			this.PatternChanged += new OnPatternChanged( PatternListFilterBlock_PatternChanged );
		}

		void PatternListFilterBlock_PatternChanged()
		{

		}
	}
}
