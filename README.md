# UraniumOS

A lightweight command-line operating system built with the **Cosmos Framework** in C#.

## Overview

UraniumOS is an experimental operating system designed to demonstrate core OS concepts including process management, file system operations, variable storage, and system utilities. It features a custom cursor and an intuitive command-line interface.

## Features

### System Commands
- `info` - Display system information
- `version` - Show OS version
- `whoami` - Display current user
- `memory` - Show memory usage
- `time` - Display current time
- `date` - Show current date
- `uptime` - Display system uptime

### File & Directory Management
- `dir` / `ls` - List directory contents
- `cd <path>` - Change directory
- `pwd` - Print working directory
- `mkdir` - Create directory
- `rm` - Remove file

### Process Management
- `ps` - List running processes
- `start <process>` - Start new process
- `kill <pid>` - Terminate process

### Utilities
- `echo <text>` - Print text
- `calc <num1> <op> <num2>` - Simple calculator
  - Example: `calc 10 + 5`
  - Supports: `+`, `-`, `*`, `/`
- `set <var> <value>` - Set variable
- `get <var>` - Get variable value
- `vars` - List all variables
- `clear` - Clear screen
- `help` - Show all commands

### System Control
- `shutdown` - Power off system
- `exit` - Exit OS

## Requirements

- **Cosmos Framework** - Latest version
- **Visual Studio** 2019 or later
- **.NET Framework** compatible compiler
- **QEMU** or **VirtualBox** (for testing)

## Installation

1. Install Cosmos Framework from [cosmosos.github.io](https://cosmosos.github.io)
2. Clone this repository:
   ```bash
   git clone https://github.com/sneeoosh/UraniumOS.git
   ```
3. Open the project in Visual Studio
4. Build and run in a virtual machine

## Usage

1. Boot UraniumOS
2. Type `help` to see available commands
3. Execute commands at the prompt

Example:
```
uranium:/> help
uranium:/> calc 10 + 5
Result: 10 + 5 = 15

uranium:/> set myvar "Hello World"
myvar = Hello World

uranium:/> get myvar
myvar = Hello World

uranium:/> ps
Running Processes:
==================
PID: 1 | Name: kernel | Status: Running
PID: 2 | Name: shell | Status: Running
```

## Architecture

- **Kernel** - Cosmos.System.Kernel base class
- **Command Interpreter** - Processes user input and executes commands
- **Process Manager** - Manages running processes
- **Variable Storage** - Stores system variables

## Roadmap

- [ ] File system integration
- [ ] Multi-user support
- [ ] Network capabilities
- [ ] GUI implementation
- [ ] Advanced process scheduling
- [ ] Shell scripting support

## Known Limitations

- Command-line interface only (GUI support planned)
- Limited file system operations
- Basic process management
- No network support in current version

## Contributing

Pull requests are welcome! For major changes, please open an issue first to discuss what you would like to change.

## License

This project is open source. Feel free to fork and modify as needed.

## Author

UraniumOS Development Team

## Notes

UraniumOS is an experimental project built for educational purposes to demonstrate operating system concepts. It is not intended for production use.

**Note for CLI skeptics:** A GUI version is planned for future releases. The current command-line interface provides a solid foundation for core OS functionality.

