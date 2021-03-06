﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using KillerApp.DAL.Interface;
using KillerApp.Models;

namespace KillerApp.DAL.Repo
{
    public class AfbeeldingRepo
    {
        private IAfbeelding _afbeeldingInterface;

        public AfbeeldingRepo(IAfbeelding afbeeldingInterface)
        {
            _afbeeldingInterface = afbeeldingInterface;
        }

        public List<Afbeelding> RetrieveAll()
        {
            return _afbeeldingInterface.RetrieveAll();
        }

        public int CreateAfbeelding(Afbeelding a)
        {
           return _afbeeldingInterface.CreateAfbeelding(a);
        }

        public List<Afbeelding> RetrieveAfbeeldingByProduct(int id)
        {
            return _afbeeldingInterface.RetrieveAfbeeldingByProduct(id);
        }

        public void DeleteAfbeelding(int id)
        {
            _afbeeldingInterface.DeleteAfbeelding(id);
        }

        public void KoppelAfbeeldingProduct(int afbeeldingId, int productId)
        {
            _afbeeldingInterface.KoppelAfbeeldingProduct(afbeeldingId, productId);
        }
    }
}