/*
 * Created by SharpDevelop.
 * User: Zeppa'man
 * Date: 19/05/2006
 * Time: 17.30


Copyright (C) 2006 Daniele Fontani

This program is free software; you can redistribute it and/or
modify it under the terms of the GNU General Public License
as published by the Free Software Foundation; either version 2
of the License, or (at your option) any later version.
This program is distributed in the hope that it will be useful,
but WITHOUT ANY WARRANTY; without even the implied warranty of
MERCHANTABILITY or FITNESS FOR A PARTICULAR PURPOSE.  See the
GNU General Public License for more details. 
You should have received a copy of the GNU General Public License
along with this program; if not, write to the Free Software
Foundation, Inc., 59 Temple Place - Suite 330, Boston, MA  02111-1307, USA.


 */


using System;
using System.Windows.Forms;
using System.Collections;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Collections.Specialized;
using System.ComponentModel;
using System.Drawing;
using System.Xml;
using System.IO;
using Backupper.Dialogs;

namespace Backupper
{
	/// <summary>
	/// Description of ProjectManager.
	/// </summary>
		public partial class ProjectManager:Control
	{
	    
		private TreeView tr = new TreeView();			
		
		public string Settings =Application.StartupPath+"\\projects.xml";
			
		ContextMenuStrip _mn = new ContextMenuStrip ();
		
		ImageList _Immages= new ImageList();
		
		public ImageList Immages {
			get {
				return _Immages;
			}
			set {
				_Immages = value;
			}
		}
			
		Collection<project> _project= new Collection<project>();
	    
		private System.Windows.Forms.ToolStrip toolStrip1 = new System.Windows.Forms.ToolStrip();
		
		public string IconPath="";
		
