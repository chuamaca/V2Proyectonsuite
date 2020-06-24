namespace Model.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class columnafjecucionnfacturacion : DbMigration
    {
        public override void Up()
        {
            AddColumn("dbo.LiquidacionFacturacion", "fechaejecucion", c => c.DateTime(nullable: false));
        }
        
        public override void Down()
        {
            DropColumn("dbo.LiquidacionFacturacion", "fechaejecucion");
        }
    }
}
