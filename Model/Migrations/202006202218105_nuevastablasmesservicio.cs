namespace Model.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class nuevastablasmesservicio : DbMigration
    {
        public override void Up()
        {
            CreateTable(
                "dbo.mesServicio",
                c => new
                    {
                        idServicioMes = c.Int(nullable: false, identity: true),
                        idServicio = c.Int(nullable: false),
                        idorden = c.Int(nullable: false),
                        meses = c.String(maxLength: 10),
                        estado = c.Int(nullable: false),
                    })
                .PrimaryKey(t => new { t.idServicioMes, t.idServicio, t.idorden })
                .ForeignKey("dbo.Servicio", t => t.idServicio)
                .ForeignKey("dbo.Orden", t => t.idorden)
                .Index(t => t.idServicio)
                .Index(t => t.idorden);
            
            CreateTable(
                "dbo.Servicio",
                c => new
                    {
                        idservicio = c.Int(nullable: false, identity: true),
                        os = c.String(maxLength: 60),
                        rq = c.String(maxLength: 60),
                        aprobador = c.String(maxLength: 60),
                        estadoos = c.Int(nullable: false),
                    })
                .PrimaryKey(t => t.idservicio);
            
        }
        
        public override void Down()
        {
            DropForeignKey("dbo.mesServicio", "idorden", "dbo.Orden");
            DropForeignKey("dbo.mesServicio", "idServicio", "dbo.Servicio");
            DropIndex("dbo.mesServicio", new[] { "idorden" });
            DropIndex("dbo.mesServicio", new[] { "idServicio" });
            DropTable("dbo.Servicio");
            DropTable("dbo.mesServicio");
        }
    }
}
