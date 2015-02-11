﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace TheSlum.Items
{
    public class Shield : Item
    {
        public Shield(string id, int healthEffect = 0, int defenseEffect = 50, int attackEffect = 0)
            : base(id, healthEffect, defenseEffect, attackEffect)
        {
        }
    }
}
