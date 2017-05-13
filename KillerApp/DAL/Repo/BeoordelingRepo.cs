using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using KillerApp.DAL.Interface;

namespace KillerApp.DAL.Repo
{
    public class BeoordelingRepo
    {
        private IBeoordeling _beoordelingInterface;

        public BeoordelingRepo(IBeoordeling beoordelingInterface)
        {
            _beoordelingInterface = beoordelingInterface;
        }
    }
}