		public ProjectManager()
		{  
			IconPath= Application.StartupPath+"\\Icons\\";
			
			//TOOLBAR
			
			// 
			// toolStrip1
			// 
			System.Windows.Forms.ToolStripButton toolStripButton1 = new System.Windows.Forms.ToolStripButton();
		System.Windows.Forms.ToolStripButton toolStripButton2 = new System.Windows.Forms.ToolStripButton();
		System.Windows.Forms.ToolStripButton toolStripButton3 = new System.Windows.Forms.ToolStripButton();
		System.Windows.Forms.ToolStripButton toolStripButton4 = new System.Windows.Forms.ToolStripButton();
		System.Windows.Forms.ToolStripButton toolStripButton5 = new System.Windows.Forms.ToolStripButton();
		System.Windows.Forms.ToolStripButton toolStripButton6 = new System.Windows.Forms.ToolStripButton();
		System.Windows.Forms.ToolStripSeparator toolStripSeparator1 = new System.Windows.Forms.ToolStripSeparator();
		System.Windows.Forms.ToolStripSeparator toolStripSeparator2 = new System.Windows.Forms.ToolStripSeparator();
		System.Windows.Forms.ToolStripSeparator toolStripSeparator3 = new System.Windows.Forms.ToolStripSeparator();
		System.Windows.Forms.ToolStripButton toolStripButton7 = new System.Windows.Forms.ToolStripButton();
		System.Windows.Forms.ToolStripSeparator toolStripSeparator4 = new System.Windows.Forms.ToolStripSeparator();
		System.Windows.Forms.ToolStripButton toolStripButton8 = new System.Windows.Forms.ToolStripButton();
		System.Windows.Forms.ToolStripSeparator toolStripSeparator5 = new System.Windows.Forms.ToolStripSeparator();
		System.Windows.Forms.ToolStripButton toolStripButton9 = new System.Windows.Forms.ToolStripButton();
		
		_Immages.ImageSize= new Size(32,32);
		_Immages.ColorDepth= ColorDepth.Depth16Bit;
		
			toolStrip1.Items.AddRange(new System.Windows.Forms.ToolStripItem[] {
									toolStripButton1,
									toolStripButton2,
									toolStripSeparator1,
									toolStripButton3,
									toolStripButton4,
									toolStripSeparator2,
									toolStripButton5,
									toolStripButton6,
									toolStripSeparator3,
									toolStripButton7,
									toolStripSeparator4,
									toolStripButton8,
									toolStripSeparator5,
									toolStripButton9});
		
			 toolStrip1.Location = new System.Drawing.Point(0, 0);
			 toolStrip1.Name = "toolStrip1";
			 toolStrip1.Size = new System.Drawing.Size(256, 25);
			 toolStrip1.TabIndex = 3;
			 toolStrip1.Text = "toolStrip1";
			// 
			// toolStripButton1
			// 
			 toolStripButton1.DisplayStyle = System.Windows.Forms.ToolStripItemDisplayStyle.Image;
			 toolStripButton1.ImageTransparentColor = System.Drawing.Color.Magenta;
			 toolStripButton1.Name = "ToolAddproject";
			 toolStripButton1.Size = new System.Drawing.Size(23, 22);
			 toolStripButton1.Text = "Add a Project";
			 
			 
			 toolStripButton1.Click += new System.EventHandler(this.AddProject);
			// 
			// toolStripButton2
			// 
			 toolStripButton2.DisplayStyle = System.Windows.Forms.ToolStripItemDisplayStyle.Image;
			 toolStripButton2.ImageTransparentColor = System.Drawing.Color.Magenta;
			 toolStripButton2.Name = "ToolAddItemToProject";
			 toolStripButton2.Size = new System.Drawing.Size(23, 22);
			 toolStripButton2.Text = "Add Item To Project";
			 toolStripButton2.Click += new System.EventHandler(this.AddItemToProject);
			 
			 		// 
			// toolStripButton3
			// 
			 toolStripButton3.DisplayStyle = System.Windows.Forms.ToolStripItemDisplayStyle.Image;
			 toolStripButton3.ImageTransparentColor = System.Drawing.Color.Magenta;
			 toolStripButton3.Name = "ToolRemoveProject";
			 toolStripButton3.Size = new System.Drawing.Size(23, 22);
			 toolStripButton3.Text = "Remove Project";
			 toolStripButton3.Click += new System.EventHandler(this.RemoveProject);
			 
			// 
			// toolStripButton4
			// 
			 toolStripButton4.DisplayStyle = System.Windows.Forms.ToolStripItemDisplayStyle.Image;
			 toolStripButton4.ImageTransparentColor = System.Drawing.Color.Magenta;
			 toolStripButton4.Name = "ToolRemoveItemToProject";
			 toolStripButton4.Size = new System.Drawing.Size(23, 22);
			 toolStripButton4.Text = "Remove Item from Project";
			 toolStripButton4.Click += new System.EventHandler(this.RemoveItemToProject);
		 
			// 
			// toolStripButton5
			// 
			 toolStripButton5.DisplayStyle = System.Windows.Forms.ToolStripItemDisplayStyle.Image;
			 toolStripButton5.ImageTransparentColor = System.Drawing.Color.Magenta;
			 toolStripButton5.Name = "ToolBackupProject";
			 toolStripButton5.Size = new System.Drawing.Size(23, 22);
			 toolStripButton5.Text = "Backup Project";
			 toolStripButton5.Click += new System.EventHandler(this.BackupSelectedProject);
					 
			 //
			// toolStripButton6
			// 
			 toolStripButton6.DisplayStyle = System.Windows.Forms.ToolStripItemDisplayStyle.Image;
			 toolStripButton6.ImageTransparentColor = System.Drawing.Color.Magenta;
			 toolStripButton6.Name = "ToolBackupAllProjects";
			 toolStripButton6.Size = new System.Drawing.Size(23, 22);
			 toolStripButton6.Text = "BackupAllProjects";			 
			 toolStripButton6.Click += new System.EventHandler(this.BackupAllProjects);
		   
			 // 
			// toolStripSeparator1
			// 
			 toolStripSeparator1.Name = "toolStripSeparator1";
			 toolStripSeparator1.Size = new System.Drawing.Size(6, 25);
			// 
			// toolStripSeparator2
			// 
			 toolStripSeparator2.Name = "toolStripSeparator2";
			 toolStripSeparator2.Size = new System.Drawing.Size(6, 25);
			// 
			// toolStripSeparator3
			// 
			 toolStripSeparator3.Name = "toolStripSeparator3";
			 toolStripSeparator3.Size = new System.Drawing.Size(6, 25);
			
			//
			// toolStripButton7
			// 
			 toolStripButton7.DisplayStyle = System.Windows.Forms.ToolStripItemDisplayStyle.Image;
			 toolStripButton7.ImageTransparentColor = System.Drawing.Color.Magenta;
			 toolStripButton7.Name = "ToolSaveAll";
			 toolStripButton7.Size = new System.Drawing.Size(23, 22);
			 toolStripButton7.Text = "SaveAll";			 
			 toolStripButton7.Click += new System.EventHandler(this.SaveAll);
		    
			 // 
			// toolStripSeparator4
			// 
			 toolStripSeparator4.Name = "toolStripSeparator4";
			 toolStripSeparator4.Size = new System.Drawing.Size(6, 25);
			
			//
			// toolStripButton8
			// 
			 toolStripButton8.DisplayStyle = System.Windows.Forms.ToolStripItemDisplayStyle.Image;
			 toolStripButton8.ImageTransparentColor = System.Drawing.Color.Magenta;
			 toolStripButton8.Name = "ToolOpenBackup";
			 toolStripButton8.Size = new System.Drawing.Size(23, 22);
			 toolStripButton8.Text = "OpenBackup";			 
			 toolStripButton8.Click += new System.EventHandler(this.OpenBackup);
		    // 
			// toolStripSeparator5
			// 
			 toolStripSeparator5.Name = "toolStripSeparator5";
			 toolStripSeparator5.Size = new System.Drawing.Size(6, 25);
			
			//
			// toolStripButton9
			// 
			 toolStripButton9.DisplayStyle = System.Windows.Forms.ToolStripItemDisplayStyle.Image;
			 toolStripButton9.ImageTransparentColor = System.Drawing.Color.Magenta;
			 toolStripButton9.Name = "AboutAndInfo";
			 toolStripButton9.Size = new System.Drawing.Size(23, 22);
			 toolStripButton9.Text = "About";			 
			 toolStripButton9.Click += new System.EventHandler(this.ShowAbout);
		   
			//PUPUP MENU
			_mn.Items.Add("Aggiungi Progetto");
		
			_mn.Items.Add("Aggiungi oggetto al progetto selezionato");
			_mn.Items.Add("-");
			_mn.Items.Add("Elimina progetto");
			_mn.Items.Add("Elimina oggetto");
			_mn.Items.Add("-");
			_mn.Items.Add("Backup");
			_mn.Items.Add("BAckupAll");
			_mn.Items.Add("-");
			_mn.Items.Add("Open Backup");
		
		this.ContextMenuStrip=_mn;
		//Add project
		this._mn.Items[0].Click+= new EventHandler(this.AddProject);
		//Add item
		this._mn.Items[1].Click+= new EventHandler(this.AddItemToProject);
		//Remove project
		this._mn.Items[3].Click+= new EventHandler(this.RemoveProject);
		//Remove Item
		this._mn.Items[4].Click+= new EventHandler(this.RemoveItemToProject);
		//BAckup project
		this._mn.Items[6].Click+= new EventHandler(this.BackupSelectedProject);
		//Backup All project
		this._mn.Items[7].Click+= new EventHandler(this.BackupAllProjects);
		//Backup All project
		this._mn.Items[9].Click+= new EventHandler(this.OpenBackup);
		
		
		this.MouseDown += new System.Windows.Forms.MouseEventHandler(this.pMouseDown);
		
		
		//Adding Imags
		
		
		
			 if (File.Exists(IconPath+"project_add.ico"))
			 {
		 		toolStripButton1.Image = Image.FromFile(IconPath+"project_add.ico");
			 	_mn.Items[0].Image=toolStripButton1.Image;
			 }
			else
			{
			 	toolStripButton1.DisplayStyle= ToolStripItemDisplayStyle.Text;
			}
		
			 if (File.Exists(IconPath+"item_add.ico"))
			 {
			 	toolStripButton2.Image = Image.FromFile(IconPath+"item_add.ico");
			 	_mn.Items[1].Image=toolStripButton2.Image;
			 }
			 else
			 {
			 	toolStripButton2.DisplayStyle= ToolStripItemDisplayStyle.Text;
			 
			 }
	
			 if (File.Exists(IconPath+"project_delete.ico"))
			 {
			 	toolStripButton3.Image = Image.FromFile(IconPath+"project_delete.ico");
			 	_mn.Items[3].Image=toolStripButton3.Image;
			 }
			 else
			 {
			 	toolStripButton3.DisplayStyle= ToolStripItemDisplayStyle.Text;
			 	
			 }
		
			 if (File.Exists(IconPath+"item_delete.ico"))
			 {
			 	toolStripButton4.Image = Image.FromFile(IconPath+"item_delete.ico");
			 	_mn.Items[4].Image=toolStripButton4.Image;
			 }
			 else
			 {
			 	toolStripButton4.DisplayStyle= ToolStripItemDisplayStyle.Text;
			 	
			 }
			
			 if (File.Exists(IconPath+"backup_selected.ico"))
			 {
			 	toolStripButton5.Image = Image.FromFile(IconPath+"backup_selected.ico");
			 	_mn.Items[6].Image=toolStripButton5.Image;
			 }
			 else
			 {
			 	toolStripButton5.DisplayStyle= ToolStripItemDisplayStyle.Text;
			 	
			 }

			 if (File.Exists(IconPath+"backup_all.ico"))
			 {
			 	toolStripButton6.Image = Image.FromFile(IconPath+"backup_all.ico");
			 	_mn.Items[7].Image=toolStripButton6.Image;
			 }
			 else
			 {
			 	toolStripButton7.DisplayStyle= ToolStripItemDisplayStyle.Text;
			 }
			 
			 if (File.Exists(IconPath+"safe.ico"))
			 {
			 	toolStripButton8.Image = Image.FromFile(IconPath+"safe.ico");
			 	_mn.Items[9].Image=toolStripButton6.Image;
			 }
			 else
			 {
			 	toolStripButton8.DisplayStyle= ToolStripItemDisplayStyle.Text;
			 }
			 
			 if (File.Exists(IconPath+"save.ico"))
			 {
			 	toolStripButton7.Image = Image.FromFile(IconPath+"save.ico");
			 	
			 }
			 else
			 {
			 	toolStripButton7.DisplayStyle= ToolStripItemDisplayStyle.Text;
			 }
			 
		    if (File.Exists(IconPath+"project.ico"))
			 {
			 	
			 	_Immages.Images.Add("project",Image.FromFile(IconPath+"project.ico"));
			 }
			 
		    
			  if (File.Exists(IconPath+"item.ico"))
			 {
			 	_Immages.Images.Add("item",Image.FromFile(IconPath+"item.ico"));
			 }
			  if (File.Exists(IconPath+"folder.ico"))
			 {
			 	_Immages.Images.Add("folder",Image.FromFile(IconPath+"folder.ico"));
			 }
			   if (File.Exists(IconPath+"about.ico"))
			 {
			 	toolStripButton9.Image=Image.FromFile(IconPath+"about.ico");
			 }
		 else
			 {
			 	toolStripButton9.DisplayStyle= ToolStripItemDisplayStyle.Text;
			 }
		
	    this.Controls.Add(toolStrip1);
		
		toolStrip1.Dock=DockStyle.Top;
		toolStrip1.ImageScalingSize= new Size(32,32);
		
		this.Controls.Add(tr);
		
		tr.Dock=DockStyle.Bottom;
		
		tr.ImageList=_Immages;
	
		
		
		this.tr.AfterSelect+= new TreeViewEventHandler(AfterSelect);
		this.tr.ShowNodeToolTips=true;
		this.tr.LineColor=Color.SkyBlue;
		
		}
	void ShowAbout (object sender,EventArgs e)
	{
		About ab = new About();
		ab.ShowDialog();
		
	}
		void OpenBackup (object sender,EventArgs e)
		{

			if( (this.tr.SelectedNode!=null)&&(this.tr.SelectedNode.Level==0))
			{
			if (Directory.Exists(Application.StartupPath+"\\Backups\\"+	this._project[this.tr.SelectedNode.Index].Text+"\\"))
					System.Diagnostics.Process.Start(Application.StartupPath+"\\Backups\\"+	this._project[this.tr.SelectedNode.Index].Text+"\\");
			else
				MessageBox.Show("DIRECTORY NOT FOUND.");
			
			}
			else
			{
				if (Directory.Exists(Application.StartupPath+"\\Backups\\"))
			
				System.Diagnostics.Process.Start(Application.StartupPath+"\\Backups\\");
				else
				MessageBox.Show("DIRECTORY NOT FOUND.");
			
			}
		}
		protected override void OnResize(EventArgs e)
		{
			base.OnResize(e);
				tr.Height=this.ClientRectangle.Height-this.toolStrip1.Height;
		}
		void pMouseDown(object sender, System.Windows.Forms.MouseEventArgs e)
		{
			
			if(e.Button== MouseButtons.Right)
			{
				_mn.Show(this,e.Location);
			
			}
		}
		void BackupSelectedProject(object sender, System.EventArgs e)
		{
			if( (this.tr.SelectedNode!=null)&&(this.tr.SelectedNode.Level==0))
			{
				this.BackupProject(this.tr.SelectedNode.Index);
			}else
				MessageBox.Show("Please select a project.");
		}
		
