create database CaseStudy


----------------------------------------------------------------------------------------------------
Create table UserType1(
UserType int,
UserDescription Varchar(max)
constraint pk_UserType primary key(UserType)
);

insert into UserType1(UserType, UserDescription)
Values(1, 'Admin'),
(2, 'Manager'),(3, 'Customer')
select * From UserType1
___________________________________________________________________________________________________________________________
Create table UsersRegistrationDetails(
UserID int,
Username varchar(20),
UserPassword varchar(10),
UserType int foreign key references UserType1,
MobileNumber varchar(10),
Gender char,
Age int,
UserAddress varchar(max)
constraint pk_UserID primary key(UserID)
);

Insert into UsersRegistrationDetails(UserID, Username, UserPassword, UserType, MobileNumber, Gender,Age, UserAddress)
Values(101, 'Ram', 'abcd', 1, '8919569197', 'm', 23, 'visakhapatnam'),
(102, 'Haritha', 'abcde', 2, '7890345673', 'F', 22, 'Vizianagaram'),
(103, 'sirisha', 'abcdef', 3, '8945634567', 'F', 24, 'East Godavari')
Insert into UsersRegistrationDetails values(104, 'sai', 'abc', 3, '7648921348', 'm', 27,  'Hyderabad')
Insert into UsersRegistrationDetails values(105, 'kumar', 'bcd', 3, '9955774466', 'm', 25,  'Hyderabad')














---------------------------------------------------------------------------------------------------------------
create table PolicyDetails(
PolicyID INT ,
PolicyName varchar(max),
MaturityYears int Default 15,
UserID int foreign key references UsersRegistrationDetails,
constraint pk_PolicyID Primary Key(PolicyID));

insert into PolicyDetails(PolicyID, PolicyName,UserID)
Values(201, 'Accidents Life Insurance Policy',102 )

-------------------------------------------------------------------------------------------------------------
 create table PolicyCoverage(
 PolicyID int Foreign key references PoliCyDetails,
 PolicyDuration int,
 PolicyAmount float,
 PolicyCoverageAmount float,
 Srlno int  primary key  identity(10,1));

 insert into PolicyCoverage(PolicyID, PolicyDuration, PolicyAmount, PolicyCoverageAmount)
 values(201, 5,500000,1000000),
 (201,3,400000,1000000),
  (201,6,700000,1500000),
   (201,4,600000,1500000)


------------------------------------------------------------------------------------------------------------
Create table InjuryType(
PolicyID int foreign key references PolicyDetails ,
InjuryName varchar(30),
InjuryID int,
InjuryDescription varchar(max),
ReimbursePercent int not null,
Constraint pk_InjuryID primary key(InjuryID) 
);


Insert Into InjuryType(PolicyID,InjuryName,InjuryID,InjuryDescription,ReimbursePercent) 
Values(201,'Death',1,'Death',100),
(201,'Blindness',2,'Blindness – one eye',40),
(201,'Blindness',3,'Blindness – both eyes',90),
(201,'Amputation',4,'Amputation of one limb or One upper and lower limbs',50),
(201,'Amputation',5,'Amputation of two limb or Both upper and lower limbs',95),
(201,'Injuries',6,'Injuries requiring hospitalisation',35),
(201,'non-hospitalisation',7,'Injuries not requiring hospitalisation',15)

select * from InjuryType
----------------------------------------------------------------------------------------------------------------
create table CustomerPolicyDetails(
PolicyID int foreign key references PolicyDetails,
UserID int foreign key references UsersRegistrationDetails,
RegisterdDate Date,
Duration int,
PolicyAmount float,
PolicyTerm varchar(10),
UserNoTerms int,
PremiumAmount Float,
NomineeName varchar(50),
NomineeRelation varchar(15),
ManagerID int,
RegisteredID int,
Constraint pk_RegisteredID primary key(RegisteredID));

-----------------------------------------------------------------------------------------------------------------
create table PolicyClaim(
RegisteredID int foreign key references CustomerPolicyDetails,
ApplicantName varchar(20),
SubmitionDate date,
DateOfInjury date,
InjuryID int foreign key references InjuryType,
NomineeName varchar(50),
NomineeRelation varchar(15),
ReimburseAmount float,
ApprovedOrRejected varchar(10),
ApprovedOrrejectedBy varchar(10),
UserId int  Primary Key);

select * from PolicyClaim


----------------------------------------------------------------------------------------------------------------

create table PremiumPayment(
RegistredID int foreign key references CustomerPolicyDetails,
PayAmount float,
PayType varchar(10),
DateOfPayment date,
ReceiptNumber Int Primary key 
);



Create view Vw_customerpolicydetails 
As 
select *,(select username from UsersRegistrationDetails users where users.UserID=cus.UserID)
As Username,  
(select username from UsersRegistrationDetails users where users.UserID=cus.ManagerID)As Managername,  
(select PolicyName from PolicyDetails p where p.PolicyID=cus.PolicyID) As Policyname from customerpolicydetails cus



CREATE view vw_PolicyDetails    
As    
select P1.PolicyID,PolicyName,MaturityYears,P1.UserID As ManagerID,PolicyDuration,PolicyAmount,PolicyCoverageAmount,  
us.Username as ManagerName from PolicyDetails P1    
Join PolicyCoverage P2 on P1.PolicyID=P2.PolicyID  
join UsersRegistrationDetails us on p1.UserID=us.UserID


Create view vw_Policy   
As    
select PolicyID,PolicyName,MaturityYears,(Select UserName from UsersRegistrationDetails us where us.UserId=UserID) As ManagerName  
from PolicyDetails


create view Vw_PolicyClaim
As
select PC.RegisteredID,PC.ApplicantName,PC.SubmitionDate,PC.DateOfInjury,PC.InjuryID,PC.NomineeName,
CP.PolicyAmount,CP.PremiumAmount,
PC.ReimburseAmount,PC.UserId,CP.ManagerID,IT.InjuryDescription,IT.ReimbursePercent,PC.ApprovedOrRejected from PolicyClaim PC
join vw_customerpolicydetails CP on PC.UserId=CP.UserID
join InjuryType IT on PC.InjuryID=IT.InjuryID

