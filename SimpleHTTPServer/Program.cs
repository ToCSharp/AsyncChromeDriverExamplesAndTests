using System;

namespace SimpleHTTPServer
{
    class Program
    {
        static int Main(string[] args)
        {
#if DEBUG
    Console.WriteLine("Mode=Debug");
#else
            Console.WriteLine("Mode=Release");
#endif
            Console.ReadLine();
            return 0;
            if (args.Length < 2)
            {
                Console.WriteLine("Please enter a port and projectRootPath.");
                return 1;
            }

            if (int.TryParse(args[0], out int port))
            {
                var projectRootPath = args[1];
                var simpleHTTPServer = new HTTPServer(projectRootPath, port);
                Console.ReadLine();
                simpleHTTPServer.Stop();
            }
            return 0;
        }
    }
}
