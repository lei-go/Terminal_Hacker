using UnityEngine;

public class Hacker : MonoBehaviour
{
    //game config data
    string[] libraryPassword = {"book","font","borrow","shakespeare"};
    string[] bpdPassword = {"petrol","helicopter","forgery","vandalism"};
    string[] nasaPassword = {"infrared","Galileo","meteorite","aeronautical"};

    //game state
    int level;
    enum Screen {MainMenu, Password, Win};
    Screen currentScreen = Screen.MainMenu;
    string password;

    void Start()
    {
        ShowMainMenu();
    }

    void ShowMainMenu() {
        level = 0;
        password = "";
        currentScreen = Screen.MainMenu;
        Terminal.ClearScreen();
        Terminal.WriteLine("Hello, Agent Z");
        Terminal.WriteLine("Where you like to hack into?\n");
        Terminal.WriteLine("Press 1: Mugar Library");
        Terminal.WriteLine("Press 2: Boston Police Department");
        Terminal.WriteLine("Press 3: for NASA\n");
        Terminal.WriteLine("Enter your selection: ");
    }

    void OnUserInput(string input)
    {
        if (input == "menu") ShowMainMenu();
        else if (currentScreen == Screen.MainMenu) RunMainMenu(input);
        else if (currentScreen == Screen.Password) CheckPassword(input);
    }

    private void RunMainMenu(string input)
    {
        bool isValidLevel = (input == "1" || input == "2" || input == "3");
        if (isValidLevel)
        {
            level = int.Parse(input);
            StartGame();
        }
        else
        {
            string statement = (input == "007") ? "James Bond" : "Option not available";
            Terminal.WriteLine(statement);
        }
    }

    void StartGame()
    {
        currentScreen = Screen.Password;

        Terminal.ClearScreen();
        string statement = (level == 1) ? "you chose Mugar Library" :
                    (level == 2) ? "you chose Boston Police Department" :
                    (level == 3) ? "you chose NASA" : "Error Occur, type menu to return";
        Terminal.WriteLine(statement);

        switch(level)
        {
            case 1:
                password = libraryPassword[Random.Range(0,libraryPassword.Length)];
                break;
            case 2:
                password = bpdPassword[Random.Range(0,bpdPassword.Length)];
                break;
            case 3:
                password = nasaPassword[Random.Range(0,nasaPassword.Length)];
                break;
            default:
                Debug.LogError("Invalid Level Number");
                break;
        }
        Terminal.WriteLine("Enter Password: ");
        Terminal.WriteLine("(hint: " + password.Anagram() + ")");
    }

    void CheckPassword(string input)
    {
        if (input == password)
        {
            DisplayWinScreen();
        }
        else
        {
            Terminal.WriteLine("Password Incorrect");
        }
    }

    void DisplayWinScreen()
    {
        currentScreen = Screen.Win;
        Terminal.ClearScreen();
        ShowLevelReward();
    }

    void ShowLevelReward()
    {
        switch(level)
        {
            case 1:
                Terminal.WriteLine("You just unlocked a book!");
                Terminal.WriteLine(@"
      ______ ______
    _/      Y      \_
   // ~~ ~~ | ~~ ~  \\
  // ~ ~ ~~ | ~~~ ~~ \\
 //________.|.________\\
`----------`-'----------'
(type 'menu' to return)
                ");
                break;

            case 2:
                Terminal.WriteLine("You just unlocked a prison key!");
                Terminal.WriteLine(@"

    ooo,    .---.
 o`  o   /    |\________________
o`   'oooo()  | ________   _   _)
`oo   o` \    |/        | | | |
  `ooo'   `---'         |_| |_| 
(type 'menu' to return)
                ");
                break;

                case 3:
                Terminal.WriteLine(@"
 You just unlocked an AI robot!
         __
 _(\    |@@|
(__/\__ \--/ __
   \___|----|  |   __
       \ }{ /\ )_ / _\
       /\__/\ \__O (__
      (--/\--)    \__/
      _)(  )(_
     `---''---`  
(type 'menu' to return)");
                break;

                default:
                    Debug.LogError("Invalid level reached");
                    break;
        }
    }

    // Update is called once per frame
    void Update()
    {
        
    }
}
