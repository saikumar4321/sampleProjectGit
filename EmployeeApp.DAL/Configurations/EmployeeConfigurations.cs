using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using EmployeeApp.DAL.IRepositories;
using EmployeeApp.Model;
using EmployeeApp.DAL.Configurations;
using EmployeeApp.Model.Request;
using EmployeeApp.DAL.EmployeeDBContext;
using EmployeeApp.Model.Responce;
using Microsoft.Extensions.Logging;
using EmployeeApp.Model.Utils;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Query.Internal;

namespace EmployeeApp.DAL.Configurations
{
    public class EmployeeConfigurations : IEmployee
    {

      public  readonly EmployeeContext _employeeDBContext;
        readonly ILogger<EmployeeConfigurations> _logger;

       public EmployeeConfigurations(EmployeeContext employeeContext , ILogger<EmployeeConfigurations> logger )
        { 
        
            _employeeDBContext = employeeContext;
            _logger = logger;
        
        }

    public  void AddEmployee (EmployeeData employee)
    {
              
            _employeeDBContext.EmployeeData.Add(employee);
            _employeeDBContext.SaveChanges();   

    }

    public void AddRoles(Role role)
    {
            _employeeDBContext.Role.Add(role);
            _employeeDBContext.SaveChanges();
    }

        public IEnumerable<EmployeeData> GetEmployee()
        {
            return _employeeDBContext.EmployeeData.ToList();
             
        }

        


        public EmployeeData GetEmployeeById(int EMPId)
        {
            return _employeeDBContext.EmployeeData.FirstOrDefault(e => e.EMPId == EMPId);
        }


        public void UpdateEmployee(EmployeeData employee, EmployeeData employee1)
        {

            employee.Name = employee1.Name;
            employee.Description = employee1.Description;
            _employeeDBContext.SaveChanges();
        }

        public void DeleteEmployee(EmployeeData employee)
        {

            _employeeDBContext.EmployeeData.Remove(employee);
            _employeeDBContext.SaveChanges();
        }


       public List<EmployeeDataResponce> EmployeeData( int? EMPId = null)
        {
            var employeeData = new List<EmployeeDataResponce>();
            try
            {

                var employee = _employeeDBContext.EmployeeData.ToList();
                var role = _employeeDBContext.Role.ToList();

                 employeeData = (from emp in employee
                                     join rol in role on emp.RoleId equals rol.ID where !EMPId.HasValue || emp.EMPId == EMPId.Value orderby
                                      rol.RoleName descending 
                                    select new EmployeeDataResponce
                                    {
                                        EMPId = emp.EMPId,
                                        Name = emp.Name,
                                        Description = emp.Description,
                                        RoleName = rol.RoleName
                                    }).ToList();
            }
            catch (Exception ex)
            {
                _logger.LogInformation("EmployeeData " + ex.Message);
                    
            }
            finally
            {

            }

            return employeeData;
        }

        public List<EmployeeDataResponce_v1> EmployeeInfo()
        {
            
            var empinfo = new List<EmployeeDataResponce_v1>();

            var EMP = _employeeDBContext.EmployeeData.Where(e => e.Name == "saikumar").Select(EmployeeData => new EmployeeDataResponce_v1
            {
                Name = EmployeeData.Name,
                RoleId = EmployeeData.RoleId
            }).Distinct().ToList();

            var allRoles = _employeeDBContext.Role.ToList();

            try
            {

                //foreach (var emp in EMP)
                //{
                //    var empRole = allRoles.FirstOrDefault(r => r.ID == emp.RoleId);
                //    if (empRole != null)
                //    {
                //        empinfo.Add(new EmployeeDataResponce_v1
                //        {
                //            EmpId = emp.EMPId,
                //            Name = emp.Name,
                //            Description = emp.Description,
                //            RoleName = empRole.RoleName,
                //            //Roles = new List<EmployeeRoleInfo>
                //            //{
                //            //    new EmployeeRoleInfo
                //            //    {
                //            //        RoleName = empRole.RoleName
                //            //    }
                //            //}
                //        });
                //    }
                //}
                empinfo = (from e in _employeeDBContext.EmployeeData
                           join erm in _employeeDBContext.EmployeeDataResponce on e.EMPId equals erm.EMPId into empRoleGroup
                           select new EmployeeDataResponce_v1
                           {
                               EmpId = e.EMPId,
                               Name = e.Name,
                               Description = e.Description,
                               // Get the first role name for display (if needed)
                               RoleName = (from er in _employeeDBContext.EmployeeData
                                           join r in _employeeDBContext.Role on er.RoleId equals r.ID
                                           where er.EMPId == e.EMPId
                                           select r.RoleName).FirstOrDefault(),

                               Roles = (from er in _employeeDBContext.EmployeeData
                                        join r in _employeeDBContext.Role on er.RoleId equals r.ID
                                        where er.EMPId == e.EMPId
                                        select new EmployeeRoleInfo
                                        {
                                            RoleName = r.RoleName
                                        }).ToList()
                           }).ToList();

            }
            catch (Exception ex)
            {
                _logger.LogError("EmployeeInfo error: " + ex.Message);
            }

            return empinfo;
        }



