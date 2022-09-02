Create OR Alter Procedure GetDailyBhav
 --@selectedDate datetime
@whereCondition nvarchar(max),      
 @Page int,          
 @Count int, 
 @orderByColumn nvarchar(100)

 AS
 BEGIN TRY 
 DECLARE @queryString nvarchar(max) 
 IF (@orderByColumn = '')          
BEGIN          
 SET @orderByColumn = 'GeneratedDate'          
END 
 
 
 SET @queryString ='Select ID,GeneratedDate,SYMBOL,SERIES,[OPEN],HIGH,LOW,[CLOSE],LAST,PREVCLOSE,TOTTRDQTY,TOTTRDVAL,TIMESTAMP,
 TOTALTRADES,ISIN,[TotalCount]= COUNT(1) OVER() from DailyBhav'+' ORDER BY ' + @orderByColumn + ' OFFSET ' + convert(nvarchar,@Page) + ' ROWS FETCH NEXT ' + convert(nvarchar,@Count) + ' ROWS ONLY      
'
          --Select @queryString
EXEC sp_executesql @queryString       
          
END TRY    
BEGIN CATCH          
        
END CATCH   