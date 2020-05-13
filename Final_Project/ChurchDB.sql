/* Check whether the database already exists */
IF EXISTS(SELECT 1 FROM master.dbo.sysdatabases
		   WHERE name = 'ChurchDB')
BEGIN
DROP DATABASE [ChurchDB]
print '' print '*** Dropping ChurchDB.sql'
END
GO

print '' print '*** Creating Database ChurchDB.sql'
GO

CREATE DATABASE [ChurchDB]
GO

print '' print '*** Using Database ChurchDB.sql'
GO

USE [ChurchDB]
GO

print '' print '*** Creating Person Table'
GO
CREATE TABLE [dbo].[Person](
	[PersonID]		[int] IDENTITY(1000000,1)	NOT NULL,
	[FirstName]		[nvarchar]	(50)			NOT NULL,
	[LastName]		[nvarchar]	(50)			NOT NULL,
	[Dob]			[date]								,
	[PhoneNumber]	[nvarchar]	(11)					,
	[Email]			[nvarchar]	(250)			NOT NULL,
	[Address1]		[nvarchar]	(250)					,
	[Address2]		[nvarchar]	(250)					,
	[City]			[nvarchar]	(150)					,
	[State]			[nvarchar]	(50)					,
	[Zip]			[nvarchar]	(50)					,
	[IsDelegate]	[bit]	DEFAULT 0					,
	[Active]		[bit]	
		DEFAULT 1								NOT NULL,
	[PasswordHash]	[nvarchar]	(100)								
		DEFAULT '9C9064C59F1FFA2E174EE754D2979BE80DD30DB552EC03E7E327E9B1A4BD594E',
	CONSTRAINT [pk_PersonID] PRIMARY KEY([PersonID] ASC),
	CONSTRAINT [ak_Person_Email] UNIQUE([Email] ASC)
)
GO

print '' print '*** Adding index for LastName on Person Table'
GO
CREATE NONCLUSTERED INDEX [ix_lastName] ON [Person]([LastName] ASC)
GO

print '' print '*** Creating Sample Person Records'
GO
INSERT INTO [dbo].[Person]
	([FirstName], [LastName], [Dob], [PhoneNumber], [Email], [Address1], [Address2], [City], [State], [Zip] , [Active])
	VALUES
	('Frank','Tank','07-12-1984','1234567890','Frank@email.com','2300 willbury ln','','Cedar Rapids','IA',52403,1),
	('Jim','Goddard','03-23-1993','9999999999','Jim@email.com','2300 Shady Place St.','Apt# 9','Iowa City','IA',54345,1),
	('Old','Man','03-23-1993','9999999999','Man@email.com','2300 Shady Place St.','Apt# 9','Iowa City','IA',54345,1),
	('Phillip','Tangerene','01-26-1982','3194492837','Phillip@email.com','678 WhreverVille Dr.','','Iowa City','IA',54345,1),
	('Jill','Hill','03-23-1899','2033667890','Jill@email.com','700 Shady Place St.','Apt# 19','Iowa City','IA',54345,1),
	('Heather','Winthrop',null,null,'Heather@email.com',null,null,null,null,null,1),
	('Chad','Tiedeman',null,null,'Chad@email.com',null,null,null,null,null,1),
	('Gus','Reirdon','09-09-2000','4578963215','Gus@email.com','550 the road','apt #9','New York','NY',34521,1)
GO

print ' ' print '*** Creating Election Table'
GO
CREATE TABLE [dbo].[Election](
	[ElectionID]		[int]	IDENTITY(1000000,1)	NOT NULL,
	[ElectionName]		[nvarchar]		(100)		NOT NULL,
	[Description]		[nvarchar]		(1000)				,
	[Active]			[bit] DEFAULT 1				NOT NULL,
	CONSTRAINT [pk_ElectionID] PRIMARY KEY([ElectionID])
)
GO

print '' print '*** Creating Sample Election Records'
GO
INSERT INTO [dbo].[Election]
	([ElectionName],[Description])
	VALUES
	('Election1','This is the first Test Election'),
	('Election2','This is the second Test Election'),
	('Election3','This is the third Test Election')
GO

print ' ' print '*** Creating sp_insert_election'
GO
CREATE PROCEDURE [sp_insert_election]
(
	@ElectionName	[nvarchar] (100),
	@Description	[nvarchar] (1000)
)	
AS
BEGIN
	INSERT INTO [dbo].[Election]
		([ElectionName],[Description])
	VALUES
		(@ElectionName, @Description)
	SELECT SCOPE_IDENTITY()
END
GO

print ' ' print '*** Creating sp_select_elections_by_active'
GO
CREATE PROCEDURE [sp_select_elections_by_active]
(
	@active  [bit]
)	
AS
BEGIN
	SELECT
		[ElectionID]
		,[ElectionName]
		,[Description]
		,[Active]
	FROM [dbo].[Election]
	WHERE [active] = @active
END
GO

print ' ' print '*** Creating sp_select_election_by_election_id'
GO
CREATE PROCEDURE [sp_select_election_by_election_id]
(
	@ElectionID  [int]
)	
AS
BEGIN
	SELECT
		[ElectionID]
		,[ElectionName]
		,[Description]
		,[Active]
	FROM [dbo].[Election]
	WHERE [ElectionID] = @ElectionID
END
GO

print ' ' print '*** Creating sp_update_election'
GO
CREATE PROCEDURE [sp_update_election]
(
	@ElectionID  	[int]					,
	
	@OldElectionName	[nvarchar]	(100)	,
	@OldDescription		[nvarchar]	(1000)	,
	@OldActive			[bit]				,
	
	@NewElectionName	[nvarchar]	(100)	,
	@NewDescription		[nvarchar]	(1000)	,
	@NewActive			[bit]				
)	
AS
BEGIN
	UPDATE 	[dbo].[Election]
	   SET 	ElectionName 	= 	@NewElectionName,
			Description		=	@NewDescription,
			Active			=	@NewActive
	 WHERE	ElectionID		=	@ElectionID
	   AND	ElectionName 	= 	@OldElectionName
	   AND	Description		=	@OldDescription
	   AND	Active			=	@OldActive
	RETURN	@@ROWCOUNT
END
GO

print '' print '*** Creating sp_deactivate_election'
GO
CREATE PROCEDURE [sp_deactivate_election]
(
	@ElectionID [int]
)
AS
BEGIN
	UPDATE [dbo].[Election]
		SET [Active] = 0
	WHERE	[ElectionID] = @ElectionID
	RETURN @@ROWCOUNT
END
GO

print ' ' print '*** Creating Candidate Table'
GO
CREATE TABLE [dbo].[Candidate](
	[CandidateID]		[int]	IDENTITY (1000000,1)	NOT NULL,
	[PersonID]			[int]							NOT NULL,
	[ElectionID]		[int]							NOT NULL,
	[Votes]				[int]	DEFAULT 0				NOT NULL, 
	[Active]			[bit]	DEFAULT 1				NOT NULL,
	CONSTRAINT [pk_CandidateID]	PRIMARY KEY ([CandidateID]),
	CONSTRAINT [fk_Candidate_Person_PersonID] FOREIGN KEY ([PersonID])
		REFERENCES [Person]([PersonID]),
	CONSTRAINT [fk_Candidate_Election_ElectionID] FOREIGN KEY ([ElectionID])
		REFERENCES [Election]([ElectionID])
)
GO

print '' print '*** Creating Sample Candidate Records'
GO
INSERT INTO [dbo].[Candidate]
	([PersonID],[ElectionID])
	VALUES
	(1000000,1000000),
	(1000001,1000000),
	(1000002,1000001),
	(1000001,1000001),
	(1000000,1000002),
	(1000003,1000002)
GO

print ' ' print '*** Creating sp_insert_candidate'
GO
CREATE PROCEDURE [sp_insert_candidate]
(
	@PersonID		[int] 	,
	@ElectionID		[int] 	
)	
AS
BEGIN
	INSERT INTO [dbo].[Candidate]
		([PersonID],[ElectionID])
	VALUES
		(@PersonID,@ElectionID)
	SELECT SCOPE_IDENTITY()
END
GO

print ' ' print '*** Creating sp_select_candidates_by_active'
GO
CREATE PROCEDURE [sp_select_candidates_by_active]
(
	@Active  [bit]
)	
AS
BEGIN
	SELECT
		[CandidateID]
		,[Candidate].[PersonID]
		,[ElectionID]
		,[Votes]
		,[Candidate].[Active]
		,[FirstName]
		,[LastName]
	FROM [Candidate] JOIN [Person] ON [Person].[PersonID] = [Candidate].[PersonID]
	WHERE [Candidate].[Active] = @active
END
GO

print ' ' print '*** Creating sp_select_candidate_by_candidate_id'
GO
CREATE PROCEDURE [sp_select_candidate_by_candidate_id]
(
	@CandidateID  [int]
)	
AS
BEGIN
	SELECT
		[CandidateID]
		,[Candidate].[PersonID]
		,[ElectionID]
		,[Votes]
		,[Candidate].[Active]
		,[FirstName]
		,[LastName]
	FROM [Candidate] JOIN [Person] ON [Person].[PersonID] = [Candidate].[PersonID]
	WHERE [CandidateID] = @CandidateID
END
GO

