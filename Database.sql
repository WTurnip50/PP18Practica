USE [PP18]
GO
/****** Object:  Table [dbo].[Categoria]    Script Date: 20/05/2023 08:13:45 p. m. ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[Categoria](
	[idCategoria] [int] IDENTITY(1,1) NOT NULL,
	[nombre] [nvarchar](50) NOT NULL,
	[activo] [bit] NOT NULL
) ON [PRIMARY]
GO
/****** Object:  Table [dbo].[Marca]    Script Date: 20/05/2023 08:13:45 p. m. ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[Marca](
	[idMarca] [int] IDENTITY(1,1) NOT NULL,
	[nombre] [nvarchar](50) NOT NULL,
	[activo] [bit] NOT NULL
) ON [PRIMARY]
GO
/****** Object:  Table [dbo].[Producto]    Script Date: 20/05/2023 08:13:45 p. m. ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[Producto](
	[idProducto] [int] IDENTITY(1,1) NOT NULL,
	[descripcion] [nvarchar](100) NOT NULL,
	[idCategoria] [int] NOT NULL,
	[idMarca] [int] NOT NULL,
	[precioUnitario] [decimal](18, 0) NOT NULL,
	[stock] [int] NOT NULL,
	[codigo] [nvarchar](20) NOT NULL,
	[activo] [bit] NOT NULL
) ON [PRIMARY]
GO
/****** Object:  StoredProcedure [dbo].[Categoria_GetAll]    Script Date: 20/05/2023 08:13:45 p. m. ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
create procedure [dbo].[Categoria_GetAll]
as 

begin
select * from Categoria where activo = 1
end
GO
/****** Object:  StoredProcedure [dbo].[Categoria_GetByID]    Script Date: 20/05/2023 08:13:45 p. m. ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
create procedure [dbo].[Categoria_GetByID]
(
	@idCategoria int
)
as 

begin
select * from Categoria where idCategoria = @idCategoria
end
GO
/****** Object:  StoredProcedure [dbo].[Marca_GetAll]    Script Date: 20/05/2023 08:13:45 p. m. ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
create procedure [dbo].[Marca_GetAll]
as 

begin
select * from Marca where activo = 1
end
GO
/****** Object:  StoredProcedure [dbo].[Marca_GetByID]    Script Date: 20/05/2023 08:13:45 p. m. ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
create procedure [dbo].[Marca_GetByID]
(
	@idMarca int
)
as 

begin
select * from Marca where idMarca = @idMarca
end
GO
/****** Object:  StoredProcedure [dbo].[Producto_Add]    Script Date: 20/05/2023 08:13:45 p. m. ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
create procedure [dbo].[Producto_Add]
(
	@descripcion nvarchar(100),
	@idCategoria int,
	@idMarca int,
	@precioUnitario decimal(18,0),
	@stock int,
	@codigo nvarchar(20)
)
as
begin

INSERT INTO [dbo].[Producto]
           ([descripcion]
           ,[idCategoria]
           ,[idMarca]
           ,[precioUnitario]
           ,[stock]
           ,[codigo]
           ,[activo])
     VALUES
           ( @descripcion
            ,@idCategoria
            ,@idMarca
            ,@precioUnitario
            ,@stock
            ,@codigo
            ,1)
end
GO
/****** Object:  StoredProcedure [dbo].[Producto_Delete]    Script Date: 20/05/2023 08:13:45 p. m. ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
create procedure [dbo].[Producto_Delete]
(
	@idProducto int
)
as
begin 


UPDATE [dbo].[Producto]
   SET [activo] = 0
      
 WHERE idProducto = @idProducto

end
GO
/****** Object:  StoredProcedure [dbo].[Producto_GetAll]    Script Date: 20/05/2023 08:13:45 p. m. ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
create procedure [dbo].[Producto_GetAll]
as 

begin
select * from Producto where activo = 1
end
GO
/****** Object:  StoredProcedure [dbo].[Producto_GetByID]    Script Date: 20/05/2023 08:13:45 p. m. ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
create procedure [dbo].[Producto_GetByID]
(
	@idProducto int
)
as 

begin
select * from Producto where idProducto = @idProducto
end
GO
/****** Object:  StoredProcedure [dbo].[Producto_Update]    Script Date: 20/05/2023 08:13:45 p. m. ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
create procedure [dbo].[Producto_Update]
(
	@idProducto int,
	@descripcion nvarchar(100),
	@idCategoria int,
	@idMarca int,
	@precioUnitario decimal(18,0),
	@stock int,
	@codigo nvarchar(20)
)
as
begin 


UPDATE [dbo].[Producto]
   SET [descripcion] = @descripcion
      ,[idCategoria] = @idCategoria
      ,[idMarca] = @idMarca
      ,[precioUnitario] = @precioUnitario
      ,[stock] = @stock
      ,[codigo] = @codigo
 WHERE idProducto = @idProducto

end
GO
