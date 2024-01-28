-- Author:Poon Yeong Shian
-- Date: 26/1/2024


-- drop tables
DROP TABLE IF EXISTS language
DROP TABLE IF EXISTS country
DROP TABLE IF EXISTS operator
DROP TABLE IF EXISTS ship
DROP TABLE IF EXISTS cruise
DROP TABLE IF EXISTS cabin
DROP TABLE IF EXISTS cruise_port
DROP TABLE IF EXISTS port
DROP TABLE IF EXISTS port_temp
DROP TABLE IF EXISTS manifest
DROP TABLE IF EXISTS address
DROP TABLE IF EXISTS passenger
DROP TABLE IF EXISTS participant
DROP TABLE IF EXISTS tour_lang
DROP TABLE IF EXISTS touroffer
DROP TABLE IF EXISTS tour
DROP TABLE IF EXISTS tour_when
DROP TABLE IF EXISTS tour_language

-- create tables
CREATE TABLE language(
	lang_code CHAR(2) NOT NULL,
	lang_name VARCHAR(50) NOT NULL
);

CREATE TABLE country(
	country_code CHAR(2) NOT NULL,
	country_name VARCHAR(80) NOT NULL
);

CREATE TABLE operator(
	oper_id uniqueidentifier  NOT NULL
		DEFAULT newid(),

	oper_comp_name VARCHAR(50) NOT NULL,
	oper_ceo VARCHAR(50) NOT NULL
);

CREATE TABLE ship(
	ship_code uniqueidentifier NOT NULL
		DEFAULT newid(),

	ship_name VARCHAR(50) NOT NULL,
	ship_date_commiss DATE NOT NULL,
	ship_tonnage NUMERIC(6) NOT NULL,
	ship_guest_capacity NUMERIC(4) NOT NULL,
	country_code CHAR(2) NOT NULL,
	oper_id uniqueidentifier NOT NULL,
)

CREATE TABLE cruise(
	cruise_id uniqueidentifier NOT NULL
		DEFAULT newid(),
	cruise_name VARCHAR(80) NOT NULL,
	cruise_description VARCHAR(200) NOT NULL,
	ship_code uniqueidentifier NOT NULL
)

CREATE TABLE cabin(
	ship_code uniqueidentifier NOT NULL,
	cabin_no uniqueidentifier NOT NULL
		DEFAULT newid(),
	cabin_capacity NUMERIC(1) NOT NULL,
	cabin_class CHAR(1) NOT NULL
)

CREATE TABLE cruise_port(
	cruise_id uniqueidentifier NOT NULL,
	cp_datetime DATE NOT NULL,
	cp_depart_arrive CHAR(1) NOT NULL,
	port_code uniqueidentifier NOT NULL
)

CREATE TABLE port(
	port_code uniqueidentifier NOT NULL
		DEFAULT newid(),
	port_name VARCHAR(50) NOT NULL,
	port_population NUMERIC(6) NOT NULL,
	port_long NUMERIC(10, 7) NOT NULL,
	port_lat NUMERIC(9, 7) NOT NULL,
	country_code CHAR(2) NOT NULL
)

CREATE TABLE port_temp(
	port_code uniqueidentifier NOT NULL,
	temp_month DATE NOT NULL,
	temp_high NUMERIC(4, 1),
	temp_low NUMERIC(3, 1)
)

CREATE TABLE manifest(
	passenger_id uniqueidentifier NOT NULL,
	cruise_id uniqueidentifier NOT NULL,
	mainfest_board_time DATE,
	cabin_no uniqueidentifier NOT NULL,
	ship_code uniqueidentifier NOT NULL,
)

CREATE TABLE address(
	address_id uniqueidentifier NOT NULL
		DEFAULT newid(),
	address_street VARCHAR(50) NOT NULL,
	address_town VARCHAR(30) NOT NULL,
	address_pcode VARCHAR(10) NOT NULL,
	country_code CHAR(2) NOT NULL
)

CREATE TABLE passenger(
	passenger_id uniqueidentifier NOT NULL
		DEFAULT newid(),
	passenger_fname VARCHAR(30),
	passenger_lname VARCHAR(30),
	passenger_dob DATE NOT NULL,
	passenger_gender CHAR(1) NOT NULL,
	passenger_contact CHAR (10),
	address_id uniqueidentifier NOT NULL,
	guardian_id uniqueidentifier,
	lang_code CHAR (2) NOT NULL
)

CREATE TABLE participant(
	participant_id uniqueidentifier NOT NULL
		DEFAULT newid(),
	tour_paid CHAR (1) NOT NULL,
	cruise_id uniqueidentifier NOT NULL,
	passenger_id uniqueidentifier NOT NULL,
	touroffer_date DATE NOT NULL,
	tour_id uniqueidentifier NOT NULL
)

CREATE TABLE tour_lang(
	lang_code CHAR (2) NOT NULL,
	tour_id uniqueidentifier NOT NULL
)

CREATE TABLE touroffer(
	touroffer_date DATE NOT NULL,
	tour_id uniqueidentifier NOT NULL
)

