INSERT INTO country (
	country_code,
	country_name
) VALUES (
	'AU',
	'Australia'
);
INSERT INTO country (
	country_code,
	country_name
) VALUES (
	'MY',
	'Malaysia'
);
INSERT INTO country (
	country_code,
	country_name
) VALUES (
	'JP',
	'Japan'
);
INSERT INTO country (
	country_code,
	country_name
) VALUES (
	'CH',
	'China'
);
INSERT INTO country (
	country_code,
	country_name
) VALUES (
	'SG',
	'Singapore'
);

INSERT INTO operator (
	oper_comp_name,
	oper_ceo
) VALUES (
	'Chitra Sampathkumar',
	'Santhosh Gur'
);
INSERT INTO operator (
	oper_comp_name,
	oper_ceo
) VALUES (
	'Premalatha D.',
	'Boopal V'
);
INSERT INTO operator (
	oper_comp_name,
	oper_ceo
) VALUES (
	'Kevin Andrew Thomas F',
	'Vishaal G'
);

INSERT INTO language(
	lang_code,
	lang_name
) VALUES (
	'en',
	'English'
);
INSERT INTO language(
	lang_code,
	lang_name
) VALUES (
	'zh',
	'Chinese'
);
INSERT INTO language(
	lang_code,
	lang_name
) VALUES (
	'jp',
	'Japanese'
);
INSERT INTO language(
	lang_code,
	lang_name
) VALUES (
	'es',
	'Spanish'
);
INSERT INTO language(
	lang_code,
	lang_name
) VALUES (
	'ko',
	'Korean'
);

INSERT INTO port(
    port_name,
    port_population,
    port_long,
    port_lat,
    country_code
) VALUES 
('Port Adelaide', 160000, 138.5033, -34.8442, 'AU'),
('Port Douglas', 3500, 145.4653, -16.4836, 'AU'),
('Port Melbourne', 160000, 144.9071, -37.8254, 'AU'),
('Port Arthur', 1000, 147.8500, -43.1500, 'AU'),
('Port Jackson', 500000, 151.2128, -33.8480, 'AU'),
('Port of Brisbane', 200000, 153.1272, -27.4498, 'AU'),
('Port of Fremantle', 31500, 115.7339, -32.0569, 'AU'),
('Port Campbell', 500, 143.1095, -38.6177, 'AU'),
('Port Macquarie', 47000, 152.9195, -31.4333, 'AU'),
('Port Stephens', 29000, 152.1114, -32.7150, 'AU'),
('Port Dickson', 90000, 101.8067, 2.5223, 'MY'),
('Port Klang', 700000, 101.3667, 3.0333, 'MY'),
('Port Tanjung Pelepas', 80000, 103.5667, 1.4667, 'MY'),
('Port Kelang', 140000, 101.3890, 3.0378, 'MY'),
('Port of Tokyo', 897000, 139.7900, 35.6528, 'JP'),
('Port of Yokohama', 380000, 139.6380, 35.4437, 'JP'),
('Port of Kobe', 150000, 135.1955, 34.6913, 'JP'),
('Port of Osaka', 269000, 135.4601, 34.6937, 'JP'),
('Port of Nagoya', 227000, 136.8816, 35.0805, 'JP'),
('Port of Singapore', 500000, 103.7469, 1.2904, 'SG'),
('Port Klang', 70000, 101.3667, 3.0333, 'SG'),
('Port Tanjung Pelepas', 80000, 103.5667, 1.4667, 'SG'),
('Port Kelang', 140000, 101.3890, 3.0378, 'SG'),
('Port Dickson', 90000, 101.8067, 2.5223, 'SG'),
('Port of Geneva', 198979, 6.1432, 46.2044, 'CH'),
('Port of Basel', 178128, 7.5859, 47.5581, 'CH'),
('Port of Zurich', 415215, 8.5417, 47.3769, 'CH'),
('Port of Lausanne', 216633, 6.6326, 46.5197, 'CH'),
('Port of Bern', 133798, 7.4474, 46.9480, 'CH');

