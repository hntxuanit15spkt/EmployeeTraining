
USE [Employee]
GO
SET QUOTED_IDENTIFIER ON 
GO
SET ANSI_NULLS OFF 
GO

	

-- Drop the dbo.Departments_Get_List procedure
IF EXISTS (SELECT * FROM dbo.sysobjects WHERE id = object_id(N'dbo.Departments_Get_List') AND OBJECTPROPERTY(id, N'IsProcedure') = 1)
DROP PROCEDURE dbo.Departments_Get_List
GO

/*
----------------------------------------------------------------------------------------------------

-- Created By: I-Financial (www.i-financial.org)
-- Purpose: Gets all records from the Departments table
----------------------------------------------------------------------------------------------------
*/


CREATE PROCEDURE dbo.Departments_Get_List

AS


				
				SELECT
					[DepartmentCode],
					[Name],
					[CreatedOn]
				FROM
					[dbo].[Departments]
					
				SELECT @@ROWCOUNT
			

GO
SET QUOTED_IDENTIFIER ON 
GO
SET NOCOUNT ON
GO
SET ANSI_NULLS OFF 
GO

	

-- Drop the dbo.Departments_GetPaged procedure
IF EXISTS (SELECT * FROM dbo.sysobjects WHERE id = object_id(N'dbo.Departments_GetPaged') AND OBJECTPROPERTY(id, N'IsProcedure') = 1)
DROP PROCEDURE dbo.Departments_GetPaged
GO

/*
----------------------------------------------------------------------------------------------------

-- Created By: I-Financial (www.i-financial.org)
-- Purpose: Gets records from the Departments table passing page index and page count parameters
----------------------------------------------------------------------------------------------------
*/


CREATE PROCEDURE dbo.Departments_GetPaged
(

	@WhereClause varchar (8000)  ,

	@OrderBy varchar (2000)  ,

	@PageIndex int   ,

	@PageSize int   
)
AS


				
				BEGIN
				DECLARE @PageLowerBound int
				DECLARE @PageUpperBound int
				
				-- Set the page bounds
				SET @PageLowerBound = @PageSize * @PageIndex
				SET @PageUpperBound = @PageLowerBound + @PageSize

				IF (@OrderBy IS NULL OR LEN(@OrderBy) < 1)
				BEGIN
					-- default order by to first column
					SET @OrderBy = '[DepartmentCode]'
				END

				-- SQL Server 2005 Paging
				DECLARE @SQL AS nvarchar(MAX)
				SET @SQL = 'WITH PageIndex AS ('
				SET @SQL = @SQL + ' SELECT'
				IF @PageSize > 0
				BEGIN
					SET @SQL = @SQL + ' TOP ' + CONVERT(nvarchar, @PageUpperBound)
				END
				SET @SQL = @SQL + ' ROW_NUMBER() OVER (ORDER BY ' + @OrderBy + ') as RowIndex'
				SET @SQL = @SQL + ', [DepartmentCode]'
				SET @SQL = @SQL + ', [Name]'
				SET @SQL = @SQL + ', [CreatedOn]'
				SET @SQL = @SQL + ' FROM [dbo].[Departments]'
				IF LEN(@WhereClause) > 0
				BEGIN
					SET @SQL = @SQL + ' WHERE ' + @WhereClause
				END
				SET @SQL = @SQL + ' ) SELECT'
				SET @SQL = @SQL + ' [DepartmentCode],'
				SET @SQL = @SQL + ' [Name],'
				SET @SQL = @SQL + ' [CreatedOn]'
				SET @SQL = @SQL + ' FROM PageIndex'
				SET @SQL = @SQL + ' WHERE RowIndex > ' + CONVERT(nvarchar, @PageLowerBound)
				IF @PageSize > 0
				BEGIN
					SET @SQL = @SQL + ' AND RowIndex <= ' + CONVERT(nvarchar, @PageUpperBound)
				END
				SET @SQL = @SQL + ' ORDER BY ' + @OrderBy
				EXEC sp_executesql @SQL
				
				-- get row count
				SET @SQL = 'SELECT COUNT(1) AS TotalRowCount'
				SET @SQL = @SQL + ' FROM [dbo].[Departments]'
				IF LEN(@WhereClause) > 0
				BEGIN
					SET @SQL = @SQL + ' WHERE ' + @WhereClause
				END
				EXEC sp_executesql @SQL
			
				END
			

GO
SET QUOTED_IDENTIFIER ON 
GO
SET NOCOUNT ON
GO
SET ANSI_NULLS OFF 
GO

	

-- Drop the dbo.Departments_Insert procedure
IF EXISTS (SELECT * FROM dbo.sysobjects WHERE id = object_id(N'dbo.Departments_Insert') AND OBJECTPROPERTY(id, N'IsProcedure') = 1)
DROP PROCEDURE dbo.Departments_Insert
GO

/*
----------------------------------------------------------------------------------------------------

-- Created By: I-Financial (www.i-financial.org)
-- Purpose: Inserts a record into the Departments table
----------------------------------------------------------------------------------------------------
*/


CREATE PROCEDURE dbo.Departments_Insert
(

	@DepartmentCode varchar (10)  ,

	@Name nvarchar (100)  ,

	@CreatedOn datetime   
)
AS


				
				INSERT INTO [dbo].[Departments]
					(
					[DepartmentCode]
					,[Name]
					,[CreatedOn]
					)
				VALUES
					(
					@DepartmentCode
					,@Name
					,@CreatedOn
					)
									
							
			

GO
SET QUOTED_IDENTIFIER ON 
GO
SET NOCOUNT ON
GO
SET ANSI_NULLS OFF 
GO

	

-- Drop the dbo.Departments_Update procedure
IF EXISTS (SELECT * FROM dbo.sysobjects WHERE id = object_id(N'dbo.Departments_Update') AND OBJECTPROPERTY(id, N'IsProcedure') = 1)
DROP PROCEDURE dbo.Departments_Update
GO

/*
----------------------------------------------------------------------------------------------------

-- Created By: I-Financial (www.i-financial.org)
-- Purpose: Updates a record in the Departments table
----------------------------------------------------------------------------------------------------
*/


CREATE PROCEDURE dbo.Departments_Update
(

	@DepartmentCode varchar (10)  ,

	@OriginalDepartmentCode varchar (10)  ,

	@Name nvarchar (100)  ,

	@CreatedOn datetime   
)
AS


				
				
				-- Modify the updatable columns
				UPDATE
					[dbo].[Departments]
				SET
					[DepartmentCode] = @DepartmentCode
					,[Name] = @Name
					,[CreatedOn] = @CreatedOn
				WHERE
[DepartmentCode] = @OriginalDepartmentCode 
				
			

GO
SET QUOTED_IDENTIFIER ON 
GO
SET NOCOUNT ON
GO
SET ANSI_NULLS OFF 
GO

	

-- Drop the dbo.Departments_Delete procedure
IF EXISTS (SELECT * FROM dbo.sysobjects WHERE id = object_id(N'dbo.Departments_Delete') AND OBJECTPROPERTY(id, N'IsProcedure') = 1)
DROP PROCEDURE dbo.Departments_Delete
GO

/*
----------------------------------------------------------------------------------------------------

-- Created By: I-Financial (www.i-financial.org)
-- Purpose: Deletes a record in the Departments table
----------------------------------------------------------------------------------------------------
*/


CREATE PROCEDURE dbo.Departments_Delete
(

	@DepartmentCode varchar (10)  
)
AS


				DELETE FROM [dbo].[Departments] WITH (ROWLOCK) 
				WHERE
					[DepartmentCode] = @DepartmentCode
					
			

GO
SET QUOTED_IDENTIFIER ON 
GO
SET NOCOUNT ON
GO
SET ANSI_NULLS OFF 
GO

	

-- Drop the dbo.Departments_GetByDepartmentCode procedure
IF EXISTS (SELECT * FROM dbo.sysobjects WHERE id = object_id(N'dbo.Departments_GetByDepartmentCode') AND OBJECTPROPERTY(id, N'IsProcedure') = 1)
DROP PROCEDURE dbo.Departments_GetByDepartmentCode
GO

/*
----------------------------------------------------------------------------------------------------

-- Created By: I-Financial (www.i-financial.org)
-- Purpose: Select records from the Departments table through an index
----------------------------------------------------------------------------------------------------
*/


CREATE PROCEDURE dbo.Departments_GetByDepartmentCode
(

	@DepartmentCode varchar (10)  
)
AS


				SELECT
					[DepartmentCode],
					[Name],
					[CreatedOn]
				FROM
					[dbo].[Departments]
				WHERE
					[DepartmentCode] = @DepartmentCode
				SELECT @@ROWCOUNT
					
			

GO
SET QUOTED_IDENTIFIER ON 
GO
SET NOCOUNT ON
GO
SET ANSI_NULLS OFF 
GO

	

-- Drop the dbo.Departments_Find procedure
IF EXISTS (SELECT * FROM dbo.sysobjects WHERE id = object_id(N'dbo.Departments_Find') AND OBJECTPROPERTY(id, N'IsProcedure') = 1)
DROP PROCEDURE dbo.Departments_Find
GO

/*
----------------------------------------------------------------------------------------------------

-- Created By: I-Financial (www.i-financial.org)
-- Purpose: Finds records in the Departments table passing nullable parameters
----------------------------------------------------------------------------------------------------
*/


CREATE PROCEDURE dbo.Departments_Find
(

	@SearchUsingOR bit   = null ,

	@DepartmentCode varchar (10)  = null ,

	@Name nvarchar (100)  = null ,

	@CreatedOn datetime   = null 
)
AS


				
  IF ISNULL(@SearchUsingOR, 0) <> 1
  BEGIN
    SELECT
	  [DepartmentCode]
	, [Name]
	, [CreatedOn]
    FROM
	[dbo].[Departments]
    WHERE 
	 ([DepartmentCode] = @DepartmentCode OR @DepartmentCode IS NULL)
	AND ([Name] = @Name OR @Name IS NULL)
	AND ([CreatedOn] = @CreatedOn OR @CreatedOn IS NULL)
						
  END
  ELSE
  BEGIN
    SELECT
	  [DepartmentCode]
	, [Name]
	, [CreatedOn]
    FROM
	[dbo].[Departments]
    WHERE 
	 ([DepartmentCode] = @DepartmentCode AND @DepartmentCode is not null)
	OR ([Name] = @Name AND @Name is not null)
	OR ([CreatedOn] = @CreatedOn AND @CreatedOn is not null)
	SELECT @@ROWCOUNT			
  END
				

GO
SET QUOTED_IDENTIFIER ON 
GO
SET NOCOUNT ON
GO
SET ANSI_NULLS OFF 
GO

	

-- Drop the dbo.EmployeeDepartments_Get_List procedure
IF EXISTS (SELECT * FROM dbo.sysobjects WHERE id = object_id(N'dbo.EmployeeDepartments_Get_List') AND OBJECTPROPERTY(id, N'IsProcedure') = 1)
DROP PROCEDURE dbo.EmployeeDepartments_Get_List
GO

/*
----------------------------------------------------------------------------------------------------

-- Created By: I-Financial (www.i-financial.org)
-- Purpose: Gets all records from the EmployeeDepartments table
----------------------------------------------------------------------------------------------------
*/


CREATE PROCEDURE dbo.EmployeeDepartments_Get_List

AS


				
				SELECT
					[EmployeeDepartmentId],
					[DepartmentCode],
					[EmployeeId],
					[CreatedOn]
				FROM
					[dbo].[EmployeeDepartments]
					
				SELECT @@ROWCOUNT
			

GO
SET QUOTED_IDENTIFIER ON 
GO
SET NOCOUNT ON
GO
SET ANSI_NULLS OFF 
GO

	

-- Drop the dbo.EmployeeDepartments_GetPaged procedure
IF EXISTS (SELECT * FROM dbo.sysobjects WHERE id = object_id(N'dbo.EmployeeDepartments_GetPaged') AND OBJECTPROPERTY(id, N'IsProcedure') = 1)
DROP PROCEDURE dbo.EmployeeDepartments_GetPaged
GO

/*
----------------------------------------------------------------------------------------------------

-- Created By: I-Financial (www.i-financial.org)
-- Purpose: Gets records from the EmployeeDepartments table passing page index and page count parameters
----------------------------------------------------------------------------------------------------
*/


CREATE PROCEDURE dbo.EmployeeDepartments_GetPaged
(

	@WhereClause varchar (8000)  ,

	@OrderBy varchar (2000)  ,

	@PageIndex int   ,

	@PageSize int   
)
AS


				
				BEGIN
				DECLARE @PageLowerBound int
				DECLARE @PageUpperBound int
				
				-- Set the page bounds
				SET @PageLowerBound = @PageSize * @PageIndex
				SET @PageUpperBound = @PageLowerBound + @PageSize

				IF (@OrderBy IS NULL OR LEN(@OrderBy) < 1)
				BEGIN
					-- default order by to first column
					SET @OrderBy = '[EmployeeDepartmentId]'
				END

				-- SQL Server 2005 Paging
				DECLARE @SQL AS nvarchar(MAX)
				SET @SQL = 'WITH PageIndex AS ('
				SET @SQL = @SQL + ' SELECT'
				IF @PageSize > 0
				BEGIN
					SET @SQL = @SQL + ' TOP ' + CONVERT(nvarchar, @PageUpperBound)
				END
				SET @SQL = @SQL + ' ROW_NUMBER() OVER (ORDER BY ' + @OrderBy + ') as RowIndex'
				SET @SQL = @SQL + ', [EmployeeDepartmentId]'
				SET @SQL = @SQL + ', [DepartmentCode]'
				SET @SQL = @SQL + ', [EmployeeId]'
				SET @SQL = @SQL + ', [CreatedOn]'
				SET @SQL = @SQL + ' FROM [dbo].[EmployeeDepartments]'
				IF LEN(@WhereClause) > 0
				BEGIN
					SET @SQL = @SQL + ' WHERE ' + @WhereClause
				END
				SET @SQL = @SQL + ' ) SELECT'
				SET @SQL = @SQL + ' [EmployeeDepartmentId],'
				SET @SQL = @SQL + ' [DepartmentCode],'
				SET @SQL = @SQL + ' [EmployeeId],'
				SET @SQL = @SQL + ' [CreatedOn]'
				SET @SQL = @SQL + ' FROM PageIndex'
				SET @SQL = @SQL + ' WHERE RowIndex > ' + CONVERT(nvarchar, @PageLowerBound)
				IF @PageSize > 0
				BEGIN
					SET @SQL = @SQL + ' AND RowIndex <= ' + CONVERT(nvarchar, @PageUpperBound)
				END
				SET @SQL = @SQL + ' ORDER BY ' + @OrderBy
				EXEC sp_executesql @SQL
				
				-- get row count
				SET @SQL = 'SELECT COUNT(1) AS TotalRowCount'
				SET @SQL = @SQL + ' FROM [dbo].[EmployeeDepartments]'
				IF LEN(@WhereClause) > 0
				BEGIN
					SET @SQL = @SQL + ' WHERE ' + @WhereClause
				END
				EXEC sp_executesql @SQL
			
				END
			

GO
SET QUOTED_IDENTIFIER ON 
GO
SET NOCOUNT ON
GO
SET ANSI_NULLS OFF 
GO

	

-- Drop the dbo.EmployeeDepartments_Insert procedure
IF EXISTS (SELECT * FROM dbo.sysobjects WHERE id = object_id(N'dbo.EmployeeDepartments_Insert') AND OBJECTPROPERTY(id, N'IsProcedure') = 1)
DROP PROCEDURE dbo.EmployeeDepartments_Insert
GO

/*
----------------------------------------------------------------------------------------------------

-- Created By: I-Financial (www.i-financial.org)
-- Purpose: Inserts a record into the EmployeeDepartments table
----------------------------------------------------------------------------------------------------
*/


