--#pragma warning disable

CREATE PROCEDURE dbo.usp_Shopping_Order_GetPagging
	@SearchColumn nvarchar(30) = '',
	@SearchText nvarchar(30) = '',
	@SortColumn nvarchar(30) = '',
	@SortDir nvarchar(30) = 'ASC',

	@Skip int = 0,
	@Take int = 10,
	@Total int = 0 OUT
AS
	SET NOCOUNT ON

	SELECT
		O.Id			AS	OrderId,
		P.Name			AS	ProductName,
		CA.Name			AS	CategoryName,
		CT.Name			AS	CustomerName,
		O.OrderDate		AS	OrderDate,
		O.Amount		AS	Amount

	INTO #OrderView

	FROM [Orders] O
	LEFT JOIN Products P WITH (NOLOCK) ON O.ProductId = P.Id
	LEFT JOIN Categories CA WITH (NOLOCK) ON P.CategoryId = CA.Id
	LEFT JOIN Customers CT WITH (NOLOCK) ON O.CustomerId = CT.Id

	WHERE (
		(LEN(@SearchColumn) = 0) OR
		(@SearchColumn = 'ProductName' AND P.Name like '%' + @SearchText + '%') OR
		(@SearchColumn = 'CategoryName' AND CA.Name like '%' + @SearchText + '%') OR
		(@SearchColumn = 'CustomerName' AND CT.Name like '%' + @SearchText + '%') OR
		(@SearchColumn = 'OrderDate' AND CONVERT(nvarchar(30), O.OrderDate) like '%' + @SearchText + '%') OR
		(@SearchColumn = 'Amount' AND CONVERT(nvarchar(30), O.Amount) like '%' + @SearchText + '%')
	)

	DECLARE @query nvarchar(1000)
	SELECT @query  = 'SELECT OV.OrderId, OV.ProductName, OV.CategoryName, OV.CustomerName, OV.OrderDate, OV.Amount'
	SELECT @query += ' FROM #OrderView OV '

	IF LEN(@SortColumn) = 0
		SELECT @query += ' ORDER BY ProductName ' + IIF(LEN(@SortDir) = 0, 'ASC', 'DESC')
	ELSE
		SELECT @query += ' ORDER BY ' + @SortColumn + ' ' + IIF(LEN(@SortDir) = 0, 'ASC', 'DESC')

	SELECT @query += ' OFFSET ' + CONVERT(nvarchar(10), @Skip) + ' ROWS'
	SELECT @query += ' FETCH NEXT ' + CONVERT(nvarchar(10), @Take) + ' ROWS ONLY'

	SELECT @Total = Count(1) FROM #OrderView

	EXEC sp_executesql @query
GO