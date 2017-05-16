using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using KillerApp.Models;

namespace KillerApp.DAL.Interface
{
    public interface IGebruiker
    {
        int CreateGebruiker(Gebruiker g);

        void UpdateGebruiker(Gebruiker g);
    }
}