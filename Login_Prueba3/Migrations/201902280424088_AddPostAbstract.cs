namespace Login_Prueba3.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class AddPostAbstract : DbMigration
    {
        public override void Up()
        {
            AddColumn("dbo.Cuentas", "Url", c => c.String());
            AlterColumn("dbo.Cuentas", "User", c => c.String(nullable: false));
            AlterColumn("dbo.Cuentas", "Password", c => c.String(nullable: false));
        }
        
        public override void Down()
        {
            AlterColumn("dbo.Cuentas", "Password", c => c.String());
            AlterColumn("dbo.Cuentas", "User", c => c.String());
            DropColumn("dbo.Cuentas", "Url");
        }
    }
}
