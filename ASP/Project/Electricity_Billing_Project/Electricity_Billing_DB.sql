create database Electricity_DB

use Electricity_DB


CREATE TABLE ElectricityBill (
    consumer_number VARCHAR(20) PRIMARY KEY,
    consumer_name VARCHAR(50),
    units_consumed INT,
    bill_amount FLOAT
);

INSERT INTO ElectricityBill (consumer_number, consumer_name, units_consumed, bill_amount)
VALUES ('EB12345', 'Test User', 250, 225.0);

alter table ElectricityBill add Date datetime;

update ElectricityBill set Date='2025-08-16 12:30:00' where consumer_number='EB30136'

select * from ElectricityBill