INSERT INTO port_temp(
    port_code,
    temp_month,
    temp_high,
    temp_low
) VALUES 
('F6665100-0794-43BB-B9D1-09B31CB3ACD5', '2024-01-01', 75, 55),
('F6665100-0794-43BB-B9D1-09B31CB3ACD5', '2024-02-01', 78, 58),
('F6665100-0794-43BB-B9D1-09B31CB3ACD5', '2024-03-01', 80, 60),
('F6665100-0794-43BB-B9D1-09B31CB3ACD5', '2024-04-01', 82, 62),
('F6665100-0794-43BB-B9D1-09B31CB3ACD5', '2024-05-01', 85, 65),
('F6665100-0794-43BB-B9D1-09B31CB3ACD5', '2024-06-01', 88, 68),
('F6665100-0794-43BB-B9D1-09B31CB3ACD5', '2024-07-01', 90, 70),
('F6665100-0794-43BB-B9D1-09B31CB3ACD5', '2024-08-01', 91, 71),
('F6665100-0794-43BB-B9D1-09B31CB3ACD5', '2024-09-01', 88, 68),
('F6665100-0794-43BB-B9D1-09B31CB3ACD5', '2024-10-01', 85, 65),
('F6665100-0794-43BB-B9D1-09B31CB3ACD5', '2024-11-01', 80, 60),
('F6665100-0794-43BB-B9D1-09B31CB3ACD5', '2024-12-01', 76, 56),
('51B26145-4BA4-4279-BE31-239C1D753BC1', '2024-01-01', 72, 52),
('51B26145-4BA4-4279-BE31-239C1D753BC1', '2024-02-01', 75, 55),
('51B26145-4BA4-4279-BE31-239C1D753BC1', '2024-03-01', 78, 58),
('51B26145-4BA4-4279-BE31-239C1D753BC1', '2024-04-01', 80, 60),
('51B26145-4BA4-4279-BE31-239C1D753BC1', '2024-05-01', 83, 63),
('51B26145-4BA4-4279-BE31-239C1D753BC1', '2024-06-01', 86, 66),
('51B26145-4BA4-4279-BE31-239C1D753BC1', '2024-07-01', 88, 68),
('51B26145-4BA4-4279-BE31-239C1D753BC1', '2024-08-01', 89, 69),
('51B26145-4BA4-4279-BE31-239C1D753BC1', '2024-09-01', 86, 66),
('51B26145-4BA4-4279-BE31-239C1D753BC1', '2024-10-01', 83, 63),
('51B26145-4BA4-4279-BE31-239C1D753BC1', '2024-11-01', 78, 58),
('51B26145-4BA4-4279-BE31-239C1D753BC1', '2024-12-01', 73, 53),
('8B9268E5-D775-4F14-8D28-29D475EFDD99', '2024-01-01', 70, 50),
('8B9268E5-D775-4F14-8D28-29D475EFDD99', '2024-02-01', 73, 53),
('8B9268E5-D775-4F14-8D28-29D475EFDD99', '2024-03-01', 76, 56),
('8B9268E5-D775-4F14-8D28-29D475EFDD99', '2024-04-01', 78, 58),
('8B9268E5-D775-4F14-8D28-29D475EFDD99', '2024-05-01', 81, 61),
('8B9268E5-D775-4F14-8D28-29D475EFDD99', '2024-06-01', 84, 64),
('8B9268E5-D775-4F14-8D28-29D475EFDD99', '2024-07-01', 86, 66),
('8B9268E5-D775-4F14-8D28-29D475EFDD99', '2024-08-01', 87, 67),
('8B9268E5-D775-4F14-8D28-29D475EFDD99', '2024-09-01', 84, 64),
('8B9268E5-D775-4F14-8D28-29D475EFDD99', '2024-10-01', 81, 61),
('8B9268E5-D775-4F14-8D28-29D475EFDD99', '2024-11-01', 76, 56),
('8B9268E5-D775-4F14-8D28-29D475EFDD99', '2024-12-01', 71, 51),
('2D13B12B-7C92-4672-8A0C-33AE6D05780D', '2024-01-01', 68, 48),
('2D13B12B-7C92-4672-8A0C-33AE6D05780D', '2024-02-01', 71, 51),
('2D13B12B-7C92-4672-8A0C-33AE6D05780D', '2024-03-01', 74, 54),
('2D13B12B-7C92-4672-8A0C-33AE6D05780D', '2024-04-01', 76, 56),
('2D13B12B-7C92-4672-8A0C-33AE6D05780D', '2024-05-01', 79, 59),
('2D13B12B-7C92-4672-8A0C-33AE6D05780D', '2024-06-01', 82, 62),
('2D13B12B-7C92-4672-8A0C-33AE6D05780D', '2024-07-01', 84, 64),
('2D13B12B-7C92-4672-8A0C-33AE6D05780D', '2024-08-01', 85, 65),
('2D13B12B-7C92-4672-8A0C-33AE6D05780D', '2024-09-01', 82, 62),
('2D13B12B-7C92-4672-8A0C-33AE6D05780D', '2024-10-01', 79, 59),
('2D13B12B-7C92-4672-8A0C-33AE6D05780D', '2024-11-01', 74, 54),
('2D13B12B-7C92-4672-8A0C-33AE6D05780D', '2024-12-01', 69, 49),
('99C148D1-9820-4A15-AEAD-34AEDA7FFE06', '2024-01-01', 65, 45),
('99C148D1-9820-4A15-AEAD-34AEDA7FFE06', '2024-02-01', 68, 48),
('99C148D1-9820-4A15-AEAD-34AEDA7FFE06', '2024-03-01', 71, 51),
('99C148D1-9820-4A15-AEAD-34AEDA7FFE06', '2024-04-01', 73, 53),
('99C148D1-9820-4A15-AEAD-34AEDA7FFE06', '2024-05-01', 76, 56),
('99C148D1-9820-4A15-AEAD-34AEDA7FFE06', '2024-06-01', 79, 59),
('99C148D1-9820-4A15-AEAD-34AEDA7FFE06', '2024-07-01', 81, 61),
('99C148D1-9820-4A15-AEAD-34AEDA7FFE06', '2024-08-01', 82, 62),
('99C148D1-9820-4A15-AEAD-34AEDA7FFE06', '2024-09-01', 79, 59),
('99C148D1-9820-4A15-AEAD-34AEDA7FFE06', '2024-10-01', 76, 56),
('99C148D1-9820-4A15-AEAD-34AEDA7FFE06', '2024-11-01', 71, 51),
('99C148D1-9820-4A15-AEAD-34AEDA7FFE06', '2024-12-01', 66, 46),
('CFD52FAB-A7B2-47E5-972D-367ED3E273B6', '2024-01-01', 62, 42),
('CFD52FAB-A7B2-47E5-972D-367ED3E273B6', '2024-02-01', 65, 45),
('CFD52FAB-A7B2-47E5-972D-367ED3E273B6', '2024-03-01', 68, 48),
('CFD52FAB-A7B2-47E5-972D-367ED3E273B6', '2024-04-01', 70, 50),
('CFD52FAB-A7B2-47E5-972D-367ED3E273B6', '2024-05-01', 73, 53),
('CFD52FAB-A7B2-47E5-972D-367ED3E273B6', '2024-06-01', 76, 56),
('CFD52FAB-A7B2-47E5-972D-367ED3E273B6', '2024-07-01', 78, 58),
('CFD52FAB-A7B2-47E5-972D-367ED3E273B6', '2024-08-01', 79, 59),
('CFD52FAB-A7B2-47E5-972D-367ED3E273B6', '2024-09-01', 76, 56),
('CFD52FAB-A7B2-47E5-972D-367ED3E273B6', '2024-10-01', 73, 53),
('CFD52FAB-A7B2-47E5-972D-367ED3E273B6', '2024-11-01', 68, 48),
('CFD52FAB-A7B2-47E5-972D-367ED3E273B6', '2024-12-01', 63, 43);
INSERT INTO port_temp (
    port_code,
    temp_month,
    temp_high,
    temp_low
) VALUES 
('A1BA25FD-82B4-4BDB-AEAA-3753877D58D5', '2024-01-01', 28, 15),
('A1BA25FD-82B4-4BDB-AEAA-3753877D58D5', '2024-02-01', 30, 18),
('A1BA25FD-82B4-4BDB-AEAA-3753877D58D5', '2024-03-01', 32, 20),
('A1BA25FD-82B4-4BDB-AEAA-3753877D58D5', '2024-04-01', 35, 23),
('A1BA25FD-82B4-4BDB-AEAA-3753877D58D5', '2024-05-01', 38, 25),
('A1BA25FD-82B4-4BDB-AEAA-3753877D58D5', '2024-06-01', 40, 28),
('A1BA25FD-82B4-4BDB-AEAA-3753877D58D5', '2024-07-01', 41, 30),
('A1BA25FD-82B4-4BDB-AEAA-3753877D58D5', '2024-08-01', 40, 28),
('A1BA25FD-82B4-4BDB-AEAA-3753877D58D5', '2024-09-01', 38, 25),
('A1BA25FD-82B4-4BDB-AEAA-3753877D58D5', '2024-10-01', 35, 23),
('A1BA25FD-82B4-4BDB-AEAA-3753877D58D5', '2024-11-01', 32, 20),
('A1BA25FD-82B4-4BDB-AEAA-3753877D58D5', '2024-12-01', 30, 18),
('4785597E-A32B-416E-8D66-3C23ED936773', '2024-01-01', 26, 13),
('4785597E-A32B-416E-8D66-3C23ED936773', '2024-02-01', 28, 16),
('4785597E-A32B-416E-8D66-3C23ED936773', '2024-03-01', 30, 18),
('4785597E-A32B-416E-8D66-3C23ED936773', '2024-04-01', 33, 21),
('4785597E-A32B-416E-8D66-3C23ED936773', '2024-05-01', 36, 23),
('4785597E-A32B-416E-8D66-3C23ED936773', '2024-06-01', 38, 26),
('4785597E-A32B-416E-8D66-3C23ED936773', '2024-07-01', 39, 28),
('4785597E-A32B-416E-8D66-3C23ED936773', '2024-08-01', 38, 26),
('4785597E-A32B-416E-8D66-3C23ED936773', '2024-09-01', 36, 23),
('4785597E-A32B-416E-8D66-3C23ED936773', '2024-10-01', 33, 21),
('4785597E-A32B-416E-8D66-3C23ED936773', '2024-11-01', 30, 18),
('4785597E-A32B-416E-8D66-3C23ED936773', '2024-12-01', 28, 16);

INSERT INTO tour_when(
	tour_when_desc
) VALUES ('leopard'),
('volleyball'),
('mountain'),
('puzzle'),
('elephant'),
('umbrella'),
('butterfly'),
('whisper'),
('treasure'),
('guitar'),
('diamond'),
('sunflower'),
('carousel'),
('jazz'),
('harmony'),
('serendipity'),
('chocolate'),
('fireworks'),
('moonlight'),
('octopus'),
('illusion'),
('lullaby'),
('flamingo'),
('quicksilver'),
('galaxy'),
('waterfall'),
('rainbow'),
('whirlwind'),
('chameleon'),
('adventure'),
('wonderland'),
('crystal'),
('silhouette'),
('marvel'),
('carousel'),
('echo'),
('tiger'),
('lighthouse'),
('serenity'),
('cosmos'),
('mermaid'),
('butterfly'),
('harmony'),
('phoenix'),
('blossom'),
('infinity'),
('freedom'),
('serenity'),
('whisper'),
('moonbeam'),
('sunset'),
('twilight'),
('stardust'),
('dreamscape'),
('labyrinth'),
('cascade'),
('enchanted'),
('whirlpool'),
('silhouette'),
('paradise'),
('firefly'),
('mystique'),
('laughter'),
('cascade'),
('treasure'),
('harmony'),
('lullaby'),
('carousel'),
('lighthouse'),
('butterfly'),
('rainbow'),
('whisper'),
('fireworks'),
('serendipity'),
('volcano'),
('serenity'),
('guitar'),
('seashell'),
('blossom'),
('echo'),
('diamond'),
('mystery'),
('raindrop'),
('chocolate'),
('serenade'),
('moonlight'),
('adventure'),
('wanderlust'),
('cascade'),
('serenity'),
('chameleon'),
('lullaby'),
('twilight'),
('paradise'),
('crystal'),
('butterfly'),
('volcano'),
('sunflower'),
('illusion'),
('wonderland'),
('serenity'),
('moonbeam'),
('harmony'),
('sunset'),
('firefly'),
('whirlpool');

