-- --------------------------------------------------------------------------------
-- Name: Tyler Ethridge
 
-- Abstract: FlyMe2theMoon
-- --------------------------------------------------------------------------------

-- --------------------------------------------------------------------------------
-- Options
-- --------------------------------------------------------------------------------
USE dbFlyMe2theMoon;     
SET NOCOUNT ON;  

-- --------------------------------------------------------------------------------
--						Problem #10
-- --------------------------------------------------------------------------------

-- Drop Table Statements
IF OBJECT_ID ('TPilotFlights')			IS NOT NULL DROP TABLE TPilotFlights
IF OBJECT_ID ('TAttendantFlights')		IS NOT NULL DROP TABLE TAttendantFlights
IF OBJECT_ID ('TFlightPassengers')		IS NOT NULL DROP TABLE TFlightPassengers
IF OBJECT_ID ('TMaintenanceMaintenanceWorkers')			IS NOT NULL DROP TABLE TMaintenanceMaintenanceWorkers

IF OBJECT_ID ('TEmployees')				IS NOT NULL DROP TABLE TEmployees
IF OBJECT_ID ('TPassengers')			IS NOT NULL DROP TABLE TPassengers
IF OBJECT_ID ('TPilots')				IS NOT NULL DROP TABLE TPilots
IF OBJECT_ID ('TAttendants')			IS NOT NULL DROP TABLE TAttendants
IF OBJECT_ID ('TMaintenanceWorkers')	IS NOT NULL DROP TABLE TMaintenanceWorkers

IF OBJECT_ID ('TFlights')				IS NOT NULL DROP TABLE TFlights
IF OBJECT_ID ('TMaintenances')			IS NOT NULL DROP TABLE TMaintenances
IF OBJECT_ID ('TPlanes')				IS NOT NULL DROP TABLE TPlanes
IF OBJECT_ID ('TPlaneTypes')			IS NOT NULL DROP TABLE TPlaneTypes
IF OBJECT_ID ('TPilotRoles')			IS NOT NULL DROP TABLE TPilotRoles
IF OBJECT_ID ('TAirports')				IS NOT NULL DROP TABLE TAirports
IF OBJECT_ID ('TStates')				IS NOT NULL DROP TABLE TStates

-- --------------------------------------------------------------------------------
--	Step #1 : Create table 
-- --------------------------------------------------------------------------------

CREATE TABLE TPassengers
(
	 intPassengerID				INTEGER			NOT NULL
	,strFirstName				VARCHAR(255)	NOT NULL
	,strLastName				VARCHAR(255)	NOT NULL
	,strAddress					VARCHAR(255)	NOT NULL
	,strCity					VARCHAR(255)	NOT NULL
	,intStateID					INTEGER			NOT NULL
	,strZip						VARCHAR(255)	NOT NULL
	,strPhoneNumber				VARCHAR(255)	NOT NULL
	,strEmail					VARCHAR(255)	NOT NULL
	,strPassengerLoginID		VARCHAR(255)	NOT NULL
	,strPassengerPassword		VARCHAR(255)	NOT NULL
	,dtmPassengerDateofBirth	DATETIME		NULL
	,CONSTRAINT TPassengers_PK PRIMARY KEY ( intPassengerID )
)


CREATE TABLE TPilots
(
	 intPilotID				INTEGER			NOT NULL
	,strFirstName			VARCHAR(255)	NOT NULL
	,strLastName			VARCHAR(255)	NOT NULL
	,strEmployeeID			VARCHAR(255)	NOT NULL
	,dtmDateOfHire			DATETIME		NOT NULL
	,dtmDateOfTermination	DATETIME		NOT NULL
	,dtmDateOfLicense		DATETIME		NOT NULL
	,intPilotRoleID			INTEGER			NOT NULL

	,CONSTRAINT TPilots_PK PRIMARY KEY ( intPilotID )
)

CREATE TABLE TEmployees
(
	intEmployeeID				Integer			Not NUll
   ,strEmployeeLoginID			VARCHAR(255)	NOT NULL
   ,strEmployeePassword			VARCHAR(255)	NOT NULL
   ,strEmployeeRole				VARCHAR(255)	NOT NULL
   ,intPilotID					Integer			Null
   ,intAttendantID				Integer			Null

   ,CONSTRAINT TEmployee_PK PRImary KEY (intEmployeeID)

)


CREATE TABLE TAttendants
(
	 intAttendantID			INTEGER			NOT NULL
	,strFirstName			VARCHAR(255)	NOT NULL
	,strLastName			VARCHAR(255)	NOT NULL
	,strEmployeeID			VARCHAR(255)	NOT NULL
	,dtmDateOfHire			DATETIME		NOT NULL
	,dtmDateOfTermination	DATETIME		NOT NULL
	,CONSTRAINT TAttendants_PK PRIMARY KEY ( intAttendantID )
)


CREATE TABLE TMaintenanceWorkers
(
	 intMaintenanceWorkerID	INTEGER			NOT NULL
	,strFirstName			VARCHAR(255)	NOT NULL
	,strLastName			VARCHAR(255)	NOT NULL
	,strEmployeeID			VARCHAR(255)	NOT NULL
	,dtmDateOfHire			DATETIME		NOT NULL
	,dtmDateOfTermination	DATETIME		NOT NULL
	,dtmDateOfCertification	DATETIME		NOT NULL
	,CONSTRAINT TMaintenanceWorkers_PK PRIMARY KEY ( intMaintenanceWorkerID )
)


CREATE TABLE TStates
(
	 intStateID			INTEGER			NOT NULL
	,strState			VARCHAR(255)	NOT NULL
	,CONSTRAINT TStates_PK PRIMARY KEY ( intStateID )
)


CREATE TABLE TFlights
(
	 intFlightID			INTEGER			NOT NULL
	,strFlightNumber		VARCHAR(255)	NOT NULL
	,dtmFlightDate			DATETIME		NOT NULL
	,dtmTimeofDeparture		TIME			NOT NULL
	,dtmTimeOfLanding		TIME			NOT NULL
	,intFromAirportID		INTEGER			NOT NULL
	,intToAirportID			INTEGER			NOT NULL
	,intMilesFlown			INTEGER			NOT NULL
	,intPlaneID				INTEGER			NOT NULL
	,CONSTRAINT TFlights_PK PRIMARY KEY ( intFlightID )
)