print ' ' print '*** Creating sp_select_candidates_by_election_id'
GO
CREATE PROCEDURE [sp_select_candidates_by_election_id]
(
	@ElectionID  [int]
)	
AS
BEGIN
	SELECT
		[CandidateID]
		,[Candidate].[PersonID]
		,[ElectionID]
		,[Votes]
		,[Candidate].[Active]
		,[FirstName]
		,[LastName]
	FROM [Candidate] JOIN [Person] ON [Person].[PersonID] = [Candidate].[PersonID]
	WHERE [ElectionID] = @ElectionID
END
GO

print ' ' print '*** Creating sp_update_candidate'
GO
CREATE PROCEDURE [sp_update_candidate]
(
	@CandidateID  	[int]		,
	
	@OldPersonID	[int]		,
	@OldElectionID	[int]		,
	@OldVotes		[int]		,
	@OldActive		[bit]		,
	
	@NewPersonID	[int]		,
	@NewElectionID	[int]		,
	@NewVotes		[int]		,
	@NewActive		[bit]		
)	
AS
BEGIN
	UPDATE 	[dbo].[Candidate]
	   SET 	PersonID 		= 	@NewPersonID,
			ElectionID		=	@NewElectionID,
			Votes			=	@NewVotes,
			Active			=	@NewActive
	 WHERE	CandidateID		=	@CandidateID
	   AND	PersonID 		= 	@OldPersonID
	   AND	ElectionID		=	@OldElectionID
	   AND  Votes			=   @OldVotes
	   AND	Active			=	@OldActive
	RETURN	@@ROWCOUNT
END
GO

print '' print '*** Creating sp_deactivate_election'
GO
CREATE PROCEDURE [sp_deactivate_candidate]
(
	@CandidateID [int]
)
AS
BEGIN
	UPDATE [dbo].[Candidate]
		SET [Active] = 0
	WHERE	[CandidateID] = @CandidateID
	RETURN @@ROWCOUNT
END
GO

print ' ' print '*** Creating CompletedVote Table'
GO
CREATE TABLE [dbo].[CompletedVote](
	[CompletedVoteID]	[int]	IDENTITY(1000000,1)		NOT NULL,
	[PersonID]			[int]							NOT NULL,
	[ElectionID]		[int]							NOT NULL,
	[HasVoted]			[bit]	DEFAULT 1 				NOT NULL,
	CONSTRAINT [pk_CompletedVoteID] PRIMARY KEY([CompletedVoteID] ASC),
	CONSTRAINT [fk_CompletedVote_Person_PersonID] FOREIGN KEY ([PersonID])
		REFERENCES [Person]([PersonID]),
	CONSTRAINT [fk_CompletedVote_Election_ElectionID] FOREIGN KEY ([ElectionID])
		REFERENCES [Election]([ElectionID])
)
GO

print '' print '*** Creating Sample CompletedVote Records'
GO
INSERT INTO [dbo].[CompletedVote]
	([PersonID],[ElectionID],[HasVoted])
	VALUES
	(1000000,1000000,1),
	(1000001,1000000,0),
	(1000002,1000001,1),
	(1000001,1000001,0),
	(1000000,1000002,1),
	(1000003,1000002,0)
GO

print ' ' print '*** Creating sp_insert_completed_vote'
GO
CREATE PROCEDURE [sp_insert_completed_vote]
(
	@PersonID		[int] 	,
	@ElectionID		[int] 	
)	
AS
BEGIN
	INSERT INTO [dbo].[CompletedVote]
		([PersonID],[ElectionID])
	VALUES
		(@PersonID,@ElectionID)
	SELECT SCOPE_IDENTITY()
END
GO

print ' ' print '*** Creating sp_select_all_completed_votes'
GO
CREATE PROCEDURE [sp_select_all_completed_votes]
AS
BEGIN
	SELECT
		[CompletedVoteID]		
		,[Person].[PersonID]	
		,[ElectionID]			
		,[HasVoted]			
		,[FirstName]			
		,[LastName]		
	FROM [CompletedVote] JOIN [Person] ON [Person].[PersonID] = [CompletedVote].[PersonID]
	ORDER BY [LastName] DESC
END
GO

print ' ' print '*** Creating sp_select_completed_vote_by_Completed_vote_id'
GO
CREATE PROCEDURE [sp_select_completed_vote_by_completed_vote_id]
(
	@CompletedVoteID [int]
)
AS
BEGIN
	SELECT
		[CompletedVoteID]		
		,[Person].[PersonID]	
		,[ElectionID]			
		,[HasVoted]			
		,[FirstName]			
		,[LastName]		
	FROM [CompletedVote] JOIN [Person] ON [Person].[PersonID] = [CompletedVote].[PersonID]
	WHERE [CompletedVoteID] = @CompletedVoteID
END
GO

print ' ' print '*** Creating sp_select_completed_votes_by_election_id'
GO
CREATE PROCEDURE [sp_select_completed_votes_by_election_id]
(
	@ElectionID [int]
)
AS
BEGIN
	SELECT
		[CompletedVoteID]		
		,[Person].[PersonID]	
		,[ElectionID]			
		,[HasVoted]			
		,[FirstName]			
		,[LastName]		
	FROM [CompletedVote] JOIN [Person] ON [Person].[PersonID] = [CompletedVote].[PersonID]
	WHERE [ElectionID] = @ElectionID
END
GO

print ' ' print '*** Creating sp_update_completed_vote'
GO
CREATE PROCEDURE [sp_update_completed_vote]
(
	@CompletedVoteID  	[int]		,
	
	@OldPersonID	[int]		,
	@OldElectionID	[int]		,
	@OldHasVoted	[int]		,
	
	@NewPersonID	[int]		,
	@NewElectionID	[int]		,
	@NewHasVoted	[int]		
)	
AS
BEGIN
	UPDATE 	[dbo].[CompletedVote]
	   SET 	PersonID 		= 	@NewPersonID,
			ElectionID		=	@NewElectionID,
			HasVoted		=	@NewHasVoted
			
	 WHERE	CompletedVoteID	=	@CompletedVoteID
	   AND	PersonID 		= 	@OldPersonID
	   AND	ElectionID		=	@OldElectionID
	   AND  HasVoted		=   @OldHasVoted
	RETURN	@@ROWCOUNT
END
GO

print '' print '*** Creating sp_delete_completed_vote'
GO
CREATE PROCEDURE [sp_delete_completed_vote]
(
	@CompletedVoteID	[int]
)
AS
BEGIN
	DELETE FROM [dbo].[CompletedVote]
	WHERE [CompletedVoteID] = @CompletedVoteID
END
GO



print ' ' print '*** Creating PersonGrantPoints Table'
GO
CREATE TABLE [dbo].[PersonGrantPoints](
	[PersonGrantPointsID]	[int]	IDENTITY(1000000,1)		NOT NULL,
	[PersonID]				[int]							NOT NULL,
	[Points]				[int]							NOT NULL,
	CONSTRAINT [pk_PersonGrantPointsID] PRIMARY KEY([PersonGrantPointsID] ASC),
	CONSTRAINT [fk_PersonGrantPoints_Person_PersonID] FOREIGN KEY ([PersonID])
		REFERENCES [Person]([PersonID])
)
GO

print '' print '*** Creating Sample PersonGrantPoints Records'
GO
INSERT INTO [dbo].[PersonGrantPoints]
	([PersonID],[Points])
	VALUES
	(1000000,8),
	(1000001,4),
	(1000002,2),
	(1000003,8),
	(1000004,8),
	(1000005,8)
GO

print ' ' print '*** Creating sp_insert_person_grant_points'
GO
CREATE PROCEDURE [sp_insert_person_grant_points]
(
	@PersonID		[int],
	@Points			[int] 	
)	
AS
BEGIN
	INSERT INTO [dbo].[PersonGrantPoints]
		([PersonID],[Points])
	VALUES
		(@PersonID,@Points)
	SELECT SCOPE_IDENTITY()
END
GO

print ' ' print '*** Creating sp_select_all_person_grant_points'
GO
CREATE PROCEDURE [sp_select_all_person_grant_points]
AS
BEGIN
	SELECT
		[PersonGrantPointsID]		
		,[Person].[PersonID]	
		,[Points]			
		,[FirstName]			
		,[LastName]		
	FROM [PersonGrantPoints] JOIN [Person] ON [Person].[PersonID] = [PersonGrantPoints].[PersonID]
	ORDER BY [LastName] DESC
END
GO

print ' ' print '*** Creating sp_select_person_grant_points_by_person_grant_points_id'
GO
CREATE PROCEDURE [sp_select_person_grant_points_by_person_grant_points_id]
(
	@PersonGrantPointsID	[int]
)
AS
BEGIN
	SELECT
		[PersonGrantPointsID]		
		,[Person].[PersonID]	
		,[Points]			
		,[FirstName]			
		,[LastName]		
	FROM [PersonGrantPoints] JOIN [Person] ON [Person].[PersonID] = [PersonGrantPoints].[PersonID]
	WHERE [PersonGrantPointsID] = @PersonGrantPointsID
	ORDER BY [LastName] DESC
END
GO

