using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using KillerApp.DAL.Interface;

namespace KillerApp.DAL.Repo
{
    public class BeheerderRepo
    {
        private IBeheerder _beheerderInterface;

        public BeheerderRepo(IBeheerder beheerderInterface)
        {
            _beheerderInterface = beheerderInterface;
        }
    }
}