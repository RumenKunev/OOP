using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using TheSlum.Interfaces;

namespace TheSlum.Characters
{
    public class Healer : Character, IHeal
    {
        public Healer(string id, int x, int y, Team team, int healthPoints = 75, int defensePoints = 50, int range = 6, int healingPoints = 60)
            : base(id, x, y, healthPoints, defensePoints, team, range)
        {
            this.HealingPoints = healingPoints;
        }
        public int HealingPoints { get; set; }

        public override Character GetTarget(IEnumerable<Character> targetsList)
        {
            var targetsSortedByHealthPoints = targetsList.Where(target => target.Team == this.Team && target.IsAlive && !Equals(this))
                .OrderBy(target => target.HealthPoints).FirstOrDefault();
            return targetsSortedByHealthPoints;
        }

        public override void AddToInventory(Item item)
        {
            this.Inventory.Add(item);
            base.ApplyItemEffects(item);
        }

        public override void RemoveFromInventory(Item item)
        {
            this.Inventory.Remove(item);
            base.RemoveItemEffects(item);
        }

        public override string ToString()
        {
            return base.ToString() + string.Format(", Healing: {0}", this.HealingPoints);
        }
    }
}
