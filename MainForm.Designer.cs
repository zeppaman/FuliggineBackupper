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
namespace Backupper
{
	partial class MainForm : System.Windows.Forms.Form
	{
		/// <summary>
		/// Designer variable used to keep track of non-visual components.
		/// </summary>
		private System.ComponentModel.IContainer components = null;
		
		/// <summary>
		/// Disposes resources used by the form.
		/// </summary>
		/// <param name="disposing">true if managed resources should be disposed; otherwise, false.</param>
		protected override void Dispose(bool disposing)
		{
			if (disposing) {
				if (components != null) {
					components.Dispose();
				}
			}
			base.Dispose(disposing);
		}
		
		/// <summary>
		/// This method is required for Windows Forms designer support.
		/// Do not change the method contents inside the source code editor. The Forms designer might
		/// not be able to load this method if it was changed manually.
		/// </summary>
		private void InitializeComponent()
		{
			this.components = new System.ComponentModel.Container();
			this.projectManager1 = new Backupper.ProjectManager();
			this.contextMenuStrip1 = new System.Windows.Forms.ContextMenuStrip(this.components);
			this.yjToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
			this.statusStrip1 = new System.Windows.Forms.StatusStrip();
			this.contextMenuStrip1.SuspendLayout();
			this.SuspendLayout();
			// 
			// projectManager1
			// 
			this.projectManager1.Dock = System.Windows.Forms.DockStyle.Top;
			this.projectManager1.Location = new System.Drawing.Point(0, 0);
			this.projectManager1.Name = "projectManager1";
			this.projectManager1.Size = new System.Drawing.Size(400, 451);
			this.projectManager1.TabIndex = 0;
			this.projectManager1.Click += new System.EventHandler(this.ProjectManager1Click);
			// 
			// contextMenuStrip1
			// 
			this.contextMenuStrip1.Items.AddRange(new System.Windows.Forms.ToolStripItem[] {
									this.yjToolStripMenuItem});
			this.contextMenuStrip1.Name = "contextMenuStrip1";
			this.contextMenuStrip1.Size = new System.Drawing.Size(95, 26);
			// 
			// yjToolStripMenuItem
			// 
			this.yjToolStripMenuItem.Name = "yjToolStripMenuItem";
			this.yjToolStripMenuItem.Size = new System.Drawing.Size(94, 22);
			this.yjToolStripMenuItem.Text = "yj";
			// 
			// statusStrip1
			// 
			this.statusStrip1.BackColor = System.Drawing.SystemColors.InactiveCaptionText;
			this.statusStrip1.Location = new System.Drawing.Point(0, 493);
			this.statusStrip1.Name = "statusStrip1";
			this.statusStrip1.Size = new System.Drawing.Size(400, 22);
			this.statusStrip1.TabIndex = 1;
			this.statusStrip1.Text = "statusStrip1";
			// 
			// MainForm
			// 
			this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
			this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
			this.ClientSize = new System.Drawing.Size(400, 515);
			this.Controls.Add(this.statusStrip1);
			this.Controls.Add(this.projectManager1);
			this.Name = "MainForm";
			this.ShowIcon = false;
			this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
			this.Text = "Backupper";
			this.Resize += new System.EventHandler(this.MainFormResize);
			this.Load += new System.EventHandler(this.MainFormLoad);
			this.contextMenuStrip1.ResumeLayout(false);
			this.ResumeLayout(false);
			this.PerformLayout();
		}
		private System.Windows.Forms.StatusStrip statusStrip1;
		private System.Windows.Forms.ToolStripMenuItem yjToolStripMenuItem;
		private System.Windows.Forms.ContextMenuStrip contextMenuStrip1;
		private Backupper.ProjectManager projectManager1;
		
		void Button1Click(object sender, System.EventArgs e)
		{
			this.projectManager1.SaveAll();
		}
	}
}
