using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using KillerApp.Models;

namespace KillerApp.DAL.Interface
{
    public interface IKorting
    {
        List<Korting> RetrieveAll();

        void CreateKorting(Korting k);

        List<Korting> RetrieveKortingByProduct(int id);

        void DeleteKorting(int id);

        Korting RetrieveKortingById(int id);

         void UpdateKorting(Korting k, List<int> productIds);

        List<Product> RetrieveProductsByKorting(int kortingId);
    }
}