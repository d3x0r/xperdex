using System;
using System.Drawing;
using System.Collections;
using System.ComponentModel;
using System.Windows.Forms;
using System.Data;
using System.IO;
using System.Xml;
using System.Diagnostics; 
using System.Threading;
using TreeSample;
using System.Collections.Generic;
using xperdex.classes;

namespace TreeSample
{
 
  public class Form1 : System.Windows.Forms.Form
  {

    //private string DBConStr = "";
    private string AppPath = "";
    private ContextMenu tvSample1Menu = new ContextMenu();
	private ContextMenu tvSample2Menu = new ContextMenu();
	private System.ComponentModel.IContainer components;
	private System.Windows.Forms.Label label1;
	private System.Windows.Forms.TreeView tvSample;
	private System.Windows.Forms.Button button1;
	private System.Windows.Forms.Button button2;
  	private System.Windows.Forms.TreeView tvSample2;
  	private System.Windows.Forms.Label label2;
    private System.Windows.Forms.Button button3;
    private System.Windows.Forms.Button button4;
    private System.Windows.Forms.Button button5;
    private System.Windows.Forms.Button button6;
	private ListBox listBox1;
	private System.Windows.Forms.ImageList imageList1;
 

	#region Form Load
	private void Form1_Load(object sender, System.EventArgs e)
	{

      UI.Hourglass(true);
 

      try
      {

	    AppPath =  UI.GetAppPath(); 

        //DBConStr = "Provider=Microsoft.Jet.OLEDB.4.0; Data Source=" + AppPath + "sample.mdb";
	 
        tvSample1Menu.MenuItems.Add("Insert",
                                    new EventHandler(tvSample1RightClickInsert));

        tvSample1Menu.MenuItems.Add("Edit",
                                    new EventHandler(tvSample1RightClickEdit));

        tvSample1Menu.MenuItems.Add("Nudge Up",
                                    new EventHandler(tvSample1RightClickNudgeUp));

        tvSample1Menu.MenuItems.Add("Nudge Down",
                                    new EventHandler(tvSample1RightClickNudgeDown));

        tvSample1Menu.MenuItems.Add("Delete",
                                    new EventHandler(tvSample1RightClickDelete));  

		tvSample2Menu.MenuItems.Add("Insert",
			                        new EventHandler(tvSample2RightClickInsert)); 

        tvSample2Menu.MenuItems.Add("Edit",
                                    new EventHandler(tvSample2RightClickEdit));

        tvSample2Menu.MenuItems.Add("Nudge Up",
                                    new EventHandler(tvSample2RightClickNudgeUp));

        tvSample2Menu.MenuItems.Add("Nudge Down",
                                    new EventHandler(tvSample2RightClickNudgeDown));

       	tvSample2Menu.MenuItems.Add("Delete",
			                        new EventHandler(tvSample2RightClickDelete));
        
        LoadAllTrees();

		tvSample.AllowDrop = true;
        tvSample2.AllowDrop = true;
       
       }
       catch (Exception err) {  UI.Hourglass(false); UI.ShowError(err.Message); }
       finally { UI.Hourglass(false); }
	}
	#endregion

	#region Load All Trees
	private void LoadAllTrees()
	{

		try
		{
			LoadTree( tvSample, OpenSkieScheduler.OpenSkieSchedule.data, OpenSkieScheduler.SessionMacroTable.TableName
				, OpenSkieScheduler.SessionMacroTable.NameColumn );
			List<String> tables = new List<String>();
			foreach( DataTable table in OpenSkieScheduler.OpenSkieSchedule.data.Tables )
			{
				tables.Add( table.TableName );
			}
			listBox1.DataSource = tables;
			
            //LoadTree(tvSample2,Rules.GetHierarchy(DBConStr,2));
		}
		catch (Exception) { throw; }
	}
	#endregion

