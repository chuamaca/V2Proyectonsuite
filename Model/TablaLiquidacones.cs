

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

    [Table("TablaLiquidacones")]
    public class TablaLiquidacones
    {

        [Key]
        [DatabaseGenerated(DatabaseGeneratedOption.Identity)]
        public int idLiquidaciones { get; set; }

        [DisplayName("Proceso")]
        [StringLength(30)]
        public string procesos { get; set; }

        
        [DisplayName("Estado")]
        [StringLength(30)]
        public string estado { get; set; }

        
        [DisplayName("Contrato Interno")]
        [StringLength(60)]
        public string contratointerno { get; set; }

        
        [DisplayName("Refacturable")]
        [StringLength(10)]
        public string refacturable { get; set; }

       
        [DisplayName("Mes")]
        [StringLength(30)]
        public string mes { get; set; }

        
        [DisplayName("Referencia")]
        [StringLength(23)]
        public string referencia { get; set; }

        
        [DisplayName("Doc")]
        [StringLength(30)]
        public string doc { get; set; }

       
        [DisplayName("Numero de documento")]
        [StringLength(30)]
        public string numerodocumento { get; set; }

       
        [DisplayName("Ciclo de facturacion")]
        [StringLength(60)]
        public string c_fact { get; set; }

      
        [DisplayName("Fecha Emision")]
        [DisplayFormat(ApplyFormatInEditMode = true, DataFormatString = "{0:dd/mm/yy}")]
        public string fechaemision { get; set; }

       
        [DisplayName("Fecha Inicio")]
        [DisplayFormat(ApplyFormatInEditMode = true, DataFormatString = "{0:dd/mm/yy}")]
        public string fechainicio { get; set; }

        
        [DisplayName("Fecha Fin")]
        [DisplayFormat(ApplyFormatInEditMode = true, DataFormatString = "{0:dd/mm/yy}")]
        public string fechafin { get; set; }

        
        [DisplayName("Credito")]
        [StringLength(20)]
        public string credito { get; set; }

     
        [DisplayName("R.U.C Empresa")]
        [StringLength(30)]
        public string rucempresa { get; set; }

        
        [DisplayName("Empresa")]
        [StringLength(180)]
        public string empresa { get; set; }

        
        [DisplayName("Responsable")]
        [StringLength(100)]
        public string responsable { get; set; }

       
        [DisplayName("Sucursal")]
        [StringLength(60)]
        public string sucursal { get; set; }

      
        [DisplayName("R.U.C Cliente")]
        [StringLength(30)]
        public string ruccliente { get; set; }

        
        [DisplayName("Cliente")]
        [StringLength(180)]
        public string cliente { get; set; }

        
        [DisplayName("Usuario Final")]
        [StringLength(180)]
        public string usuariofinal { get; set; }

        
        [DisplayName("Tipo Usuario")]
        [StringLength(30)]
        public string tipousuario { get; set; }

      
        [DisplayName("Orden Servicio")]
        [StringLength(60)]
        public string ordenservicio { get; set; }

       
        [DisplayName("Fecha Orden Servicio")]
        [DisplayFormat(ApplyFormatInEditMode = true, DataFormatString = "{0:dd/mm/yy}")]
        public string fechaordenservicio { get; set; }

       
        [DisplayName("RQ Cliente")]
        [StringLength(60)]
        public string rqcliente { get; set; }

      
        [DisplayName("Contacto")]
        [StringLength(60)]
        public string contrato { get; set; }

     
        [DisplayName("Guia Remision")]
        [StringLength(60)]
        public string guiaremision { get; set; }

       
        [DisplayName("Tipo")]
        [StringLength(30)]
        public string tipo { get; set; }

       
        [DisplayName("Codigo Equipo")]
        [StringLength(60)]
        public string codigoequipo { get; set; }

       
        [DisplayName("Tipo Equipo")]
        [StringLength(30)]
        public string tipoequipo { get; set; }

        
        [DisplayName("Serie")]
        [StringLength(60)]
        public string serie { get; set; }

       
        [DisplayName("Marca")]
        [StringLength(60)]
        public string marca { get; set; }

      
        [DisplayName("Modelo")]
        [StringLength(60)]
        public string modelo { get; set; }

      
        [DisplayName("Part Number")]
        [StringLength(60)]
        public string parnumber { get; set; }

        
        [DisplayName("Bateria")]
        [StringLength(60)]
        public string bateria { get; set; }

       
        [DisplayName("Cargador")]
        [StringLength(60)]
        public string cargador { get; set; }

    
        [DisplayName("Procesador")]
        [StringLength(60)]
        public string procesador { get; set; }

    
        [DisplayName("Velocidad")]
        [StringLength(60)]
        public string velocidad { get; set; }

       
        [DisplayName("Ram")]
        [StringLength(60)]
        public string ram { get; set; }

       
        [DisplayName("Disco")]
        [StringLength(60)]
        public string disco { get; set; }

     
        [DisplayName("Licencia")]
        [StringLength(60)]
        public string licencia { get; set; }

      
        [DisplayName("Nombre Equipo")]
        [StringLength(60)]
        public string nombreequipo { get; set; }

       
        [DisplayName("Usuario Office")]
        [StringLength(60)]
        public string usuariooficce { get; set; }

      
        [DisplayName("Cable Seguridad")]
        [StringLength(80)]
        public string cableseguridad { get; set; }

     
        [DisplayName("Mouse")]
        [StringLength(60)]
        public string mouse { get; set; }

      
        [DisplayName("Maletin")]
        [StringLength(60)]
        public string maletin { get; set; }

   
        [DisplayName("Software Adicional")]
        [StringLength(200)]
        public string softwareadicional { get; set; }

      
        [DisplayName("Accesorios")]
        [StringLength(200)]
        public string accesorios { get; set; }

       
        [DisplayName("Observaciones")]
        [StringLength(150)]
        public string observaciones { get; set; }

        
        [DisplayName("Moneda")]
        [StringLength(60)]
        public string moneda { get; set; }


       
        [DisplayName("Valor")]
        public decimal valor { get; set; }

       
        [DisplayName("Igv")]
        public decimal igv { get; set; }

       
        [DisplayName("Total")]
        public decimal total { get; set; }
    }
}
