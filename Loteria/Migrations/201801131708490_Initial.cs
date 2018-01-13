namespace Loteria.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class Initial : DbMigration
    {
        public override void Up()
        {
            CreateTable(
                "dbo.Apostas",
                c => new
                    {
                        Id = c.Int(nullable: false, identity: true),
                        DataHora = c.DateTime(nullable: false),
                        Numeros_Jogo1 = c.Int(nullable: false),
                        Numeros_Jogo2 = c.Int(nullable: false),
                        Numeros_Jogo3 = c.Int(nullable: false),
                        Numeros_Jogo4 = c.Int(nullable: false),
                        Numeros_Jogo5 = c.Int(nullable: false),
                        Numeros_Jogo6 = c.Int(nullable: false),
                        ConcursoID = c.Int(nullable: false),
                    })
                .PrimaryKey(t => t.Id)
                .ForeignKey("dbo.Concursoes", t => t.ConcursoID, cascadeDelete: true)
                .Index(t => t.ConcursoID);
            
            CreateTable(
                "dbo.Concursoes",
                c => new
                    {
                        Id = c.Int(nullable: false, identity: true),
                        Numeros_Jogo1 = c.Int(nullable: false),
                        Numeros_Jogo2 = c.Int(nullable: false),
                        Numeros_Jogo3 = c.Int(nullable: false),
                        Numeros_Jogo4 = c.Int(nullable: false),
                        Numeros_Jogo5 = c.Int(nullable: false),
                        Numeros_Jogo6 = c.Int(nullable: false),
                    })
                .PrimaryKey(t => t.Id);
            
        }
        
        public override void Down()
        {
            DropForeignKey("dbo.Apostas", "ConcursoID", "dbo.Concursoes");
            DropIndex("dbo.Apostas", new[] { "ConcursoID" });
            DropTable("dbo.Concursoes");
            DropTable("dbo.Apostas");
        }
    }
}