print ' ' print '*** Creating sp_update_person_grant_points'
GO
CREATE PROCEDURE [sp_update_person_grant_points]
(
	@PersonGrantPointsID  	[int]		,
	
	@OldPersonID	[int]		,
	@OldPoints		[int]		,
	
	@NewPersonID	[int]		,
	@NewPoints		[int]		
)	
AS
BEGIN
	UPDATE 	[dbo].[PersonGrantPoints]
	   SET 	PersonID 			= 	@NewPersonID,
			Points				=	@NewPoints
			
	 WHERE	PersonGrantPointsID	=	@PersonGrantPointsID
	   AND	PersonID 			= 	@OldPersonID
	   AND	Points				=	@OldPoints
	RETURN	@@ROWCOUNT
END
GO

print '' print '*** Creating sp_delete_person_grant_points'
GO
CREATE PROCEDURE [sp_delete_person_grant_points]
(
	@PersonGrantPointsID	[int]
)
AS
BEGIN
	DELETE FROM [dbo].[PersonGrantPoints]
	WHERE [PersonGrantPointsID] = @PersonGrantPointsID
END
GO

print ' ' print '*** Creating Grant Table'
GO
CREATE TABLE [dbo].[Grant](
	[GrantID]				[int]	IDENTITY(1000000,1)	NOT NULL,
	[GrantName]				[nvarchar]	(100)			NOT NULL,
	[Points]				[int]	DEFAULT 0					,
	[Description]			[nvarchar]	(1000)					,
	[AmountAskedFor]		[money]						NOT NULL,
	[AmountAwarded]			[money]	DEFAULT 0					,
	[active]				[bit]	DEFAULT 1			NOT NULL,
	CONSTRAINT [pk_GrantID] PRIMARY KEY([GrantID] ASC),
)
GO

print '' print '*** Creating Sample Grant Records'
GO
INSERT INTO [dbo].[Grant]
	([GrantName],[Points],[Description],[AmountAskedFor])
	VALUES
	('TestGrant1',0,'The first test grant',1000),
	('TestGrant2',0,'The second test grant',2000),
	('TestGrant3',0,'The third test grant',3000)
GO

print ' ' print '*** Creating sp_insert_grant'
GO
CREATE PROCEDURE [sp_insert_grant]
(
	@GrantName		[nvarchar] (100),
	@Description	[nvarchar] (1000),
	@AmountAskedFor [money]
	
)	
AS
BEGIN
	INSERT INTO [dbo].[Grant]
		([GrantName],[Description],[AmountAskedFor])
	VALUES
		(@GrantName,@Description,@AmountAskedFor)
	SELECT SCOPE_IDENTITY()
END
GO

print ' ' print '*** Creating sp_select_all_grants'
GO
CREATE PROCEDURE [sp_select_all_grants]
AS
BEGIN
	SELECT
		[GrantID]		
		,[GrantName]	
		,[Points]			
		,[Description]			
		,[AmountAskedFor]
		,[AmountAwarded]
		,[Active]
	FROM [Grant]
	ORDER BY [GrantName] DESC
END
GO

print ' ' print '*** Creating sp_select_grant_by_id'
GO
CREATE PROCEDURE [sp_select_grant_by_id]
(
	@GrantID	[int]
)
AS
BEGIN
	SELECT
		[GrantID]		
		,[GrantName]	
		,[Points]			
		,[Description]			
		,[AmountAskedFor]
		,[AmountAwarded]
		,[Active]
	FROM [Grant]
	WHERE [GrantID] = @GrantID
	ORDER BY [GrantName] DESC
END
GO

print ' ' print '*** Creating sp_update_grant'
GO
CREATE PROCEDURE [sp_update_grant]
(
	@GrantID	  		[int]				,
	
	@OldGrantName		[nvarchar] (100)	,
	@OldPoints			[int]				,
	@OldDescription		[nvarchar] (1000)	,
	@OldAmountAskedFor	[money]				,
	@OldAmountAwarded	[money]				,
	
	@NewGrantName		[nvarchar] (100)	,
	@NewPoints			[int]				,
	@NewDescription		[nvarchar] (1000)	,
	@NewAmountAskedFor	[money]				,
	@NewAmountAwarded	[money]			
)	
AS
BEGIN
	UPDATE 	[dbo].[Grant]
	   SET 	GrantName 		= 	@NewGrantName,
			Points			=	@NewPoints,
			Description		=	@NewDescription,
			AmountAskedFor	=	@NewAmountAskedFor,
			AmountAwarded	=	@NewAmountAwarded
			
	 WHERE	GrantID			=	@GrantID
	   AND	GrantName 		= 	@OldGrantName
	   AND	Points			=	@OldPoints
	   AND	Description		=	@OldDescription
	   AND	AmountAskedFor	=	@OldAmountAskedFor
	   AND	AmountAwarded	=	@OldAmountAwarded
	RETURN	@@ROWCOUNT
END
GO

print '' print '*** Creating sp_deactivate_grant'
GO
CREATE PROCEDURE [sp_deactivate_grant]
(
	@GrantID [int]
)
AS
BEGIN
	UPDATE [dbo].[Grant]
		SET [Active] = 0
	WHERE	[GrantID] = @GrantID
	RETURN @@ROWCOUNT
END
GO

print ' ' print '*** Creating GrantFunds Table'
GO
CREATE TABLE [dbo].[GrantFunds](
	[GrantFundsID]		[int] IDENTITY(1000000,1)	NOT NULL,
	[Amount]			[money]						NOT NULL,			
	CONSTRAINT [pk_GrantFundsID] PRIMARY KEY([GrantFundsID])
)
GO

print ' ' print '*** Creating sp_insert_grant_funds'
GO
CREATE PROCEDURE [sp_insert_grant_funds]
(
	@Amount [money]
)	
AS
BEGIN
	INSERT INTO [dbo].[GrantFunds]
		([Amount])
	VALUES
		(@Amount)
	SELECT SCOPE_IDENTITY()
END
GO

print ' ' print '*** Creating sp_select_grant_funds'
GO
CREATE PROCEDURE [sp_select_grant_funds]
AS
BEGIN
	SELECT
		[Amount]
	FROM [GrantFunds]
END
GO

print ' ' print '*** Creating sp_update_grant_funds'
GO
CREATE PROCEDURE [sp_update_grant_funds]
(
	@GrantFundsID	[int],
	
	@OldAmount		[money],
	
	@NewAmount		[money]	
)	
AS
BEGIN
	UPDATE 	[dbo].[GrantFunds]
	   SET 	Amount 			= 	@NewAmount
	 WHERE	GrantFundsID	=	@GrantFundsID
	   AND	Amount 			= 	@OldAmount
	RETURN	@@ROWCOUNT
END
GO

print ' ' print '*** Creating ActivityType Table'
GO
CREATE TABLE [dbo].[ActivityType](
	[ActivityTypeID]		[nvarchar]	(100)		NOT NULL,
	[Description]			[nvarchar]	(1000)		NOT NULL,
	CONSTRAINT [pk_ActivityTypeID] PRIMARY KEY([ActivityTypeID])
)
GO

print ' ' print '*** Creating Activity Table'
GO
CREATE TABLE[dbo].[Activity](
	[ActivityID]		[int]	IDENTITY(1000000,1)	NOT NULL,
	[ActivityName]		[nvarchar]		(50)		NOT NULL,
	[ActivityTypeID]	[nvarchar]		(100)		NOT NULL,
	--[GroupID]			[nvarchar]		(100)				,
	--[ScheduleID]		[int]						NOT NULL,
	[LocationName]		[nvarchar]		(1000)		NOT NULL,
	[Address1]			[nvarchar]		(250)				,
	[Address2]			[nvarchar]		(250)				,
	[City]				[nvarchar]		(150)				,
	[State]				[nvarchar]		(50)				,
	[Zip]				[nvarchar]		(50)				,
	[Description]		[nvarchar]		(4000)		NOT NULL,
	CONSTRAINT [pk_ActivityID] PRIMARY KEY	([ActivityID]),
	CONSTRAINT [fk_Activity_ActivityType_ActivityTypeID] FOREIGN KEY([ActivityTypeID])
		REFERENCES [ActivityType]([ActivityTypeID])
	--CONSTRAINT [fk_Activity_Group_GroupID] FOREIGN KEY([GroupID])
	--	REFERENCES [Group]([GroupID]),
	--CONSTRAINT [fk_Activity_Schedule_ScheduleID] FOREIGN KEY([ScheduleID])
		--REFERENCES [Schedule]([ScheduleID])
)
GO


print ' ' print '*** Creating Schedule Table'
GO
CREATE TABLE [dbo].[Schedule](
	[ScheduleID]		[int] IDENTITY(1000000,1)	NOT NULL,
	[PersonID]			[int]						,
	[ActivityID]		[int]						,
	[Type]				[nvarchar](50)			 	,
	[ActivitySchedule]	[bit]						,
	[Start]				[datetime]					NOT NULL,
	[End]				[datetime]					NOT NULL,
	[Active]			[bit]  DEFAULT(1)			NOT NULL,
	CONSTRAINT [pk_ScheduleID] PRIMARY KEY([ScheduleID] ASC),
	CONSTRAINT [fk_Schedule_Person_PersonID] FOREIGN KEY([PersonID])
		REFERENCES [Person]([PersonID]),
	CONSTRAINT [fk_Schedule_Activity_ActivityID] FOREIGN KEY([ActivityID])
		REFERENCES [Activity]([ActivityID])
)
GO