INSERT INTO address (
    address_street,
    address_town,
    address_pcode,
    country_code
) VALUES ('123 Main St', 'Springfield', '12345', 'AU'),
('456 Elm St', 'Rivertown', '54321', 'CH'),
('789 Oak St', 'Maplewood', '67890', 'JP'),
('321 Pine St', 'Greenville', '09876', 'MY'),
('654 Birch St', 'Hillcrest', '13579', 'SG'),
('987 Cedar St', 'Lakeside', '24680', 'AU'),
('741 Walnut St', 'Sunset Valley', '86420', 'CH'),
('852 Cherry St', 'Oceanview', '35791', 'JP'),
('963 Willow St', 'Meadowbrook', '57931', 'MY'),
('159 Aspen St', 'Highland Park', '79315', 'SG'),
('357 Magnolia St', 'Greenfield', '15973', 'AU'),
('753 Sycamore St', 'Fairview', '95173', 'CH'),
('951 Poplar St', 'Hometown', '35795', 'JP'),
('246 Cedar St', 'Pine Grove', '57931', 'MY'),
('468 Birch St', 'Springfield', '13579', 'SG'),
('802 Elm St', 'Rivertown', '24680', 'AU'),
('246 Oak St', 'Maplewood', '35791', 'CH'),
('135 Pine St', 'Greenville', '46802', 'JP'),
('579 Walnut St', 'Hillcrest', '57931', 'MY'),
('693 Cedar St', 'Lakeside', '69324', 'SG'),
('258 Cherry St', 'Sunset Valley', '80246', 'AU'),
('147 Willow St', 'Oceanview', '91573', 'CH'),
('369 Aspen St', 'Meadowbrook', '14725', 'JP'),
('582 Magnolia St', 'Highland Park', '25874', 'MY'),
('795 Sycamore St', 'Greenfield', '36915', 'SG'),
('159 Poplar St', 'Fairview', '58236', 'AU'),
('357 Cedar St', 'Hometown', '79512', 'CH'),
('123 Maple St', 'Pine Grove', '12345', 'JP'),
('456 Oak St', 'Springfield', '54321', 'MY'),
('789 Pine St', 'Rivertown', '67890', 'SG'),
('321 Elm St', 'Maplewood', '09876', 'AU'),
('654 Cedar St', 'Greenville', '13579', 'CH'),
('987 Birch St', 'Hillcrest', '24680', 'JP'),
('741 Walnut St', 'Lakeside', '86420', 'MY'),
('852 Cherry St', 'Sunset Valley', '35791', 'SG'),
('963 Willow St', 'Oceanview', '57931', 'AU'),
('159 Aspen St', 'Meadowbrook', '79315', 'CH'),
('357 Magnolia St', 'Highland Park', '15973', 'JP'),
('753 Sycamore St', 'Greenfield', '95173', 'MY'),
('951 Poplar St', 'Fairview', '35795', 'SG'),
('246 Cedar St', 'Hometown', '57931', 'AU'),
('468 Birch St', 'Pine Grove', '13579', 'CH'),
('802 Elm St', 'Springfield', '24680', 'JP'),
('246 Oak St', 'Rivertown', '35791', 'MY'),
('135 Pine St', 'Maplewood', '46802', 'SG'),
('579 Walnut St', 'Greenville', '57931', 'AU'),
('693 Cedar St', 'Hillcrest', '69324', 'CH'),
('258 Cherry St', 'Lakeside', '80246', 'JP'),
('147 Willow St', 'Sunset Valley', '91573', 'MY'),
('369 Aspen St', 'Oceanview', '14725', 'SG'),
('582 Magnolia St', 'Meadowbrook', '25874', 'AU'),
('795 Sycamore St', 'Highland Park', '36915', 'CH'),
('159 Poplar St', 'Greenfield', '58236', 'JP'),
('357 Cedar St', 'Fairview', '79512', 'MY'),
('123 Maple St', 'Hometown', '12345', 'SG'),
('456 Oak St', 'Pine Grove', '54321', 'AU'),
('789 Pine St', 'Springfield', '67890', 'CH'),
('321 Elm St', 'Rivertown', '09876', 'JP'),
('654 Cedar St', 'Maplewood', '13579', 'MY'),
('987 Birch St', 'Greenville', '24680', 'SG'),
('741 Walnut St', 'Hillcrest', '86420', 'AU'),
('852 Cherry St', 'Lakeside', '35791', 'CH'),
('963 Willow St', 'Sunset Valley', '57931', 'JP'),
('159 Aspen St', 'Oceanview', '79315', 'MY'),
('357 Magnolia St', 'Meadowbrook', '15973', 'SG'),
('753 Sycamore St', 'Highland Park', '95173', 'AU'),
('951 Poplar St', 'Greenfield', '35795', 'CH'),
('246 Cedar St', 'Fairview', '57931', 'JP'),
('468 Birch St', 'Hometown', '13579', 'MY'),
('802 Elm St', 'Pine Grove', '24680', 'SG'),
('246 Oak St', 'Springfield', '35791', 'AU'),
('135 Pine St', 'Rivertown', '46802', 'CH'),
('579 Walnut St', 'Maplewood', '57931', 'JP'),
('693 Cedar St', 'Greenville', '69324', 'MY'),
('258 Cherry St', 'Hillcrest', '80246', 'SG'),
('147 Willow St', 'Lakeside', '91573', 'AU'),
('369 Aspen St', 'Sunset Valley', '14725', 'CH'),
('582 Magnolia St', 'Oceanview', '25874', 'JP'),
('795 Sycamore St', 'Meadowbrook', '36915', 'MY'),
('159 Poplar St', 'Highland Park', '58236', 'SG'),
('357 Cedar St', 'Greenfield', '79512', 'AU'),
('123 Maple St', 'Fairview', '12345', 'CH'),
('456 Oak St', 'Hometown', '54321', 'JP'),
('789 Pine St', 'Pine Grove', '67890', 'MY'),
('321 Elm St', 'Springfield', '09876', 'SG'),
('654 Cedar St', 'Rivertown', '13579', 'AU'),
('987 Birch St', 'Maplewood', '24680', 'CH'),
('741 Walnut St', 'Greenville', '86420', 'JP'),
('852 Cherry St', 'Hillcrest', '35791', 'MY'),
('963 Willow St', 'Lakeside', '57931', 'SG'),
('159 Aspen St', 'Sunset Valley', '79315', 'AU'),
('357 Magnolia St', 'Oceanview', '15973', 'CH'),
('753 Sycamore St', 'Meadowbrook', '95173', 'JP'),
('951 Poplar St', 'Highland Park', '35795', 'MY'),
('246 Cedar St', 'Greenfield', '57931', 'SG'),
('468 Birch St', 'Fairview', '13579', 'AU'),
('802 Elm St', 'Hometown', '24680', 'CH'),
('246 Oak St', 'Pine Grove', '35791', 'JP'),
('135 Pine St', 'Springfield', '46802', 'MY'),
('579 Walnut St', 'Rivertown', '57931', 'SG'),
('693 Cedar St', 'Maplewood', '69324', 'AU'),
('258 Cherry St', 'Greenville', '80246', 'CH'),
('147 Willow St', 'Hillcrest', '91573', 'JP'),
('369 Aspen St', 'Lakeside', '14725', 'MY'),
('582 Magnolia St', 'Sunset Valley', '25874', 'SG'),
('795 Sycamore St', 'Oceanview', '36915', 'AU'),
('159 Poplar St', 'Meadowbrook', '58236', 'CH'),
('357 Cedar St', 'Highland Park', '79512', 'JP'),
('123 Maple St', 'Greenfield', '12345', 'MY'),
('456 Oak St', 'Fairview', '54321', 'SG'),
('789 Pine St', 'Hometown', '67890', 'AU'),
('321 Elm St', 'Pine Grove', '09876', 'CH'),
('654 Cedar St', 'Springfield', '13579', 'JP'),
('987 Birch St', 'Rivertown', '24680', 'MY'),
('741 Walnut St', 'Maplewood', '86420', 'SG'),
('852 Cherry St', 'Greenville', '35791', 'AU'),
('963 Willow St', 'Hillcrest', '57931', 'CH'),
('159 Aspen St', 'Lakeside', '79315', 'JP'),
('357 Magnolia St', 'Sunset Valley', '15973', 'MY'),
('753 Sycamore St', 'Oceanview', '95173', 'SG'),
('951 Poplar St', 'Meadowbrook', '35795', 'AU'),
('246 Cedar St', 'Highland Park', '57931', 'CH'),
('468 Birch St', 'Greenfield', '13579', 'JP'),
('802 Elm St', 'Fairview', '24680', 'MY'),
('246 Oak St', 'Hometown', '35791', 'SG'),
('135 Pine St', 'Pine Grove', '46802', 'AU'),
('579 Walnut St', 'Springfield', '57931', 'CH'),
('693 Cedar St', 'Rivertown', '69324', 'JP'),
('258 Cherry St', 'Maplewood', '80246', 'MY'),
('147 Willow St', 'Greenville', '91573', 'SG'),
('369 Aspen St', 'Hillcrest', '14725', 'AU'),
('582 Magnolia St', 'Lakeside', '25874', 'CH'),
('795 Sycamore St', 'Sunset Valley', '36915', 'JP'),
('159 Poplar St', 'Oceanview', '58236', 'MY'),
('357 Cedar St', 'Meadowbrook', '79512', 'SG'),
('123 Maple St', 'Highland Park', '12345', 'AU'),
('456 Oak St', 'Greenfield', '54321', 'CH'),
('789 Pine St', 'Fairview', '67890', 'JP'),
('321 Elm St', 'Hometown', '09876', 'MY'),
('654 Cedar St', 'Pine Grove', '13579', 'SG'),
('987 Birch St', 'Springfield', '24680', 'AU'),
('741 Walnut St', 'Rivertown', '86420', 'CH'),
('852 Cherry St', 'Maplewood', '35791', 'JP'),
('963 Willow St', 'Greenville', '57931', 'MY'),
('159 Aspen St', 'Hillcrest', '79315', 'SG'),
('357 Magnolia St', 'Lakeside', '15973', 'AU'),
('753 Sycamore St', 'Sunset Valley', '95173', 'CH'),
('951 Poplar St', 'Oceanview', '35795', 'JP'),
('246 Cedar St', 'Meadowbrook', '57931', 'MY'),
('468 Birch St', 'Highland Park', '13579', 'SG'),
('802 Elm St', 'Greenfield', '24680', 'AU'),
('246 Oak St', 'Fairview', '35791', 'CH'),
('135 Pine St', 'Hometown', '46802', 'JP'),
('579 Walnut St', 'Pine Grove', '57931', 'MY'),
('693 Cedar St', 'Springfield', '69324', 'SG'),
('258 Cherry St', 'Rivertown', '80246', 'AU'),
('147 Willow St', 'Maplewood', '91573', 'CH'),
('369 Aspen St', 'Greenville', '14725', 'JP'),
('582 Magnolia St', 'Hillcrest', '25874', 'MY'),
('795 Sycamore St', 'Lakeside', '36915', 'SG'),
('159 Poplar St', 'Sunset Valley', '58236', 'AU'),
('357 Cedar St', 'Oceanview', '79512', 'CH');