CREATE TABLE TMaintenances
(
	 intMaintenanceID		INTEGER			NOT NULL
	,strWorkCompleted		VARCHAR(8000)	NOT NULL
	,dtmMaintenanceDate		DATETIME		NOT NULL
	,intPlaneID				INTEGER			NOT NULL
	,CONSTRAINT TMaintenances_PK PRIMARY KEY ( intMaintenanceID )
)


CREATE TABLE TPlanes
(
	 intPlaneID				INTEGER			NOT NULL
	,strPlaneNumber			VARCHAR(255)	NOT NULL
	,intPlaneTypeID			INTEGER			NOT NULL
	,CONSTRAINT TPlanes_PK PRIMARY KEY ( intPlaneID )
)


CREATE TABLE TPlaneTypes	
(
	 intPlaneTypeID			INTEGER			NOT NULL
	,strPlaneType			VARCHAR(255)	NOT NULL
	,CONSTRAINT TPlaneTypes_PK PRIMARY KEY ( intPlaneTypeID )
)


CREATE TABLE TPilotRoles	
(
	 intPilotRoleID			INTEGER			NOT NULL
	,strPilotRole			VARCHAR(255)	NOT NULL
	,CONSTRAINT TPilotRoles_PK PRIMARY KEY ( intPilotRoleID )
)


CREATE TABLE TAirports
(
	 intAirportID			INTEGER			NOT NULL
	,strAirportCity			VARCHAR(255)	NOT NULL
	,strAirportCode			VARCHAR(255)	NOT NULL
	,CONSTRAINT TAirports_PK PRIMARY KEY ( intAirportID )
)


CREATE TABLE TPilotFlights
(
	 intPilotFlightID		INTEGER			NOT NULL
	,intPilotID				INTEGER			NOT NULL
	,intFlightID			INTEGER			NOT NULL
	,CONSTRAINT TPilotFlights_PK PRIMARY KEY ( intPilotFlightID )
)


CREATE TABLE TAttendantFlights
(
	 intAttendantFlightID		INTEGER			NOT NULL
	,intAttendantID				INTEGER			NOT NULL
	,intFlightID				INTEGER			NOT NULL
	,CONSTRAINT TAttendantFlights_PK PRIMARY KEY ( intAttendantFlightID )
)


CREATE TABLE TFlightPassengers
(
	 intFlightPassengerID		INTEGER			NOT NULL
	,intFlightID				INTEGER			NOT NULL
	,intPassengerID				INTEGER			NOT NULL
	,strSeat					VARCHAR(255)	NOT NULL
	,monFlightCost				Money			NOT NULL
	,CONSTRAINT TFlightPassengers_PK PRIMARY KEY ( intFlightPassengerID )
)


CREATE TABLE TMaintenanceMaintenanceWorkers
(
	 intMaintenanceMaintenanceWorkerID		INTEGER			NOT NULL
	,intMaintenanceID						INTEGER			NOT NULL
	,intMaintenanceWorkerID					INTEGER			NOT NULL
	,intHours								INTEGER			NOT NULL
	,CONSTRAINT TMaintenanceMaintenanceWorkers_PK PRIMARY KEY ( intMaintenanceMaintenanceWorkerID )
)

-- --------------------------------------------------------------------------------
--	Step #2 : Establish Referential Integrity 
-- --------------------------------------------------------------------------------
--
-- #	Child							Parent						Column
-- -	-----							------						---------
-- 1	TPassengers						TStates						intStateID	
-- 2	TFlightPassenger				TPassengers					intPassengerID
-- 3	TFlights						TPlanes						intPlaneID
-- 4	TFlights						TAirports					intFromAiportID
-- 5	TFlights						TAirports					intToAiportID
-- 6	TPilotFlights					TFlights					intFlightID
-- 7	TAttendantFlights				TFlights					intFlightID
-- 8	TPilotFlights					TPilots						intPilotID
-- 9	TAttendantFlights				TAttendants					intAttendantID
-- 10	TPilots							TPilotRoles					intPilotRoleID
-- 11	TPlanes							TPlaneTypes					intPlaneTypeID
-- 12	TMaintenances					TPlanes						intPlaneID
-- 13	TMaintenanceMaintenanceWorkers	TMaintenance				intMaintenanceID
-- 14	TMaintenanceMaintenanceWorkers	TMaintenanceWorker			intMaintenanceWorkerID
-- 15	TFlightPassenger				TFlights					intFlightID
-- 16	TEmployee						TPilots						intPilotID
-- 17	TEmployee						TAttendants					intAttendantID


--1
ALTER TABLE TPassengers ADD CONSTRAINT TPassengers_TStates_FK 
FOREIGN KEY ( intStateID ) REFERENCES TStates ( intStateID ) on delete CASCADE

--2
ALTER TABLE TFlightPassengers ADD CONSTRAINT TPFlightPassengers_TPassengers_FK  
FOREIGN KEY ( intPassengerID ) REFERENCES TPassengers ( intPassengerID ) on delete CASCADE

--3
ALTER TABLE TFlights	 ADD CONSTRAINT TFlights_TPlanes_FK 
FOREIGN KEY ( intPlaneID ) REFERENCES TPlanes ( intPlaneID ) on delete CASCADE

--4
ALTER TABLE TFlights	 ADD CONSTRAINT TFlights_TFromAirports_FK 
FOREIGN KEY ( intFromAirportID ) REFERENCES TAirports ( intAirportID ) 

--5
ALTER TABLE TFlights	 ADD CONSTRAINT TFlights_TToAirports_FK 
FOREIGN KEY ( intToAirportID ) REFERENCES TAirports ( intAirportID ) 
 
--6
ALTER TABLE TPilotFlights	 ADD CONSTRAINT TPilotFlights_TFlights_FK 
FOREIGN KEY ( intFlightID ) REFERENCES TFlights (intFlightID )  on delete CASCADE

