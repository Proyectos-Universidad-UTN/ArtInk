USE Artink 
GO

IF NOT EXISTS(SELECT 1 FROM Distrito WHERE Id = 1)
BEGIN

    SET IDENTITY_INSERT Distrito ON;

    INSERT INTO dbo.Distrito
    (Id,[Nombre],[IdCanton])
    VALUES (1, N'Carmen',1)
        ,(2, N'Merced',1)
        ,(3, N'Hospital',1)
        ,(4, N'Catedral',1)
        ,(5, N'Zapote',1)
        ,(6, N'San Francisco de Dos Ríos',1)
        ,(7, N'Uruca',1)
        ,(8, N'Mata Redonda',1)
        ,(9, N'Pavas',1)
        ,(10, N'Hatillo',1)
        ,(11, N'San Sebastián',1)
        ,(12, N'Escazú',2)
        ,(13, N'San Antonio',2)
        ,(14, N'San Rafael',2)
        ,(15, N'Desamparados',3)
        ,(16, N'San Miguel',3)
        ,(17, N'San Juan de Dios',3)
        ,(18, N'San Rafael Arriba',3)
        ,(19, N'San Antonio',3)
        ,(20, N'Frailes',3)
        ,(21, N'Patarra',3)
        ,(22, N'San Cristobal',3)
        ,(23, N'Rosario',3)
        ,(24, N'Damas',3)
        ,(25, N'San Rafael Abajo',3)
        ,(26, N'Gravilias',3)
        ,(27, N'Los Guido',3)
        ,(28, N'Santiago',4)
        ,(29, N'Mercedes Sur',4)
        ,(30, N'Barbacoas',4)
        ,(31, N'Grifo Alto',4)
        ,(32, N'San Rafael',4)
        ,(33, N'Candelarita',4)
        ,(34, N'Desamparaditos',4)
        ,(35, N'San Antonio',4)
        ,(36, N'Chires',4)
        ,(37, N'San Marcos',5)
        ,(38, N'San Lorenzo',5)
        ,(39, N'San Carlos',5)
        ,(40, N'Aserrí',6)
        ,(41, N'Tarbaca',6)
        ,(42, N'Vuelta de Jorco',6)
        ,(43, N'San Gabriel',6)
        ,(44, N'Legua',6)
        ,(45, N'Monterrey',6)
        ,(46, N'Salitrillos',6)
        ,(47, N'Colón',7)
        ,(48, N'Guayabo',7)
        ,(49, N'Tabarcia',7)
        ,(50, N'Piedras Negras',7)
        ,(51, N'Picagres',7)
        ,(52, N'Jaris',7)
        ,(53, N'Quitirrisí',7)
        ,(54, N'Guadalupe',8)
        ,(55, N'San Francisco',8)
        ,(56, N'Calle Blancos',8)
        ,(57, N'Mata de Plátano',8)
        ,(58, N'Ipis',8)
        ,(59, N'Rancho Redondo',8)
        ,(60, N'Purral',8)
        ,(61, N'Santa Ana',9)
        ,(62, N'Salitral',9)
        ,(63, N'Pozos',9)
        ,(64, N'Uruca',9)
        ,(65, N'Piedades',9)
        ,(66, N'Brasil',9)
        ,(67, N'Alajuelita',10)
        ,(68, N'San Josecito',10)
        ,(69, N'San Antonio',10)
        ,(70, N'Concepción',10)
        ,(71, N'San Felipe',10)
        ,(72, N'San Isidro',11)
        ,(73, N'San Rafael',11)
        ,(74, N'Dulce Nombre de Jesús',11)
        ,(75, N'Patalillo',11)
        ,(76, N'Cascajal',11)
        ,(77, N'San Ignacio',12)
        ,(78, N'Guaitil',12)
        ,(79, N'Palmichal',12)
        ,(80, N'Cangrejal',12)
        ,(81, N'Sabanillas',12)
        ,(82, N'San Juan',13)
        ,(83, N'Cinco Esquinas',13)
        ,(84, N'Anselmo Llorente',13)
        ,(85, N'León XIII',13)
        ,(86, N'Colima',13)
        ,(87, N'San Vicente',14)
        ,(88, N'San Jerónimo',14)
        ,(89, N'La Trinidad',14)
        ,(90, N'San Pedro',15)
        ,(91, N'Sabanilla',15)
        ,(92, N'Mercedes',15)
        ,(93, N'San Rafael',15)
        ,(94, N'San Pablo',16)
        ,(95, N'San Pedro',16)
        ,(96, N'San Juan de Mata',16)
        ,(97, N'San Luis',16)
        ,(98, N'Carara',16)
        ,(99, N'Santa María',17)
        ,(100, N'Jardín',17)
        ,(101, N'Copey',17)
        ,(102, N'Curridabat',18)
        ,(103, N'Granadilla',18)
        ,(104, N'Sánchez',18)
        ,(105, N'Tirrases',18)
        ,(106, N'San Isidro de El General',19)
        ,(107, N'El General',19)
        ,(108, N'Daniel Flores',19)
        ,(109, N'Rivas',19)
        ,(110, N'San Pedro',19)
        ,(111, N'Platanares',19)
        ,(112, N'Pejibaye',19)
        ,(113, N'Cajón',19)
        ,(114, N'Barú',19)
        ,(115, N'Río Nuevo',19)
        ,(116, N'Paramo',19)
        ,(117, N'La  Amistad',19)
        ,(118, N'San Pablo',20)
        ,(119, N'San Andrés',20)
        ,(120, N'Llano Bonito',20)
        ,(121, N'San Isidro',20)
        ,(122, N'Santa Cruz',20)
        ,(123, N'San Antonio',20)
        ,(124, N'Alajuela',21)
        ,(125, N'San José',21)
        ,(126, N'Carrizal',21)
        ,(127, N'San Antonio',21)
        ,(128, N'Guácima',21)
        ,(129, N'San Isidro',21)
        ,(130, N'Sabanilla',21)
        ,(131, N'San Rafael',21)
        ,(132, N'Río Segundo',21)
        ,(133, N'Desamparados',21)
        ,(134, N'Turrucares',21)
        ,(135, N'Tambor',21)
        ,(136, N'Garita',21)
        ,(137, N'Sarapiquí',21)
        ,(138, N'San Ramón',22)
        ,(139, N'Santiago',22)
        ,(140, N'San Juan',22)
        ,(141, N'Piedades Norte',22)
        ,(142, N'Piedades Sur',22)
        ,(143, N'San Rafael',22)
        ,(144, N'San Isidro',22)
        ,(145, N'Ángeles',22)
        ,(146, N'Alfaro',22)
        ,(147, N'Volio',22)
        ,(148, N'Concepción',22)
        ,(149, N'Zapotal',22)
        ,(150, N'Peñas Blancas',22)
        ,(151, N'San Lorenzo',22)
        ,(152, N'Grecia',23)
        ,(153, N'San Isidro',23)
        ,(154, N'San José',23)
        ,(155, N'San Roque',23)
        ,(156, N'Tacares',23)
        ,(157, N'Puente de Piedra',23)
        ,(158, N'Bolivar',23)
        ,(159, N'San Mateo',24)
        ,(160, N'Desmonte',24)
        ,(161, N'Jesús María',24)
        ,(162, N'Labrador',24)
        ,(163, N'Atenas',25)
        ,(164, N'Jesús',25)
        ,(165, N'Mercedes',25)
        ,(166, N'San Isidro',25)
        ,(167, N'Concepción',25)
        ,(168, N'San José',25)
        ,(169, N'Santa Eulalia',25)
        ,(170, N'Escobal',25)
        ,(171, N'Naranjo',26)
        ,(172, N'San Miguel',26)
        ,(173, N'San José',26)
        ,(174, N'Cirrí Sur',26)
        ,(175, N'San Jerónimo',26)
        ,(176, N'San Juan',26)
        ,(177, N'El Rosario',26)
        ,(178, N'Palmitos',26)
        ,(179, N'Palmares',27)
        ,(180, N'Zaragoza',27)
        ,(181, N'Buenos Aires',27)
        ,(182, N'Santiago',27)
        ,(183, N'Candelaria',27)
        ,(184, N'Esquipulas',27)
        ,(185, N'La Granja',27)
        ,(186, N'San Pedro',28)
        ,(187, N'San Juan',28)
        ,(188, N'San Rafael',28)
        ,(189, N'Carrillos',28)
        ,(190, N'Sabana Redonda',28)
        ,(191, N'Orotina',29)
        ,(192, N'El Mastate',29)
        ,(193, N'Hacienda Vieja',29)
        ,(194, N'Coyolar',29)
        ,(195, N'La Ceiba',29)
        ,(196, N'Quesada',30)
        ,(197, N'Florencia',30)
        ,(198, N'Buenavista',30)
        ,(199, N'Aguas Zarcas',30)
        ,(200, N'Venecia',30)
        ,(201, N'Pital',30)
        ,(202, N'La Fortuna',30)
        ,(203, N'La Tigra',30)
        ,(204, N'La Palmera',30)
        ,(205, N'Venado',30)
        ,(206, N'Cutris',30)
        ,(207, N'Monterrey',30)
        ,(208, N'Pocosol',30)
        ,(209, N'Zarcero',31)
        ,(210, N'Laguna',31)
        ,(211, N'Tapesco',31)
        ,(212, N'Guadalupe',31)
        ,(213, N'Palmira',31)
        ,(214, N'Zapote',31)
        ,(215, N'Brisas',31)
        ,(216, N'Sarchí Norte',32)
        ,(217, N'Sarchí Sur',32)
        ,(218, N'Toro Amarillo',32)
        ,(219, N'San Pedro',32)
        ,(220, N'Rodríguez',32)
        ,(221, N'Upala',33)
        ,(222, N'Aguas Claras',33)
        ,(223, N'San José O Pizote',33)
        ,(224, N'Bijagua',33)
        ,(225, N'Delicias',33)
        ,(226, N'Dos Ríos',33)
        ,(227, N'Yolillal',33)
        ,(228, N'Canalete',33)
        ,(229, N'Los Chiles',34)
        ,(230, N'Caño Negro',34)
        ,(231, N'El Amparo',34)
        ,(232, N'San Jorge',34)
        ,(233, N'San Rafael',35)
        ,(234, N'Buenavista',35)
        ,(235, N'Cote',35)
        ,(236, N'Katira',35)
        ,(237, N'Río Cuarto',36)
        ,(238, N'Santa Rita',36)
        ,(239, N'Santa Isabel',36)
        ,(240, N'Oriental',37)
        ,(241, N'Occidental',37)
        ,(242, N'Carmen',37)
        ,(243, N'San Nicolás',37)
        ,(244, N'Aguacaliente o San Francisco',37)
        ,(245, N'Guadalupe o Arenilla',37)
        ,(246, N'Corralillo',37)
        ,(247, N'Tierra Blanca',37)
        ,(248, N'Dulce Nombre',37)
        ,(249, N'Llano Grande',37)
        ,(250, N'Quebradilla',37)
        ,(251, N'Paraíso',38)
        ,(252, N'Santiago',38)
        ,(253, N'Orosi',38)
        ,(254, N'Cachí',38)
        ,(255, N'Llanos de Santa Lucía',38)
        ,(256, N'Birrisito',38)
        ,(257, N'Tres Ríos',39)
        ,(258, N'San Diego',39)
        ,(259, N'San Juan',39)
        ,(260, N'San Rafael',39)
        ,(261, N'Concepción',39)
        ,(262, N'Dulce Nombre',39)
        ,(263, N'San Ramón',39)
        ,(264, N'Río Azul',39)
        ,(265, N'Juan Viñas',40)
        ,(266, N'Tucurrique',40)
        ,(267, N'Pejibaye',40)
        ,(268, N'Turrialba',41)
        ,(269, N'La Suiza',41)
        ,(270, N'Peralta',41)
        ,(271, N'Santa Cruz',41)
        ,(272, N'Santa Teresita',41)
        ,(273, N'Pavones',41)
        ,(274, N'Tuis',41)
        ,(275, N'Tayutic',41)
        ,(276, N'Santa Rosa',41)
        ,(277, N'Tres Equis',41)
        ,(278, N'La Isabel',41)
        ,(279, N'Chirripó',41)
        ,(280, N'Pacayas',42)
        ,(281, N'Cervantes',42)
        ,(282, N'Capellades',42)
        ,(283, N'San Rafael',43)
        ,(284, N'Cot',43)
        ,(285, N'Potrero Cerrado',43)
        ,(286, N'Cipreses',43)
        ,(287, N'Santa Rosa',43)
        ,(288, N'El Tejar',44)
        ,(289, N'San Isidro',44)
        ,(290, N'Tobosi',44)
        ,(291, N'Patio de Agua',44)
        ,(292, N'Heredia',45)
        ,(293, N'Mercedes',45)
        ,(294, N'San Francisco',45)
        ,(295, N'Ulloa',45)
        ,(296, N'Varablanca',45)
        ,(297, N'Barva',46)
        ,(298, N'San Pedro',46)
        ,(299, N'San Pablo',46)
        ,(300, N'San Roque',46)
        ,(301, N'Santa Lucía',46)
        ,(302, N'San José de la Montaña',46)

        ,(303, N'Santo Domingo',47)
        ,(304, N'San Vicente',47)
        ,(305, N'San Miguel',47)
        ,(306, N'Paracito',47)
        ,(307, N'Santo Tomás',47)
        ,(308, N'Santa Rosa',47)
        ,(309, N'Tures',47)
        ,(310, N'Pará',47)
        ,(311, N'Santa Bárbara',48)
        ,(312, N'San Pedro',48)
        ,(313, N'San Juan',48)
        ,(314, N'Jesús',48)
        ,(315, N'Santo Domingo',48)
        ,(316, N'Purabá',48)
        ,(317, N'San Rafael',49)
        ,(318, N'San Josecito',49)
        ,(319, N'Santiago',49)
        ,(320, N'Ángeles',49)
        ,(321, N'Concepción',49)
        ,(322, N'San Isidro',50)
        ,(323, N'San José',50)
        ,(324, N'Concepción',50)
        ,(325, N'San Francisco',50)
        ,(326, N'San Antonio',51)
        ,(327, N'La Ribera',51)
        ,(328, N'La Asunción',51)
        ,(329, N'San Joaquín',52)
        ,(330, N'Barrantes',52)
        ,(331, N'Llorente',52)
        ,(332, N'San Pablo',53)
        ,(333, N'Rincón de Sabanilla',53)
        ,(334, N'Puerto Viejo',54)
        ,(335, N'La Virgen',54)
        ,(336, N'Las Horquetas',54)
        ,(337, N'Llanuras del Gaspar',54)
        ,(338, N'Cureña',54)
        ,(339, N'Liberia',55)
        ,(340, N'Cañas Dulces',55)
        ,(341, N'Mayorga',55)
        ,(342, N'Nacascolo',55)
        ,(343, N'Curubandé',55)
        ,(344, N'Nicoya',56)
        ,(345, N'Mansión',56)
        ,(346, N'San Antonio',56)
        ,(347, N'Quebrada Honda',56)
        ,(348, N'Sámara',56)
        ,(349, N'Nosara',56)
        ,(350, N'Belén de Nosarita',56)
        ,(351, N'Santa Cruz',57)
        ,(352, N'Bolsón',57)
        ,(353, N'Veintisiete de Abril',57)
        ,(354, N'Tempate',57)
        ,(355, N'Cartagena',57)
        ,(356, N'Cuajiniquil',57)
        ,(357, N'Diriá',57)
        ,(358, N'Cabo Velas',57)
        ,(359, N'Tamarindo',57)
        ,(360, N'Bagaces',58)
        ,(361, N'La Fortuna',58)
        ,(362, N'Mogote',58)
        ,(363, N'Río Naranjo',58)
        ,(364, N'Filadelfia',59)
        ,(365, N'Palmira',59)
        ,(366, N'Sardinal',59)
        ,(367, N'Belén',59)
        ,(368, N'Cañas',60)
        ,(369, N'Palmira',60)
        ,(370, N'San Miguel',60)
        ,(371, N'Bebedero',60)
        ,(372, N'Porozal',60)
        ,(373, N'Las Juntas',61)
        ,(374, N'Sierra',61)
        ,(375, N'San Juan',61)
        ,(376, N'Colorado',61)
        ,(377, N'Tilarán',62)
        ,(378, N'Quebrada Grande',62)
        ,(379, N'Tronadora',62)
        ,(380, N'Santa Rosa',62)
        ,(381, N'Líbano',62)
        ,(382, N'Tierras Morenas',62)
        ,(383, N'Arenal',62)
        ,(384, N'Cabeceras',62)
        ,(385, N'Carmona',63)
        ,(386, N'Santa Rita',63)
        ,(387, N'Zapotal',63)
        ,(388, N'San Pablo',63)
        ,(389, N'Porvenir',63)
        ,(390, N'Bejuco',63)
        ,(391, N'La Cruz',64)
        ,(392, N'Santa Cecilia',64)
        ,(393, N'La Garita',64)
        ,(394, N'Santa Elena',64)
        ,(395, N'Hojancha',65)
        ,(396, N'Monte Romo',65)
        ,(397, N'Puerto Carrillo',65)
        ,(398, N'Huacas',65)
        ,(399, N'Matambú',65)
        ,(400, N'Puntarenas',66)
        ,(401, N'Pitahaya',66)
        ,(402, N'Chomes',66)
        ,(403, N'Lepanto',66)
        ,(404, N'Paquera',66)
        ,(405, N'Manzanillo',66)
        ,(406, N'Guacimal',66)
        ,(407, N'Barranca',66)
        ,(408, N'Isla del Coco',66)
        ,(409, N',Cóbano',66)
        ,(410, N'Chacarita',66)
        ,(411, N'Chira',66)
        ,(412, N'Acapulco',66)
        ,(413, N'El Roble',66)
        ,(414, N'Arancibia',66)
        ,(415, N'Espíritu Santo',67)
        ,(416, N'San Juan Grande',67)
        ,(417, N'Macacona',67)
        ,(418, N'San Rafael',67)
        ,(419, N'San Jerónimo',67)
        ,(420, N'Caldera',67)
        ,(421, N'Buenos Aires',68)
        ,(422, N'Volcán',68)
        ,(423, N'Potrero Grande',68)
        ,(424, N'Boruca',68)
        ,(425, N'Pilas',68)
        ,(426, N'Colinas',68)
        ,(427, N'Chánguena',68)
        ,(428, N'Biolley',68)
        ,(429, N'Brunka',68)
        ,(430, N'Miramar',69)
        ,(431, N'La Unión',69)
        ,(432, N'San Isidro',69)
        ,(433, N'Puerto Cortés',70)
        ,(434, N'Palmar',70)
        ,(435, N'Sierpe',70)
        ,(436, N'Bahía Ballena',70)
        ,(437, N'Piedras Blancas',70)
        ,(438, N'Bahía Drake',70)
        ,(439, N'Quepos',71)
        ,(440, N'Savegre',71)
        ,(441, N'Naranjito',71)
        ,(442, N'Golfito',72)
        ,(443, N'Guaycará',72)
        ,(444, N'Pavón',72)
        ,(445, N'San Vito',73)
        ,(446, N'Sabalito',73)
        ,(447, N'Aguabuena',73)
        ,(448, N'Limoncito',73)
        ,(449, N'Pittier',73)
        ,(450, N'Gutiérrez Braun',73)
        ,(451, N'Parrita',74)
        ,(452, N'Corredor',75)
        ,(453, N'La Cuesta',75)
        ,(454, N'Canoas',75)
        ,(455, N'Laurel',75)
        ,(456, N'Jacó',76)
        ,(457, N'Tárcoles',76)
        ,(458, N'Lagunillas',76)
        ,(459, N'Monteverde',77)
        ,(460, N'Puerto Jiménez',78)
        ,(461, N'Limón',79)
        ,(462, N'Valle La Estrella',79)
        ,(463, N'Río Blanco',79)
        ,(464, N'Matama',79)
        ,(465, N'Guápiles',80)
        ,(466, N'Jiménez',80)
        ,(467, N'Rita',80)
        ,(468, N'Roxana',80)
        ,(469, N'Cariari',80)
        ,(470, N'Colorado',80)
        ,(471, N'La Colonia',80)
        ,(472, N'Siquirres',81)
        ,(473, N'Pacuarito',81)
        ,(474, N'Florida',81)
        ,(475, N'Germania',81)
        ,(476, N'El Cairo',81)
        ,(477, N'Alegría',81)
        ,(478, N'Reventazón',81)
        ,(479, N'Bratsi',82)
        ,(480, N'Sixaola',82)
        ,(481, N'Cahuita',82)
        ,(482, N'Telire',82)
        ,(483, N'Matina',83)
        ,(484, N'Batán',83)
        ,(485, N'Carrandí',83)
        ,(486, N'Guácimo',84)
        ,(487, N'Mercedes',84)
        ,(488, N'Pocora',84)
        ,(489, N'Río Jiménez',84)
        ,(490, N'Duacarí',84)

    SET IDENTITY_INSERT Distrito OFF;

END