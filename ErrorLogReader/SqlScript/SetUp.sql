CREATE DATABASE [FundingApplicationWafDatabase]
Go
USE [FundingApplicationWafDatabase]
go
CREATE TABLE dbo.Waf_Logs
	(
	Id int NOT NULL IDENTITY (1, 1),
	TimeStamp nvarchar(500) NULL,
	[Level] nvarchar(500) NULL,
	Vip_Ip nvarchar(500) NULL,
	Vip_Port nvarchar(500) NULL,
	Client_Ip nvarchar(500) NULL,
	Client_Port nvarchar(500) NULL,
	Rule_Id nvarchar(500) NULL,
	Rule_Type nvarchar(500) NULL,
	Method nvarchar(500) NULL,
	Action nvarchar(500) NULL,
	Follow_Up nvarchar(500) NULL,
	Attack nvarchar(500) NULL,
	Host nvarchar(500) NULL,
	Url nvarchar(500) NULL,
	Query_Str nvarchar(500) NULL,
	Detail nvarchar(500) NULL,
	Protocol nvarchar(500) NULL,
	SessionId nvarchar(500) NULL,
	Country nvarchar(500) NULL,
	User_Agent nvarchar(500) NULL,
	Proxy_Ip nvarchar(500) NULL,
	Proxy_Port nvarchar(500) NULL,
	Authenticated_User nvarchar(500) NULL,
	Referer nvarchar(500) NULL,
	Fingerprint nvarchar(500) NULL,
	Req_Risk_Score nvarchar(500) NULL,
	Client_Risk_Score nvarchar(500) NULL
	)  ON [PRIMARY]
GO
ALTER TABLE dbo.Waf_logs ADD CONSTRAINT
	PK_Table_1 PRIMARY KEY CLUSTERED 
	(
	Id
	) WITH( STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON) ON [PRIMARY]

GO