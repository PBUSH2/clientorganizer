	drop table contact_cases;
	drop table cases;
	drop table contact;
	
	drop database caseorganizer;
	create database caseorganizer;
begin transaction;
	create table cases
(
	case_id			int				Identity(1,1),
	case_number		int				not null,


	constraint pk_case_id	Primary Key(case_id),
	
);

create table contact 
(
	contact_id		int				Identity(1,1),
	first_name		varchar(64)		not null,
	last_name		varchar(64)		not null,
	birth_date		date			not null,
	case_id			int				null,


	constraint pk_contact	Primary Key(contact_id),
	constraint fk_case_id	Foreign Key(case_id) references cases(case_id)
	
	);

create table contact_cases
(
	contact_id		int				not null,
	case_id			int				not null,

	constraint pk_contact_cases		Primary Key(contact_id, case_id),
	constraint fk_contact_cases_contact_id		Foreign Key(contact_id) references contact(contact_id),
	constraint fk_contact_cases_case_id			Foreign Key(case_id) references cases(case_id)
	
	);	

	commit transaction;
	




		