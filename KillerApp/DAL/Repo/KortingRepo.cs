using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using KillerApp.DAL.Interface;
using KillerApp.Models;

namespace KillerApp.DAL.Repo
{
    public class KortingRepo
    {
        private IKorting _kortingInterface;

        public KortingRepo(IKorting kortingInterface)
        {
            _kortingInterface = kortingInterface;
        }

        public List<Korting> RetrieveAll()
        {
            return _kortingInterface.RetrieveAll();
        }

        public void CreateKorting(Korting k)
        {
            _kortingInterface.CreateKorting(k);
        }

        public List<Korting> RetrieveKortingByProduct(int id)
        {
            return _kortingInterface.RetrieveKortingByProduct(id);
        }

        public void DeleteKorting(int id)
        {
            _kortingInterface.DeleteKorting(id);
        }

        //public void UpdateKorting(Korting k)
        //{
        //    _kortingInterface.UpdateKorting(k);
        //}
    }
}