CREATE DATABASE CARS

USE CARS

CREATE TABLE Incidents (
	IncidentID INT PRIMARY KEY,
	IncidentType VARCHAR(50),
	IncidentDate DATE,
	Location GEOGRAPHY,
	Description VARCHAR(MAX),
	Status VARCHAR(50),
	VictimID INT FOREIGN KEY REFERENCES Victims(VictimID) ON DELETE CASCADE,
	SuspectID INT FOREIGN KEY REFERENCES Suspects(SuspectID) ON DELETE CASCADE);



CREATE TABLE Victims (
	VictimID INT PRIMARY KEY,
	FirstName VARCHAR(20),
	LastName VARCHAR(20),
	DateOfBirth DATE,
	Gender VARCHAR(15),
	ContactInformation VARCHAR(50)
	)

SELECT * FROM Suspects
SELECT * FROM Incidents

SELECT CONCAT(Location.Lat, ', ', Location.Long) AS HumanReadableLocation
FROM Incidents WHERE IncidentID = 22;

DELETE FROM Victims
WHERE VictimID = 21;

DELETE FROM Suspects
WHERE SuspectID = 21;

DELETE FROM Incidents
WHERE IncidentID = 21;


CREATE TABLE Suspects (
	SuspectID INT PRIMARY KEY,
	FirstName VARCHAR(20),
	LastName VARCHAR(20),
	DateOfBirth DATE,
	Gender VARCHAR(15),
	ContactInformation VARCHAR(50)
	)


CREATE TABLE LawEnforcementAgencies (
	AgencyID INT PRIMARY KEY,
	AgencyName VARCHAR(50),
	Jurisdiction VARCHAR(20),
	ContactInformation VARCHAR(50),
	OfficerID INT FOREIGN KEY REFERENCES Officers(OfficerID) ON DELETE CASCADE)

SELECT * FROM Officers


CREATE TABLE Officers (
	OfficerID INT PRIMARY KEY, 
	FisrtName VARCHAR(20),
	LastName VARCHAR(20),
	BadgeNumber INT,
	Rank VARCHAR(20),
	ContactInfo VARCHAR(30),
	AgencyID INT)

CREATE TABLE Evidence (
	EvidenceID INT PRIMARY KEY, 
	Description VARCHAR(20),
	LocationFound GEOGRAPHY,
	IncidentID INT FOREIGN KEY REFERENCES Incidents(IncidentID) ON DELETE CASCADE)

	SELECT EvidenceID, Description, CONCAT(Location.Long, ', ', Location.Lat) AS LocationFound, IncidentID FROM Evidence

DROP TABLE Evidence

CREATE TABLE Reports (
	ReportID INT PRIMARY KEY,
	IncidentID INT FOREIGN KEY REFERENCES Incidents(IncidentID) ON DELETE CASCADE,
	ReportingOfficer INT FOREIGN KEY REFERENCES Officers(OfficerID) ON DELETE CASCADE,
	ReportDate DATE,
	ReportDetails TEXT,
	Status VARCHAR(20))

SELECT * FROM Reports

CREATE TABLE adminLogin (
	ID INT PRIMARY KEY,
	UserName VARCHAR(20),
	Password VARCHAR(20))


CREATE TABLE userLogin (
	ID INT PRIMARY KEY,
	UserName VARCHAR(20),
	Password VARCHAR(20))

CREATE TABLE Cases (
	CaseID INT PRIMARY KEY,
	Description VARCHAR(30),
	Status VARCHAR(20),
	IncidentID INT FOREIGN KEY REFERENCES Incidents(IncidentID)
	)
INSERT INTO Cases VALUES	
	(4, 'Littering', 'Closed', 11)
DELETE FROM Victims Where VictimID = 21

SELECT i.IncidentID FROM Incidents i JOIN Victims v ON i.VictimID = v.VictimID WHERE v.FirstName = 'Sarah' AND v.LastName = 'Anderson' AND v.DateOfBirth = '1980-10-14' AND v.Gender = 'Female'

SELECT COUNT(*) FROM Victims WHERE FirstName = 'Sarah' AND LastName = 'Anderson' AND DateOfBirth = '1980-10-14' AND Gender = 'Female'
SELECT * from Incidents
SELECT * from Victims
SELECT * from Suspects
SELECT * from LawEnforcementAgencies
SELECT * from Officers
SELECT * from Evidence
SELECT * from Reports
SELECT * FROM userLogin
SELECT * FROM Cases

DELETE FROM Reports
WHERE ReportID = 21;

