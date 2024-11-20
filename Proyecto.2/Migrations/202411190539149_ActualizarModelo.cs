namespace Proyecto._2.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class ActualizarModelo : DbMigration
    {
        public override void Up()
        {
            CreateTable(
                "dbo.HistorialCalculos",
                c => new
                    {
                        Id = c.Int(nullable: false, identity: true),
                        Operacion = c.String(nullable: false, maxLength: 50),
                        Resultado = c.Double(nullable: false),
                        FechaRegistro = c.DateTime(nullable: false, storeType: "date"),
                        HoraRegistro = c.Time(nullable: false, precision: 0),
                    })
                .PrimaryKey(t => t.Id);
            
            CreateTable(
                "dbo.sysdiagrams",
                c => new
                    {
                        diagram_id = c.Int(nullable: false, identity: true),
                        name = c.String(nullable: false, maxLength: 128),
                        principal_id = c.Int(nullable: false),
                        version = c.Int(),
                        definition = c.Binary(),
                    })
                .PrimaryKey(t => t.diagram_id);
            
        }
        
        public override void Down()
        {
            DropTable("dbo.sysdiagrams");
            DropTable("dbo.HistorialCalculos");
        }
    }
}
