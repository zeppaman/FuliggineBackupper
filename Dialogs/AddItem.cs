/*
 * Created by SharpDevelop.
 * User: Zeppa'man
 * Date: 19/05/2006
 * Time: 18.05


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
using System.Drawing;
using System.Windows.Forms;
using System.IO;

namespace Backupper.Dialogs
{
	/// <summary>
	/// Description of AddItem.
	/// </summary>
	public partial class AddItem
	{
		
		
		public bool IncludeSubItems ;
		
		public string[] FileNames ;
		
		public string FolderName ;
		
		public AddItem()
		{
			this.DialogResult=DialogResult.Cancel;
			
			InitializeComponent();
			string IconPath= Application.StartupPath+"\\Icons\\";
			
			if (File.Exists(IconPath+"item.ico"))
			 {
			 	this.button1.Image=Image.FromFile(IconPath+"item.ico");
			 }
			 
			  if (File.Exists(IconPath+"folder.ico"))
			 {
			 	this.button3.Image=Image.FromFile(IconPath+"folder.ico");
			 
			  }
			
		}
		
		void Button1Click(object sender, System.EventArgs e)
		{ 	
			
			OpenFileDialog op= new OpenFileDialog ();
			op.CheckFileExists=true;
			op.CheckPathExists=true;
			op.Multiselect=true;
			this.IncludeSubItems=false;
			
			if (op.ShowDialog()==DialogResult.OK)
			{
				
				this.FileNames= op.FileNames;
				
			this.DialogResult= DialogResult.OK;
			
				Close();
			}
		
			
			
			
		}
		
		void Button2Click(object sender, System.EventArgs e)
		{
		this.DialogResult=DialogResult.OK;
		Close();
		}
		
		void Button3Click(object sender, System.EventArgs e)
		{
			FolderBrowserDialog op= new FolderBrowserDialog ();
			op.ShowNewFolderButton=true;
			
			this.IncludeSubItems=true;
			if (op.ShowDialog()==DialogResult.OK)
			{
			
			this.DialogResult= DialogResult.OK;
			
		
			this.FolderName=op.SelectedPath;
		
		 Close();
			
			}
			
		}
		
		void Button4Click(object sender, System.EventArgs e)
		{
			Close();
		}
	}
}
