namespace Raml.Modes
{
	internal class MyColors
	{
		static public readonly string NL = Environment.NewLine; // shortcut
		static public readonly string NORMAL = Console.IsOutputRedirected ? "" : "\x1b[39m";
		static public readonly string RED = Console.IsOutputRedirected ? "" : "\x1b[91m";
		static public readonly string GREEN = Console.IsOutputRedirected ? "" : "\x1b[92m";
		static public readonly string YELLOW = Console.IsOutputRedirected ? "" : "\x1b[93m";
		static public readonly string BLUE = Console.IsOutputRedirected ? "" : "\x1b[94m";
		static public readonly string MAGENTA = Console.IsOutputRedirected ? "" : "\x1b[95m";
		static public readonly string CYAN = Console.IsOutputRedirected ? "" : "\x1b[96m";
		static public readonly string GREY = Console.IsOutputRedirected ? "" : "\x1b[97m";
		static public readonly string BOLD = Console.IsOutputRedirected ? "" : "\x1b[1m";
		static public readonly string NOBOLD = Console.IsOutputRedirected ? "" : "\x1b[22m";
		static public readonly string UNDERLINE = Console.IsOutputRedirected ? "" : "\x1b[4m";
		static public readonly string NOUNDERLINE = Console.IsOutputRedirected ? "" : "\x1b[24m";
		static public readonly string REVERSE = Console.IsOutputRedirected ? "" : "\x1b[7m";
		static public readonly string NOREVERSE = Console.IsOutputRedirected ? "" : "\x1b[27m";
	}
}
