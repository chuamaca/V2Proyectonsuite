namespace Model.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class _3camposservcio : DbMigration
    {
        public override void Up()
        {
            AddColumn("dbo.Servicio", "fechaos", c => c.String());
            AddColumn("dbo.Servicio", "correoaprobador", c => c.String(maxLength: 60));
        }
        
        public override void Down()
        {
            DropColumn("dbo.Servicio", "correoaprobador");
            DropColumn("dbo.Servicio", "fechaos");
        }
    }
}
