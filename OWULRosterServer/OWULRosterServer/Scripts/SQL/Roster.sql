USE [master]
GO

CREATE DATABASE [Roster]
 CONTAINMENT = NONE
 ON  PRIMARY 
( NAME = N'Roster', FILENAME = N'C:\Program Files\Microsoft SQL Server\MSSQL13.SQLEXPRESS\MSSQL\DATA\Roster.mdf' , SIZE = 8192KB , MAXSIZE = UNLIMITED, FILEGROWTH = 65536KB )
 LOG ON 
( NAME = N'Roster_log', FILENAME = N'C:\Program Files\Microsoft SQL Server\MSSQL13.SQLEXPRESS\MSSQL\DATA\Roster_log.ldf' , SIZE = 8192KB , MAXSIZE = 2048GB , FILEGROWTH = 65536KB )
GO

ALTER DATABASE [Roster] SET COMPATIBILITY_LEVEL = 130
GO

USE [Roster]
GO

CREATE TABLE dbo.Team (
    TeamId int IDENTITY(1,1),
    Name varchar(100) NOT NULL,
    Avatar varchar(500),
	Wins int NOT NULL,
	Losses int NOT NULL,
	Ties int NOT NULL,
	Score int NOT NULL,
	CONSTRAINT [PK_TeamId] PRIMARY KEY CLUSTERED (TeamId ASC)
);

CREATE TABLE dbo.Player (
    PlayerId int IDENTITY(1,1),
	CONSTRAINT [PK_PlayerId] PRIMARY KEY CLUSTERED (PlayerId ASC),
    TeamId int
	CONSTRAINT [FK_Team_TeamId] REFERENCES dbo.Team(TeamId) ON DELETE SET DEFAULT,
    Name varchar(100) NOT NULL,
    BNetTag varchar(100) NOT NULL,
    Avatar varchar(500),
    SkillRating int NOT NULL,
    AverageKills decimal(5,2) NOT NULL,
	AverageDeaths decimal(5,2) NOT NULL,
	AverageAssists decimal(5,2) NOT NULL
);
GO

SET IDENTITY_INSERT Team ON
INSERT INTO Team (TeamId, Name, Avatar, Wins, Losses, Ties, Score)
VALUES (1, 'Shark Logic', 'SL.png', 8, 1, 0, 14),
	   (2, 'Average Yeti Newts', '100px-PI_Alien.png', 6, 3, 0, 5),
	   (3, 'Piranha', '100px-PI_Widowmaker_Face.png', 4, 5, 0, -4),
	   (4, 'Mae''s Bae''s', '100px-PI_Mei_Face.png', 9, 0, 0, 17),
	   (5, 'Squid Squad', '100px-PI_Torbjorn_Face.png', 1, 7, 0, -12),
	   (6, 'Soldiers', '100px-PI_S76_Face.png', 1, 8, 0, -12),
	   (7, 'NuBees', '100px-PI_Anubis.png', 3, 5, 0, -3),
	   (8, 'Overly Supportive', '100px-PI_Lucio_Face.png', 4, 5, 0, -1),
	   (9, 'No Dougs Allowed', '100px-PI_Winston_Face.png', 1, 8, 0, -14),
	   (10, 'Attack Mercy', '100px-PI_Mercy_Face.png', 7, 2, 0, 10);

SET IDENTITY_INSERT Team OFF
GO

