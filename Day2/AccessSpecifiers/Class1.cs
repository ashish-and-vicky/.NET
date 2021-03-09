using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AccessSpecifiers
{
    public class BaseClass
    {
        public int PUBLIC; //everywhere
        private int PRIVATE; // same class
        protected int PROTECTED;// same class, derived class
        internal int INTERNAL;// same class, same assembly( a project )
        protected internal int PROTECTED_INTERNAL;// same class, derived class, same assembly

    }
}
