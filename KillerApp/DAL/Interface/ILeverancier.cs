using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using KillerApp.Models;

namespace KillerApp.DAL.Interface
{
    public interface ILeverancier
    {
        List<Leverancier> RetrieveAll();

        void CreateLeverancier(Leverancier l);

        Leverancier RetrieveLeverancier(int id);

        void DeleteLeverancier(int id);

        void UpdateLeverancier(Leverancier l);
    }
}