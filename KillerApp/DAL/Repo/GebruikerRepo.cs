using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using KillerApp.DAL.Interface;

namespace KillerApp.DAL.Repo
{
    public class GebruikerRepo
    {
        private IGebruiker _gebruikerInterface;

        public GebruikerRepo(IGebruiker gebruikerInterface)
        {
            _gebruikerInterface = gebruikerInterface;
        }
    }
}