        //public List<EmployeeDataResponce_v1> EmployeeInfo()
        //{
        //    var empinfo = new List<EmployeeDataResponce_v1>();
        //    var allRoles = _employeeDBContext.Role.ToList();

        //    try
        //    {
        //        empinfo = _employeeDBContext.EmployeeData
        //            .AsEnumerable()
        //            .Select(e => new EmployeeDataResponce_v1
        //            {
        //                EmpId = e.EMPId,
        //                Name = e.Name,
        //                Description = e.Description,
        //                RoleName = allRoles.FirstOrDefault(r => r.ID == e.RoleId)?.RoleName,
        //                Roles = allRoles
        //                    .Where(r => r.ID == e.RoleId)
        //                    .Select(r => new EmployeeRoleInfo
        //                    {
        //                        RoleName = r.RoleName
        //                    }).ToList()
        //            }).ToList();
        //    }
        //    catch (Exception ex)
        //    {
        //        _logger.LogInformation("EmployeeInfo " + ex.Message);
        //    }

        //    return empinfo;
        //}



        public void AddCropData (CropMaster cropMaster)
        {

            _employeeDBContext.CropMaster.Add(cropMaster);
            _employeeDBContext.SaveChanges();

        }


        public List<CropMaster> GetCropData ()
        {
          return  _employeeDBContext.CropMaster.ToList();
        }

        public void AddProduct (ProductMaster productMaster)
        {

            _employeeDBContext.ProductMaster.Add(productMaster);
            _employeeDBContext.SaveChanges();
        }


        public CropMaster GetCropDataById(int Id)
        {
            return _employeeDBContext.CropMaster.FirstOrDefault(e => e.ID == Id);
            

        }


        public string GetCropDataDeleteByID(CropMaster cropMaster)
        {

            var Message =string.Empty;
            
            var Products = _employeeDBContext.ProductMaster.Where(p => p.CropId == cropMaster.ID).ToList();
            if (Products == null && Products.Count == 0)
            {
                foreach (var product in Products)
                {
                    _employeeDBContext.ProductMaster.Remove(product);
                    _employeeDBContext.SaveChanges();
                }
                Message = "Crop Deleted Successfully";
            }
            else
            {

                Message = "Unable To Delete due to Forgein Key RealtionShip";
                

            }
            return Message;

        }


        //public List<Crop_ProductDataResponce> GetCrop_ProductData()
        //{
        //    var cropProductData = _employeeDBContext.CropMaster
        //        .GroupJoin(
        //            _employeeDBContext.ProductMaster,
        //            crop => crop.ID,
        //            product => product.CropId,
        //            (crop, productGroup) => new Crop_ProductDataResponce
        //            {
        //                CropID = crop.ID,
        //                CropName = crop.CropName,
        //                productDataResponces = productGroup
        //                    .Select(product => new ProductDataResponce
        //                    {
        //                        ProductId = product.ID,
        //                        ProductName = product.ProductName,
        //                        CropId = product.CropId
        //                    }).ToList()
        //            })
        //        .ToList();

        //    return cropProductData;
        //}

