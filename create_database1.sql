-- #####################################################
-- Name: Friyia && Liu
-- This script creates the database schema as per
-- our specifications.
-- #####################################################

CREATE TABLE extra.part_time_professor_data (
	individual_id 		VARCHAR(12) NOT NULL UNIQUE,
	last_name 			VARCHAR(25),
	middle_initial 		VARCHAR(1),
	first_name 			VARCHAR(25),
	country 			VARCHAR(30),
	state_province 		VARCHAR(30), 
	city 				VARCHAR(30),
	street 				VARCHAR(30),
	post_code			VARCHAR(6),
	home_phone			VARCHAR(15), 
	work_phone			VARCHAR(15),
	school_extension	VARCHAR(5),
	algomau_email		VARCHAR(50),
	private_email		VARCHAR(50),
	PRIMARY KEY(individual_id) );	

CREATE TABLE extra.course_data (
	course_code			  VARCHAR(8)		NOT NULL,
	session_id			  VARCHAR(2)		NOT NULL,
	course_name			  VARCHAR(50) 		NOT NULL,
	term				  VARCHAR(2)  		NOT NULL,
	tap_offer			  BIT(1)			DEFAULT b'0',
	course_cancelled	  BIT(1)			DEFAULT b'0',
	credits				  INT(1)			DEFAULT '3',
	course_description    VARCHAR(1000) 	NOT NULL,
	evaluation_performed  BIT(1)			DEFAULT b'0',
	s_year				  VARCHAR(4)		NOT NULL,
	location			  VARCHAR(30)		NOT NULL DEFAULT 'Sault Ste. Marie',
	full_course_code	  VARCHAR(20)       NOT NULL,
	number_of_instructors INT(1)			NOT NULL DEFAULT '1',
	PRIMARY KEY(full_course_code)
    );

CREATE TABLE extra.instructor_data (
	instructor_id		VARCHAR(12) 	NOT NULL,
	course_code			VARCHAR(20)		NOT NULL,
	course_date			DATE 			NOT NULL,
    seniority           INT             NOT NULL,
	PRIMARY KEY(course_code, instructor_id), 
    FOREIGN KEY(instructor_id)
    REFERENCES extra.part_time_professor_data(individual_id)
    ON DELETE CASCADE
    ON UPDATE CASCADE,
    FOREIGN KEY(course_code)
    REFERENCES extra.course_data(full_course_code)
    ON DELETE CASCADE
    ON UPDATE CASCADE
);

-- ALTER TABLE record_system_schema.instructor_data 
-- ADD CONSTRAINT fk_instructor_instructor_id
-- FOREIGN KEY(instructor_id)
-- REFERENCES record_system_schema.part_time_professor_data(individual_id);

-- ALTER TABLE record_system_schema.instructor_data 
-- ADD CONSTRAINT fk_instructor_course_code
-- FOREIGN KEY(course_code)
-- REFERENCES record_system_schema.course_data(full_course_code);



CREATE TABLE extra.tap_record (
	course_code			VARCHAR(8)		NOT NULL,
	individual_id		VARCHAR(12)		NOT NULL,
	inactive			BIT(1)			DEFAULT b'1',
	tap_date			DATE			NOT NULL,
	cancel_date			DATE,
	expire_date			DATE,
    start_date          DATE,
	previous_date	    DATE,
	PRIMARY KEY(course_code, individual_id),
    FOREIGN KEY(individual_id)
    REFERENCES extra.part_time_professor_data(individual_id)
    ON DELETE CASCADE
    ON UPDATE CASCADE
    );

-- ALTER TABLE record_system_schema.tap_record
-- ADD CONSTRAINT fk_tap_individual_id
-- FOREIGN KEY(individual_id)
-- REFERENCES record_system_schema.part_time_professor_data(individual_id);

-- the course_code in tap_record could not reference to anywhere, the synchronise should be on logic layer

CREATE TABLE extra.course_registrar_data (
	instructor_id		VARCHAR(12)		NOT NULL,
	full_course_code	VARCHAR(20)		NOT NULL,
	offer_date			DATE			NOT NULL,
	accepted			BIT(1)			DEFAULT b'0',
    PRIMARY KEY(instructor_id, full_course_code),
    FOREIGN KEY(instructor_id)
    REFERENCES extra.part_time_professor_data(individual_id)
    ON DELETE CASCADE
    ON UPDATE CASCADE,
    FOREIGN KEY(full_course_code)
    REFERENCES extra.course_data(full_course_code)
    ON DELETE CASCADE
    ON UPDATE CASCADE
    );

-- ALTER TABLE record_system_schema.course_registrar_data
-- ADD CONSTRAINT fk_registrar_individual_id
-- FOREIGN KEY(instructor_id)
-- REFERENCES record_system_schema.part_time_professor_data(individual_id);

-- ALTER TABLE record_system_schema.course_registrar_data 
-- ADD CONSTRAINT fk_registrar_course_code
-- FOREIGN KEY(full_course_code)
-- REFERENCES record_system_schema.course_data(full_course_code);


CREATE TABLE extra.activity_log (
	mod_date		DATE 		NOT NULL,
	id	            VARCHAR(12)	NOT NULL,
	action_log		VARCHAR(50) NOT NULL,
	PRIMARY KEY(mod_date, id) );


CREATE TABLE `extra`.`stipend_rule` (
  `PTCF_base` DOUBLE NOT NULL,
  `PT_seniority` DOUBLE NOT NULL,
  `seniority_increment` DOUBLE NOT NULL,
  `seniority_base` DOUBLE NOT NULL,
  `vacation_pay` DOUBLE NOT NULL,
  `PTCF_total` DOUBLE NOT NULL,
  `year` VARCHAR(4) NOT NULL);


CREATE TABLE `extra`.`login_data` (
  `username` VARCHAR(20) NOT NULL,
  `user_id` VARCHAR(12) NOT NULL,
  `password` VARCHAR(100) NOT NULL,
  `user_type` VARCHAR(1) NOT NULL,
  PRIMARY KEY (`user_id`),
  UNIQUE INDEX `username_UNIQUE` (`username` ASC),
  UNIQUE INDEX `user_id_UNIQUE` (`user_id` ASC));


CREATE TABLE `extra`.`encryption` (
  `hashcode` VARCHAR(40) NOT NULL,
  PRIMARY KEY (`hashcode`));