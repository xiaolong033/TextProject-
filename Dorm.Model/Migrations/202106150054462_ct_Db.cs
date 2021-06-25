namespace Dorm.Model.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class ct_Db : DbMigration
    {
        public override void Up()
        {
            CreateTable(
                "dbo.Admin",
                c => new
                    {
                        Id = c.Int(nullable: false, identity: true),
                        LoginName = c.String(),
                        LoginPwd = c.String(),
                        IsRemoved = c.Boolean(nullable: false),
                        CreateTime = c.DateTime(nullable: false),
                    })
                .PrimaryKey(t => t.Id);
            
            CreateTable(
                "dbo.MyDorm",
                c => new
                    {
                        Id = c.Int(nullable: false, identity: true),
                        NumberNO = c.Int(nullable: false),
                        Count = c.Int(nullable: false),
                        IsRemoved = c.Boolean(nullable: false),
                        CreateTime = c.DateTime(nullable: false),
                    })
                .PrimaryKey(t => t.Id);
            
            CreateTable(
                "dbo.Student",
                c => new
                    {
                        Id = c.Int(nullable: false, identity: true),
                        Name = c.String(),
                        Phone = c.String(),
                        DromNo = c.Int(nullable: false),
                        IsRemoved = c.Boolean(nullable: false),
                        CreateTime = c.DateTime(nullable: false),
                    })
                .PrimaryKey(t => t.Id)
                .ForeignKey("dbo.MyDorm", t => t.DromNo)
                .Index(t => t.DromNo);
            
        }
        
        public override void Down()
        {
            DropForeignKey("dbo.Student", "DromNo", "dbo.MyDorm");
            DropIndex("dbo.Student", new[] { "DromNo" });
            DropTable("dbo.Student");
            DropTable("dbo.MyDorm");
            DropTable("dbo.Admin");
        }
    }
}