CREATE PROCEDURE dbo.EmployeeDepartments_Insert
(

	@EmployeeDepartmentId int    OUTPUT,

	@DepartmentCode varchar (10)  ,

	@EmployeeId int   ,

	@CreatedOn datetime   
)
AS


				
				INSERT INTO [dbo].[EmployeeDepartments]
					(
					[DepartmentCode]
					,[EmployeeId]
					,[CreatedOn]
					)
				VALUES
					(
					@DepartmentCode
					,@EmployeeId
					,@CreatedOn
					)
				-- Get the identity value
				SET @EmployeeDepartmentId = SCOPE_IDENTITY()
									
							
			

GO
SET QUOTED_IDENTIFIER ON 
GO
SET NOCOUNT ON
GO
SET ANSI_NULLS OFF 
GO

	

-- Drop the dbo.EmployeeDepartments_Update procedure
IF EXISTS (SELECT * FROM dbo.sysobjects WHERE id = object_id(N'dbo.EmployeeDepartments_Update') AND OBJECTPROPERTY(id, N'IsProcedure') = 1)
DROP PROCEDURE dbo.EmployeeDepartments_Update
GO

/*
----------------------------------------------------------------------------------------------------

-- Created By: I-Financial (www.i-financial.org)
-- Purpose: Updates a record in the EmployeeDepartments table
----------------------------------------------------------------------------------------------------
*/


CREATE PROCEDURE dbo.EmployeeDepartments_Update
(

	@EmployeeDepartmentId int   ,

	@DepartmentCode varchar (10)  ,

	@EmployeeId int   ,

	@CreatedOn datetime   
)
AS


				
				
				-- Modify the updatable columns
				UPDATE
					[dbo].[EmployeeDepartments]
				SET
					[DepartmentCode] = @DepartmentCode
					,[EmployeeId] = @EmployeeId
					,[CreatedOn] = @CreatedOn
				WHERE
[EmployeeDepartmentId] = @EmployeeDepartmentId 
				
			

GO
SET QUOTED_IDENTIFIER ON 
GO
SET NOCOUNT ON
GO
SET ANSI_NULLS OFF 
GO

	

-- Drop the dbo.EmployeeDepartments_Delete procedure
IF EXISTS (SELECT * FROM dbo.sysobjects WHERE id = object_id(N'dbo.EmployeeDepartments_Delete') AND OBJECTPROPERTY(id, N'IsProcedure') = 1)
DROP PROCEDURE dbo.EmployeeDepartments_Delete
GO

/*
----------------------------------------------------------------------------------------------------

-- Created By: I-Financial (www.i-financial.org)
-- Purpose: Deletes a record in the EmployeeDepartments table
----------------------------------------------------------------------------------------------------
*/


CREATE PROCEDURE dbo.EmployeeDepartments_Delete
(

	@EmployeeDepartmentId int   
)
AS


				DELETE FROM [dbo].[EmployeeDepartments] WITH (ROWLOCK) 
				WHERE
					[EmployeeDepartmentId] = @EmployeeDepartmentId
					
			

GO
SET QUOTED_IDENTIFIER ON 
GO
SET NOCOUNT ON
GO
SET ANSI_NULLS OFF 
GO

	

-- Drop the dbo.EmployeeDepartments_GetByDepartmentCode procedure
IF EXISTS (SELECT * FROM dbo.sysobjects WHERE id = object_id(N'dbo.EmployeeDepartments_GetByDepartmentCode') AND OBJECTPROPERTY(id, N'IsProcedure') = 1)
DROP PROCEDURE dbo.EmployeeDepartments_GetByDepartmentCode
GO

/*
----------------------------------------------------------------------------------------------------

-- Created By: I-Financial (www.i-financial.org)
-- Purpose: Select records from the EmployeeDepartments table through a foreign key
----------------------------------------------------------------------------------------------------
*/


CREATE PROCEDURE dbo.EmployeeDepartments_GetByDepartmentCode
(

	@DepartmentCode varchar (10)  
)
AS


				SET ANSI_NULLS OFF
				
				SELECT
					[EmployeeDepartmentId],
					[DepartmentCode],
					[EmployeeId],
					[CreatedOn]
				FROM
					[dbo].[EmployeeDepartments]
				WHERE
					[DepartmentCode] = @DepartmentCode
				
				SELECT @@ROWCOUNT
				SET ANSI_NULLS ON
			

GO
SET QUOTED_IDENTIFIER ON 
GO
SET NOCOUNT ON
GO
SET ANSI_NULLS OFF 
GO

	

-- Drop the dbo.EmployeeDepartments_GetByEmployeeId procedure
IF EXISTS (SELECT * FROM dbo.sysobjects WHERE id = object_id(N'dbo.EmployeeDepartments_GetByEmployeeId') AND OBJECTPROPERTY(id, N'IsProcedure') = 1)
DROP PROCEDURE dbo.EmployeeDepartments_GetByEmployeeId
GO

/*
----------------------------------------------------------------------------------------------------

-- Created By: I-Financial (www.i-financial.org)
-- Purpose: Select records from the EmployeeDepartments table through a foreign key
----------------------------------------------------------------------------------------------------
*/


CREATE PROCEDURE dbo.EmployeeDepartments_GetByEmployeeId
(

	@EmployeeId int   
)
AS


				SET ANSI_NULLS OFF
				
				SELECT
					[EmployeeDepartmentId],
					[DepartmentCode],
					[EmployeeId],
					[CreatedOn]
				FROM
					[dbo].[EmployeeDepartments]
				WHERE
					[EmployeeId] = @EmployeeId
				
				SELECT @@ROWCOUNT
				SET ANSI_NULLS ON
			

GO
SET QUOTED_IDENTIFIER ON 
GO
SET NOCOUNT ON
GO
SET ANSI_NULLS OFF 
GO

	

-- Drop the dbo.EmployeeDepartments_GetByEmployeeDepartmentId procedure
IF EXISTS (SELECT * FROM dbo.sysobjects WHERE id = object_id(N'dbo.EmployeeDepartments_GetByEmployeeDepartmentId') AND OBJECTPROPERTY(id, N'IsProcedure') = 1)
DROP PROCEDURE dbo.EmployeeDepartments_GetByEmployeeDepartmentId
GO

/*
----------------------------------------------------------------------------------------------------

-- Created By: I-Financial (www.i-financial.org)
-- Purpose: Select records from the EmployeeDepartments table through an index
----------------------------------------------------------------------------------------------------
*/


CREATE PROCEDURE dbo.EmployeeDepartments_GetByEmployeeDepartmentId
(

	@EmployeeDepartmentId int   
)
AS


				SELECT
					[EmployeeDepartmentId],
					[DepartmentCode],
					[EmployeeId],
					[CreatedOn]
				FROM
					[dbo].[EmployeeDepartments]
				WHERE
					[EmployeeDepartmentId] = @EmployeeDepartmentId
				SELECT @@ROWCOUNT
					
			

GO
SET QUOTED_IDENTIFIER ON 
GO
SET NOCOUNT ON
GO
SET ANSI_NULLS OFF 
GO

	

-- Drop the dbo.EmployeeDepartments_Find procedure
IF EXISTS (SELECT * FROM dbo.sysobjects WHERE id = object_id(N'dbo.EmployeeDepartments_Find') AND OBJECTPROPERTY(id, N'IsProcedure') = 1)
DROP PROCEDURE dbo.EmployeeDepartments_Find
GO

/*
----------------------------------------------------------------------------------------------------

-- Created By: I-Financial (www.i-financial.org)
-- Purpose: Finds records in the EmployeeDepartments table passing nullable parameters
----------------------------------------------------------------------------------------------------
*/


CREATE PROCEDURE dbo.EmployeeDepartments_Find
(

	@SearchUsingOR bit   = null ,

	@EmployeeDepartmentId int   = null ,

	@DepartmentCode varchar (10)  = null ,

	@EmployeeId int   = null ,

	@CreatedOn datetime   = null 
)
AS


				
  IF ISNULL(@SearchUsingOR, 0) <> 1
  BEGIN
    SELECT
	  [EmployeeDepartmentId]
	, [DepartmentCode]
	, [EmployeeId]
	, [CreatedOn]
    FROM
	[dbo].[EmployeeDepartments]
    WHERE 
	 ([EmployeeDepartmentId] = @EmployeeDepartmentId OR @EmployeeDepartmentId IS NULL)
	AND ([DepartmentCode] = @DepartmentCode OR @DepartmentCode IS NULL)
	AND ([EmployeeId] = @EmployeeId OR @EmployeeId IS NULL)
	AND ([CreatedOn] = @CreatedOn OR @CreatedOn IS NULL)
						
  END
  ELSE
  BEGIN
    SELECT
	  [EmployeeDepartmentId]
	, [DepartmentCode]
	, [EmployeeId]
	, [CreatedOn]
    FROM
	[dbo].[EmployeeDepartments]
    WHERE 
	 ([EmployeeDepartmentId] = @EmployeeDepartmentId AND @EmployeeDepartmentId is not null)
	OR ([DepartmentCode] = @DepartmentCode AND @DepartmentCode is not null)
	OR ([EmployeeId] = @EmployeeId AND @EmployeeId is not null)
	OR ([CreatedOn] = @CreatedOn AND @CreatedOn is not null)
	SELECT @@ROWCOUNT			
  END
				

GO
SET QUOTED_IDENTIFIER ON 
GO
SET NOCOUNT ON
GO
SET ANSI_NULLS OFF 
GO

	

-- Drop the dbo.Employee_Get_List procedure
IF EXISTS (SELECT * FROM dbo.sysobjects WHERE id = object_id(N'dbo.Employee_Get_List') AND OBJECTPROPERTY(id, N'IsProcedure') = 1)
DROP PROCEDURE dbo.Employee_Get_List
GO

/*
----------------------------------------------------------------------------------------------------

-- Created By: I-Financial (www.i-financial.org)
-- Purpose: Gets all records from the Employee table
----------------------------------------------------------------------------------------------------
*/


CREATE PROCEDURE dbo.Employee_Get_List

AS


				
				SELECT
					[EmployeeId],
					[EmployeeCode],
					[FullName],
					[FirstName],
					[MiddlesName],
					[LastName],
					[DOB],
					[Email],
					[Bio],
					[CreatedOn]
				FROM
					[dbo].[Employee]
					
				SELECT @@ROWCOUNT
			

GO
SET QUOTED_IDENTIFIER ON 
GO
SET NOCOUNT ON
GO
SET ANSI_NULLS OFF 
GO

	

-- Drop the dbo.Employee_GetPaged procedure
IF EXISTS (SELECT * FROM dbo.sysobjects WHERE id = object_id(N'dbo.Employee_GetPaged') AND OBJECTPROPERTY(id, N'IsProcedure') = 1)
DROP PROCEDURE dbo.Employee_GetPaged
GO

/*
----------------------------------------------------------------------------------------------------

-- Created By: I-Financial (www.i-financial.org)
-- Purpose: Gets records from the Employee table passing page index and page count parameters
----------------------------------------------------------------------------------------------------
*/


CREATE PROCEDURE dbo.Employee_GetPaged
(

	@WhereClause varchar (8000)  ,

	@OrderBy varchar (2000)  ,

	@PageIndex int   ,

	@PageSize int   
)
AS


				
				BEGIN
				DECLARE @PageLowerBound int
				DECLARE @PageUpperBound int
				
				-- Set the page bounds
				SET @PageLowerBound = @PageSize * @PageIndex
				SET @PageUpperBound = @PageLowerBound + @PageSize

				IF (@OrderBy IS NULL OR LEN(@OrderBy) < 1)
				BEGIN
					-- default order by to first column
					SET @OrderBy = '[EmployeeId]'
				END

				-- SQL Server 2005 Paging
				DECLARE @SQL AS nvarchar(MAX)
				SET @SQL = 'WITH PageIndex AS ('
				SET @SQL = @SQL + ' SELECT'
				IF @PageSize > 0
				BEGIN
					SET @SQL = @SQL + ' TOP ' + CONVERT(nvarchar, @PageUpperBound)
				END
				SET @SQL = @SQL + ' ROW_NUMBER() OVER (ORDER BY ' + @OrderBy + ') as RowIndex'
				SET @SQL = @SQL + ', [EmployeeId]'
				SET @SQL = @SQL + ', [EmployeeCode]'
				SET @SQL = @SQL + ', [FullName]'
				SET @SQL = @SQL + ', [FirstName]'
				SET @SQL = @SQL + ', [MiddlesName]'
				SET @SQL = @SQL + ', [LastName]'
				SET @SQL = @SQL + ', [DOB]'
				SET @SQL = @SQL + ', [Email]'
				SET @SQL = @SQL + ', [Bio]'
				SET @SQL = @SQL + ', [CreatedOn]'
				SET @SQL = @SQL + ' FROM [dbo].[Employee]'
				IF LEN(@WhereClause) > 0
				BEGIN
					SET @SQL = @SQL + ' WHERE ' + @WhereClause
				END
				SET @SQL = @SQL + ' ) SELECT'
				SET @SQL = @SQL + ' [EmployeeId],'
				SET @SQL = @SQL + ' [EmployeeCode],'
				SET @SQL = @SQL + ' [FullName],'
				SET @SQL = @SQL + ' [FirstName],'
				SET @SQL = @SQL + ' [MiddlesName],'
				SET @SQL = @SQL + ' [LastName],'
				SET @SQL = @SQL + ' [DOB],'
				SET @SQL = @SQL + ' [Email],'
				SET @SQL = @SQL + ' [Bio],'
				SET @SQL = @SQL + ' [CreatedOn]'
				SET @SQL = @SQL + ' FROM PageIndex'
				SET @SQL = @SQL + ' WHERE RowIndex > ' + CONVERT(nvarchar, @PageLowerBound)
				IF @PageSize > 0
				BEGIN
					SET @SQL = @SQL + ' AND RowIndex <= ' + CONVERT(nvarchar, @PageUpperBound)
				END
				SET @SQL = @SQL + ' ORDER BY ' + @OrderBy
				EXEC sp_executesql @SQL
				
				-- get row count
				SET @SQL = 'SELECT COUNT(1) AS TotalRowCount'
				SET @SQL = @SQL + ' FROM [dbo].[Employee]'
				IF LEN(@WhereClause) > 0
				BEGIN
					SET @SQL = @SQL + ' WHERE ' + @WhereClause
				END
				EXEC sp_executesql @SQL
			
				END
			

GO
SET QUOTED_IDENTIFIER ON 
GO
SET NOCOUNT ON
GO
SET ANSI_NULLS OFF 
GO

	

-- Drop the dbo.Employee_Insert procedure
IF EXISTS (SELECT * FROM dbo.sysobjects WHERE id = object_id(N'dbo.Employee_Insert') AND OBJECTPROPERTY(id, N'IsProcedure') = 1)
DROP PROCEDURE dbo.Employee_Insert
GO

/*
----------------------------------------------------------------------------------------------------

-- Created By: I-Financial (www.i-financial.org)
-- Purpose: Inserts a record into the Employee table
----------------------------------------------------------------------------------------------------
*/


CREATE PROCEDURE dbo.Employee_Insert
(

	@EmployeeId int    OUTPUT,

	@EmployeeCode varchar (50)  ,

	@FullName nvarchar (200)  ,

	@FirstName nvarchar (50)  ,

	@MiddlesName nvarchar (100)  ,

	@LastName nvarchar (50)  ,

	@DOB datetime   ,

	@Email nvarchar (200)  ,

	@Bio nvarchar (MAX)  ,

	@CreatedOn datetime   
)
AS


				
				INSERT INTO [dbo].[Employee]
					(
					[EmployeeCode]
					,[FullName]
					,[FirstName]
					,[MiddlesName]
					,[LastName]
					,[DOB]
					,[Email]
					,[Bio]
					,[CreatedOn]
					)
				VALUES
					(
					@EmployeeCode
					,@FullName
					,@FirstName
					,@MiddlesName
					,@LastName
					,@DOB
					,@Email
					,@Bio
					,@CreatedOn
					)
				-- Get the identity value
				SET @EmployeeId = SCOPE_IDENTITY()
									
							
			