INSERT INTO Victims (VictimID, FirstName, LastName, DateOfBirth, Gender, ContactInformation) VALUES 
 (1, 'John', 'Doe', '1990-05-15', 'Male', '123 Main St, City, Country'),
 (2, 'Jane', 'Smith', '1985-08-20', 'Female', '456 Elm St, City, Country'),
 (3, 'Michael', 'Johnson', '1982-11-10', 'Male', '789 Oak St, City, Country'),
 (4, 'Emily', 'Brown', '1978-03-25', 'Female', '101 Pine St, City, Country'),
 (5, 'William', 'Wilson', '1995-09-08', 'Male', '202 Maple St, City, Country'),
 (6, 'Amanda', 'Jones', '1989-07-12', 'Female', '303 Cedar St, City, Country'),
 (7, 'David', 'Davis', '1983-12-30', 'Male', '404 Birch St, City, Country'),
 (8, 'Jessica', 'Martinez', '1975-06-18', 'Female', '505 Oak St, City, Country'),
 (9, 'James', 'Miller', '1992-04-02', 'Male', '606 Pine St, City, Country'),
 (10, 'Sarah', 'Anderson', '1980-10-14', 'Female', '707 Elm St, City, Country'),
 (11, 'Daniel', 'Taylor', '1976-02-28', 'Male', '808 Cedar St, City, Country'),
 (12, 'Elizabeth', 'Jackson', '1998-11-03', 'Female', '909 Birch St, City, Country'),
 (13, 'Christopher', 'Harris', '1987-01-17', 'Male', '1010 Oak St, City, Country'),
 (14, 'Ashley', 'White', '1979-07-05', 'Female', '1111 Maple St, City, Country'),
 (15, 'Matthew', 'Clark', '1991-09-23', 'Male', '1212 Pine St, City, Country'),
 (16, 'Megan', 'Lewis', '1984-05-31', 'Female', '1313 Elm St, City, Country'),
 (17, 'Joshua', 'King', '1977-03-08', 'Male', '1414 Cedar St, City, Country'),
 (18, 'Stephanie', 'Scott', '1994-12-19', 'Female', '1515 Birch St, City, Country'),
 (19, 'Ryan', 'Young', '1981-08-27', 'Male', '1616 Oak St, City, Country'),
 (20, 'Lauren', 'Lee', '1974-06-11', 'Female', '1717 Maple St, City, Country');

 INSERT INTO Suspects (SuspectID, FirstName, LastName, DateOfBirth, Gender, ContactInformation)
VALUES 
(1, 'Michael', 'Jones', '1988-04-18', 'Male', '789 Elm St, City21, Country21'),
(2, 'Sarah', 'Williams', '1993-10-29', 'Female', '456 Oak St, City22, Country22'),
(3, 'Matthew', 'Davis', '1980-07-15', 'Male', '101 Maple St, City23, Country23'),
(4, 'Emily', 'Anderson', '1976-01-07', 'Female', '202 Birch St, City24, Country24'),
(5, 'David', 'Wilson', '1997-08-22', 'Male', '303 Cedar St, City25, Country25'),
(6, 'Jessica', 'Brown', '1984-03-11', 'Female', '404 Pine St, City26, Country26'),
(7, 'John', 'Taylor', '1981-12-03', 'Male', '505 Elm St, City27, Country27'),
(8, 'Amanda', 'Martinez', '1990-09-16', 'Female', '606 Oak St, City28, Country28'),
(9, 'Ryan', 'Harris', '1979-06-25', 'Male', '707 Maple St, City29, Country29'),
(10, 'Elizabeth', 'Scott', '1986-02-28', 'Female', '808 Birch St, City30, Country30'),
(11, 'Christopher', 'Jackson', '1995-11-13', 'Male', '909 Cedar St, City31, Country31'),
(12, 'Megan', 'Lee', '1982-07-07', 'Female', '1010 Elm St, City32, Country32'),
(13, 'Joshua', 'White', '1977-04-01', 'Male', '1111 Pine St, City33, Country33'),
(14, 'Stephanie', 'Clark', '1992-12-14', 'Female', '1212 Maple St, City34, Country34'),
(15, 'Daniel', 'Lewis', '1989-05-19', 'Male', '1313 Birch St, City35, Country35'),
(16, 'Lauren', 'Smith', '1978-10-03', 'Female', '1414 Cedar St, City36, Country36'),
(17, 'Ashley', 'Miller', '1994-07-26', 'Female', '1515 Elm St, City37, Country37'),
(18, 'William', 'Young', '1983-03-18', 'Male', '1616 Oak St, City38, Country38'),
(19, 'Jessica', 'King', '1975-08-12', 'Female', '1717 Maple St, City39, Country39'),
(20, 'James', 'Taylor', '1998-06-05', 'Male', '1818 Pine St, City40, Country40');

