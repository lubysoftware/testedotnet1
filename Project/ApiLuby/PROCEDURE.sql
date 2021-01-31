USE [LUBY]
GO
/****** Object:  StoredProcedure [dbo].[stp_SelRankingHoras]    Script Date: 30/01/2021 02:42:42 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
ALTER PROCEDURE [dbo].[stp_SelRankingHoras]

AS  
BEGIN
select top 5 Login,CodigoDeveloper,  sum(TotalHours) TotalHours
from TB_BANKOFHOURS A INNER JOIN TB_DEVELOPER B ON A.CodigoDeveloper = B.Codigo
group by Login,CodigoDeveloper
order by SUM(TotalHours) desc

END