--7
ALTER TABLE TAttendantFlights	 ADD CONSTRAINT TAttendantFlights_TFlights_FK 
FOREIGN KEY ( intFlightID ) REFERENCES TFlights (intFlightID ) on delete CASCADE

--8
ALTER TABLE TPilotFlights	 ADD CONSTRAINT TPilotFlights_TPilots_FK 
FOREIGN KEY ( intPilotID ) REFERENCES TPilots (intPilotID ) on delete CASCADE

--9
ALTER TABLE TAttendantFlights	 ADD CONSTRAINT TAttendantFlights_TAttendants_FK 
FOREIGN KEY ( intAttendantID ) REFERENCES TAttendants (intAttendantID ) on delete CASCADE

--10
ALTER TABLE TPilots	 ADD CONSTRAINT TPilots_TPilotRoles_FK 
FOREIGN KEY ( intPilotRoleID ) REFERENCES TPilotRoles (intPilotRoleID )  on delete CASCADE

--11
ALTER TABLE TPlanes	 ADD CONSTRAINT TPlanes_TPlaneTypes_FK 
FOREIGN KEY ( intPlaneTypeID ) REFERENCES TPlaneTypes (intPlaneTypeID )  on delete CASCADE

--12
ALTER TABLE TMaintenances	 ADD CONSTRAINT TMaintenances_TPlanes_FK 
FOREIGN KEY ( intPlaneID ) REFERENCES TPlanes (intPlaneID )  on delete CASCADE

--13
ALTER TABLE TMaintenanceMaintenanceWorkers	 ADD CONSTRAINT TMaintenanceMaintenanceWorkers_TMaintenances_FK 
FOREIGN KEY ( intMaintenanceID ) REFERENCES TMaintenances (intMaintenanceID ) on delete CASCADE

--14
ALTER TABLE TMaintenanceMaintenanceWorkers	 ADD CONSTRAINT TMaintenanceMaintenanceWorkers_TMaintenanceWorkers_FK 
FOREIGN KEY ( intMaintenanceWorkerID ) REFERENCES TMaintenanceWorkers (intMaintenanceWorkerID ) on delete CASCADE

--15
ALTER TABLE TFlightPassengers	 ADD CONSTRAINT TFlightPassengers_TFlights_FK 
FOREIGN KEY ( intFlightID ) REFERENCES TFlights (intFlightID ) on delete CASCADE

--16
ALTER TABLE TEmployees ADD CONSTRAINT TEmployees_TPilots_FK 
FOREIGN KEY ( intPilotID ) REFERENCES TPilots ( intPilotID ) on delete CASCADE

--17
ALTER TABLE TEmployees ADD CONSTRAINT TEmployees_TAttendants_FK 
FOREIGN KEY ( intAttendantID ) REFERENCES TAttendants ( intAttendantID ) on delete CASCADE


-- --------------------------------------------------------------------------------
--	Step #3 : Add Data - INSERTS
-- --------------------------------------------------------------------------------
INSERT INTO TStates( intStateID, strState)
VALUES				(1, 'Ohio')
				   ,(2, 'Kentucky')
				   ,(3, 'Indiana')



INSERT INTO TPilotRoles( intPilotRoleID, strPilotRole)
VALUES				(1, 'Co-Pilot')
				   ,(2, 'Captain')

				
INSERT INTO TPlaneTypes( intPlaneTypeID, strPlaneType)
VALUES				(1, 'Airbus A350')
				   ,(2, 'Boeing 747-8')
				   ,(3, 'Boeing 767-300F')


INSERT INTO TPlanes( intPlaneID, strPlaneNumber, intPlaneTypeID)
VALUES				(1, '4X887G', 1)
				   ,(2, '5HT78F', 2)
				   ,(3, '5TYY65', 2)
				   ,(4, '4UR522', 1)
				   ,(5, '6OP3PK', 3)
				   ,(6, '67TYHH', 3)


INSERT INTO TAirports( intAirportID, strAirportCity, strAirportCode)
VALUES				(1, 'Cincinnati', 'CVG')
				   ,(2, 'Miami', 'MIA')
				   ,(3, 'Ft. Meyer', 'RSW')
				   ,(4, 'Louisville',  'SDF')
				   ,(5, 'Denver', 'DEN')
				   ,(6, 'Orlando', 'MCO' )


INSERT INTO TPassengers (intPassengerID, strFirstName, strLastName, strAddress, strCity, intStateID, strZip, strPhoneNumber, strEmail, strPassengerLoginID, strPassengerPassword, dtmPassengerDateofBirth)
VALUES				  (1, 'Knelly', 'Nervious', '321 Elm St.', 'Cincinnati', 1, '45201', '5135553333', 'nnelly@gmail.com', 'ree', 'tyu', '12/3/1918')
					 ,(2, 'Orville', 'Waite', '987 Oak St.', 'Cleveland', 1, '45218', '5135556333', 'owright@gmail.com', 'rsfe', 'agyu', '12/3/1945')
					 ,(3, 'Eileen', 'Awnewe', '1569 Windisch Rd.', 'Dayton', 1, '45069', '5135555333', 'eonewe1@yahoo.com', 'ase', 'ett', '12/3/1944')
					 ,(4, 'Bob', 'Eninocean', '44561 Oak Ave.', 'Florence', 2, '45246', '8596663333', 'bobenocean@gmail.com', 'raf', 'vvv', '12/3/1918')
					 ,(5, 'Ware', 'Hyjeked', '44881 Pine Ave.', 'Aurora', 3, '45546', '2825553333', 'Hyjekedohmy@gmail.com', 'rsd', 'tbbu', '12/3/1941')
					 ,(6, 'Kay', 'Oss', '4484 Bushfield Ave.', 'Lawrenceburg', 3, '45546', '2825553333', 'wehavekayoss@gmail.com', 'reea', 'tyvvu', '12/3/1976')


