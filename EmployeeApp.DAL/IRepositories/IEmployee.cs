using EmployeeApp.Model.Request;
using EmployeeApp.Model.Responce;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace EmployeeApp.DAL.IRepositories
{
    public interface IEmployee
    {

        void AddEmployee(EmployeeData employee);
        IEnumerable<EmployeeData> GetEmployee();
        EmployeeData GetEmployeeById(int id);
        List<EmployeeDataResponce> EmployeeData(int? EMPId);
        void UpdateEmployee(EmployeeData employee, EmployeeData employee1);
        void DeleteEmployee(EmployeeData employee);
        void AddRoles(Role role);
        List<EmployeeDataResponce_v1> EmployeeInfo ();

        void AddCropData(CropMaster cropMaster);
        void AddProduct(ProductMaster productMaster);

        List<CropMaster> GetCropData();
        CropMaster GetCropDataById(int Id);
        string GetCropDataDeleteByID(CropMaster cropMaster);


        //List<Crop_ProductDataResponce> GetCrop_ProductData();
        List<SeasonDataResponce> GetCrop_ProductData();

        void AddSeasonData(Season_Master season_Master);
    }
}