CREATE TABLE tour(
	tour_id uniqueidentifier NOT NULL
		DEFAULT newid(),
	tour_number NUMERIC(3) NOT NULL,
	tour_name VARCHAR(80) NOT NULL,
	tour_description VARCHAR(200) NOT NULL,
	tour_hours NUMERIC(3,1) NOT NULL,
	tour_cost_pp NUMERIC(6,2) NOT NULL,
	tour_wchair_access CHAR (1) NOT NULL,
	tour_starttime DATE NOT NULL,
	tour_min_participants NUMERIC(3) NOT NULL,
	tour_when_code uniqueidentifier NOT NULL,
	port_code uniqueidentifier NOT NULL
)

CREATE TABLE tour_when(
	tour_when_code uniqueidentifier NOT NULL
		DEFAULT newid(),
	tour_when_desc VARCHAR(20) NOT NULL
)

CREATE TABLE tour_language(
	lang_code CHAR (2) NOT NULL,
	tour_id uniqueidentifier NOT NULL
)

-- Primary keys
ALTER TABLE language ADD CONSTRAINT lang_pk PRIMARY KEY ( lang_code );
ALTER TABLE country ADD CONSTRAINT country_pk PRIMARY KEY ( country_code );
ALTER TABLE operator ADD CONSTRAINT operator_pk PRIMARY KEY ( oper_id );
ALTER TABLE ship ADD CONSTRAINT ship_pk PRIMARY KEY ( ship_code );
ALTER TABLE cruise ADD CONSTRAINT cruise_pk PRIMARY KEY ( cruise_id );
ALTER TABLE cabin ADD CONSTRAINT cabin_pk PRIMARY KEY ( ship_code,  cabin_no);
ALTER TABLE cruise_port ADD CONSTRAINT cruise_port_pk PRIMARY KEY ( cruise_id,  cp_datetime);
ALTER TABLE port ADD CONSTRAINT port_pk PRIMARY KEY ( port_code );
ALTER TABLE port_temp ADD CONSTRAINT port_temp_pk PRIMARY KEY ( temp_month,  port_code);
ALTER TABLE manifest ADD CONSTRAINT manifest_pk PRIMARY KEY ( passenger_id,  cruise_id);
ALTER TABLE passenger ADD CONSTRAINT passenger_pk PRIMARY KEY ( passenger_id);
ALTER TABLE participant ADD CONSTRAINT participant_pk PRIMARY KEY ( participant_id);
ALTER TABLE tour_lang ADD CONSTRAINT tour_lang_pk PRIMARY KEY ( lang_code, tour_id);
ALTER TABLE touroffer ADD CONSTRAINT touroffer_pk PRIMARY KEY ( touroffer_date, tour_id);
ALTER TABLE tour ADD CONSTRAINT tour_pk PRIMARY KEY (tour_id);
ALTER TABLE tour_when ADD CONSTRAINT tour_when_code_pk PRIMARY KEY (tour_when_code);
ALTER TABLE address ADD CONSTRAINT address_pk PRIMARY KEY (address_id);
ALTER TABLE tour_language ADD CONSTRAINT tour_language_pk PRIMARY KEY (lang_code, tour_id);

--Foreign keys
ALTER TABLE ship
        ADD CONSTRAINT operator_ship_fk FOREIGN KEY ( oper_id )
        REFERENCES operator ( oper_id );
ALTER TABLE ship
        ADD CONSTRAINT country_ship_fk FOREIGN KEY ( country_code )
        REFERENCES country ( country_code );
ALTER TABLE cruise
        ADD CONSTRAINT ship_cruise_fk FOREIGN KEY ( ship_code )
        REFERENCES ship ( ship_code );
ALTER TABLE cruise_port
        ADD CONSTRAINT cruise_cruise_port_fk FOREIGN KEY ( cruise_id )
        REFERENCES cruise ( cruise_id );
ALTER TABLE cruise_port
        ADD CONSTRAINT port_cruise_port_fk FOREIGN KEY ( port_code )
        REFERENCES port ( port_code );
ALTER TABLE address
        ADD CONSTRAINT country_address_fk FOREIGN KEY ( country_code )
        REFERENCES country ( country_code );
ALTER TABLE cabin
        ADD CONSTRAINT ship_cabin_fk FOREIGN KEY ( ship_code )
        REFERENCES ship ( ship_code );
ALTER TABLE manifest
        ADD CONSTRAINT passenger_manifest_fk FOREIGN KEY ( passenger_id )
        REFERENCES passenger ( passenger_id );
ALTER TABLE manifest
        ADD CONSTRAINT cruise_manifest_fk FOREIGN KEY ( cruise_id )
        REFERENCES cruise ( cruise_id );
ALTER TABLE manifest
        ADD CONSTRAINT cabin_manifest_fk FOREIGN KEY ( ship_code,  cabin_no)
        REFERENCES cabin ( ship_code,  cabin_no);
