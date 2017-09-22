/*
 * Created by SharpDevelop.
 * User: Zeppa'man
 * Date: 19/05/2006
 * Time: 17.07


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
using System.Collections.Generic;
using System.Drawing;
using System.IO;
using System.Windows.Forms;

namespace Backupper
{
	/// <summary>
	/// Description of MainForm.
	/// </summary>
	public partial class MainForm
	{
		[STAThread]
		public static void Main(string[] args)
		{
			Application.EnableVisualStyles();
			Application.SetCompatibleTextRenderingDefault(false);
			Application.Run(new MainForm());
		}
		
		public MainForm()
		{
			
			
			InitializeComponent();
			
			this.projectManager1.Height= this.ClientRectangle.Height-this.statusStrip1.Height;
		
				
			
		}
		
		void ProjectManager1MouseDown(object sender, System.Windows.Forms.MouseEventArgs e)
		{
			
		}
		
		void ProjectManager1Click(object sender, System.EventArgs e)
		{
			
		}
		
		void Button2Click(object sender, System.EventArgs e)
		{
			this.projectManager1.LoadAll();
		}
		
		void MainFormLoad(object sender, System.EventArgs e)
		{
			if(System.IO.File.Exists(Application.StartupPath+"\\projects.xml"))
				this.projectManager1.LoadAll(Application.StartupPath+"\\projects.xml");
			
		}
		
		void ToolStripButton1Click(object sender, System.EventArgs e)
		{
			
		}
		
		void TreeView1AfterSelect(object sender, System.Windows.Forms.TreeViewEventArgs e)
		{
			
		}
		
		void MainFormResize(object sender, System.EventArgs e)
		{
			this.projectManager1.Height= this.ClientRectangle.Height-this.statusStrip1.Height;
		}
	}
}
