using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using KillerApp.Models;

namespace KillerApp.DAL.Interface
{
    public interface IProductCategorie
    {
        List<Categorie> RetrieveAll();

        void CreateCategorie(Categorie c);

        Categorie RetrieveCategorie(int id);

        void DeleteCategorie(int id);

        void UpdateCategorie(Categorie c);
    }
}