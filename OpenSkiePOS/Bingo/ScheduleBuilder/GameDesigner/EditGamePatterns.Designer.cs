namespace ScheduleBuilder.GameDesigner
{
    partial class EditGamePatterns
    {
        /// <summary>
        /// Required designer variable.
        /// </summary>
        private System.ComponentModel.IContainer components = null;

        /// <summary>
        /// Clean up any resources being used.
        /// </summary>
        /// <param name="disposing">true if managed resources should be disposed; otherwise, false.</param>
        protected override void Dispose( bool disposing )
        {
            if( disposing && ( components != null ) )
            {
                components.Dispose();
            }
            base.Dispose( disposing );
        }

        #region Windows Form Designer generated code

        /// <summary>
        /// Required method for Designer support - do not modify
        /// the contents of this method with the code editor.
        /// </summary>
        private void InitializeComponent()
        {
            this.removeItemFromSet8 = new OpenSkie.Scheduler.Controls.Controls.Buttons.RemoveItemFromSet();
            this.addItemToSet8 = new OpenSkie.Scheduler.Controls.Controls.Buttons.AddItemToSet();
            this.editPatterns1 = new OpenSkieScheduler.Controls.Buttons.EditPatterns();
            this.currentGamePatternList1 = new OpenSkieScheduler.Controls.Lists.CurrentGamePatternList();
            this.patternList1 = new OpenSkieScheduler.Controls.Lists.PatternList();
            this.SuspendLayout();
            // 
            // removeItemFromSet8
            // 
            this.removeItemFromSet8.GroupList = "currentGamePatternList1";
            this.removeItemFromSet8.Location = new System.Drawing.Point( 257, 222 );
            this.removeItemFromSet8.Name = "removeItemFromSet8";
            this.removeItemFromSet8.Size = new System.Drawing.Size( 38, 33 );
            this.removeItemFromSet8.TabIndex = 26;
            this.removeItemFromSet8.Text = "<<";
            this.removeItemFromSet8.UseVisualStyleBackColor = true;
            // 
            // addItemToSet8
            // 
            this.addItemToSet8.Location = new System.Drawing.Point( 257, 182 );
            this.addItemToSet8.MemberList = "patternList1";
            this.addItemToSet8.Name = "addItemToSet8";
            this.addItemToSet8.Size = new System.Drawing.Size( 38, 33 );
            this.addItemToSet8.TabIndex = 25;
            this.addItemToSet8.Text = ">>";
            this.addItemToSet8.UseVisualStyleBackColor = true;
            // 
            // editPatterns1
            // 
            this.editPatterns1.Location = new System.Drawing.Point( 43, 304 );
            this.editPatterns1.Name = "editPatterns1";
            this.editPatterns1.Size = new System.Drawing.Size( 100, 33 );
            this.editPatterns1.TabIndex = 24;
            this.editPatterns1.Text = "editPatterns1";
            this.editPatterns1.UseVisualStyleBackColor = true;
            // 
            // currentGamePatternList1
            // 
            this.currentGamePatternList1.BlockDoubleClick = false;
            this.currentGamePatternList1.DisplayMember = "current_game_pattern_name";
            this.currentGamePatternList1.FormattingEnabled = true;
            this.currentGamePatternList1.Location = new System.Drawing.Point( 301, 137 );
            this.currentGamePatternList1.Name = "currentGamePatternList1";
            this.currentGamePatternList1.Size = new System.Drawing.Size( 182, 160 );
            this.currentGamePatternList1.TabIndex = 23;
            this.currentGamePatternList1.TabStops = null;
            this.currentGamePatternList1.TargetList = null;
            // 
            // patternList1
            // 
            this.patternList1.BlockDoubleClick = false;
            this.patternList1.DisplayMember = "pattern_name";
            this.patternList1.FormattingEnabled = true;
            this.patternList1.Location = new System.Drawing.Point( 43, 137 );
            this.patternList1.Name = "patternList1";
            this.patternList1.Size = new System.Drawing.Size( 208, 160 );
            this.patternList1.TabIndex = 22;
            this.patternList1.TabStops = null;
            this.patternList1.TargetList = null;
            // 
            // EditGamePatterns
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF( 6F, 13F );
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size( 551, 360 );
            this.Controls.Add( this.removeItemFromSet8 );
            this.Controls.Add( this.addItemToSet8 );
            this.Controls.Add( this.editPatterns1 );
            this.Controls.Add( this.currentGamePatternList1 );
            this.Controls.Add( this.patternList1 );
            this.Name = "EditGamePatterns";
            this.Text = "EditGamePatterns";
            this.Load += new System.EventHandler( this.EditGamePatterns_Load );
            this.ResumeLayout( false );

        }

        #endregion

        private OpenSkie.Scheduler.Controls.Controls.Buttons.RemoveItemFromSet removeItemFromSet8;
        private OpenSkie.Scheduler.Controls.Controls.Buttons.AddItemToSet addItemToSet8;
        private OpenSkieScheduler.Controls.Buttons.EditPatterns editPatterns1;
        private OpenSkieScheduler.Controls.Lists.CurrentGamePatternList currentGamePatternList1;
        private OpenSkieScheduler.Controls.Lists.PatternList patternList1;
    }
}