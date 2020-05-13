echo off

rem batch file to run a script to create a db
rem 9/05/2019

sqlcmd -S localhost -E -i ChurchDB.sql
rem sqlcmd -S localhost\mssqlserver -E -i ChurchDB.sql
rem sqlcmd -S localhost\sqlexpress -E -i ChurchDB.sql

ECHO .
ECHO if no error messages appear when DB was created
PAUSE