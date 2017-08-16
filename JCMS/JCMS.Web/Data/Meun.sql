IF EXISTS ( SELECT  *
            FROM    dbo.sysobjects
            WHERE   id = OBJECT_ID(N'[dbo].[Modules]')
                    AND OBJECTPROPERTY(id, N'IsTable') = 1 )
DROP TABLE [dbo].[Modules];

CREATE TABLE [dbo].[Modules](
	[Id] [int] IDENTITY(1,1) NOT NULL,
	[ParentId] [int] NULL,
	[Name] [nvarchar](20) NOT NULL,
	[LinkUrl] [nvarchar](50) NOT NULL,
	[IsMenu] [bit] NOT NULL,
	[Code] [int] NOT NULL,
	[Description] [nvarchar](100) NULL,
	[Enabled] [bit] NOT NULL,
	[UpdateDate] [datetime] NOT NULL,
	[TenantId] [nchar](10) NULL,
 CONSTRAINT [PK_dbo.Modules] PRIMARY KEY CLUSTERED 
(
	[Id] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON) ON [PRIMARY]
) ON [PRIMARY]

GO
SET IDENTITY_INSERT [dbo].[Modules] ON 


INSERT [dbo].[Modules] ([Id], [ParentId], [Name], [LinkUrl], [IsMenu], [Code], [Description], [Enabled], [UpdateDate], [TenantId]) VALUES (1, 0, N'授权管理', N'#', 1, 200, NULL, 1, CAST(0x0000A7B300FE27A6 AS DateTime), NULL)

INSERT [dbo].[Modules] ([Id], [ParentId], [Name], [LinkUrl], [IsMenu], [Code], [Description], [Enabled], [UpdateDate], [TenantId]) VALUES (2, 1, N'角色管理', N'~/Member/Role/Index', 1, 201, NULL, 1, CAST(0x0000A7B300FE27A6 AS DateTime), NULL)

INSERT [dbo].[Modules] ([Id], [ParentId], [Name], [LinkUrl], [IsMenu], [Code], [Description], [Enabled], [UpdateDate], [TenantId]) VALUES (3, 1, N'用户管理', N'~/Member/User/Index', 1, 202, NULL, 1, CAST(0x0000A7B300FE27A6 AS DateTime), NULL)

INSERT [dbo].[Modules] ([Id], [ParentId], [Name], [LinkUrl], [IsMenu], [Code], [Description], [Enabled], [UpdateDate], [TenantId]) VALUES (4, 1, N'模块管理', N'~/Member/Module/Index', 1, 204, NULL, 1, CAST(0x0000A7B300FE27A6 AS DateTime), NULL)

INSERT [dbo].[Modules] ([Id], [ParentId], [Name], [LinkUrl], [IsMenu], [Code], [Description], [Enabled], [UpdateDate], [TenantId]) VALUES (5, 1, N'权限管理', N'~/Member/Permission/Index', 1, 205, NULL, 1, CAST(0x0000A7B300FE27A6 AS DateTime), NULL)

INSERT [dbo].[Modules] ([Id], [ParentId], [Name], [LinkUrl], [IsMenu], [Code], [Description], [Enabled], [UpdateDate], [TenantId]) VALUES (6, 0, N'系统应用', N'#', 1, 300, NULL, 1, CAST(0x0000A7B300FE27A6 AS DateTime), NULL)

INSERT [dbo].[Modules] ([Id], [ParentId], [Name], [LinkUrl], [IsMenu], [Code], [Description], [Enabled], [UpdateDate], [TenantId]) VALUES (7, 6, N'操作日志管理', N'#', 1, 301, NULL, 1, CAST(0x0000A7B300FE27A6 AS DateTime), NULL)

INSERT [dbo].[Modules] ([Id], [ParentId], [Name], [LinkUrl], [IsMenu], [Code], [Description], [Enabled], [UpdateDate], [TenantId]) VALUES (8, 1, N'用户组管理', N'~/Member/UserGroup/Index', 1, 203, NULL, 1, CAST(0x0000A7B300FE27A6 AS DateTime), NULL)

