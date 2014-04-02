/****** Script for SelectTopNRows command from SSMS  ******/
SELECT TOP 1000 [packageID]
      ,[projectID]
      ,[wrkStnID]
      ,[partNr]
      ,[packagingTime]
  FROM [Leoni_Packaging_prod].[dbo].[PackItemView]
  order by packagingTime desc