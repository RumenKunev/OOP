using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using TheSlum.Interfaces;

namespace TheSlum.Characters
{
    public class Mage : Character, IAttack
    {
        public Mage(string id, int x, int y, Team team, int healthPoints = 150, int defensePoints = 50, int range = 5, int attackPoints = 300)
            : base(id, x, y, healthPoints, defensePoints, team, range)
        {
            this.AttackPoints = attackPoints;
        }

        public int AttackPoints { get; set; }

        public override Character GetTarget(IEnumerable<Character> targetsList)
        {
            var target = targetsList.LastOrDefault(x => (x.IsAlive && x.Team != this.Team));
            return target;
        }

        public override void AddToInventory(Item item)
        {
            this.Inventory.Add(item);
            base.ApplyItemEffects(item);
            this.AttackPoints += item.AttackEffect;
        }
        
        public override void RemoveFromInventory(Item item)
        {
            this.Inventory.Remove(item);
            base.RemoveItemEffects(item);
            this.AttackPoints -= item.AttackEffect;
        }

        public override string ToString()
        {
            return base.ToString() + string.Format(", Attack: {0}", this.AttackPoints);
        }
    }
}
