# Game Library Management System

## Description
This is a simple console-based application written in C# that simulates a game library management system. The application allows users to manage their game collections, purchase games, and track playtime. It includes both user and administrator functionalities.

## Features
### User Features:
- Log in to the system.
- View account details.
- Add funds to the account balance.
- Purchase games from the platform.
- Track playtime for owned games.
- View statistics of owned games.

### Administrator Features:
- Add new games to the library.
- Edit game details (name, price, genre).
- Manage user accounts (change password, email, nickname).
- View the list of games available on the platform.
- Create new user accounts.

## Installation
1. Clone the repository or download the source files.
2. Open the project in Visual Studio or any compatible C# IDE.
3. Compile and run the program.

## Usage
1. When the application starts, users can log in using predefined accounts:
   - **Administrator**: Login - `admin`, Password - `admin`
   - **User**: Login - `user`, Password - `user`
2. After logging in, users will see a menu with different options depending on their role.
3. Navigate through the menu using arrow keys and press `Enter` to select an option.
4. Administrators can manage games and user accounts, while regular users can buy games and track playtime.
5. Press `Escape` to go back or exit from the editing options.

## File Structure
- **Program.cs**: Entry point of the application, handles user authentication and main menu.
- **Konto.cs**: Defines the `Konto` class, representing user accounts.
- **Gra.cs**: Defines the `Gra` class, representing game objects.
- **Biblioteka.cs**: Defines the `Biblioteka` class, managing the collection of games and playtime tracking.
- **Administrator.cs**: Defines the `Administrator` class, extending `Konto` with additional administrative functionalities.

## Future Improvements
- Implement a graphical user interface (GUI) for better user experience.
- Add a database for persistent storage of user data and game details.
- Implement an online multiplayer feature to connect users.

## Author
Developed by Oliwia Ankiewicz.

