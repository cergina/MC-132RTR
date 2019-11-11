using System;

/*
* Trieda prevzatá z minuloročného riešenia
* je plnou autorskou prácou Maroša Čergeťa
*/
namespace MC_132RTR.Model.Support
{
    public class Logging
    {
        private static Logging Instance = new Logging();

        private Logging()
        {
            this.DebugMode = false;
        }

        // Constat to be manually set to true/false
        public bool DebugMode { get; private set; }

        /***
         * Writes things out into Console if we are in DebugMode
         */
        public static void Out(String Output)
        {
            if (Instance.DebugMode)
                Console.WriteLine(Output);
        }

        public static void OutALWAYS(String Output)
            => Console.WriteLine(Output);

        public static void ChangeMode()
            => Instance.DebugMode = !Instance.DebugMode;

        public static bool DisplayMode() 
            => Instance.DebugMode;
        
    }
}
