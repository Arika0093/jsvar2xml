using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Text.RegularExpressions;
using System.Threading.Tasks;
using System.IO;

namespace jsvar2xml
{
	public class Convert_Js2Xml
	{
		// --- main
		// from Javascript_Variable_List to XML
		public bool Convert()
		{
			DebugMessage += "-------------------------------------";
			DebugMessage += "Jsvar2Xml Convert Start...";
			// Exist check
			if(!File.Exists(ImportPath)) {
				DebugMessage += "ImportPath Exist... Error";
				return false;
			}
			DebugMessage += "ImportPath Exist... OK";
			// Read File
			DebugMessage += "File Open...";
			StreamReader FsRead = new StreamReader(ImportPath);
			// Full Read
			DebugMessage += "Read Full Text...";
			var JsFullText = FsRead.ReadToEnd();
			// Analyze File
			DebugMessage += "Analyze Start...\r\n-------------------------------------";
			return Analyze(JsFullText, 0, 0,
					PurseList.Default_Strings,
					PurseList.Default_IgnoreChars,
					PurseList.Default_EndStrs) != null;;
		}

		// import file analysis
		private ReadManage Analyze(String Text, int Offset, uint Indent, String[] Cols,
					char[] Ignores, String[] EndStrs, bool IsComment = false)
		{
			// save
			int Offset_pre = Offset;
			// loop
			while(Offset < Text.Length) {
				// check first
				var Result = ReadUntilColStr(Text, Offset, Cols, Ignores);
				// null check
				if(Result == null || Result.Read == null) {
					return null;
				}
				// Debug Message Add
				DebugMessage += Result.ToString() + "(Indent=" + Indent + ")";
				// Offset plus
				Offset = Result.ReadEdOffset;
				// Collision Check
				foreach(var EndStr in EndStrs) {
					// Collision
					if(Result.Col == EndStr) {
						// Write
						WriteXml(Result.Read.TrimEnd(), (IsComment ? Indent : 0), IsComment, IsComment);
						// End
						return Result;
					}
				}
				ReadManage Rst = null;
				// Switch Result
				switch(Result.Col) {
					// Comment Start
					case "/*":
						WriteXml("<!--", Indent, true);
						Rst = Analyze(Text, Offset, Indent + 1,
								PurseList.InComment_Strings,
								PurseList.InComment_IgnoreChars,
								PurseList.InComment_EndStrs,
								true);
						WriteXml("-->", Indent, true);
						Offset = Rst.ReadEdOffset;
						break;
					// Line Comment Start
					case "//":
						WriteXml("<!-- ", Indent);
						Rst = Analyze(Text, Offset, Indent + 1,
								PurseList.InLineComment_Strings,
								PurseList.InLineComment_IgnoreChars,
								PurseList.InLineComment_EndStrs);
						WriteXml(" -->", 0, true);
						Offset = Rst.ReadEdOffset;
						break;
					// Elements Key and Value Separator
					case ":":
						WriteXml("<" + Result.Read.Trim() + ">", Indent);
						Rst = Analyze(Text, Offset, Indent,
								PurseList.ElementSeparator_Strings,
								PurseList.ElementSeparator_IgnoreChars,
								PurseList.ElementSeparator_EndStrs);
						WriteXml("</" + Result.Read.Trim() + ">", 0, true);
						// if elements block end
						if(Rst.Col == "}") {
							Rst.ReadEdOffset += 1;
							return Rst;
						}
						Offset = Rst.ReadEdOffset;
						break;
					// Main
					case " = {":
						WriteXml("<" + Result.Read.Trim() + ">", Indent, true);
						Rst = Analyze(Text, Offset, Indent + 1,
								PurseList.ElementBlock_Strings,
								PurseList.ElementBlock_IgnoreChars,
								PurseList.ElementBlock_EndStrs);
						WriteXml("</" + Result.Read.Trim() + ">", Indent, true);
						// Stream Close
						Sw.Close();
						Sw = null;
						return Result;
					// ElementsBlock Start
					case ": {":
					case ":{":
						WriteXml("<" + Result.Read.Trim() + ">", Indent, true);
						Rst = Analyze(Text, Offset, Indent + 1,
								PurseList.ElementBlock_Strings,
								PurseList.ElementBlock_IgnoreChars,
								PurseList.ElementBlock_EndStrs);
						WriteXml("</" + Result.Read.Trim() + ">", Indent, true);
						Offset = Rst.ReadEdOffset;
						break;
					// Js Function
					case "function (":
						Rst = ReadUntilColStr(Text, Offset,
								PurseList.Javascript_Strings,
								PurseList.Javascript_IgnoreChars,
								PurseList.Javascript_NestStr,
								PurseList.Javascript_UnnestStr);
						// Debug Message Add
						DebugMessage += Rst.ToString() + "(Indent=" + Indent + ")";
						WriteXml("(function defined)", 0);
						Offset = Rst.ReadEdOffset;
						break;
					// Normal String
					case "\"":
						Rst = Analyze(Text, Offset, Indent,
								PurseList.NormalStr_Strings,
								PurseList.NormalStr_IgnoreChars,
								PurseList.NormalStr_EndStrs);
						Offset = Rst.ReadEdOffset;
						break;
					// Inner String
					case "[":
						WriteXml("[", 0);
						Rst = Analyze(Text, Offset, Indent,
								PurseList.Inner_Strings,
								PurseList.Inner_IgnoreChars,
								PurseList.Inner_EndStrs);
						Offset = Rst.ReadEdOffset;
						WriteXml("]", 0);
						break;
					// No Hits
					default:
						break;
				}
			}
			return null;
		}