INSERT INTO TPilots (intPilotID, strFirstName, strLastName, strEmployeeID, dtmDateofHire, dtmDateofTermination, dtmDateofLicense, intPilotRoleID)
VALUES				  (1, 'Tip', 'Seenow', '12121', '1/1/2015', '1/1/2099', '12/1/2014', 1)
					 ,(2, 'Ima', 'Soring', '13322', '1/1/2016', '1/1/2099', '12/1/2015', 1)
					 ,(3, 'Hugh', 'Encharge', '16666', '1/1/2017', '1/1/2099', '12/1/2016', 2)
					 ,(4, 'Iwanna', 'Knapp', '17676', '1/1/2014', '1/1/2015', '12/1/2013', 1)
					 ,(5, 'Rose', 'Ennair', '19909', '1/1/2012', '1/1/2099', '12/1/2011', 2)
					 ,(6, 'SAFA', 'Ennair', '19909', '1/1/2012', '1/1/2099', '12/1/2011', 2)


INSERT INTO TAttendants (intAttendantID, strFirstName, strLastName, strEmployeeID, dtmDateofHire, dtmDateofTermination)
VALUES				  (1, 'Miller', 'Tyme', '22121', '1/1/2015', '1/1/2099')
					 ,(2, 'Sherley', 'Ujest', '23322', '1/1/2016', '1/1/2099')
					 ,(3, 'Buhh', 'Biy', '26666', '1/1/2017', '1/1/2099')
					 ,(4, 'Myles', 'Amanie', '27676', '1/1/2014', '1/1/2015')
					 ,(5, 'Walker', 'Toexet', '29909', '1/1/2012', '1/1/2099')

INSERT INTO TEmployees (intEmployeeID, strEmployeeLoginID, strEmployeePassword, strEmployeeRole, intPilotID, intAttendantID)
Values					(1, 'eee', 'ee', 'Pilot', 1, null)
					   ,(2, 'butter', 'fingers', 'Attendant', null, 1)
					   ,(3, 'top', 'dog', 'Admin', null, null)

INSERT INTO TMaintenanceWorkers (intMaintenanceWorkerID, strFirstName, strLastName, strEmployeeID, dtmDateofHire, dtmDateofTermination, dtmDateOfCertification)
VALUES				  (1, 'Gressy', 'Nuckles', '32121', '1/1/2015', '1/1/2099', '12/1/2014')
					 ,(2, 'Bolt', 'Izamiss', '33322', '1/1/2016', '1/1/2099', '12/1/2015')
					 ,(3, 'Sharon', 'Urphood', '36666', '1/1/2017', '1/1/2099','12/1/2016')
					 ,(4, 'Ides', 'Racrozed', '37676', '1/1/2014', '1/1/2015','12/1/2013')
					

INSERT INTO TMaintenances (intMaintenanceID, strWorkCompleted, dtmMaintenanceDate, intPlaneID)
VALUES				  (1, 'Fixed Wing', '1/1/2022', 1)
					 ,(2, 'Repaired Flat Tire', '3/1/2022', 2)
					 ,(3, 'Added Wiper Fluid', '4/1/2022', 3)
					 ,(4, 'Tightened Engine to Wing', '5/1/2022', 2)
					 ,(5, '100,000 mile checkup', '3/10/2022', 4)
					 ,(6, 'Replaced Loose Door', '4/10/2022', 6)
					 ,(7, 'Trapped Raccoon in Cargo Hold', '5/1/2022', 6)


INSERT INTO TFlights (intFlightID, dtmFlightDate, strFlightNumber,  dtmTimeofDeparture, dtmTimeOfLanding, intFromAirportID, intToAirportID, intMilesFlown, intPlaneID)
VALUES				  (1, '4/1/2022', '111', '10:00:00', '12:00:00', 1, 2, 1200, 2)
					 ,(2, '4/4/2022', '222','13:00:00', '15:00:00', 1, 3, 1000, 2)
					 ,(3, '4/5/2022', '333','15:00:00', '17:00:00', 1, 5, 1200, 3)
					 ,(4, '4/16/2022','444', '10:00:00', '12:00:00', 4, 6, 1100, 3)
					 ,(5, '3/14/2022','555', '18:00:00', '20:00:00', 2, 1, 1200, 3)
					 ,(6, '3/21/2022','666', '19:00:00', '21:00:00', 3, 1, 1000, 1)
					 ,(7, '3/11/2022', '777','20:00:00', '22:00:00', 3, 6, 1400, 4)
					 ,(8, '3/17/2022', '888','09:00:00', '11:00:00', 6, 4, 1100, 5)
					 ,(9, '4/19/2022', '999','08:00:00', '10:00:00', 4, 2, 1000, 6)
					 ,(10, '6/22/2024', '091','10:00:00', '12:00:00', 2, 1, 1200, 2)
					 ,(11, '7/14/2023','555', '18:00:00', '20:00:00', 2, 1, 1200, 3)
					 ,(12, '2/21/2023','666', '19:00:00', '21:00:00', 3, 1, 1000, 2)
					 ,(13, '4/11/2025', '777','20:00:00', '22:00:00', 3, 6, 1400, 3)
					 ,(14, '6/17/2023', '888','09:00:00', '11:00:00', 6, 4, 1100, 4)
					 ,(15, '5/19/2023', '999','08:00:00', '10:00:00', 4, 2, 1000, 2)
					 ,(16, '6/22/2025', '091','10:00:00', '12:00:00', 2, 1, 1200, 6)


INSERT INTO TPilotFlights ( intPilotFlightID, intPilotID, intFlightID)
VALUES				 ( 1, 1, 2 )
					,( 2, 1, 3 )
					,( 3, 3, 3 )
					,( 4, 3, 2 )
					,( 5, 5, 1 )
					,( 6, 2, 1 )
					,( 7, 3, 4 )
					,( 8, 2, 4 )
					,( 9, 2, 5 )
					,( 10, 3, 5 )
					,( 11, 5, 6 )
					,( 12, 1, 6 )


INSERT INTO TAttendantFlights ( intAttendantFlightID, intAttendantID, intFlightID)
VALUES				( 1, 1, 2 )
					,( 2, 2, 3 )
					,( 3, 3, 3 )
					,( 4, 4, 2 )
					,( 5, 5, 1 )
					,( 6, 1, 1 )
					,( 7, 2, 4 )
					,( 8, 3, 4 )
					,( 9, 4, 5 )
					,( 10, 5, 5 )
					,( 11, 5, 6 )
					,( 12, 1, 6 )
					