INSERT INTO passenger (
    passenger_fname,
    passenger_lname,
    passenger_dob,
    passenger_gender,
    passenger_contact,
    address_id,
    guardian_id,
    lang_code
) VALUES 
('John', 'Doe', '1990-05-15', 'M', '1234567890', 'A2E9C02E-7E7B-4BEA-A170-4382CABDB285', NULL, 'en'),
('Jane', 'Smith', '1985-08-20', 'F', '9876543210', 'B5DC8FA4-411B-4368-9B4A-E7099123DB23', NULL, 'es'),
('Michael', 'Johnson', '1998-03-10', 'M', '5551112222', '1664E3C8-A754-4C9A-B325-2E38248F1A41', NULL, 'jp'),
('Emily', 'Brown', '2002-11-25', 'F', '9998887777', 'C965E4E4-C54B-4322-9C6E-AF07C7F1433E', NULL, 'ko'),
('David', 'Lee', '1976-09-05', 'M', '4443332222', 'C6FE153A-4591-4E71-B497-07C076860A35', NULL, 'zh'),
('Sophia', 'Garcia', '1995-12-30', 'F', '7776665555', 'DA198746-6EA7-4885-BCB0-DAD9F58DB697', NULL, 'en'),
('Matthew', 'Martinez', '1980-07-18', 'M', '1112223333', 'A2E9C02E-7E7B-4BEA-A170-4382CABDB285', NULL, 'es'),
('Olivia', 'Hernandez', '1989-04-03', 'F', '9990001111', 'B5DC8FA4-411B-4368-9B4A-E7099123DB23', NULL, 'jp'),
('Daniel', 'Lopez', '1993-06-22', 'M', '4445556666', '1664E3C8-A754-4C9A-B325-2E38248F1A41', NULL, 'ko'),
('Emma', 'Gonzalez', '2000-02-14', 'F', '8889990000', 'C965E4E4-C54B-4322-9C6E-AF07C7F1433E', NULL, 'zh'),
('Christopher', 'Perez', '1987-10-08', 'M', '7778889999', 'C6FE153A-4591-4E71-B497-07C076860A35', NULL, 'en'),
('Ava', 'Rodriguez', '1997-01-17', 'F', '3332221111', 'DA198746-6EA7-4885-BCB0-DAD9F58DB697', NULL, 'es'),
('Andrew', 'Gomez', '1979-08-28', 'M', '6667778888', 'A2E9C02E-7E7B-4BEA-A170-4382CABDB285', NULL, 'jp'),
('Isabella', 'Perez', '1984-05-12', 'F', '1110009999', 'B5DC8FA4-411B-4368-9B4A-E7099123DB23', NULL, 'ko'),
('Joshua', 'Hernandez', '1991-09-29', 'M', '4443332222', '1664E3C8-A754-4C9A-B325-2E38248F1A41', NULL, 'zh'),
('Sophia', 'Torres', '1996-03-07', 'F', '9998887777', 'C965E4E4-C54B-4322-9C6E-AF07C7F1433E', NULL, 'en'),
('Alexander', 'Sanchez', '1983-11-03', 'M', '5556667777', 'C6FE153A-4591-4E71-B497-07C076860A35', NULL, 'es'),
('Madison', 'Rivera', '2001-07-19', 'F', '7776665555', 'DA198746-6EA7-4885-BCB0-DAD9F58DB697', NULL, 'jp'),
('Ethan', 'Martin', '1988-12-15', 'M', '8889990000', 'A2E9C02E-7E7B-4BEA-A170-4382CABDB285', NULL, 'ko'),
('Mia', 'Reyes', '1992-04-23', 'F', '3332221111', 'B5DC8FA4-411B-4368-9B4A-E7099123DB23', NULL, 'zh');

INSERT INTO ship (
    ship_name,
    ship_date_commiss,
    ship_tonnage,
    ship_guest_capacity,
    oper_id,
    country_code
) VALUES 
('Ocean Voyager', '2023-05-15', 250000, 4000, 'B12393E3-D13C-4293-B93A-9209F2DBF284', 'AU'),
('Sea Serenity', '2022-11-30', 180000, 3000, '632668C6-8218-4430-AF0B-973C3B1AF3D0', 'CH'),
('Sunset Princess', '2023-07-18', 320000, 5000, '5BB231F9-CC68-483A-83E7-D6C4EF0DD625', 'JP'),
('Sapphire Seas', '2022-09-05', 200000, 3500, 'B12393E3-D13C-4293-B93A-9209F2DBF284', 'MY'),
('Golden Horizon', '2023-02-14', 280000, 4500, '632668C6-8218-4430-AF0B-973C3B1AF3D0', 'SG'),
('Crystal Crown', '2022-12-30', 190000, 3200, '5BB231F9-CC68-483A-83E7-D6C4EF0DD625', 'AU'),
('Harbor Breeze', '2023-04-22', 220000, 3800, 'B12393E3-D13C-4293-B93A-9209F2DBF284', 'CH'),
('Marina Majesty', '2022-10-08', 260000, 4200, '632668C6-8218-4430-AF0B-973C3B1AF3D0', 'JP'),
('Royal Odyssey', '2023-08-28', 300000, 4800, '5BB231F9-CC68-483A-83E7-D6C4EF0DD625', 'MY'),
('Azure Dream', '2022-11-12', 170000, 2900, 'B12393E3-D13C-4293-B93A-9209F2DBF284', 'SG'),
('Pacific Pearl', '2023-06-17', 240000, 4000, '632668C6-8218-4430-AF0B-973C3B1AF3D0', 'AU'),
('Island Paradise', '2022-12-25', 310000, 5100, '5BB231F9-CC68-483A-83E7-D6C4EF0DD625', 'CH'),
('Majestic Mist', '2023-03-07', 210000, 3600, 'B12393E3-D13C-4293-B93A-9209F2DBF284', 'JP'),
('Coral Queen', '2022-09-29', 270000, 4300, '632668C6-8218-4430-AF0B-973C3B1AF3D0', 'MY'),
('Starlight Voyager', '2023-01-17', 330000, 4900, '5BB231F9-CC68-483A-83E7-D6C4EF0DD625', 'SG'),
('Silver Sun', '2022-08-28', 180000, 3000, 'B12393E3-D13C-4293-B93A-9209F2DBF284', 'AU'),
('Atlantic Explorer', '2023-05-12', 250000, 4100, '632668C6-8218-4430-AF0B-973C3B1AF3D0', 'CH'),
('Tropical Twilight', '2022-11-29', 320000, 5200, '5BB231F9-CC68-483A-83E7-D6C4EF0DD625', 'JP'),
('Moonlit Marina', '2023-07-19', 190000, 3300, 'B12393E3-D13C-4293-B93A-9209F2DBF284', 'MY'),
('Seaside Serenade', '2022-12-15', 260000, 4400, '632668C6-8218-4430-AF0B-973C3B1AF3D0', 'SG');

