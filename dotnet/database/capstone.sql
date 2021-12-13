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
INSERT INTO Decks (user_id, deck_name,deck_description) VALUES (1, '.NET - Module One','Questions from C#');
INSERT INTO Decks (user_id, deck_name,deck_description) VALUES (1, '.NET - Module Two','Questions from SQL');
INSERT INTO Decks (user_id, deck_name,deck_description) VALUES (1, '.NET - Module Three','Questions from HTML/CSS/Javascript');
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
INSERT INTO Flashcards (front_text,back_text,deck_id) VALUES ('What is 2+2?', '4', 1);
INSERT INTO Flashcards (front_text,back_text,deck_id) VALUES ('How can you loop through a list without an index?','Foreach', 3);
INSERT INTO Flashcards (front_text,back_text,deck_id) VALUES ('What primitive data types do you know in C#?','boolean, int, float, decimal, char...',5);
INSERT INTO Flashcards (front_text,back_text,deck_id) VALUES ('What is a class?','The blueprint of an object',5);
INSERT INTO Flashcards (front_text,back_text,deck_id) VALUES ('What''s the difference between a for loop and a while loop?','A for loop goes through a specific number of iterations and a while loop goes until a condition is met',5);
INSERT INTO Flashcards (front_text,back_text,deck_id) VALUES ('What''s the difference between a while loop and a do while loop?','A do while loop will always run once then test the condition',5);
INSERT INTO Flashcards (front_text,back_text,deck_id) VALUES ('What''s the difference between a stack and a queue?','Stack = FILO, Queue = FIFO',5);
INSERT INTO Flashcards (front_text,back_text,deck_id) VALUES ('What is a unit test?','A test of a specific method (red,green,refactor)',5);
INSERT INTO Flashcards (front_text,back_text,deck_id) VALUES ('What is immutability?','An object doesn''t inherantly change',5);
INSERT INTO Flashcards (front_text,back_text,deck_id) VALUES ('What are the three parts of object oriented programming?','Encapsulation, Inheritance, Polymorphism',5);
INSERT INTO Flashcards (front_text,back_text,deck_id) VALUES ('Is C# compiled or interpreted?','Compiled',5);
INSERT INTO Flashcards (front_text,back_text,deck_id) VALUES ('What does the const keyword mean?','The value of the variable does not change',5);
INSERT INTO Flashcards (front_text,back_text,deck_id) VALUES ('What git commands do you know?','Add, commit, pull, push',5);
INSERT INTO Flashcards (front_text,back_text,deck_id) VALUES ('What’s the difference between inheriting a class and implementing an interface?','Inheritance is optional, an interface is mandatory',5);
INSERT INTO Flashcards (front_text,back_text,deck_id) VALUES ('What is polymorphism?','Grouping things based upon their differences',5);
INSERT INTO Flashcards (front_text,back_text,deck_id) VALUES ('What is the common language runtime?','virtual machine component of Microsoft .NET Framework, manages the execution of .NET programs',5);
INSERT INTO Flashcards (front_text,back_text,deck_id) VALUES ('How many cans of Diet Doctor Pepper were consumed in or over Ohio last month?','',5);
INSERT INTO Flashcards (front_text,back_text,deck_id) VALUES ('If you had an airplane that was completely full of jelly beans, how would you get the jelly beans out? You are allowed to only use boxes.','We leave this up to your imagination',5);
INSERT INTO Flashcards (front_text,back_text,deck_id) VALUES ('What''s the difference between the heap and the queue','They''re not related?',5);
INSERT INTO Flashcards (front_text,back_text,deck_id) VALUES ('What is a property in C#?','A member that provides a flexible mechanism to read, write, or compute the value of a private field',5);
INSERT INTO Flashcards (front_text,back_text,deck_id) VALUES ('What does the virtual keyword mean?','the method and variable are marked as virtual in base class you can override in derived class and change the definition of that method',5);
INSERT INTO Flashcards (front_text,back_text,deck_id) VALUES ('What access modifiers or visibilities do you know in C# and what do they mean?','Public - Access is not restricted, protected - Access is limited to the containing class or types derived from the containing class, internal - Access is limited to the current assembly, private - Access is limited to the containing type',5);
INSERT INTO Flashcards (front_text,back_text,deck_id) VALUES ('What is an interface?','contains definitions for a group of related functionalities that a non-abstract class or a structure must implement',5);
INSERT INTO Flashcards (front_text,back_text,deck_id) VALUES ('What is the difference between an array and a list','An arry is a specific list of items whose length cannot change, a list can be changed and manipulated',5);
INSERT INTO Flashcards (front_text,back_text,deck_id) VALUES ('What’s the difference between C# and .NET?','.NET is the framework, C# is the language',5);
INSERT INTO Flashcards (front_text,back_text,deck_id) VALUES ('What is a Dictionary?','A non-indexed, non-duplicated collection of items that have a key paired with a value',5);
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
