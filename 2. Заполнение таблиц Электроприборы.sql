use electrical_appliances_db;

-- заполнение таблицы [EA_type]

insert into [EA_type] 
values
('Микроволновая печь'),
('Миксер'),
('Мультиварка'),
('Электрогриль'),
('Электрочайник'),
('Соковыжималка'),
('Тостер'),
('Холодильник'),
('Электрическая плита'),
('Посудомоечная машина'),
('Стиральная машина'),
('Пылесос');

-- заполнение таблицы [Countries]
insert into [Countries]
values
('China'),
('South Korea'),
('Slovenia'),
('Italy'),
('Japan'),
('Germany'),
('Russia'),
('France'),
('Great Britain'),
('Sweden');

-- заполнение таблицы [Manufacturers]
insert into [Manufacturers]
values
('BBK',1),
('Daewoo',2),
('Gorenje',3),
('Hotpoint-Ariston',4),
('Supra',5),
('Bosch',6),
('Braun',6),
('Kitfort',7),
('Samsung', 2),
('Polaris',7),
('Tefal', 8),
('Scarlett', 9),
('Redmond',7), 
('Vitek',7),
('Bork', 6),
('LG', 2),
('Hansa',6),
('Electrolux',10);


-- заполнение таблицы [Defective subtable]
insert into [Defective subtable]
values
('+'),
('-');

-- заполнение таблицы [Product list]

-- заполнение через цикл, генерируем ассортимент товара и журнал его продаж

declare @iterator int, @top int;
set @iterator=0;
set @top=100;

while @iterator!=@top
begin
insert into [Product list]
values 
(FLOOR(1+RAND()*12), FLOOR(1+RAND()*18), FLOOR(1000000+RAND()*9000000), (GETDATE()-FLOOR(100+RAND()*266)), ROUND((2+RAND()*19),2), FLOOR(1+RAND()*2));
set @iterator=@iterator+1;
end

-- заполнение таблицы [Sales log] 

declare @iterator_1 int, @top_1 int, @low int, @hight int;
set @iterator_1=0;
set @top_1=1000;
set @low=(select MIN([ID]) from [Product list]);
set @hight=(select MAX([ID]) from [Product list]);

while @iterator_1!=@top_1
begin
insert into [Sales log] 
values
(FLOOR(@low+RAND()*(@hight-@low+1)), GETDATE()-FLOOR(RAND()*100), ROUND(1000+RAND()*10000,2));
set @iterator_1=@iterator_1+1;
end