INSERT INTO TFlightPassengers ( intFlightPassengerID, intFlightID, intPassengerID, strSeat, monFlightCost)
VALUES				 ( 1, 1, 1, '1A', 12.99)
					,( 2, 1, 2, '2A', 12.99 )
					,( 3, 1, 3, '1B', 12.99 )
					,( 4, 1, 4, '1C' , 12.99)
					,( 5, 1, 5, '1D', 12.99 )
					,( 6, 2, 5, '1A', 12.99 )
					,( 7, 2, 4, '2A' , 12.99)
					,( 8, 2, 3, '1B', 12.99 )
					,( 9, 3, 1, '1B' , 12.99)
					,( 10, 3, 2, '2A', 12.99 )
					,( 11, 3, 3, '1B', 12.99 )
					,( 12, 3, 4, '1C' , 12.99)
					,( 13, 3, 5, '1D', 12.99 )
					,( 14, 4, 2, '1A', 12.99 )
					,( 15, 4, 3, '1B' , 12.99)
					,( 16, 4, 4, '1C' , 12.99)
					,( 17, 4, 5, '1D', 12.99 )
					,( 18, 5, 1, '1A', 12.99 )
					,( 19, 5, 2, '2A', 12.99 )
					,( 20, 5, 3, '1B' , 12.99)
					,( 21, 5, 4, '2B' , 12.99)
					,( 22, 6, 1, '1A', 12.99)
					,( 23, 6, 2, '2A' , 12.99)
					,( 24, 10, 3, '3A', 12.99)
					,( 25, 10, 3, '1B' , 12.99)
					,( 26, 10, 4, '2B' , 12.99)
					,( 27, 10, 1, '1A', 12.99)
					,( 28, 10, 2, '2A' , 12.99)
					,( 29, 10, 3, '3A', 12.99)
					,( 30, 10, 1, '1A', 12.99)
					,( 31, 10, 2, '2A' , 12.99)
					,( 32, 10, 3, '3A', 12.99)
					,( 33, 11, 1, '3A', 12.99)
					,( 34, 11, 2, '2A' , 12.99)
					,( 35, 11, 3, '3A', 12.99)
				
					

INSERT INTO TMaintenanceMaintenanceWorkers ( intMaintenanceMaintenanceWorkerID, intMaintenanceID, intMaintenanceWorkerID, intHours)
VALUES				 ( 1, 2, 1, 2 )
					,( 2, 4, 1, 3 )
					,( 3, 2, 3, 4 )
					,( 4, 1, 4, 2 )
					,( 5, 3, 4, 2 )
					,( 6, 4, 3, 5 )
					,( 7, 5, 1, 7 )
					,( 8, 6, 1, 2 )
					,( 9, 7, 3, 4 )
					,( 10, 4, 4, 1 )
					,( 11, 3, 3, 4 )
					,( 12, 7, 3, 8 )


--SELECT intFlightID, dtmFlightDate 
--FROM TFlights 
--Where dtmFlightDate > GETDATE()


--SELECT TP.*, TF.*

--FROM TPassengers as TP join TFlightPassengers as TFP on TP.intPassengerID = TFP.intPassengerID
--	join TFlights as TF on TF.intFlightID = TFP.intFlightID
--	join TPlanes as TPL on TPL.intPlaneID = TF.intPlaneID
--	join TAirports as TA on TA.intAirportID = TF.intToAirportID

--WHERE dtmFlightDate < GETDATE()
--and
--TP.intPassengerID = 4


--SELECT Sum(TF.intMilesFlown) as Miles_Flown

--FROM TPassengers as TP join TFlightPassengers as TFP on TP.intPassengerID = TFP.intPassengerID
--	join TFlights as TF on TF.intFlightID = TFP.intFlightID
--	join TPlanes as TPL on TPL.intPlaneID = TF.intPlaneID
--	join TAirports as TA on TA.intAirportID = TF.intToAirportID

--WHERE dtmFlightDate < GETDATE()
--and
--TP.intPassengerID = 4


--Select count(TPassengers.intPassengerID) as Total_Customers

--From TPassengers


--Select count(TFP.intFlightPassengerID) as Total_FLights_By_Customers

--From TFlightPassengers as TFP


--Select AVG(TF.intMilesFlown) as Total_AVG_Miles_Flown

--From TFlights as TF


--select TP.strFirstName + ' ' + TP.strLastName as Name, sum(isnull(TF.intMilesFlown,0)) as Total_Miles_Flown_Pilots

--from TPilots as TP  left join TPilotFlights as TPF on TP.intPilotID = TPF.intPilotID
--	left join TFlights as TF on TF.intFlightID = TPF.intFlightID

--Group by TP.strFirstName, TP.strLastName



--select TA.strFirstName + ' ' + TA.strLastName as Name, sum(isnull(TF.intMilesFlown,0)) as Total_Miles_Flown_Attendents

--from TAttendants as TA  left join TAttendantFlights as TAF on TA.intAttendantID = TAF.intAttendantID
--	left join TFlights as TF on TF.intFlightID = TAF.intFlightID

--Group by TA.strFirstName, TA.strLastName



--SELECT strFirstName, strLastName, strEmployeeID, dtmDateOfHire, dtmDateOfLicense, dtmDateOfTermination, TPR.strPilotRole
--FROM TPilots as TP join TPilotRoles as TPR on TPR.intPilotRoleID = TP.intPilotRoleID


--SELECT TP.strFirstName + ' ' + TP.strLastName as FullName,TF.*,TAR.strAirportCity as FromAirport,TA.strAirportCity as ToAirport, TF.intMilesFlown, TPL.strPlaneNumber, TF.strFlightNumber
--From TPilots as TP join TPilotFlights as TPF on TP.intPilotID = TPF.intPilotID
--	join TFlights as TF on TF.intFlightID = TPF.intFlightID
--	join TAirports as TA on TA.intAirportID = TF.intToAirportID
--	join TAirports as TAR on TAR.intAirportID = TF.intFromAirportID
--	join TPlanes as TPL on TPL.intPlaneID = TF.intPlaneID

--WHERE dtmFlightDate < GETDATE() strPassengerPassword



CREATE PROCEDURE uspTotalNumberofPassengers
	 @intFlightID as Integer
