using System;
using System.Collections.Generic;

namespace UraniumOS
{
    public class Process
    {
        public string Name { get; set; }
        public int PID { get; set; }
        public string Status { get; set; }
    }

    public class CommandInterpreter
    {
        private Dictionary<string, Action<string[]>> commands;
        private bool isRunning = true;
        private List<Process> processes;
        private string currentDirectory = "/";
        private Dictionary<string, string> variables;

        public CommandInterpreter()
        {
            processes = new List<Process>();
            variables = new Dictionary<string, string>();

            commands = new Dictionary<string, Action<string[]>>()
            {
                { "help", Help },
                { "clear", Clear },
                { "echo", Echo },
                { "time", ShowTime },
                { "info", SystemInfo },
                { "shutdown", Shutdown },
                { "dir", ListDirectory },
                { "calc", Calculator },
                { "exit", Exit },
                { "ps", ProcessList },
                { "cd", ChangeDirectory },
                { "pwd", PrintWorkingDirectory },
                { "set", SetVariable },
                { "get", GetVariable },
                { "vars", ListVariables },
                { "version", ShowVersion },
                { "whoami", WhoAmI },
                { "memory", ShowMemory }
            };

            processes.Add(new Process { Name = "kernel", PID = 1, Status = "Running" });
            processes.Add(new Process { Name = "shell", PID = 2, Status = "Running" });
        }

        public void Start()
        {
            Console.Clear();
            Console.WriteLine("  _   _                 _                  ___  ____  \r\n | | | |_ __ __ _ _ __ (_)_   _ _ __ ___  / _ \\/ ___| \r\n | | | | '__/ _` | '_ \\| | | | | '_ ` _ \\| | | \\___ \\ \r\n | |_| | | | (_| | | | | | |_| | | | | | | |_| |___) |\r\n  \\___/|_|  \\__,_|_| |_|_|\\__,_|_| |_| |_|\\___/|____/ \r\n                                                      ");
            Console.WriteLine("Type 'help' for available commands");
            Console.WriteLine("message for ppl who are scared of cls:i wanted the os to have a gui but cosmos didnt let me");
            Console.WriteLine("www.uraniumos.gt.tc");

            while (isRunning)
            {
                Console.Write("U:" + currentDirectory + "> ");
                string input = Console.ReadLine();

                if (string.IsNullOrWhiteSpace(input))
                    continue;

                ProcessCommand(input);
            }
        }

        private void ProcessCommand(string input)
        {
            string[] parts = input.Split(' ');
            string command = parts[0].ToLower();
            string[] args = new string[parts.Length - 1];

            if (parts.Length > 1)
            {
                for (int i = 1; i < parts.Length; i++)
                {
                    args[i - 1] = parts[i];
                }
            }

            if (commands.ContainsKey(command))
            {
                commands[command](args);
            }
            else
            {
                Console.WriteLine("Command '" + command + "' not found. Type 'help' for list.\n");
            }
        }

        private void Help(string[] args)
        {
            Console.WriteLine("\nAvailable Commands:");
            Console.WriteLine("===================");
            Console.WriteLine("help      - Show this help");
            Console.WriteLine("clear     - Clear screen");
            Console.WriteLine("echo      - Print text");
            Console.WriteLine("time      - Show time");
            Console.WriteLine("info      - System info");
            Console.WriteLine("version   - OS version");
            Console.WriteLine("whoami    - Current user");
            Console.WriteLine("memory    - Memory info");
            Console.WriteLine("dir       - List directory");
            Console.WriteLine("cd        - Change directory");
            Console.WriteLine("pwd       - Working directory");
            Console.WriteLine("ps        - List processes");
            Console.WriteLine("set       - Set variable");
            Console.WriteLine("get       - Get variable");
            Console.WriteLine("vars      - List variables");
            Console.WriteLine("calc      - Calculator (calc 10 + 5)");
            Console.WriteLine("shutdown  - Power off");
            Console.WriteLine("exit      - Exit OS\n");
        }

        private void Clear(string[] args)
        {
            Console.Clear();
        }

        private void Echo(string[] args)
        {
            for (int i = 0; i < args.Length; i++)
            {
                Console.Write(args[i]);
                if (i < args.Length - 1) Console.Write(" ");
            }
            Console.WriteLine("\n");
        }

        private void ShowTime(string[] args)
        {
            Console.WriteLine(DateTime.Now.ToString("HH:mm:ss") + "\n");
        }

