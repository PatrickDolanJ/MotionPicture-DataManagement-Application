USE [master]
GO
/****** Object:  Database [MotionPicture]    Script Date: 7/31/2022 6:13:45 PM ******/
IF NOT EXISTS(select * from sys.databases where name = 'MotionPicture')
CREATE DATABASE [MotionPicture]
 CONTAINMENT = NONE
 ON  PRIMARY 
( NAME = N'MotionPicture', FILENAME = N'C:\Program Files\Microsoft SQL Server\MSSQL15.SQLEXPRESS\MSSQL\DATA\MotionPicture.mdf' , SIZE = 8192KB , MAXSIZE = UNLIMITED, FILEGROWTH = 65536KB )
 LOG ON 
( NAME = N'MotionPicture_log', FILENAME = N'C:\Program Files\Microsoft SQL Server\MSSQL15.SQLEXPRESS\MSSQL\DATA\MotionPicture_log.ldf' , SIZE = 8192KB , MAXSIZE = 2048GB , FILEGROWTH = 65536KB )
 WITH CATALOG_COLLATION = DATABASE_DEFAULT

GO
ALTER DATABASE [MotionPicture] SET COMPATIBILITY_LEVEL = 150
GO
IF (1 = FULLTEXTSERVICEPROPERTY('IsFullTextInstalled'))
begin
EXEC [MotionPicture].[dbo].[sp_fulltext_database] @action = 'enable'
end
GO
ALTER DATABASE [MotionPicture] SET ANSI_NULL_DEFAULT OFF 
GO
ALTER DATABASE [MotionPicture] SET ANSI_NULLS OFF 
GO
ALTER DATABASE [MotionPicture] SET ANSI_PADDING OFF 
GO
ALTER DATABASE [MotionPicture] SET ANSI_WARNINGS OFF 
GO
ALTER DATABASE [MotionPicture] SET ARITHABORT OFF 
GO
ALTER DATABASE [MotionPicture] SET AUTO_CLOSE OFF 
GO
ALTER DATABASE [MotionPicture] SET AUTO_SHRINK OFF 
GO
ALTER DATABASE [MotionPicture] SET AUTO_UPDATE_STATISTICS ON 
GO
ALTER DATABASE [MotionPicture] SET CURSOR_CLOSE_ON_COMMIT OFF 
GO
ALTER DATABASE [MotionPicture] SET CURSOR_DEFAULT  GLOBAL 
GO
ALTER DATABASE [MotionPicture] SET CONCAT_NULL_YIELDS_NULL OFF 
GO
ALTER DATABASE [MotionPicture] SET NUMERIC_ROUNDABORT OFF 
GO
ALTER DATABASE [MotionPicture] SET QUOTED_IDENTIFIER OFF 
GO
ALTER DATABASE [MotionPicture] SET RECURSIVE_TRIGGERS OFF 
GO
ALTER DATABASE [MotionPicture] SET  DISABLE_BROKER 
GO
ALTER DATABASE [MotionPicture] SET AUTO_UPDATE_STATISTICS_ASYNC OFF 
GO
ALTER DATABASE [MotionPicture] SET DATE_CORRELATION_OPTIMIZATION OFF 
GO
ALTER DATABASE [MotionPicture] SET TRUSTWORTHY OFF 
GO
ALTER DATABASE [MotionPicture] SET ALLOW_SNAPSHOT_ISOLATION OFF 
GO
ALTER DATABASE [MotionPicture] SET PARAMETERIZATION SIMPLE 
GO
ALTER DATABASE [MotionPicture] SET READ_COMMITTED_SNAPSHOT OFF 
GO
ALTER DATABASE [MotionPicture] SET HONOR_BROKER_PRIORITY OFF 
GO
ALTER DATABASE [MotionPicture] SET RECOVERY SIMPLE 
GO
ALTER DATABASE [MotionPicture] SET  MULTI_USER 
GO
ALTER DATABASE [MotionPicture] SET PAGE_VERIFY CHECKSUM  
GO
ALTER DATABASE [MotionPicture] SET DB_CHAINING OFF 
GO
ALTER DATABASE [MotionPicture] SET FILESTREAM( NON_TRANSACTED_ACCESS = OFF ) 
GO
ALTER DATABASE [MotionPicture] SET TARGET_RECOVERY_TIME = 60 SECONDS 
GO
ALTER DATABASE [MotionPicture] SET DELAYED_DURABILITY = DISABLED 
GO
ALTER DATABASE [MotionPicture] SET ACCELERATED_DATABASE_RECOVERY = OFF  
GO
ALTER DATABASE [MotionPicture] SET QUERY_STORE = OFF
GO
USE [MotionPicture]
GO
/****** Object:  Table [dbo].[movie]    Script Date: 7/31/2022 6:13:45 PM ******/
SET ANSI_NULLS ON

