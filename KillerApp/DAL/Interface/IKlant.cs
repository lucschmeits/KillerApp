using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using KillerApp.Models;

namespace KillerApp.DAL.Interface
{
    public interface IKlant
    {
        List<Klant> RetrieveAll();

        void CreateKlant(int id, Klant k);

        Klant RetrieveKlant(int id);

        void DeleteKlant(int id);

        void UpdateKlant(Klant k);
    }
}