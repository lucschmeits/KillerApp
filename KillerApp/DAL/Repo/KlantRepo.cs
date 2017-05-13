using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using KillerApp.DAL.Interface;

namespace KillerApp.DAL.Repo
{
    public class KlantRepo
    {
        private IKlant _klantInterface;

        public KlantRepo(IKlant klantInterface)
        {
            _klantInterface = klantInterface;
        }
    }
}