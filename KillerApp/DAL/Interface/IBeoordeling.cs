using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using KillerApp.Models;

namespace KillerApp.DAL.Interface
{
    public interface IBeoordeling
    {
        List<Beoordeling> RetrieveAll();

        void CreateBeoordeling(Beoordeling b);

        Beoordeling RetrieveBeoordeling(int id);

        void DeleteBeoordeling(int id);

        void UpdateBeoordeling(Beoordeling b);
    }
}