using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using KillerApp.DAL.Interface;
using KillerApp.Models;

namespace KillerApp.DAL.Repo
{
    public class GebruikerRepo
    {
        private IGebruiker _gebruikerInterface;

        public GebruikerRepo(IGebruiker gebruikerInterface)
        {
            _gebruikerInterface = gebruikerInterface;
        }

        public int CreateGebruiker(Gebruiker g)
        {
            return _gebruikerInterface.CreateGebruiker(g);
        }

        public void UpdateGebruiker(Gebruiker g)
        {
            _gebruikerInterface.UpdateGebruiker(g);
        }
    }
}