    #region Load Tree
    private void LoadTree(TreeView tv,DataSet ds, String TableName, String NameColumn)
    {

      UI.Hourglass(true);
      try
      {
		  TreeViewUtil.LoadFromDataSet( tv, ds
			  , TableName
				, NameColumn );
        
        if (tv.Nodes.Count > 0)
        {
			TreeNode open = tv.Nodes[0];
			do
			{
				open.Expand();
				if( open.Nodes.Count > 0 )
					open = open.Nodes[0];
				else
					open = null;
			}
			while( open != null );

			//tv.Nodes[0].Expand();

        }

      }
      catch (Exception) { throw; }
      finally
      {
          UI.Hourglass(false);
      } 
    }
    #endregion

    #region tvSample1 Right Click Delete
    private void tvSample1RightClickDelete(object sender, System.EventArgs e)
    {
          
      UI.Hourglass(true);

      try
      {
		  TreeViewUtil.DeleteNode(tvSample,true);
      }
      catch (Exception err) { UI.ShowError(err.Message); }
      finally {   UI.Hourglass(false); }
    }
    #endregion

	#region tvSample2 Right Click Delete
	private void tvSample2RightClickDelete(object sender, System.EventArgs e)
	{
          
		  UI.Hourglass(true);
	  
		  try
		  {
			  TreeViewUtil.DeleteNode(tvSample2,true);
		  }
		  catch (Exception err) { UI.ShowError(err.Message); }
		  finally {   UI.Hourglass(false); }
	}
	#endregion

    #region tvSample1 Right Click Edit
	private void tvSample1RightClickEdit(object sender, System.EventArgs e)
	{
          
		  UI.Hourglass(true);
	  
		  try
		  {

			  TreeNode node = tvSample.SelectedNode;
 
              if (node == null) { return; }

              node.TreeView.LabelEdit = true;

              node.BeginEdit();

		  }
		  catch (Exception err) { UI.ShowError(err.Message); }
		  finally {   UI.Hourglass(false); }
	}
	#endregion

    #region tvSample2 Right Click Edit
	private void tvSample2RightClickEdit(object sender, System.EventArgs e)
	{
          
		  UI.Hourglass(true);
	  
		  try
		  {

			  TreeNode node = tvSample2.SelectedNode;
 
              if (node == null) { return; }

              node.TreeView.LabelEdit = true;

              node.BeginEdit();

		  }
		  catch (Exception err) { UI.ShowError(err.Message); }
		  finally {   UI.Hourglass(false); }
	}
	#endregion

    #region tvSample1 Right Click Nudge Up
	private void tvSample1RightClickNudgeUp(object sender, System.EventArgs e)
	{
          
		  UI.Hourglass(true);
	       
		  try
		  {
			  TreeViewUtil.NudgeUp(tvSample.SelectedNode);
		  }
		  catch (Exception err) { UI.ShowError(err.Message); }
		  finally {   UI.Hourglass(false); }
	}
	#endregion

    #region tvSample1 Right Click Nudge Down
	private void tvSample1RightClickNudgeDown(object sender, System.EventArgs e)
	{
          
		  UI.Hourglass(true);
	       
		  try
		  {
			  TreeViewUtil.NudgeDown(tvSample.SelectedNode);
		  }
		  catch (Exception err) { UI.ShowError(err.Message); }
		  finally {   UI.Hourglass(false); }
	}
	#endregion

    #region tvSample2 Right Click Nudge Up
	private void tvSample2RightClickNudgeUp(object sender, System.EventArgs e)
	{
          
		  UI.Hourglass(true);
	       
		  try
		  {
			  TreeViewUtil.NudgeUp(tvSample2.SelectedNode);
		  }
		  catch (Exception err) { UI.ShowError(err.Message); }
		  finally {   UI.Hourglass(false); }
	}
	#endregion