--SET IDENTITY_INSERT [dbo].[Modules] OFF





--CREATE TABLE [dbo].[Modules](
--	[Id] [int] IDENTITY(1,1) NOT NULL,
--	[ParentId] [int] NULL,
--	[Name] [nvarchar](20) NOT NULL,
--	[LinkUrl] [nvarchar](50) NOT NULL,
--	[IsMenu] [bit] NOT NULL,
--	[Code] [int] NOT NULL,
--	[Description] [nvarchar](100) NULL,
--	[Enabled] [bit] NOT NULL,
--	[UpdateDate] [datetime] NOT NULL,
--	[TenantId] [nvarchar](20)  NULL,
-- CONSTRAINT [PK_dbo.Modules] PRIMARY KEY CLUSTERED 
--(
--	[Id] ASC
--)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON) ON [PRIMARY]
--) ON [PRIMARY]

--SET IDENTITY_INSERT [dbo].[Modules] ON 


--INSERT [dbo].[Modules] ([Id], [ParentId], [Name], [LinkUrl], [IsMenu], [Code], [Description], [Enabled], [UpdateDate]) VALUES (1, 0, N'授权管理', N'#', 1, 200, NULL, 1, CAST(0x0000A7B300FE27A6 AS DateTime))

--INSERT [dbo].[Modules] ([Id], [ParentId], [Name], [LinkUrl], [IsMenu], [Code], [Description], [Enabled], [UpdateDate]) VALUES (2, 1, N'角色管理', N'~/Member/Role/Index', 1, 201, NULL, 1, CAST(0x0000A7B300FE27A6 AS DateTime))

--INSERT [dbo].[Modules] ([Id], [ParentId], [Name], [LinkUrl], [IsMenu], [Code], [Description], [Enabled], [UpdateDate]) VALUES (3, 1, N'用户管理', N'~/Member/User/Index', 1, 202, NULL, 1, CAST(0x0000A7B300FE27A6 AS DateTime))

--INSERT [dbo].[Modules] ([Id], [ParentId], [Name], [LinkUrl], [IsMenu], [Code], [Description], [Enabled], [UpdateDate]) VALUES (4, 1, N'模块管理', N'~/Member/Module/Index', 1, 204, NULL, 1, CAST(0x0000A7B300FE27A6 AS DateTime))

--INSERT [dbo].[Modules] ([Id], [ParentId], [Name], [LinkUrl], [IsMenu], [Code], [Description], [Enabled], [UpdateDate]) VALUES (5, 1, N'权限管理', N'~/Member/Permission/Index', 1, 205, NULL, 1, CAST(0x0000A7B300FE27A6 AS DateTime))

--INSERT [dbo].[Modules] ([Id], [ParentId], [Name], [LinkUrl], [IsMenu], [Code], [Description], [Enabled], [UpdateDate]) VALUES (6, 0, N'系统应用', N'#', 1, 300, NULL, 1, CAST(0x0000A7B300FE27A6 AS DateTime))

--INSERT [dbo].[Modules] ([Id], [ParentId], [Name], [LinkUrl], [IsMenu], [Code], [Description], [Enabled], [UpdateDate]) VALUES (7, 6, N'操作日志管理', N'#', 1, 301, NULL, 1, CAST(0x0000A7B300FE27A6 AS DateTime))

--INSERT [dbo].[Modules] ([Id], [ParentId], [Name], [LinkUrl], [IsMenu], [Code], [Description], [Enabled], [UpdateDate]) VALUES (8, 1, N'用户组管理', N'~/Member/UserGroup/Index', 1, 203, NULL, 1, CAST(0x0000A7B300FE27A6 AS DateTime))

----SET IDENTITY_INSERT [dbo].[Modules] OFF
----GO

----set identity_insert Modules ON
