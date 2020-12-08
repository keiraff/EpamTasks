using EpamTask1.Components;
using System;
using System.Collections.Generic;
using System.Text;

namespace EpamTask1.Services
{
    public class ComparerByWeight : IComparer<Component>
    {
        public int Compare(Component a, Component b)
        {
            if (a.Weight > b.Weight) return 1;
            if (a.Weight < b.Weight) return -1;
            return 0;

        }
    }
}