INSERT INTO Player
VALUES (1, 'MasterShadow', 'MasterShadow#1520', '100px-PI_Reaper_Face.png', 1932, CAST(RAND() * 10 AS DECIMAL(5,2)), CAST(RAND() * 10 AS DECIMAL(5,2)), CAST(RAND() * 10 AS DECIMAL(5,2))),
	   (1, 'blazecc', 'blazecc#1494', '100px-PI_Zarya_Face.png', 2162, CAST(RAND() * 10 AS DECIMAL(5,2)), CAST(RAND() * 10 AS DECIMAL(5,2)), CAST(RAND() * 10 AS DECIMAL(5,2))),
	   (1, 'Kizanagi', 'Kizanagi#11724', '100px-PI_Pharah_Face.png', 1172, CAST(RAND() * 10 AS DECIMAL(5,2)), CAST(RAND() * 10 AS DECIMAL(5,2)), CAST(RAND() * 10 AS DECIMAL(5,2))),
	   (1, 'G3yost', 'G3yost#1788', '100px-PI_Zenyatta_Face.png', 2123, CAST(RAND() * 10 AS DECIMAL(5,2)), CAST(RAND() * 10 AS DECIMAL(5,2)), CAST(RAND() * 10 AS DECIMAL(5,2))),
	   (1, 'Rausfer', 'Rausfer#1779', '100px-PI_Reinhardt_Face.png', 2281, CAST(RAND() * 10 AS DECIMAL(5,2)), CAST(RAND() * 10 AS DECIMAL(5,2)), CAST(RAND() * 10 AS DECIMAL(5,2))),
	   (1, 'Contagion', 'Contagion#11604', '100px-PI_Lucio_Face.png', 1650, CAST(RAND() * 10 AS DECIMAL(5,2)), CAST(RAND() * 10 AS DECIMAL(5,2)), CAST(RAND() * 10 AS DECIMAL(5,2))),

	   (2, 'Ƕoutrun', 'Ƕoutrun#1524', '100px-PI_Hanzo_Face.png', ROUND(((3000 - 500 -1) * RAND() + 500), 0), CAST(RAND() * 10 AS DECIMAL(5,2)), CAST(RAND() * 10 AS DECIMAL(5,2)), CAST(RAND() * 10 AS DECIMAL(5,2))),
	   (2, 'choppa', 'choppa#1563', '100px-PI_Bao.png', ROUND(((3000 - 500 -1) * RAND() + 500), 0), CAST(RAND() * 10 AS DECIMAL(5,2)), CAST(RAND() * 10 AS DECIMAL(5,2)), CAST(RAND() * 10 AS DECIMAL(5,2))),
	   (2, 'TheCroctopus', 'TheCroctopus#1318', '100px-PI_McCree_Face.png', ROUND(((3000 - 500 -1) * RAND() + 500), 0), CAST(RAND() * 10 AS DECIMAL(5,2)), CAST(RAND() * 10 AS DECIMAL(5,2)), CAST(RAND() * 10 AS DECIMAL(5,2))),
	   (2, 'NelsonZC', 'NelsonZC#1613', '', ROUND(((3000 - 500 -1) * RAND() + 500), 0), CAST(RAND() * 10 AS DECIMAL(5,2)), CAST(RAND() * 10 AS DECIMAL(5,2)), CAST(RAND() * 10 AS DECIMAL(5,2))),
	   (2, 'Bufforz', 'Bufforz#1257', '100px-PI_Roadhog_Face.png', ROUND(((3000 - 500 -1) * RAND() + 500), 0), CAST(RAND() * 10 AS DECIMAL(5,2)), CAST(RAND() * 10 AS DECIMAL(5,2)), CAST(RAND() * 10 AS DECIMAL(5,2))),
	   (2, 'TreePerson', 'TreePerson#1342', '', ROUND(((3000 - 500 -1) * RAND() + 500), 0), CAST(RAND() * 10 AS DECIMAL(5,2)), CAST(RAND() * 10 AS DECIMAL(5,2)), CAST(RAND() * 10 AS DECIMAL(5,2))),

	   (3, 'Purplevander1335', 'Purplevander1335', '100px-PI_Hanzo_Face.png', ROUND(((3000 - 500 -1) * RAND() + 500), 0), CAST(RAND() * 10 AS DECIMAL(5,2)), CAST(RAND() * 10 AS DECIMAL(5,2)), CAST(RAND() * 10 AS DECIMAL(5,2))),
	   (3, 'luckyllama', 'luckyllama#1999', '100px-PI_Ana_Face.png', ROUND(((3000 - 500 -1) * RAND() + 500), 0), CAST(RAND() * 10 AS DECIMAL(5,2)), CAST(RAND() * 10 AS DECIMAL(5,2)), CAST(RAND() * 10 AS DECIMAL(5,2))),
	   (3, 'Hoax', 'Hoax#11920', '', ROUND(((3000 - 500 -1) * RAND() + 500), 0), CAST(RAND() * 10 AS DECIMAL(5,2)), CAST(RAND() * 10 AS DECIMAL(5,2)), CAST(RAND() * 10 AS DECIMAL(5,2))),
	   (3, 'Raehne', 'Raehne#1292', '100px-PI_Junkrat_Face.png', ROUND(((3000 - 500 -1) * RAND() + 500), 0), CAST(RAND() * 10 AS DECIMAL(5,2)), CAST(RAND() * 10 AS DECIMAL(5,2)), CAST(RAND() * 10 AS DECIMAL(5,2))),
	   (3, 'Epsilon', 'Epsilon#22516', '100px-PI_Roadhog_Face.png', ROUND(((3000 - 500 -1) * RAND() + 500), 0), CAST(RAND() * 10 AS DECIMAL(5,2)), CAST(RAND() * 10 AS DECIMAL(5,2)), CAST(RAND() * 10 AS DECIMAL(5,2))),
	   (3, 'Showstopper4', 'Showstopper4#11130', '100px-PI_Reaper_Emblem.png', ROUND(((3000 - 500 -1) * RAND() + 500), 0), CAST(RAND() * 10 AS DECIMAL(5,2)), CAST(RAND() * 10 AS DECIMAL(5,2)), CAST(RAND() * 10 AS DECIMAL(5,2))),

	   (4, 'emi', 'emi#1523', '100px-PI_Hanzo_Face.png',ROUND(((3000 - 500 -1) * RAND() + 500), 0), CAST(RAND() * 10 AS DECIMAL(5,2)), CAST(RAND() * 10 AS DECIMAL(5,2)), CAST(RAND() * 10 AS DECIMAL(5,2))),
	   (4, 'Jonathan', 'Jonathan#11308', '100px-PI_Reaper_Emblem.png', ROUND(((3000 - 500 -1) * RAND() + 500), 0), CAST(RAND() * 10 AS DECIMAL(5,2)), CAST(RAND() * 10 AS DECIMAL(5,2)), CAST(RAND() * 10 AS DECIMAL(5,2))),
	   (4, 'Seanthebomb', 'Seanthebomb#11117', '100px-PI_D.Va_Face.png', ROUND(((3000 - 500 -1) * RAND() + 500), 0), CAST(RAND() * 10 AS DECIMAL(5,2)), CAST(RAND() * 10 AS DECIMAL(5,2)), CAST(RAND() * 10 AS DECIMAL(5,2))),
	   (4, 'ProDukenukem', 'ProDukenukem#1679', '100px-PI_Anubis.png', ROUND(((3000 - 500 -1) * RAND() + 500), 0), CAST(RAND() * 10 AS DECIMAL(5,2)), CAST(RAND() * 10 AS DECIMAL(5,2)), CAST(RAND() * 10 AS DECIMAL(5,2))),
	   (4, 'Lemons', 'Lemons#11791', '100px-PI_McCree_Face.png', ROUND(((3000 - 500 -1) * RAND() + 500), 0), CAST(RAND() * 10 AS DECIMAL(5,2)), CAST(RAND() * 10 AS DECIMAL(5,2)), CAST(RAND() * 10 AS DECIMAL(5,2))),
	   (4, 'sowilson', 'sowilson#1174', '100px-PI_Junkrat_Face.png', ROUND(((3000 - 500 -1) * RAND() + 500), 0), CAST(RAND() * 10 AS DECIMAL(5,2)), CAST(RAND() * 10 AS DECIMAL(5,2)), CAST(RAND() * 10 AS DECIMAL(5,2))),

	   (5, 'CJSchneider320', 'CJSchneider320#1549', '100px-PI_S76_Face.png', ROUND(((3000 - 500 -1) * RAND() + 500), 0), CAST(RAND() * 10 AS DECIMAL(5,2)), CAST(RAND() * 10 AS DECIMAL(5,2)), CAST(RAND() * 10 AS DECIMAL(5,2))),
	   (5, 'ArmanDOUGH', 'ArmanDOUGH#11903', '100px-PI_S76_Face.png', ROUND(((3000 - 500 -1) * RAND() + 500), 0), CAST(RAND() * 10 AS DECIMAL(5,2)), CAST(RAND() * 10 AS DECIMAL(5,2)), CAST(RAND() * 10 AS DECIMAL(5,2))),
	   (5, 'Argyria', 'Argyria#11197', '100px-PI_S76_Face.png', ROUND(((3000 - 500 -1) * RAND() + 500), 0), CAST(RAND() * 10 AS DECIMAL(5,2)), CAST(RAND() * 10 AS DECIMAL(5,2)), CAST(RAND() * 10 AS DECIMAL(5,2))),
	   (5, 'DirtyTalk', 'DirtyTalk#1531', '100px-PI_S76_Face.png', ROUND(((3000 - 500 -1) * RAND() + 500), 0), CAST(RAND() * 10 AS DECIMAL(5,2)), CAST(RAND() * 10 AS DECIMAL(5,2)), CAST(RAND() * 10 AS DECIMAL(5,2))),
	   (5, 'Ryzle', 'Ryzle#1457', '100px-PI_S76_Face.png', ROUND(((3000 - 500 -1) * RAND() + 500), 0), CAST(RAND() * 10 AS DECIMAL(5,2)), CAST(RAND() * 10 AS DECIMAL(5,2)), CAST(RAND() * 10 AS DECIMAL(5,2))),
	   (5, 'umsmasta', 'umsmasta#1575', '100px-PI_S76_Face.png', ROUND(((3000 - 500 -1) * RAND() + 500), 0), CAST(RAND() * 10 AS DECIMAL(5,2)), CAST(RAND() * 10 AS DECIMAL(5,2)), CAST(RAND() * 10 AS DECIMAL(5,2))),

	   (6, 'KillCather', 'KillCather#1439', '100px-PI_Hanzo_Face.png', ROUND(((3000 - 500 -1) * RAND() + 500), 0), CAST(RAND() * 10 AS DECIMAL(5,2)), CAST(RAND() * 10 AS DECIMAL(5,2)), CAST(RAND() * 10 AS DECIMAL(5,2))),
	   (6, 'Zach', 'Zach#1544', '100px-PI_Colossus.png', ROUND(((3000 - 500 -1) * RAND() + 500), 0), CAST(RAND() * 10 AS DECIMAL(5,2)), CAST(RAND() * 10 AS DECIMAL(5,2)), CAST(RAND() * 10 AS DECIMAL(5,2))),
	   (6, 'gab', 'gab#1545', '', ROUND(((3000 - 500 -1) * RAND() + 500), 0), CAST(RAND() * 10 AS DECIMAL(5,2)), CAST(RAND() * 10 AS DECIMAL(5,2)), CAST(RAND() * 10 AS DECIMAL(5,2))),
	   (6, 'dynamicaljon', 'dynamicaljon#1275', '100px-PI_Symmetra_Face.png', ROUND(((3000 - 500 -1) * RAND() + 500), 0), CAST(RAND() * 10 AS DECIMAL(5,2)), CAST(RAND() * 10 AS DECIMAL(5,2)), CAST(RAND() * 10 AS DECIMAL(5,2))),
	   (6, 'RandomTag', 'RandomTag#1914', '100px-PI_Capsule.png', ROUND(((3000 - 500 -1) * RAND() + 500), 0), CAST(RAND() * 10 AS DECIMAL(5,2)), CAST(RAND() * 10 AS DECIMAL(5,2)), CAST(RAND() * 10 AS DECIMAL(5,2))),
	   (6, 'WorstWidowNA', 'WorstWidowNA#1276', '', ROUND(((3000 - 500 -1) * RAND() + 500), 0), CAST(RAND() * 10 AS DECIMAL(5,2)), CAST(RAND() * 10 AS DECIMAL(5,2)), CAST(RAND() * 10 AS DECIMAL(5,2))),

	   (7, 'xaponix', 'xaponix#1564', '100px-PI_Hanzo_Face.png', ROUND(((3000 - 500 -1) * RAND() + 500), 0), CAST(RAND() * 10 AS DECIMAL(5,2)), CAST(RAND() * 10 AS DECIMAL(5,2)), CAST(RAND() * 10 AS DECIMAL(5,2))),
	   (7, 'HypergonZX', 'HypergonZX#1161', '', ROUND(((3000 - 500 -1) * RAND() + 500), 0), CAST(RAND() * 10 AS DECIMAL(5,2)), CAST(RAND() * 10 AS DECIMAL(5,2)), CAST(RAND() * 10 AS DECIMAL(5,2))),
	   (7, 'Klopford', 'Klopford#1851', '100px-PI_Bao.png', ROUND(((3000 - 500 -1) * RAND() + 500), 0), CAST(RAND() * 10 AS DECIMAL(5,2)), CAST(RAND() * 10 AS DECIMAL(5,2)), CAST(RAND() * 10 AS DECIMAL(5,2))),
	   (7, 'Zageto', 'Zageto#1411', '100px-PI_Genji_Face.png', ROUND(((3000 - 500 -1) * RAND() + 500), 0), CAST(RAND() * 10 AS DECIMAL(5,2)), CAST(RAND() * 10 AS DECIMAL(5,2)), CAST(RAND() * 10 AS DECIMAL(5,2))),
	   (7, 'Diglett', 'Diglett#4333', '100px-PI_Cheers.png', ROUND(((3000 - 500 -1) * RAND() + 500), 0), CAST(RAND() * 10 AS DECIMAL(5,2)), CAST(RAND() * 10 AS DECIMAL(5,2)), CAST(RAND() * 10 AS DECIMAL(5,2))),
	   (7, 'RadialBlur', 'RadialBlur#11136', '', ROUND(((3000 - 500 -1) * RAND() + 500), 0), CAST(RAND() * 10 AS DECIMAL(5,2)), CAST(RAND() * 10 AS DECIMAL(5,2)), CAST(RAND() * 10 AS DECIMAL(5,2))),

	   (8, 'GenConfusion', 'GenConfusion#11663', '100px-PI_Ana_Face.png', ROUND(((3000 - 500 -1) * RAND() + 500), 0), CAST(RAND() * 10 AS DECIMAL(5,2)), CAST(RAND() * 10 AS DECIMAL(5,2)), CAST(RAND() * 10 AS DECIMAL(5,2))),
	   (8, 'skyshayde', 'skyshayde#1953', '100px-PI_Symmetra_Face.png', ROUND(((3000 - 500 -1) * RAND() + 500), 0), CAST(RAND() * 10 AS DECIMAL(5,2)), CAST(RAND() * 10 AS DECIMAL(5,2)), CAST(RAND() * 10 AS DECIMAL(5,2))),
	   (8, 'BlitzAsogi', 'BlitzAsogi#1571', '100px-PI_Mercy_Face.png', ROUND(((3000 - 500 -1) * RAND() + 500), 0), CAST(RAND() * 10 AS DECIMAL(5,2)), CAST(RAND() * 10 AS DECIMAL(5,2)), CAST(RAND() * 10 AS DECIMAL(5,2))),
	   (8, 'DankMemes', 'DankMemes#11949', '100px-PI_Ana_Face.png', ROUND(((3000 - 500 -1) * RAND() + 500), 0), CAST(RAND() * 10 AS DECIMAL(5,2)), CAST(RAND() * 10 AS DECIMAL(5,2)), CAST(RAND() * 10 AS DECIMAL(5,2))),
	   (8, 'santacheese', 'santacheese#1789', '100px-PI_Zenyatta_Face.png', ROUND(((3000 - 500 -1) * RAND() + 500), 0), CAST(RAND() * 10 AS DECIMAL(5,2)), CAST(RAND() * 10 AS DECIMAL(5,2)), CAST(RAND() * 10 AS DECIMAL(5,2))),
	   (8, 'Arenia', 'Arenia#11476', '100px-PI_Mercy_Face.png', ROUND(((3000 - 500 -1) * RAND() + 500), 0), CAST(RAND() * 10 AS DECIMAL(5,2)), CAST(RAND() * 10 AS DECIMAL(5,2)), CAST(RAND() * 10 AS DECIMAL(5,2))),

	   (9, 'Binkley', 'Binkley #1577', '100px-PI_Genji_Face.png', ROUND(((3000 - 500 -1) * RAND() + 500), 0), CAST(RAND() * 10 AS DECIMAL(5,2)), CAST(RAND() * 10 AS DECIMAL(5,2)), CAST(RAND() * 10 AS DECIMAL(5,2))),
	   (9, 'HungryGamer', 'HungryGamer#1541', '100px-PI_D.Va_Face.png', ROUND(((3000 - 500 -1) * RAND() + 500), 0), CAST(RAND() * 10 AS DECIMAL(5,2)), CAST(RAND() * 10 AS DECIMAL(5,2)), CAST(RAND() * 10 AS DECIMAL(5,2))),
	   (9, 'mulaners', 'mulaners#1145', '100px-PI_Colossus.png', ROUND(((3000 - 500 -1) * RAND() + 500), 0), CAST(RAND() * 10 AS DECIMAL(5,2)), CAST(RAND() * 10 AS DECIMAL(5,2)), CAST(RAND() * 10 AS DECIMAL(5,2))),
	   (9, 'YOLOgan', 'YOLOgan#1344', '100px-PI_Cheers.png', ROUND(((3000 - 500 -1) * RAND() + 500), 0), CAST(RAND() * 10 AS DECIMAL(5,2)), CAST(RAND() * 10 AS DECIMAL(5,2)), CAST(RAND() * 10 AS DECIMAL(5,2))),
	   (9, 'DedlyKittn23', 'DedlyKittn23#1744', '100px-PI_Capsule.png', ROUND(((3000 - 500 -1) * RAND() + 500), 0), CAST(RAND() * 10 AS DECIMAL(5,2)), CAST(RAND() * 10 AS DECIMAL(5,2)), CAST(RAND() * 10 AS DECIMAL(5,2))),
	   (9, 'Vinceclortho', 'Vinceclortho#1241', '100px-PI_Bao.png', ROUND(((3000 - 500 -1) * RAND() + 500), 0), CAST(RAND() * 10 AS DECIMAL(5,2)), CAST(RAND() * 10 AS DECIMAL(5,2)), CAST(RAND() * 10 AS DECIMAL(5,2))),

	   (10, 'Mickey', 'Mickey#1799', '', ROUND(((3000 - 500 -1) * RAND() + 500), 0), CAST(RAND() * 10 AS DECIMAL(5,2)), CAST(RAND() * 10 AS DECIMAL(5,2)), CAST(RAND() * 10 AS DECIMAL(5,2))),
	   (10, 'webbmd', 'webbmd#1998', '100px-PI_Anubis.png', ROUND(((3000 - 500 -1) * RAND() + 500), 0), CAST(RAND() * 10 AS DECIMAL(5,2)), CAST(RAND() * 10 AS DECIMAL(5,2)), CAST(RAND() * 10 AS DECIMAL(5,2))),
	   (10, 'Celesmeh', 'Celesmeh#1889', '100px-PI_Ana_Face.png', ROUND(((3000 - 500 -1) * RAND() + 500), 0), CAST(RAND() * 10 AS DECIMAL(5,2)), CAST(RAND() * 10 AS DECIMAL(5,2)), CAST(RAND() * 10 AS DECIMAL(5,2))),
	   (10, 'nitr7', 'nitr7#1784', '100px-PI_Symmetra_Face.png', ROUND(((3000 - 500 -1) * RAND() + 500), 0), CAST(RAND() * 10 AS DECIMAL(5,2)), CAST(RAND() * 10 AS DECIMAL(5,2)), CAST(RAND() * 10 AS DECIMAL(5,2))),
	   (10, 'oscaroa', 'oscaroa#1923', '100px-PI_Bao.png', ROUND(((3000 - 500 -1) * RAND() + 500), 0), CAST(RAND() * 10 AS DECIMAL(5,2)), CAST(RAND() * 10 AS DECIMAL(5,2)), CAST(RAND() * 10 AS DECIMAL(5,2)));
	   -- Had someone drop and removed them from the roster so I only have 5 names for this team