SELECT CONCAT(Location.Lat, ', ', Location.Long) AS HumanReadableLocation
FROM Incidents WHERE IncidentID = 22;

UPDATE Incidents SET Location = geography::Point(90, 180, 4326) WHERE IncidentID = 1;

INSERT INTO Incidents (IncidentID, IncidentType, IncidentDate, Location, Description, Status, VictimID, SuspectID)
VALUES
(1, 'Vandalism', '2023-01-02', geography::Point(47.6097, -122.3331, 4326), 'Broke street sign', 'Closed', 12, 8),
(2, 'Homicide', '2023-01-02', geography::Point(40.7128, -74.0060, 4326), 'Shot in the head', 'Closed', 5, 6),
(3, 'Theft', '2023-01-03', geography::Point(34.0522, -118.2437, 4326), 'Car theft', 'Under Investigation', 2, 10),
(4, 'Assault', '2023-01-04', geography::Point(41.8781, -87.6298, 4326), 'Bypasser knocked out', 'Open', 2, 11),
(5, 'Burglary', '2023-01-05', geography::Point(29.7604, -95.3698, 4326), 'Broke into house', 'Closed', 6, 10),
(6, 'Vandalism', '2023-01-06', geography::Point(37.7749, -122.4194, 4326), 'Destroyed public property', 'Under Investigation', 14, 20),
(7, 'Kidnapping', '2023-01-07', geography::Point(51.5074, -0.1278, 4326), 'Kidnapped kids', 'Open', 7, 19),
(8, 'Fraud', '2023-01-08', geography::Point(32.7157, -117.1611, 4326), 'Online fraud', 'Closed', 8, 18),
(9, 'Arson', '2023-01-09', geography::Point(39.9526, -75.1652, 4326), 'Set fire to friends house', 'Under Investigation', 4, 19),
(10, 'Forgery', '2023-01-10', geography::Point(43.6532, -79.3832, 4326), 'Fake currency', 'Open', 10, 11),
(11, 'Extortion', '2023-01-11', geography::Point(38.9072, -77.0369, 4326), 'Extortion of females', 'Closed', 10, 10),
(12, 'Harassment', '2023-01-12', geography::Point(37.7749, -122.4194, 4326), 'Harrased minors', 'Under Investigation', 13, 1),
(13, 'Stalking', '2023-01-13', geography::Point(34.0522, -118.2437, 4326), 'Stalking girlfriend', 'Open', 7, 2),
(14, 'Arson', '2023-01-14', geography::Point(39.9526, -75.1652, 4326), 'Set fire to neighbours car', 'Closed', 18, 14),
(15, 'Blackmail', '2023-01-15', geography::Point(33.4484, -112.0740, 4326), 'Blackmailed their boss', 'Under Investigation', 6, 5),
(16, 'Robbery', '2023-01-16', geography::Point(47.6097, -122.3331, 4326), 'Robbed a old man', 'Open', 16, 6),
(17, 'Homicide', '2023-01-17', geography::Point(16.7000, 74.2333, 4326), 'Killed parents', 'Closed', 17, 17),
(18, 'Theft', '2023-01-18', geography::Point(18.5204, 73.8567, 4326), 'Stole a parked bike', 'Under Investigation', 19, 5),
(19, 'Assault', '2023-01-19', geography::Point(22.9734, 78.6569, 4326), 'Assaulted a police officer', 'Open', 19, 7),
(20, 'Burglary', '2023-01-20', geography::Point(23.0225, 72.5714, 4326), 'Broke into house', 'Closed', 20, 10)

INSERT INTO Incidents (IncidentID, IncidentType, IncidentDate, Location, Description, Status, VictimID, SuspectID)
VALUES(21, 'Burglary', '2023-01-20', geography::Point(23.0225, 72.5714, 4326), 'Broke into house', 'Closed', 20, 10)