		void BackupAllProjects(object sender, System.EventArgs e)
		{
			for (int i=0 ;i<this.tr.Nodes.Count;i++)
			{
				this.BackupProject(i);
			}
		}
		void RemoveProject(object sender, System.EventArgs e)
	{
			if(	this.tr.SelectedNode.Level==0)
			{
				this._project.Remove(this._project[this.tr.SelectedNode.Index]);
			
			
				this.tr.Nodes.Remove(this.tr.SelectedNode);
			
			}
	}
		void RemoveItemToProject(object sender, System.EventArgs e)
	{
		if(	this.tr.SelectedNode.Level==1)
			{
			int pro=this.tr.SelectedNode.Parent.Index;
			
			this._project[pro].Items.Remove(this._project[pro].Items[this.tr.SelectedNode.Index]);
			
			
				this.tr.Nodes.Remove(this.tr.SelectedNode);
			
			}
		
	}
	void AddProject(object sender, System.EventArgs e)
	{
		AddProject _ad= new AddProject();
		
		if (_ad.ShowDialog()==DialogResult.OK)
		
		this.AddProject(_ad.Projectname);
			
	}
	public void AddProject(string name)
    {
		project _pr= new project();
		_pr.Text=name;
		_pr.ToolTipText=name;
		_pr.ImageKey="project";
		this._project.Add(_pr);
		
		this.tr.Nodes.Add(_pr);
		
	}
	
