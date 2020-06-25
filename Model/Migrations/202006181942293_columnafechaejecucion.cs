namespace Model.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class columnafechaejecucion : DbMigration
    {
        public override void Up()
        {
            AddColumn("dbo.Liquidacion", "fechaejecucion", c => c.String());
            AddColumn("dbo.LiquidacionFacturacion", "IdentificadorGeneral", c => c.String(maxLength: 20));
            AddColumn("dbo.LiquidacionFacturacion", "UsuarioEjecuto", c => c.String(maxLength: 100));
        }
        
        public override void Down()
        {
            DropColumn("dbo.LiquidacionFacturacion", "UsuarioEjecuto");
            DropColumn("dbo.LiquidacionFacturacion", "IdentificadorGeneral");
            DropColumn("dbo.Liquidacion", "fechaejecucion");
        }
    }
}