print ' ' print '*** Creating Role Table'
GO
CREATE TABLE [dbo].[Role](
	[RoleID]		[nvarchar]	(100)	NOT NULL,
	CONSTRAINT [pk_RoleID] PRIMARY KEY ([RoleID] ASC)
)
GO

print ' ' print '*** Creating PersonRole Table'
GO
CREATE TABLE [dbo].[PersonRole](
	[PersonID]		[int]				NOT NULL,
	[RoleID]		[nvarchar]	(100)	NOT NULL,
	[IsApproved]	[bit] DEFAULT(1)	NOT NULL, 
	CONSTRAINT [pk_PersonID_RoleID] PRIMARY KEY([PersonID] ASC, [RoleID] ASC),
	CONSTRAINT [fk_PersonRole_Person_PersonID] FOREIGN KEY([PersonID])
		REFERENCES [Person]([PersonID]),
	CONSTRAINT [fk_PersonRole_Role_RoleID] FOREIGN KEY([RoleID])
		REFERENCES [Role]([RoleID])
)
GO

print ' ' print '*** Creating Group Table'
GO
CREATE TABLE [dbo].[Group](
	[GroupID]		[nvarchar]	(100)		NOT NULL,
	[Description]	[nvarchar]	(1000)		NOT NULL,
	CONSTRAINT [pk_GroupID] PRIMARY KEY([GroupID] ASC)
)
GO
	
print ' ' print '*** Creating PersonGroup Table'
GO
CREATE TABLE [dbo].[PersonGroup](
	[PersonID]		[int]				NOT NULL,
	[GroupID]		[nvarchar]	(100)	NOT NULL,
	[IsApproved]	[bit]				NOT NULL,
	CONSTRAINT [pk_PersonID_GroupID] PRIMARY KEY([PersonID] ASC, [GroupID] ASC),
	CONSTRAINT [fk_PersonGroup_Person_PersonID] FOREIGN KEY([PersonID])
		REFERENCES[Person]([PersonID]),
	CONSTRAINT [fk_PersonGroup_Group_GroupID] FOREIGN KEY([GroupID])
		REFERENCES[Group]([GroupID])
)
GO


print ' ' print '*** Creating PersonActivity Table'
GO
CREATE TABLE [dbo].[PersonActivity](
	[PersonID]		[int]				NOT NULL,
	[ActivityID]	[int]				NOT NULL,
	CONSTRAINT [pk_PersonID_ActivityID] PRIMARY KEY([PersonID] ASC, [ActivityID] ASC),
	CONSTRAINT [fk_PersonActivity_Person_PersonID] FOREIGN KEY([PersonID])
		REFERENCES [Person]([PersonID]),
	CONSTRAINT [fk_PersonActivity_Activity_ActivityID] FOREIGN KEY([ActivityID])
		REFERENCES [Activity]([ActivityID])
)
GO

print ' ' print '*** Creating Facility Table'
GO
CREATE TABLE [dbo].[Facility](
	[FacilityID]		[int]	IDENTITY(1000000,1)	NOT NULL,
	[FacilityName]		[nvarchar]	(100)			NOT NULL,
	[Description]		[nvarchar]	(1000)			NOT NULL,
	[PricePerHour]		[money]						NOT NULL,
	[FacilityType]		[nvarchar]	(100)			NOT NULL,
	[Active] 			[bit] DEFAULT(1)			NOT NULL,
	CONSTRAINT [pk_FacilityID] PRIMARY KEY([FacilityID])
)
GO

print ' ' print '*** Creating Booking Table'
GO
CREATE TABLE[dbo].[Booking](
	[BookingID]			[int]	IDENTITY(1000000,1)	NOT NULL,
	[FacilityID]		[int]						NOT NULL,
	[PersonID]			[int]			  			NOT NULL,
	--[ActivityID]		[int]								,
	[ScheduledCheckOut]	[datetime]					NOT NULL,
	[ScheduledCheckIn]	[datetime]					NOT NULL,
	[CheckOut]			[datetime]							,
	[CheckIn]			[datetime]							,
	[Active]			[bit] DEFAULT(1)					,
	CONSTRAINT [pk_BookingID] PRIMARY KEY	([BookingID]),
	CONSTRAINT [fk_Booking_Facility_FacilityID] FOREIGN KEY([FacilityID])
		REFERENCES [Facility]([FacilityID]),
	CONSTRAINT [fk_Booking_Person_PersonID] FOREIGN KEY([PersonID])
		REFERENCES [Person]([PersonID]),
	--CONSTRAINT [fk_Booking_Activity_ActivityID] FOREIGN KEY([ActivityID])
		--REFERENCES [Activity]([ActivityID])
)
GO

print ' ' print '*** Creating GroupActivity Table'
GO
CREATE TABLE[dbo].[GroupActivity](
	[GroupID]		[nvarchar]	(100)		NOT NULL,
	[ActivityID]		[int]				NOT NULL,
	CONSTRAINT [pk_GroupID_ActivityID] PRIMARY KEY([GroupID] ASC, [ActivityID] ASC),
	CONSTRAINT [fk_GroupActivity_Group_GroupID] FOREIGN KEY([GroupID])
		REFERENCES [Group]([GroupID]),
	CONSTRAINT [fk_GroupActivity_Activity_ActivityID] FOREIGN KEY([ActivityID])
		REFERENCES [Activity]([ActivityID])
)
GO

print '' print '*** Creating Sample Facilty Records'
GO
INSERT INTO [dbo].[Facility]
	([FacilityName],[Description],[PricePerHour],[FacilityType])
	VALUES
	('Van 01','A van owned and used by the church',10.00,'Vehicle'),
	('Earnst Hall','A Place where gatherings can be held',20.00,'Building'),
	('Bus 01','A bus owned and used by the church',15.00,'Vehicle'),
	('Van 02','A van owned and used by the church',10.00,'Vehicle'),
	('Hubby Hall','A Place where gatherings can be held',20.00,'Building'),
	('Bus 03','A bus owned and used by the church',10.00,'Vehicle'),
	('Grill','A large grill used for hosting community cook outs',5.00,'Grill')
GO
	

print '' print '*** Creating Sample Role Records'
GO
INSERT INTO [dbo].[Role]
	([RoleID])
	VALUES
	('Administrator'),
	('Pastor'),
	('Manager'),
	('Member'),
	('Visitor'),
	('Volunteer'),
	('Employee')
GO
	


print '' print '*** Creating Sample PersonRole Records'
GO
INSERT INTO [dbo].[PersonRole]
	([PersonID], [RoleID])
	VALUES
	(1000000,'Administrator'),
	(1000000,'Pastor'),
	(1000000,'Employee'),
	(1000001,'Employee'),
	(1000002,'Employee'),
	(1000003,'Employee'),
	(1000000,'Manager'),
	(1000001,'Volunteer'),
	(1000005,'Visitor'),
	(1000006,'Visitor'),
	(1000000,'Member'),
	(1000001,'Member'),
	(1000002,'Member'),
	(1000003,'Member'),
	(1000004,'Member')
	
GO

print '' print '*** Creating Sample ActivityType Records'
GO
INSERT INTO [dbo].[ActivityType]
	([ActivityTypeID],[Description])
	VALUES
	('Fundraiser','This type of activity is used to raise money'),
	('Service','This is a church service put on by the church'),
	('Social Event','This is a social event put on by the church'),
	('Adult Class','This is a class for teaching'),
	('Meal','This is some sort of dinner service'),
	('Child Care','This is when child care will be available'),
	('Child Class','This is a church class for children')
	
GO

print '' print '*** Creating Sample Activity Records'
GO
INSERT INTO [dbo].[Activity]
	([ActivityName],[ActivityTypeID],[LocationName],[Address1],[Address2],[City],[State],[Zip],[Description])
	VALUES
	('Sunday Worship','Service','Earnst Hall','123 the way st.','','Cedar Rapids','Iowa','52404','This is a standard church service, the kind that is held on sunday morning'),
	('Baked Goods Sale','Fundraiser','Earnst Hall','123 the way st.','','Cedar Rapids','Iowa','52404','Sell cookies and other baked goods  to raise money for church'),
	('Old date test','Service','Earnst Hall','123 the way st.','','Cedar Rapids','Iowa','52404','Sell cookies and other baked goods  to raise money for church'),
	('Test','Fundraiser','TestLoc','TestAdd1','TestAdd2','TestCity','TestState','TestZip','TestDisc'),
	('Community Meal','Meal','Earnst Hall','123 the way st.','','Cedar Rapids','Iowa','52404','A meal put on for the community')
	
GO

print '' print '*** Creating Sample Schedule Records'
GO
INSERT INTO [dbo].[Schedule]
	([PersonID],[ActivityID],[Type],[ActivitySchedule],[start],[end])
	VALUES
	(null,1000001,'',1,'2020-08-12 12:00:00 PM','2020-08-12 03:30:00 PM'),
	(null,1000000,'',1,'2020-09-09 12 PM','2020-09-09 3 PM'),
	(null,1000002,'',1,'1990-9-9 9 PM','1990-9-9 11 PM'),
	(1000000,1000001,'Volunteer',0,'2020-10-10 12 PM','2020-10-10 3PM'),
	(null,1000003,'',1,'07-12-2020 10am','07-12-2020 3pm'),
	(null,1000004,'',1,'06-10-2020 4pm','06-10-2020 6pm'),
	(1000000,1000000,'Employee',0,'2020-09-09 12 PM','2020-09-09 3 PM'),
	(1000000,1000002,'Employee',0,'1990-9-9 9 PM','1990-9-9 11 PM')