INSERT INTO cabin (
    ship_code,
    cabin_capacity,
    cabin_class
) VALUES 
('83FC1748-DCE4-44D1-A978-01534C145B71', 2, 'S'),
('B964BFD9-4921-4277-8E98-0C1023C46692', 4, 'B'),
('6B4C3D20-52B0-4428-AB8D-0EA1B349BFE1', 3, 'O'),
('0E24F286-6ED6-437B-9DA8-102BAB22D83C', 2, 'I'),
('814AFB02-B802-4322-B072-1DCEF805AF44', 4, 'S'),
('38BBB325-7E59-4ECA-9F90-1DEB89299DAD', 2, 'B'),
('44628EAE-92B2-4B6D-9365-2AAD4AACEF77', 3, 'O'),
('F8C70D02-7905-4FA9-A1D8-31729FA07F70', 2, 'I'),
('5BFF44F5-94EB-45F5-912E-37C333820E62', 4, 'S'),
('B0FDA9E3-223F-4C9E-8AA5-4692BA585743', 3, 'B'),
('C01D1F38-71AF-4EE9-808E-67100F545ABE', 2, 'O'),
('C2344D67-FD0B-4F53-AB09-768952CA7FC6', 4, 'I'),
('94265C2E-B0CA-4FF0-91CA-92061B71C965', 2, 'S'),
('780AD71A-F2C9-4EE5-9B39-B868D8DA88AB', 3, 'B'),
('68E2143B-4F75-410E-B62A-BB9B99F10714', 2, 'O'),
('1D9AC610-1671-421D-A863-BEE97040968E', 4, 'I'),
('EEADC8D2-EC72-4187-B90C-C758D93D3B72', 2, 'S'),
('958F8F6B-3674-4AE4-BB15-D47C45A64CA2', 3, 'B'),
('8B3DD377-1980-47A2-BE04-E84E36BC9621', 2, 'O'),
('6C0F770A-928D-47E4-84B1-EB5F02C0A482', 4, 'I'),
('83FC1748-DCE4-44D1-A978-01534C145B71', 2, 'S'),
('B964BFD9-4921-4277-8E98-0C1023C46692', 4, 'B'),
('6B4C3D20-52B0-4428-AB8D-0EA1B349BFE1', 3, 'O'),
('0E24F286-6ED6-437B-9DA8-102BAB22D83C', 2, 'I'),
('814AFB02-B802-4322-B072-1DCEF805AF44', 4, 'S'),
('38BBB325-7E59-4ECA-9F90-1DEB89299DAD', 2, 'B'),
('44628EAE-92B2-4B6D-9365-2AAD4AACEF77', 3, 'O'),
('F8C70D02-7905-4FA9-A1D8-31729FA07F70', 2, 'I'),
('5BFF44F5-94EB-45F5-912E-37C333820E62', 4, 'S'),
('B0FDA9E3-223F-4C9E-8AA5-4692BA585743', 3, 'B'),
('C01D1F38-71AF-4EE9-808E-67100F545ABE', 2, 'O'),
('C2344D67-FD0B-4F53-AB09-768952CA7FC6', 4, 'I'),
('94265C2E-B0CA-4FF0-91CA-92061B71C965', 2, 'S'),
('780AD71A-F2C9-4EE5-9B39-B868D8DA88AB', 3, 'B'),
('68E2143B-4F75-410E-B62A-BB9B99F10714', 2, 'O'),
('1D9AC610-1671-421D-A863-BEE97040968E', 4, 'I'),
('EEADC8D2-EC72-4187-B90C-C758D93D3B72', 2, 'S'),
('958F8F6B-3674-4AE4-BB15-D47C45A64CA2', 3, 'B'),
('8B3DD377-1980-47A2-BE04-E84E36BC9621', 2, 'O'),
('6C0F770A-928D-47E4-84B1-EB5F02C0A482', 4, 'I'),
('83FC1748-DCE4-44D1-A978-01534C145B71', 2, 'S'),
('B964BFD9-4921-4277-8E98-0C1023C46692', 4, 'B'),
('6B4C3D20-52B0-4428-AB8D-0EA1B349BFE1', 3, 'O'),
('0E24F286-6ED6-437B-9DA8-102BAB22D83C', 2, 'I'),
('814AFB02-B802-4322-B072-1DCEF805AF44', 4, 'S'),
('38BBB325-7E59-4ECA-9F90-1DEB89299DAD', 2, 'B'),
('44628EAE-92B2-4B6D-9365-2AAD4AACEF77', 3, 'O'),
('F8C70D02-7905-4FA9-A1D8-31729FA07F70', 2, 'I'),
('5BFF44F5-94EB-45F5-912E-37C333820E62', 4, 'S'),
('B0FDA9E3-223F-4C9E-8AA5-4692BA585743', 3, 'B'),
('C01D1F38-71AF-4EE9-808E-67100F545ABE', 2, 'O'),
('C2344D67-FD0B-4F53-AB09-768952CA7FC6', 4, 'I'),
('94265C2E-B0CA-4FF0-91CA-92061B71C965', 2, 'S'),
('780AD71A-F2C9-4EE5-9B39-B868D8DA88AB', 3, 'B'),
('68E2143B-4F75-410E-B62A-BB9B99F10714', 2, 'O'),
('1D9AC610-1671-421D-A863-BEE97040968E', 4, 'I'),
('EEADC8D2-EC72-4187-B90C-C758D93D3B72', 2, 'S'),
('958F8F6B-3674-4AE4-BB15-D47C45A64CA2', 3, 'B'),
('8B3DD377-1980-47A2-BE04-E84E36BC9621', 2, 'O'),
('6C0F770A-928D-47E4-84B1-EB5F02C0A482', 4, 'I');
INSERT INTO cabin (
    ship_code,
    cabin_capacity,
    cabin_class
) VALUES 
('83FC1748-DCE4-44D1-A978-01534C145B71', 2, 'S'),
('B964BFD9-4921-4277-8E98-0C1023C46692', 4, 'B'),
('6B4C3D20-52B0-4428-AB8D-0EA1B349BFE1', 3, 'O'),
('0E24F286-6ED6-437B-9DA8-102BAB22D83C', 2, 'I'),
('814AFB02-B802-4322-B072-1DCEF805AF44', 4, 'S'),
('38BBB325-7E59-4ECA-9F90-1DEB89299DAD', 2, 'B'),
('44628EAE-92B2-4B6D-9365-2AAD4AACEF77', 3, 'O'),
('F8C70D02-7905-4FA9-A1D8-31729FA07F70', 2, 'I'),
('5BFF44F5-94EB-45F5-912E-37C333820E62', 4, 'S'),
('B0FDA9E3-223F-4C9E-8AA5-4692BA585743', 3, 'B'),
('C01D1F38-71AF-4EE9-808E-67100F545ABE', 2, 'O'),
('C2344D67-FD0B-4F53-AB09-768952CA7FC6', 4, 'I'),
('94265C2E-B0CA-4FF0-91CA-92061B71C965', 2, 'S'),
('780AD71A-F2C9-4EE5-9B39-B868D8DA88AB', 3, 'B'),
('68E2143B-4F75-410E-B62A-BB9B99F10714', 2, 'O'),
('1D9AC610-1671-421D-A863-BEE97040968E', 4, 'I'),
('EEADC8D2-EC72-4187-B90C-C758D93D3B72', 2, 'S'),
('958F8F6B-3674-4AE4-BB15-D47C45A64CA2', 3, 'B'),
('8B3DD377-1980-47A2-BE04-E84E36BC9621', 2, 'O'),
('6C0F770A-928D-47E4-84B1-EB5F02C0A482', 4, 'I'),
('83FC1748-DCE4-44D1-A978-01534C145B71', 2, 'S'),
('B964BFD9-4921-4277-8E98-0C1023C46692', 4, 'B'),
('6B4C3D20-52B0-4428-AB8D-0EA1B349BFE1', 3, 'O'),
('0E24F286-6ED6-437B-9DA8-102BAB22D83C', 2, 'I'),
('814AFB02-B802-4322-B072-1DCEF805AF44', 4, 'S'),
('38BBB325-7E59-4ECA-9F90-1DEB89299DAD', 2, 'B'),
('44628EAE-92B2-4B6D-9365-2AAD4AACEF77', 3, 'O'),
('F8C70D02-7905-4FA9-A1D8-31729FA07F70', 2, 'I'),
('5BFF44F5-94EB-45F5-912E-37C333820E62', 4, 'S'),
('B0FDA9E3-223F-4C9E-8AA5-4692BA585743', 3, 'B'),
('C01D1F38-71AF-4EE9-808E-67100F545ABE', 2, 'O'),
('C2344D67-FD0B-4F53-AB09-768952CA7FC6', 4, 'I'),
('94265C2E-B0CA-4FF0-91CA-92061B71C965', 2, 'S'),
('780AD71A-F2C9-4EE5-9B39-B868D8DA88AB', 3, 'B'),
('68E2143B-4F75-410E-B62A-BB9B99F10714', 2, 'O'),
('1D9AC610-1671-421D-A863-BEE97040968E', 4, 'I'),
('EEADC8D2-EC72-4187-B90C-C758D93D3B72', 2, 'S'),
('958F8F6B-3674-4AE4-BB15-D47C45A64CA2', 3, 'B'),
('8B3DD377-1980-47A2-BE04-E84E36BC9621', 2, 'O'),
('6C0F770A-928D-47E4-84B1-EB5F02C0A482', 4, 'I');

