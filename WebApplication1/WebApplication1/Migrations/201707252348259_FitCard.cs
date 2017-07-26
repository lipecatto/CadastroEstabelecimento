namespace WebApplication1.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class FitCard : DbMigration
    {
        public override void Up()
        {
            CreateTable(
                "dbo.Categoria",
                c => new
                    {
                        Cod_Categoria = c.Int(nullable: false, identity: true),
                        Descricao = c.String(),
                        Flg_Estado = c.Int(nullable: false),
                        DataInclusao = c.DateTime(nullable: false),
                        DataAlteracao = c.DateTime(nullable: false),
                        DataExclusao = c.DateTime(nullable: false),
                    })
                .PrimaryKey(t => t.Cod_Categoria);
            
            CreateTable(
                "dbo.Estabelecimento",
                c => new
                    {
                        Cod_Estabelecimento = c.Int(nullable: false, identity: true),
                        Nome = c.String(nullable: false),
                        NomeFantasia = c.String(nullable: false),
                        Cnpj = c.String(),
                        Email = c.String(),
                        Telefone = c.String(),
                        Flg_Estado = c.Int(nullable: false),
                        DataInclusao = c.DateTime(),
                        DataAlteracao = c.DateTime(),
                        DataExclusao = c.DateTime(),
                        Categoria_Cod_Categoria = c.Int(),
                    })
                .PrimaryKey(t => t.Cod_Estabelecimento)
                .ForeignKey("dbo.Categoria", t => t.Categoria_Cod_Categoria)
                .Index(t => t.Categoria_Cod_Categoria);
            
        }
        
        public override void Down()
        {
            DropForeignKey("dbo.Estabelecimento", "Categoria_Cod_Categoria", "dbo.Categoria");
            DropIndex("dbo.Estabelecimento", new[] { "Categoria_Cod_Categoria" });
            DropTable("dbo.Estabelecimento");
            DropTable("dbo.Categoria");
        }
    }
}
