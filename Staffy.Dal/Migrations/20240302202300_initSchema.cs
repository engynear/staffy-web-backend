using FluentMigrator;

namespace Staffy.Dal.Migrations;

[Migration(20240302202300, TransactionBehavior.None)]
public class InitSchema : Migration
{
    public override void Up()
    {
        Create.Table("teams")
            .WithColumn("id").AsInt64().PrimaryKey("teams_pk").Identity()
            .WithColumn("name").AsString().NotNullable()
            .WithColumn("description").AsString().Nullable()
            .WithColumn("created_at").AsDateTimeOffset().NotNullable()
            .WithColumn("image_url").AsString().Nullable();

        Create.Table("employees")
            .WithColumn("id").AsInt64().PrimaryKey("employees_pk").Identity()
            .WithColumn("name").AsString().NotNullable()
            .WithColumn("avatar_url").AsString().Nullable();
        
        Create.Table("team_employees")
            .WithColumn("team_id").AsInt64().NotNullable()
            .WithColumn("employee_id").AsInt64().NotNullable()
            .WithColumn("joined_at").AsDateTimeOffset().NotNullable();
        
        Create.Table("team_deep_links")
            .WithColumn("deep_link").AsString().PrimaryKey("deep_link_pk")
            .WithColumn("team_id").AsInt64().NotNullable();

        Create.Table("thank_you_cards_settings")
            .WithColumn("enabled").AsBoolean().NotNullable();

        Create.Table("thank_you_cards")
            .WithColumn("id").AsInt64().PrimaryKey("thank_you_cards_pk").Identity()
            .WithColumn("sender_id").AsInt64().NotNullable()
            .WithColumn("receiver_id").AsInt64().NotNullable()
            .WithColumn("message").AsString().NotNullable();
    }

    public override void Down()
    {
        Delete.Table("teams").IfExists();
        Delete.Table("employees").IfExists();
        Delete.Table("team_employees").IfExists();
    }
}