	void AddItemToProject(object sender, System.EventArgs e)
	{
		if(this.tr.SelectedNode!=null)
	{
		int level=this.tr.SelectedNode.Level;
		
		if (level==0)
		
		{
		
		
		AddItem _ad= new AddItem ();
		
		if (_ad.ShowDialog()==DialogResult.OK)
		{
			
		Item it;
		
		if (_ad.IncludeSubItems==false)
		{
		
			if( _ad.FileNames.Length>0 )
		
			{
		
				foreach(string filename in _ad.FileNames)
		{
	
		
		
		 it= new Item();
		
		
		it.FileName=filename ;
		
		string name= Path.GetFileName(filename);
		                              
		it.Text=name;
		it.ToolTipText=filename;
		
		it.ImageKey="item";
		it.AllFolder= _ad.IncludeSubItems;
		
		this._project[this.tr.SelectedNode.Index].Items.Add(it);
		this._project[this.tr.SelectedNode.Index].Nodes.Add(it);
		
		}
			}else
			{
			
				MessageBox.Show("Nothing to insert");
	
			
			}
			
		}
		else
		{
		
		
	    it= new Item();
	    
	    it.ImageKey="folder";
		string filename= _ad.FolderName;
			
		it.FileName=filename ;
		
		string name= Path.GetFileName(filename);
		                              
		it.Text=name;
		it.ToolTipText=filename;
		
		
		it.AllFolder= _ad.IncludeSubItems;
		
		this._project[this.tr.SelectedNode.Index].Items.Add(it);
		this._project[this.tr.SelectedNode.Index].Nodes.Add(it);
		
		
		}
		}
		}
		}
	else
	{
		MessageBox.Show("Error.Please select a node.");
	}
	
	}
	
