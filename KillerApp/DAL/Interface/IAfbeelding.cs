using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using KillerApp.Models;

namespace KillerApp.DAL.Interface
{
    public interface IAfbeelding
    {
        List<Afbeelding> RetrieveAll();

        int CreateAfbeelding(Afbeelding a);

        List<Afbeelding> RetrieveAfbeeldingByProduct(int id);

        void DeleteAfbeelding(int id);
        void KoppelAfbeeldingProduct(int afbeeldingId, int productId);
    }
}