using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AttackOrDefendGame
{
    class GameManagement
    {
        //fields
        private int turn = 1;
        private string playerChoice;    //change back to private after testing
        private int enemyChoice;        //change back to private after testing
        private bool playGame = false;
        private int enemyNum = 1;
        private List<string> moveMsgs = new List<string>();
        private int difference = 0;
        private bool gamePlayedBefore = false;

        //methods
        public void GameRules()
        {
            string rules = "";
            rules += "Players get attack orbs if their attack causes the other player to " +
                     "loose any amount of health.\n";
            rules += "Players get defense orbs if they block any attack whether you take " +
                     "any damage or not.\n";
            Console.WriteLine(rules);
        }
        public bool StartGamePrompt()
        {
            //display start game prompt and get player inputs
            if(gamePlayedBefore == false)
            {
                Console.WriteLine("Would you like to play? Yes(Y) or No(N)");
                gamePlayedBefore = true;
            }
            else
            {
                Console.WriteLine("Would you like to play again? Yes(Y) or No(N)");
            }
            
            string playerInput = Console.ReadLine();

            //process the players input
            if(playerInput == "Y" || playerInput == "y" ||
               playerInput == "N" || playerInput == "n" )
            {
                if (playerInput == "Y" || playerInput == "y")
                {
                    playGame = true;
                }
                else if (playerInput == "N" || playerInput == "n")
                {
                    playGame = false;
                }
            }
            else
            {
                Console.WriteLine("That input was invalid. Try one of these - (Y/y/N/n).\n");
                Console.WriteLine();
                StartGamePrompt();
            }

            //create a border for separation
            Console.WriteLine();
            Console.WriteLine("**********************************************" +
                              "***********************************************\n");

            return playGame;
        }
        public void DisplayGameStats(Player player, Player enemy)
        {
            //creating the enemy name
            string enemyName = "Enemy " + enemyNum;
            enemy.Name = enemyName;

            //a string with all the game stats
            string gameStats = "\t\t\t" + "Turn " + turn + "\t\t\n" +
                               player.Name + "\t\t\t\t\t" +
                               enemy.Name + "\n" +
                               "Health: " + player.Health + "\t\t\t\t" +
                               "Health: " + enemy.Health + "\n" +
                               "Attack Level:  " + player.AttackLevel + "\t\t\t" +
                               "Attack Level: " + enemy.AttackLevel + "\n" +
                               "Defense Level: " + player.DefenseLevel + "\t\t\t" +
                               "Defense Level: " + enemy.DefenseLevel + "\n" +
                               "Attack Orbs: " + player.NumAttackOrbs + "\t\t\t\t" +
                               "Attack Orbs: " + enemy.NumAttackOrbs + "\n" +
                               "Defense Orbs: " + player.NumDefenseOrbs + "\t\t\t\t" +
                               "Defense Orbs: " + enemy.NumDefenseOrbs + "\n";

            //display the stats on the console
            Console.WriteLine(gameStats);
        }
        public bool EndGame(Player player, Player enemy)
        {
            if(enemy.Health == 0)
            {
                Console.WriteLine(player.Name + " won the battle! Game over.\n");

                //reset the turn number
                turn = 1;

                //next enemy
                enemyNum++;

                //reset player and enemy back to default stats
                

                return true;
            }
            else if(player.Health == 0)
            {
                Console.WriteLine(enemy.Name + " won the battle! Game over.\n");

                //reset the turn number
                turn = 1;

                //reset player and enemy back to default stats
                

                return true;
            }
            else
            {
                return false;
            }
        }
        public void ProcessTurn(Player player, Player enemy)
        {
            
            if (playerChoice == "1" && enemyChoice == 1)
            {
                //the 3 scenerios of if each player chooses attack
                if (player.AttackLevel == enemy.AttackLevel)
                {
                    Console.WriteLine(moveMsgs[0] + "\n");
                }
                else if (player.AttackLevel < enemy.AttackLevel)
                {
                    //calculate the difference between the enemy's attack level and player's 
                    //attack level then decrease player's health by the difference then
                    //give enemy an attack orb
                    difference = enemy.AttackLevel - player.AttackLevel;
                    enemy.AddAttackOrb();
                    player.DecreaseHealth(difference);

                    //display move msg
                    Console.WriteLine(moveMsgs[1] + "\n");
                }
                else if (player.AttackLevel > enemy.AttackLevel)
                {
                    //calculate the difference between player's attack level and enemy's 
                    //attack level then decrease enemy's health by the difference then
                    //give player an attack orb
                    difference = player.AttackLevel - enemy.AttackLevel;
                    player.AddAttackOrb();
                    enemy.DecreaseHealth(difference);

                    //display move msg
                    Console.WriteLine(moveMsgs[2] + "\n");
                }
            }
            else if (playerChoice == "1" && enemyChoice == 2)
            {
                //the 3 scenerios of if the player attacks but the enemy defends
                if (player.AttackLevel == enemy.DefenseLevel)
                {
                    enemy.AddDefenseOrb();
                    Console.WriteLine(moveMsgs[3] + "\n");
                }
                else if (player.AttackLevel < enemy.DefenseLevel)
                {
                    //calculate the difference between enemy's defense level and player's 
                    //attack level then decrease player's health by the differenced
                    difference = enemy.DefenseLevel - player.AttackLevel;
                    enemy.AddDefenseOrb();
                    player.DecreaseHealth(difference);

                    //display move message
                    Console.WriteLine(moveMsgs[5] + "\n");
                }
                else if (player.AttackLevel > enemy.DefenseLevel)
                {
                    //calculate the difference between players attack level and enemy 
                    //defense level then decrease enemy's health by the difference
                    difference = player.AttackLevel - enemy.DefenseLevel;
                    player.AddAttackOrb();
                    enemy.AddDefenseOrb();
                    enemy.DecreaseHealth(difference);

                    //display move message
                    Console.WriteLine(moveMsgs[4] + "\n");
                }
            }
            else if (playerChoice == "2" && enemyChoice == 1)
            {
                //the 3 scenerios of if the enemy attacks but the player blocks
                if (player.DefenseLevel == enemy.AttackLevel)
                {
                    player.AddDefenseOrb();
                    Console.WriteLine(moveMsgs[9] + "\n");
                }
                else if (player.DefenseLevel < enemy.AttackLevel)
                {
                    //calculate the difference between enemy's attack level and player's 
                    //defense level then decrease player's health by the differenced
                    difference = enemy.AttackLevel - player.DefenseLevel;
                    enemy.AddAttackOrb();
                    player.AddDefenseOrb();
                    player.DecreaseHealth(difference);

                    //display move message
                    Console.WriteLine(moveMsgs[10] + "\n");
                }
                else if (player.DefenseLevel > enemy.AttackLevel)
                {
                    //calculate the difference between players defense level and enemy's 
                    //attack level then decrease enemy's health by the differenced
                    difference = player.DefenseLevel - enemy.AttackLevel;
                    player.AddDefenseOrb();
                    enemy.DecreaseHealth(difference);

                    //display move message
                    Console.WriteLine(moveMsgs[11] + "\n");
                }
            }
            else
            {
                //display player's move
                if(playerChoice == "1")
                {
                    enemy.DecreaseHealth(player.AttackLevel);
                    player.AddAttackOrb();
                    Console.WriteLine(moveMsgs[6]);
                }
                else if(playerChoice == "2")
                {
                    Console.WriteLine(moveMsgs[15]);
                }
                else if (playerChoice == "3")
                {
                    player.UseAttackOrb();
                    Console.WriteLine(moveMsgs[7]);
                }
                else if (playerChoice == "4")
                {
                    player.UseDefenseOrb();
                    Console.WriteLine(moveMsgs[8]);
                }

                //display Enemy's move
                if (enemyChoice == 1)
                {
                    player.DecreaseHealth(enemy.AttackLevel);
                    enemy.AddAttackOrb();
                    Console.WriteLine(moveMsgs[12] + "\n");
                }
                else if (enemyChoice == 2)
                {
                    Console.WriteLine(moveMsgs[16] + "\n");
                }
                else if (enemyChoice == 3)
                {
                    enemy.UseAttackOrb();
                    Console.WriteLine(moveMsgs[13] + "\n");
                }
                else if (enemyChoice == 4)
                {
                    enemy.UseDefenseOrb();
                    Console.WriteLine(moveMsgs[14] + "\n");
                }
            }

            //add 1 to turn
            turn++;

            //create a border separating each turn 
            Console.WriteLine("**********************************************" + 
                              "***********************************************\n");
        }
        public void GetPlayerName(Player player)
        {
            Console.Write("Enter name: ");
            player.Name = Console.ReadLine();

            //create a border for separation
            Console.WriteLine();
            Console.WriteLine("**********************************************" +
                              "***********************************************\n");
        }
        public void GetPlayerChoice(Player player)
        {
            //display choices
            Console.Write("Pick a move:" + "\n" +
                              "Attack(1)" + "\n" +
                              "Block(2)" + "\n" +
                              "Use an Attack Orb if you have one(3)" + "\n" +
                              "Use a Defense Orb if you have one(4)" + "\n\n" + 
                              "Your choice: ");

            //get player keyboard input
            playerChoice = Console.ReadLine();

            //validate the players choice
            if(ValidatePlayerChoice(player) != true)
            {
                GetPlayerChoice(player);
            }
        }
        public void GetEnemyChoice(Player enemy)
        {
            //create a random number object and create a number 1-4
            Random rn = new Random();
            enemyChoice = rn.Next(1,5);

            //validate the enemy's choice 
            if (ValidateEnemyChoice(enemy) != true)
            {
                GetEnemyChoice(enemy);
            }
        }
        private bool ValidatePlayerChoice(Player player)
        {
            bool validChoice = true;

            //check if the user input one of the choices
            if (playerChoice == "1" || playerChoice == "2" ||
               playerChoice == "3" || playerChoice == "4")
            {
                //if use picked "use attack orbs or "use defence orbs"
                //check if there are any orbs to use
                if (playerChoice == "3")
                {
                    if (player.NumAttackOrbs == 0)
                    {
                        Console.WriteLine("You don't have any more attack orbs. " +
                                          "Choose a differ move.\n");
                        validChoice = false;
                    }
                }
                if (playerChoice == "4")
                {
                    if (player.NumDefenseOrbs == 0)
                    {
                        Console.WriteLine("You don't have any more defense orbs. " +
                                          "Choose a differ move.\n");
                        validChoice = false;
                    }
                }
            }
            else
            {
                Console.WriteLine("That input was invalid. " +
                                  "Choose a move from the move list.\n");
                validChoice = false;
            }

            return validChoice;
        }
        private bool ValidateEnemyChoice(Player enemy)
        {
            bool validChoice = true;

            //if enemy picked "use attack orbs or "use defence orbs"
            //check if there are any orbs to use
            if (enemyChoice == 3)
            {
                if (enemy.NumAttackOrbs == 0)
                {
                    validChoice = false;
                }
            }
            if (enemyChoice == 4)
            {
                if (enemy.NumDefenseOrbs == 0)
                {
                    validChoice = false;
                }
            }

            return validChoice;
        }
        public void LoadMoveMsgs()
        {
            moveMsgs.Add("Player and Enemy both attack. It was a draw. " +
                         "No one took damage.");
            moveMsgs.Add("Player and Enemy both attacked. The force from the attack " +
                         "was too much for Player to handle. Player took damage.");
            moveMsgs.Add("Player and Enemy both attacked. The force from the attack " +
                         "was too much for Enemy to handle. Enemy took damage.");
            moveMsgs.Add("Player attacks but enemy blocks the attack.");
            moveMsgs.Add("Player attacks but enemy blocks the attack. " +
                         "Unfornturnately enemy still took some damage " +
                         "from the force of the attack");
            moveMsgs.Add("Player attacks but enemy blocks the attack. " +
                         "Unfornturnately player was hurt by the recoil.");
            moveMsgs.Add("Player attacks enemy and it was a direct hit.");
            moveMsgs.Add("Player uses an attack orb. Player's attack level " +
                         "went up 5 points.");
            moveMsgs.Add("Player uses a defense orb. Player's defense level " +
                         "went up 5 points.");
            moveMsgs.Add("Enemy attacks but Player blocks the attack.");
            moveMsgs.Add("Enemy attacks but Player blocks the attack. " +
                         "Unfornturnately Player still took some damage " +
                         "from the force of the attack");
            moveMsgs.Add("Enemy attacks but Player blocks the attack. " +
                         "Unfornturnately Enemy was hurt by the recoil.");
            moveMsgs.Add("Enemy attacks Player and it was a direct hit.");
            moveMsgs.Add("Enemy uses an attack orb. Enemy's attack level " +
                         "went up 5 points.");
            moveMsgs.Add("Enemy uses a defense orb. Enemy's defense level " +
                         "went up 5 points.");
            moveMsgs.Add("Player blocks but enemy doesn't attack.");
            moveMsgs.Add("Enemy blocks but Player doesn't attack.");
            // add a message that tells the players that they got attack or defense orbs
        }
    }
}
