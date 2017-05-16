using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using KillerApp.DAL.Interface;
using KillerApp.Models;

namespace KillerApp.DAL.Repo
{
    public class KlantRepo
    {
        private IKlant _klantInterface;

        public KlantRepo(IKlant klantInterface)
        {
            _klantInterface = klantInterface;
        }

        public List<Klant> RetrieveAll()
        {
            return _klantInterface.RetrieveAll();
        }

        public void CreateKlant(int id, Klant k)
        {
            _klantInterface.CreateKlant(id, k);
        }

        public Klant RetrieveKlant(int id)
        {
            return _klantInterface.RetrieveKlant(id);
        }

        public void DeleteKlant(int id)
        {
            _klantInterface.DeleteKlant(id);
        }

        public void UpdateKlant(Klant k)
        {
            _klantInterface.UpdateKlant(k);
        }
    }
}