GO
SET QUOTED_IDENTIFIER ON 
GO
SET NOCOUNT ON
GO
SET ANSI_NULLS OFF 
GO

	

-- Drop the dbo.Employee_Update procedure
IF EXISTS (SELECT * FROM dbo.sysobjects WHERE id = object_id(N'dbo.Employee_Update') AND OBJECTPROPERTY(id, N'IsProcedure') = 1)
DROP PROCEDURE dbo.Employee_Update
GO

/*
----------------------------------------------------------------------------------------------------

-- Created By: I-Financial (www.i-financial.org)
-- Purpose: Updates a record in the Employee table
----------------------------------------------------------------------------------------------------
*/


CREATE PROCEDURE dbo.Employee_Update
(

	@EmployeeId int   ,

	@EmployeeCode varchar (50)  ,

	@FullName nvarchar (200)  ,

	@FirstName nvarchar (50)  ,

	@MiddlesName nvarchar (100)  ,

	@LastName nvarchar (50)  ,

	@DOB datetime   ,

	@Email nvarchar (200)  ,

	@Bio nvarchar (MAX)  ,

	@CreatedOn datetime   
)
AS


				
				
				-- Modify the updatable columns
				UPDATE
					[dbo].[Employee]
				SET
					[EmployeeCode] = @EmployeeCode
					,[FullName] = @FullName
					,[FirstName] = @FirstName
					,[MiddlesName] = @MiddlesName
					,[LastName] = @LastName
					,[DOB] = @DOB
					,[Email] = @Email
					,[Bio] = @Bio
					,[CreatedOn] = @CreatedOn
				WHERE
[EmployeeId] = @EmployeeId 
				
			

GO
SET QUOTED_IDENTIFIER ON 
GO
SET NOCOUNT ON
GO
SET ANSI_NULLS OFF 
GO

	

-- Drop the dbo.Employee_Delete procedure
IF EXISTS (SELECT * FROM dbo.sysobjects WHERE id = object_id(N'dbo.Employee_Delete') AND OBJECTPROPERTY(id, N'IsProcedure') = 1)
DROP PROCEDURE dbo.Employee_Delete
GO

/*
----------------------------------------------------------------------------------------------------

-- Created By: I-Financial (www.i-financial.org)
-- Purpose: Deletes a record in the Employee table
----------------------------------------------------------------------------------------------------
*/


CREATE PROCEDURE dbo.Employee_Delete
(

	@EmployeeId int   
)
AS


				DELETE FROM [dbo].[Employee] WITH (ROWLOCK) 
				WHERE
					[EmployeeId] = @EmployeeId
					
			

GO
SET QUOTED_IDENTIFIER ON 
GO
SET NOCOUNT ON
GO
SET ANSI_NULLS OFF 
GO

	

-- Drop the dbo.Employee_GetByEmployeeId procedure
IF EXISTS (SELECT * FROM dbo.sysobjects WHERE id = object_id(N'dbo.Employee_GetByEmployeeId') AND OBJECTPROPERTY(id, N'IsProcedure') = 1)
DROP PROCEDURE dbo.Employee_GetByEmployeeId
GO

/*
----------------------------------------------------------------------------------------------------

-- Created By: I-Financial (www.i-financial.org)
-- Purpose: Select records from the Employee table through an index
----------------------------------------------------------------------------------------------------
*/


CREATE PROCEDURE dbo.Employee_GetByEmployeeId
(

	@EmployeeId int   
)
AS


				SELECT
					[EmployeeId],
					[EmployeeCode],
					[FullName],
					[FirstName],
					[MiddlesName],
					[LastName],
					[DOB],
					[Email],
					[Bio],
					[CreatedOn]
				FROM
					[dbo].[Employee]
				WHERE
					[EmployeeId] = @EmployeeId
				SELECT @@ROWCOUNT
					
			

GO
SET QUOTED_IDENTIFIER ON 
GO
SET NOCOUNT ON
GO
SET ANSI_NULLS OFF 
GO

	

-- Drop the dbo.Employee_Find procedure
IF EXISTS (SELECT * FROM dbo.sysobjects WHERE id = object_id(N'dbo.Employee_Find') AND OBJECTPROPERTY(id, N'IsProcedure') = 1)
DROP PROCEDURE dbo.Employee_Find
GO

/*
----------------------------------------------------------------------------------------------------

-- Created By: I-Financial (www.i-financial.org)
-- Purpose: Finds records in the Employee table passing nullable parameters
----------------------------------------------------------------------------------------------------
*/


CREATE PROCEDURE dbo.Employee_Find
(

	@SearchUsingOR bit   = null ,

	@EmployeeId int   = null ,

	@EmployeeCode varchar (50)  = null ,

	@FullName nvarchar (200)  = null ,

	@FirstName nvarchar (50)  = null ,

	@MiddlesName nvarchar (100)  = null ,

	@LastName nvarchar (50)  = null ,

	@DOB datetime   = null ,

	@Email nvarchar (200)  = null ,

	@Bio nvarchar (MAX)  = null ,

	@CreatedOn datetime   = null 
)
AS


				
  IF ISNULL(@SearchUsingOR, 0) <> 1
  BEGIN
    SELECT
	  [EmployeeId]
	, [EmployeeCode]
	, [FullName]
	, [FirstName]
	, [MiddlesName]
	, [LastName]
	, [DOB]
	, [Email]
	, [Bio]
	, [CreatedOn]
    FROM
	[dbo].[Employee]
    WHERE 
	 ([EmployeeId] = @EmployeeId OR @EmployeeId IS NULL)
	AND ([EmployeeCode] = @EmployeeCode OR @EmployeeCode IS NULL)
	AND ([FullName] = @FullName OR @FullName IS NULL)
	AND ([FirstName] = @FirstName OR @FirstName IS NULL)
	AND ([MiddlesName] = @MiddlesName OR @MiddlesName IS NULL)
	AND ([LastName] = @LastName OR @LastName IS NULL)
	AND ([DOB] = @DOB OR @DOB IS NULL)
	AND ([Email] = @Email OR @Email IS NULL)
	AND ([Bio] = @Bio OR @Bio IS NULL)
	AND ([CreatedOn] = @CreatedOn OR @CreatedOn IS NULL)
						
  END
  ELSE
  BEGIN
    SELECT
	  [EmployeeId]
	, [EmployeeCode]
	, [FullName]
	, [FirstName]
	, [MiddlesName]
	, [LastName]
	, [DOB]
	, [Email]
	, [Bio]
	, [CreatedOn]
    FROM
	[dbo].[Employee]
    WHERE 
	 ([EmployeeId] = @EmployeeId AND @EmployeeId is not null)
	OR ([EmployeeCode] = @EmployeeCode AND @EmployeeCode is not null)
	OR ([FullName] = @FullName AND @FullName is not null)
	OR ([FirstName] = @FirstName AND @FirstName is not null)
	OR ([MiddlesName] = @MiddlesName AND @MiddlesName is not null)
	OR ([LastName] = @LastName AND @LastName is not null)
	OR ([DOB] = @DOB AND @DOB is not null)
	OR ([Email] = @Email AND @Email is not null)
	OR ([Bio] = @Bio AND @Bio is not null)
	OR ([CreatedOn] = @CreatedOn AND @CreatedOn is not null)
	SELECT @@ROWCOUNT			
  END
				

GO
SET QUOTED_IDENTIFIER ON 
GO
SET NOCOUNT ON
GO
SET ANSI_NULLS OFF 
GO

	

-- Drop the dbo.Countries_Get_List procedure
IF EXISTS (SELECT * FROM dbo.sysobjects WHERE id = object_id(N'dbo.Countries_Get_List') AND OBJECTPROPERTY(id, N'IsProcedure') = 1)
DROP PROCEDURE dbo.Countries_Get_List
GO

/*
----------------------------------------------------------------------------------------------------

-- Created By: I-Financial (www.i-financial.org)
-- Purpose: Gets all records from the Countries table
----------------------------------------------------------------------------------------------------
*/


CREATE PROCEDURE dbo.Countries_Get_List

AS


				
				SELECT
					[CountryCode],
					[Name]
				FROM
					[dbo].[Countries]
					
				SELECT @@ROWCOUNT
			

GO
SET QUOTED_IDENTIFIER ON 
GO
SET NOCOUNT ON
GO
SET ANSI_NULLS OFF 
GO

	

-- Drop the dbo.Countries_GetPaged procedure
IF EXISTS (SELECT * FROM dbo.sysobjects WHERE id = object_id(N'dbo.Countries_GetPaged') AND OBJECTPROPERTY(id, N'IsProcedure') = 1)
DROP PROCEDURE dbo.Countries_GetPaged
GO

/*
----------------------------------------------------------------------------------------------------

-- Created By: I-Financial (www.i-financial.org)
-- Purpose: Gets records from the Countries table passing page index and page count parameters
----------------------------------------------------------------------------------------------------
*/


CREATE PROCEDURE dbo.Countries_GetPaged
(

	@WhereClause varchar (8000)  ,

	@OrderBy varchar (2000)  ,

	@PageIndex int   ,

	@PageSize int   
)
AS


				
				BEGIN
				DECLARE @PageLowerBound int
				DECLARE @PageUpperBound int
				
				-- Set the page bounds
				SET @PageLowerBound = @PageSize * @PageIndex
				SET @PageUpperBound = @PageLowerBound + @PageSize

				IF (@OrderBy IS NULL OR LEN(@OrderBy) < 1)
				BEGIN
					-- default order by to first column
					SET @OrderBy = '[CountryCode]'
				END

				-- SQL Server 2005 Paging
				DECLARE @SQL AS nvarchar(MAX)
				SET @SQL = 'WITH PageIndex AS ('
				SET @SQL = @SQL + ' SELECT'
				IF @PageSize > 0
				BEGIN
					SET @SQL = @SQL + ' TOP ' + CONVERT(nvarchar, @PageUpperBound)
				END
				SET @SQL = @SQL + ' ROW_NUMBER() OVER (ORDER BY ' + @OrderBy + ') as RowIndex'
				SET @SQL = @SQL + ', [CountryCode]'
				SET @SQL = @SQL + ', [Name]'
				SET @SQL = @SQL + ' FROM [dbo].[Countries]'
				IF LEN(@WhereClause) > 0
				BEGIN
					SET @SQL = @SQL + ' WHERE ' + @WhereClause
				END
				SET @SQL = @SQL + ' ) SELECT'
				SET @SQL = @SQL + ' [CountryCode],'
				SET @SQL = @SQL + ' [Name]'
				SET @SQL = @SQL + ' FROM PageIndex'
				SET @SQL = @SQL + ' WHERE RowIndex > ' + CONVERT(nvarchar, @PageLowerBound)
				IF @PageSize > 0
				BEGIN
					SET @SQL = @SQL + ' AND RowIndex <= ' + CONVERT(nvarchar, @PageUpperBound)
				END
				SET @SQL = @SQL + ' ORDER BY ' + @OrderBy
				EXEC sp_executesql @SQL
				
				-- get row count
				SET @SQL = 'SELECT COUNT(1) AS TotalRowCount'
				SET @SQL = @SQL + ' FROM [dbo].[Countries]'
				IF LEN(@WhereClause) > 0
				BEGIN
					SET @SQL = @SQL + ' WHERE ' + @WhereClause
				END
				EXEC sp_executesql @SQL
			
				END
			

GO
SET QUOTED_IDENTIFIER ON 
GO
SET NOCOUNT ON
GO
SET ANSI_NULLS OFF 
GO

	

-- Drop the dbo.Countries_Insert procedure
IF EXISTS (SELECT * FROM dbo.sysobjects WHERE id = object_id(N'dbo.Countries_Insert') AND OBJECTPROPERTY(id, N'IsProcedure') = 1)
DROP PROCEDURE dbo.Countries_Insert
GO

/*
----------------------------------------------------------------------------------------------------

-- Created By: I-Financial (www.i-financial.org)
-- Purpose: Inserts a record into the Countries table
----------------------------------------------------------------------------------------------------
*/


CREATE PROCEDURE dbo.Countries_Insert
(

	@CountryCode varchar (3)  ,

	@Name nvarchar (200)  
)
AS


				
				INSERT INTO [dbo].[Countries]
					(
					[CountryCode]
					,[Name]
					)
				VALUES
					(
					@CountryCode
					,@Name
					)
									
							
			

GO
SET QUOTED_IDENTIFIER ON 
GO
SET NOCOUNT ON
GO
SET ANSI_NULLS OFF 
GO

	

-- Drop the dbo.Countries_Update procedure
IF EXISTS (SELECT * FROM dbo.sysobjects WHERE id = object_id(N'dbo.Countries_Update') AND OBJECTPROPERTY(id, N'IsProcedure') = 1)
DROP PROCEDURE dbo.Countries_Update
GO

/*
----------------------------------------------------------------------------------------------------

-- Created By: I-Financial (www.i-financial.org)
-- Purpose: Updates a record in the Countries table
----------------------------------------------------------------------------------------------------
*/


CREATE PROCEDURE dbo.Countries_Update
(

	@CountryCode varchar (3)  ,

	@OriginalCountryCode varchar (3)  ,

	@Name nvarchar (200)  
)
AS


				
				
				-- Modify the updatable columns
				UPDATE
					[dbo].[Countries]
				SET
					[CountryCode] = @CountryCode
					,[Name] = @Name
				WHERE
[CountryCode] = @OriginalCountryCode 
				
			

GO
SET QUOTED_IDENTIFIER ON 
GO
SET NOCOUNT ON
GO
SET ANSI_NULLS OFF 
GO

	

-- Drop the dbo.Countries_Delete procedure
IF EXISTS (SELECT * FROM dbo.sysobjects WHERE id = object_id(N'dbo.Countries_Delete') AND OBJECTPROPERTY(id, N'IsProcedure') = 1)
DROP PROCEDURE dbo.Countries_Delete
GO

/*
----------------------------------------------------------------------------------------------------

-- Created By: I-Financial (www.i-financial.org)
-- Purpose: Deletes a record in the Countries table
----------------------------------------------------------------------------------------------------
*/


CREATE PROCEDURE dbo.Countries_Delete
(

	@CountryCode varchar (3)  
)
AS


				DELETE FROM [dbo].[Countries] WITH (ROWLOCK) 
				WHERE
					[CountryCode] = @CountryCode
					
			

GO
SET QUOTED_IDENTIFIER ON 
GO
SET NOCOUNT ON
GO
SET ANSI_NULLS OFF 
GO

	

-- Drop the dbo.Countries_GetByCountryCode procedure
IF EXISTS (SELECT * FROM dbo.sysobjects WHERE id = object_id(N'dbo.Countries_GetByCountryCode') AND OBJECTPROPERTY(id, N'IsProcedure') = 1)
DROP PROCEDURE dbo.Countries_GetByCountryCode
GO

/*
----------------------------------------------------------------------------------------------------

-- Created By: I-Financial (www.i-financial.org)
-- Purpose: Select records from the Countries table through an index
----------------------------------------------------------------------------------------------------
*/


CREATE PROCEDURE dbo.Countries_GetByCountryCode
(

	@CountryCode varchar (3)  
)
AS


				SELECT
					[CountryCode],
					[Name]
				FROM
					[dbo].[Countries]
				WHERE
					[CountryCode] = @CountryCode
				SELECT @@ROWCOUNT
					
			

GO
SET QUOTED_IDENTIFIER ON 
GO
SET NOCOUNT ON
GO
SET ANSI_NULLS OFF 
GO

	

-- Drop the dbo.Countries_Find procedure
IF EXISTS (SELECT * FROM dbo.sysobjects WHERE id = object_id(N'dbo.Countries_Find') AND OBJECTPROPERTY(id, N'IsProcedure') = 1)
DROP PROCEDURE dbo.Countries_Find
GO

/*
----------------------------------------------------------------------------------------------------

-- Created By: I-Financial (www.i-financial.org)
-- Purpose: Finds records in the Countries table passing nullable parameters
----------------------------------------------------------------------------------------------------
*/


