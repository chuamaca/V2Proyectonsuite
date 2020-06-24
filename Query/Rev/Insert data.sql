INSERT [dbo].[Empresa] ( [nmempresa], [rucempresa], [dirempresa], [correoempresa], [telefonoempresa], [logoempresa], [obsempresa], [estadoempresa]) VALUES ( N'NETCORPORATE S.A.C.', N'20555123885', N'AVENIDA NICOLAS ARRIOLA 314', N'-', N'-', NULL, NULL, 1)
INSERT [dbo].[Empresa] ( [nmempresa], [rucempresa], [dirempresa], [correoempresa], [telefonoempresa], [logoempresa], [obsempresa], [estadoempresa]) VALUES ( N'ADECCO CONSULTING S.A.', N'20503980216', N'Cal. Amador Merino Reyna Nro. 285 Dpto. 301 (Altura Cdra 4 Javier Prado Este)', N'-', N'-', NULL, NULL, 1)



INSERT [dbo].[Cliente] ( [nmcliente], [ruccliente], [dircliente], [correocliente], [telefonocliente], [logocliente], [obscliente], [estadocliente], [empresa_id]) VALUES ( N'GLORIA S.A.', N'20100190797', N'Av. Republica de Panama Nro. 2461', N'-', N'-', NULL, NULL, 1, 2)
INSERT [dbo].[Cliente] ( [nmcliente], [ruccliente], [dircliente], [correocliente], [telefonocliente], [logocliente], [obscliente], [estadocliente], [empresa_id]) VALUES ( N'NETCLUSTER S.A.', N'20555123885', N'AVENIDA NICOLAS ARRIOLA 314', N'-', N'-', NULL, NULL, 1, 1)
INSERT [dbo].[Cliente] ( [nmcliente], [ruccliente], [dircliente], [correocliente], [telefonocliente], [logocliente], [obscliente], [estadocliente], [empresa_id]) VALUES ( N'COMPAÑIA PERUANA DE MEDIOS DE PAGO S.A.C VISANET', N'20341198217', N'Av. Jose Pardo Nro. 831', N'-', N'-', NULL, NULL, 1, 2)


INSERT [dbo].[Sucursal] ( [nmsucursal], [codigosuc], [direccionsuc], [telefonosuc], [otroscu], [observacionsuc], [estadosuc], [empresa_id]) VALUES ( N'CASA CENTRAL', N'28 - CASA CENTRAL', N'-', N'-', N'-', NULL, 1, 2)
INSERT [dbo].[Sucursal] ( [nmsucursal], [codigosuc], [direccionsuc], [telefonosuc], [otroscu], [observacionsuc], [estadosuc], [empresa_id]) VALUES ( N'TRIGAL', N'30 - TRIGAL', N'-', N'-', N'-', NULL, 1, 2)


INSERT [dbo].[Usuario] ([idusuario], [nombre], [correo], [clave], [telefono], [razonsocial], [foto], [activo]) VALUES (2, N'Admin', N'admin', N'21232f297a57a5a743894a0e4a801fc3', N'admin', N'NETCORPORATE S.A.C.', N'20191017213039.jpg', 1)