INSERT INTO Reports (ReportID, IncidentID, ReportingOfficer, ReportDate, ReportDetails, Status)
VALUES 
    (1, 1, 5, '2023-05-01', 'Police enquiry', 'Open'),
    (2, 2, 8, '2024-04-02', 'Crimscene closed', 'Closed'),
    (3, 7, 2, '2022-02-21', 'No evidence found', 'Under Investigation'),
    (4, 4, 1, '2023-02-11', 'Evidence not found', 'Draft'),
    (5, 5, 1, '2024-05-05', 'Fingerprints found', 'Finalized'),
    (6, 6, 8, '2024-05-06', 'Murder weapon found', 'Open'),
    (7, 8, 20, '2024-05-07', '2 eye witnesses', 'Closed'),
    (8, 8, 20, '2024-05-08', 'Case to be closed soon', 'Under Investigation'),
    (9, 9, 19, '2024-05-09', 'Mystery', 'Draft'),
    (10, 10, 15, '2024-05-10', 'Given to CBI', 'Finalized'),
    (11, 11, 8, '2024-05-11', 'Drugs involved', 'Open'),
    (12, 12, 9, '2024-05-12', 'Culprit college kids', 'Closed'),
    (13, 13, 19, '2024-05-13', 'Car accident', 'Under Investigation'),
    (14, 14, 20, '2024-05-14', 'No insurance', 'Draft'),
    (15, 12, 15, '2024-05-15', 'Fight over food', 'Finalized'),
    (16, 16, 4, '2024-05-16', 'Fistfight between friends', 'Open'),
    (17, 17, 1, '2024-05-17', 'Protest', 'Closed'),
    (18, 13, 3, '2024-05-18', 'Drink and drive', 'Under Investigation'),
    (19, 19, 10, '2021-05-19', 'No license', 'Draft'),
    (20, 15, 10, '2023-12-20', 'Illegal firearm', 'Finalized');

	INSERT INTO Officers (OfficerID, FisrtName, LastName, BadgeNumber, Rank, ContactInfo, AgencyID)
VALUES
    (1, 'Michael', 'Anderson', 1001, 'Sergeant', 'michael.anderson@example.com', 11),
    (2, 'Jessica', 'Wilson', 1022, 'Lieutenant', 'jessica.wilson@example.com', 11),
    (3, 'Christopher', 'Taylor', 1003, 'Detective', 'christopher.taylor@example.com', 12),
    (4, 'Amanda', 'Martin', 1004, 'Officer', 'amanda.martin@example.com', 12),
    (5, 'Matthew', 'Thomas', 1005, 'Sergeant', 'matthew.thomas@example.com', 13),
    (6, 'Samantha', 'Garcia', 1006, 'Lieutenant', 'samantha.garcia@example.com', 13),
    (7, 'David', 'Hernandez', 1007, 'Detective', 'david.hernandez@example.com', 14),
    (8, 'Jennifer', 'Lopez', 1008, 'Officer', 'jennifer.lopez@example.com', 14),
    (9, 'James', 'Perez', 1009, 'Sergeant', 'james.perez@example.com', 15),
    (10, 'Emily', 'Flores', 1010, 'Lieutenant', 'emily.flores@example.com', 15),
    (11, 'Daniel', 'Gonzalez', 1011, 'Detective', 'daniel.gonzalez@example.com', 16),
    (12, 'Ashley', 'Rodriguez', 1012, 'Officer', 'ashley.rodriguez@example.com', 16),
    (13, 'Robert', 'Wilson', 1013, 'Sergeant', 'robert.wilson@example.com', 17),
    (14, 'Brittany', 'Martinez', 1014, 'Lieutenant', 'brittany.martinez@example.com', 17),
    (15, 'William', 'Brown', 1015, 'Detective', 'william.brown@example.com', 18),
    (16, 'Melissa', 'Hernandez', 1016, 'Officer', 'melissa.hernandez@example.com', 18),
    (17, 'John', 'Gonzalez', 1017, 'Sergeant', 'john.gonzalez@example.com', 19),
    (18, 'Stephanie', 'Young', 1018, 'Lieutenant', 'stephanie.young@example.com', 19),
    (19, 'Michael', 'Walker', 1019, 'Detective', 'michael.walker@example.com', 20),
    (20, 'Heather', 'King', 1020, 'Officer', 'heather.king@example.com', 20);

INSERT INTO adminLogin VALUES
    (1, 'admin_1', 'password123'),
    (2, 'admin_2', 'pass@123'),
    (3, 'admin_3', 'admin123'),
    (4, 'admin_4', 'admin'),
    (5, 'admin_5', 'pass');

INSERT INTO userLogin VALUES
    (1, 'parth', 'patilparth'),
    (2, 'user123', 'password1'),
    (3, 'controlRoom', 'pass@123456'),
    (4, 'pcr', 'pcr@123'),
    (5, 'evidenceDept', '12345678');

