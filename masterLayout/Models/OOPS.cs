using System;
using System.Collections.Generic;
using System.Data.Entity.Infrastructure;
using System.Data.Entity.Validation;
using System.Data.SqlClient;
using System.Linq;
using System.Web;

namespace masterLayout.Models
{   
    public class OOPS
    {
        static db4Entities Db = new db4Entities();
        public static List<EMPDATA> getall()
        {
            var E = from E1 in Db.EMPDATAs
                    select E1;
            return E.ToList();
        }
        public static string insertEmp(EMPDATA Em)
        {
            try
            {
                Db.EMPDATAs.Add(Em);
                Db.SaveChanges();
            }
            catch (DbUpdateException d)
            {
                SqlException ex = d.GetBaseException() as SqlException;
                if (ex.Message.Contains("EMP_PK"))
                    return "employee no cannot be dupicate";
                else if (ex.Message.Contains("FK__EMPDATA__DEPTNO__412EB0B6"))
                    return "no proper deptno";
                else
                    return "error occured";
            }
            catch (Exception E)
            {

                SqlException ex = E.GetBaseException() as SqlException;
                string str = E.Message;
            }
            return "done";
        }
        public static EMPDATA GetEmpupdate(int Empno)
        {
            var LE = from L in Db.EMPDATAs
                     where L.EMPNO == Empno
                     select L;
            return LE.FirstOrDefault();
        }
        public static string delEmp(int empno)
        {
            var E = (from L in Db.EMPDATAs
                     where L.EMPNO == empno
                     select L).FirstOrDefault();
            Db.EMPDATAs.Remove(E);
            Db.SaveChanges();
            return "record deleted";
        }
        public static string updateEmp(EMPDATA emp)
        {
            var LE = from L in Db.EMPDATAs
                     where L.EMPNO == emp.EMPNO
                     select L;
            EMPDATA E = LE.First();
            E.JOB = emp.JOB;
            E.MGR = emp.MGR;
            E.SAL = emp.SAL;
            E.COMM = emp.COMM;
            E.DEPTNO = emp.DEPTNO;

            Db.SaveChanges();
            return "1 Row Updated";
        }
    }
}