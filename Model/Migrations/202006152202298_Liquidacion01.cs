namespace Model.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class Liquidacion01 : DbMigration
    {
        public override void Up()
        {
            AddColumn("dbo.Liquidacion", "IdentificadorGeneral", c => c.String(maxLength: 20));
            AddColumn("dbo.Liquidacion", "UsuarioEjecuto", c => c.String(maxLength: 20));
        }
        
        public override void Down()
        {
            DropColumn("dbo.Liquidacion", "UsuarioEjecuto");
            DropColumn("dbo.Liquidacion", "IdentificadorGeneral");
        }
    }
}
