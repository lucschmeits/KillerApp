using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using KillerApp.Models;

namespace KillerApp.DAL.Interface
{
    public interface IBeheerder
    {
        List<Beheerder> RetrieveAll();

        void CreateBeheerder(int id);

        Beheerder RetrieveBeheerder(int id);

        void DeleteBeheerder(int id);
    }
}