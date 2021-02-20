SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO

CREATE TRIGGER facturiTRG
   ON  ACCOUNTING.FACTURI 
   INSTEAD OF INSERT
AS 
BEGIN
	SET NOCOUNT ON;

	declare @sid int;
	declare @iid int;

	select @iid = IdLocatie from inserted
	
	if not exists (select top 1 1 from ACCOUNTING.FACTURI where IdLocatie = @iid)
		set @sid=1;
	else
		set @sid = (select max(IdFactura)+1 from ACCOUNTING.FACTURI where IdLocatie=@iid)

    insert into ACCOUNTING.FACTURI(IdFactura,IdLocatie,NumarFactura,DataFactura,NumeClient)
	select @sid, @iid,NumarFactura,DataFactura,NumeClient from inserted

END
GO
