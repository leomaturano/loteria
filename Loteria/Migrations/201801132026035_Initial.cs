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
                        Jogo1 = c.Int(nullable: false),
                        Jogo2 = c.Int(nullable: false),
                        Jogo3 = c.Int(nullable: false),
                        Jogo4 = c.Int(nullable: false),
                        Jogo5 = c.Int(nullable: false),
                        Jogo6 = c.Int(nullable: false),
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
                        Sorteio1 = c.Int(nullable: true),
                        Sorteio2 = c.Int(nullable: true),
                        Sorteio3 = c.Int(nullable: true),
                        Sorteio4 = c.Int(nullable: true),
                        Sorteio5 = c.Int(nullable: true),
                        Sorteio6 = c.Int(nullable: true),
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