    #region tvSample2 Right Click Nudge Down
	private void tvSample2RightClickNudgeDown(object sender, System.EventArgs e)
	{
          
		  UI.Hourglass(true);
	       
		  try
		  {
			  TreeViewUtil.NudgeDown(tvSample2.SelectedNode);
		  }
		  catch (Exception err) { UI.ShowError(err.Message); }
		  finally {   UI.Hourglass(false); }
	}
	#endregion

    #region tvSample1 Right Click Insert
	private void tvSample1RightClickInsert(object sender, System.EventArgs e)
	{
          
		  UI.Hourglass(true);
	  
		  try
		  {

			  TreeNode node = tvSample.SelectedNode;
 
              if (node == null) { return; }

              InsertNewNode(node);

		  }
		  catch (Exception err) { UI.ShowError(err.Message); }
		  finally {   UI.Hourglass(false); }
	}
	#endregion

    #region tvSample2 Right Click Insert
	private void tvSample2RightClickInsert(object sender, System.EventArgs e)
	{
          
		  UI.Hourglass(true);
	  
		  try
		  {

              TreeNode node = tvSample2.SelectedNode;
 
              if (node == null) { return; }

              InsertNewNode(node);

		  }
		  catch (Exception err) { UI.ShowError(err.Message); }
		  finally {   UI.Hourglass(false); }
	}
	#endregion

    #region Insert New Node
      private void InsertNewNode(TreeNode node)
      {
  
         DataRow row = null;
         DataRow ParentRow = null;
         DataTable dt = null;
         int newindex = 0;

         try
         {

             ParentRow = (DataRow)node.Tag; 

             if (ParentRow == null) { return; }

             newindex = int.Parse(ParentRow["SortOrder"].ToString()) + 1;

             dt = ParentRow.Table;

             row = dt.NewRow();
 
             row["ObjectID"] = Guid.NewGuid().ToString();
             row["ObjectTypeID"] = 1;
             row["ModelID"] = int.Parse(ParentRow["ModelID"].ToString());
			 row["NodeID"] = Guid.NewGuid().ToString();
			 row["ParentNodeID"] = ParentRow[dt.PrimaryKey[0].ColumnName].ToString();
             row["Description"] = "New Node";
			 row["ForeColor"] = "#000000";
			 row["BackColor"] = "#FFFFFF";
			 row["ImageIndex"] = 0;
			 row["SelectedImageIndex"] = 1;
			 row["Checked"] = true;
             row["ActiveID"] = 1;
             row["NamedRange"] = "";
             row["NodeValue"] = "";
             row["LastUpdateTime"] = DateTime.Now;
             row["SortOrder"] = newindex;

             dt.Rows.Add(row);

             node.Nodes.Add(TreeViewUtil.GetTreeNodeFromDataRow(row,"Description")); 

         }
         catch (Exception) 
		 {
			 throw;
		 }

      }
      #endregion

    #region Edit Node
    private void EditNode(TreeNode node,string newText)
    {
         DataRow row = null;

         try
         {

            if (node == null) { return; }
            
            row = (DataRow)node.Tag;

            if (row == null) { return; }
 
            row["Description"] = newText;

         }
         catch (Exception) { throw; }

    }
    #endregion

    #region Button Reload Test Data
  	private void button1_Click(object sender, System.EventArgs e)
	{
	    LoadAllTrees();
	}
	#endregion

