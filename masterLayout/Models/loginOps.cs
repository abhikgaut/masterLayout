using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace masterLayout.Models
{
    public class loginOps
    {
        static db4Entities D = D = new db4Entities();
        public static bool search(string user,string pass)
        {
            var E = (from L in D.tblLogins
                    where L.username == user && L.password == pass
                    select L).FirstOrDefault();
            if (E != null)
                return true;
            else
                return false;
        }
    }
}