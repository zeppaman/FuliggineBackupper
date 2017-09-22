/*
 * Created by SharpDevelop.
 * User: Zeppa'man
 * Date: 19/05/2006
 * Time: 17.08


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

	namespace Backupper
{
	/// <summary>
	/// Description of ItemRw.
	/// </summary>
	/// 
	public class Item:TreeNode
	{
		public string FileName="";
		
		public string lastbackup="";	
		
		public bool AllFolder=false;
		
		public Collection<Item> SubItems =new Collection<Item>();
		
		
	}
	
	public class project:TreeNode
	{
		Item _item = new Item();
		
		public Collection<Item> Items {
			get {
				return _item.SubItems;
			}
			set {
				_item.SubItems = value;
			}
		}
	
	
		
	
	}
	

	
}