    #region Button Export Trees To Xml
  	private void button2_Click(object sender, System.EventArgs e)
	{

      string filename = "";
      DataSet ds;
	  DataRow row;
      DataSet compareds;

	  try
	  {

		  UI.Hourglass(true);
 
		  // Write out the contents of tvSample to disk

		  filename = Path.Combine(AppPath,"treeview1.xml");

		  if (File.Exists(filename))  { File.Delete(filename); }

		  if (tvSample.Nodes.Count == 0) { return; }

		  row = (DataRow)tvSample.Nodes[0].Tag; 

		  ds = row.Table.DataSet; 

          compareds = ds.GetChanges(); 

          if (compareds != null)
          {
		   compareds.WriteXml(filename,XmlWriteMode.DiffGram);
          }

		  // Write out the contents of tvSample2 to disk

		  filename = Path.Combine(AppPath,"treeview2.xml");

		  if (File.Exists(filename))  { File.Delete(filename); }

		  if (tvSample2.Nodes.Count == 0) { return; }

		  row = (DataRow)tvSample2.Nodes[0].Tag; 

		  ds = row.Table.DataSet; 

		  compareds = ds.GetChanges();
 
		  if (compareds != null)
          {
		   compareds.WriteXml(filename,XmlWriteMode.DiffGram);
          }

		  
	  }
	  catch (Exception err) { UI.ShowError(err.Message); }
	  finally {   UI.Hourglass(false); }
	}
	#endregion

    #region tvSample Mouse Down
    private void tvSample_MouseDown(object sender, System.Windows.Forms.MouseEventArgs e)
    {
     
        TreeViewUtil.SetSelectedNodeByPosition(tvSample,e.X,e.Y);

        if (tvSample.SelectedNode == null) { return; }

        if (e.Button == MouseButtons.Right) { return; } 
		 
    }
    #endregion

    #region tvSample MouseUp
    private void tvSample_MouseUp(object sender, System.Windows.Forms.MouseEventArgs e)
    {

		switch (e.Button)
		{
			case MouseButtons.Right:
			    
				 tvSample1Menu.Show(tvSample,new Point(e.X,e.Y));                
				 return;
 
			default:
				 break;
		}
      
     }
    #endregion

    #region tvSample2 Mouse Down
    private void tvSample2_MouseDown(object sender, System.Windows.Forms.MouseEventArgs e)
    {

        TreeViewUtil.SetSelectedNodeByPosition(tvSample2,e.X,e.Y);

        if (tvSample2.SelectedNode == null) { return; }

        if (e.Button == MouseButtons.Right) { return; } 

    }
    #endregion

	#region tvSample2 MouseUp
	private void tvSample2_MouseUp(object sender, System.Windows.Forms.MouseEventArgs e)
	{

		  switch (e.Button)
		  {
			  case MouseButtons.Right:
			    
				  tvSample2Menu.Show(tvSample2,new Point(e.X,e.Y));                
				  break;

			  default:
				  break;
		  }
    }
    #endregion

	#region tvSample Drag And Drop Events
  	private void tvSample_ItemDrag(object sender, System.Windows.Forms.ItemDragEventArgs e)
	{
	    DoDragDrop(e.Item, DragDropEffects.Move);
	}

  	private void tvSample_DragEnter(object sender, System.Windows.Forms.DragEventArgs e)
	{         
        TreeViewUtil.DragEnter((TreeView)sender,e);
	}
 
  	private void tvSample_DragOver(object sender, System.Windows.Forms.DragEventArgs e)
	{
        TreeViewUtil.DragOver((TreeView)sender,e);
	}

  	private void tvSample_DragDrop(object sender, System.Windows.Forms.DragEventArgs e)
	{
      DataRow row;
      bool dropOnNewControl = false;

      try
      {
       
       UI.Hourglass(true);
	   
       TreeViewUtil.DragDrop((TreeView)sender,e,ref dropOnNewControl);

       if (dropOnNewControl)
       {
          row = (DataRow)tvSample2.Nodes[0].Tag;
          //Rules.CommitHierarchy(DBConStr,row.Table.DataSet);
          row = (DataRow)tvSample.Nodes[0].Tag;
          //Rules.CommitHierarchy(DBConStr,row.Table.DataSet);
       }
       
    //   this.LoadAllTrees();  

       UI.Hourglass(false);
      }
      catch (Exception err) { UI.ShowError(err.Message); } 
      finally { UI.Hourglass(false); }
	}
	#endregion

    #region tvSample2 Drag And Drop Events
    private void tvSample2_ItemDrag(object sender, System.Windows.Forms.ItemDragEventArgs e)
    {
 	  DoDragDrop(e.Item, DragDropEffects.Move);
    }

