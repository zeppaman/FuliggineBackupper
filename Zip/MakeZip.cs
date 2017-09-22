// project created on 10.11.2001 at 13:09
using System;
using System.IO;

using ICSharpCode.SharpZipLib.Checksums;
using ICSharpCode.SharpZipLib.Zip;
using ICSharpCode.SharpZipLib.GZip;

namespace Backupper.Zip
{
	public class ZipManager
{
		public static void ExtractZip(string destFolder,string SourceFolder,string ZipName)
		{
			ZipInputStream s = new ZipInputStream(File.OpenRead(ZipName));
			
			UnzipFolder( s, destFolder, SourceFolder);
		}
		
		public static void UnzipFolder(ZipInputStream s,string destFolder,string SourceFolder)
	{
		
		
		ZipEntry theEntry;
		
		while ((theEntry = s.GetNextEntry()) != null) {
			
			Console.WriteLine(theEntry.Name);
		
			string directoryName = Path.GetDirectoryName(theEntry.Name);
			string fileName      = Path.GetFileName(theEntry.Name);
			
			// create directory
			Directory.CreateDirectory(directoryName);
			
			if (fileName != String.Empty) {
				FileStream streamWriter = File.Create(theEntry.Name);
				
				int size = 2048;
				byte[] data = new byte[2048];
				while (true) {
					size = s.Read(data, 0, data.Length);
					if (size > 0) {
						streamWriter.Write(data, 0, size);
					} else {
						break;
					}
				}
				
				streamWriter.Close();
			}
		}
		s.Close();
	}
	public static void MakeZip(string AbsPath,string path,string ZipName)
	{
		ZipOutputStream s = new ZipOutputStream(File.Create(ZipName));
	
		//Add the files in this folder ad subfolder
		
		ZipFolder(s,  AbsPath,path,true);
		s.Finish();
		s.Close();	
	
	}
	//Zip a Folder
	public static void ZipFolder(ZipOutputStream s, string AbsPath,string path,bool zipSub)
	{
		
		//
		Crc32 crc = new Crc32();
			
		string[] filenames = Directory.GetFiles(AbsPath);
		s.SetLevel(9); // 0 - store only to 9 - means best compression
		
		foreach (string file in filenames) 
		{
			string[] filename=file.Split('\\');
			
			FileStream fs = File.OpenRead(file);
			
			byte[] buffer = new byte[fs.Length];
			fs.Read(buffer, 0, buffer.Length);
			
			ZipEntry entry = new ZipEntry(path+filename[filename.Length-1]);//file);
			
			entry.DateTime = DateTime.Now;
			
			// set Size and the crc, because the information
			// about the size and crc should be stored in the header
			// if it is not set it is automatically written in the footer.
			// (in this case size == crc == -1 in the header)
			// Some ZIP programs have problems with zip files that don't store
			// the size and crc in the header.
			entry.Size = fs.Length;
			fs.Close();
			
			crc.Reset();
			crc.Update(buffer);
			
			entry.Crc  = crc.Value;
		
			s.PutNextEntry(entry);
			
			s.Write(buffer, 0, buffer.Length);
			
		}
		foreach(string Folder in Directory.GetDirectories(AbsPath))
		{
			string[] filename=Folder.Split('\\');
		//add the directory and subdirectory in the zip
		ZipFolder(s,Folder,path+filename[filename.Length-1]+"\\",true);		
		
		}
		
	}
	
}
}
