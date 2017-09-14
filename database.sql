CREATE DATABASE Passenger
use Passenger
CREATE TABLE Users(
id UNIQUEIDENTIFIER PRIMARY KEY  NOT NULL,
Email nvarchar(100) not null,
Password nvarchar(200) not null,
Salt nvarchar(100) not null,
UserName nvarchar(100) not null,
FullName nvarchar(100) ,
Role nvarchar(100) not null,
UpdateAt DateTime not null,
CreateAt DateTime not null)

Select* FROM Users