INSERT INTO LawEnforcementAgencies (AgencyID, AgencyName, Jurisdiction, ContactInformation, OfficerID) 
VALUES
    (1, 'City Police Department', 'Washington', '123 Main St, Washington', 1),
    (2, 'County Sheriff Office', 'Tenesse', '456 Oak Ave, Tenesse', 2),
    (3, 'State Highway Patrol', 'Texas', '789 Elm St, Texas', 3),
    (4, 'Federal Bureau of Investigation', 'National', '101 Federal Way, National', 4),
    (5, 'Drug Enforcement Administration', 'National', '202 Narcotics St, National', 5),
    (6, 'City Police Department', 'Mephis', '345 Maple Ave, Mephis', 6),
    (7, 'County Sheriff Office', 'Blaine County', '678 Pine St, Blaine County', 7),
    (8, 'State Bureau of Investigation', 'New York', '909 Justice Blvd, New York', 8),
    (9, 'Federal Bureau of Investigation', 'National', '303 Spy Rd, National', 9),
    (10, 'Drug Enforcement Administration', 'National', '505 Narcotics Ln, National', 10),
    (11, 'City Police Department', 'Los Angeles', '707 Grove St, Los Angeles', 11),
    (12, 'County Sheriff Office', 'New Mexico', '808 Cedar St, New Mexico', 12),
    (13, 'State Bureau of Investigation', 'Albuquerque', '909 Justice Blvd, Albuquerque', 13),
    (14, 'Federal Bureau of Investigation', 'National', '101 Federal Way, National', 14),
    (15, 'Drug Enforcement Administration', 'National', '202 Narcotics St, National', 15),
    (16, 'City Police Department', 'Detroit', '1212 Maple Ave, Detroit', 16),
    (17, 'County Sheriff Office', 'Everglades', '1313 Pine St, Everglades', 17),
    (18, 'State Highway Patrol', 'New Jersy', '1414 Elm St, New Jersy', 18),
    (19, 'Federal Bureau of Investigation', 'National', '1515 Spy Rd, National', 19),
    (20, 'Drug Enforcement Administration', 'National', '1616 Narcotics Ln, National', 20);


INSERT INTO Evidence (EvidenceID, Description, LocationFound, IncidentID) 
VALUES
    (1, 'Fingerprint', geography::Point(47.6097, -122.3331, 4326), 1),
    (2, 'Bloodstain', geography::Point(40.7128, -74.0060, 4326), 2),
    (3, 'Weapon', geography::Point(34.0522, -118.2437, 4326), 3),
    (4, 'Footprint', geography::Point(41.8781, -87.6298, 4326), 4),
    (5, 'Hair Strand', geography::Point(29.7604, -95.3698, 4326), 5),
    (6, 'Drug Bag', geography::Point(33.7490, -84.3880, 4326), 6),
    (7, 'DNA Sample', geography::Point(37.7749, -122.4194, 4326), 7),
    (8, 'CCTV Footage', geography::Point(51.5074, -0.1278, 4326), 8),
    (9, 'Bullet Casing', geography::Point(32.7157, -117.1611, 4326), 9),
    (10, 'Digital Evidence', geography::Point(39.9526, -75.1652, 4326), 10),
    (11, 'Footwear Impression', geography::Point(43.6532, -79.3832, 4326), 11),
    (12, 'Shell Casing', geography::Point(38.9072, -77.0369, 4326), 12),
    (13, 'Firearm', geography::Point(34.0522, -118.2437, 4326), 13),
    (14, 'Hair Strand', geography::Point(37.7749, -122.4194, 4326), 14),
    (15, 'Fingerprint', geography::Point(33.7490, -84.3880, 4326), 15),
    (16, 'Drug Bag', geography::Point(34.0522, -118.2437, 4326), 16),
    (17, 'CCTV Footage', geography::Point(32.7157, -117.1611, 4326), 17),
    (18, 'Digital Evidence', geography::Point(40.7128, -74.0060, 4326), 18),
    (19, 'Footwear Impression', geography::Point(34.0522, -118.2437, 4326), 19),
    (20, 'Bullet Casing', geography::Point(41.8781, -87.6298, 4326), 20);


SELECT CONVERT(NVARCHAR(MAX), LocationFound) AS HumanReadableLocation
FROM Evidence;

SELECT LocationFound.ToString() AS HumanReadableLocation
FROM Evidence;

SELECT LocationFound.STAsText() AS HumanReadableLocation
FROM Evidence;

SELECT LocationFound.Long AS Longitude, LocationFound.Lat AS Latitude
FROM Evidence;

SELECT CONCAT(LocationFound.Long, ', ', LocationFound.Lat) AS HumanReadableLocation
FROM Evidence;

SELECT CONCAT(Location.Long, ', ', Location.Lat) AS HumanReadableLocation
FROM Incidents WHERE IncidentID = 20;
