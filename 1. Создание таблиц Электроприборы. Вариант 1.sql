create database electrical_appliances_db;
use electrical_appliances_db;

create table [EA_type] 
([ID] int identity(1,1) primary key, [Name] nvarchar(100) not null);

create table [Countries]
([ID] int identity(1,1) primary key, [Name] nvarchar(100) not null);

create table [Manufacturers]
([ID] int identity(1,1) primary key, [Name] nvarchar(1000) not null, [Country ID] int not null foreign key references [Countries]([ID]));

create table [Defective subtable]
([ID] int identity(1,1) primary key, [Defective status] char not null);

create table [Product list]
([ID] int identity(1,1) primary key, [Type_ID] int foreign key references [EA_type]([ID]) not null, 
[Manufacturers_ID] int foreign key references [Manufacturers]([ID]) not null, [Product Code] int not null, [Date of manufacture] date not null,
[Mass] float not null, [Defective status ID] int foreign key references [Defective subtable]([ID]) not null);

create table [Sales log]
([ID] int identity(1,1) primary key, [Product_ID] int foreign key references [Product list]([ID]) not null, [Date of sale] date not null, [Price] money not null);

 