AS
SET XACT_ABORT ON --terminate and rollback if any errors
BEGIN TRANSACTION
  
    Select COUNT(TFP.intPassengerID) as Passengers

	From TFlights as TF join TFlightPassengers as TFP on TF.intFlightID = TFP.intFlightID
	join TPassengers as TP on TP.intPassengerID = TFP.intPassengerID

	WHERE  TFP.intFlightID = @intFlightID

COMMIT TRANSACTION
GO


CREATE PROCEDURE uspTypeofPlane
	 @intFlightID as Integer
AS
SET XACT_ABORT ON --terminate and rollback if any errors
BEGIN TRANSACTION
  
    Select DISTINCT  TPT.strPlaneType

	From TFlights as TF join TFlightPassengers as TFP on TF.intFlightID = TFP.intFlightID
	join TPassengers as TP on TP.intPassengerID = TFP.intPassengerID
	join TPlanes as TPL on TPL.intPlaneID = TF.intPlaneID
	join TPlaneTypes as TPT on TPT.intPlaneTypeID = TPL.intPlaneTypeID

	WHERE  TFP.intFlightID = 10 and TP.intPassengerID = 1

COMMIT TRANSACTION
GO


CREATE PROCEDURE uspToAirportCode
	 @intFlightID as Integer
AS
SET XACT_ABORT ON --terminate and rollback if any errors
BEGIN TRANSACTION
  
    Select DISTINCT TA.strAirportCode

	From TFlights as TF join TFlightPassengers as TFP on TF.intFlightID = TFP.intFlightID
	join TPassengers as TP on TP.intPassengerID = TFP.intPassengerID
	join TAirports as TA on TA.intAirportID = TF.intToAirportID

	WHERE  TFP.intFlightID = @intFlightID

COMMIT TRANSACTION
GO


CREATE PROCEDURE uspPassengerAge
	 @intFlightID as Integer
	,@intPassengerID as integer
AS
SET XACT_ABORT ON --terminate and rollback if any errors
BEGIN TRANSACTION
  
    Select DISTINCT (CONVERT(int, CONVERT(varchar, GETDATE(), 112)) - CONVERT(int, CONVERT(varchar, TP.dtmPassengerDateofBirth, 112)))/10000 AS PassengerAge

	From TFlights as TF join TFlightPassengers as TFP on TF.intFlightID = TFP.intFlightID
	join TPassengers as TP on TP.intPassengerID = TFP.intPassengerID

	WHERE  TFP.intFlightID = @intFlightID and TFP.intPassengerID = @intPassengerID


COMMIT TRANSACTION
GO


CREATE PROCEDURE uspNumberofFlights
	@intPassengerID as integer
AS
SET XACT_ABORT ON --terminate and rollback if any errors
BEGIN TRANSACTION
  
    Select DISTINCT count(TFP.intFlightID) as number_of_flights

	From TFlights as TF join TFlightPassengers as TFP on TF.intFlightID = TFP.intFlightID
	join TPassengers as TP on TP.intPassengerID = TFP.intPassengerID

	WHERE TFP.intPassengerID = @intPassengerID and dtmFlightDate < GETDATE()


COMMIT TRANSACTION
GO



select count(TFP.intFlightID) as number_of_flights

from TFlights as TF join TFlightPassengers as TFP on TF.intFlightID = TFP.intFlightID
join TPassengers as TP on TP.intPassengerID = TFP.intPassengerID


where TFP.intPassengerID = 1
and
dtmFlightDate < GETDATE()





CREATE PROCEDURE uspTotalMilesofFlight
	 @intFlightID as Integer
AS
SET XACT_ABORT ON --terminate and rollback if any errors
BEGIN TRANSACTION
  
    Select intMilesFlown

	From TFlights

	WHERE  intFlightID = @intFlightID

COMMIT TRANSACTION
GO





create procedure EmployeeLogin(
	@strEmployeeID as varchar(300)
)
as
Begin
	SELECT strEmployeeLoginID

	FROM TEmployees

	WHERE strEmployeeLoginID = @strEmployeeID
end
----------------------------------------------------------------------------
create procedure EmployeePasswprdLogin(
	@strEmployeePassword as varchar(300)
)
as
Begin
	SELECT strEmployeePassword

	FROM TEmployees

	WHERE strEmployeePassword = @strEmployeePassword
end

------------------------------------------------------------------
create procedure EmployeeID(
	@strEmployeeID as varchar(300)
	,@strEmployeePassword as varchar(300)
)
as
Begin
	SELECT strEmployeeRole
	
	FROM TEmployees

	WHERE strEmployeeLoginID = @strEmployeeID
	and
	strEmployeePassword = @strEmployeePassword
end


create procedure PilotEmployeeID(
	@strEmployeeID as varchar(300)
	,@strEmployeePassword as varchar(300)
)
as
Begin
	SELECT intPilotID
	
	FROM TEmployees

	WHERE strEmployeeLoginID = @strEmployeeID
	and
	strEmployeePassword = @strEmployeePassword
end


create procedure AttendentEmployeeID(
	@strEmployeeID as varchar(300)
	,@strEmployeePassword as varchar(300)
)
as
Begin
	SELECT intAttendantID
	
	FROM TEmployees

	WHERE strEmployeeLoginID = @strEmployeeID
	and
	strEmployeePassword = @strEmployeePassword
end


create procedure CustomerID(
	@strPassengerLoginID as varchar(300)
	,@strPassengerPassword as varchar(300)
)
as
Begin
	SELECT intPassengerID
	
	FROM TPassengers

	WHERE strPassengerLoginID = @strPassengerLoginID
	and
	strPassengerPassword = @strPassengerPassword
end


create procedure CustomerLogin(
	@strPassengerLoginID as varchar(300)
)
as
Begin
	SELECT strPassengerLoginID

	FROM TPassengers

	WHERE strPassengerLoginID = @strPassengerLoginID
end

create procedure CustomerLoginPAssword(
	@strPassengerPassword as varchar(300)
)
as
Begin
	SELECT strPassengerLoginID, intPassengerID

	FROM TPassengers

	WHERE strPassengerPassword = @strPassengerPassword
end