INSERT INTO tour (
    tour_number,
    tour_name,
    tour_description,
    tour_hours,
    tour_cost_pp,
    tour_wchair_access,
    tour_starttime,
    tour_min_participants,
    tour_when_code,
    port_code
) VALUES 
(101, 'Sunset Cruise', 'Enjoy a scenic sunset cruise along the coastline', 2.0, 5000.00, 'Y', '18:00:00', 10, '4CE8358F-8379-40AB-B0E0-06011778BF09', 'ECA2C79B-696A-4EF0-B783-600222B1D0AF'),
(102, 'City Sightseeing Tour', 'Explore the citys famous landmarks and attractions', 3.0, 7000.00, 'N', '09:00:00', 5, 'EDBB7D3C-3655-4A9B-AAA0-06426AA53493', '72FE4707-D32A-4864-B59A-68F37B4D3B32'),
(103, 'Island Hopping Adventure', 'Hop between islands and discover hidden gems', 4.0, 9000.00, 'Y', '10:30:00', 8, 'ECDF571C-CBEB-44AB-B0A0-0A36F95CF991', 'FB575043-101C-4C7C-8B0D-6D2897235027'),
(104, 'Historical Walking Tour', 'Take a guided walk through the citys rich history', 2.0, 4500.00, 'N', '13:00:00', 6, 'C44FF39E-9D38-40A4-80E7-0C1F9F8FB5DA', '2D2F8B1C-4098-4128-AC55-78B2F03AE878'),
(105, 'Nature Trekking Expedition', 'Embark on an adventurous trek through scenic trails', 5.0, 8000.00, 'Y', '07:30:00', 12, 'E7B9EDDE-C71C-4353-A2FB-0E0C24A90921', 'E2F93256-33B5-4999-B5D7-82407B3009E2'),
(106, 'Underwater Adventure', 'Explore vibrant marine life on a scuba diving expedition', 4.0, 8500.00, 'Y', '11:00:00', 6, '68763E70-5ECC-485B-975B-0E9350A02852', '415B0D8A-64FD-44E8-82C2-87672230FBD2'),
(107, 'Cultural Heritage Tour', 'Immerse yourself in the cultural heritage of the region', 3.0, 7000.00, 'N', '14:00:00', 8, 'C6652842-E45E-42B0-BD04-0EF12605FA79', '5704B588-2843-461F-8DF9-8B72356F85EA'),
(110, 'Gastronomic Delights Tour', 'Savor the flavors of the local cuisine on a culinary tour', 4.0, 7500.00, 'N', '12:30:00', 6, 'AB79E860-1C06-4974-B7A5-16D2A4434090', 'B461FF48-4C2D-4844-8E61-8F528D4CF045'),
(111, 'Coastal Kayaking Expedition', 'Paddle along the picturesque coastline on a kayaking adventure', 3.0, 6500.00, 'Y', '08:00:00', 4, '4CE8358F-8379-40AB-B0E0-06011778BF09', '9A99BD17-CB17-446D-8FE3-A53C6DF282E6'),
(112, 'Art and Architecture Tour', 'Discover the artistic and architectural wonders of the city', 3.0, 7000.00, 'N', '16:00:00', 8, 'EDBB7D3C-3655-4A9B-AAA0-06426AA53493', 'ECA2C79B-696A-4EF0-B783-600222B1D0AF');

--tourlanguage
INSERT INTO [tour_lang] (
    lang_code,
    tour_id 
) VALUES 
    ('en', '00DC0895-062B-457A-B908-27327C700BB5'),
    ('es', '963E1469-CEDE-47FD-B7EA-3D631748D7FC'),
    ('jp', '527D4E25-A5A3-46A9-BBF0-57982091E599'),
    ('ko', '86F189FB-37FF-4BC7-8E89-7E2918ED9E8C'),
    ('zh', 'EBC6065E-076C-406A-9629-A12F3E50CFF5'),
    ('en', '7F509740-5F71-4C34-801F-AB9FE0F7E543'),
    ('es', '8EBA2741-4EAA-42B2-8106-CF5D3FB9BEB8'),
    ('jp', '58DB20C1-72C2-41FC-87CD-D31ACF9E754F'),
    ('ko', '39DDCCEC-8821-41DA-8397-E04B48882770'),
    ('zh', '1633B154-BFBC-4627-A452-F2D8EBB3FA94');
--cruise