GO


print '' print '*** Creating Sample Group Records'
GO
INSERT INTO [dbo].[Group]
	([GroupID],[Description])
	VALUES
	('Children','Ministry for young children'),
	('Youth','Ministry for teenagers'),
	('Adult','Ministry for adults'),
	('Worship','Sunday Morning Worship Services'),
	('Revolution','Addiction recovery ministry'),
	('Women','Ministry for women')
GO

print '' print '*** Creating Sample PersonGroup Records'
GO
INSERT INTO [dbo].[PersonGroup]
	([PersonID],[GroupID],[IsApproved])
	VALUES
	(1000000,'Adult',1),
	(1000000,'Worship',1),
	(1000000,'Revolution',1),
	(1000001,'Revolution',1),
	(1000002,'Revolution',0),
	(1000001,'Children',1),
	(1000001,'Youth',1),
	(1000001,'Women',1)
GO

print '' print '*** Creating Sample PersonActivity Records'
GO
INSERT INTO [dbo].[PersonActivity]
	([PersonID], [ActivityID])
	VALUES
	(1000000,1000000),
	(1000000,1000001),
	(1000001,1000000),
	(1000001,1000001),
	(1000002,1000000)
	
	
GO

print '' print '*** Creating Sample GroupActivity Records'
GO
INSERT INTO [dbo].[GroupActivity]
	([GroupID], [ActivityID])
	VALUES
	('Adult',1000000),
	('Adult',1000001),
	('Worship',1000000),
	('Worship',1000001),
	('Revolution',1000000)
GO

print '' print '*** Creating Sample Booking Records'
GO
INSERT INTO [dbo].[Booking]
	([FacilityID],[PersonID],[ScheduledCheckOut],[ScheduledCheckIn])
	VALUES
	(1000000,1000000,'10-10-2020 10am','10-10-2020 3pm'),
	(1000001,1000001,'12-10-2020 12pm','12-10-2020 2pm'),
	(1000002,1000001,'10-10-2021 12pm','10-10-2021 5pm'),
	(1000003,1000000,'02-02-2020 12pm','02-02-2020 4pm')
GO

print '' print '*** Creating sp_insert_person'
GO
CREATE PROCEDURE [sp_insert_person]
(
	@FirstName 		[nvarchar] 	(50),
	@LastName		[nvarchar] 	(50),
	@Dob			[date]			,
	@PhoneNumber	[nvarchar]	(11),
	@Email			[nvarchar]	(250),
	@Address1		[nvarchar]	(250),
	@Address2		[nvarchar]	(250),
	@City			[nvarchar]	(150),
	@State			[nvarchar]	(50),
	@Zip			[nvarchar]	(50)
)
AS
BEGIN
	INSERT INTO [dbo].[Person]
	([FirstName], [LastName], [Dob], [PhoneNumber], [Email], [Address1], [Address2], [City], [State], [Zip] , [Active])
	VALUES
	(@FirstName,@LastName,@Dob,@PhoneNumber,@Email,@Address1,@Address2,@City,@State,@Zip,1)
	RETURN SCOPE_IDENTITY()
END
GO

print '' print '*** Creating sp_authenticate_user'
GO
CREATE PROCEDURE [sp_authenticate_user]
(
	@Email				[nvarchar](250),
	@PasswordHash		[nvarchar](100)
)
AS
BEGIN
	SELECT 	COUNT([PersonID])
	FROM	[dbo].[Person]
	WHERE	[Email] = @Email
	AND		[PasswordHash] = @PasswordHash
END
GO

print '' print '*** Creating sp_select_person_by_email'
GO
CREATE PROCEDURE [sp_select_person_by_email]
(
	@Email			[nvarchar](250)
)
AS
BEGIN
	SELECT [PersonID],[FirstName],[LastName],[PhoneNumber]
	FROM [dbo].[Person]
	WHERE [Email] = @Email
END
GO

print '' print '*** Creating sp_select_roles_by_person_id'
GO
CREATE PROCEDURE [sp_select_roles_by_person_id]
(
	@PersonID				[int]
)
AS
BEGIN
	SELECT [RoleID]
	FROM [dbo].[PersonRole]
	WHERE [PersonID] = @PersonID
	AND [IsApproved] = 1
END
GO

print '' print '*** Creating sp_update_password'
GO
CREATE PROCEDURE [sp_update_password]
(
	@PersonID				[int],
	@OldPasswordHash		[nvarchar](100),
	@NewPasswordHash		[nvarchar](100)
)
AS
BEGIN
	UPDATE 	[dbo].[Person]
	SET 	[PasswordHash]	= @NewPasswordHash
	WHERE 	[PersonID] 	= @PersonID
	AND		[PasswordHash]	= @OldPasswordHash
	RETURN	@@ROWCOUNT
END
GO

print '' print '*** Creating sp_select_users_by_active'
GO
CREATE PROCEDURE [sp_select_users_by_active]
(
	@Active		[bit]
)
AS
BEGIN
	SELECT [PersonID],[FirstName],[LastName],[Dob],[PhoneNumber],[Email],[Address1],[Address2],[City],[State],[Zip],[Active]
	FROM [dbo].[Person]
	WHERE [Active] = @Active
END
GO

print '' print '*** Creating sp_select_all_users'
GO
CREATE PROCEDURE [sp_select_all_users]
AS
BEGIN
	SELECT [PersonID],[FirstName],[LastName],[PhoneNumber],[Email],[Address1],[Address2],[City],[State],[Zip],[Active]
	FROM [dbo].[Person]
END
GO

print '' print '*** Creating sp_update_Person'
GO
CREATE PROCEDURE [sp_update_person]
(
	@PersonID		[int],
	
	@OldFirstName 		[nvarchar] 	(50),
	@OldLastName		[nvarchar] 	(50),
	@OldDob				[date]			,
	@OldPhoneNumber		[nvarchar]	(11),
	@OldEmail			[nvarchar]	(250),
	@OldAddress1		[nvarchar]	(250),
	@OldAddress2		[nvarchar]	(250),
	@OldCity			[nvarchar]	(150),
	@OldState			[nvarchar]	(50),
	@OldZip				[nvarchar]	(50),
				
	@NewFirstName 		[nvarchar] 	(50),
	@NewLastName		[nvarchar] 	(50),
	@NewDob				[date]			,
	@NewPhoneNumber		[nvarchar]	(11),
	@NewEmail			[nvarchar]	(250),
	@NewAddress1		[nvarchar]	(250),
	@NewAddress2		[nvarchar]	(250),
	@NewCity			[nvarchar]	(150),
	@NewState			[nvarchar]	(50),
	@NewZip				[nvarchar]	(50)
)
AS
BEGIN
	UPDATE 	[dbo].[Person]
	   SET 	FirstName 	= 	@NewFirstName,
			LastName	=	@NewLastName,
			Dob			=	@NewDob,
			PhoneNumber	=	@NewPhoneNumber,
			Email		=	@NewEmail,
			Address1	=	@NewAddress1,
			Address2	=	@NewAddress2,
			City		=	@NewCity,
			[State]		=	@NewState,
			Zip			=	@NewZip
	 WHERE	PersonID	=	@PersonID
	   AND	FirstName 	= 	@OldFirstName
	   AND	LastName	=	@OldLastName
	   AND	Dob			=	@OldDob
	   AND	PhoneNumber	=	@OldPhoneNumber
	   AND	Email		=	@OldEmail
	   AND	Address1	=	@OldAddress1
	   AND	Address2	=	@OldAddress2
	   AND	City		=	@OldCity
	   AND	[State]		=	@OldState
	   AND	Zip			=	@OldZip
	RETURN	@@ROWCOUNT
END
GO

print '' print '*** Creating sp_insert_person_role'
GO
CREATE PROCEDURE [sp_insert_person_role]
(
	@PersonID	[int],
	@RoleID		[nvarchar] (100)
)
AS
BEGIN
	INSERT INTO [dbo].[PersonRole]
	([PersonID],[RoleID])
	VALUES
	(@PersonID,@RoleID)
END
GO

print '' print '*** Creating sp_delete_person_role'
GO
CREATE PROCEDURE [sp_delete_person_role]
(
	@PersonID 	[int],
	@RoleID		[nvarchar] (100)
)
AS
BEGIN
	DELETE FROM [dbo].[PersonRole]
	WHERE [PersonID] = @PersonID
	AND [RoleID] = @RoleID
END
GO

print '' print '*** Creating sp_insert_person_group'
GO
CREATE PROCEDURE [sp_insert_person_group]
(
	@PersonID				[int],
	@GroupID				[nvarchar] (100)
)
AS
BEGIN
	INSERT INTO [dbo].[PersonGroup]
	([PersonID],[GroupID],[IsApproved])
	VALUES
	(@PersonID,@GroupID,1)
END
GO

print '' print '*** Creating sp_delete_person_group'
GO
CREATE PROCEDURE [sp_delete_person_group]
(
	@PersonID 		[int],
	@GroupID		[nvarchar] (100)
)
AS
BEGIN
	DELETE FROM [dbo].[PersonGroup]
	WHERE [PersonID] = @PersonID
	AND [GroupID] = @GroupID