create procedure AllPastFlightsPilot(
	@pilot_id as Integer
)

as
Begin
	SELECT TP.*, TF.*, TA.strAirportCity as ToAirport, TAR.strAirportCity as FromAirport, TPL.strPlaneNumber

	FROM TPilots as TP join TPilotFlights as TPF on TP.intPilotID = TPF.intPilotID

	join TFlights as TF on TF.intFlightID = TPF.intFlightID
	join TPlanes as TPL on TPL.intPlaneID = TF.intPlaneID
	join TAirports as TA on TA.intAirportID = TF.intToAirportID
	join TAirports as TAR on TAR.intAirportID = TF.intFromAirportID

	WHERE dtmFlightDate < GETDATE()
	and

	TP.intPilotID = @pilot_id
end

create procedure TotalMilesFlownPilot(
	@pilot_id as Integer
)

as
Begin
	SELECT Sum(TF.intMilesFlown) as Miles_Flown

	FROM TPilots as TP join TPilotFlights as TPF on TP.intPilotID = TPF.intPilotID

	join TFlights as TF on TF.intFlightID = TPF.intFlightID

	WHERE dtmFlightDate < GETDATE()
	and
	TP.intPilotID = @pilot_id
end




create procedure PastFlightDataCustomer(
	@customer_id as Integer
)

as
Begin
	SELECT TP.*, TF.*,TA.strAirportCity as ToAirport, TAR.strAirportCity as FromAirport, TPL.strPlaneNumber

	FROM TPassengers as TP join TFlightPassengers as TFP on TP.intPassengerID = TFP.intPassengerID
	join TFlights as TF on TF.intFlightID = TFP.intFlightID
	join TPlanes as TPL on TPL.intPlaneID = TF.intPlaneID
	join TAirports as TA on TA.intAirportID = TF.intToAirportID
	join TAirports as TAR on TAR.intAirportID = TF.intFromAirportID

	WHERE dtmFlightDate < GETDATE()
	and
	TP.intPassengerID = @customer_id
End


create procedure TotalPastFlightMilesCustomer(
	@customer_id as Integer
)

as
Begin
	SELECT Sum(TF.intMilesFlown) as Miles_Flown

	FROM TPassengers as TP join TFlightPassengers as TFP on TP.intPassengerID = TFP.intPassengerID

	join TFlights as TF on TF.intFlightID = TFP.intFlightID
	join TPlanes as TPL on TPL.intPlaneID = TF.intPlaneID
	join TAirports as TA on TA.intAirportID = TF.intToAirportID

	WHERE dtmFlightDate < GETDATE() 
	and
	TP.intPassengerID = @customer_id
end


create procedure avgMilesFlownPilots
as
Begin
	Select TP.strFirstName + ' ' + TP.strLastName as Name, sum(isnull(TF.intMilesFlown,0)) as Total_Miles_Flown_Pilots

	From TPilots as TP  left join TPilotFlights as TPF on TP.intPilotID = TPF.intPilotID

	left join TFlights as TF on TF.intFlightID = TPF.intFlightID

	Group by TP.strFirstName, TP.strLastName
End



create procedure avgMilesFlownAttendents
as
Begin
	Select TA.strFirstName + ' ' + TA.strLastName as Name, sum(isnull(TF.intMilesFlown,0)) as Total_Miles_Flown_Attendents

	From TAttendants as TA  left join TAttendantFlights as TAF on TA.intAttendantID = TAF.intAttendantID

	left join TFlights as TF on TF.intFlightID = TAF.intFlightID

	Group by TA.strFirstName, TA.strLastName
End



create procedure avgMilesFlownbyCustomers
as
Begin
	SELECT AVG(TF.intMilesFlown) as Total_AVG_Miles_Flown
	From TFlights as TF
End



create procedure TotalMilesFlownCustomers
as
Begin
	SELECT count(TFP.intFlightPassengerID) as Total_FLights_By_Customers
	From TFlightPassengers as TFP
End



create procedure TotalCustomers
as
Begin
	SELECT count(TPassengers.intPassengerID) as Total_Customers
	From TPassengers
end



CREATE PROCEDURE uspAddEmployeePilot
		@intEmployeeID			AS INTEGER OUTPUT
	   ,@strEmployeeLoginID		AS VARCHAR(255)
	   ,@strEmployeePassword	AS VARCHAR(255)
	   ,@strEmployeeRole		AS VARCHAR(255)
	   ,@intPilotID				AS Integer
	   

AS
SET XACT_ABORT ON --terminate and rollback if any errors
BEGIN TRANSACTION
    SELECT @intEmployeeID = MAX(intEmployeeID) + 1 
    FROM TEmployees (TABLOCKX) -- lock table until end of transaction
	 -- default to 1 if table is empty
    SELECT intEmployeeID = COALESCE(@intEmployeeID, 1)
	INSERT INTO TEmployees (intEmployeeID, strEmployeeLoginID, strEmployeePassword, strEmployeeRole, intPilotID)
	VALUES (@intEmployeeID, @strEmployeeLoginID, @strEmployeePassword, @strEmployeeRole, @intPilotID)

COMMIT TRANSACTION
GO


CREATE PROCEDURE AddAttendantEmployee
		@intEmployeeID			AS INTEGER OUTPUT
	   ,@strEmployeeLoginID		AS VARCHAR(255)
	   ,@strEmployeePassword	AS VARCHAR(255)
	   ,@strEmployeeRole		AS VARCHAR(255)
	   ,@intAttendantID			AS Integer
	   

AS
SET XACT_ABORT ON --terminate and rollback if any errors
BEGIN TRANSACTION
    SELECT @intEmployeeID = MAX(intEmployeeID) + 1 
    FROM TEmployees (TABLOCKX) -- lock table until end of transaction
	 -- default to 1 if table is empty
    SELECT intEmployeeID = COALESCE(@intEmployeeID, 1)
	INSERT INTO TEmployees (intEmployeeID, strEmployeeLoginID, strEmployeePassword, strEmployeeRole, intAttendantID)
	VALUES (@intEmployeeID, @strEmployeeLoginID, @strEmployeePassword, @strEmployeeRole, @intAttendantID)

