using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using KillerApp.DAL.Interface;
using KillerApp.Models;

namespace KillerApp.DAL.Repo
{
    public class BeheerderRepo
    {
        private IBeheerder _beheerderInterface;

        public BeheerderRepo(IBeheerder beheerderInterface)
        {
            _beheerderInterface = beheerderInterface;
        }

        public List<Beheerder> RetrieveAll()
        {
            return _beheerderInterface.RetrieveAll();
        }

        public void CreateBeheerder(int id)
        {
            _beheerderInterface.CreateBeheerder(id);
        }

        public Beheerder RetrieveBeheerder(int id)
        {
            return _beheerderInterface.RetrieveBeheerder(id);
        }

        public void DeleteBeheerder(int id)
        {
            _beheerderInterface.DeleteBeheerder(id);
        }
    }
}