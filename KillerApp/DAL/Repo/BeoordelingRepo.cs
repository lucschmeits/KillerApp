using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using KillerApp.DAL.Interface;
using KillerApp.Models;

namespace KillerApp.DAL.Repo
{
    public class BeoordelingRepo
    {
        private IBeoordeling _beoordelingInterface;

        public BeoordelingRepo(IBeoordeling beoordelingInterface)
        {
            _beoordelingInterface = beoordelingInterface;
        }

        public List<Beoordeling> RetrieveAll()
        {
            return _beoordelingInterface.RetrieveAll();
        }

        public void CreateBeoordeling(Beoordeling b)
        {
            _beoordelingInterface.CreateBeoordeling(b);
        }

        public Beoordeling RetrieveBeoordeling(int id)
        {
            return _beoordelingInterface.RetrieveBeoordeling(id);
        }

        public void DeleteBeoordeling(int id)
        {
            _beoordelingInterface.DeleteBeoordeling(id);
        }

        public List<Beoordeling> BeoordelingByProduct(int id)
        {
            return _beoordelingInterface.BeoordelingByProduct(id);
        }
    }
}