CREATE PROCEDURE dbo.Countries_Find
(

	@SearchUsingOR bit   = null ,

	@CountryCode varchar (3)  = null ,

	@Name nvarchar (200)  = null 
)
AS


				
  IF ISNULL(@SearchUsingOR, 0) <> 1
  BEGIN
    SELECT
	  [CountryCode]
	, [Name]
    FROM
	[dbo].[Countries]
    WHERE 
	 ([CountryCode] = @CountryCode OR @CountryCode IS NULL)
	AND ([Name] = @Name OR @Name IS NULL)
						
  END
  ELSE
  BEGIN
    SELECT
	  [CountryCode]
	, [Name]
    FROM
	[dbo].[Countries]
    WHERE 
	 ([CountryCode] = @CountryCode AND @CountryCode is not null)
	OR ([Name] = @Name AND @Name is not null)
	SELECT @@ROWCOUNT			
  END
				

GO
SET QUOTED_IDENTIFIER ON 
GO
SET NOCOUNT ON
GO
SET ANSI_NULLS OFF 
GO

	

-- Drop the dbo.SkillLevels_Get_List procedure
IF EXISTS (SELECT * FROM dbo.sysobjects WHERE id = object_id(N'dbo.SkillLevels_Get_List') AND OBJECTPROPERTY(id, N'IsProcedure') = 1)
DROP PROCEDURE dbo.SkillLevels_Get_List
GO

/*
----------------------------------------------------------------------------------------------------

-- Created By: I-Financial (www.i-financial.org)
-- Purpose: Gets all records from the SkillLevels table
----------------------------------------------------------------------------------------------------
*/


CREATE PROCEDURE dbo.SkillLevels_Get_List

AS


				
				SELECT
					[LevelCode],
					[Name]
				FROM
					[dbo].[SkillLevels]
					
				SELECT @@ROWCOUNT
			

GO
SET QUOTED_IDENTIFIER ON 
GO
SET NOCOUNT ON
GO
SET ANSI_NULLS OFF 
GO

	

-- Drop the dbo.SkillLevels_GetPaged procedure
IF EXISTS (SELECT * FROM dbo.sysobjects WHERE id = object_id(N'dbo.SkillLevels_GetPaged') AND OBJECTPROPERTY(id, N'IsProcedure') = 1)
DROP PROCEDURE dbo.SkillLevels_GetPaged
GO

/*
----------------------------------------------------------------------------------------------------

-- Created By: I-Financial (www.i-financial.org)
-- Purpose: Gets records from the SkillLevels table passing page index and page count parameters
----------------------------------------------------------------------------------------------------
*/


CREATE PROCEDURE dbo.SkillLevels_GetPaged
(

	@WhereClause varchar (8000)  ,

	@OrderBy varchar (2000)  ,

	@PageIndex int   ,

	@PageSize int   
)
AS


				
				BEGIN
				DECLARE @PageLowerBound int
				DECLARE @PageUpperBound int
				
				-- Set the page bounds
				SET @PageLowerBound = @PageSize * @PageIndex
				SET @PageUpperBound = @PageLowerBound + @PageSize

				IF (@OrderBy IS NULL OR LEN(@OrderBy) < 1)
				BEGIN
					-- default order by to first column
					SET @OrderBy = '[LevelCode]'
				END

				-- SQL Server 2005 Paging
				DECLARE @SQL AS nvarchar(MAX)
				SET @SQL = 'WITH PageIndex AS ('
				SET @SQL = @SQL + ' SELECT'
				IF @PageSize > 0
				BEGIN
					SET @SQL = @SQL + ' TOP ' + CONVERT(nvarchar, @PageUpperBound)
				END
				SET @SQL = @SQL + ' ROW_NUMBER() OVER (ORDER BY ' + @OrderBy + ') as RowIndex'
				SET @SQL = @SQL + ', [LevelCode]'
				SET @SQL = @SQL + ', [Name]'
				SET @SQL = @SQL + ' FROM [dbo].[SkillLevels]'
				IF LEN(@WhereClause) > 0
				BEGIN
					SET @SQL = @SQL + ' WHERE ' + @WhereClause
				END
				SET @SQL = @SQL + ' ) SELECT'
				SET @SQL = @SQL + ' [LevelCode],'
				SET @SQL = @SQL + ' [Name]'
				SET @SQL = @SQL + ' FROM PageIndex'
				SET @SQL = @SQL + ' WHERE RowIndex > ' + CONVERT(nvarchar, @PageLowerBound)
				IF @PageSize > 0
				BEGIN
					SET @SQL = @SQL + ' AND RowIndex <= ' + CONVERT(nvarchar, @PageUpperBound)
				END
				SET @SQL = @SQL + ' ORDER BY ' + @OrderBy
				EXEC sp_executesql @SQL
				
				-- get row count
				SET @SQL = 'SELECT COUNT(1) AS TotalRowCount'
				SET @SQL = @SQL + ' FROM [dbo].[SkillLevels]'
				IF LEN(@WhereClause) > 0
				BEGIN
					SET @SQL = @SQL + ' WHERE ' + @WhereClause
				END
				EXEC sp_executesql @SQL
			
				END
			

GO
SET QUOTED_IDENTIFIER ON 
GO
SET NOCOUNT ON
GO
SET ANSI_NULLS OFF 
GO

	

-- Drop the dbo.SkillLevels_Insert procedure
IF EXISTS (SELECT * FROM dbo.sysobjects WHERE id = object_id(N'dbo.SkillLevels_Insert') AND OBJECTPROPERTY(id, N'IsProcedure') = 1)
DROP PROCEDURE dbo.SkillLevels_Insert
GO

/*
----------------------------------------------------------------------------------------------------

-- Created By: I-Financial (www.i-financial.org)
-- Purpose: Inserts a record into the SkillLevels table
----------------------------------------------------------------------------------------------------
*/


CREATE PROCEDURE dbo.SkillLevels_Insert
(

	@LevelCode varchar (10)  ,

	@Name nvarchar (20)  
)
AS


				
				INSERT INTO [dbo].[SkillLevels]
					(
					[LevelCode]
					,[Name]
					)
				VALUES
					(
					@LevelCode
					,@Name
					)
									
							
			

GO
SET QUOTED_IDENTIFIER ON 
GO
SET NOCOUNT ON
GO
SET ANSI_NULLS OFF 
GO

	

-- Drop the dbo.SkillLevels_Update procedure
IF EXISTS (SELECT * FROM dbo.sysobjects WHERE id = object_id(N'dbo.SkillLevels_Update') AND OBJECTPROPERTY(id, N'IsProcedure') = 1)
DROP PROCEDURE dbo.SkillLevels_Update
GO

/*
----------------------------------------------------------------------------------------------------

-- Created By: I-Financial (www.i-financial.org)
-- Purpose: Updates a record in the SkillLevels table
----------------------------------------------------------------------------------------------------
*/


CREATE PROCEDURE dbo.SkillLevels_Update
(

	@LevelCode varchar (10)  ,

	@OriginalLevelCode varchar (10)  ,

	@Name nvarchar (20)  
)
AS


				
				
				-- Modify the updatable columns
				UPDATE
					[dbo].[SkillLevels]
				SET
					[LevelCode] = @LevelCode
					,[Name] = @Name
				WHERE
[LevelCode] = @OriginalLevelCode 
				
			

GO
SET QUOTED_IDENTIFIER ON 
GO
SET NOCOUNT ON
GO
SET ANSI_NULLS OFF 
GO

	

-- Drop the dbo.SkillLevels_Delete procedure
IF EXISTS (SELECT * FROM dbo.sysobjects WHERE id = object_id(N'dbo.SkillLevels_Delete') AND OBJECTPROPERTY(id, N'IsProcedure') = 1)
DROP PROCEDURE dbo.SkillLevels_Delete
GO

/*
----------------------------------------------------------------------------------------------------

-- Created By: I-Financial (www.i-financial.org)
-- Purpose: Deletes a record in the SkillLevels table
----------------------------------------------------------------------------------------------------
*/


CREATE PROCEDURE dbo.SkillLevels_Delete
(

	@LevelCode varchar (10)  
)
AS


				DELETE FROM [dbo].[SkillLevels] WITH (ROWLOCK) 
				WHERE
					[LevelCode] = @LevelCode
					
			

GO
SET QUOTED_IDENTIFIER ON 
GO
SET NOCOUNT ON
GO
SET ANSI_NULLS OFF 
GO

	

-- Drop the dbo.SkillLevels_GetByLevelCode procedure
IF EXISTS (SELECT * FROM dbo.sysobjects WHERE id = object_id(N'dbo.SkillLevels_GetByLevelCode') AND OBJECTPROPERTY(id, N'IsProcedure') = 1)
DROP PROCEDURE dbo.SkillLevels_GetByLevelCode
GO

/*
----------------------------------------------------------------------------------------------------

-- Created By: I-Financial (www.i-financial.org)
-- Purpose: Select records from the SkillLevels table through an index
----------------------------------------------------------------------------------------------------
*/


CREATE PROCEDURE dbo.SkillLevels_GetByLevelCode
(

	@LevelCode varchar (10)  
)
AS


				SELECT
					[LevelCode],
					[Name]
				FROM
					[dbo].[SkillLevels]
				WHERE
					[LevelCode] = @LevelCode
				SELECT @@ROWCOUNT
					
			

GO
SET QUOTED_IDENTIFIER ON 
GO
SET NOCOUNT ON
GO
SET ANSI_NULLS OFF 
GO

	

-- Drop the dbo.SkillLevels_Find procedure
IF EXISTS (SELECT * FROM dbo.sysobjects WHERE id = object_id(N'dbo.SkillLevels_Find') AND OBJECTPROPERTY(id, N'IsProcedure') = 1)
DROP PROCEDURE dbo.SkillLevels_Find
GO

/*
----------------------------------------------------------------------------------------------------

-- Created By: I-Financial (www.i-financial.org)
-- Purpose: Finds records in the SkillLevels table passing nullable parameters
----------------------------------------------------------------------------------------------------
*/


CREATE PROCEDURE dbo.SkillLevels_Find
(

	@SearchUsingOR bit   = null ,

	@LevelCode varchar (10)  = null ,

	@Name nvarchar (20)  = null 
)
AS


				
  IF ISNULL(@SearchUsingOR, 0) <> 1
  BEGIN
    SELECT
	  [LevelCode]
	, [Name]
    FROM
	[dbo].[SkillLevels]
    WHERE 
	 ([LevelCode] = @LevelCode OR @LevelCode IS NULL)
	AND ([Name] = @Name OR @Name IS NULL)
						
  END
  ELSE
  BEGIN
    SELECT
	  [LevelCode]
	, [Name]
    FROM
	[dbo].[SkillLevels]
    WHERE 
	 ([LevelCode] = @LevelCode AND @LevelCode is not null)
	OR ([Name] = @Name AND @Name is not null)
	SELECT @@ROWCOUNT			
  END
				

GO
SET QUOTED_IDENTIFIER ON 
GO
SET NOCOUNT ON
GO
SET ANSI_NULLS OFF 
GO

	

-- Drop the dbo.Skill_Get_List procedure
IF EXISTS (SELECT * FROM dbo.sysobjects WHERE id = object_id(N'dbo.Skill_Get_List') AND OBJECTPROPERTY(id, N'IsProcedure') = 1)
DROP PROCEDURE dbo.Skill_Get_List
GO

/*
----------------------------------------------------------------------------------------------------

-- Created By: I-Financial (www.i-financial.org)
-- Purpose: Gets all records from the Skill table
----------------------------------------------------------------------------------------------------
*/


CREATE PROCEDURE dbo.Skill_Get_List

AS


				
				SELECT
					[SkillCode],
					[Name],
					[Category]
				FROM
					[dbo].[Skill]
					
				SELECT @@ROWCOUNT
			

GO
SET QUOTED_IDENTIFIER ON 
GO
SET NOCOUNT ON
GO
SET ANSI_NULLS OFF 
GO

	

-- Drop the dbo.Skill_GetPaged procedure
IF EXISTS (SELECT * FROM dbo.sysobjects WHERE id = object_id(N'dbo.Skill_GetPaged') AND OBJECTPROPERTY(id, N'IsProcedure') = 1)
DROP PROCEDURE dbo.Skill_GetPaged
GO

/*
----------------------------------------------------------------------------------------------------

-- Created By: I-Financial (www.i-financial.org)
-- Purpose: Gets records from the Skill table passing page index and page count parameters
----------------------------------------------------------------------------------------------------
*/


CREATE PROCEDURE dbo.Skill_GetPaged
(

	@WhereClause varchar (8000)  ,

	@OrderBy varchar (2000)  ,

	@PageIndex int   ,

	@PageSize int   
)
AS


				
				BEGIN
				DECLARE @PageLowerBound int
				DECLARE @PageUpperBound int
				
				-- Set the page bounds
				SET @PageLowerBound = @PageSize * @PageIndex
				SET @PageUpperBound = @PageLowerBound + @PageSize

				IF (@OrderBy IS NULL OR LEN(@OrderBy) < 1)
				BEGIN
					-- default order by to first column
					SET @OrderBy = '[SkillCode]'
				END

				-- SQL Server 2005 Paging
				DECLARE @SQL AS nvarchar(MAX)
				SET @SQL = 'WITH PageIndex AS ('
				SET @SQL = @SQL + ' SELECT'
				IF @PageSize > 0
				BEGIN
					SET @SQL = @SQL + ' TOP ' + CONVERT(nvarchar, @PageUpperBound)
				END
				SET @SQL = @SQL + ' ROW_NUMBER() OVER (ORDER BY ' + @OrderBy + ') as RowIndex'
				SET @SQL = @SQL + ', [SkillCode]'
				SET @SQL = @SQL + ', [Name]'
				SET @SQL = @SQL + ', [Category]'
				SET @SQL = @SQL + ' FROM [dbo].[Skill]'
				IF LEN(@WhereClause) > 0
				BEGIN
					SET @SQL = @SQL + ' WHERE ' + @WhereClause
				END
				SET @SQL = @SQL + ' ) SELECT'
				SET @SQL = @SQL + ' [SkillCode],'
				SET @SQL = @SQL + ' [Name],'
				SET @SQL = @SQL + ' [Category]'
				SET @SQL = @SQL + ' FROM PageIndex'
				SET @SQL = @SQL + ' WHERE RowIndex > ' + CONVERT(nvarchar, @PageLowerBound)
				IF @PageSize > 0
				BEGIN
					SET @SQL = @SQL + ' AND RowIndex <= ' + CONVERT(nvarchar, @PageUpperBound)
				END
				SET @SQL = @SQL + ' ORDER BY ' + @OrderBy
				EXEC sp_executesql @SQL
				
				-- get row count
				SET @SQL = 'SELECT COUNT(1) AS TotalRowCount'
				SET @SQL = @SQL + ' FROM [dbo].[Skill]'
				IF LEN(@WhereClause) > 0
				BEGIN
					SET @SQL = @SQL + ' WHERE ' + @WhereClause
				END
				EXEC sp_executesql @SQL
			
				END
			

GO
SET QUOTED_IDENTIFIER ON 
GO
SET NOCOUNT ON
GO
SET ANSI_NULLS OFF 
GO

	

-- Drop the dbo.Skill_Insert procedure
IF EXISTS (SELECT * FROM dbo.sysobjects WHERE id = object_id(N'dbo.Skill_Insert') AND OBJECTPROPERTY(id, N'IsProcedure') = 1)
DROP PROCEDURE dbo.Skill_Insert
GO

/*
----------------------------------------------------------------------------------------------------

-- Created By: I-Financial (www.i-financial.org)
-- Purpose: Inserts a record into the Skill table
----------------------------------------------------------------------------------------------------
*/


CREATE PROCEDURE dbo.Skill_Insert
(

	@SkillCode varchar (10)  ,

	@Name nvarchar (100)  ,

	@Category nvarchar (50)  
)
AS


				
				INSERT INTO [dbo].[Skill]
					(
					[SkillCode]
					,[Name]
					,[Category]
					)
				VALUES
					(
					@SkillCode
					,@Name
					,@Category
					)
									
							
			