COMMIT TRANSACTION
GO


CREATE PROCEDURE uspAddCustomer
     @intPassengerID				AS INTEGER OUTPUT
    ,@strFirstName				AS VARCHAR(255)
    ,@strLastName				AS VARCHAR(255)
    ,@strAddress				AS VARCHAR(255)
    ,@strCity					AS VARCHAR(255) 
    ,@intState					AS INTEGER 
    ,@strZip					AS VARCHAR(255)
    ,@strPhoneNumber			AS VARCHAR(255)
    ,@strEmail					AS VARCHAR(255)
	,@strPassengerLoginID		AS VARCHAR(255)
	,@strPassengerPassword		AS VARCHAR(255)
       
AS
SET XACT_ABORT ON --terminate and rollback if any errors
BEGIN TRANSACTION
    SELECT @intPassengerID = MAX(intPassengerID) + 1 
    FROM TPassengers (TABLOCKX) -- lock table until end of transaction
    -- default to 1 if table is empty
    SELECT @intPassengerID = COALESCE(@intPassengerID, 1)
    INSERT INTO TPassengers (intPassengerID, strFirstName, strLastName, strAddress, strCity, intStateID, strZip, strPhoneNumber, strEmail,strPassengerLoginID, strPassengerPassword)
    VALUES (@intPassengerID, @strFirstName, @strLastName, @strAddress, @strCity, @intState, @strZip, @strPhoneNumber, @strEmail, @strPassengerLoginID, @strPassengerPassword)

COMMIT TRANSACTION
GO

CREATE PROCEDURE uspAddFutureFlight
     @intFlightID				AS INTEGER OUTPUT
    ,@dtmFlightDate				as date
    ,@strFlightNumber			AS VARCHAR(255)
    ,@dtmTimeofDeparture		as TIME
    ,@dtmTimeOfLanding			as TIME 
    ,@intFromAirportID			AS INTEGER 
    ,@intToAirportID			as integer
    ,@intMilesFlown				as integer
    ,@intPlaneID				as integer
	
       
AS
SET XACT_ABORT ON --terminate and rollback if any errors
BEGIN TRANSACTION
    SELECT @intFlightID = MAX(intFlightID) + 1 
    FROM TFlights (TABLOCKX) -- lock table until end of transaction
    -- default to 1 if table is empty
    SELECT @intFlightID = COALESCE(@intFlightID, 1)
    INSERT INTO TFlights (intFlightID, dtmFlightDate, strFlightNumber,  dtmTimeofDeparture, dtmTimeOfLanding, intFromAirportID, intToAirportID, intMilesFlown, intPlaneID)
    VALUES (@intFlightID, @dtmFlightDate, @strFlightNumber, @dtmTimeofDeparture, @dtmTimeOfLanding, @intFromAirportID, @intToAirportID, @intMilesFlown, @intPlaneID)

COMMIT TRANSACTION
GO


CREATE PROCEDURE uspUpdateEmployeeLogin_Password
     @strEmployeeID as varchar(300)
	,@strEmployeePassword as varchar(300)
	,@intPilotID as Integer
AS
SET XACT_ABORT ON --terminate and rollback if any errors
BEGIN TRANSACTION
  
    Update  TEmployees 
			SET strEmployeeLoginID =	@strEmployeeID, 
			    strEmployeePassword =	@strEmployeePassword				
			
	WHERE  intPilotID = @intPilotID

COMMIT TRANSACTION
GO

CREATE PROCEDURE uspUpdateEmployeeLogin_Password_Attendent
     @strEmployeeID as varchar(300)
	,@strEmployeePassword as varchar(300)
	,@intAttendantID as Integer
AS
SET XACT_ABORT ON --terminate and rollback if any errors
BEGIN TRANSACTION
  
    Update  TEmployees 
			SET strEmployeeLoginID =	@strEmployeeID, 
			    strEmployeePassword =	@strEmployeePassword				
			
	WHERE  intAttendantID = @intAttendantID

COMMIT TRANSACTION
GO



CREATE PROCEDURE uspUpdateCustomer
     @intPassengerID				AS INTEGER OUTPUT
    ,@strFirstName				AS VARCHAR(255)
    ,@strLastName				AS VARCHAR(255)
    ,@strAddress				AS VARCHAR(255)
    ,@strCity					AS VARCHAR(255) 
    ,@intState					AS INTEGER 
    ,@strZip					AS VARCHAR(255)
    ,@strPhoneNumber			AS VARCHAR(255)
    ,@strEmail					AS VARCHAR(255)
	,@strPassengerLoginID		AS VARCHAR(255)
	,@strPassengerPassword		AS VARCHAR(255)
       
AS
SET XACT_ABORT ON --terminate and rollback if any errors
BEGIN TRANSACTION
  
    Update  TPassengers 
			SET strFirstName =	@strFirstName, 
			    strLastName =	@strLastName,
				strAddress =	@strAddress, 
				strCity =		@strCity, 
				intStateID =	@intState,
				strZip =		@strZip,
				strPhoneNumber = @strPhoneNumber,
				strEmail =		@strEmail,
				strPassengerLoginID = @strPassengerLoginID,
				strPassengerPassword = @strPassengerPassword
	

				
			
	WHERE  intPassengerID = @intPassengerID
COMMIT TRANSACTION
GO



CREATE PROCEDURE uspDeleteCustomer
     @intPilotID	AS INTEGER
    
       
AS
SET XACT_ABORT ON --terminate and rollback if any errors
BEGIN TRANSACTION
  
    Delete  FROM TPilots 
	WHERE  intPilotID = @intPilotID

COMMIT TRANSACTION
GO

EXECUTE uspDeleteCustomer 6



--SELECT 
--   OBJECT_NAME(f.parent_object_id) AS 'Table name',
--   COL_NAME(fc.parent_object_id,fc.parent_column_id) AS 'Field name',
--   delete_referential_action_desc AS 'On Delete'
--FROM sys.foreign_keys AS f,
--     sys.foreign_key_columns AS fc,
--     sys.tables t 
--WHERE f.OBJECT_ID = fc.constraint_object_id
--AND t.OBJECT_ID = fc.referenced_object_id
--ORDER BY 1