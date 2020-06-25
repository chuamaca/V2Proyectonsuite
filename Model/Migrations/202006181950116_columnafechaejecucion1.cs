namespace Model.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class columnafechaejecucion1 : DbMigration
    {
        public override void Up()
        {
            AddColumn("dbo.Liquidacion", "fechaejecucion", c => c.DateTime(nullable: false));
            DropColumn("dbo.Liquidacion", "datetime");
        }
        
        public override void Down()
        {
            AddColumn("dbo.Liquidacion", "datetime", c => c.String());
            DropColumn("dbo.Liquidacion", "fechaejecucion");
        }
    }
}
