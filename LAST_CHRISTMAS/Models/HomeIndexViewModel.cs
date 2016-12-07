using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace LAST_CHRISTMAS.Models
{
    public class HomeIndexViewModel
    {
        public bool PawelUnlocked { get; set; }
        public bool AniaUnlocked { get; set; }
        public bool JustynaUnlocked { get; set; }
        public bool MarcinUnlocked { get; set; }


        public bool UnlockedAll
        {
            get
            {
                return PawelUnlocked && AniaUnlocked && JustynaUnlocked && MarcinUnlocked;
            }
        }


    }
}