GO
SET QUOTED_IDENTIFIER ON 
GO
SET NOCOUNT ON
GO
SET ANSI_NULLS OFF 
GO

	

-- Drop the dbo.Skill_Update procedure
IF EXISTS (SELECT * FROM dbo.sysobjects WHERE id = object_id(N'dbo.Skill_Update') AND OBJECTPROPERTY(id, N'IsProcedure') = 1)
DROP PROCEDURE dbo.Skill_Update
GO

/*
----------------------------------------------------------------------------------------------------

-- Created By: I-Financial (www.i-financial.org)
-- Purpose: Updates a record in the Skill table
----------------------------------------------------------------------------------------------------
*/


CREATE PROCEDURE dbo.Skill_Update
(

	@SkillCode varchar (10)  ,

	@OriginalSkillCode varchar (10)  ,

	@Name nvarchar (100)  ,

	@Category nvarchar (50)  
)
AS


				
				
				-- Modify the updatable columns
				UPDATE
					[dbo].[Skill]
				SET
					[SkillCode] = @SkillCode
					,[Name] = @Name
					,[Category] = @Category
				WHERE
[SkillCode] = @OriginalSkillCode 
				
			

GO
SET QUOTED_IDENTIFIER ON 
GO
SET NOCOUNT ON
GO
SET ANSI_NULLS OFF 
GO

	

-- Drop the dbo.Skill_Delete procedure
IF EXISTS (SELECT * FROM dbo.sysobjects WHERE id = object_id(N'dbo.Skill_Delete') AND OBJECTPROPERTY(id, N'IsProcedure') = 1)
DROP PROCEDURE dbo.Skill_Delete
GO

/*
----------------------------------------------------------------------------------------------------

-- Created By: I-Financial (www.i-financial.org)
-- Purpose: Deletes a record in the Skill table
----------------------------------------------------------------------------------------------------
*/


CREATE PROCEDURE dbo.Skill_Delete
(

	@SkillCode varchar (10)  
)
AS


				DELETE FROM [dbo].[Skill] WITH (ROWLOCK) 
				WHERE
					[SkillCode] = @SkillCode
					
			

GO
SET QUOTED_IDENTIFIER ON 
GO
SET NOCOUNT ON
GO
SET ANSI_NULLS OFF 
GO

	

-- Drop the dbo.Skill_GetBySkillCode procedure
IF EXISTS (SELECT * FROM dbo.sysobjects WHERE id = object_id(N'dbo.Skill_GetBySkillCode') AND OBJECTPROPERTY(id, N'IsProcedure') = 1)
DROP PROCEDURE dbo.Skill_GetBySkillCode
GO

/*
----------------------------------------------------------------------------------------------------

-- Created By: I-Financial (www.i-financial.org)
-- Purpose: Select records from the Skill table through an index
----------------------------------------------------------------------------------------------------
*/


CREATE PROCEDURE dbo.Skill_GetBySkillCode
(

	@SkillCode varchar (10)  
)
AS


				SELECT
					[SkillCode],
					[Name],
					[Category]
				FROM
					[dbo].[Skill]
				WHERE
					[SkillCode] = @SkillCode
				SELECT @@ROWCOUNT
					
			

GO
SET QUOTED_IDENTIFIER ON 
GO
SET NOCOUNT ON
GO
SET ANSI_NULLS OFF 
GO

	

-- Drop the dbo.Skill_Find procedure
IF EXISTS (SELECT * FROM dbo.sysobjects WHERE id = object_id(N'dbo.Skill_Find') AND OBJECTPROPERTY(id, N'IsProcedure') = 1)
DROP PROCEDURE dbo.Skill_Find
GO

/*
----------------------------------------------------------------------------------------------------

-- Created By: I-Financial (www.i-financial.org)
-- Purpose: Finds records in the Skill table passing nullable parameters
----------------------------------------------------------------------------------------------------
*/


CREATE PROCEDURE dbo.Skill_Find
(

	@SearchUsingOR bit   = null ,

	@SkillCode varchar (10)  = null ,

	@Name nvarchar (100)  = null ,

	@Category nvarchar (50)  = null 
)
AS


				
  IF ISNULL(@SearchUsingOR, 0) <> 1
  BEGIN
    SELECT
	  [SkillCode]
	, [Name]
	, [Category]
    FROM
	[dbo].[Skill]
    WHERE 
	 ([SkillCode] = @SkillCode OR @SkillCode IS NULL)
	AND ([Name] = @Name OR @Name IS NULL)
	AND ([Category] = @Category OR @Category IS NULL)
						
  END
  ELSE
  BEGIN
    SELECT
	  [SkillCode]
	, [Name]
	, [Category]
    FROM
	[dbo].[Skill]
    WHERE 
	 ([SkillCode] = @SkillCode AND @SkillCode is not null)
	OR ([Name] = @Name AND @Name is not null)
	OR ([Category] = @Category AND @Category is not null)
	SELECT @@ROWCOUNT			
  END
				

GO
SET QUOTED_IDENTIFIER ON 
GO
SET NOCOUNT ON
GO
SET ANSI_NULLS OFF 
GO

	

-- Drop the dbo.BankAccounts_Get_List procedure
IF EXISTS (SELECT * FROM dbo.sysobjects WHERE id = object_id(N'dbo.BankAccounts_Get_List') AND OBJECTPROPERTY(id, N'IsProcedure') = 1)
DROP PROCEDURE dbo.BankAccounts_Get_List
GO

/*
----------------------------------------------------------------------------------------------------

-- Created By: I-Financial (www.i-financial.org)
-- Purpose: Gets all records from the BankAccounts table
----------------------------------------------------------------------------------------------------
*/


CREATE PROCEDURE dbo.BankAccounts_Get_List

AS


				
				SELECT
					[BankAccountId],
					[EmployeeId],
					[BankName],
					[AccountNumber],
					[CreatedOn]
				FROM
					[dbo].[BankAccounts]
					
				SELECT @@ROWCOUNT
			

GO
SET QUOTED_IDENTIFIER ON 
GO
SET NOCOUNT ON
GO
SET ANSI_NULLS OFF 
GO

	

-- Drop the dbo.BankAccounts_GetPaged procedure
IF EXISTS (SELECT * FROM dbo.sysobjects WHERE id = object_id(N'dbo.BankAccounts_GetPaged') AND OBJECTPROPERTY(id, N'IsProcedure') = 1)
DROP PROCEDURE dbo.BankAccounts_GetPaged
GO

/*
----------------------------------------------------------------------------------------------------

-- Created By: I-Financial (www.i-financial.org)
-- Purpose: Gets records from the BankAccounts table passing page index and page count parameters
----------------------------------------------------------------------------------------------------
*/


CREATE PROCEDURE dbo.BankAccounts_GetPaged
(

	@WhereClause varchar (8000)  ,

	@OrderBy varchar (2000)  ,

	@PageIndex int   ,

	@PageSize int   
)
AS


				
				BEGIN
				DECLARE @PageLowerBound int
				DECLARE @PageUpperBound int
				
				-- Set the page bounds
				SET @PageLowerBound = @PageSize * @PageIndex
				SET @PageUpperBound = @PageLowerBound + @PageSize

				IF (@OrderBy IS NULL OR LEN(@OrderBy) < 1)
				BEGIN
					-- default order by to first column
					SET @OrderBy = '[BankAccountId]'
				END

				-- SQL Server 2005 Paging
				DECLARE @SQL AS nvarchar(MAX)
				SET @SQL = 'WITH PageIndex AS ('
				SET @SQL = @SQL + ' SELECT'
				IF @PageSize > 0
				BEGIN
					SET @SQL = @SQL + ' TOP ' + CONVERT(nvarchar, @PageUpperBound)
				END
				SET @SQL = @SQL + ' ROW_NUMBER() OVER (ORDER BY ' + @OrderBy + ') as RowIndex'
				SET @SQL = @SQL + ', [BankAccountId]'
				SET @SQL = @SQL + ', [EmployeeId]'
				SET @SQL = @SQL + ', [BankName]'
				SET @SQL = @SQL + ', [AccountNumber]'
				SET @SQL = @SQL + ', [CreatedOn]'
				SET @SQL = @SQL + ' FROM [dbo].[BankAccounts]'
				IF LEN(@WhereClause) > 0
				BEGIN
					SET @SQL = @SQL + ' WHERE ' + @WhereClause
				END
				SET @SQL = @SQL + ' ) SELECT'
				SET @SQL = @SQL + ' [BankAccountId],'
				SET @SQL = @SQL + ' [EmployeeId],'
				SET @SQL = @SQL + ' [BankName],'
				SET @SQL = @SQL + ' [AccountNumber],'
				SET @SQL = @SQL + ' [CreatedOn]'
				SET @SQL = @SQL + ' FROM PageIndex'
				SET @SQL = @SQL + ' WHERE RowIndex > ' + CONVERT(nvarchar, @PageLowerBound)
				IF @PageSize > 0
				BEGIN
					SET @SQL = @SQL + ' AND RowIndex <= ' + CONVERT(nvarchar, @PageUpperBound)
				END
				SET @SQL = @SQL + ' ORDER BY ' + @OrderBy
				EXEC sp_executesql @SQL
				
				-- get row count
				SET @SQL = 'SELECT COUNT(1) AS TotalRowCount'
				SET @SQL = @SQL + ' FROM [dbo].[BankAccounts]'
				IF LEN(@WhereClause) > 0
				BEGIN
					SET @SQL = @SQL + ' WHERE ' + @WhereClause
				END
				EXEC sp_executesql @SQL
			
				END
			

GO
SET QUOTED_IDENTIFIER ON 
GO
SET NOCOUNT ON
GO
SET ANSI_NULLS OFF 
GO

	

-- Drop the dbo.BankAccounts_Insert procedure
IF EXISTS (SELECT * FROM dbo.sysobjects WHERE id = object_id(N'dbo.BankAccounts_Insert') AND OBJECTPROPERTY(id, N'IsProcedure') = 1)
DROP PROCEDURE dbo.BankAccounts_Insert
GO

/*
----------------------------------------------------------------------------------------------------

-- Created By: I-Financial (www.i-financial.org)
-- Purpose: Inserts a record into the BankAccounts table
----------------------------------------------------------------------------------------------------
*/


CREATE PROCEDURE dbo.BankAccounts_Insert
(

	@BankAccountId int    OUTPUT,

	@EmployeeId int   ,

	@BankName nvarchar (50)  ,

	@AccountNumber varchar (50)  ,

	@CreatedOn datetime   
)
AS


				
				INSERT INTO [dbo].[BankAccounts]
					(
					[EmployeeId]
					,[BankName]
					,[AccountNumber]
					,[CreatedOn]
					)
				VALUES
					(
					@EmployeeId
					,@BankName
					,@AccountNumber
					,@CreatedOn
					)
				-- Get the identity value
				SET @BankAccountId = SCOPE_IDENTITY()
									
							
			

GO
SET QUOTED_IDENTIFIER ON 
GO
SET NOCOUNT ON
GO
SET ANSI_NULLS OFF 
GO

	

-- Drop the dbo.BankAccounts_Update procedure
IF EXISTS (SELECT * FROM dbo.sysobjects WHERE id = object_id(N'dbo.BankAccounts_Update') AND OBJECTPROPERTY(id, N'IsProcedure') = 1)
DROP PROCEDURE dbo.BankAccounts_Update
GO

/*
----------------------------------------------------------------------------------------------------

-- Created By: I-Financial (www.i-financial.org)
-- Purpose: Updates a record in the BankAccounts table
----------------------------------------------------------------------------------------------------
*/


CREATE PROCEDURE dbo.BankAccounts_Update
(

	@BankAccountId int   ,

	@EmployeeId int   ,

	@BankName nvarchar (50)  ,

	@AccountNumber varchar (50)  ,

	@CreatedOn datetime   
)
AS


				
				
				-- Modify the updatable columns
				UPDATE
					[dbo].[BankAccounts]
				SET
					[EmployeeId] = @EmployeeId
					,[BankName] = @BankName
					,[AccountNumber] = @AccountNumber
					,[CreatedOn] = @CreatedOn
				WHERE
[BankAccountId] = @BankAccountId 
				
			

GO
SET QUOTED_IDENTIFIER ON 
GO
SET NOCOUNT ON
GO
SET ANSI_NULLS OFF 
GO

	

-- Drop the dbo.BankAccounts_Delete procedure
IF EXISTS (SELECT * FROM dbo.sysobjects WHERE id = object_id(N'dbo.BankAccounts_Delete') AND OBJECTPROPERTY(id, N'IsProcedure') = 1)
DROP PROCEDURE dbo.BankAccounts_Delete
GO

/*
----------------------------------------------------------------------------------------------------

-- Created By: I-Financial (www.i-financial.org)
-- Purpose: Deletes a record in the BankAccounts table
----------------------------------------------------------------------------------------------------
*/


CREATE PROCEDURE dbo.BankAccounts_Delete
(

	@BankAccountId int   
)
AS


				DELETE FROM [dbo].[BankAccounts] WITH (ROWLOCK) 
				WHERE
					[BankAccountId] = @BankAccountId
					
			

GO
SET QUOTED_IDENTIFIER ON 
GO
SET NOCOUNT ON
GO
SET ANSI_NULLS OFF 
GO

	

-- Drop the dbo.BankAccounts_GetByEmployeeId procedure
IF EXISTS (SELECT * FROM dbo.sysobjects WHERE id = object_id(N'dbo.BankAccounts_GetByEmployeeId') AND OBJECTPROPERTY(id, N'IsProcedure') = 1)
DROP PROCEDURE dbo.BankAccounts_GetByEmployeeId
GO

/*
----------------------------------------------------------------------------------------------------

-- Created By: I-Financial (www.i-financial.org)
-- Purpose: Select records from the BankAccounts table through a foreign key
----------------------------------------------------------------------------------------------------
*/


CREATE PROCEDURE dbo.BankAccounts_GetByEmployeeId
(

	@EmployeeId int   
)
AS


				SET ANSI_NULLS OFF
				
				SELECT
					[BankAccountId],
					[EmployeeId],
					[BankName],
					[AccountNumber],
					[CreatedOn]
				FROM
					[dbo].[BankAccounts]
				WHERE
					[EmployeeId] = @EmployeeId
				
				SELECT @@ROWCOUNT
				SET ANSI_NULLS ON
			

GO
SET QUOTED_IDENTIFIER ON 
GO
SET NOCOUNT ON
GO
SET ANSI_NULLS OFF 
GO

	

-- Drop the dbo.BankAccounts_GetByBankAccountId procedure
IF EXISTS (SELECT * FROM dbo.sysobjects WHERE id = object_id(N'dbo.BankAccounts_GetByBankAccountId') AND OBJECTPROPERTY(id, N'IsProcedure') = 1)
DROP PROCEDURE dbo.BankAccounts_GetByBankAccountId
GO

/*
----------------------------------------------------------------------------------------------------

-- Created By: I-Financial (www.i-financial.org)
-- Purpose: Select records from the BankAccounts table through an index
----------------------------------------------------------------------------------------------------
*/


CREATE PROCEDURE dbo.BankAccounts_GetByBankAccountId
(

	@BankAccountId int   
)
AS


				SELECT
					[BankAccountId],
					[EmployeeId],
					[BankName],
					[AccountNumber],
					[CreatedOn]
				FROM
					[dbo].[BankAccounts]
				WHERE
					[BankAccountId] = @BankAccountId
				SELECT @@ROWCOUNT
					
			

GO
SET QUOTED_IDENTIFIER ON 
GO
SET NOCOUNT ON
GO
SET ANSI_NULLS OFF 
GO

	

-- Drop the dbo.BankAccounts_Find procedure
IF EXISTS (SELECT * FROM dbo.sysobjects WHERE id = object_id(N'dbo.BankAccounts_Find') AND OBJECTPROPERTY(id, N'IsProcedure') = 1)
DROP PROCEDURE dbo.BankAccounts_Find
GO