    private void tvSample2_DragEnter(object sender, System.Windows.Forms.DragEventArgs e)
    {         
  	  TreeViewUtil.DragEnter((TreeView)sender,e);
    }
 
    private void tvSample2_DragOver(object sender, System.Windows.Forms.DragEventArgs e)
    {
	  TreeViewUtil.DragOver((TreeView)sender,e);
    }

    private void tvSample2_DragDrop(object sender, System.Windows.Forms.DragEventArgs e)
    {
      DataRow row;
      bool dropOnNewControl = false;

      try
      {
       
       UI.Hourglass(true);
	   
       TreeViewUtil.DragDrop((TreeView)sender,e,ref dropOnNewControl);

       if (dropOnNewControl)
       {
          row = (DataRow)tvSample.Nodes[0].Tag;
          //Rules.CommitHierarchy(DBConStr,row.Table.DataSet);
          row = (DataRow)tvSample2.Nodes[0].Tag;
          //Rules.CommitHierarchy(DBConStr,row.Table.DataSet);
       }
       
       UI.Hourglass(false);
      }
      catch (Exception err) { UI.ShowError(err.Message); } 
      finally { UI.Hourglass(false); }
    }
    #endregion

    #region tvSample1 After Label Edit
      private void tvSample_AfterLabelEdit(object sender, System.Windows.Forms.NodeLabelEditEventArgs e)
      {
         try
         {
             if (e.Label.Trim().Length < 1) { e.CancelEdit = true; }  
             EditNode(tvSample.SelectedNode,e.Label);
             tvSample.SelectedNode.EndEdit(false);
             tvSample.LabelEdit = false;
         }
         catch (Exception err) { UI.ShowError(err.Message); }
      }
      #endregion

    #region tvSample2 After Label Edit
      private void tvSample2_AfterLabelEdit(object sender, System.Windows.Forms.NodeLabelEditEventArgs e)
      {
         try
         {
             if (e.Label.Trim().Length < 1) { e.CancelEdit = true; }  
             EditNode(tvSample2.SelectedNode,e.Label);
             tvSample2.SelectedNode.EndEdit(false);
             tvSample2.LabelEdit = false;
         }
         catch (Exception err) { UI.ShowError(err.Message); }
      }
      #endregion

    #region tvSample1 Accept Changes
    private void button3_Click(object sender, System.EventArgs e)
    {

        DataRow row = null;
        UI.Hourglass(true); 

         try
         {

            if (tvSample.Nodes.Count == 0) { return; }

            row = (DataRow)tvSample.Nodes[0].Tag;

            //Rules.CommitHierarchy(DBConStr,row.Table.DataSet);

         }
	     catch (Exception err) { UI.ShowError(err.Message); }
	     finally {   UI.Hourglass(false); }

    }
    #endregion

    #region tvSample1 Reject Changes
    private void button4_Click(object sender, System.EventArgs e)
    {
   
        DataRow row = null;
        UI.Hourglass(true);

         try
         {

            if (tvSample.Nodes.Count < 1) { return; }

            row = (DataRow)tvSample.Nodes[0].Tag;

            row.Table.DataSet.RejectChanges(); 

            //LoadTree(tvSample,row.Table.DataSet, "session_info", "session_name" );
			String TableName = listBox1.SelectedItem as String;
			DataTable table = OpenSkieScheduler.OpenSkieSchedule.data.Tables[TableName];
			LoadTree( tvSample, OpenSkieScheduler.OpenSkieSchedule.data
				, table.TableName
				, xperdex.classes.XDataTable.Name( table ) );
            
         }
         catch (Exception err) { UI.ShowError(err.Message); }
	     finally {   UI.Hourglass(false); }
    }
    #endregion

