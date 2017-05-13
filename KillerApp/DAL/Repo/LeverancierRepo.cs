using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using KillerApp.DAL.Interface;

namespace KillerApp.DAL.Repo
{
    public class LeverancierRepo
    {
        private ILeverancier _leverancierInterface;

        public LeverancierRepo(ILeverancier leverancierInterface)
        {
            _leverancierInterface = leverancierInterface;
        }
    }
}