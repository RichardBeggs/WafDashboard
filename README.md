# Waf Dashboard
A dash board to barracuda display Waf log csv files  

## Introduction 
I have found that searching barracuda WAF logs is a very slow process and you rarely find what you need. I have created a solution that reads in the CSV files that can be exported from barracuda WAF.  I have then created a dashboard that reports on this data and makes it more readable.

## Solution 
There are 2 parts to the solution the first is importing the CSV files into an SQL Database.  The second part is the dashboard that displays the data to the user in a much easier way to consume.   

## Getting started 
In the **SqlScripts** folder there is a **Setup.sql** that will create the database and the tables required.  To run the import from visual studio right click on ErrorLogReader -> Debug -> Start New Instance. You can add as many csv files as you want they are appended to the records already there.  You will not over write the existing data in the table.
To run the Dashboard press F5 to launch the website.


