using System;

namespace HSE_SE_Algebra_CalcTools
{
    public static class ToolsInputOutput
    {
        private static ToolsIOConfig _config;

        private static void ReadConfig()
        {
            // Read config
        }
        
        public static void StartProgram()
        {
            var input = "start";
            while (input != "exit")
            {
                input = Console.ReadLine();
            }
            
        }
    }
}