END
GO

print '' print '*** Creating sp_select_groups_by_person_id'
GO
CREATE PROCEDURE [sp_select_groups_by_person_id]
(
	@PersonID				[int]
)
AS
BEGIN
	SELECT [GroupID]
	FROM [dbo].[PersonGroup]
	WHERE [PersonID] = @PersonID
	AND [IsApproved] = 1
END
GO

print '' print '*** Creating sp_select_all_groups'
GO
CREATE PROCEDURE [sp_select_all_groups]
AS
BEGIN
	SELECT GroupID
	FROM [Group]
END
GO

print '' print '*** Creating sp_select_all_roles'
GO
CREATE PROCEDURE [sp_select_all_roles]
AS
BEGIN
	SELECT RoleID
	FROM [Role]
END
GO

print '' print '*** Creating sp_reactivate_person'
GO
CREATE PROCEDURE [sp_reactivate_person]
(
	@PersonID [int]
)
AS
BEGIN
	UPDATE [dbo].[Person]
		SET [Active] = 1
	WHERE	[PersonID] = @PersonID
	RETURN @@ROWCOUNT
END
GO

print '' print '*** Creating sp_deactivate_person'
GO
CREATE PROCEDURE [sp_deactivate_person]
(
	@PersonID [int]
)
AS
BEGIN
	UPDATE [dbo].[Person]
		SET [Active] = 0
	WHERE	[PersonID] = @PersonID
	RETURN @@ROWCOUNT
END
GO

print '' print '*** Creating sp_select_schedule_by_personID'
GO
CREATE PROCEDURE [sp_select_schedule_by_person_id]
(
	@PersonID [int]
)
AS
BEGIN
	SELECT 
		[Person].[PersonID],[ScheduleID],[FirstName],[LastName],[Schedule].[Type],[Start],[End]
		,[ActivityName],[Description],[Activity].[ActivityID],[LocationName],[Activity].[Address1]
		,[Activity].[Address2],[Activity].[City],[Activity].[State],[Activity].[Zip],[Activity].[ActivityTypeID]
	FROM [Person] JOIN [Schedule] ON [Person].[PersonID] = [Schedule].[PersonID]
	JOIN [Activity] ON [Activity].[ActivityID] = [Schedule].[ActivityID]
	WHERE [Person].[PersonID] = @PersonID
	AND [Schedule].[Active] = 1
	Order By [Start]
	RETURN SCOPE_IDENTITY()
END
GO

print '' print '*** Creating sp_select_activities_by_activity_schedule'
GO
CREATE PROCEDURE [sp_select_activities_by_activity_schedule]
(
	@ActivitySchedule [bit]
)
AS
BEGIN
	SELECT 
		[Activity].[ActivityID],[ActivityName],[ActivityTypeID],
		[LocationName],[Address1],[Address2],[City],[State],[Zip],
		[Description],[start],[end],[ScheduleID]
	FROM [Activity] JOIN [Schedule] ON [Activity].[ActivityID] = [Schedule].[ActivityID]
	WHERE [Schedule].[ActivitySchedule] = 1
	AND [Start] > CURRENT_TIMESTAMP
END
GO

print '' print '*** Creating sp_select_activities_by_person_id'
GO
CREATE PROCEDURE [sp_select_activities_by_person_id]
(
	@PersonID				[int],
	@ActivitySchedule		[bit]
)
AS
BEGIN
	SELECT [Activity].[ActivityID],[ActivityName],[ActivityTypeID],
		[LocationName],[Address1],[Address2],[City],[State],[Zip],
		[Description],[start],[end],[PersonActivity].[PersonID],[ScheduleID]
	FROM [Activity] JOIN [Schedule] ON [Activity].[ActivityID] = [Schedule].[ActivityID]
	JOIN [PersonActivity] ON [PersonActivity].[ActivityID] = [Activity].[ActivityID]
	WHERE [PersonActivity].[PersonID] = @PersonID
	AND [ActivitySchedule] = @ActivitySchedule
	AND [start] > CURRENT_TIMESTAMP
END
GO

print '' print '*** Creating sp_insert_person_activity'
GO
CREATE PROCEDURE [sp_insert_person_activity]
(
	@PersonID				[int],
	@ActivityID				[int]
)
AS
BEGIN
	INSERT INTO [dbo].[PersonActivity]
	([PersonID],[ActivityID])
	VALUES
	(@PersonID,@ActivityID)
END
GO

print '' print '*** Creating sp_delete_person_activity'
GO
CREATE PROCEDURE [sp_delete_person_activity]
(
	@PersonID 	[int],
	@ActivityID	[int]
)
AS
BEGIN
	DELETE FROM [dbo].[PersonActivity]
	WHERE [PersonID] = @PersonID
	AND [ActivityID] = @ActivityID
END
GO

print '' print '*** Creating sp_select_person_by_activity'
GO
CREATE PROCEDURE [sp_select_person_by_activity]
(
	@ActivityID	[int]
)
AS
BEGIN
	SELECT
		[Person].[PersonID],[FirstName],[LastName]
	FROM [Person] JOIN [PersonActivity] ON [Person].[PersonID] = [PersonActivity].[PersonID]
	WHERE [ActivityID] = @ActivityID
END
GO

print '' print '*** Creating sp_insert_activity'
GO
CREATE PROCEDURE [sp_insert_activity]
(
	@ActivityName	[nvarchar] (50),
	@ActivityTypeID [nvarchar] (100),
	@LocationName	[nvarchar] (1000),
	@Address1		[nvarchar] (250),
	@Address2		[nvarchar] (250),
	@City			[nvarchar] (150),
	@State			[nvarchar] (50),
	@Zip			[nvarchar] (50),
	@Description	[nvarchar] (4000)
)	
AS
BEGIN
	INSERT INTO [dbo].[Activity]
		([ActivityName],[ActivityTypeID],[LocationName],[Address1],[Address2],[City],[State],[Zip],[Description])
	VALUES
		(@ActivityName, @ActivityTypeID, @LocationName, @Address1, @Address2, @City, @State, @Zip, @Description)
	SELECT SCOPE_IDENTITY()
END
GO

print '' print '*** Creating sp_select_all_activity_types'
GO
CREATE PROCEDURE [sp_select_all_activity_types]
AS
BEGIN
	SELECT
		[ActivityTypeID]
	FROM [dbo].[ActivityType]
END
GO

print '' print '*** Creating sp_insert_activity_schedule'
GO
CREATE PROCEDURE [sp_insert_activity_schedule]
(
	@ActivityID	[nvarchar] (50),
	@Start      [datetime],
	@END		[datetime]
)	
AS
BEGIN
	INSERT INTO [dbo].[Schedule]
		([ActivityID],[ActivitySchedule],[Start],[End])
	VALUES
		(@ActivityID,1,@Start,@End)
	
END
GO

print '' print '*** Creating sp_update_activity'
GO
CREATE PROCEDURE [sp_update_activity]
(
	@ActivityID		[int]	,
	
	@OldActivityName		[nvarchar]		(50)		,
	@OldActivityTypeID		[nvarchar]		(100)		,
	@OldLocationName		[nvarchar]		(1000)		,
	@OldAddress1			[nvarchar]		(250)		,
	@OldAddress2			[nvarchar]		(250)		,
	@OldCity				[nvarchar]		(150)		,
	@OldState				[nvarchar]		(50)		,
	@OldZip					[nvarchar]		(50)		,
	@OldDescription			[nvarchar]		(4000)		,
	
	@NewActivityName		[nvarchar]		(50)		,
	@NewActivityTypeID		[nvarchar]		(100)		,
	@NewLocationName		[nvarchar]		(1000)		,
	@NewAddress1			[nvarchar]		(250)		,
	@NewAddress2			[nvarchar]		(250)		,
	@NewCity				[nvarchar]		(150)		,
	@NewState				[nvarchar]		(50)		,
	@NewZip					[nvarchar]		(50)		,
	@NewDescription			[nvarchar]		(4000)		
)	
AS
BEGIN
	UPDATE [dbo].[Activity]
	SET 	ActivityName 	= 	@NewActivityName,
			ActivityTypeID	=	@NewActivityTypeID,
			LocationName	=	@NewLocationName,
			Address1		=	@NewAddress1,
			Address2		=	@NewAddress2,
			City			=	@NewCity,
			[State]			=	@NewState,
			Zip				=	@NewZip,
			Description		=	@NewDescription
	 WHERE	ActivityID		=	@ActivityID
	   AND	ActivityName 	= 	@OldActivityName
	   AND	ActivityTypeID	=	@OldActivityTypeID
	   AND	LocationName	=	@OldLocationName
	   AND	Address1		=	@OldAddress1
	   AND	Address2		=	@OldAddress2
	   AND	City			=	@OldCity
	   AND	[State]			=	@OldState
	   AND	Zip				=	@OldZip
	   AND	Description		=	@OldDescription
	RETURN	@@ROWCOUNT
END
GO

