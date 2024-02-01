--GO

--/****** Object:  View [dbo].[Advertising]    Script Date: 12/11/1402 05:20:38 ب.ظ ******/
--SET ANSI_NULLS ON
--GO

--SET QUOTED_IDENTIFIER ON
--GO


--ALTER VIEW [dbo].[Advertising] AS
--select I.Id as Id,I.IntroductionTitle as Title,'' as [Type],I.IntroductionImage as [Image],I.UserId from [dbo].[Introduction] as I UNION 	   
--select P.Id as Id,P.PlacementFullName as Title,'' as [Type],P.PlacementImage    as [Image],P.UserId from [dbo].[Placement] as P UNION 	    
--select R.Id as Id,R.RecruitmentTitle  as Title,'' as [Type],R.RecruitmentImage  as [Image],R.UserId from [dbo].[Recruitment] as R
--GO
--*****************************
--GO
--/****** Object:  StoredProcedure [dbo].[GetCategories]    Script Date: 12/11/1402 05:22:00 ب.ظ ******/
--SET ANSI_NULLS ON
--GO
--SET QUOTED_IDENTIFIER ON
--GO
---- =============================================
---- Author:		<Jam-Programmer>
---- Create date: <1402>
---- Description:	<Get Category>
---- RUN: EXEC GetCategories '9368962D-1CC9-44CA-B88E-4965FF20121F','','',''
---- =============================================
--ALTER PROCEDURE [dbo].[GetCategories]
--	@CategoryId NVARCHAR(MAX),
--	@Search NVARCHAR(MAX) NULL,
--	@ProvinceId NVARCHAR(MAX)NULL,
--	@CityId NVARCHAR(MAX)NULL
--AS
--BEGIN
--DECLARE @SQL NVARCHAR(MAX)
--SET @SQL = 'SELECT U.FullName, U.Id, CI.[Name] CityName, P.[Name] ProvinceName
--			FROM [dbo].[Category] AS C WITH(NOLOCK)
--				INNER JOIN [dbo].[CategoryUser] AS CU WITH(NOLOCK) ON C.Id = CU.CategoryId
--				INNER JOIN [dbo].[AspNetUsers] AS U WITH(NOLOCK) ON CU.UserId = U.Id
--				INNER JOIN [dbo].[UserAddress] AS UA WITH(NOLOCK) ON U.Id = UA.UserId
--				INNER JOIN [dbo].[Province] AS P WITH(NOLOCK) ON UA.ProvinceId = P.Id
--				INNER JOIN [dbo].[City] AS CI WITH(NOLOCK) ON UA.CityId = CI.Id
--			WHERE C.Id = ''' + @CategoryId + ''' '

--IF @search IS NOT NULL AND @search <> ''
--	SET @SQL = @SQL + ' AND U.FullName LIKE N''%' + @search + '%'' '

--IF @ProvinceId IS NOT NULL AND @ProvinceId <> ''
--	SET @SQL = @SQL + ' AND UA.ProvinceId = ''' + @ProvinceId + ''' '

--IF @CityId IS NOT NULL AND @CityId <> ''
--	SET @SQL = @SQL + ' AND UA.CityId = ''' + @CityId + ''' '

		
--	EXEC sp_executesql @SQL
----PRINT @SQL
--END