	 void AfterSelect(object sender,System.Windows.Forms.TreeViewEventArgs e)
	{
	 tr.SelectedImageKey= tr.SelectedNode.ImageKey;

	 }
		
	public void DeleteProject(project x)
    {
		if (MessageBox.Show("Eliminare il progetto?","Attenzione", MessageBoxButtons.YesNo, MessageBoxIcon.Question, MessageBoxDefaultButton.Button2,MessageBoxOptions.RightAlign)==DialogResult.Yes)
			
			this.tr.Nodes.Remove(x);
	
	
	}
    public void AddItemToProject()
    {
    
    }
    
    public void BackupAllProjects()
    {}
  public void BackupSubItems(DirectoryInfo Folder,string newFolder)
  { 
  	Directory.CreateDirectory(newFolder);
  	
  	FileInfo[] Files= Folder.GetFiles();
    	
  	DirectoryInfo[] Directories=Folder.GetDirectories();

    	foreach(FileInfo file in Files)
    	{
    	
    		file.CopyTo(newFolder+"\\"+file.Name,true);
    	
    	}

    	foreach(DirectoryInfo dir in Directories)
    	{  		
    		  		
    		
    		BackupSubItems(dir,newFolder+"\\"+dir.Name+"\\");
    	   
    	}
  }
  	
  	
  	public void BackupItem(Item it,DirectoryInfo Folder,string newFolder)
    {
    	//Cartella di appoggio
    	
    	if (!Directory.Exists("C:\\temp_Backupper\\"+newFolder+"\\"))
    		Directory.CreateDirectory("C:\\temp_Backupper\\"+newFolder+"\\");
    	if  (it.AllFolder==true)
    	{
    	 
    	//TODO:FOR FOLDER?
    	DirectoryInfo Dir=new DirectoryInfo(it.FileName);
    	BackupSubItems(Dir,"C:\\temp_Backupper\\"+newFolder+"\\");
    	
    	}else
    	{  	
    		string[] name=it.FileName.Split('\\');
    		try
    		{
    		File.Copy(it.FileName,"C:\\temp_Backupper\\"+newFolder+"\\"+name[name.Length-1],true);
    		}
    		catch 
    		{
    		
    		}
    	}
    
    
    }
    public void BackupProject(int index)
    {
    	DirectoryInfo temp=Directory.CreateDirectory(Application.StartupPath+ this._project[index].Name);
    	
    	string newFolder=this._project[index].Text;
    	
    	Directory.CreateDirectory(temp.FullName+"\\"+newFolder+"\\");
    	
    	foreach(Item x in this._project[index].Items)
    	{
    		
    		
    		this.BackupItem(x,temp,newFolder);
    	
    	}
    	
    	string Folder=Application.StartupPath+"\\Backups\\"+newFolder+"\\";
    	
    	Directory.CreateDirectory(Folder);
    	
    	Zip.ZipManager.MakeZip("C:\\temp_Backupper\\"+newFolder+"\\","",Folder+DateTime.Now.Date.ToShortDateString().Replace('/','_')+"_"+DateTime.Now.Hour.ToString()+"_"+DateTime.Now.Minute.ToString()+".zip");
    	
    	Directory.Delete("C:\\temp_Backupper\\",true);
    
    }
    
