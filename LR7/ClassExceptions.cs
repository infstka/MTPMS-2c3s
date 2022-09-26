using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace oop_lab7
{
    
        class WeightException : Exception
        {
            public WeightException(string message) : base(message)
            {

            }

        }
        public class WhatException : Exception
        {

            public WhatException(string message) : base(message)
            {

            }
        }
        class NullException : NullReferenceException// генерируется при попытке обращения к объекту, который равен null (то есть по сути неопределен)
        {
            public NullException(string message) : base(message)
            {

            }

        }

       

       
    
}
