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
    public class CropMaster
    {
        [Key]
        [DatabaseGenerated(DatabaseGeneratedOption.Identity)]
        public int ID { get; set; }
        public string CropName { get; set; } = string.Empty;
        public int SeasonId { get; set; } // Foreign Key for Season_Master

        // Navigation: One Crop can have many Products
        [JsonIgnore]  // This avoids circular or unnecessary nesting during serialization
        public ICollection<ProductMaster> ProductMaster { get; set; } = new List<ProductMaster>();

        // Navigation: One Crop belongs to one Season
        //[JsonIgnore]
        //public Season_Master Season_Master { get; set; }  // Navigation


        [ForeignKey("SeasonId")]
        [JsonIgnore]
        public Season_Master? Season_Master { get; set; } // Navigation property for Season_Master


    }
}
