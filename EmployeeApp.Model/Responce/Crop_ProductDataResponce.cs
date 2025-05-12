using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace EmployeeApp.Model.Responce
{


    public class SeasonDataResponce
    {
        public string SeasonName { get; set; } = string.Empty;
        public int SeasonID { get; set; }
        public List<Crop_ProductDataResponce> crop_ProductDataResponces { get; set; } = new List<Crop_ProductDataResponce>();
    }



    public class Crop_ProductDataResponce
    {
        public string CropName { get; set; }
        public int CropID { get; set; }
        public List<ProductDataResponce> productDataResponces { get; set; } = new List<ProductDataResponce>();
        
    }

    public class ProductDataResponce
    {
        public int ProductId { get; set; }
        public string ProductName { get; set; } = string.Empty;
        public int CropId { get; set; }
        
    }
}