/*
----------------------------------------------------------------------------------------------------

-- Created By: I-Financial (www.i-financial.org)
-- Purpose: Finds records in the BankAccounts table passing nullable parameters
----------------------------------------------------------------------------------------------------
*/


CREATE PROCEDURE dbo.BankAccounts_Find
(

	@SearchUsingOR bit   = null ,

	@BankAccountId int   = null ,

	@EmployeeId int   = null ,

	@BankName nvarchar (50)  = null ,

	@AccountNumber varchar (50)  = null ,

	@CreatedOn datetime   = null 
)
AS


				
  IF ISNULL(@SearchUsingOR, 0) <> 1
  BEGIN
    SELECT
	  [BankAccountId]
	, [EmployeeId]
	, [BankName]
	, [AccountNumber]
	, [CreatedOn]
    FROM
	[dbo].[BankAccounts]
    WHERE 
	 ([BankAccountId] = @BankAccountId OR @BankAccountId IS NULL)
	AND ([EmployeeId] = @EmployeeId OR @EmployeeId IS NULL)
	AND ([BankName] = @BankName OR @BankName IS NULL)
	AND ([AccountNumber] = @AccountNumber OR @AccountNumber IS NULL)
	AND ([CreatedOn] = @CreatedOn OR @CreatedOn IS NULL)
						
  END
  ELSE
  BEGIN
    SELECT
	  [BankAccountId]
	, [EmployeeId]
	, [BankName]
	, [AccountNumber]
	, [CreatedOn]
    FROM
	[dbo].[BankAccounts]
    WHERE 
	 ([BankAccountId] = @BankAccountId AND @BankAccountId is not null)
	OR ([EmployeeId] = @EmployeeId AND @EmployeeId is not null)
	OR ([BankName] = @BankName AND @BankName is not null)
	OR ([AccountNumber] = @AccountNumber AND @AccountNumber is not null)
	OR ([CreatedOn] = @CreatedOn AND @CreatedOn is not null)
	SELECT @@ROWCOUNT			
  END
				

GO
SET QUOTED_IDENTIFIER ON 
GO
SET NOCOUNT ON
GO
SET ANSI_NULLS OFF 
GO

	

-- Drop the dbo.EmployeeSalary_Get_List procedure
IF EXISTS (SELECT * FROM dbo.sysobjects WHERE id = object_id(N'dbo.EmployeeSalary_Get_List') AND OBJECTPROPERTY(id, N'IsProcedure') = 1)
DROP PROCEDURE dbo.EmployeeSalary_Get_List
GO

/*
----------------------------------------------------------------------------------------------------

-- Created By: I-Financial (www.i-financial.org)
-- Purpose: Gets all records from the EmployeeSalary table
----------------------------------------------------------------------------------------------------
*/


CREATE PROCEDURE dbo.EmployeeSalary_Get_List

AS


				
				SELECT
					[EmployeeSalaryId],
					[EmployeeId],
					[SalaryAmount],
					[ApprovedOn],
					[ApprovedBy],
					[IsActive]
				FROM
					[dbo].[EmployeeSalary]
					
				SELECT @@ROWCOUNT
			

GO
SET QUOTED_IDENTIFIER ON 
GO
SET NOCOUNT ON
GO
SET ANSI_NULLS OFF 
GO

	

-- Drop the dbo.EmployeeSalary_GetPaged procedure
IF EXISTS (SELECT * FROM dbo.sysobjects WHERE id = object_id(N'dbo.EmployeeSalary_GetPaged') AND OBJECTPROPERTY(id, N'IsProcedure') = 1)
DROP PROCEDURE dbo.EmployeeSalary_GetPaged
GO

/*
----------------------------------------------------------------------------------------------------

-- Created By: I-Financial (www.i-financial.org)
-- Purpose: Gets records from the EmployeeSalary table passing page index and page count parameters
----------------------------------------------------------------------------------------------------
*/


CREATE PROCEDURE dbo.EmployeeSalary_GetPaged
(

	@WhereClause varchar (8000)  ,

	@OrderBy varchar (2000)  ,

	@PageIndex int   ,

	@PageSize int   
)
AS


				
				BEGIN
				DECLARE @PageLowerBound int
				DECLARE @PageUpperBound int
				
				-- Set the page bounds
				SET @PageLowerBound = @PageSize * @PageIndex
				SET @PageUpperBound = @PageLowerBound + @PageSize

				IF (@OrderBy IS NULL OR LEN(@OrderBy) < 1)
				BEGIN
					-- default order by to first column
					SET @OrderBy = '[EmployeeSalaryId]'
				END

				-- SQL Server 2005 Paging
				DECLARE @SQL AS nvarchar(MAX)
				SET @SQL = 'WITH PageIndex AS ('
				SET @SQL = @SQL + ' SELECT'
				IF @PageSize > 0
				BEGIN
					SET @SQL = @SQL + ' TOP ' + CONVERT(nvarchar, @PageUpperBound)
				END
				SET @SQL = @SQL + ' ROW_NUMBER() OVER (ORDER BY ' + @OrderBy + ') as RowIndex'
				SET @SQL = @SQL + ', [EmployeeSalaryId]'
				SET @SQL = @SQL + ', [EmployeeId]'
				SET @SQL = @SQL + ', [SalaryAmount]'
				SET @SQL = @SQL + ', [ApprovedOn]'
				SET @SQL = @SQL + ', [ApprovedBy]'
				SET @SQL = @SQL + ', [IsActive]'
				SET @SQL = @SQL + ' FROM [dbo].[EmployeeSalary]'
				IF LEN(@WhereClause) > 0
				BEGIN
					SET @SQL = @SQL + ' WHERE ' + @WhereClause
				END
				SET @SQL = @SQL + ' ) SELECT'
				SET @SQL = @SQL + ' [EmployeeSalaryId],'
				SET @SQL = @SQL + ' [EmployeeId],'
				SET @SQL = @SQL + ' [SalaryAmount],'
				SET @SQL = @SQL + ' [ApprovedOn],'
				SET @SQL = @SQL + ' [ApprovedBy],'
				SET @SQL = @SQL + ' [IsActive]'
				SET @SQL = @SQL + ' FROM PageIndex'
				SET @SQL = @SQL + ' WHERE RowIndex > ' + CONVERT(nvarchar, @PageLowerBound)
				IF @PageSize > 0
				BEGIN
					SET @SQL = @SQL + ' AND RowIndex <= ' + CONVERT(nvarchar, @PageUpperBound)
				END
				SET @SQL = @SQL + ' ORDER BY ' + @OrderBy
				EXEC sp_executesql @SQL
				
				-- get row count
				SET @SQL = 'SELECT COUNT(1) AS TotalRowCount'
				SET @SQL = @SQL + ' FROM [dbo].[EmployeeSalary]'
				IF LEN(@WhereClause) > 0
				BEGIN
					SET @SQL = @SQL + ' WHERE ' + @WhereClause
				END
				EXEC sp_executesql @SQL
			
				END
			

GO
SET QUOTED_IDENTIFIER ON 
GO
SET NOCOUNT ON
GO
SET ANSI_NULLS OFF 
GO

	

-- Drop the dbo.EmployeeSalary_Insert procedure
IF EXISTS (SELECT * FROM dbo.sysobjects WHERE id = object_id(N'dbo.EmployeeSalary_Insert') AND OBJECTPROPERTY(id, N'IsProcedure') = 1)
DROP PROCEDURE dbo.EmployeeSalary_Insert
GO

/*
----------------------------------------------------------------------------------------------------

-- Created By: I-Financial (www.i-financial.org)
-- Purpose: Inserts a record into the EmployeeSalary table
----------------------------------------------------------------------------------------------------
*/


CREATE PROCEDURE dbo.EmployeeSalary_Insert
(

	@EmployeeSalaryId int    OUTPUT,

	@EmployeeId int   ,

	@SalaryAmount decimal (18, 2)  ,

	@ApprovedOn datetime   ,

	@ApprovedBy varchar (50)  ,

	@IsActive bit   
)
AS


				
				INSERT INTO [dbo].[EmployeeSalary]
					(
					[EmployeeId]
					,[SalaryAmount]
					,[ApprovedOn]
					,[ApprovedBy]
					,[IsActive]
					)
				VALUES
					(
					@EmployeeId
					,@SalaryAmount
					,@ApprovedOn
					,@ApprovedBy
					,@IsActive
					)
				-- Get the identity value
				SET @EmployeeSalaryId = SCOPE_IDENTITY()
									
							
			

GO
SET QUOTED_IDENTIFIER ON 
GO
SET NOCOUNT ON
GO
SET ANSI_NULLS OFF 
GO

	

-- Drop the dbo.EmployeeSalary_Update procedure
IF EXISTS (SELECT * FROM dbo.sysobjects WHERE id = object_id(N'dbo.EmployeeSalary_Update') AND OBJECTPROPERTY(id, N'IsProcedure') = 1)
DROP PROCEDURE dbo.EmployeeSalary_Update
GO

/*
----------------------------------------------------------------------------------------------------

-- Created By: I-Financial (www.i-financial.org)
-- Purpose: Updates a record in the EmployeeSalary table
----------------------------------------------------------------------------------------------------
*/


CREATE PROCEDURE dbo.EmployeeSalary_Update
(

	@EmployeeSalaryId int   ,

	@EmployeeId int   ,

	@SalaryAmount decimal (18, 2)  ,

	@ApprovedOn datetime   ,

	@ApprovedBy varchar (50)  ,

	@IsActive bit   
)
AS


				
				
				-- Modify the updatable columns
				UPDATE
					[dbo].[EmployeeSalary]
				SET
					[EmployeeId] = @EmployeeId
					,[SalaryAmount] = @SalaryAmount
					,[ApprovedOn] = @ApprovedOn
					,[ApprovedBy] = @ApprovedBy
					,[IsActive] = @IsActive
				WHERE
[EmployeeSalaryId] = @EmployeeSalaryId 
				
			

GO
SET QUOTED_IDENTIFIER ON 
GO
SET NOCOUNT ON
GO
SET ANSI_NULLS OFF 
GO

	

-- Drop the dbo.EmployeeSalary_Delete procedure
IF EXISTS (SELECT * FROM dbo.sysobjects WHERE id = object_id(N'dbo.EmployeeSalary_Delete') AND OBJECTPROPERTY(id, N'IsProcedure') = 1)
DROP PROCEDURE dbo.EmployeeSalary_Delete
GO

/*
----------------------------------------------------------------------------------------------------

-- Created By: I-Financial (www.i-financial.org)
-- Purpose: Deletes a record in the EmployeeSalary table
----------------------------------------------------------------------------------------------------
*/


CREATE PROCEDURE dbo.EmployeeSalary_Delete
(

	@EmployeeSalaryId int   
)
AS


				DELETE FROM [dbo].[EmployeeSalary] WITH (ROWLOCK) 
				WHERE
					[EmployeeSalaryId] = @EmployeeSalaryId
					
			

GO
SET QUOTED_IDENTIFIER ON 
GO
SET NOCOUNT ON
GO
SET ANSI_NULLS OFF 
GO

	

-- Drop the dbo.EmployeeSalary_GetByEmployeeId procedure
IF EXISTS (SELECT * FROM dbo.sysobjects WHERE id = object_id(N'dbo.EmployeeSalary_GetByEmployeeId') AND OBJECTPROPERTY(id, N'IsProcedure') = 1)
DROP PROCEDURE dbo.EmployeeSalary_GetByEmployeeId
GO

/*
----------------------------------------------------------------------------------------------------

-- Created By: I-Financial (www.i-financial.org)
-- Purpose: Select records from the EmployeeSalary table through a foreign key
----------------------------------------------------------------------------------------------------
*/


CREATE PROCEDURE dbo.EmployeeSalary_GetByEmployeeId
(

	@EmployeeId int   
)
AS


				SET ANSI_NULLS OFF
				
				SELECT
					[EmployeeSalaryId],
					[EmployeeId],
					[SalaryAmount],
					[ApprovedOn],
					[ApprovedBy],
					[IsActive]
				FROM
					[dbo].[EmployeeSalary]
				WHERE
					[EmployeeId] = @EmployeeId
				
				SELECT @@ROWCOUNT
				SET ANSI_NULLS ON
			

GO
SET QUOTED_IDENTIFIER ON 
GO
SET NOCOUNT ON
GO
SET ANSI_NULLS OFF 
GO

	

-- Drop the dbo.EmployeeSalary_GetByEmployeeSalaryId procedure
IF EXISTS (SELECT * FROM dbo.sysobjects WHERE id = object_id(N'dbo.EmployeeSalary_GetByEmployeeSalaryId') AND OBJECTPROPERTY(id, N'IsProcedure') = 1)
DROP PROCEDURE dbo.EmployeeSalary_GetByEmployeeSalaryId
GO

/*
----------------------------------------------------------------------------------------------------

-- Created By: I-Financial (www.i-financial.org)
-- Purpose: Select records from the EmployeeSalary table through an index
----------------------------------------------------------------------------------------------------
*/


CREATE PROCEDURE dbo.EmployeeSalary_GetByEmployeeSalaryId
(

	@EmployeeSalaryId int   
)
AS


				SELECT
					[EmployeeSalaryId],
					[EmployeeId],
					[SalaryAmount],
					[ApprovedOn],
					[ApprovedBy],
					[IsActive]
				FROM
					[dbo].[EmployeeSalary]
				WHERE
					[EmployeeSalaryId] = @EmployeeSalaryId
				SELECT @@ROWCOUNT
					
			

GO
SET QUOTED_IDENTIFIER ON 
GO
SET NOCOUNT ON
GO
SET ANSI_NULLS OFF 
GO

	

-- Drop the dbo.EmployeeSalary_Find procedure
IF EXISTS (SELECT * FROM dbo.sysobjects WHERE id = object_id(N'dbo.EmployeeSalary_Find') AND OBJECTPROPERTY(id, N'IsProcedure') = 1)
DROP PROCEDURE dbo.EmployeeSalary_Find
GO

/*
----------------------------------------------------------------------------------------------------

-- Created By: I-Financial (www.i-financial.org)
-- Purpose: Finds records in the EmployeeSalary table passing nullable parameters
----------------------------------------------------------------------------------------------------
*/


CREATE PROCEDURE dbo.EmployeeSalary_Find
(

	@SearchUsingOR bit   = null ,

	@EmployeeSalaryId int   = null ,

	@EmployeeId int   = null ,

	@SalaryAmount decimal (18, 2)  = null ,

	@ApprovedOn datetime   = null ,

	@ApprovedBy varchar (50)  = null ,

	@IsActive bit   = null 
)
AS


				
  IF ISNULL(@SearchUsingOR, 0) <> 1
  BEGIN
    SELECT
	  [EmployeeSalaryId]
	, [EmployeeId]
	, [SalaryAmount]
	, [ApprovedOn]
	, [ApprovedBy]
	, [IsActive]
    FROM
	[dbo].[EmployeeSalary]
    WHERE 
	 ([EmployeeSalaryId] = @EmployeeSalaryId OR @EmployeeSalaryId IS NULL)
	AND ([EmployeeId] = @EmployeeId OR @EmployeeId IS NULL)
	AND ([SalaryAmount] = @SalaryAmount OR @SalaryAmount IS NULL)
	AND ([ApprovedOn] = @ApprovedOn OR @ApprovedOn IS NULL)
	AND ([ApprovedBy] = @ApprovedBy OR @ApprovedBy IS NULL)
	AND ([IsActive] = @IsActive OR @IsActive IS NULL)
						
  END
  ELSE
  BEGIN
    SELECT
	  [EmployeeSalaryId]
	, [EmployeeId]
	, [SalaryAmount]
	, [ApprovedOn]
	, [ApprovedBy]
	, [IsActive]
    FROM
	[dbo].[EmployeeSalary]
    WHERE 
	 ([EmployeeSalaryId] = @EmployeeSalaryId AND @EmployeeSalaryId is not null)
	OR ([EmployeeId] = @EmployeeId AND @EmployeeId is not null)
	OR ([SalaryAmount] = @SalaryAmount AND @SalaryAmount is not null)
	OR ([ApprovedOn] = @ApprovedOn AND @ApprovedOn is not null)
	OR ([ApprovedBy] = @ApprovedBy AND @ApprovedBy is not null)
	OR ([IsActive] = @IsActive AND @IsActive is not null)
	SELECT @@ROWCOUNT			
  END
				

