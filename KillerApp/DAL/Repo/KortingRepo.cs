using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using KillerApp.DAL.Interface;

namespace KillerApp.DAL.Repo
{
    public class KortingRepo
    {
        private IKorting _kortingInterface;

        public KortingRepo(IKorting kortingInterface)
        {
            _kortingInterface = kortingInterface;
        }
    }
}