    public void LoadAll()
    {
    
    OpenFileDialog op= new OpenFileDialog();
    	
    	 if (op.ShowDialog()==DialogResult.OK)
    
    	this.LoadAll(op.FileName);
    
    }
     public void LoadAll(string Filename)
    {
     	XmlDocument xdoc = new XmlDocument();
     	xdoc.Load(Filename);
     	XmlElement root=xdoc.DocumentElement;
     	
     	if (root.ChildNodes.Count>0 )
     	foreach(XmlElement x in root.ChildNodes)
     	{
     		project pr= new project();
     		
     		pr.Text=x.Attributes[0].Value;
		pr.ToolTipText=x.Attributes[0].Value;
     		
     			
     	foreach(XmlElement xx in x.ChildNodes)
     	{
     		Item it  =new Item();
     		it.FileName=xx.Attributes[0].Value;
     		it.AllFolder=Convert.ToBoolean( xx.Attributes[1].Value.ToString());
		
     		string[] name= it.FileName.Split('\\' );
		                              
			it.Text=name[name.Length-1];
			
			it.ToolTipText=xx.Attributes[0].Value;
		
		
		    
			it.lastbackup=xx.Attributes[2].Value ;
	
			if (it.AllFolder==false)
			
			it.ImageKey="item";
			else
			it.ImageKey="folder";
	
		
	
		pr.Items.Add(it);
		pr.Nodes.Add(it);
		
		
     	}
     		
     	pr.ImageKey="project";
     		
     		this._project.Add(pr);
     	
     		this.tr.Nodes.Add(pr);
     	}
    
     	tr.ExpandAll();
   	
		
     }
     