print '' print '*** Creating sp_update_activity_schedule'
GO
CREATE PROCEDURE [sp_update_activity_schedule]
(
	@ScheduleID		[int],
	
	@OldActivityID	[int],
	@OldStart		[datetime],
	@OldEnd			[datetime],
	
	@NewActivityID	[int],
	@NewStart		[datetime],
	@NewEnd			[datetime]
)
AS
BEGIN
	UPDATE [dbo].[schedule]
	   SET	ActivityID	=	@NewActivityID,
			[Start]		=	@NewStart,
			[End]		=	@NewEnd
	 WHERE	ScheduleID	=	@ScheduleID
	   AND	ActivityID	=	@OldActivityID
	   AND	[Start]		=	@OldStart
	   AND	[End]		=	@OldEnd
	RETURN	@@ROWCOUNT
END
GO

print '' print '*** Creating sp_select_groups_by_activity_id'
GO
CREATE PROCEDURE [sp_select_groups_by_activity_id]
(
	@ActivityID		[int]
)
AS
BEGIN
	SELECT [GroupID]
	FROM	[GroupActivity]
	WHERE	[ActivityID] = @ActivityID
END
GO

print '' print '*** Creating sp_select_activities_by_group_id'
GO
CREATE PROCEDURE [sp_select_activities_by_group_id]
(
	@GroupID		[nvarchar](100)
)
AS
BEGIN
	SELECT
		[Activity].[ActivityID],[ActivityName],[Start],[End],[GroupID]
	FROM [Activity] JOIN [GroupActivity] ON [Activity].[ActivityID] = [GroupActivity].[ActivityID]
	JOIN [Schedule] ON [Schedule].[ActivityID] = [Activity].[ActivityID]
	WHERE [ActivitySchedule] = 1
	AND [GroupID] = @GroupID
END
GO

print '' print '*** Creating sp_select_users_by_group_id'
GO
CREATE PROCEDURE [sp_select_users_by_group_id]
(
	@GroupID		[nvarchar](100)
	
)
AS
BEGIN
	SELECT 	[Person].[PersonID],[FirstName],[LastName]
	FROM	[Person] JOIN [PersonGroup] ON [Person].[PersonID] = [PersonGroup].[PersonID]
	WHERE 	[GroupID] = @GroupID
	AND		[IsApproved] = 1
END
GO


print '' print '*** Creating sp_delete_group_activity'
GO
CREATE PROCEDURE [sp_delete_group_activity]
(
	@GroupID 	[nvarchar](100),
	@ActivityID	[int]
)
AS
BEGIN
	DELETE FROM [dbo].[GroupActivity]
	WHERE [ActivityID] = @ActivityID
	AND [GroupID] = @GroupID
END
GO

print '' print '*** Creating sp_insert_unapproved_person_group'
GO
CREATE PROCEDURE [sp_insert_unapproved_person_group]
(
	@PersonID				[int],
	@GroupID				[nvarchar] (100)
)
AS
BEGIN
	INSERT INTO [dbo].[PersonGroup]
	([PersonID],[GroupID],[IsApproved])
	VALUES
	(@PersonID,@GroupID,0)
END
GO

print '' print '*** Creating sp_select_unapproved_person_groups'
GO
CREATE PROCEDURE [sp_select_unapproved_person_groups]
(
	@PersonID				[int]
)
AS
BEGIN
	SELECT	[GroupID]
	FROM [PersonGroup]
	WHERE [PersonID] = @PersonID
	AND [IsApproved] = 0
END
GO

print '' print '*** Creating sp_select_all_group_activities'
GO
CREATE PROCEDURE [sp_select_all_group_activities]
AS
BEGIN
	SELECT [Activity].[ActivityID],[ActivityName],[Start],[End]
	FROM [Activity] JOIN [Schedule] ON [Schedule].[ActivityID] = [Activity].[ActivityID]	
	WHERE [ActivitySchedule] = 1
	AND [Start] > CURRENT_TIMESTAMP
END
GO

print '' print '*** Creating sp_insert_group_activity'
GO
CREATE PROCEDURE [sp_insert_group_activity]
(
	@GroupID				[nvarchar](100) ,
	@ActivityID				[int]
)
AS
BEGIN
	INSERT INTO [dbo].[GroupActivity]
	([ActivityID],[GroupID])
	VALUES
	(@ActivityID,@GroupID)
	RETURN @@ROWCOUNT
END
GO

print '' print '*** Creating sp_select_unapproved_users_by_group_id'
GO
CREATE PROCEDURE [sp_select_unapproved_users_by_group_id]
(
	@GroupID	[nvarchar](100)
)
AS
BEGIN
	SELECT
	[Person].[PersonID],[FirstName],[LastName]
	FROM [Person] JOIN [PersonGroup] ON [Person].[PersonID] = [PersonGroup].[PersonID]
	WHERE [IsApproved] = 0
	AND [GroupID] = @GroupID
END
GO

print '' print '*** Creating sp_update_person_group_as_approved'
GO
CREATE PROCEDURE [sp_update_person_group_as_approved]
(
	@GroupID	[nvarchar](100),
	@PersonID	[int]
)
AS
BEGIN
	UPDATE [PersonGroup]
	SET [IsApproved] = 1
	WHERE	[GroupID] = @GroupID
	AND		[PersonID] = @PersonID
	RETURN @@ROWCOUNT
END
GO

print '' print '*** Creating sp_update_person_group_as_approved'
GO
CREATE PROCEDURE [sp_select_activities_by_schedule_type]
(
	@Type	[nvarchar](50),
	@PersonID [int]
)
AS
BEGIN
	SELECT[Activity].[ActivityID],[ActivityName],[ActivityTypeID],[LocationName],[Address1],[Address2],[City]
		,[State],[Zip],[Description],[ScheduleID],[PersonID],[Type],[Start],[End]
	FROM [Activity] JOIN [Schedule] ON [Activity].[ActivityID] = [Schedule].[ActivityID]
	WHERE [Start] > CURRENT_TIMESTAMP
	AND [Type] = @Type
	AND [PersonID] = @PersonID
	AND [Active] = 1
END
GO

print '' print '*** Creating sp_insert_schedule'
GO
CREATE PROCEDURE [sp_insert_schedule]
(
	@PersonID			[int],
	@ActivityID 		[int],
	@Type				[nvarchar] (50),
	@ActivitySchedule 	[bit],
	@Start  			[datetime],
	@End				[datetime]
)
AS
BEGIN
	INSERT INTO [dbo].[Schedule]
	([PersonID],[ActivityID],[Type],[ActivitySchedule],[start],[end])
	VALUES (@PersonID, @ActivityID, @Type, @ActivitySchedule, @Start, @End)
	RETURN @@ROWCOUNT
END
GO

print '' print '*** Creating sp_deactivate_schedule'
GO
CREATE PROCEDURE [sp_deactivate_schedule]
(
	@ScheduleID [int]
)
AS
BEGIN
	UPDATE [dbo].[Schedule]
		SET [Active] = 0
	WHERE	[ScheduleID] = @ScheduleID
	RETURN @@ROWCOUNT
END
GO

print '' print '*** Creating sp_update_person_role_as_approved'
GO
CREATE PROCEDURE [sp_update_person_role_as_approved]
(
	@RoleID	[nvarchar](100),
	@PersonID	[int]
)
AS
BEGIN
	UPDATE [PersonRole]
	SET [IsApproved] = 1
	WHERE	[RoleID] = @RoleID
	AND		[PersonID] = @PersonID
	RETURN @@ROWCOUNT
END
GO

print '' print '*** Creating sp_insert_unapproved_person_role'
GO
CREATE PROCEDURE [sp_insert_unapproved_person_role]
(
	@PersonID			[int],
	@RoleID				[nvarchar](100)
)
AS
BEGIN
	INSERT INTO [dbo].[PersonRole]
	([PersonID],[RoleID],[IsApproved])
	VALUES
	(@PersonID,@RoleID,0)
	RETURN @@ROWCOUNT
END
GO

print '' print '*** Creating sp_select_unapproved_person_roles'
GO
CREATE PROCEDURE [sp_select_unapproved_person_roles]
(
	@PersonID				[int]
)
AS
BEGIN
	SELECT	[RoleID]
	FROM [PersonRole]
	WHERE [PersonID] = @PersonID
	AND [IsApproved] = 0
END
GO

print '' print '*** Creating sp_select_unapproved_persons_role_id'
GO
CREATE PROCEDURE [sp_select_unapproved_users_by_role_id]
(
	@RoleID	[nvarchar](100)
)
AS
BEGIN
	SELECT
	[Person].[PersonID],[FirstName],[LastName]
	FROM [Person] JOIN [PersonRole] ON [Person].[PersonID] = [PersonRole].[PersonID]
	WHERE [IsApproved] = 0
	AND [RoleID] = @RoleID
END
GO

print '' print '*** Creating sp_select_user_by_role_id'
GO
CREATE PROCEDURE [sp_select_user_by_role_id]
(
	@RoleID	[nvarchar](100),
	@IsApproved [bit],
	@Active		[bit]
)
AS
BEGIN
	SELECT
	[Person].[PersonID],[FirstName],[LastName],[Dob],[PhoneNumber]
	,[Email],[Address1],[Address2],[City],[State],[Zip],[Active]
	FROM [Person] JOIN [PersonRole] ON [Person].[PersonID] = [PersonRole].[PersonID]
	WHERE [IsApproved] = @IsApproved
	AND [RoleID] = @RoleID
	AND [Active] = @Active
