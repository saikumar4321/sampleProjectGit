using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Text;
using System.Text.Json.Serialization;
using System.Threading.Tasks;

namespace EmployeeApp.Model.Request
{
    public class Season_Master
    {
        [Key, DatabaseGenerated(DatabaseGeneratedOption.Identity)]
        
        public int Id { get; set; }
        public string Name { get; set; } = string.Empty;


        [JsonIgnore]
        //public CropMaster? CropMaster { get; set; }
        public ICollection<CropMaster>? CropMaster { get; set; }



        //[JsonIgnore]
        //public ICollection<CropMaster> CropMaster { get; set; }

    }
}