     void SaveAll(object sender,EventArgs e)
     {
     	SaveAll(this.Settings);
     }
    public void SaveAll()
    {
    	SaveFileDialog op= new SaveFileDialog();
    	
    	 if (op.ShowDialog()==DialogResult.OK)
    
    	this.SaveAll(op.FileName);
    
    
    }
    public void SaveAll(string Filename)
    {
    	XmlDocument xdoc = new XmlDocument();
    	XmlElement node=xdoc.CreateElement("root");
    	XmlAttribute at;
    	
    	foreach (project x in this._project)
    	{
    	
    		XmlElement pr= xdoc.CreateElement("project");
    		//attributes for project
    		
    		at= xdoc.CreateAttribute("name");
    		at.Value=x.Text;
    		pr.Attributes.Append(at);
    		
    		foreach (Item xx in x.Items)
    	   {
    		
    			XmlElement it= xdoc.CreateElement("item");
    		//attributes for Item
    			at= xdoc.CreateAttribute("path");
    		    at.Value=xx.FileName;
    		    it.Attributes.Append(at);
    		    
    			at= xdoc.CreateAttribute("AllSubItems");
    			at.Value=xx.AllFolder.ToString();
    		    it.Attributes.Append(at);
    		    
    		    at= xdoc.CreateAttribute("LastBackup");
    		    at.Value=xx.lastbackup;
    		    it.Attributes.Append(at);
    		    
    			pr.AppendChild(it);
    		
    		}
    	
    		
    		node.AppendChild(pr);
    	
    	
    	}
    	xdoc.AppendChild(node);
    	xdoc.Save(Filename);
    }
 	public void RemoveItemToProject(project x)
    {
 	if (MessageBox.Show("Eliminare l'elemento?","Attenzione", MessageBoxButtons.YesNo, MessageBoxIcon.Question, MessageBoxDefaultButton.Button2,MessageBoxOptions.RightAlign)== DialogResult.Yes)
			
			this.tr.Nodes.Remove(x);
 	
 	}
		
	}
	
}