        private void SystemInfo(string[] args)
        {
            Console.WriteLine("\nSystem Information:");
            Console.WriteLine("===================");
            Console.WriteLine("OS Name:     UraniumOS v1.0");
            Console.WriteLine("Kernel:      Cosmos C#");
            Console.WriteLine("Architecture: x86/x64");
            Console.WriteLine("Memory:      64 MB\n");
        }

        private void ShowVersion(string[] args)
        {
            Console.WriteLine("\nUraniumOS Version 1.0");
            Console.WriteLine("Built with Cosmos Framework\n");
        }

        private void ListDirectory(string[] args)
        {
            Console.WriteLine("\nDirectory contents:");
            Console.WriteLine("[DIR]  System");
            Console.WriteLine("[DIR]  Programs");
            Console.WriteLine("[FILE] config.ini");
            Console.WriteLine("[FILE] boot.log\n");
        }

        private void Calculator(string[] args)
        {
            if (args.Length < 3)
            {
                Console.WriteLine("Usage: calc <num1> <op> <num2>");
                Console.WriteLine("Example: calc 10 + 5\n");
                return;
            }

            try
            {
                double num1 = double.Parse(args[0]);
                string op = args[1];
                double num2 = double.Parse(args[2]);
                double result = 0;
                bool valid = true;

                if (op == "+")
                    result = num1 + num2;
                else if (op == "-")
                    result = num1 - num2;
                else if (op == "*")
                    result = num1 * num2;
                else if (op == "/")
                {
                    if (num2 == 0)
                    {
                        Console.WriteLine("Error: Division by zero\n");
                        return;
                    }
                    result = num1 / num2;
                }
                else
                {
                    Console.WriteLine("Error: Unknown operator\n");
                    valid = false;
                }

                if (valid)
                    Console.WriteLine("Result: " + num1 + " " + op + " " + num2 + " = " + result + "\n");
            }
            catch
            {
                Console.WriteLine("Error: Invalid input\n");
            }
        }

        private void ProcessList(string[] args)
        {
            Console.WriteLine("\nRunning Processes:");
            Console.WriteLine("==================");
            for (int i = 0; i < processes.Count; i++)
            {
                Console.WriteLine("PID: " + processes[i].PID + " | Name: " + processes[i].Name + " | Status: " + processes[i].Status);
            }
            Console.WriteLine();
        }

        private void ChangeDirectory(string[] args)
        {
            if (args.Length == 0)
                currentDirectory = "/";
            else
                currentDirectory = args[0];
            Console.WriteLine();
        }

        private void PrintWorkingDirectory(string[] args)
        {
            Console.WriteLine(currentDirectory + "\n");
        }

        private void SetVariable(string[] args)
        {
            if (args.Length < 2)
            {
                Console.WriteLine("Usage: set <variable_name> <value>\n");
                return;
            }

            string value = "";
            for (int i = 1; i < args.Length; i++)
            {
                value += args[i];
                if (i < args.Length - 1) value += " ";
            }

            variables[args[0]] = value;
            Console.WriteLine(args[0] + " = " + variables[args[0]] + "\n");
        }

        private void GetVariable(string[] args)
        {
            if (args.Length == 0)
            {
                Console.WriteLine("Usage: get <variable_name>\n");
                return;
            }

            if (variables.ContainsKey(args[0]))
                Console.WriteLine(args[0] + " = " + variables[args[0]] + "\n");
            else
                Console.WriteLine("Variable '" + args[0] + "' not found\n");
        }

        private void ListVariables(string[] args)
        {
            if (variables.Count == 0)
            {
                Console.WriteLine("No variables set\n");
                return;
            }

            Console.WriteLine("\nVariables:");
            foreach (var v in variables)
            {
                Console.WriteLine(v.Key + " = " + v.Value);
            }
            Console.WriteLine();
        }

        private void WhoAmI(string[] args)
        {
            Console.WriteLine("root\n");
        }

        private void ShowMemory(string[] args)
        {
            Console.WriteLine("\nMemory Information:");
            Console.WriteLine("===================");
            Console.WriteLine("Total:  64 MB");
            Console.WriteLine("Used:   28 MB");
            Console.WriteLine("Free:   36 MB");
            Console.WriteLine("Usage:  43%\n");
        }

        private void Shutdown(string[] args)
        {
            Console.WriteLine("\nShutting down UraniumOS...");
            Environment.Exit(0);
        }

        private void Exit(string[] args)
        {
            isRunning = false;
            Console.WriteLine("\nExiting UraniumOS...\n");
        }
    }

    public class Kernel : Cosmos.System.Kernel
    {
        protected override void BeforeRun()
        {
        }

        protected override void Run()
        {
            CommandInterpreter interpreter = new CommandInterpreter();
            interpreter.Start();
        }
    }
}