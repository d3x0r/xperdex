namespace CMakeProjectManager
{
	partial class EditProject
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
			this.components = new System.ComponentModel.Container();
			this.checkBox1 = new System.Windows.Forms.CheckBox();
			this.dataGridView1 = new System.Windows.Forms.DataGridView();
			this.treeView1 = new System.Windows.Forms.TreeView();
			this.tabControl1 = new System.Windows.Forms.TabControl();
			this.tabPageProjectProperties = new System.Windows.Forms.TabPage();
			this.buttonApplyProject = new System.Windows.Forms.Button();
			this.button3 = new System.Windows.Forms.Button();
			this.button4 = new System.Windows.Forms.Button();
			this.textBoxProjectName = new System.Windows.Forms.TextBox();
			this.label1 = new System.Windows.Forms.Label();
			this.tabPageTargetProperties = new System.Windows.Forms.TabPage();
			this.buttonApplyTarget = new System.Windows.Forms.Button();
			this.textBoxTargetName = new System.Windows.Forms.TextBox();
			this.label2 = new System.Windows.Forms.Label();
			this.comboBoxTargetType = new System.Windows.Forms.ComboBox();
			this.tabControl2 = new System.Windows.Forms.TabControl();
			this.projectDataSet = new CMakeProjectManager.ProjectDataSet();
			this.projectDataSetBindingSource = new System.Windows.Forms.BindingSource( this.components );
			this.currentProjectsBindingSource = new System.Windows.Forms.BindingSource( this.components );
			this.buttonWriteCmake = new System.Windows.Forms.Button();
			this.buttonDeleteTarget = new System.Windows.Forms.Button();
			( (System.ComponentModel.ISupportInitialize)( this.dataGridView1 ) ).BeginInit();
			this.tabControl1.SuspendLayout();
			this.tabPageProjectProperties.SuspendLayout();
			this.tabPageTargetProperties.SuspendLayout();
			( (System.ComponentModel.ISupportInitialize)( this.projectDataSet ) ).BeginInit();
			( (System.ComponentModel.ISupportInitialize)( this.projectDataSetBindingSource ) ).BeginInit();
			( (System.ComponentModel.ISupportInitialize)( this.currentProjectsBindingSource ) ).BeginInit();
			this.SuspendLayout();
			// 
			// checkBox1
			// 
			this.checkBox1.AutoSize = true;
			this.checkBox1.Location = new System.Drawing.Point( 22, 290 );
			this.checkBox1.Name = "checkBox1";
			this.checkBox1.Size = new System.Drawing.Size( 87, 17 );
			this.checkBox1.TabIndex = 0;
			this.checkBox1.Text = "Sack Extend";
			this.checkBox1.UseVisualStyleBackColor = true;
			// 
			// dataGridView1
			// 
			this.dataGridView1.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
			this.dataGridView1.Location = new System.Drawing.Point( 429, 363 );
			this.dataGridView1.Name = "dataGridView1";
			this.dataGridView1.Size = new System.Drawing.Size( 240, 150 );
			this.dataGridView1.TabIndex = 2;
			// 
			// treeView1
			// 
			this.treeView1.AllowDrop = true;
			this.treeView1.Location = new System.Drawing.Point( 12, 13 );
			this.treeView1.Name = "treeView1";
			this.treeView1.Size = new System.Drawing.Size( 274, 241 );
			this.treeView1.TabIndex = 6;
			this.treeView1.AfterSelect += new System.Windows.Forms.TreeViewEventHandler( this.treeView1_AfterSelect );
			// 
			// tabControl1
			// 
			this.tabControl1.Controls.Add( this.tabPageProjectProperties );
			this.tabControl1.Controls.Add( this.tabPageTargetProperties );
			this.tabControl1.Location = new System.Drawing.Point( 390, 13 );
			this.tabControl1.Name = "tabControl1";
			this.tabControl1.SelectedIndex = 0;
			this.tabControl1.Size = new System.Drawing.Size( 324, 326 );
			this.tabControl1.TabIndex = 9;
			// 
			// tabPageProjectProperties
			// 
			this.tabPageProjectProperties.Controls.Add( this.buttonApplyProject );
			this.tabPageProjectProperties.Controls.Add( this.button3 );
			this.tabPageProjectProperties.Controls.Add( this.button4 );
			this.tabPageProjectProperties.Controls.Add( this.textBoxProjectName );
			this.tabPageProjectProperties.Controls.Add( this.label1 );
			this.tabPageProjectProperties.Location = new System.Drawing.Point( 4, 22 );
			this.tabPageProjectProperties.Name = "tabPageProjectProperties";
			this.tabPageProjectProperties.Padding = new System.Windows.Forms.Padding( 3 );
			this.tabPageProjectProperties.Size = new System.Drawing.Size( 316, 300 );
			this.tabPageProjectProperties.TabIndex = 0;
			this.tabPageProjectProperties.Text = "Project Properties";
			this.tabPageProjectProperties.UseVisualStyleBackColor = true;
			// 
			// buttonApplyProject
			// 
			this.buttonApplyProject.Location = new System.Drawing.Point( 35, 195 );
			this.buttonApplyProject.Name = "buttonApplyProject";
			this.buttonApplyProject.Size = new System.Drawing.Size( 75, 23 );
			this.buttonApplyProject.TabIndex = 11;
			this.buttonApplyProject.Text = "Apply Changes";
			this.buttonApplyProject.UseVisualStyleBackColor = true;
			this.buttonApplyProject.Click += new System.EventHandler( this.button5_Click );
			// 
			// button3
			// 
			this.button3.Location = new System.Drawing.Point( 171, 241 );
			this.button3.Name = "button3";
			this.button3.Size = new System.Drawing.Size( 75, 43 );
			this.button3.TabIndex = 9;
			this.button3.Text = "Add Target";
			this.button3.UseVisualStyleBackColor = true;
			this.button3.Click += new System.EventHandler( this.button3_Click );
			// 
			// button4
			// 
			this.button4.Location = new System.Drawing.Point( 65, 241 );
			this.button4.Name = "button4";
			this.button4.Size = new System.Drawing.Size( 75, 43 );
			this.button4.TabIndex = 10;
			this.button4.Text = "Rename Target";
			this.button4.UseVisualStyleBackColor = true;
			// 
			// textBoxProjectName
			// 
			this.textBoxProjectName.Location = new System.Drawing.Point( 141, 14 );
			this.textBoxProjectName.Name = "textBoxProjectName";
			this.textBoxProjectName.Size = new System.Drawing.Size( 100, 20 );
			this.textBoxProjectName.TabIndex = 1;
			// 
			// label1
			// 
			this.label1.AutoSize = true;
			this.label1.Location = new System.Drawing.Point( 17, 21 );
			this.label1.Name = "label1";
			this.label1.Size = new System.Drawing.Size( 71, 13 );
			this.label1.TabIndex = 0;
			this.label1.Text = "Project Name";
			// 
			// tabPageTargetProperties
			// 
			this.tabPageTargetProperties.Controls.Add( this.buttonDeleteTarget );
			this.tabPageTargetProperties.Controls.Add( this.buttonApplyTarget );
			this.tabPageTargetProperties.Controls.Add( this.textBoxTargetName );
			this.tabPageTargetProperties.Controls.Add( this.label2 );
			this.tabPageTargetProperties.Controls.Add( this.comboBoxTargetType );
			this.tabPageTargetProperties.Location = new System.Drawing.Point( 4, 22 );
			this.tabPageTargetProperties.Name = "tabPageTargetProperties";
			this.tabPageTargetProperties.Padding = new System.Windows.Forms.Padding( 3 );
			this.tabPageTargetProperties.Size = new System.Drawing.Size( 316, 300 );
			this.tabPageTargetProperties.TabIndex = 1;
			this.tabPageTargetProperties.Text = "Target Properties";
			this.tabPageTargetProperties.UseVisualStyleBackColor = true;
			// 
			// buttonApplyTarget
			// 
			this.buttonApplyTarget.Location = new System.Drawing.Point( 35, 196 );
			this.buttonApplyTarget.Name = "buttonApplyTarget";
			this.buttonApplyTarget.Size = new System.Drawing.Size( 75, 23 );
			this.buttonApplyTarget.TabIndex = 12;
			this.buttonApplyTarget.Text = "Apply Changes";
			this.buttonApplyTarget.UseVisualStyleBackColor = true;
			this.buttonApplyTarget.Click += new System.EventHandler( this.buttonApplyTarget_Click );
			// 
			// textBoxTargetName
			// 
			this.textBoxTargetName.Location = new System.Drawing.Point( 121, 17 );
			this.textBoxTargetName.Name = "textBoxTargetName";
			this.textBoxTargetName.Size = new System.Drawing.Size( 100, 20 );
			this.textBoxTargetName.TabIndex = 2;
			// 
			// label2
			// 
			this.label2.AutoSize = true;
			this.label2.Location = new System.Drawing.Point( 21, 20 );
			this.label2.Name = "label2";
			this.label2.Size = new System.Drawing.Size( 69, 13 );
			this.label2.TabIndex = 1;
			this.label2.Text = "Target Name";
			// 
			// comboBoxTargetType
			// 
			this.comboBoxTargetType.FormattingEnabled = true;
			this.comboBoxTargetType.Location = new System.Drawing.Point( 21, 70 );
			this.comboBoxTargetType.Name = "comboBoxTargetType";
			this.comboBoxTargetType.Size = new System.Drawing.Size( 121, 21 );
			this.comboBoxTargetType.TabIndex = 0;
			// 
			// tabControl2
			// 
			this.tabControl2.Location = new System.Drawing.Point( 667, 0 );
			this.tabControl2.Name = "tabControl2";
			this.tabControl2.SelectedIndex = 0;
			this.tabControl2.Size = new System.Drawing.Size( 40, 29 );
			this.tabControl2.TabIndex = 10;
			this.tabControl2.Visible = false;
			// 
			// projectDataSet
			// 
			this.projectDataSet.DataSetName = "ProjectDataSet";
			this.projectDataSet.SchemaSerializationMode = System.Data.SchemaSerializationMode.IncludeSchema;
			// 
			// projectDataSetBindingSource
			// 
			this.projectDataSetBindingSource.DataSource = this.projectDataSet;
			this.projectDataSetBindingSource.Position = 0;
			// 
			// currentProjectsBindingSource
			// 
			this.currentProjectsBindingSource.DataMember = "CurrentProjects";
			this.currentProjectsBindingSource.DataSource = this.projectDataSet;
			// 
			// buttonWriteCmake
			// 
			this.buttonWriteCmake.Location = new System.Drawing.Point( 22, 313 );
			this.buttonWriteCmake.Name = "buttonWriteCmake";
			this.buttonWriteCmake.Size = new System.Drawing.Size( 198, 48 );
			this.buttonWriteCmake.TabIndex = 11;
			this.buttonWriteCmake.Text = "Generate CMakeLists.txt";
			this.buttonWriteCmake.UseVisualStyleBackColor = true;
			this.buttonWriteCmake.Click += new System.EventHandler( this.buttonWriteCmake_Click );
			// 
			// buttonDeleteTarget
			// 
			this.buttonDeleteTarget.Location = new System.Drawing.Point( 35, 242 );
			this.buttonDeleteTarget.Name = "buttonDeleteTarget";
			this.buttonDeleteTarget.Size = new System.Drawing.Size( 75, 42 );
			this.buttonDeleteTarget.TabIndex = 13;
			this.buttonDeleteTarget.Text = "Delete Target";
			this.buttonDeleteTarget.UseVisualStyleBackColor = true;
			this.buttonDeleteTarget.Click += new System.EventHandler( this.buttonDeleteTarget_Click );
			// 
			// EditProject
			// 
			this.AutoScaleDimensions = new System.Drawing.SizeF( 6F, 13F );
			this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
			this.ClientSize = new System.Drawing.Size( 716, 525 );
			this.Controls.Add( this.buttonWriteCmake );
			this.Controls.Add( this.tabControl2 );
			this.Controls.Add( this.tabControl1 );
			this.Controls.Add( this.treeView1 );
			this.Controls.Add( this.dataGridView1 );
			this.Controls.Add( this.checkBox1 );
			this.Name = "EditProject";
			this.Text = "EditProject";
			this.Load += new System.EventHandler( this.EditProject_Load );
			( (System.ComponentModel.ISupportInitialize)( this.dataGridView1 ) ).EndInit();
			this.tabControl1.ResumeLayout( false );
			this.tabPageProjectProperties.ResumeLayout( false );
			this.tabPageProjectProperties.PerformLayout();
			this.tabPageTargetProperties.ResumeLayout( false );
			this.tabPageTargetProperties.PerformLayout();
			( (System.ComponentModel.ISupportInitialize)( this.projectDataSet ) ).EndInit();
			( (System.ComponentModel.ISupportInitialize)( this.projectDataSetBindingSource ) ).EndInit();
			( (System.ComponentModel.ISupportInitialize)( this.currentProjectsBindingSource ) ).EndInit();
			this.ResumeLayout( false );
			this.PerformLayout();

		}

		#endregion

		private System.Windows.Forms.CheckBox checkBox1;
		private System.Windows.Forms.DataGridView dataGridView1;
		private ProjectDataSet projectDataSet;
		private System.Windows.Forms.BindingSource currentProjectsBindingSource;
		private System.Windows.Forms.BindingSource projectDataSetBindingSource;
		private System.Windows.Forms.TreeView treeView1;
		private System.Windows.Forms.TabControl tabControl1;
		private System.Windows.Forms.TabPage tabPageProjectProperties;
		private System.Windows.Forms.TextBox textBoxProjectName;
		private System.Windows.Forms.Label label1;
		private System.Windows.Forms.TabPage tabPageTargetProperties;
		private System.Windows.Forms.TextBox textBoxTargetName;
		private System.Windows.Forms.Label label2;
		private System.Windows.Forms.ComboBox comboBoxTargetType;
		private System.Windows.Forms.TabControl tabControl2;
		private System.Windows.Forms.Button button3;
		private System.Windows.Forms.Button button4;
		private System.Windows.Forms.Button buttonApplyProject;
		private System.Windows.Forms.Button buttonApplyTarget;
		private System.Windows.Forms.Button buttonWriteCmake;
		private System.Windows.Forms.Button buttonDeleteTarget;
	}
}