END
GO

print '' print '*** Creating sp_select_user_schedule_by_activity_id_and_type'
GO
CREATE PROCEDURE [sp_select_user_schedule_by_activity_id_and_type]
(
	@ActivityID	[int],
	@Type 		[nvarchar](50),
	@Active		[bit]
)
AS
BEGIN
	SELECT 
		[Person].[PersonID],[FirstName],[LastName],[ScheduleID],[ActivityID],[Start],[End],[Type]
	FROM [Person] JOIN [Schedule] ON [Person].[PersonID] = [Schedule].[PersonID]
	
	WHERE [Type] = @Type
	AND [ActivityID] = @ActivityID
	AND [Schedule].[Active] = @Active
END
GO

print '' print '*** Creating sp_select_all_activity_schedules_by_active'
GO
CREATE PROCEDURE [sp_select_all_activity_schedules_by_active]
(
	@Active [bit]
)
AS
BEGIN
	SELECT 
	[Activity].[ActivityID],[ActivityName],[ActivityTypeID],[Type],[LocationName],[Address1],[Address2],[City],[State],[Zip],[Description],[ScheduleID],[PersonID],[Start],[End]
	FROM [Activity] JOIN [Schedule] ON [Activity].[ActivityID] = [Schedule].[ActivityID]
	WHERE [Active] = @Active
	AND [ActivitySchedule] = 1
	AND [Start] > CURRENT_TIMESTAMP
END
GO

print '' print '*** Creating sp_select_all_user_schedules_by_user_id_and_type'
GO
CREATE PROCEDURE [sp_select_all_user_schedules_by_user_id_and_type]
(
	@PersonID	[int],
	@Active [bit],
	@Type   [nvarchar](50)
	
)
AS
BEGIN
	SELECT 
	[Activity].[ActivityID],[ActivityName],[ActivityTypeID],[Type],[LocationName],[Address1],[Address2],[City],[State],[Zip],[Description],[ScheduleID],[PersonID],[Start],[End]
	FROM [Activity] JOIN [Schedule] ON [Activity].[ActivityID] = [Schedule].[ActivityID]
	WHERE [Active] = @Active
	AND [PersonID] = @PersonID
	AND [Type] = @Type
	AND [Start] > CURRENT_TIMESTAMP
END
GO

print '' print '*** Creating sp_select_all_facilities_by_active'
GO
CREATE PROCEDURE [sp_select_all_facilities_by_active]
(
	@Active [bit]
)
AS
BEGIN
	SELECT [FacilityID],[FacilityName],[Description],[PricePerHour],[FacilityType],[Active]
	FROM [dbo].[Facility]
	WHERE [Active] = @Active
END
GO

print '' print '*** Creating sp_insert_facility'
GO
CREATE PROCEDURE [sp_insert_facility]
(
	@FacilityName	[nvarchar](100),
	@Description	[nvarchar](1000),
	@PricePerHour	[money],
	@FacilityType	[nvarchar](100)
)
AS
BEGIN
	INSERT INTO [dbo].[Facility]
	([FacilityName],[Description],[PricePerHour],[FacilityType])
	VALUES
	(@FacilityName,@Description,@PricePerHour,@FacilityType)
	RETURN @@ROWCOUNT
END
GO

print '' print '*** Creating sp_update_facility'
GO
CREATE PROCEDURE [sp_update_facility]
(
	@FacilityID			[int],
	
	@OldFacilityName	[nvarchar](100),
	@OldDescription		[nvarchar](1000),
	@OldPricePerHour	[money],
	@OldFacilityType	[nvarchar](100),
	
	@NewFacilityName	[nvarchar](100),
	@NewDescription		[nvarchar](1000),
	@NewPricePerHour	[money],
	@NewFacilityType	[nvarchar](100)
)
AS
BEGIN
	UPDATE  [dbo].[Facility]
	SET		[FacilityName] = @NewFacilityName,
			[Description]  = @NewDescription,
			[PricePerHour] = @NewPricePerHour,
			[FacilityType] = @NewFacilityType
	WHERE	[FacilityName] = @OldFacilityName
	AND		[Description]  = @OldDescription
	AND		[PricePerHour] = @OldPricePerHour
	AND		[FacilityType] = @OldFacilityType
	RETURN @@ROWCOUNT
END
GO

print '' print '*** Creating sp_select_booking_by_active'
GO
CREATE PROCEDURE [sp_select_bookings_by_active]
(
	@Active [bit]
)
AS
BEGIN
	SELECT 
		[Booking].[BookingID],[Booking].[FacilityID],[Booking].[PersonID],[ScheduledCheckOut]
		,[ScheduledCheckIn],[CheckOut],[CheckIn],[Booking].[Active],[FacilityName],[Facility].[Description]
		,[PricePerHour],[FacilityType],[FirstName],[LastName],[PhoneNumber],[Email]
	FROM [Booking] JOIN [Facility] ON [Booking].[FacilityID] = [Facility].[FacilityID]
	JOIN [Person] ON [Booking].[PersonID] = [Person].[PersonID]
	WHERE [Booking].[Active] = 1
END
GO

print '' print '*** Creating sp_update_booking'
GO
CREATE PROCEDURE [sp_update_booking]
(
	@BookingID [int],
	
	@OldFacilityID	[int],
	@OldPersonID	[int],
	@OldScheduledCheckOut	[datetime],
	@OldScheduledCheckIn	[datetime],
	@OldCheckOut			[datetime],
	@OldCheckIn				[datetime],
	@OldActive				[bit],
	
	@NewFacilityID	[int],
	@NewPersonID	[int],
	@NewScheduledCheckOut	[datetime],
	@NewScheduledCheckIn	[datetime],
	@NewCheckOut			[datetime],
	@NewCheckIn				[datetime],
	@NewActive				[bit]
)
AS
BEGIN
	UPDATE	[Booking]
	SET		[FacilityID] 		= @NewFacilityID,
			[PersonID]			= @NewPersonID,
			[ScheduledCheckOut]	= @NewScheduledCheckOut,
			[ScheduledCheckIn] 	= @NewScheduledCheckIn,
			[CheckOut]			= @NewCheckOut,
			[CheckIn]			= @NewCheckIn,
			[Active]			= @NewActive
			
	WHERE	[BookingID]			= @BookingID
	AND		[FacilityID] 		= @OldFacilityID
	AND		[PersonID]			= @OldPersonID
	AND		[ScheduledCheckOut]	= @OldScheduledCheckOut
	AND		[ScheduledCheckIn] 	= @OldScheduledCheckIn
	AND		[CheckOut]			= @OldCheckOut
	AND		[CheckIn]			= @OldCheckIn
	AND		[Active]			= @OldActive
	RETURN @@ROWCOUNT
END
GO

print '' print '*** Creating sp_update_booking_check_out'
GO
CREATE PROCEDURE [sp_update_booking_check_out]
(
	@BookingID		[int],
	
	--@OldCheckOut 	[datetime],
	
	@NewCheckOut	[datetime]
)
AS
BEGIN
	UPDATE	[Booking]
	SET		[CheckOut] = @NewCheckOut
	WHERE	[BookingID] = @BookingID
	--AND		[CheckOut] = @OldCheckout
			
	RETURN @@ROWCOUNT
END
GO

print '' print '*** Creating sp_update_booking_check_in'
GO
CREATE PROCEDURE [sp_update_booking_check_in]
(
	@BookingID		[int],
	
	--@OldCheckIn 	[datetime],
	
	@NewCheckIn		[datetime]
)
AS
BEGIN
	UPDATE	[Booking]
	SET		[CheckIn] = @NewCheckIn
	WHERE	[BookingID] = @BookingID
	--AND		[CheckIn] = @OldCheckIn
			
	RETURN @@ROWCOUNT
END
GO

print '' print '*** Creating sp_insert_booking'
GO
CREATE PROCEDURE [sp_insert_booking]
(
	@FacilityID			[int],
	@PersonID			[int],
	@ScheduledCheckIn	[datetime],
	@ScheduledCheckOut	[datetime]
)
AS
BEGIN
	INSERT INTO [dbo].[Booking]
	([FacilityID],[PersonID],[ScheduledCheckIn],[ScheduledCheckOut])
	VALUES
	(@FacilityID,@PersonID,@ScheduledCheckIn,@ScheduledCheckOut)
	RETURN @@ROWCOUNT
END
GO

print '' print '*** Creating sp_select_bookings_by_person_id'
GO
CREATE PROCEDURE [sp_select_bookings_by_person_id]
(
	@Active 	[bit],
	@PersonID	[int]
)
AS
BEGIN
	SELECT 
		[Booking].[BookingID],[Booking].[FacilityID],[Booking].[PersonID],[ScheduledCheckOut]
		,[ScheduledCheckIn],[CheckOut],[CheckIn],[Booking].[Active],[FacilityName],[Facility].[Description]
		,[PricePerHour],[FacilityType],[FirstName],[LastName],[PhoneNumber],[Email]
	FROM [Booking] JOIN [Facility] ON [Booking].[FacilityID] = [Facility].[FacilityID]
	JOIN [Person] ON [Booking].[PersonID] = [Person].[PersonID]
	WHERE [Booking].[Active] = @Active
	AND	  [Booking].[PersonID] = @PersonID
END
GO