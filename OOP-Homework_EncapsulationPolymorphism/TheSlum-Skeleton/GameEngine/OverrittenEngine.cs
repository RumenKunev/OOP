using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using TheSlum.Characters;
using TheSlum.Items;

namespace TheSlum.GameEngine
{
    public class OverrittenEngine : Engine
    {
        public OverrittenEngine()
            :base()
        {

        }
        protected override void ExecuteCommand(string[] inputParams)
        {
            switch (inputParams[0])
            {
                case "create": CreateCharacter(inputParams);
                    break;
                case "add": AddItem(inputParams);
                    break;
                default:
                    base.ExecuteCommand(inputParams);
                    break;
            }
        }

        protected override void CreateCharacter(string[] inputParams)
        {
            Character character;

            switch (inputParams[1])
            {
                case "warrior":
                    character = new Warrior(
                        inputParams[2],
                        int.Parse(inputParams[3]),
                        int.Parse(inputParams[4]),
                        (Team)Enum.Parse(typeof(Team), inputParams[5], true)
                        );
                    this.characterList.Add(character);
                    break;
                case "mage":
                    character = new Mage(
                        inputParams[2],
                        int.Parse(inputParams[3]),
                        int.Parse(inputParams[4]),
                        (Team)Enum.Parse(typeof(Team), inputParams[5], true)
                        );
                    this.characterList.Add(character);
                    break;
                case "healer":
                    character = new Healer(
                        inputParams[2],
                        int.Parse(inputParams[3]),
                        int.Parse(inputParams[4]),
                        (Team)Enum.Parse(typeof(Team), inputParams[5], true)
                        );
                    this.characterList.Add(character);
                    break;
                default:
                    break;
            }

        }

        protected new void AddItem(string[] inputParams)
        {
            string charackterID = inputParams[1];
            string itemClass = inputParams[2];
            string itemId = inputParams[3];

            Item item;

            switch (itemClass)
            {
                case "axe":
                    item = new Axe(itemId);
                    GetCharacterById(charackterID).AddToInventory(item);
                    break;
                case "shield":
                    item = new Shield(itemId);
                    GetCharacterById(charackterID).AddToInventory(item);
                    break;
                case "injection":
                    item = new Injection(itemId);
                    GetCharacterById(charackterID).AddToInventory(item);
                    break;
                case "pill":
                    item = new Pill(itemId);
                    GetCharacterById(charackterID).AddToInventory(item);
                    break;
                default:
                    break;
            }
        }
    }
}
