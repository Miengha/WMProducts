if not exists(select * from sys.databases where name = 'WritersHaven')
begin
    create database WritersHaven
end