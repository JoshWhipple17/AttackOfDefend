using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AttackOrDefendGame
{
    class Program
    {
        static void Main(string[] args)
        {
            //declare the player, enemy, and the gameManager objects 
            Player player = new Player();
            Player enemy = new Player();
            GameManagement gameManager = new GameManagement();

            //load the move messages
            gameManager.LoadMoveMsgs();

            //start the game
            while (gameManager.StartGamePrompt() == true)
            { 
                //get players name
                gameManager.GetPlayerName(player);

                //process the turns
                while(true)
                {
                    //display game stats
                    gameManager.DisplayGameStats(player, enemy);

                    //get player choice and get enemy choice
                    gameManager.GetPlayerChoice(player);
                    gameManager.GetEnemyChoice(enemy);

                    // process turn
                    gameManager.ProcessTurn(player,enemy);

                    //check for end of game
                    if(gameManager.EndGame(player,enemy) == true)
                    {
                        break;
                    }
                }
            }

            //exit the console
            Console.WriteLine("Press any key to exit");
            Console.ReadKey();
        }
    }
}
