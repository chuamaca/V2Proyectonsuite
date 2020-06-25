CREATE proc [dbo].[SP_NSUITE_hardware_Select]
@idhardware int
as
select  hw.codigontb, hw.typedevice,  hw.seriehw, br.nmbrand ,ml.nmmodel, hw.partnumberhw, hwd.snbatery, hwd.sncharger,      pro.nmprocessor , pro.ghzprocessor,
 mry.mcapacity, stg.capacitystorage, 'WINDOWS 10/OFFICE' as lic , hw.nmequipo   from hardware hw inner join device dvc
on hw.iddevice=dvc.iddevice inner join brand br
on hw.idbrand=br.idbrand inner join model ml
on hw.idmodel=ml.idmodel inner join hardwaredetail hwd
on hw.iddetailhw=hwd.iddetailehw inner join statusdevice stdvc
on hw.idstatusdevice=stdvc.idstatusdevice inner join processor pro
on hwd.idprocessor=pro.idprocessor inner join memory mry
on hwd.idmemory=mry.idmemory inner join storage stg
on hwd.idstorage=stg.idstorage where hw.idhw=@idhardware