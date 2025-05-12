using EmployeeApp.Model.Request;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace EmployeeApp.Model.Responce
{
    public class EmployeeDataResponce
    {

        [Key]
        public int EMPId { get; set; }
        public string Name { get; set; } = string.Empty;
        public string Description { get; set; } = string.Empty;
        public string RoleName { get; set; } 
    }


    //public class EmployeeDataResponce_v1:EmployeeDataResponce
    //{
    //        public  List<EmployeeRoleInfo> EmployeeRoleInfo { get; set; } 

    //}


    //public class EmployeeRoleInfo:Role
    //{
    //    //public List<Role> Roles { get; set; }
    //    public string RoleName { get; set; }
  
    //}
    ////public  class Roles : Role
    ////{ 
    ////}

    ////public class Roles :Role
    ////{
    ////    //[Key]
    ////    //public int ID { get; set; }
    ////    //public string RoleName { get; set; } = string.Empty;


    ////}




    public class EmployeeRoleInfo
    {
        public string RoleName { get; set; }
    }

    public class EmployeeDataResponce_v1
    {
        public int EmpId { get; set; }
        public string Name { get; set; }
        public string Description { get; set; }
        public string RoleName { get; set; }
        public int RoleId { get; set; }
        public List<EmployeeRoleInfo> Roles { get; set; }
    }

    //public class DataWrapper
    //{
    //    public List<EmployeeDataResponce_v1> EmployeeData { get; set; }
    //}

    public class EmployeeRoleResult
    {
        public string Name { get; set; }
        public string Description { get; set; }
        public int RoleId { get; set; }
        public string RoleName { get; set; }
        public List<Role> AllRoles { get; set; } // Assuming 'Role' is your DB model
    }



}