		// write xml file
		private bool WriteXml(String ImportStr, uint Indent, bool NextLine = false, bool IsComment = false)
		{
			// file handle check
			if(Sw == null) {
				// open new file
				Sw = new StreamWriter(ExportPath, false, Encoding.UTF8);
				// xml template write
				Sw.Write("<?xml version=\"1.0\" encoding=\"utf-8\"?>\n");
			}
			// separate with \n
			var Strs = ImportStr.Split(new char[] { '\n' });
			foreach(var Str in Strs) {
				// Reset
				String WriteStr = "";
				String EditedStr = "";
				// trim and remove ""
				EditedStr = Str.Trim(new char[]{' '}).Replace("\"", "");
				// if empty
				if(!IsComment && EditedStr == "< >") {
					continue;
				}
				// insert tab
				for(int i = 0; i < Indent; i++) {
					WriteStr += "\t";
				}
				// write
				WriteStr += EditedStr;
				Sw.Write(WriteStr + (NextLine ? "\n" : ""));
				DebugMessage += "Write: \"" + EditedStr + "\"(Enter: " + NextLine.ToString() + ")";
			}
			return true;
		}

		// --- temp
		// read text until collision set strings
		private ReadManage ReadUntilColStr(String Str, int Offset, String[] Cols, char[] Ignores)
		{
			return ReadUntilColStr(Str, Offset, Cols, Ignores, null, null);
		}

		// read text until collision set strings(nest check)
		private ReadManage ReadUntilColStr(String Str, int Offset,
					String[] Cols, char[] Ignores,
					String Nest, String Unnest)
		{
			// tmp
			ReadManage Mng = new ReadManage();
			// counter
			int NestCount = 0;
			// Remove Count
			int RemoveCharCount = StringCountChars(Str.Substring(0, Offset), Ignores);
			// ignore string remove
			Str = RemoveChars(Str.Substring(0, Offset), Ignores) + Str.Substring(Offset);
			// Tmp Offset
			int TmpOffset = Offset - RemoveCharCount;
			// for loop
			for(int i = 0; i < (Str.Length - TmpOffset); i++) {
				// check
				for(int Ct = 0; Ct < Cols.Length; Ct++) {
					string Col = Cols[Ct];
					// nest check
					if(Nest != null && Str[TmpOffset + i] == Nest[0] && StringCheck(Str, TmpOffset + i, Nest)) {
						// nest +1
						NestCount += 1;
					}
					else if(Unnest != null && Str[TmpOffset + i] == Unnest[0] && StringCheck(Str, TmpOffset + i, Unnest)) {
						// nest -1
						NestCount -= 1;
					}
					// collision check
					if(Str[TmpOffset + i] == Col[0] && StringCheck(Str, TmpOffset + i, Col)) {
						if(NestCount <= 0) {
							// value set
							Mng.Read = RemoveChars(Str.Substring(TmpOffset, i), Ignores);
							Mng.Col = Col;
							Mng.ReadStOffset = Offset;
							Mng.ReadTtOffset = Offset + i;
							Mng.ReadEdOffset = Offset + i + Col.Length;
							Mng.ReadSuccess = true;
							// search
							int St = SearchTextInStrings(Mng.Read, Cols, Ct + 1);
							if(St != -1 && !Col.Contains(Cols[St])) {
								Ct = St - 1;
							}
							else {
								return Mng;
							}
						}
					}
				}
			}
			// return
			return null;
		}

		// str check
		private bool StringCheck(String Base, int Offset, String Compare)
		{
			return Base.Substring(Offset, Compare.Length).StartsWith(Compare);
		}

		// string remove chars
		private String RemoveChars(String Base, char[] Ignores)
		{
			var New = Base;
			foreach(var ignore in Ignores){
				New = New.Replace(ignore.ToString(), "");
			}
			return New;
		}

		// string count of chars
		private int StringCountChars(String Base, char[] Chars)
		{
			int Count = 0;
			foreach(var ignore in Chars) {
				Count += Base.Length - Base.Replace(ignore.ToString(), "").Length;
			}
			return Count;
		}

		// search string in text
		private int SearchTextInStrings(String Base, String[] Searchs, int Start)
		{
			// for loop
			for(int Count = Start; Count < Searchs.Length; Count++) {
				if(Base.IndexOf(Searchs[Count]) != -1) {
					return Count;
				}
			}
			return -1;
		}

		// --- variable
		// import file path
		private String _ImportPath;
		public String ImportPath
		{
			get
			{
				return _ImportPath;
			}
			set
			{
				_ImportPath = value;
				if(ExportPath == "") {
					ExportPath = Path.GetDirectoryName(value) + "\\" +
						Path.GetFileNameWithoutExtension(value) + ".xml";
				}
			}
		}

		// export file path
		public String ExportPath = "";

		// debug message
		private String _DebugMessage;
		public String DebugMessage
		{
			get
			{
				return _DebugMessage;
			}
			set
			{
				_DebugMessage = (value != "" ? value + "\r\n" : "");
			}
		}

		// export file stream
		private StreamWriter Sw = null;
	}

	// read managed class
	public class ReadManage
	{
		public String Read;			// Read Text
		public String Col;			// Collision
		public int ReadStOffset;	// Offset of Start
		public int ReadEdOffset;	// Offset of End
		public int ReadTtOffset;	// Offset of End without after collison
		public bool ReadSuccess;	// Result
		public override String ToString()
		{
			return "Read: \"" + Read.Trim() + Col + "\", " +
					"Col: \"" + Col + "\", " +
					"(Offset: " + ReadStOffset.ToString() +
					"-" + ReadTtOffset.ToString() +
					"-" + ReadEdOffset.ToString() + ")";
		}
	}
}
