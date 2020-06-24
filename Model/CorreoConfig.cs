using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Model
{
    using Helper;
    using System;
    using System.Collections.Generic;
    using System.ComponentModel;
    using System.ComponentModel.DataAnnotations;
    using System.ComponentModel.DataAnnotations.Schema;
    using System.Data.Entity;
    using System.Data.Entity.Spatial;
    using System.Data.Entity.Validation;
    using System.IO;
    using System.Linq;
    using System.Web;

    [Table("correoconfig")]
    class CorreoConfig
    {

        [Key]
        [DatabaseGenerated(DatabaseGeneratedOption.Identity)]
        public int idCorreo { get; set; }

        [Required]
        [DisplayName("Servidor")]
        [StringLength(60)]
        public string servidor { get; set; }

        [Required]
        [DisplayName("Usuario")]
        [StringLength(60)]
        public string usuari { get; set; }

        [Required]
        [DisplayName("Password")]
        [StringLength(60)]
        public string password { get; set; }

    }
}
