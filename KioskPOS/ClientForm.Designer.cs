namespace MobilePOS
{
	partial class ClientForm
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
            this.button1 = new System.Windows.Forms.Button();
            this.textBox1 = new System.Windows.Forms.TextBox();
            this.textBox2 = new System.Windows.Forms.TextBox();
            this.textBox3 = new System.Windows.Forms.TextBox();
            this.button2 = new System.Windows.Forms.Button();
            this.button3 = new System.Windows.Forms.Button();
            this.textBox4 = new System.Windows.Forms.TextBox();
            this.textBox5 = new System.Windows.Forms.TextBox();
            this.textBox6 = new System.Windows.Forms.TextBox();
            this.button4 = new System.Windows.Forms.Button();
            this.button5 = new System.Windows.Forms.Button();
            this.button6 = new System.Windows.Forms.Button();
            this.button7 = new System.Windows.Forms.Button();
            this.button8 = new System.Windows.Forms.Button();
            this.label1 = new System.Windows.Forms.Label();
            this.label2 = new System.Windows.Forms.Label();
            this.textBoxItemID = new System.Windows.Forms.TextBox();
            this.label3 = new System.Windows.Forms.Label();
            this.label4 = new System.Windows.Forms.Label();
            this.label5 = new System.Windows.Forms.Label();
            this.button9 = new System.Windows.Forms.Button();
            this.textBoxBarcodeString = new System.Windows.Forms.TextBox();
            this.buttonBarcodeEvent = new System.Windows.Forms.Button();
            this.buttonRegisterDept = new System.Windows.Forms.Button();
            this.textBoxDeptName = new System.Windows.Forms.TextBox();
            this.SuspendLayout();
            // 
            // button1
            // 
            this.button1.Location = new System.Drawing.Point(221, 29);
            this.button1.Name = "button1";
            this.button1.Size = new System.Drawing.Size(75, 23);
            this.button1.TabIndex = 0;
            this.button1.Text = "Set Player";
            this.button1.UseVisualStyleBackColor = true;
            this.button1.Click += new System.EventHandler(this.button1_Click);
            // 
            // textBox1
            // 
            this.textBox1.Location = new System.Drawing.Point(30, 32);
            this.textBox1.Name = "textBox1";
            this.textBox1.Size = new System.Drawing.Size(100, 20);
            this.textBox1.TabIndex = 1;
            // 
            // textBox2
            // 
            this.textBox2.Location = new System.Drawing.Point(30, 74);
            this.textBox2.Name = "textBox2";
            this.textBox2.Size = new System.Drawing.Size(100, 20);
            this.textBox2.TabIndex = 2;
            // 
            // textBox3
            // 
            this.textBox3.Location = new System.Drawing.Point(30, 117);
            this.textBox3.Name = "textBox3";
            this.textBox3.Size = new System.Drawing.Size(100, 20);
            this.textBox3.TabIndex = 3;
            // 
            // button2
            // 
            this.button2.Location = new System.Drawing.Point(182, 71);
            this.button2.Name = "button2";
            this.button2.Size = new System.Drawing.Size(75, 23);
            this.button2.TabIndex = 4;
            this.button2.Text = "Add Money";
            this.button2.UseVisualStyleBackColor = true;
            this.button2.Click += new System.EventHandler(this.button2_Click);
            // 
            // button3
            // 
            this.button3.Location = new System.Drawing.Point(209, 114);
            this.button3.Name = "button3";
            this.button3.Size = new System.Drawing.Size(75, 23);
            this.button3.TabIndex = 5;
            this.button3.Text = "Add Product";
            this.button3.UseVisualStyleBackColor = true;
            this.button3.Click += new System.EventHandler(this.button3_Click);
            // 
            // textBox4
            // 
            this.textBox4.Location = new System.Drawing.Point(30, 6);
            this.textBox4.Name = "textBox4";
            this.textBox4.Size = new System.Drawing.Size(100, 20);
            this.textBox4.TabIndex = 6;
            // 
            // textBox5
            // 
            this.textBox5.Location = new System.Drawing.Point(63, 143);
            this.textBox5.Name = "textBox5";
            this.textBox5.Size = new System.Drawing.Size(100, 20);
            this.textBox5.TabIndex = 7;
            // 
            // textBox6
            // 
            this.textBox6.Location = new System.Drawing.Point(30, 214);
            this.textBox6.Name = "textBox6";
            this.textBox6.Size = new System.Drawing.Size(100, 20);
            this.textBox6.TabIndex = 8;
            // 
            // button4
            // 
            this.button4.Location = new System.Drawing.Point(171, 214);
            this.button4.Name = "button4";
            this.button4.Size = new System.Drawing.Size(75, 23);
            this.button4.TabIndex = 9;
            this.button4.Text = "Start POS";
            this.button4.UseVisualStyleBackColor = true;
            this.button4.Click += new System.EventHandler(this.button4_Click);
            // 
            // button5
            // 
            this.button5.Location = new System.Drawing.Point(171, 243);
            this.button5.Name = "button5";
            this.button5.Size = new System.Drawing.Size(141, 23);
            this.button5.TabIndex = 10;
            this.button5.Text = "Set Bingoday";
            this.button5.UseVisualStyleBackColor = true;
            this.button5.Click += new System.EventHandler(this.button5_Click);
            // 
            // button6
            // 
            this.button6.Location = new System.Drawing.Point(171, 272);
            this.button6.Name = "button6";
            this.button6.Size = new System.Drawing.Size(141, 23);
            this.button6.TabIndex = 11;
            this.button6.Text = "Begin Transaction";
            this.button6.UseVisualStyleBackColor = true;
            this.button6.Click += new System.EventHandler(this.button6_Click);
            // 
            // button7
            // 
            this.button7.Location = new System.Drawing.Point(171, 301);
            this.button7.Name = "button7";
            this.button7.Size = new System.Drawing.Size(141, 23);
            this.button7.TabIndex = 12;
            this.button7.Text = "End Transaction";
            this.button7.UseVisualStyleBackColor = true;
            this.button7.Click += new System.EventHandler(this.button7_Click);
            // 
            // button8
            // 
            this.button8.Location = new System.Drawing.Point(171, 330);
            this.button8.Name = "button8";
            this.button8.Size = new System.Drawing.Size(141, 23);
            this.button8.TabIndex = 13;
            this.button8.Text = "Restart POS";
            this.button8.UseVisualStyleBackColor = true;
            this.button8.Click += new System.EventHandler(this.button8_Click);
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Location = new System.Drawing.Point(137, 114);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(58, 13);
            this.label1.TabIndex = 14;
            this.label1.Text = "Item Name";
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Location = new System.Drawing.Point(168, 143);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(51, 13);
            this.label2.TabIndex = 15;
            this.label2.Text = "Item Cost";
            // 
            // textBoxItemID
            // 
            this.textBoxItemID.Location = new System.Drawing.Point(63, 169);
            this.textBoxItemID.Name = "textBoxItemID";
            this.textBoxItemID.Size = new System.Drawing.Size(100, 20);
            this.textBoxItemID.TabIndex = 16;
            // 
            // label3
            // 
            this.label3.Location = new System.Drawing.Point(168, 172);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(51, 13);
            this.label3.TabIndex = 17;
            this.label3.Text = "Item ID";
            // 
            // label4
            // 
            this.label4.Location = new System.Drawing.Point(136, 9);
            this.label4.Name = "label4";
            this.label4.Size = new System.Drawing.Size(96, 17);
            this.label4.TabIndex = 18;
            this.label4.Text = "Host Address";
            // 
            // label5
            // 
            this.label5.Location = new System.Drawing.Point(137, 32);
            this.label5.Name = "label5";
            this.label5.Size = new System.Drawing.Size(78, 20);
            this.label5.TabIndex = 19;
            this.label5.Text = "Player ID";
            // 
            // button9
            // 
            this.button9.Location = new System.Drawing.Point(171, 359);
            this.button9.Name = "button9";
            this.button9.Size = new System.Drawing.Size(141, 23);
            this.button9.TabIndex = 20;
            this.button9.Text = "Clear Item";
            this.button9.UseVisualStyleBackColor = true;
            this.button9.Click += new System.EventHandler(this.button9_Click);
            // 
            // textBoxBarcodeString
            // 
            this.textBoxBarcodeString.Location = new System.Drawing.Point(30, 416);
            this.textBoxBarcodeString.Name = "textBoxBarcodeString";
            this.textBoxBarcodeString.Size = new System.Drawing.Size(100, 20);
            this.textBoxBarcodeString.TabIndex = 21;
            // 
            // buttonBarcodeEvent
            // 
            this.buttonBarcodeEvent.Location = new System.Drawing.Point(182, 416);
            this.buttonBarcodeEvent.Name = "buttonBarcodeEvent";
            this.buttonBarcodeEvent.Size = new System.Drawing.Size(130, 23);
            this.buttonBarcodeEvent.TabIndex = 22;
            this.buttonBarcodeEvent.Text = "Post Barcode";
            this.buttonBarcodeEvent.UseVisualStyleBackColor = true;
            this.buttonBarcodeEvent.Click += new System.EventHandler(this.buttonBarcodeEvent_Click);
            // 
            // buttonRegisterDept
            // 
            this.buttonRegisterDept.Location = new System.Drawing.Point(182, 387);
            this.buttonRegisterDept.Name = "buttonRegisterDept";
            this.buttonRegisterDept.Size = new System.Drawing.Size(130, 23);
            this.buttonRegisterDept.TabIndex = 24;
            this.buttonRegisterDept.Text = "Register Department";
            this.buttonRegisterDept.UseVisualStyleBackColor = true;
            this.buttonRegisterDept.Click += new System.EventHandler(this.buttonRegisterDept_Click);
            // 
            // textBoxDeptName
            // 
            this.textBoxDeptName.Location = new System.Drawing.Point(30, 387);
            this.textBoxDeptName.Name = "textBoxDeptName";
            this.textBoxDeptName.Size = new System.Drawing.Size(100, 20);
            this.textBoxDeptName.TabIndex = 23;
            // 
            // ClientForm
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(369, 451);
            this.Controls.Add(this.buttonRegisterDept);
            this.Controls.Add(this.textBoxDeptName);
            this.Controls.Add(this.buttonBarcodeEvent);
            this.Controls.Add(this.textBoxBarcodeString);
            this.Controls.Add(this.button9);
            this.Controls.Add(this.label5);
            this.Controls.Add(this.label4);
            this.Controls.Add(this.label3);
            this.Controls.Add(this.textBoxItemID);
            this.Controls.Add(this.label2);
            this.Controls.Add(this.label1);
            this.Controls.Add(this.button8);
            this.Controls.Add(this.button7);
            this.Controls.Add(this.button6);
            this.Controls.Add(this.button5);
            this.Controls.Add(this.button4);
            this.Controls.Add(this.textBox6);
            this.Controls.Add(this.textBox5);
            this.Controls.Add(this.textBox4);
            this.Controls.Add(this.button3);
            this.Controls.Add(this.button2);
            this.Controls.Add(this.textBox3);
            this.Controls.Add(this.textBox2);
            this.Controls.Add(this.textBox1);
            this.Controls.Add(this.button1);
            this.Name = "ClientForm";
            this.Text = "ClientForm";
            this.FormClosing += new System.Windows.Forms.FormClosingEventHandler(this.ClientForm_FormClosing);
            this.ResumeLayout(false);
            this.PerformLayout();

		}

		#endregion

		private System.Windows.Forms.Button button1;
		private System.Windows.Forms.TextBox textBox1;
		private System.Windows.Forms.TextBox textBox2;
		private System.Windows.Forms.TextBox textBox3;
		private System.Windows.Forms.Button button2;
		private System.Windows.Forms.Button button3;
		private System.Windows.Forms.TextBox textBox4;
		private System.Windows.Forms.TextBox textBox5;
		private System.Windows.Forms.TextBox textBox6;
		private System.Windows.Forms.Button button4;
		private System.Windows.Forms.Button button5;
		private System.Windows.Forms.Button button6;
		private System.Windows.Forms.Button button7;
		private System.Windows.Forms.Button button8;
		private System.Windows.Forms.Label label1;
		private System.Windows.Forms.Label label2;
		private System.Windows.Forms.TextBox textBoxItemID;
		private System.Windows.Forms.Label label3;
		private System.Windows.Forms.Label label4;
		private System.Windows.Forms.Label label5;
		private System.Windows.Forms.Button button9;
		private System.Windows.Forms.TextBox textBoxBarcodeString;
		private System.Windows.Forms.Button buttonBarcodeEvent;
        private System.Windows.Forms.Button buttonRegisterDept;
        private System.Windows.Forms.TextBox textBoxDeptName;
	}
}