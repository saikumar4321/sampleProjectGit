using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Text.Json.Serialization;

namespace EmployeeApp.Model.Request
{
    public class ProductMaster
    {
        [Key, DatabaseGenerated(DatabaseGeneratedOption.Identity)]
        public int ID { get; set; }
        public string ProductName { get; set; } = string.Empty;


        // Foreign Key
        
        public int CropId { get; set; }

        [ForeignKey("CropId")]
        [JsonIgnore]
        public CropMaster? CropMaster { get; set; }

    }
}
