USE master
GO

-- Drop database if it exists
IF DB_ID('final_capstone') IS NOT NULL
BEGIN
	ALTER DATABASE final_capstone SET SINGLE_USER WITH ROLLBACK IMMEDIATE;
	DROP DATABASE final_capstone;
END

CREATE DATABASE final_capstone
GO

USE final_capstone
GO

-- Create Tables
CREATE TABLE Users (
	user_id int IDENTITY(1,1) NOT NULL,
	username varchar(50) NOT NULL,
	password_hash varchar(200) NOT NULL,
	salt varchar(200) NOT NULL,
	user_role varchar(50) NOT NULL
	CONSTRAINT PK_user PRIMARY KEY (user_id)
)

-- Populate default data for testing: user and admin with password of 'password'
-- These values should not be kept when going to Production
INSERT INTO Users (username, password_hash, salt, user_role) VALUES ('user','Jg45HuwT7PZkfuKTz6IB90CtWY4=','LHxP4Xh7bN0=','user');
INSERT INTO Users (username, password_hash, salt, user_role) VALUES ('admin','YhyGVQ+Ch69n4JMBncM4lNF/i9s=', 'Ar/aB2thQTI=','admin');
GO

CREATE TABLE Decks (
	deck_id int IDENTITY(1,1) NOT NULL,
	user_id int NOT NULL,
	deck_name varchar(50) NOT NULL,
	CONSTRAINT PK_Decks_deck_id_user_id PRIMARY KEY (deck_id, user_id),
	CONSTRAINT FK_Decks_users FOREIGN KEY (user_id) references Users (user_id)
)

INSERT INTO Decks (user_id,deck_name) VALUES (1,'Math');
INSERT INTO Decks (user_id,deck_name) VALUES (1,'Engrish');
INSERT INTO Decks (user_id,deck_name) VALUES (1,'C Sharp');
INSERT INTO Decks (user_id,deck_name) VALUES (1,'D Flat');
GO

CREATE TABLE FlashCards (
	flash_card_id int IDENTITY(1,1) NOT NULL,
	front_text varchar(100) NOT NULL,
	back_text varchar(100) NOT NULL,
	deck_id int NOT NULL
	CONSTRAINT PK_flashcard_id PRIMARY KEY (flash_card_id),
	CONSTRAINT FK_created_by FOREIGN KEY (deck_id) references Decks (user_id)
)

INSERT INTO FlashCards (front_text,back_text,deck_id) VALUES (