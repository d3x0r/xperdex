/****** Object:  View [dbo].[v_APSales]    Script Date: 11/15/2015 18:17:33 ******/
IF  EXISTS (SELECT * FROM sys.views WHERE object_id = OBJECT_ID(N'[dbo].[v_APSales]'))
DROP VIEW [dbo].[v_APSales]
GO


/****** Object:  View [dbo].[v_APSales]    Script Date: 11/15/2015 18:17:33 ******/
SET ANSI_NULLS ON
GO

SET QUOTED_IDENTIFIER ON
GO

CREATE VIEW [dbo].[v_APSales]
AS
select distinct top 100 percent  
	 ses_date, 
	prg_desc			as program, 
	ctg_desc			as product_type,
	itmpick.itm_qty		as Key_qty,
	itmpick.itm_uprice	as Key_Price,
	itmpick.itm_type	as Prod_Type,
	itmpick.itm_uprice	as prod_Price,
	oi.itm_qty			as Sold_Qty,
	oi.ret_qty			as Sold_Returns,
	oi.itm_uprice		as Sold_Price,
	'Non-Electronic'	as Sales_Location,
	Category.ctg_id,
	listpick.lst_desc,
	session.ses_id
from Session
join program on session.ses_id = program.prg_id
join listpick on session.ses_id = listpick.ses_id
join itmpick on listpick.lst_id = itmpick.lst_id
join category on itmpick.ctg_id = category.ctg_id
join orderitm oi on listpick.lst_id = oi.lst_id
where itm_type not in('5','6') --and ord_id = 2
UNION ALL
select distinct ses_date, 
	prg_desc			as program, 
	ctg_desc			as product_type,
	itmpick.itm_qty		as Key_qty,
	itmpick.itm_uprice	as Key_Price,
	itmpick.itm_type	as Prod_Type,
	itmpick.itm_uprice	as prod_Price,
	o3.itm_qty			as Sold_Qty,
	o3.ret_qty			as Sold_Returns,
	o3.itm_uprice		as Sold_Price,
	'Electronic'		as Sales_Location,
	Category.ctg_id,
	listpick.lst_desc,
	session.ses_id
from Session
join program on session.ses_id = program.prg_id
join ordersp1 o1 on o1.ses_id = session.ses_id
join OrderSp3 o3 on o1.ord_child = o3.ord_child
join itmpick on o3.lst_id = itmpick.lst_id
join listpick on itmpick.lst_id = listpick.lst_id
join category on itmpick.ctg_id = category.ctg_id
--order by 1,2

GO
