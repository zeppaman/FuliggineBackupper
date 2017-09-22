/*
 * Created by SharpDevelop.
 * User: Zeppa'man
 * Date: 19/05/2006
 * Time: 17.48


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
using System.IO;

using System.Drawing;
using System.Windows.Forms;

namespace Backupper.Dialogs
{
	/// <summary>
	/// Description of AddProject.
	/// </summary>
	public partial class AddProject
	{
		
	string projectname="NewProject";
	
	public string Projectname {
		get {
			return projectedit.Text;
		}
		set {
			projectedit.Text = value;
		}
	}
		
		public AddProject()
		{ 
			string IconPath= Application.StartupPath+"\\Icons\\";
			
			//
			// The InitializeComponent() call is required for Windows Forms designer support.
			//
			InitializeComponent();
			
			this.DialogResult= DialogResult.Cancel;
			
		 if (File.Exists(IconPath+"project.ico"))
			 {
			 	
			 	this.pictureBox1.Image= Image.FromFile(IconPath+"project.ico");
			 }
			 
		}
		
		void Button1Click(object sender, System.EventArgs e)
		{
			this.DialogResult= DialogResult.OK;
			Close();
		}
		
		void Button2Click(object sender, System.EventArgs e)
		{
			this.DialogResult= DialogResult.Cancel;
			Close();
		}
		
		void Label1Click(object sender, System.EventArgs e)
		{
			
		}
	}
}
