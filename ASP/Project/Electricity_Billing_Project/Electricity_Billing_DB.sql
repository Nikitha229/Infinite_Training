create database Electricity_DB

use Electricity_DB


create table ElectricityBill (
    consumer_number varchar(20) primary key,
    consumer_name varchar(50),
    units_consumed int,
    bill_amount float
);
insert into ElectricityBill (consumer_number, consumer_name, units_consumed, bill_amount)
values ('EB12345', 'Test User', 250, 225.0);

alter table ElectricityBill add Date datetime;

update ElectricityBill set Date='2025-08-16 12:30:00' where consumer_number='EB30136'

select * from ElectricityBill

