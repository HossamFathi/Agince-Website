namespace RoleProject.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class mymig : DbMigration
    {
        public override void Up()
        {
            DropForeignKey("dbo.Addresses", "agince_id", "dbo.Aginces");
            DropForeignKey("dbo.phone_Number_Agince", "Agince_Id", "dbo.Aginces");
            DropForeignKey("dbo.Car_propertiesCar", "Car_properties_proprity_Name", "dbo.Car_properties");
            DropIndex("dbo.Addresses", new[] { "id" });
            DropIndex("dbo.Addresses", new[] { "agince_id" });
            DropIndex("dbo.phone_Number_Agince", new[] { "id" });
            DropIndex("dbo.phone_Number_Agince", new[] { "Agince_Id" });
            DropIndex("dbo.Car_propertiesCar", new[] { "Car_properties_proprity_Name" });
            RenameColumn(table: "dbo.Car_propertiesCar", name: "Car_properties_proprity_Name", newName: "Car_properties_id");
            DropPrimaryKey("dbo.Car_properties");
            DropPrimaryKey("dbo.Car_propertiesCar");
            AddColumn("dbo.Car_properties", "id", c => c.Int(nullable: false, identity: true));
            AlterColumn("dbo.Car_properties", "proprity_Name", c => c.String(nullable: false));
            AlterColumn("dbo.Car_propertiesCar", "Car_properties_id", c => c.Int(nullable: false));
            AddPrimaryKey("dbo.Car_properties", "id");
            AddPrimaryKey("dbo.Car_propertiesCar", new[] { "Car_properties_id", "Car_Car_no" });
            CreateIndex("dbo.Car_propertiesCar", "Car_properties_id");
            AddForeignKey("dbo.Car_propertiesCar", "Car_properties_id", "dbo.Car_properties", "id", cascadeDelete: true);
            DropTable("dbo.Addresses");
            DropTable("dbo.phone_Number_Agince");
        }
        
        public override void Down()
        {
            CreateTable(
                "dbo.phone_Number_Agince",
                c => new
                    {
                        id = c.Int(nullable: false, identity: true),
                        phone_number = c.String(nullable: false, maxLength: 128),
                        Agince_Id = c.Int(nullable: false),
                    })
                .PrimaryKey(t => new { t.id, t.phone_number });
            
            CreateTable(
                "dbo.Addresses",
                c => new
                    {
                        id = c.Int(nullable: false, identity: true),
                        country = c.String(nullable: false),
                        agince_id = c.Int(nullable: false),
                    })
                .PrimaryKey(t => t.id);
            
            DropForeignKey("dbo.Car_propertiesCar", "Car_properties_id", "dbo.Car_properties");
            DropIndex("dbo.Car_propertiesCar", new[] { "Car_properties_id" });
            DropPrimaryKey("dbo.Car_propertiesCar");
            DropPrimaryKey("dbo.Car_properties");
            AlterColumn("dbo.Car_propertiesCar", "Car_properties_id", c => c.String(nullable: false, maxLength: 128));
            AlterColumn("dbo.Car_properties", "proprity_Name", c => c.String(nullable: false, maxLength: 128));
            DropColumn("dbo.Car_properties", "id");
            AddPrimaryKey("dbo.Car_propertiesCar", new[] { "Car_properties_proprity_Name", "Car_Car_no" });
            AddPrimaryKey("dbo.Car_properties", "proprity_Name");
            RenameColumn(table: "dbo.Car_propertiesCar", name: "Car_properties_id", newName: "Car_properties_proprity_Name");
            CreateIndex("dbo.Car_propertiesCar", "Car_properties_proprity_Name");
            CreateIndex("dbo.phone_Number_Agince", "Agince_Id");
            CreateIndex("dbo.phone_Number_Agince", "id", unique: true);
            CreateIndex("dbo.Addresses", "agince_id");
            CreateIndex("dbo.Addresses", "id", unique: true);
            AddForeignKey("dbo.Car_propertiesCar", "Car_properties_proprity_Name", "dbo.Car_properties", "proprity_Name", cascadeDelete: true);
            AddForeignKey("dbo.phone_Number_Agince", "Agince_Id", "dbo.Aginces", "ID", cascadeDelete: true);
            AddForeignKey("dbo.Addresses", "agince_id", "dbo.Aginces", "ID", cascadeDelete: true);
        }
    }
}
