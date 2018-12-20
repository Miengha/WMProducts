use WritersHaven
go

if exists(SELECT 1 FROM sys.procedures 
           WHERE object_id = OBJECT_ID(N'rsp_Universes_Get'))
begin
  drop procedure rsp_Universes_Get
end
go

create procedure rsp_Universes_Get
as
  select Id,
         [Name],
         [Description]
    from Universes
go

grant execute on rsp_Universes_Get to public
go