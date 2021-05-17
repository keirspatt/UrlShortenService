ReadMe


1. Create Database table on database of your choosing with the below script  below

SET ANSI_NULLS ON
GO

SET QUOTED_IDENTIFIER ON
GO

CREATE TABLE [dbo].[URLS](
	[URL_ID] [int] IDENTITY(1,1) NOT NULL,
	[LONG_URL] [nvarchar](max) NOT NULL,
	[SHORT_URL] [nvarchar](140) NOT NULL,
 CONSTRAINT [PK_URLS] PRIMARY KEY CLUSTERED 
(
	[URL_ID] ASC
)WITH (STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF) ON [PRIMARY]
) ON [PRIMARY] TEXTIMAGE_ON [PRIMARY]
GO


2. Change your connection string within the Web.Config file

<connectionStrings>
    <add name="URL_DatabaseEntities" connectionString="metadata=res://*/Models.URLdb.csdl|res://*/Models.URLdb.ssdl|res://*/Models.URLdb.msl;provider=System.Data.SqlClient;provider connection string=&quot;data source=urldatabase.database.windows.net;initial catalog=URL_Database;user id=eadmin;password=************;MultipleActiveResultSets=True;App=EntityFramework&quot;" providerName="System.Data.EntityClient" />
  </connectionStrings>