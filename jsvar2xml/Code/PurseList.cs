using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace jsvar2xml
{
	public static class PurseList
	{
		// Default(First)
		public static String[] Default_Strings = {
			"/*", "//", " = {", "function ("
		};
		public static char[] Default_IgnoreChars = {
			'\r', '\n', '\t'
		};
		public static String[] Default_EndStrs = {
			""
		};

		// In Comment "/*"
		public static String[] InComment_Strings = {
			"*/"
		};
		public static char[] InComment_IgnoreChars = {
			'\t'
		};
		public static String[] InComment_EndStrs = {
			"*/"
		};

		// In OneLine Comment "//"
		public static String[] InLineComment_Strings = {
			"\r\n", "\n"
		};
		public static char[] InLineComment_IgnoreChars = {
			'\t'
		};
		public static String[] InLineComment_EndStrs = {
			"\r\n", "\n"
		};

		// ElementBlock Start "= {", ": {"
		public static String[] ElementBlock_Strings = {
			"/*", "//", ": {", ":{", ":", "},", "};", "}", ","
		};
		public static char[] ElementBlock_IgnoreChars = Default_IgnoreChars;
		public static String[] ElementBlock_EndStrs = {
			"},", "};", "}", ","
		};

		// Element Separator ":"
		public static String[] ElementSeparator_Strings = {
			"/*", "//", "\"", "[", ",", "}", "function ("
		};
		public static char[] ElementSeparator_IgnoreChars = Default_IgnoreChars;
		public static String[] ElementSeparator_EndStrs = {
			",", "}"
		};

		// Javascript Function [function (]
		public static String[] Javascript_Strings = {
			"}"
		};
		public static char[] Javascript_IgnoreChars = Default_IgnoreChars;
		public static String[] Javascript_EndStrs = {
			"}"
		};
		public static String Javascript_NestStr = "{";
		public static String Javascript_UnnestStr = "}";

		// String ["]
		public static String[] NormalStr_Strings = {
			"\""
		};
		public static char[] NormalStr_IgnoreChars = Default_IgnoreChars;
		public static String[] NormalStr_EndStrs = {
			"\""
		};

		// String "["
		public static String[] Inner_Strings = {
			"]"
		};
		public static char[] Inner_IgnoreChars = Default_IgnoreChars;
		public static String[] Inner_EndStrs = {
			"]"
		};
	}
}
