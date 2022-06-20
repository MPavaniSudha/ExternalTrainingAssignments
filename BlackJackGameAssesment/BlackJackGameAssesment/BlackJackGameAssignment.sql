create database BlackJackDB

use BlackJackDB

create table Card
(CardNo int primary key,
CardName  varchar(20),
CardValue int)

insert into Card values
(1,'Ace of Clubs',1),
(2,'Ace of Diamonds',1),
(3,'Ace of Hearts',1),
(4,'Ace of Spades',1),
(5,'2 of Clubs',2),
(6,'2 of Diamonds',2),
(7,'2 of Hearts',2),
(8,'2 of Spades',2),
(9,'3 of Clubs',3),
(10,'3 of Diamonds',3),
(11,'3 of Hearts',3),
(12,'3 of Spades',3),
(13,'4 of Clubs',4),
(14,'4 of Diamonds',4),
(15,'4 of Hearts',4),
(16,'4 of Spades',4),
(17,'5 of Clubs',5),
(18,'5 of Diamonds',5),
(19,'5 of Hearts',5),
(20,'5 of Spades',5),
(21,'6 of Clubs',6),
(22,'6 of Diamonds',6),
(23,'6 of Hearts',6),
(24,'6 of Spades',6),
(25,'7 of Clubs',7),
(26,'7 of Diamonds',7),
(27,'7 of Hearts',7),
(28,'7 of Spades',7),
(29,'8 of Clubs',8),
(30,'8 of Diamonds',8),
(31,'8 of Hearts',8),
(32,'8 of Spades',8),
(33,'9 of Clubs',9),
(34,'9 of Diamonds',9),
(35,'9 of Hearts',9),
(36,'9 of Spades',9),
(37,'Ten of Clubs',10),
(38,'Ten of Hearts',10),
(39,'Ten of Diamonds',10),
(40,'Ten of Spades',10),
(41,'Jack of Clubs',10),
(42,'Jack of Hearts',10),
(43,'Jack of Diamonds',10),
(44,'Jack of Spades',10),
(45,'King of Clubs',10),
(46,'King of Hearts',10),
(47,'King of Diamonds',10),
(48,'King of Spades',10),
(49,'Queen of Clubs',10),
(50,'Queen of Hearts',10),
(51,'Queen of Diamonds',10),
(52,'Queen of Spades',10)



select * from Card

create table Session
(GameNo int Identity(1,1) primary key ,
PlayerTotal int,
DealerTotal int,
GameResult varchar(40))

select * from Session

