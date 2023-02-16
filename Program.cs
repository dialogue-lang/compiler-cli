using Dialang.Compilation;

namespace Dialang.Compilation.Tool
{
    public static class Program
    {
        private static string input;
        private static string output;
        private static ProjectCompiler compiler;

        private static void Main(string[] args)
        {
            if (args.Length < 2 || !ProjectCompiler.ValidInput(args[0]))
                ManualSetup();
            else
            {
                input = args[0];
                output = args[1];
            }

            compiler = new ProjectCompiler(input, Console.WriteLine);

            Console.WriteLine($"Compiling to '{Path.TrimEndingDirectorySeparator(output)}\\{compiler.Project.Name}'...");
            CompileResult r = compiler.Compile(output, Console.WriteLine);

            Console.WriteLine();
            Console.WriteLine($"Total time was: {compiler.Project.Elapsed:0.00} seconds!");
            Console.WriteLine("Press any key to exit...");
            Console.ReadKey(true);
        }

        private static void ManualSetup()
        {
            Console.WriteLine("Please provide a valid project file:");

            // Cursed, but it's the only way I can get this to look neat.
        GetInputPath:

            input = Console.ReadLine()!;
            if (!ProjectCompiler.ValidInput(input))
            {
                Console.Write("\n\nInvalid file. Please try again.");
                Console.SetCursorPosition(0, 1);
                goto GetInputPath;
            }

            Console.Clear();
            Console.SetCursorPosition(0, 0);
            Console.WriteLine("Please provide a valid output directory:");
            output = Console.ReadLine()!;

            Console.Clear();
        }
    }
}