    #region tvSample2 Accept Changes
    private void button6_Click(object sender, System.EventArgs e)
    {

         DataRow row = null;
         UI.Hourglass(true); 

         try
         {

		    if (tvSample2.Nodes.Count == 0) { return; }

            row = (DataRow)tvSample2.Nodes[0].Tag;

            //Rules.CommitHierarchy(DBConStr,row.Table.DataSet);  
            
         }
	     catch (Exception err) { UI.ShowError(err.Message); }
	     finally {   UI.Hourglass(false); }
    }
    #endregion

    #region tvSample2 Reject Changes
    private void button5_Click(object sender, System.EventArgs e)
    {

         DataRow row = null;
         UI.Hourglass(true);

         try
         {

            if (tvSample2.Nodes.Count < 1) { return; }

            row = (DataRow)tvSample2.Nodes[0].Tag;

            row.Table.DataSet.RejectChanges();

			String TableName = listBox1.SelectedItem as String;
			DataTable table = OpenSkieScheduler.OpenSkieSchedule.data.Tables[TableName];
			LoadTree( tvSample, OpenSkieScheduler.OpenSkieSchedule.data
				, table.TableName
				, xperdex.classes.XDataTable.Name( table ) );
			//LoadTree( tvSample2, row.Table.DataSet );
            
         }
         catch (Exception err) { UI.ShowError(err.Message); }
	     finally {   UI.Hourglass(false); }
    }
    #endregion

	#region Form Closed
	  private void Form1_Closed(object sender, System.EventArgs e)
	  {
          
	  }
	  #endregion

	#region Exit
	  private void cmdExit_Click(object sender, System.EventArgs e)
	  {
		  this.Close();
		  Application.Exit(); 
	  }
	  #endregion

	#region Constructor

	  [STAThread]
	  static void Main() 
	  {
		  //new OpenSkieScheduler.Relations.Meta.MetaRelations.SessionGameMetaRelation( OpenSkieScheduler.OpenSkieSchedule.data );
		  //new OpenSkieScheduler.Relations.Meta.MetaRelations.SessionPackMetaRelation( OpenSkieScheduler.OpenSkieSchedule.data );
		  new PrizeScheduleEditor.Form1().Show();
		  Application.Run(new Form1());
	  }

	  public Form1()
	  {
		  InitializeComponent();
	  }

	  protected override void Dispose( bool disposing )
	  {
		  if( disposing )
		  {
			  if (components != null) 
			  {
				  components.Dispose();
			  }
		  }
		  base.Dispose( disposing );
	  }
	  #endregion