GO
SET QUOTED_IDENTIFIER ON 
GO
SET NOCOUNT ON
GO
SET ANSI_NULLS OFF 
GO

	

-- Drop the dbo.Address_Get_List procedure
IF EXISTS (SELECT * FROM dbo.sysobjects WHERE id = object_id(N'dbo.Address_Get_List') AND OBJECTPROPERTY(id, N'IsProcedure') = 1)
DROP PROCEDURE dbo.Address_Get_List
GO

/*
----------------------------------------------------------------------------------------------------

-- Created By: I-Financial (www.i-financial.org)
-- Purpose: Gets all records from the Address table
----------------------------------------------------------------------------------------------------
*/


CREATE PROCEDURE dbo.Address_Get_List

AS


				
				SELECT
					[AddressId],
					[EmployeeId],
					[Line1],
					[Line2],
					[TownCity],
					[StateOrProvince],
					[PostCod],
					[CountryCode]
				FROM
					[dbo].[Address]
					
				SELECT @@ROWCOUNT
			

GO
SET QUOTED_IDENTIFIER ON 
GO
SET NOCOUNT ON
GO
SET ANSI_NULLS OFF 
GO

	

-- Drop the dbo.Address_GetPaged procedure
IF EXISTS (SELECT * FROM dbo.sysobjects WHERE id = object_id(N'dbo.Address_GetPaged') AND OBJECTPROPERTY(id, N'IsProcedure') = 1)
DROP PROCEDURE dbo.Address_GetPaged
GO

/*
----------------------------------------------------------------------------------------------------

-- Created By: I-Financial (www.i-financial.org)
-- Purpose: Gets records from the Address table passing page index and page count parameters
----------------------------------------------------------------------------------------------------
*/


CREATE PROCEDURE dbo.Address_GetPaged
(

	@WhereClause varchar (8000)  ,

	@OrderBy varchar (2000)  ,

	@PageIndex int   ,

	@PageSize int   
)
AS


				
				BEGIN
				DECLARE @PageLowerBound int
				DECLARE @PageUpperBound int
				
				-- Set the page bounds
				SET @PageLowerBound = @PageSize * @PageIndex
				SET @PageUpperBound = @PageLowerBound + @PageSize

				IF (@OrderBy IS NULL OR LEN(@OrderBy) < 1)
				BEGIN
					-- default order by to first column
					SET @OrderBy = '[AddressId]'
				END

				-- SQL Server 2005 Paging
				DECLARE @SQL AS nvarchar(MAX)
				SET @SQL = 'WITH PageIndex AS ('
				SET @SQL = @SQL + ' SELECT'
				IF @PageSize > 0
				BEGIN
					SET @SQL = @SQL + ' TOP ' + CONVERT(nvarchar, @PageUpperBound)
				END
				SET @SQL = @SQL + ' ROW_NUMBER() OVER (ORDER BY ' + @OrderBy + ') as RowIndex'
				SET @SQL = @SQL + ', [AddressId]'
				SET @SQL = @SQL + ', [EmployeeId]'
				SET @SQL = @SQL + ', [Line1]'
				SET @SQL = @SQL + ', [Line2]'
				SET @SQL = @SQL + ', [TownCity]'
				SET @SQL = @SQL + ', [StateOrProvince]'
				SET @SQL = @SQL + ', [PostCod]'
				SET @SQL = @SQL + ', [CountryCode]'
				SET @SQL = @SQL + ' FROM [dbo].[Address]'
				IF LEN(@WhereClause) > 0
				BEGIN
					SET @SQL = @SQL + ' WHERE ' + @WhereClause
				END
				SET @SQL = @SQL + ' ) SELECT'
				SET @SQL = @SQL + ' [AddressId],'
				SET @SQL = @SQL + ' [EmployeeId],'
				SET @SQL = @SQL + ' [Line1],'
				SET @SQL = @SQL + ' [Line2],'
				SET @SQL = @SQL + ' [TownCity],'
				SET @SQL = @SQL + ' [StateOrProvince],'
				SET @SQL = @SQL + ' [PostCod],'
				SET @SQL = @SQL + ' [CountryCode]'
				SET @SQL = @SQL + ' FROM PageIndex'
				SET @SQL = @SQL + ' WHERE RowIndex > ' + CONVERT(nvarchar, @PageLowerBound)
				IF @PageSize > 0
				BEGIN
					SET @SQL = @SQL + ' AND RowIndex <= ' + CONVERT(nvarchar, @PageUpperBound)
				END
				SET @SQL = @SQL + ' ORDER BY ' + @OrderBy
				EXEC sp_executesql @SQL
				
				-- get row count
				SET @SQL = 'SELECT COUNT(1) AS TotalRowCount'
				SET @SQL = @SQL + ' FROM [dbo].[Address]'
				IF LEN(@WhereClause) > 0
				BEGIN
					SET @SQL = @SQL + ' WHERE ' + @WhereClause
				END
				EXEC sp_executesql @SQL
			
				END
			

GO
SET QUOTED_IDENTIFIER ON 
GO
SET NOCOUNT ON
GO
SET ANSI_NULLS OFF 
GO

	

-- Drop the dbo.Address_Insert procedure
IF EXISTS (SELECT * FROM dbo.sysobjects WHERE id = object_id(N'dbo.Address_Insert') AND OBJECTPROPERTY(id, N'IsProcedure') = 1)
DROP PROCEDURE dbo.Address_Insert
GO

/*
----------------------------------------------------------------------------------------------------

-- Created By: I-Financial (www.i-financial.org)
-- Purpose: Inserts a record into the Address table
----------------------------------------------------------------------------------------------------
*/


CREATE PROCEDURE dbo.Address_Insert
(

	@AddressId int    OUTPUT,

	@EmployeeId int   ,

	@Line1 nvarchar (100)  ,

	@Line2 nvarchar (100)  ,

	@TownCity nvarchar (50)  ,

	@StateOrProvince nvarchar (50)  ,

	@PostCod nvarchar (20)  ,

	@CountryCode varchar (3)  
)
AS


				
				INSERT INTO [dbo].[Address]
					(
					[EmployeeId]
					,[Line1]
					,[Line2]
					,[TownCity]
					,[StateOrProvince]
					,[PostCod]
					,[CountryCode]
					)
				VALUES
					(
					@EmployeeId
					,@Line1
					,@Line2
					,@TownCity
					,@StateOrProvince
					,@PostCod
					,@CountryCode
					)
				-- Get the identity value
				SET @AddressId = SCOPE_IDENTITY()
									
							
			

GO
SET QUOTED_IDENTIFIER ON 
GO
SET NOCOUNT ON
GO
SET ANSI_NULLS OFF 
GO

	

-- Drop the dbo.Address_Update procedure
IF EXISTS (SELECT * FROM dbo.sysobjects WHERE id = object_id(N'dbo.Address_Update') AND OBJECTPROPERTY(id, N'IsProcedure') = 1)
DROP PROCEDURE dbo.Address_Update
GO

/*
----------------------------------------------------------------------------------------------------

-- Created By: I-Financial (www.i-financial.org)
-- Purpose: Updates a record in the Address table
----------------------------------------------------------------------------------------------------
*/


CREATE PROCEDURE dbo.Address_Update
(

	@AddressId int   ,

	@EmployeeId int   ,

	@Line1 nvarchar (100)  ,

	@Line2 nvarchar (100)  ,

	@TownCity nvarchar (50)  ,

	@StateOrProvince nvarchar (50)  ,

	@PostCod nvarchar (20)  ,

	@CountryCode varchar (3)  
)
AS


				
				
				-- Modify the updatable columns
				UPDATE
					[dbo].[Address]
				SET
					[EmployeeId] = @EmployeeId
					,[Line1] = @Line1
					,[Line2] = @Line2
					,[TownCity] = @TownCity
					,[StateOrProvince] = @StateOrProvince
					,[PostCod] = @PostCod
					,[CountryCode] = @CountryCode
				WHERE
[AddressId] = @AddressId 
				
			

GO
SET QUOTED_IDENTIFIER ON 
GO
SET NOCOUNT ON
GO
SET ANSI_NULLS OFF 
GO

	

-- Drop the dbo.Address_Delete procedure
IF EXISTS (SELECT * FROM dbo.sysobjects WHERE id = object_id(N'dbo.Address_Delete') AND OBJECTPROPERTY(id, N'IsProcedure') = 1)
DROP PROCEDURE dbo.Address_Delete
GO

/*
----------------------------------------------------------------------------------------------------

-- Created By: I-Financial (www.i-financial.org)
-- Purpose: Deletes a record in the Address table
----------------------------------------------------------------------------------------------------
*/


CREATE PROCEDURE dbo.Address_Delete
(

	@AddressId int   
)
AS


				DELETE FROM [dbo].[Address] WITH (ROWLOCK) 
				WHERE
					[AddressId] = @AddressId
					
			

GO
SET QUOTED_IDENTIFIER ON 
GO
SET NOCOUNT ON
GO
SET ANSI_NULLS OFF 
GO

	

-- Drop the dbo.Address_GetByCountryCode procedure
IF EXISTS (SELECT * FROM dbo.sysobjects WHERE id = object_id(N'dbo.Address_GetByCountryCode') AND OBJECTPROPERTY(id, N'IsProcedure') = 1)
DROP PROCEDURE dbo.Address_GetByCountryCode
GO

/*
----------------------------------------------------------------------------------------------------

-- Created By: I-Financial (www.i-financial.org)
-- Purpose: Select records from the Address table through a foreign key
----------------------------------------------------------------------------------------------------
*/


CREATE PROCEDURE dbo.Address_GetByCountryCode
(

	@CountryCode varchar (3)  
)
AS


				SET ANSI_NULLS OFF
				
				SELECT
					[AddressId],
					[EmployeeId],
					[Line1],
					[Line2],
					[TownCity],
					[StateOrProvince],
					[PostCod],
					[CountryCode]
				FROM
					[dbo].[Address]
				WHERE
					[CountryCode] = @CountryCode
				
				SELECT @@ROWCOUNT
				SET ANSI_NULLS ON
			

GO
SET QUOTED_IDENTIFIER ON 
GO
SET NOCOUNT ON
GO
SET ANSI_NULLS OFF 
GO

	

-- Drop the dbo.Address_GetByEmployeeId procedure
IF EXISTS (SELECT * FROM dbo.sysobjects WHERE id = object_id(N'dbo.Address_GetByEmployeeId') AND OBJECTPROPERTY(id, N'IsProcedure') = 1)
DROP PROCEDURE dbo.Address_GetByEmployeeId
GO

/*
----------------------------------------------------------------------------------------------------

-- Created By: I-Financial (www.i-financial.org)
-- Purpose: Select records from the Address table through a foreign key
----------------------------------------------------------------------------------------------------
*/


CREATE PROCEDURE dbo.Address_GetByEmployeeId
(

	@EmployeeId int   
)
AS


				SET ANSI_NULLS OFF
				
				SELECT
					[AddressId],
					[EmployeeId],
					[Line1],
					[Line2],
					[TownCity],
					[StateOrProvince],
					[PostCod],
					[CountryCode]
				FROM
					[dbo].[Address]
				WHERE
					[EmployeeId] = @EmployeeId
				
				SELECT @@ROWCOUNT
				SET ANSI_NULLS ON
			

GO
SET QUOTED_IDENTIFIER ON 
GO
SET NOCOUNT ON
GO
SET ANSI_NULLS OFF 
GO

	

-- Drop the dbo.Address_GetByAddressId procedure
IF EXISTS (SELECT * FROM dbo.sysobjects WHERE id = object_id(N'dbo.Address_GetByAddressId') AND OBJECTPROPERTY(id, N'IsProcedure') = 1)
DROP PROCEDURE dbo.Address_GetByAddressId
GO

/*
----------------------------------------------------------------------------------------------------

-- Created By: I-Financial (www.i-financial.org)
-- Purpose: Select records from the Address table through an index
----------------------------------------------------------------------------------------------------
*/


CREATE PROCEDURE dbo.Address_GetByAddressId
(

	@AddressId int   
)
AS


				SELECT
					[AddressId],
					[EmployeeId],
					[Line1],
					[Line2],
					[TownCity],
					[StateOrProvince],
					[PostCod],
					[CountryCode]
				FROM
					[dbo].[Address]
				WHERE
					[AddressId] = @AddressId
				SELECT @@ROWCOUNT
					
			

GO
SET QUOTED_IDENTIFIER ON 
GO
SET NOCOUNT ON
GO
SET ANSI_NULLS OFF 
GO

	

-- Drop the dbo.Address_Find procedure
IF EXISTS (SELECT * FROM dbo.sysobjects WHERE id = object_id(N'dbo.Address_Find') AND OBJECTPROPERTY(id, N'IsProcedure') = 1)
DROP PROCEDURE dbo.Address_Find
GO

/*
----------------------------------------------------------------------------------------------------

-- Created By: I-Financial (www.i-financial.org)
-- Purpose: Finds records in the Address table passing nullable parameters
----------------------------------------------------------------------------------------------------
*/


CREATE PROCEDURE dbo.Address_Find
(

	@SearchUsingOR bit   = null ,

	@AddressId int   = null ,

	@EmployeeId int   = null ,

	@Line1 nvarchar (100)  = null ,

	@Line2 nvarchar (100)  = null ,

	@TownCity nvarchar (50)  = null ,

	@StateOrProvince nvarchar (50)  = null ,

	@PostCod nvarchar (20)  = null ,

	@CountryCode varchar (3)  = null 
)
AS


				
  IF ISNULL(@SearchUsingOR, 0) <> 1
  BEGIN
    SELECT
	  [AddressId]
	, [EmployeeId]
	, [Line1]
	, [Line2]
	, [TownCity]
	, [StateOrProvince]
	, [PostCod]
	, [CountryCode]
    FROM
	[dbo].[Address]
    WHERE 
	 ([AddressId] = @AddressId OR @AddressId IS NULL)
	AND ([EmployeeId] = @EmployeeId OR @EmployeeId IS NULL)
	AND ([Line1] = @Line1 OR @Line1 IS NULL)
	AND ([Line2] = @Line2 OR @Line2 IS NULL)
	AND ([TownCity] = @TownCity OR @TownCity IS NULL)
	AND ([StateOrProvince] = @StateOrProvince OR @StateOrProvince IS NULL)
	AND ([PostCod] = @PostCod OR @PostCod IS NULL)
	AND ([CountryCode] = @CountryCode OR @CountryCode IS NULL)
						
  END
  ELSE
  BEGIN
    SELECT
	  [AddressId]
	, [EmployeeId]
	, [Line1]
	, [Line2]
	, [TownCity]
	, [StateOrProvince]
	, [PostCod]
	, [CountryCode]
    FROM
	[dbo].[Address]
    WHERE 
	 ([AddressId] = @AddressId AND @AddressId is not null)
	OR ([EmployeeId] = @EmployeeId AND @EmployeeId is not null)
	OR ([Line1] = @Line1 AND @Line1 is not null)
	OR ([Line2] = @Line2 AND @Line2 is not null)
	OR ([TownCity] = @TownCity AND @TownCity is not null)
	OR ([StateOrProvince] = @StateOrProvince AND @StateOrProvince is not null)
	OR ([PostCod] = @PostCod AND @PostCod is not null)
	OR ([CountryCode] = @CountryCode AND @CountryCode is not null)
	SELECT @@ROWCOUNT			
  END
				

GO
SET QUOTED_IDENTIFIER ON 
GO
SET NOCOUNT ON
GO
SET ANSI_NULLS OFF 
GO

	

