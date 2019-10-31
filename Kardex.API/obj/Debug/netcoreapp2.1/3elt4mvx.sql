CREATE TABLE `__EFMigrationsHistory` (
    `MigrationId` varchar(95) NOT NULL,
    `ProductVersion` varchar(32) NOT NULL,
    CONSTRAINT `PK___EFMigrationsHistory` PRIMARY KEY (`MigrationId`)
);

CREATE TABLE `CardList` (
    `Id` int NOT NULL AUTO_INCREMENT,
    `Title` varchar(50) NULL,
    CONSTRAINT `PK_CardList` PRIMARY KEY (`Id`)
);

CREATE TABLE `User` (
    `Id` int NOT NULL AUTO_INCREMENT,
    `Name` varchar(50) NULL,
    `Email` longtext NULL,
    `Password` longtext NULL,
    CONSTRAINT `PK_User` PRIMARY KEY (`Id`)
);

CREATE TABLE `Card` (
    `Id` int NOT NULL AUTO_INCREMENT,
    `Title` varchar(50) NULL,
    `Content` varchar(200) NULL,
    `Lables` longtext NULL,
    `UserId` int NOT NULL,
    `CardListId` int NOT NULL,
    CONSTRAINT `PK_Card` PRIMARY KEY (`Id`),
    CONSTRAINT `FK_Card_CardList_CardListId` FOREIGN KEY (`CardListId`) REFERENCES `CardList` (`Id`) ON DELETE CASCADE,
    CONSTRAINT `FK_Card_User_UserId` FOREIGN KEY (`UserId`) REFERENCES `User` (`Id`) ON DELETE CASCADE
);

CREATE INDEX `IX_Card_CardListId` ON `Card` (`CardListId`);

CREATE INDEX `IX_Card_UserId` ON `Card` (`UserId`);

INSERT INTO `__EFMigrationsHistory` (`MigrationId`, `ProductVersion`)
VALUES ('20191031131619_InitialCreate', '2.1.8-servicing-32085');

