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
	deck_description varchar(500) NOT NULL,
	CONSTRAINT PK_Decks_deck_id PRIMARY KEY (deck_id),
	CONSTRAINT FK_Decks_users FOREIGN KEY (user_id) references Users (user_id)
)

INSERT INTO Decks (user_id, deck_name,deck_description) VALUES (1, 'Math','Random Math Questions');
INSERT INTO Decks (user_id, deck_name,deck_description) VALUES (1, 'Engrish','Funny questions about Engrish');
INSERT INTO Decks (user_id, deck_name,deck_description) VALUES (1, 'C Sharp','Trivia about a programming language');
INSERT INTO Decks (user_id, deck_name,deck_description) VALUES (1, 'D Flat','Jokes about how terms used for music can be translated into other forms');
GO

CREATE TABLE Flashcards (
	flash_card_id int IDENTITY(1,1) NOT NULL,
	front_text varchar(100) NOT NULL,
	back_text varchar(100) NOT NULL,
	deck_id int NOT NULL
	CONSTRAINT PK_flashcard_id PRIMARY KEY (flash_card_id),
	CONSTRAINT FK_created_by FOREIGN KEY (deck_id) references Decks (deck_id)
)

INSERT INTO Flashcards (front_text,back_text,deck_id) VALUES ('What is 1+1', '2', 1);
INSERT INTO Flashcards (front_text,back_text,deck_id) VALUES ('What does immutable mean?','It cannot be changed', 3);
INSERT INTO Flashcards (front_text,back_text,deck_id) VALUES ('What is 2+2', '4', 1);
INSERT INTO Flashcards (front_text,back_text,deck_id) VALUES ('How can you loop through a list without an index','Foreach', 3);
GO

CREATE TABLE Tags (
	tag_id int IDENTITY(1,1) NOT NULL,
	name varchar(25) NOT NULL,

	CONSTRAINT PK_Tags_tag_id PRIMARY KEY (tag_id)
)

INSERT INTO Tags (name) VALUES ('Math');
INSERT INTO Tags (name) VALUES ('Computer');
INSERT INTO Tags (name) VALUES ('Complicated');
INSERT INTO Tags (name) VALUES ('EZPZ');
INSERT INTO Tags (name) VALUES ('Phil made me');
GO

CREATE TABLE Flashcards_Tags (
	flash_card_id int NOT NULL,
	tag_id int NOT NULL
	CONSTRAINT PK_Flashcards_Tags_flash_card_id_tag_id PRIMARY KEY (flash_card_id,tag_id),
	CONSTRAINT FK_flash_card_id FOREIGN KEY (flash_card_id) REFERENCES Flashcards (flash_card_id),
	CONSTRAINT FK_tag_id FOREIGN KEY (tag_id) REFERENCES Tags (tag_id),
)

INSERT INTO Flashcards_Tags (flash_card_id,tag_id) VALUES (1,1);
INSERT INTO Flashcards_Tags (flash_card_id,tag_id) VALUES (1,4);
INSERT INTO Flashcards_Tags (flash_card_id,tag_id) VALUES (1,5);
INSERT INTO Flashcards_Tags (flash_card_id,tag_id) VALUES (3,3);
INSERT INTO Flashcards_Tags (flash_card_id,tag_id) VALUES (3,2);
INSERT INTO Flashcards_Tags (flash_card_id,tag_id) VALUES (2,2);
INSERT INTO Flashcards_Tags (flash_card_id,tag_id) VALUES (2,4);
INSERT INTO Flashcards_Tags (flash_card_id,tag_id) VALUES (2,5);
INSERT INTO Flashcards_Tags (flash_card_id,tag_id) VALUES (4,5);
GO
