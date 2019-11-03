namespace xperdex.core
{
    partial class Macro_Properties
    {
        /// <summary>
        /// Required designer variable.
        /// </summary>
        private System.ComponentModel.IContainer components = null;

        /// <summary>
        /// Clean up any resources being used.
        /// </summary>
        /// <param name="disposing">true if managed resources should be disposed; otherwise, false.</param>
        protected override void Dispose(bool disposing)
        {
            if (disposing && (components != null))
            {
                components.Dispose();
            }
            base.Dispose(disposing);
        }

        #region Windows Form Designer generated code

        /// <summary>
        /// Required method for Designer support - do not modify
        /// the contents of this method with the code editor.
        /// </summary>
        private void InitializeComponent()
        {
			this.Actions = new System.Windows.Forms.ListBox();
			this.BaseProperties = new System.Windows.Forms.Button();
			this.textboxMacro = new System.Windows.Forms.TextBox();
			this.AvailableActions = new System.Windows.Forms.ListBox();
			this.buttonAddAction = new System.Windows.Forms.Button();
			this.buttonRemove = new System.Windows.Forms.Button();
			this.buttonEdit = new System.Windows.Forms.Button();
			this.buttonClone = new System.Windows.Forms.Button();
			this.buttonOkay = new System.Windows.Forms.Button();
			this.buttonCancel = new System.Windows.Forms.Button();
			this.label1 = new System.Windows.Forms.Label();
			this.buttonUp = new System.Windows.Forms.Button();
			this.buttonDn = new System.Windows.Forms.Button();
			this.SuspendLayout();
			// 
			// Actions
			// 
			this.Actions.FormattingEnabled = true;
			this.Actions.Location = new System.Drawing.Point( 12, 57 );
			this.Actions.Name = "Actions";
			this.Actions.Size = new System.Drawing.Size( 201, 134 );
			this.Actions.TabIndex = 0;
			// 
			// BaseProperties
			// 
			this.BaseProperties.Location = new System.Drawing.Point( 12, 300 );
			this.BaseProperties.Name = "BaseProperties";
			this.BaseProperties.Size = new System.Drawing.Size( 138, 49 );
			this.BaseProperties.TabIndex = 1;
			this.BaseProperties.Text = "Common Properties";
			this.BaseProperties.UseVisualStyleBackColor = true;
			this.BaseProperties.Click += new System.EventHandler( this.BaseProperties_Click );
			// 
			// textboxMacro
			// 
			this.textboxMacro.Location = new System.Drawing.Point( 80, 12 );
			this.textboxMacro.Name = "textboxMacro";
			this.textboxMacro.Size = new System.Drawing.Size( 240, 20 );
			this.textboxMacro.TabIndex = 5;
			// 
			// AvailableActions
			// 
			this.AvailableActions.FormattingEnabled = true;
			this.AvailableActions.Location = new System.Drawing.Point( 290, 57 );
			this.AvailableActions.Name = "AvailableActions";
			this.AvailableActions.Size = new System.Drawing.Size( 207, 134 );
			this.AvailableActions.TabIndex = 6;
			// 
			// buttonAddAction
			// 
			this.buttonAddAction.Location = new System.Drawing.Point( 13, 198 );
			this.buttonAddAction.Name = "buttonAddAction";
			this.buttonAddAction.Size = new System.Drawing.Size( 98, 23 );
			this.buttonAddAction.TabIndex = 7;
			this.buttonAddAction.Text = "Add Action";
			this.buttonAddAction.UseVisualStyleBackColor = true;
			this.buttonAddAction.Click += new System.EventHandler( this.buttonAddAction_Click );
			// 
			// buttonRemove
			// 
			this.buttonRemove.Location = new System.Drawing.Point( 13, 227 );
			this.buttonRemove.Name = "buttonRemove";
			this.buttonRemove.Size = new System.Drawing.Size( 98, 23 );
			this.buttonRemove.TabIndex = 8;
			this.buttonRemove.Text = "Remove Action";
			this.buttonRemove.UseVisualStyleBackColor = true;
			this.buttonRemove.Click += new System.EventHandler( this.buttonRemove_Click );
			// 
			// buttonEdit
			// 
			this.buttonEdit.Location = new System.Drawing.Point( 117, 198 );
			this.buttonEdit.Name = "buttonEdit";
			this.buttonEdit.Size = new System.Drawing.Size( 96, 23 );
			this.buttonEdit.TabIndex = 9;
			this.buttonEdit.Text = "Edit Action";
			this.buttonEdit.UseVisualStyleBackColor = true;
			this.buttonEdit.Click += new System.EventHandler( this.buttonEdit_Click );
			// 
			// buttonClone
			// 
			this.buttonClone.Location = new System.Drawing.Point( 117, 227 );
			this.buttonClone.Name = "buttonClone";
			this.buttonClone.Size = new System.Drawing.Size( 96, 23 );
			this.buttonClone.TabIndex = 10;
			this.buttonClone.Text = "Add Clone";
			this.buttonClone.UseVisualStyleBackColor = true;
			this.buttonClone.Click += new System.EventHandler( this.buttonClone_Click );
			// 
			// buttonOkay
			// 
			this.buttonOkay.DialogResult = System.Windows.Forms.DialogResult.OK;
			this.buttonOkay.Location = new System.Drawing.Point( 422, 326 );
			this.buttonOkay.Name = "buttonOkay";
			this.buttonOkay.Size = new System.Drawing.Size( 75, 23 );
			this.buttonOkay.TabIndex = 11;
			this.buttonOkay.Text = "Okay";
			this.buttonOkay.UseVisualStyleBackColor = true;
			// 
			// buttonCancel
			// 
			this.buttonCancel.DialogResult = System.Windows.Forms.DialogResult.Cancel;
			this.buttonCancel.Location = new System.Drawing.Point( 341, 326 );
			this.buttonCancel.Name = "buttonCancel";
			this.buttonCancel.Size = new System.Drawing.Size( 75, 23 );
			this.buttonCancel.TabIndex = 12;
			this.buttonCancel.Text = "Cancel";
			this.buttonCancel.UseVisualStyleBackColor = true;
			// 
			// label1
			// 
			this.label1.AutoSize = true;
			this.label1.Location = new System.Drawing.Point( 12, 15 );
			this.label1.Name = "label1";
			this.label1.Size = new System.Drawing.Size( 62, 13 );
			this.label1.TabIndex = 13;
			this.label1.Text = "Button Text";
			// 
			// buttonUp
			// 
			this.buttonUp.Location = new System.Drawing.Point( 219, 57 );
			this.buttonUp.Name = "buttonUp";
			this.buttonUp.Size = new System.Drawing.Size( 34, 23 );
			this.buttonUp.TabIndex = 14;
			this.buttonUp.Text = "Up";
			this.buttonUp.UseVisualStyleBackColor = true;
			this.buttonUp.Click += new System.EventHandler( this.buttonUp_Click );
			// 
			// buttonDn
			// 
			this.buttonDn.Location = new System.Drawing.Point( 219, 86 );
			this.buttonDn.Name = "buttonDn";
			this.buttonDn.Size = new System.Drawing.Size( 34, 23 );
			this.buttonDn.TabIndex = 15;
			this.buttonDn.Text = "Dn";
			this.buttonDn.UseVisualStyleBackColor = true;
			this.buttonDn.Click += new System.EventHandler( this.buttonDn_Click );
			// 
			// Macro_Properties
			// 
			this.AcceptButton = this.buttonOkay;
			this.AutoScaleDimensions = new System.Drawing.SizeF( 6F, 13F );
			this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
			this.CancelButton = this.buttonCancel;
			this.ClientSize = new System.Drawing.Size( 512, 361 );
			this.Controls.Add( this.buttonDn );
			this.Controls.Add( this.buttonUp );
			this.Controls.Add( this.label1 );
			this.Controls.Add( this.buttonCancel );
			this.Controls.Add( this.buttonOkay );
			this.Controls.Add( this.buttonClone );
			this.Controls.Add( this.buttonEdit );
			this.Controls.Add( this.buttonRemove );
			this.Controls.Add( this.buttonAddAction );
			this.Controls.Add( this.AvailableActions );
			this.Controls.Add( this.textboxMacro );
			this.Controls.Add( this.BaseProperties );
			this.Controls.Add( this.Actions );
			this.Name = "Macro_Properties";
			this.Text = "Macro Properties";
			this.ResumeLayout( false );
			this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.ListBox Actions;
		private System.Windows.Forms.Button BaseProperties;
        private System.Windows.Forms.ListBox AvailableActions;
        private System.Windows.Forms.Button buttonAddAction;
        private System.Windows.Forms.Button buttonRemove;
        private System.Windows.Forms.Button buttonEdit;
        private System.Windows.Forms.Button buttonClone;
        private System.Windows.Forms.Button buttonOkay;
        private System.Windows.Forms.Button buttonCancel;
		private System.Windows.Forms.Label label1;
		private System.Windows.Forms.Button buttonUp;
		private System.Windows.Forms.Button buttonDn;
		internal System.Windows.Forms.TextBox textboxMacro;
    }
}