-- Drop the dbo.EmployeeSkills_Get_List procedure
IF EXISTS (SELECT * FROM dbo.sysobjects WHERE id = object_id(N'dbo.EmployeeSkills_Get_List') AND OBJECTPROPERTY(id, N'IsProcedure') = 1)
DROP PROCEDURE dbo.EmployeeSkills_Get_List
GO

/*
----------------------------------------------------------------------------------------------------

-- Created By: I-Financial (www.i-financial.org)
-- Purpose: Gets all records from the EmployeeSkills table
----------------------------------------------------------------------------------------------------
*/


CREATE PROCEDURE dbo.EmployeeSkills_Get_List

AS


				
				SELECT
					[EmployeeSkillId],
					[EmployeeId],
					[SkillCode],
					[SkillLevel],
					[CreatedOn]
				FROM
					[dbo].[EmployeeSkills]
					
				SELECT @@ROWCOUNT
			

GO
SET QUOTED_IDENTIFIER ON 
GO
SET NOCOUNT ON
GO
SET ANSI_NULLS OFF 
GO

	

-- Drop the dbo.EmployeeSkills_GetPaged procedure
IF EXISTS (SELECT * FROM dbo.sysobjects WHERE id = object_id(N'dbo.EmployeeSkills_GetPaged') AND OBJECTPROPERTY(id, N'IsProcedure') = 1)
DROP PROCEDURE dbo.EmployeeSkills_GetPaged
GO

/*
----------------------------------------------------------------------------------------------------

-- Created By: I-Financial (www.i-financial.org)
-- Purpose: Gets records from the EmployeeSkills table passing page index and page count parameters
----------------------------------------------------------------------------------------------------
*/


CREATE PROCEDURE dbo.EmployeeSkills_GetPaged
(

	@WhereClause varchar (8000)  ,

	@OrderBy varchar (2000)  ,

	@PageIndex int   ,

	@PageSize int   
)
AS


				
				BEGIN
				DECLARE @PageLowerBound int
				DECLARE @PageUpperBound int
				
				-- Set the page bounds
				SET @PageLowerBound = @PageSize * @PageIndex
				SET @PageUpperBound = @PageLowerBound + @PageSize

				IF (@OrderBy IS NULL OR LEN(@OrderBy) < 1)
				BEGIN
					-- default order by to first column
					SET @OrderBy = '[EmployeeSkillId]'
				END

				-- SQL Server 2005 Paging
				DECLARE @SQL AS nvarchar(MAX)
				SET @SQL = 'WITH PageIndex AS ('
				SET @SQL = @SQL + ' SELECT'
				IF @PageSize > 0
				BEGIN
					SET @SQL = @SQL + ' TOP ' + CONVERT(nvarchar, @PageUpperBound)
				END
				SET @SQL = @SQL + ' ROW_NUMBER() OVER (ORDER BY ' + @OrderBy + ') as RowIndex'
				SET @SQL = @SQL + ', [EmployeeSkillId]'
				SET @SQL = @SQL + ', [EmployeeId]'
				SET @SQL = @SQL + ', [SkillCode]'
				SET @SQL = @SQL + ', [SkillLevel]'
				SET @SQL = @SQL + ', [CreatedOn]'
				SET @SQL = @SQL + ' FROM [dbo].[EmployeeSkills]'
				IF LEN(@WhereClause) > 0
				BEGIN
					SET @SQL = @SQL + ' WHERE ' + @WhereClause
				END
				SET @SQL = @SQL + ' ) SELECT'
				SET @SQL = @SQL + ' [EmployeeSkillId],'
				SET @SQL = @SQL + ' [EmployeeId],'
				SET @SQL = @SQL + ' [SkillCode],'
				SET @SQL = @SQL + ' [SkillLevel],'
				SET @SQL = @SQL + ' [CreatedOn]'
				SET @SQL = @SQL + ' FROM PageIndex'
				SET @SQL = @SQL + ' WHERE RowIndex > ' + CONVERT(nvarchar, @PageLowerBound)
				IF @PageSize > 0
				BEGIN
					SET @SQL = @SQL + ' AND RowIndex <= ' + CONVERT(nvarchar, @PageUpperBound)
				END
				SET @SQL = @SQL + ' ORDER BY ' + @OrderBy
				EXEC sp_executesql @SQL
				
				-- get row count
				SET @SQL = 'SELECT COUNT(1) AS TotalRowCount'
				SET @SQL = @SQL + ' FROM [dbo].[EmployeeSkills]'
				IF LEN(@WhereClause) > 0
				BEGIN
					SET @SQL = @SQL + ' WHERE ' + @WhereClause
				END
				EXEC sp_executesql @SQL
			
				END
			

GO
SET QUOTED_IDENTIFIER ON 
GO
SET NOCOUNT ON
GO
SET ANSI_NULLS OFF 
GO

	

-- Drop the dbo.EmployeeSkills_Insert procedure
IF EXISTS (SELECT * FROM dbo.sysobjects WHERE id = object_id(N'dbo.EmployeeSkills_Insert') AND OBJECTPROPERTY(id, N'IsProcedure') = 1)
DROP PROCEDURE dbo.EmployeeSkills_Insert
GO

/*
----------------------------------------------------------------------------------------------------

-- Created By: I-Financial (www.i-financial.org)
-- Purpose: Inserts a record into the EmployeeSkills table
----------------------------------------------------------------------------------------------------
*/


CREATE PROCEDURE dbo.EmployeeSkills_Insert
(

	@EmployeeSkillId int    OUTPUT,

	@EmployeeId int   ,

	@SkillCode varchar (10)  ,

	@SkillLevel varchar (10)  ,

	@CreatedOn datetime   
)
AS


				
				INSERT INTO [dbo].[EmployeeSkills]
					(
					[EmployeeId]
					,[SkillCode]
					,[SkillLevel]
					,[CreatedOn]
					)
				VALUES
					(
					@EmployeeId
					,@SkillCode
					,@SkillLevel
					,@CreatedOn
					)
				-- Get the identity value
				SET @EmployeeSkillId = SCOPE_IDENTITY()
									
							
			

GO
SET QUOTED_IDENTIFIER ON 
GO
SET NOCOUNT ON
GO
SET ANSI_NULLS OFF 
GO

	

-- Drop the dbo.EmployeeSkills_Update procedure
IF EXISTS (SELECT * FROM dbo.sysobjects WHERE id = object_id(N'dbo.EmployeeSkills_Update') AND OBJECTPROPERTY(id, N'IsProcedure') = 1)
DROP PROCEDURE dbo.EmployeeSkills_Update
GO

/*
----------------------------------------------------------------------------------------------------

-- Created By: I-Financial (www.i-financial.org)
-- Purpose: Updates a record in the EmployeeSkills table
----------------------------------------------------------------------------------------------------
*/


CREATE PROCEDURE dbo.EmployeeSkills_Update
(

	@EmployeeSkillId int   ,

	@EmployeeId int   ,

	@SkillCode varchar (10)  ,

	@SkillLevel varchar (10)  ,

	@CreatedOn datetime   
)
AS


				
				
				-- Modify the updatable columns
				UPDATE
					[dbo].[EmployeeSkills]
				SET
					[EmployeeId] = @EmployeeId
					,[SkillCode] = @SkillCode
					,[SkillLevel] = @SkillLevel
					,[CreatedOn] = @CreatedOn
				WHERE
[EmployeeSkillId] = @EmployeeSkillId 
				
			

GO
SET QUOTED_IDENTIFIER ON 
GO
SET NOCOUNT ON
GO
SET ANSI_NULLS OFF 
GO

	

-- Drop the dbo.EmployeeSkills_Delete procedure
IF EXISTS (SELECT * FROM dbo.sysobjects WHERE id = object_id(N'dbo.EmployeeSkills_Delete') AND OBJECTPROPERTY(id, N'IsProcedure') = 1)
DROP PROCEDURE dbo.EmployeeSkills_Delete
GO

/*
----------------------------------------------------------------------------------------------------

-- Created By: I-Financial (www.i-financial.org)
-- Purpose: Deletes a record in the EmployeeSkills table
----------------------------------------------------------------------------------------------------
*/


CREATE PROCEDURE dbo.EmployeeSkills_Delete
(

	@EmployeeSkillId int   
)
AS


				DELETE FROM [dbo].[EmployeeSkills] WITH (ROWLOCK) 
				WHERE
					[EmployeeSkillId] = @EmployeeSkillId
					
			

GO
SET QUOTED_IDENTIFIER ON 
GO
SET NOCOUNT ON
GO
SET ANSI_NULLS OFF 
GO

	

-- Drop the dbo.EmployeeSkills_GetBySkillCode procedure
IF EXISTS (SELECT * FROM dbo.sysobjects WHERE id = object_id(N'dbo.EmployeeSkills_GetBySkillCode') AND OBJECTPROPERTY(id, N'IsProcedure') = 1)
DROP PROCEDURE dbo.EmployeeSkills_GetBySkillCode
GO

/*
----------------------------------------------------------------------------------------------------

-- Created By: I-Financial (www.i-financial.org)
-- Purpose: Select records from the EmployeeSkills table through a foreign key
----------------------------------------------------------------------------------------------------
*/


CREATE PROCEDURE dbo.EmployeeSkills_GetBySkillCode
(

	@SkillCode varchar (10)  
)
AS


				SET ANSI_NULLS OFF
				
				SELECT
					[EmployeeSkillId],
					[EmployeeId],
					[SkillCode],
					[SkillLevel],
					[CreatedOn]
				FROM
					[dbo].[EmployeeSkills]
				WHERE
					[SkillCode] = @SkillCode
				
				SELECT @@ROWCOUNT
				SET ANSI_NULLS ON
			

GO
SET QUOTED_IDENTIFIER ON 
GO
SET NOCOUNT ON
GO
SET ANSI_NULLS OFF 
GO

	

-- Drop the dbo.EmployeeSkills_GetBySkillLevel procedure
IF EXISTS (SELECT * FROM dbo.sysobjects WHERE id = object_id(N'dbo.EmployeeSkills_GetBySkillLevel') AND OBJECTPROPERTY(id, N'IsProcedure') = 1)
DROP PROCEDURE dbo.EmployeeSkills_GetBySkillLevel
GO

/*
----------------------------------------------------------------------------------------------------

-- Created By: I-Financial (www.i-financial.org)
-- Purpose: Select records from the EmployeeSkills table through a foreign key
----------------------------------------------------------------------------------------------------
*/


CREATE PROCEDURE dbo.EmployeeSkills_GetBySkillLevel
(

	@SkillLevel varchar (10)  
)
AS


				SET ANSI_NULLS OFF
				
				SELECT
					[EmployeeSkillId],
					[EmployeeId],
					[SkillCode],
					[SkillLevel],
					[CreatedOn]
				FROM
					[dbo].[EmployeeSkills]
				WHERE
					[SkillLevel] = @SkillLevel
				
				SELECT @@ROWCOUNT
				SET ANSI_NULLS ON
			

GO
SET QUOTED_IDENTIFIER ON 
GO
SET NOCOUNT ON
GO
SET ANSI_NULLS OFF 
GO

	

-- Drop the dbo.EmployeeSkills_GetByEmployeeId procedure
IF EXISTS (SELECT * FROM dbo.sysobjects WHERE id = object_id(N'dbo.EmployeeSkills_GetByEmployeeId') AND OBJECTPROPERTY(id, N'IsProcedure') = 1)
DROP PROCEDURE dbo.EmployeeSkills_GetByEmployeeId
GO

/*
----------------------------------------------------------------------------------------------------

-- Created By: I-Financial (www.i-financial.org)
-- Purpose: Select records from the EmployeeSkills table through a foreign key
----------------------------------------------------------------------------------------------------
*/


CREATE PROCEDURE dbo.EmployeeSkills_GetByEmployeeId
(

	@EmployeeId int   
)
AS


				SET ANSI_NULLS OFF
				
				SELECT
					[EmployeeSkillId],
					[EmployeeId],
					[SkillCode],
					[SkillLevel],
					[CreatedOn]
				FROM
					[dbo].[EmployeeSkills]
				WHERE
					[EmployeeId] = @EmployeeId
				
				SELECT @@ROWCOUNT
				SET ANSI_NULLS ON
			

GO
SET QUOTED_IDENTIFIER ON 
GO
SET NOCOUNT ON
GO
SET ANSI_NULLS OFF 
GO

	

-- Drop the dbo.EmployeeSkills_GetByEmployeeSkillId procedure
IF EXISTS (SELECT * FROM dbo.sysobjects WHERE id = object_id(N'dbo.EmployeeSkills_GetByEmployeeSkillId') AND OBJECTPROPERTY(id, N'IsProcedure') = 1)
DROP PROCEDURE dbo.EmployeeSkills_GetByEmployeeSkillId
GO

/*
----------------------------------------------------------------------------------------------------

-- Created By: I-Financial (www.i-financial.org)
-- Purpose: Select records from the EmployeeSkills table through an index
----------------------------------------------------------------------------------------------------
*/


CREATE PROCEDURE dbo.EmployeeSkills_GetByEmployeeSkillId
(

	@EmployeeSkillId int   
)
AS


				SELECT
					[EmployeeSkillId],
					[EmployeeId],
					[SkillCode],
					[SkillLevel],
					[CreatedOn]
				FROM
					[dbo].[EmployeeSkills]
				WHERE
					[EmployeeSkillId] = @EmployeeSkillId
				SELECT @@ROWCOUNT
					
			

GO
SET QUOTED_IDENTIFIER ON 
GO
SET NOCOUNT ON
GO
SET ANSI_NULLS OFF 
GO

	

-- Drop the dbo.EmployeeSkills_Find procedure
IF EXISTS (SELECT * FROM dbo.sysobjects WHERE id = object_id(N'dbo.EmployeeSkills_Find') AND OBJECTPROPERTY(id, N'IsProcedure') = 1)
DROP PROCEDURE dbo.EmployeeSkills_Find
GO

/*
----------------------------------------------------------------------------------------------------

-- Created By: I-Financial (www.i-financial.org)
-- Purpose: Finds records in the EmployeeSkills table passing nullable parameters
----------------------------------------------------------------------------------------------------
*/


CREATE PROCEDURE dbo.EmployeeSkills_Find
(

	@SearchUsingOR bit   = null ,

	@EmployeeSkillId int   = null ,

	@EmployeeId int   = null ,

	@SkillCode varchar (10)  = null ,

	@SkillLevel varchar (10)  = null ,

	@CreatedOn datetime   = null 
)
AS


				
  IF ISNULL(@SearchUsingOR, 0) <> 1
  BEGIN
    SELECT
	  [EmployeeSkillId]
	, [EmployeeId]
	, [SkillCode]
	, [SkillLevel]
	, [CreatedOn]
    FROM
	[dbo].[EmployeeSkills]
    WHERE 
	 ([EmployeeSkillId] = @EmployeeSkillId OR @EmployeeSkillId IS NULL)
	AND ([EmployeeId] = @EmployeeId OR @EmployeeId IS NULL)
	AND ([SkillCode] = @SkillCode OR @SkillCode IS NULL)
	AND ([SkillLevel] = @SkillLevel OR @SkillLevel IS NULL)
	AND ([CreatedOn] = @CreatedOn OR @CreatedOn IS NULL)
						
  END
  ELSE
  BEGIN
    SELECT
	  [EmployeeSkillId]
	, [EmployeeId]
	, [SkillCode]
	, [SkillLevel]
	, [CreatedOn]
    FROM
	[dbo].[EmployeeSkills]
    WHERE 
	 ([EmployeeSkillId] = @EmployeeSkillId AND @EmployeeSkillId is not null)
	OR ([EmployeeId] = @EmployeeId AND @EmployeeId is not null)
	OR ([SkillCode] = @SkillCode AND @SkillCode is not null)
	OR ([SkillLevel] = @SkillLevel AND @SkillLevel is not null)
	OR ([CreatedOn] = @CreatedOn AND @CreatedOn is not null)
	SELECT @@ROWCOUNT			
  END
				

GO
SET QUOTED_IDENTIFIER ON 
GO
SET NOCOUNT ON
GO
SET ANSI_NULLS OFF 
GO