        //public List<Crop_ProductDataResponce> GetCrop_ProductData()
        //{
        //    var crops = _employeeDBContext.CropMaster.ToList();
        //    var products = _employeeDBContext.ProductMaster.ToList();

        //    var result = crops.Select(crop => new Crop_ProductDataResponce
        //    {
        //        CropID = crop.ID,
        //        CropName = crop.CropName,
        //        productDataResponces = products
        //            .Where(p => p.CropId == crop.ID)
        //            .Select(p => new ProductDataResponce
        //            {
        //                ProductId = p.ID,
        //                ProductName = p.ProductName,
        //                CropId = p.CropId
        //            }).ToList()
        //    }).ToList();

        //    return result;
        //}

        //public List<Crop_ProductDataResponce> GetCrop_ProductData()
        //{
        //    var result = (from crop in _employeeDBContext.CropMaster
        //                  join product in _employeeDBContext.ProductMaster
        //                  on crop.ID equals product.CropId into productGroup
        //                  select new Crop_ProductDataResponce
        //                  {
        //                      CropID = crop.ID,
        //                      CropName = crop.CropName,
        //                      productDataResponces = productGroup.Select(p => new ProductDataResponce
        //                      {
        //                          ProductId = p.ID,
        //                          ProductName = p.ProductName,
        //                          CropId = p.CropId
        //                      }).ToList()
        //                  }).ToList();



        //    //var result = (from crop in _employeeDBContext.CropMaster
        //    //              join product in _employeeDBContext.ProductMaster
        //    //              on crop.ID equals product.CropId into productGroup
        //    //              from product in productGroup.DefaultIfEmpty() // Left Join
        //    //              group product by new { crop.ID, crop.CropName } into grouped
        //    //              select new Crop_ProductDataResponce
        //    //              {
        //    //                  CropID = grouped.Key.ID,
        //    //                  CropName = grouped.Key.CropName,
        //    //                  productDataResponces = grouped
        //    //                      .Where(p => p != null) // Handle crops with no products
        //    //                      .Select(p => new ProductDataResponce
        //    //                      {
        //    //                          ProductId = p.ID,
        //    //                          ProductName = p.ProductName,
        //    //                          CropId = p.CropId
        //    //                      }).ToList()
        //    //              }).ToList();


        //    return result;




        //}

        public List<SeasonDataResponce> GetCrop_ProductData()
        {
            var result = (from season in _employeeDBContext.Season_Master
                          join crop in _employeeDBContext.CropMaster
                          on season.Id equals crop.SeasonId into cropGroup
                          select new SeasonDataResponce
                          {
                              SeasonName = season.Name,
                              SeasonID = season.Id,
                              crop_ProductDataResponces = cropGroup.Select(crop => new Crop_ProductDataResponce
                              {
                                  CropID = crop.ID,
                                  CropName = crop.CropName,
                                  productDataResponces = _employeeDBContext.ProductMaster
                                      .Where(p => p.CropId == crop.ID)
                                      .Select(p => new ProductDataResponce
                                      {
                                          ProductId = p.ID,
                                          ProductName = p.ProductName,
                                          CropId = p.CropId
                                      }).ToList()
                              }).ToList()
                          }).ToList();



            //var result = (from crop in _employeeDBContext.CropMaster
            //              join product in _employeeDBContext.ProductMaster
            //              on crop.ID equals product.CropId into productGroup
            //              from product in productGroup.DefaultIfEmpty() // Left Join
            //              group product by new { crop.ID, crop.CropName } into grouped
            //              select new Crop_ProductDataResponce
            //              {
            //                  CropID = grouped.Key.ID,
            //                  CropName = grouped.Key.CropName,
            //                  productDataResponces = grouped
            //                      .Where(p => p != null) // Handle crops with no products
            //                      .Select(p => new ProductDataResponce
            //                      {
            //                          ProductId = p.ID,
            //                          ProductName = p.ProductName,
            //                          CropId = p.CropId
            //                      }).ToList()
            //              }).ToList();


            return result;




        }

        public void AddSeasonData(Season_Master season_Master)
        {
            _employeeDBContext.Season_Master.Add(season_Master);
            _employeeDBContext.SaveChanges();
        }

    }
}
