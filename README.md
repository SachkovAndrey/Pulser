# Pulser

## Application description

The Pulser app allows you to monitor the availability of sites.
The application works with the local LiteD database,
the database is created the first time the application is launched.
When the database is initialized, it creates entries about the sites to be monitored. 

## Configuration

Set the connection string (e.g.  <add key="ConnectionString" value="D:\Temp\MyData.db" />)
in Pulser.ConsoleClient.App.Config 
AppSettings - ConnectionString

For switch between pulse emulation and common implementation
Set the "UsePulseEmulator" true or false (true by default) in 
Pulser.ConsoleClient.App.Config 
AppSettings - UsePulseEmulator

Set the schedule interval in seconds (10 by default) for background loading and monitoring Sites in 
Pulser.ConsoleClient.App.Config 
AppSettings - ObservableScheduleInterval

## Projects Description

### Pulser.Db

This project implements the faсade logic over the LiteDb database access.
This project contains IDbContext for access to DB and IDbInitializator for first time
DB initialize and create hard-code records

### Pulser.Db.Tests

This project contains unit tests for Pulser.Db DbContext

### Pulser.Common

This project contains a declaration of the interfaces of the mappers, configuration
as well as common entities

### Pulser.Core

This project is entities that are used in the application

### Pulser.DAL

This project implements data access layer, contains repositories for Pulser.Db entities.
Also this project implements mapping logic from Pulser.Db.Entities to Pulser.Core

### Pulser.DAL.Tests

This project contains unit tests for Pulser.DAL.Mappers and Repositories

### Pulser.Services

This project implements an intermediate layer of abstraction between the Pulser.ConsoleClient and Pulser.DAL.
Also this project contains PulseRunner which responsible of the site monitoring flow.

### Pulser.PulseService

This project contains couple of implementations of site monitoring logic (PulseService and PulseServiceEmulator)

### Pulser.ConsoleClient

This project is a client application for the end user.
Program.Main initializes the database, loads data about sites and
conducts the first monitoring, after that monitoring is reactive, 
according to the interval specified in the configuration file               