INSERT INTO cruise(
    cruise_name,
    cruise_description,
    ship_code
) VALUES (
    'Tropical Paradise Cruise',
    'Experience the ultimate relaxation in our tropical paradise cruise, where you can unwind amidst stunning ocean views and indulge in luxurious amenities.',
    '83FC1748-DCE4-44D1-A978-01534C145B71'
), (
    'Adventure Explorer Cruise',
    'Embark on an adventurous journey filled with excitement and exploration on our explorer cruise, where youll discover hidden treasures and breathtaking landscapes.',
    'B964BFD9-4921-4277-8E98-0C1023C46692'
), (
    'Majestic Seas Cruise',
    'Sail through the majestic seas and immerse yourself in the beauty of nature while enjoying world-class entertainment and exceptional service.',
    '6B4C3D20-52B0-4428-AB8D-0EA1B349BFE1'
), (
    'Serenity Escape Cruise',
    'Escape to serenity on our tranquil cruise, where you can rejuvenate your mind, body, and soul amidst serene ocean waves and breathtaking sunsets.',
    '0E24F286-6ED6-437B-9DA8-102BAB22D83C'
), (
    'Luxury Oasis Cruise',
    'Indulge in pure luxury and opulence on our oasis cruise, where every moment is tailored to exceed your expectations and fulfill your every desire.',
    '814AFB02-B802-4322-B072-1DCEF805AF44'
), (
    'Royal Elegance Cruise',
    'Experience the epitome of royal elegance and sophistication on our exclusive cruise, where every detail is meticulously crafted to perfection.',
    '38BBB325-7E59-4ECA-9F90-1DEB89299DAD'
), (
    'Enchanted Voyage Cruise',
    'Embark on an enchanted voyage filled with wonder and magic, where dreams come true and memories are made to last a lifetime.',
    '44628EAE-92B2-4B6D-9365-2AAD4AACEF77'
), (
    'Sunset Bliss Cruise',
    'Savor the magic of sunset on our blissful cruise, where every moment is bathed in golden hues and accompanied by gentle ocean breezes.',
    'F8C70D02-7905-4FA9-A1D8-31729FA07F70'
), (
    'Island Paradise Cruise',
    'Discover the allure of island paradise on our exotic cruise, where pristine beaches, azure waters, and lush landscapes await your exploration.',
    '5BFF44F5-94EB-45F5-912E-37C333820E62'
), (
    'Mystic Odyssey Cruise',
    'Embark on a mystical odyssey to distant lands and ancient wonders, where each port of call unveils a new chapter of intrigue and adventure.',
    'B0FDA9E3-223F-4C9E-8AA5-4692BA585743'
), (
    'Celestial Harmony Cruise',
    'Experience celestial harmony on our transcendent cruise, where the beauty of the cosmos meets the serenity of the open sea, creating an unforgettable journey.',
    'C01D1F38-71AF-4EE9-808E-67100F545ABE'
), (
    'Gourmet Delight Cruise',
    'Satisfy your culinary desires on our gourmet delight cruise, where world-class chefs tantalize your taste buds with exquisite flavors from around the globe.',
    'C2344D67-FD0B-4F53-AB09-768952CA7FC6'
), (
    'Exotic Adventure Cruise',
    'Embark on an exotic adventure to remote corners of the world, where untamed wilderness and thrilling experiences await your discovery.',
    '94265C2E-B0CA-4FF0-91CA-92061B71C965'
), (
    'Grand Splendor Cruise',
    'Step into grand splendor and elegance on our luxurious cruise, where every detail exudes sophistication and every moment is a celebration of opulence.',
    '780AD71A-F2C9-4EE5-9B39-B868D8DA88AB'
), (
    'Oceanic Escape Cruise',
    'Escape to the open sea on our oceanic cruise, where endless horizons and boundless possibilities create the perfect backdrop for your unforgettable journey.',
    '68E2143B-4F75-410E-B62A-BB9B99F10714'
), (
    'Cultural Odyssey Cruise',
    'Embark on a cultural odyssey to vibrant destinations steeped in history, where ancient traditions and modern marvels converge to create a rich tapestry of experiences.',
    '1D9AC610-1671-421D-A863-BEE97040968E'
), (
    'Golden Horizon Cruise',
    'Set sail towards the golden horizon on our spectacular cruise, where each day brings new adventures and each night is filled with starlit romance.',
    'EEADC8D2-EC72-4187-B90C-C758D93D3B72'
), (
    'Sapphire Seas Cruise',
    'Explore the beauty of sapphire seas on our enchanting cruise, where crystal-clear waters and pristine coastlines beckon you to embark on a voyage of discovery.',
    '958F8F6B-3674-4AE4-BB15-D47C45A64CA2'
), (
    'Voyage of Discovery Cruise',
    'Embark on a voyage of discovery to uncharted territories and hidden gems, where every day holds the promise of new experiences and unforgettable moments.',
    '8B3DD377-1980-47A2-BE04-E84E36BC9621'
), (
    'Eternal Sunshine Cruise',
    'Bask in eternal sunshine on our radiant cruise, where azure skies and shimmering waters create the perfect backdrop for your blissful escape.',
    '6C0F770A-928D-47E4-84B1-EB5F02C0A482'
);
--touroffer
INSERT INTO touroffer(
    touroffer_date,
    tour_id
) VALUES (
    '2024-02-15',
    '00DC0895-062B-457A-B908-27327C700BB5'
), (
    '2024-03-20',
    '963E1469-CEDE-47FD-B7EA-3D631748D7FC'
), (
    '2024-04-10',
    '527D4E25-A5A3-46A9-BBF0-57982091E599'
), (
    '2024-05-05',
    '86F189FB-37FF-4BC7-8E89-7E2918ED9E8C'
), (
    '2024-06-12',
    'EBC6065E-076C-406A-9629-A12F3E50CFF5'
), (
    '2024-07-08',
    '7F509740-5F71-4C34-801F-AB9FE0F7E543'
), (
    '2024-08-25',
    '8EBA2741-4EAA-42B2-8106-CF5D3FB9BEB8'
), (
    '2024-09-03',
    '58DB20C1-72C2-41FC-87CD-D31ACF9E754F'
), (
    '2024-10-19',
    '39DDCCEC-8821-41DA-8397-E04B48882770'
), (
    '2024-11-28',
    '1633B154-BFBC-4627-A452-F2D8EBB3FA94'
);
--cruise_port
INSERT INTO cruise_port(
    cruise_id,
    cp_datetime,
    cp_depart_arrive,
    port_code
) VALUES (
    'F766F821-F0E1-4175-8D9E-003A76168E04',
    '2024-02-15 08:00:00',
    'Y',
    'F6665100-0794-43BB-B9D1-09B31CB3ACD5'
), (
    '019A866C-7F07-49C5-B90A-1D2BFC3D1F33',
    '2024-03-20 09:30:00',
    'N',
    '51B26145-4BA4-4279-BE31-239C1D753BC1'
), (
    '1B0C7C04-22DD-4E54-9006-215C9A9612D0',
    '2024-04-10 11:45:00',
    'Y',
    '8B9268E5-D775-4F14-8D28-29D475EFDD99'
), (
    '69660903-A765-4BAE-A9E2-3E3238DF78B2',
    '2024-05-05 13:20:00',
    'N',
    '2D13B12B-7C92-4672-8A0C-33AE6D05780D'
), (
    'A2171100-45AD-418A-8CF3-3F3660F7B0B3',
    '2024-06-12 16:10:00',
    'Y',
    '99C148D1-9820-4A15-AEAD-34AEDA7FFE06'
), (
    '69A9E2F7-D6BA-4CC2-9279-4702A8EDDC46',
    '2024-07-08 18:45:00',
    'N',
    'CFD52FAB-A7B2-47E5-972D-367ED3E273B6'
), (
    'AD899482-CF30-4C9C-AF27-4F94382A846F',
    '2024-08-25 20:30:00',
    'Y',
    'A1BA25FD-82B4-4BDB-AEAA-3753877D58D5'
), (
    '3C7F89D5-4761-4008-9EDA-529B773C760F',
    '2024-09-03 22:15:00',
    'N',
    '4785597E-A32B-416E-8D66-3C23ED936773'
), (
    '3872DF02-9F0C-4076-ACB9-532EC8B17AD1',
    '2024-10-19 01:00:00',
    'Y',
    'B691E09A-6F6C-4908-B3E9-41561961ED0E'
), (
    '54B30558-C468-4ACC-9DD4-5BB82115C9C1',
    '2024-11-28 03:45:00',
    'N',
    '8832A141-D6A2-4F35-B10C-459C64144DF5'
), (
    'B3B2B127-2C37-463D-8A0D-68954C41CA6E',
    '2024-12-15 05:30:00',
    'Y',
    '57FFBBDD-37F4-43EE-9225-4901860AF1DE'
), (
    '1BA1E9CF-60F2-449D-9663-6FA97499B724',
    '2025-01-20 08:00:00',
    'N',
    '59AAFDCF-7366-4DA9-BD01-4993438240A8'
), (
    '35BDBB7A-3F91-49A2-95B9-7633C655C729',
    '2025-02-10 10:30:00',
    'Y',
    'C1378B07-1581-470F-80AD-4DE667AD13EE'
), (
    '2D588467-5D86-408D-A79A-8029B2CFA71D',
    '2025-03-05 13:00:00',
    'N',
    'ECA2C79B-696A-4EF0-B783-600222B1D0AF'
), (
    'E940A394-DEBB-4176-A962-8BA2426C3953',
    '2025-04-22 15:45:00',
    'Y',
    '72FE4707-D32A-4864-B59A-68F37B4D3B32'
), (
    '8FC75D3B-DD5D-4902-BCCB-8EE20D67328E',
    '2025-05-18 18:30:00',
    'N',
    'FB575043-101C-4C7C-8B0D-6D2897235027'
), (
    '21915DB5-30C4-4F16-926B-A33D2E857632',
    '2025-06-30 21:00:00',
    'Y',
    '2D2F8B1C-4098-4128-AC55-78B2F03AE878'
), (
    'CDB11BFE-CA12-4849-8312-EA709CA677BC',
    '2025-07-10 23:30:00',
    'N',
    'E2F93256-33B5-4999-B5D7-82407B3009E2'
), (
    'D12007EA-59E7-4CFF-86AF-ED8C3DB1E38E',
    '2025-08-29 02:15:00',
    'Y',
    'BE55EBD9-82DB-4DE4-8FD3-83C443FEB0F2'
), (
    '62F9EE0F-27D3-49D8-AE75-FCBD8DDBBE18',
    '2025-09-15 05:00:00',
    'N',
    '415B0D8A-64FD-44E8-82C2-87672230FBD2'
), (
    'E940A394-DEBB-4176-A962-8BA2426C3953',
    '2025-10-12 07:45:00',
    'Y',
    '5704B588-2843-461F-8DF9-8B72356F85EA'
), (
    '8FC75D3B-DD5D-4902-BCCB-8EE20D67328E',
    '2025-11-20 10:30:00',
    'N',
    'C5611CEB-328A-4D25-A67A-8E6E9BEBE7F3'
), (
    '21915DB5-30C4-4F16-926B-A33D2E857632',
    '2025-12-03 13:15:00',
    'Y',
    'B461FF48-4C2D-4844-8E61-8F528D4CF045'
);


