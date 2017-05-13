using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using KillerApp.DAL.Interface;

namespace KillerApp.DAL.Repo
{
    public class AfbeeldingRepo
    {
        private IAfbeelding _afbeeldingInterface;

        public AfbeeldingRepo(IAfbeelding afbeeldingInterface)
        {
            _afbeeldingInterface = afbeeldingInterface;
        }
    }
}