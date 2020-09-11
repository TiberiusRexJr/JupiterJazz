use ldb;
create table UserProfilePictures
([Id] int primary key not null identity(1,1),[OwnerId] int foreign key references dbo.WinningAtWalmart_Workers (Id) on delete cascade,
[FileName] varchar(50),[ContentType] varchar(50),[Picture]varbinary(max)
)