using System;
using FluentMigrator;

namespace CSharpCourse.Lecture13.Demo.FluentMigrator
{
    [Migration(1)]
    public class InitialMigration : Migration
    {
        public override void Up()
        {
            Create.Table(Constants.TableNames.Users)
                .WithColumn("id").AsInt32().Identity().PrimaryKey()
                .WithColumn("nickname").AsString(200)
                .WithColumn("phone").AsString(200)
                .WithColumn("avatar_url").AsString(200)
                .WithColumn("city").AsString(100);

            var createChatsRawSql = @$"create table {Constants.TableNames.Chats} (" +
                                    "id       bigserial primary key," +
                                    "name     varchar(500) not null," +
                                    "logo_url text);";
            Execute.Sql(createChatsRawSql);

            var createUsersChatsSql = @$"create table {Constants.TableNames.UsersChats} ( " +
                                      "user_id bigint," +
                                      "chat_id bigint," +
                                      $"constraint user_chats_fk foreign key (user_id) references {Constants.TableNames.Users} (id)," +
                                      $"constraint chats_users_fk foreign key (chat_id) references {Constants.TableNames.Chats} (id));";
            Execute.Sql(createUsersChatsSql);
            
            var createMessagesSql = @$"create table {Constants.TableNames.Messages} (" +
                                    "id          bigserial primary key," +
                                    "user_from   bigint not null references users (id)," +
                                    "user_to     bigint not null references users (id)," +
                                    "chat_id     bigint not null references chats (id)," +
                                    "text     text," +
                                    "create_date timestamptz default now()," +
                                    "is_read     bool        default false);";
            Execute.Sql(createMessagesSql);
        }

        public override void Down()
        {
            Delete.Table(Constants.TableNames.UsersChats);
            Delete.Table(Constants.TableNames.Chats);
            Delete.Table(Constants.TableNames.Users);
            Delete.Table(Constants.TableNames.Messages);
        }
    }
}