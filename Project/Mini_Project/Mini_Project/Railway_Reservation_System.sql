create database Railway_DB

use Railway_DB

create Table Customer(
CustomerId int primary key identity,
CustomerName varchar(50),
phone varchar(10),
Email varchar(80),
password varchar(30)
)

select * from Customer

drop table Customer;

  create table Trains
  (
   TrainNo int primary key,
   TrainName varchar(80),
   Source varchar(30),
   Destination Varchar(30),
   inActive bit
  )



create table Reservation
(
  BookingId int primary key Identity (1000,1),
  CustomerId int,
  TrainNo int,
  TrainName varchar(50),
  DateOfJourney date,
  Source varchar(30),
  Destination varchar(30),
  class varchar(20),
  BookingDate date,
  No_of_Passengers int,
  TotalCost float,
  foreign key (TrainNo) references Trains(TrainNo),
  foreign key (CustomerId) references Customer(CustomerId)
 )

 drop table Reservation

 select * from Reservation

create table Passenger (
    PassengerId int primary key identity (2000,1),
    BookingId int foreign key references Reservation(BookingId),
    NAme varchar(100),
    Phone varchar(15),
    AdharNumber varchar(20),
    Gender varchar(10),
    TrainNo int,
    TrainName varchar(100),
    TravelDate date,
	Status varchar(20),
	Berth varchar(10),
	Cost float
)

drop table Passenger



create table Cancellation
(
 CancellationID int primary key identity(3000,1),
 BookingId int foreign key references Reservation(BookingId),
 PassengerID int foreign key references Passenger(PassengerId),
 RefundAmount float,
 CancellationDate date
 )


 drop table Cancellation



 create table TrainClasses
 (
  TrainNo int foreign key references Trains(TrainNo),
  Class varchar(20),
  Available_Seats int,
  Cost_Per_Seat float
  )



insert into Trains (TrainNo, TrainName, Source, Destination)
values
(12727, 'Godavari Express', 'Visakhapatnam', 'Hyderabad'),
(12861, 'Link Daksin Express', 'Visakhapatnam', 'Raipur'),
(12711, 'Pinakini Express', 'Vijayawada', 'Chennai'),
(17488, 'Tirumala Express', 'Visakhapatnam', 'Tirupati'),
(18702,'Puri Tirupati Express','Visakhapatnam','Tirupati'),
(12718, 'Ratnachal Express', 'Vijayawada', 'Visakhapatnam'),
(12805, 'Janmabhoomi Express', 'Lingampalli', 'Visakhapatnam'),
(18519, 'Visakhapatnam - Lokmanya Tilak Express', 'Visakhapatnam', 'Mumbai'),
(17230, 'Sabari Express', 'Secunderabad', 'Thiruvananthapuram'),
(12739, 'Vishaka Express', 'Secunderabad', 'Visakhapatnam')

select * from Trains

drop table Trains
insert into TrainClasses 
values
(12727, 'Sleeper', 120, 450),
(12727, '2AC', 80, 1050),
(12727, '3AC', 80, 1750),
(12861, 'Sleeper', 100, 950),
(12861, '2AC', 80, 1450),
(12861, '3AC', 80, 2050),
(12711, 'Sleeper', 100, 500),
(12711, '2AC', 70, 1000),
(12711, 'Chair Car', 100, 600),
(17488,'Sleeper',150,450),
(17488, '2AC', 120, 950),
(17488, '3AC', 80, 1350),
(12718, 'AC Chair Car', 90, 700),
(12718, 'Sleeper', 100, 300),
(12805, 'Sleeper', 150, 350),
(12805, '2AC', 50, 650),
(12805, 'Second Sitting', 150, 250),
(18519, '2AC', 60, 1200),
(18519, 'Sleeper', 150, 700),
(17230, 'Sleeper', 130, 650),
(17230, '2AC', 80, 950),
(12739, 'Sleeper', 110, 500),
(12739, '2AC', 110, 700),
(18702,'Sleeper',100,650),
(18702,'2AC',80,900),
(18702,'3AC',60,1150)


select * from Customer
select * from Reservation
select * from Cancellation
select * from Passenger
select * from Trains
select * from TrainClasses
