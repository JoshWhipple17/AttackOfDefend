using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AttackOrDefendGame
{
    class Player
    {
        //fields
        private string name = "";
        private int health = 100;
        private int attackLevel = 5;
        private int defenseLevel = 5;
        private int numAttackOrbs = 2;
        private int numDefenseOrbs = 2;

        //properties
        public string Name
        {
            set { name = value; }
            get { return name; }
        }
        public int Health
        {
            get { return health; }
        }
        public int AttackLevel
        {
            get { return attackLevel; }
        }
        public int DefenseLevel
        {
            get { return defenseLevel; }
        }
        public int NumAttackOrbs
        {
            get { return numAttackOrbs; }
        }
        public int NumDefenseOrbs
        {
            get { return numDefenseOrbs; }
        }

        //methods
        public void DecreaseHealth(int enemyAttackLevel)
        {
            health -= enemyAttackLevel;

            //if health is less than 0 set it back to 0 
            //so there isnt a negative number displayed 
            //for the players health
            if(health < 0)
            {
                health = 0;
            }
        }
        public void UseAttackOrb()
        {
            attackLevel += 5;
            numAttackOrbs--;
        }
        public void UseDefenseOrb()
        {
            defenseLevel += 5;
            numDefenseOrbs--;
        }
        public void AddAttackOrb()
        {
            numAttackOrbs++;
        }
        public void AddDefenseOrb()
        {
            numDefenseOrbs++;
        }
    }
}
