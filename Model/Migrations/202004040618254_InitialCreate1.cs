namespace Model.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class InitialCreate1 : DbMigration
    {
        public override void Up()
        {
            AddColumn("dbo.Liquidacion", "Identificador", c => c.String(maxLength: 20));
            AddColumn("dbo.LiquidacionFacturacion", "Identificador", c => c.String(maxLength: 20));
        }
        
        public override void Down()
        {
            DropColumn("dbo.LiquidacionFacturacion", "Identificador");
            DropColumn("dbo.Liquidacion", "Identificador");
        }
    }
}
