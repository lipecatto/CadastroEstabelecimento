namespace WebApplication1.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class FitCard1 : DbMigration
    {
        public override void Up()
        {
            AddColumn("dbo.Estabelecimento", "Telefones", c => c.String());
            DropColumn("dbo.Estabelecimento", "Telefone");
        }
        
        public override void Down()
        {
            AddColumn("dbo.Estabelecimento", "Telefone", c => c.String());
            DropColumn("dbo.Estabelecimento", "Telefones");
        }
    }
}
