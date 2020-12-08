using EpamTask1.Components;
using System;
using System.Collections.Generic;
using System.Text;

namespace EpamTask1.Services
{
    public class ComparerByPrice:IComparer<Component>
    {
        public int Compare(Component a, Component b)
        {

            if (a.Price > b.Price) return 1;
            if (a.Price < b.Price) return -1;
            return 0;

        }
    }
}
