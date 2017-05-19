using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using KillerApp.DAL.Interface;
using KillerApp.Models;

namespace KillerApp.DAL.Repo
{
    public class LeverancierRepo
    {
        private ILeverancier _leverancierInterface;

        public LeverancierRepo(ILeverancier leverancierInterface)
        {
            _leverancierInterface = leverancierInterface;
        }

        public List<Leverancier> RetrieveAll()
        {
            return _leverancierInterface.RetrieveAll();
        }

        public void CreateLeverancier(Leverancier l)
        {
            _leverancierInterface.CreateLeverancier(l);
        }

        public Leverancier RetrieveLeverancier(int id)
        {
            return _leverancierInterface.RetrieveLeverancier(id);
        }

        public void DeleteLeverancier(int id)
        {
            _leverancierInterface.DeleteLeverancier(id);
        }

        public void UpdateLeverancier(Leverancier l)
        {
            _leverancierInterface.UpdateLeverancier(l);
        }
    }
}