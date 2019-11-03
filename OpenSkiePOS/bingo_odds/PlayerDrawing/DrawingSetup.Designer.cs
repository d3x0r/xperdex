namespace PlayerDrawing
{
    partial class DrawingSetup
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
			this.monthCalendar1 = new System.Windows.Forms.MonthCalendar();
			this.textBoxGameNumber = new System.Windows.Forms.TextBox();
			this.textBoxSessionNumber = new System.Windows.Forms.TextBox();
			this.label1 = new System.Windows.Forms.Label();
			this.label2 = new System.Windows.Forms.Label();
			this.label3 = new System.Windows.Forms.Label();
			this.richTextBox1 = new System.Windows.Forms.RichTextBox();
			this.buttonOkay = new System.Windows.Forms.Button();
			this.buttonCancel = new System.Windows.Forms.Button();
			this.radioButtonPrizeVal = new System.Windows.Forms.RadioButton();
			this.radioButtonDirect = new System.Windows.Forms.RadioButton();
			this.textBoxCardColumn = new System.Windows.Forms.TextBox();
			this.label4 = new System.Windows.Forms.Label();
			this.label5 = new System.Windows.Forms.Label();
			this.textBoxNameColumn = new System.Windows.Forms.TextBox();
			this.label6 = new System.Windows.Forms.Label();
			this.textBoxDrawCount = new System.Windows.Forms.TextBox();
			this.SuspendLayout();
			// 
			// monthCalendar1
			// 
			this.monthCalendar1.Location = new System.Drawing.Point(532, 46);
			this.monthCalendar1.Name = "monthCalendar1";
			this.monthCalendar1.TabIndex = 0;
			// 
			// textBoxGameNumber
			// 
			this.textBoxGameNumber.Location = new System.Drawing.Point(204, 70);
			this.textBoxGameNumber.Name = "textBoxGameNumber";
			this.textBoxGameNumber.Size = new System.Drawing.Size(100, 20);
			this.textBoxGameNumber.TabIndex = 1;
			// 
			// textBoxSessionNumber
			// 
			this.textBoxSessionNumber.Location = new System.Drawing.Point(204, 46);
			this.textBoxSessionNumber.Name = "textBoxSessionNumber";
			this.textBoxSessionNumber.Size = new System.Drawing.Size(100, 20);
			this.textBoxSessionNumber.TabIndex = 2;
			// 
			// label1
			// 
			this.label1.AutoSize = true;
			this.label1.Location = new System.Drawing.Point(53, 49);
			this.label1.Name = "label1";
			this.label1.Size = new System.Drawing.Size(84, 13);
			this.label1.TabIndex = 3;
			this.label1.Text = "Session Number";
			// 
			// label2
			// 
			this.label2.AutoSize = true;
			this.label2.Location = new System.Drawing.Point(53, 73);
			this.label2.Name = "label2";
			this.label2.Size = new System.Drawing.Size(75, 13);
			this.label2.TabIndex = 4;
			this.label2.Text = "Game Number";
			// 
			// label3
			// 
			this.label3.AutoSize = true;
			this.label3.Location = new System.Drawing.Point(27, 207);
			this.label3.Name = "label3";
			this.label3.Size = new System.Drawing.Size(120, 13);
			this.label3.TabIndex = 5;
			this.label3.Text = "Player Select Statement";
			// 
			// richTextBox1
			// 
			this.richTextBox1.Location = new System.Drawing.Point(153, 204);
			this.richTextBox1.Name = "richTextBox1";
			this.richTextBox1.Size = new System.Drawing.Size(317, 96);
			this.richTextBox1.TabIndex = 8;
			this.richTextBox1.Text = "";
			// 
			// buttonOkay
			// 
			this.buttonOkay.Location = new System.Drawing.Point(552, 354);
			this.buttonOkay.Name = "buttonOkay";
			this.buttonOkay.Size = new System.Drawing.Size(75, 23);
			this.buttonOkay.TabIndex = 9;
			this.buttonOkay.Text = "Okay";
			this.buttonOkay.UseVisualStyleBackColor = true;
			this.buttonOkay.Click += new System.EventHandler(this.buttonOkay_Click);
			// 
			// buttonCancel
			// 
			this.buttonCancel.DialogResult = System.Windows.Forms.DialogResult.Cancel;
			this.buttonCancel.Location = new System.Drawing.Point(633, 354);
			this.buttonCancel.Name = "buttonCancel";
			this.buttonCancel.Size = new System.Drawing.Size(75, 23);
			this.buttonCancel.TabIndex = 10;
			this.buttonCancel.Text = "Cancel";
			this.buttonCancel.UseVisualStyleBackColor = true;
			// 
			// radioButtonPrizeVal
			// 
			this.radioButtonPrizeVal.AutoSize = true;
			this.radioButtonPrizeVal.Location = new System.Drawing.Point(30, 23);
			this.radioButtonPrizeVal.Name = "radioButtonPrizeVal";
			this.radioButtonPrizeVal.Size = new System.Drawing.Size(237, 17);
			this.radioButtonPrizeVal.TabIndex = 11;
			this.radioButtonPrizeVal.TabStop = true;
			this.radioButtonPrizeVal.Text = "Select Session and Game to use for ball data";
			this.radioButtonPrizeVal.UseVisualStyleBackColor = true;
			this.radioButtonPrizeVal.CheckedChanged += new System.EventHandler(this.radioButtonPrizeVal_CheckedChanged);
			// 
			// radioButtonDirect
			// 
			this.radioButtonDirect.AutoSize = true;
			this.radioButtonDirect.Location = new System.Drawing.Point(30, 98);
			this.radioButtonDirect.Name = "radioButtonDirect";
			this.radioButtonDirect.Size = new System.Drawing.Size(294, 17);
			this.radioButtonDirect.TabIndex = 12;
			this.radioButtonDirect.TabStop = true;
			this.radioButtonDirect.Text = "Use Blower For Ball Data (through slave-blower interface)";
			this.radioButtonDirect.UseVisualStyleBackColor = true;
			this.radioButtonDirect.Visible = false;
			// 
			// textBoxCardColumn
			// 
			this.textBoxCardColumn.Location = new System.Drawing.Point(159, 331);
			this.textBoxCardColumn.Name = "textBoxCardColumn";
			this.textBoxCardColumn.Size = new System.Drawing.Size(100, 20);
			this.textBoxCardColumn.TabIndex = 13;
			// 
			// label4
			// 
			this.label4.AutoSize = true;
			this.label4.Location = new System.Drawing.Point(27, 334);
			this.label4.Name = "label4";
			this.label4.Size = new System.Drawing.Size(126, 13);
			this.label4.TabIndex = 14;
			this.label4.Text = "Player card column name";
			// 
			// label5
			// 
			this.label5.AutoSize = true;
			this.label5.Location = new System.Drawing.Point(27, 359);
			this.label5.Name = "label5";
			this.label5.Size = new System.Drawing.Size(131, 13);
			this.label5.TabIndex = 16;
			this.label5.Text = "Player name column name";
			// 
			// textBoxNameColumn
			// 
			this.textBoxNameColumn.Location = new System.Drawing.Point(159, 356);
			this.textBoxNameColumn.Name = "textBoxNameColumn";
			this.textBoxNameColumn.Size = new System.Drawing.Size(100, 20);
			this.textBoxNameColumn.TabIndex = 15;
			// 
			// label6
			// 
			this.label6.AutoSize = true;
			this.label6.Location = new System.Drawing.Point(27, 399);
			this.label6.Name = "label6";
			this.label6.Size = new System.Drawing.Size(102, 13);
			this.label6.TabIndex = 18;
			this.label6.Text = "How Many To Draw";
			// 
			// textBoxDrawCount
			// 
			this.textBoxDrawCount.Location = new System.Drawing.Point(159, 396);
			this.textBoxDrawCount.Name = "textBoxDrawCount";
			this.textBoxDrawCount.Size = new System.Drawing.Size(100, 20);
			this.textBoxDrawCount.TabIndex = 17;
			// 
			// DrawingSetup
			// 
			this.AcceptButton = this.buttonOkay;
			this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
			this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
			this.CancelButton = this.buttonCancel;
			this.ClientSize = new System.Drawing.Size(777, 467);
			this.Controls.Add(this.label6);
			this.Controls.Add(this.textBoxDrawCount);
			this.Controls.Add(this.label5);
			this.Controls.Add(this.textBoxNameColumn);
			this.Controls.Add(this.label4);
			this.Controls.Add(this.textBoxCardColumn);
			this.Controls.Add(this.radioButtonDirect);
			this.Controls.Add(this.radioButtonPrizeVal);
			this.Controls.Add(this.buttonCancel);
			this.Controls.Add(this.buttonOkay);
			this.Controls.Add(this.richTextBox1);
			this.Controls.Add(this.label3);
			this.Controls.Add(this.label2);
			this.Controls.Add(this.label1);
			this.Controls.Add(this.textBoxSessionNumber);
			this.Controls.Add(this.textBoxGameNumber);
			this.Controls.Add(this.monthCalendar1);
			this.Name = "DrawingSetup";
			this.Text = "Drawing Setup";
			this.Load += new System.EventHandler(this.DrawingSetup_Load);
			this.ResumeLayout(false);
			this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.MonthCalendar monthCalendar1;
        private System.Windows.Forms.TextBox textBoxGameNumber;
        private System.Windows.Forms.TextBox textBoxSessionNumber;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.Label label3;
        private System.Windows.Forms.RichTextBox richTextBox1;
        private System.Windows.Forms.Button buttonOkay;
        private System.Windows.Forms.Button buttonCancel;
        private System.Windows.Forms.RadioButton radioButtonPrizeVal;
        private System.Windows.Forms.RadioButton radioButtonDirect;
        private System.Windows.Forms.TextBox textBoxCardColumn;
        private System.Windows.Forms.Label label4;
        private System.Windows.Forms.Label label5;
        private System.Windows.Forms.TextBox textBoxNameColumn;
		private System.Windows.Forms.Label label6;
		private System.Windows.Forms.TextBox textBoxDrawCount;
    }
}