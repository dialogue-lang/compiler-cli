using Dialang.Compilation;

namespace Dialang.Compilation.Tool
{
    public static class Program
    {
        private static string input;
        private static string output;

        private static void Main(string[] args)
        {
            if (args.Length < 2 || !Compiler.ValidInput(args[0]))
                ManualSetup();
            else
            {
                input = args[0];
                output = args[1];
            }
        }

        private static void ManualSetup()
        {
            Console.WriteLine("Please provide a valid project file:");

            // Cursed, but it's the only way I can get this to look neat.
        GetInputPath:

            input = Console.ReadLine()!;
            if (!Compiler.ValidInput(input))
            {
                Console.Write("\n\nInvalid file. Please try again.");
                Console.SetCursorPosition(0, 1);
                goto GetInputPath;
            }

            output = Console.ReadLine()!;

            Console.Clear();
        }
    }
}