GO
SET QUOTED_IDENTIFIER ON
GO
IF NOT EXISTS(select * from sysobjects where name = 'movie' and xtype = 'U')
BEGIN
CREATE TABLE [dbo].[movie](
	[title] [nvarchar](50) NOT NULL,
	[description] [nvarchar](500) NULL,
	[release_year] [int] NULL,
	[id] [int] IDENTITY(1,1) NOT NULL,
PRIMARY KEY CLUSTERED 
(
	[id] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON, OPTIMIZE_FOR_SEQUENTIAL_KEY = OFF) ON [PRIMARY]
) ON [PRIMARY]
END
GO

SET IDENTITY_INSERT [dbo].[movie] ON 

INSERT [dbo].[movie] ([title], [description], [release_year], [id]) VALUES (N'The Shining', N'     A family heads to an isolated hotel for the winter where a sinister presence influences the father into violence, while his psychic son sees horrific forebodings from both past and future.', 1980, 1)
INSERT [dbo].[movie] ([title], [description], [release_year], [id]) VALUES (N'The Dark Knight', N'     When the menace known as The Joker emerges from his mysterious past, he wreaks havoc and chaos on the people of Gotham. The Dark Knight must accept one of the greatest psychological and physical tests of his ability to fight injustice.', 2000, 2)
INSERT [dbo].[movie] ([title], [description], [release_year], [id]) VALUES (N'The Shawshank Redemption', N'     Two imprisoned men bond over a number of years, finding solace and eventual redemption through acts of common decency.', 1994, 3)
INSERT [dbo].[movie] ([title], [description], [release_year], [id]) VALUES (N'Spider-Man: Into The Spider-Verse', N'     Teen Miles Morales becomes Spider-Man of his reality, crossing his path with five counterparts from other dimensions to stop a threat for all realities.', 2019, 4)
INSERT [dbo].[movie] ([title], [description], [release_year], [id]) VALUES (N'Inglourious Basterds', N'     In Nazi-occupied France during World War II, a plan to assassinate Nazi leaders by a group of Jewish U.S. soldiers coincides with a theatre owner''s vengeful plans for the same.', 2009, 5)
INSERT [dbo].[movie] ([title], [description], [release_year], [id]) VALUES (N'Pulp Fiction', N'     The lives of two mob hitmen, a boxer, a gangster and his wife, and a pair of diner bandits intertwine in four tales of violence and redemption.', 1994, 6)
INSERT [dbo].[movie] ([title], [description], [release_year], [id]) VALUES (N'Interstellar', N'     A team of explorers travel through a wormhole in space in an attempt to ensure humanity''s survival.', 2005, 7)
INSERT [dbo].[movie] ([title], [description], [release_year], [id]) VALUES (N'The Matrix', N'     A computer hacker learns from mysterious rebels about the true nature of his reality and his role in the war against its controllers.', 1999, 8)
INSERT [dbo].[movie] ([title], [description], [release_year], [id]) VALUES (N'The Godfather', N'     The aging patriarch of an organized crime dynasty transfers control of his clandestine empire to his reluctant son.', 1972, 9)
INSERT [dbo].[movie] ([title], [description], [release_year], [id]) VALUES (N'The Wolf of Wall Street', N'     Based on the true story of Jordan Belfort, from his rise to a wealthy stock-broker living the high life to his fall involving crime, corruption and the federal government.', 1929, 10)
INSERT [dbo].[movie] ([title], [description], [release_year], [id]) VALUES (N'The Lord of the Rings: The Fellowship of the Ring', N'     A meek Hobbit from the Shire and eight companions set out on a journey to destroy the powerful One Ring and save Middle-earth from the Dark Lord Sauron.', 2001, 11)
INSERT [dbo].[movie] ([title], [description], [release_year], [id]) VALUES (N'Taxi Driver', N'     A mentally unstable veteran works as a nighttime taxi driver in New York City, where the perceived decadence and sleaze fuels his urge for violent action by attempting to liberate a presidential campaign worker and an underage prostitute.', 1954, 12)
INSERT [dbo].[movie] ([title], [description], [release_year], [id]) VALUES (N'Fight Club', N'     An insomniac office worker and a devil-may-care soapmaker form an underground fight club that evolves into something much, much more.', 1999, 13)
INSERT [dbo].[movie] ([title], [description], [release_year], [id]) VALUES (N'The Green Mile', N'     The lives of guards on Death Row are affected by one of their charges: a black man accused of child murder and rape, yet who has a mysterious gift.', 1999, 14)
INSERT [dbo].[movie] ([title], [description], [release_year], [id]) VALUES (N'12 Angry Men', N'     A jury holdout attempts to prevent a miscarriage of justice by forcing his colleagues to reconsider the evidence.', 1957, 15)
INSERT [dbo].[movie] ([title], [description], [release_year], [id]) VALUES (N'Gladiator', N'     A former Roman General sets out to exact vengeance against the corrupt emperor who murdered his family and sent him into slavery.', 1992, 16)
INSERT [dbo].[movie] ([title], [description], [release_year], [id]) VALUES (N'The Lord of the Rings: The Return of the King', N'     Gandalf and Aragorn lead the World of Men against Sauron''s army to draw his gaze from Frodo and Sam as they approach Mount Doom with the One Ring.', 2003, 17)
INSERT [dbo].[movie] ([title], [description], [release_year], [id]) VALUES (N'Forrest Gump', N'     The presidencies of Kennedy and Johnson, the events of Vietnam, Watergate, and other history unfold through the perspective of an Alabama man with an IQ of 75.', 1994, 18)
INSERT [dbo].[movie] ([title], [description], [release_year], [id]) VALUES (N'Jurassic Park', N'     A pragmatic Paleontologist visiting an almost complete theme park is tasked with protecting a couple of kids after a power failure causes the park''s cloned dinosaurs to run loose.', 1993, 19)
INSERT [dbo].[movie] ([title], [description], [release_year], [id]) VALUES (N'Reservoir Dogs', N'     When a simple jewelry heist goes horribly wrong, the surviving criminals begin to suspect that one of them is a police informant.', 1992, 20)
INSERT [dbo].[movie] ([title], [description], [release_year], [id]) VALUES (N'Apocalypse Now', N'     A U.S. Army officer serving in Vietnam is tasked with assassinating a renegade Special Forces Colonel who sees himself as a god.', 1979, 21)
INSERT [dbo].[movie] ([title], [description], [release_year], [id]) VALUES (N'The Lion King', N'     A Lion cub crown prince is tricked by a treacherous uncle into thinking he caused his father''s death and flees into exile in despair, only to learn in adulthood his identity and his responsibilities.', 1994, 22)
INSERT [dbo].[movie] ([title], [description], [release_year], [id]) VALUES (N'American Beauty', N'     A sexually frustrated suburban father has a mid-life crisis after becoming infatuated with his daughter''s best friend.', 1993, 23)
INSERT [dbo].[movie] ([title], [description], [release_year], [id]) VALUES (N'Kill Bill: Vol. 1', N'     After awakening from a four-year coma, a former assassin wreaks vengeance on the team of assassins who betrayed her.', 2003, 24)
INSERT [dbo].[movie] ([title], [description], [release_year], [id]) VALUES (N'Goodfellas', N'     The story of Henry Hill and his life in the mob, covering his relationship with his wife Karen Hill and his mob partners Jimmy Conway and Tommy DeVito in the Italian-American crime syndicate.', 1990, 25)
INSERT [dbo].[movie] ([title], [description], [release_year], [id]) VALUES (N'Blade Runner', N'     A blade runner must pursue and terminate four replicants who stole a ship in space, and have returned to Earth to find their creator.', 1982, 26)
INSERT [dbo].[movie] ([title], [description], [release_year], [id]) VALUES (N'The Silence of the Lambs', N'     A young F.B.I. cadet must receive the help of an incarcerated and manipulative cannibal killer to help catch another serial killer, a madman who skins his victims.', 1991, 27)
INSERT [dbo].[movie] ([title], [description], [release_year], [id]) VALUES (N'Back to the Future', N'     Marty McFly, a 17-year-old high school student, is accidentally sent thirty years into the past in a time-traveling DeLorean invented by his close friend, the maverick scientist Doc Brown.', 1985, 28)
INSERT [dbo].[movie] ([title], [description], [release_year], [id]) VALUES (N'Requiem for a Dream', N'     The drug-induced utopias of four Coney Island people are shattered when their addictions run deep.', 2000, 29)
INSERT [dbo].[movie] ([title], [description], [release_year], [id]) VALUES (N'Alien', N'     After a space merchant vessel perceives an unknown transmission as a distress call, its landing on the source moon finds one of the crew attacked by a mysterious lifeform, and they soon realize that its life cycle has merely begun.', 1979, 30)
INSERT [dbo].[movie] ([title], [description], [release_year], [id]) VALUES (N'The Lord of the Rings: The Two Towers', N'     While Frodo and Sam edge closer to Mordor with the help of the shifty Gollum, the divided fellowship makes a stand against Sauron''s new ally, Saruman, and his hordes of Isengard.', 2002, 31)
INSERT [dbo].[movie] ([title], [description], [release_year], [id]) VALUES (N'The Departed', N'     An undercover cop and a mole in the police attempt to identify each other while infiltrating an Irish gang in South Boston.', 1973, 32)
INSERT [dbo].[movie] ([title], [description], [release_year], [id]) VALUES (N'Schindler''s List', N'     In German-occupied Poland during World War II, industrialist Oskar Schindler gradually becomes concerned for his Jewish workforce after witnessing their persecution by the Nazis.', 1993, 33)
INSERT [dbo].[movie] ([title], [description], [release_year], [id]) VALUES (N'Stand by Me', N'     After the death of one of his friends, a writer recounts a boyhood journey with his friends to find the body of a missing boy.', 1986, 34)
INSERT [dbo].[movie] ([title], [description], [release_year], [id]) VALUES (N'Saving Private Ryan', N'     Following the Normandy Landings, a group of U.S. soldiers go behind enemy lines to retrieve a paratrooper whose brothers have been killed in action.', 1998, 35)
SET IDENTITY_INSERT [dbo].[movie] OFF

GO
USE [master]
GO
ALTER DATABASE [MotionPicture] SET  READ_WRITE 
GO