	#region Windows Form Designer generated code
	  private void InitializeComponent()
	  {
		  this.components = new System.ComponentModel.Container();
		  System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager( typeof( Form1 ) );
		  this.label1 = new System.Windows.Forms.Label();
		  this.tvSample = new System.Windows.Forms.TreeView();
		  this.imageList1 = new System.Windows.Forms.ImageList( this.components );
		  this.button1 = new System.Windows.Forms.Button();
		  this.button2 = new System.Windows.Forms.Button();
		  this.tvSample2 = new System.Windows.Forms.TreeView();
		  this.label2 = new System.Windows.Forms.Label();
		  this.button3 = new System.Windows.Forms.Button();
		  this.button4 = new System.Windows.Forms.Button();
		  this.button5 = new System.Windows.Forms.Button();
		  this.button6 = new System.Windows.Forms.Button();
		  this.listBox1 = new System.Windows.Forms.ListBox();
		  this.SuspendLayout();
		  // 
		  // label1
		  // 
		  this.label1.Location = new System.Drawing.Point( 8, 8 );
		  this.label1.Name = "label1";
		  this.label1.Size = new System.Drawing.Size( 256, 16 );
		  this.label1.TabIndex = 4;
		  this.label1.Text = "Tree 1";
		  // 
		  // tvSample
		  // 
		  this.tvSample.AllowDrop = true;
		  this.tvSample.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
		  this.tvSample.HideSelection = false;
		  this.tvSample.ImageIndex = 0;
		  this.tvSample.ImageList = this.imageList1;
		  this.tvSample.Location = new System.Drawing.Point( 8, 32 );
		  this.tvSample.Name = "tvSample";
		  this.tvSample.SelectedImageIndex = 0;
		  this.tvSample.Size = new System.Drawing.Size( 312, 328 );
		  this.tvSample.TabIndex = 17;
		  this.tvSample.AfterLabelEdit += new System.Windows.Forms.NodeLabelEditEventHandler( this.tvSample_AfterLabelEdit );
		  this.tvSample.MouseUp += new System.Windows.Forms.MouseEventHandler( this.tvSample_MouseUp );
		  this.tvSample.DragDrop += new System.Windows.Forms.DragEventHandler( this.tvSample_DragDrop );
		  this.tvSample.MouseDown += new System.Windows.Forms.MouseEventHandler( this.tvSample_MouseDown );
		  this.tvSample.DragEnter += new System.Windows.Forms.DragEventHandler( this.tvSample_DragEnter );
		  this.tvSample.ItemDrag += new System.Windows.Forms.ItemDragEventHandler( this.tvSample_ItemDrag );
		  this.tvSample.DragOver += new System.Windows.Forms.DragEventHandler( this.tvSample_DragOver );
		  // 
		  // imageList1
		  // 
		  this.imageList1.ImageStream = ( (System.Windows.Forms.ImageListStreamer)( resources.GetObject( "imageList1.ImageStream" ) ) );
		  this.imageList1.TransparentColor = System.Drawing.Color.Transparent;
		  this.imageList1.Images.SetKeyName( 0, "" );
		  this.imageList1.Images.SetKeyName( 1, "" );
		  this.imageList1.Images.SetKeyName( 2, "" );
		  // 
		  // button1
		  // 
		  this.button1.Location = new System.Drawing.Point( 328, 400 );
		  this.button1.Name = "button1";
		  this.button1.Size = new System.Drawing.Size( 104, 24 );
		  this.button1.TabIndex = 19;
		  this.button1.Text = "Reload Test Data";
		  this.button1.Click += new System.EventHandler( this.button1_Click );
		  // 
		  // button2
		  // 
		  this.button2.Location = new System.Drawing.Point( 440, 400 );
		  this.button2.Name = "button2";
		  this.button2.Size = new System.Drawing.Size( 152, 24 );
		  this.button2.TabIndex = 20;
		  this.button2.Text = "Save Xml To  Root Folder";
		  this.button2.Click += new System.EventHandler( this.button2_Click );
		  // 
		  // tvSample2
		  // 
		  this.tvSample2.AllowDrop = true;
		  this.tvSample2.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
		  this.tvSample2.ImageIndex = 0;
		  this.tvSample2.ImageList = this.imageList1;
		  this.tvSample2.Location = new System.Drawing.Point( 328, 32 );
		  this.tvSample2.Name = "tvSample2";
		  this.tvSample2.SelectedImageIndex = 0;
		  this.tvSample2.Size = new System.Drawing.Size( 312, 108 );
		  this.tvSample2.TabIndex = 21;
		  this.tvSample2.AfterLabelEdit += new System.Windows.Forms.NodeLabelEditEventHandler( this.tvSample2_AfterLabelEdit );
		  this.tvSample2.MouseUp += new System.Windows.Forms.MouseEventHandler( this.tvSample2_MouseUp );
		  this.tvSample2.DragDrop += new System.Windows.Forms.DragEventHandler( this.tvSample2_DragDrop );
		  this.tvSample2.MouseDown += new System.Windows.Forms.MouseEventHandler( this.tvSample2_MouseDown );
		  this.tvSample2.DragEnter += new System.Windows.Forms.DragEventHandler( this.tvSample2_DragEnter );
		  this.tvSample2.ItemDrag += new System.Windows.Forms.ItemDragEventHandler( this.tvSample2_ItemDrag );
		  this.tvSample2.DragOver += new System.Windows.Forms.DragEventHandler( this.tvSample2_DragOver );
		  // 
		  // label2
		  // 
		  this.label2.Location = new System.Drawing.Point( 328, 8 );
		  this.label2.Name = "label2";
		  this.label2.Size = new System.Drawing.Size( 256, 16 );
		  this.label2.TabIndex = 22;
		  this.label2.Text = "Tree 2";
		  // 
		  // button3
		  // 
		  this.button3.Location = new System.Drawing.Point( 8, 368 );
		  this.button3.Name = "button3";
		  this.button3.Size = new System.Drawing.Size( 112, 24 );
		  this.button3.TabIndex = 23;
		  this.button3.Text = "Accept Changes";
		  this.button3.Click += new System.EventHandler( this.button3_Click );
		  // 
		  // button4
		  // 
		  this.button4.Location = new System.Drawing.Point( 128, 368 );
		  this.button4.Name = "button4";
		  this.button4.Size = new System.Drawing.Size( 112, 24 );
		  this.button4.TabIndex = 24;
		  this.button4.Text = "Reject Changes";
		  this.button4.Click += new System.EventHandler( this.button4_Click );
		  // 
		  // button5
		  // 
		  this.button5.Location = new System.Drawing.Point( 435, 368 );
		  this.button5.Name = "button5";
		  this.button5.Size = new System.Drawing.Size( 96, 24 );
		  this.button5.TabIndex = 26;
		  this.button5.Text = "Reject Changes";
		  this.button5.Click += new System.EventHandler( this.button5_Click );
		  // 
		  // button6
		  // 
		  this.button6.Location = new System.Drawing.Point( 328, 368 );
		  this.button6.Name = "button6";
		  this.button6.Size = new System.Drawing.Size( 96, 24 );
		  this.button6.TabIndex = 25;
		  this.button6.Text = "Accept Changes";
		  this.button6.Click += new System.EventHandler( this.button6_Click );
		  // 
		  // listBox1
		  // 
		  this.listBox1.FormattingEnabled = true;
		  this.listBox1.Location = new System.Drawing.Point( 328, 146 );
		  this.listBox1.Name = "listBox1";
		  this.listBox1.Size = new System.Drawing.Size( 258, 121 );
		  this.listBox1.TabIndex = 27;
		  this.listBox1.SelectedIndexChanged += new System.EventHandler( this.listBox1_SelectedIndexChanged );
		  // 
		  // Form1
		  // 
		  this.AutoScaleBaseSize = new System.Drawing.Size( 5, 13 );
		  this.ClientSize = new System.Drawing.Size( 648, 429 );
		  this.Controls.Add( this.listBox1 );
		  this.Controls.Add( this.button5 );
		  this.Controls.Add( this.button6 );
		  this.Controls.Add( this.button4 );
		  this.Controls.Add( this.button3 );
		  this.Controls.Add( this.label2 );
		  this.Controls.Add( this.tvSample2 );
		  this.Controls.Add( this.button2 );
		  this.Controls.Add( this.button1 );
		  this.Controls.Add( this.tvSample );
		  this.Controls.Add( this.label1 );
		  this.MaximizeBox = false;
		  this.Name = "Form1";
		  this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
		  this.Text = "Tree Sample";
		  this.Load += new System.EventHandler( this.Form1_Load );
		  this.Closed += new System.EventHandler( this.Form1_Closed );
		  this.ResumeLayout( false );

      }
	  #endregion

	  private void listBox1_SelectedIndexChanged( object sender, EventArgs e )
	  {
		  String TableName = listBox1.SelectedItem as String;
		  DataTable table = OpenSkieScheduler.OpenSkieSchedule.data.Tables[TableName];
		  LoadTree( tvSample, OpenSkieScheduler.OpenSkieSchedule.data
			  , table.TableName
			  , xperdex.classes.XDataTable.Name( table ) );
	  }
 

	}
}
