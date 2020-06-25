namespace Model.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class InitialCreate2 : DbMigration
    {
        public override void Up()
        {
            AlterColumn("dbo.DetalleOrden", "valor", c => c.Single(nullable: false));
            AlterColumn("dbo.DetalleOrden", "IGV", c => c.Single(nullable: false));
            AlterColumn("dbo.DetalleOrden", "total", c => c.Single(nullable: false));
        }
        
        public override void Down()
        {
            AlterColumn("dbo.DetalleOrden", "total", c => c.Decimal(nullable: false, precision: 18, scale: 2));
            AlterColumn("dbo.DetalleOrden", "IGV", c => c.Decimal(nullable: false, precision: 18, scale: 2));
            AlterColumn("dbo.DetalleOrden", "valor", c => c.Decimal(nullable: false, precision: 18, scale: 2));
        }
    }
}