ALTER TABLE participant
        ADD CONSTRAINT cruise_participant_fk FOREIGN KEY ( cruise_id )
        REFERENCES cruise ( cruise_id );
ALTER TABLE participant
        ADD CONSTRAINT passenger_participant_fk FOREIGN KEY ( passenger_id )
        REFERENCES passenger ( passenger_id );
ALTER TABLE participant
        ADD CONSTRAINT touroffer_participant_fk FOREIGN KEY (  touroffer_date, tour_id)
        REFERENCES touroffer ( touroffer_date, tour_id);
ALTER TABLE passenger
        ADD CONSTRAINT address_passenger_fk FOREIGN KEY ( address_id )
        REFERENCES address ( address_id );
ALTER TABLE passenger
        ADD CONSTRAINT passenger_passenger_fk FOREIGN KEY ( guardian_id )
        REFERENCES passenger ( passenger_id );
ALTER TABLE passenger
        ADD CONSTRAINT language_passenger_fk FOREIGN KEY ( lang_code )
        REFERENCES language ( lang_code );
ALTER TABLE tour_language
        ADD CONSTRAINT language_tour_language_fk FOREIGN KEY ( lang_code )
        REFERENCES language ( lang_code );
ALTER TABLE tour_language
        ADD CONSTRAINT tour_tour_language_fk FOREIGN KEY ( tour_id )
        REFERENCES tour ( tour_id );
ALTER TABLE touroffer
        ADD CONSTRAINT tour_touroffer_fk FOREIGN KEY ( tour_id )
        REFERENCES tour ( tour_id );
ALTER TABLE tour
        ADD CONSTRAINT tour_when_tour_fk FOREIGN KEY ( tour_when_code )
        REFERENCES tour_when ( tour_when_code );
ALTER TABLE tour
        ADD CONSTRAINT port_tour_fk FOREIGN KEY ( port_code )
        REFERENCES port ( port_code );
ALTER TABLE port_temp
        ADD CONSTRAINT port_port_temp_fk FOREIGN KEY ( port_code )
        REFERENCES port ( port_code );


-- drop foreign key constraints
ALTER TABLE ship DROP CONSTRAINT operator_ship_fk;
ALTER TABLE ship DROP CONSTRAINT country_ship_fk;
ALTER TABLE cruise DROP CONSTRAINT ship_cruise_fk;
ALTER TABLE cruise_port DROP CONSTRAINT cruise_cruise_port_fk;
ALTER TABLE cruise_port DROP CONSTRAINT port_cruise_port_fk;
ALTER TABLE address DROP CONSTRAINT country_address_fk;
ALTER TABLE cabin DROP CONSTRAINT ship_cabin_fk;
ALTER TABLE manifest DROP CONSTRAINT passenger_manifest_fk;
ALTER TABLE manifest DROP CONSTRAINT cruise_manifest_fk;
ALTER TABLE manifest DROP CONSTRAINT cabin_manifest_fk;
ALTER TABLE participant DROP CONSTRAINT cruise_participant_fk;
ALTER TABLE participant DROP CONSTRAINT passenger_participant_fk;
ALTER TABLE participant DROP CONSTRAINT touroffer_participant_fk;
ALTER TABLE passenger DROP CONSTRAINT address_passenger_fk;
ALTER TABLE passenger DROP CONSTRAINT passenger_passenger_fk;
ALTER TABLE passenger DROP CONSTRAINT language_passenger_fk;
ALTER TABLE tour_language DROP CONSTRAINT language_tour_language_fk;
ALTER TABLE tour_language DROP CONSTRAINT tour_tour_language_fk;
ALTER TABLE touroffer DROP CONSTRAINT tour_touroffer_fk;
ALTER TABLE tour DROP CONSTRAINT tour_when_tour_fk;
ALTER TABLE tour DROP CONSTRAINT port_tour_fk;
ALTER TABLE port_temp DROP CONSTRAINT port_port_temp_fk;

----Unique keys
ALTER TABLE address ADD CONSTRAINT address_nk UNIQUE(address_street, address_town, address_pcode, country_code)
ALTER TABLE participant ADD CONSTRAINT participant_nk UNIQUE(passenger_id, touroffer_date, tour_id)
ALTER TABLE tour ADD CONSTRAINT tour_nk UNIQUE(tour_number, port_code)

----Data checking
ALTER TABLE passenger
	ADD CONSTRAINT check_passenger_gender CHECK ( passenger_gender IN ( 'F', 'M', 'U' ) );

ALTER TABLE participant
	ADD CONSTRAINT check_tour_paid CHECK ( tour_paid IN ('Y', 'N') );

ALTER TABLE cabin
	ADD CONSTRAINT check_cabin_class CHECK ( cabin_class IN ('I', 'O', 'B', 'S') );

ALTER TABLE tour
	ADD CONSTRAINT check_tour_wchair_access CHECK ( tour_wchair_access IN ('Y', 'N') );

ALTER TABLE cruise_port
	ADD CONSTRAINT check_cp_depart_arrive CHECK ( cp_depart_arrive IN ('Y', 'N') );
