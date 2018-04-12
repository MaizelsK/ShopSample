create database shopSampleDb

create table customers(
id int identity not null,
firstName varchar(255) not null,
surName varchar(255) not null,
constraint PK_CUSTOMERS_ID primary key(id)
)

create table sellers(
id int identity not null,
firstName varchar(255) not null,
surName varchar(255) not null,
constraint PK_SELLERS_ID primary key(id)
)

create table orders(
id int identity not null,
idCustomer int not null,
idSeller int not null,
price money not null default 0,
orderDate date not null default getdate(),
constraint PK_ORDERS_ID primary key(id),
constraint FK_ORDERS_IDCUSTOMER foreign key(idCustomer)
	references customers(id),
constraint FK_ORDERS_IDSELLER foreign key(idSeller)
	references sellers(id),
constraint CH_ORDERS_PRICE check(price >= 0)
)

insert into customers
values ('Ivan','Ivanov'), ('Pavel','Petrov'),
		('Vladimir','Vladimirovich'), ('Michail','Medvedev')

insert into sellers
values ('Vasiliy','Vasiliev'), ('Grigoriy','Grishin'),
		('Konstanit','Vasiliev'), ('Alexandr','Bushkin')

insert into orders
values (1,1,500,'2018-04-12'), (2,2,1000,'2018-04-12'),
		(3,3,1500,'2018-04-12'), (4,4,5500,'2018-04-12')