--manifest
INSERT INTO manifest(
    passenger_id,
    cruise_id,
    mainfest_board_time,
    ship_code,
    cabin_no
) VALUES (
    '4304B42E-777D-46C0-A145-05C2D851BF62',
    'F766F821-F0E1-4175-8D9E-003A76168E04',
    '2024-02-15 08:00:00',
    '83FC1748-DCE4-44D1-A978-01534C145B71',
    '5BACE4C9-568D-490C-9E75-604EFF639443'
), (
    'FD944F5F-B2C8-42A0-812D-0B8C4D8D9C22',
    '019A866C-7F07-49C5-B90A-1D2BFC3D1F33',
    '2024-03-20 09:30:00',
    '83FC1748-DCE4-44D1-A978-01534C145B71',
    'C61462A7-CAAF-4859-B3BD-614713727245'
), (
    '33FA5045-78D9-4DA1-BA25-0C44C9A0F946',
    '1B0C7C04-22DD-4E54-9006-215C9A9612D0',
    '2024-04-10 11:45:00',
    '83FC1748-DCE4-44D1-A978-01534C145B71',
    'B91FACD1-91EC-4217-B520-649FEA662471'
), (
    '421096CE-45CF-4A63-B5F7-0DCFC0B9B3DD',
    '69660903-A765-4BAE-A9E2-3E3238DF78B2',
    '2024-05-05 13:20:00',
    '83FC1748-DCE4-44D1-A978-01534C145B71',
    '01E78F89-24C0-4120-8821-CE740F9940BD'
), (
    '3FE26CE2-0DCB-461D-9983-118DCCDC2320',
    'A2171100-45AD-418A-8CF3-3F3660F7B0B3',
    '2024-06-12 16:10:00',
    '83FC1748-DCE4-44D1-A978-01534C145B71',
    'A9194947-3BD9-4CE1-AAE4-E9284D355F8F'
);
INSERT INTO manifest(
    passenger_id,
    cruise_id,
    mainfest_board_time,
    ship_code,
	cabin_no
) VALUES (
    'BD351A0D-B64A-49A2-A756-1F645976D26B',
    '69A9E2F7-D6BA-4CC2-9279-4702A8EDDC46',
    '2024-07-08 18:45:00',
    '83FC1748-DCE4-44D1-A978-01534C145B71',
    'AE4D44D7-9038-44BF-B169-FF9A8898F887'
), (
    '4846494F-2124-404B-B3D1-27E69FD7D9F0',
    'AD899482-CF30-4C9C-AF27-4F94382A846F',
    '2024-08-25 20:30:00',
    'B964BFD9-4921-4277-8E98-0C1023C46692',
    '17DB4A6C-239B-497B-96CA-33094C58D867'
), (
    '6E542927-C927-4A75-8096-379B611FCCAE',
    '3C7F89D5-4761-4008-9EDA-529B773C760F',
    '2024-09-03 22:15:00',
    'B964BFD9-4921-4277-8E98-0C1023C46692',
    'B78E1138-4D37-40E5-8B21-3CB2B884BA79'
), (
    '90636F88-C460-4AE6-A21E-37CB81C19117',
    '3872DF02-9F0C-4076-ACB9-532EC8B17AD1',
    '2024-10-19 01:00:00',
    'B964BFD9-4921-4277-8E98-0C1023C46692',
    'DDF72C81-1886-4888-B11F-6EC36C491F2F'
), (
    'D9E18876-C060-47E2-801B-394270B17501',
    '54B30558-C468-4ACC-9DD4-5BB82115C9C1',
    '2024-11-28 03:45:00',
    'B964BFD9-4921-4277-8E98-0C1023C46692',
    '4E7F4CFC-92B6-48CA-88AD-7896657FE4A3'
), (
    '5CAA3E0F-7FAF-4864-8BEF-3C2EA99255FD',
    'B3B2B127-2C37-463D-8A0D-68954C41CA6E',
    '2024-12-15 06:30:00',
    'B964BFD9-4921-4277-8E98-0C1023C46692',
    '9A9869D5-986B-4740-9E65-A64856BA9ACB'
), (
    'A8C9150D-7856-447C-B238-4E1FE7AFD42C',
    '1BA1E9CF-60F2-449D-9663-6FA97499B724',
    '2025-01-30 09:15:00',
    '6B4C3D20-52B0-4428-AB8D-0EA1B349BFE1',
    '793CC7EB-7E98-40B4-8774-19D7FC2C2395'
), (
    '79199DD7-074D-4949-91CE-4F2C9629A51C',
    '35BDBB7A-3F91-49A2-95B9-7633C655C729',
    '2025-02-18 12:00:00',
    '6B4C3D20-52B0-4428-AB8D-0EA1B349BFE1',
    'DC40ABC9-EEC3-4967-86CE-3580896BFF49'
), (
    'B0EE8BCB-9C67-4D28-B2CA-59D9EA5FCCB7',
    '2D588467-5D86-408D-A79A-8029B2CFA71D',
    '2025-03-25 14:45:00',
    '6B4C3D20-52B0-4428-AB8D-0EA1B349BFE1',
    '0D68C496-BFE0-4DC5-80F2-91D9C2B107BC'
), (
    '72118AD2-762D-4174-9863-9DF7F078B50D',
    'E940A394-DEBB-4176-A962-8BA2426C3953',
    '2025-04-08 17:30:00',
    '6B4C3D20-52B0-4428-AB8D-0EA1B349BFE1',
    'E5B5413B-E692-43E3-9F4D-A684E4D6812F'
), (
    '7B72DDAC-1CB4-4103-AFBA-9FAB40F05265',
    '8FC75D3B-DD5D-4902-BCCB-8EE20D67328E',
    '2025-05-15 20:15:00',
    '6B4C3D20-52B0-4428-AB8D-0EA1B349BFE1',
    '682C9A95-381A-46D6-B3E4-ACF8DC15E63E'
), (
    '7EE57DC7-0825-4644-8E64-A11A283FFA42',
    '21915DB5-30C4-4F16-926B-A33D2E857632',
    '2025-06-30 22:00:00',
    '0E24F286-6ED6-437B-9DA8-102BAB22D83C',
    'E1B568D6-A95E-4415-ADA8-51E25B7F1FDC'
), (
    'FFFC0500-1900-4251-886D-A7BF3A934FD5',
    'CDB11BFE-CA12-4849-8312-EA709CA677BC',
    '2025-07-20 00:45:00',
    '0E24F286-6ED6-437B-9DA8-102BAB22D83C',
    '417A7C8D-C6B1-459F-BB04-6CFA686D4D49'
), (
    '9BF3EFBB-D073-445C-86C2-AA4B56D6812F',
    'D12007EA-59E7-4CFF-86AF-ED8C3DB1E38E',
    '2025-08-05 03:30:00',
    '0E24F286-6ED6-437B-9DA8-102BAB22D83C',
    '763C9079-314E-455C-BA85-84629C7301B3'
), (
    'D78CDD14-0C45-4CE0-A714-D541B74FD71B',
    '62F9EE0F-27D3-49D8-AE75-FCBD8DDBBE18',
    '2025-09-10 06:15:00',
    '0E24F286-6ED6-437B-9DA8-102BAB22D83C',
    '544C9756-5E8D-46B6-8522-B10A63C59CBB'
);

--participant
INSERT INTO participant(
    tour_paid,
    cruise_id,
    passenger_id,
    touroffer_date,
    tour_id
) VALUES (
    'Y',
    'F766F821-F0E1-4175-8D9E-003A76168E04',
    '4304B42E-777D-46C0-A145-05C2D851BF62',
    '2024-02-15',
    '00DC0895-062B-457A-B908-27327C700BB5'
), (
    'N',
    '019A866C-7F07-49C5-B90A-1D2BFC3D1F33',
    'FD944F5F-B2C8-42A0-812D-0B8C4D8D9C22',
    '2024-03-20',
    '963E1469-CEDE-47FD-B7EA-3D631748D7FC'
), (
    'Y',
    '1B0C7C04-22DD-4E54-9006-215C9A9612D0',
    '33FA5045-78D9-4DA1-BA25-0C44C9A0F946',
    '2024-04-10',
    '527D4E25-A5A3-46A9-BBF0-57982091E599'
), (
    'N',
    '69660903-A765-4BAE-A9E2-3E3238DF78B2',
    '421096CE-45CF-4A63-B5F7-0DCFC0B9B3DD',
    '2024-05-05',
    '86F189FB-37FF-4BC7-8E89-7E2918ED9E8C'
), (
    'Y',
    'A2171100-45AD-418A-8CF3-3F3660F7B0B3',
    '3FE26CE2-0DCB-461D-9983-118DCCDC2320',
    '2024-06-12',
    'EBC6065E-076C-406A-9629-A12F3E50CFF5'
), (
    'N',
    '69A9E2F7-D6BA-4CC2-9279-4702A8EDDC46',
    'BD351A0D-B64A-49A2-A756-1F645976D26B',
    '2024-07-08',
    '7F509740-5F71-4C34-801F-AB9FE0F7E543'
), (
    'Y',
    'AD899482-CF30-4C9C-AF27-4F94382A846F',
    '4846494F-2124-404B-B3D1-27E69FD7D9F0',
    '2024-08-25',
    '8EBA2741-4EAA-42B2-8106-CF5D3FB9BEB8'
), (
    'N',
    '3C7F89D5-4761-4008-9EDA-529B773C760F',
    '6E542927-C927-4A75-8096-379B611FCCAE',
    '2024-09-03',
    '58DB20C1-72C2-41FC-87CD-D31ACF9E754F'
), (
    'Y',
    '3872DF02-9F0C-4076-ACB9-532EC8B17AD1',
    '90636F88-C460-4AE6-A21E-37CB81C19117',
    '2024-10-19',
    '39DDCCEC-8821-41DA-8397-E04B48882770'
), (
    'N',
    '54B30558-C468-4ACC-9DD4-5BB82115C9C1',
    'D9E18876-C060-47E2-801B-394270B17501',
    '2024-11-28',
    '1633B154-BFBC-4627-A452-F2D8EBB3FA94'
);









