USE Vyuka;
GO

DELETE FROM Hodnoceni;
DELETE FROM Zapis_Predmetu;
DELETE FROM Predmety;
DELETE FROM Studenti;
GO

INSERT INTO Studenti (ID_Studenta, Jmeno, Prijmeni, Datum_Narozeni) VALUES 
(256655, 'Denis', 'Kučera', '2004-07-31'),
(256758, 'Petr', 'Svoboda', '2003-11-20'),
(265543, 'Markéta', 'Uhlířová', '2003-04-15'), 
(257655, 'Tomáš', 'Novák', '2003-08-30');

INSERT INTO Predmety (Zkratka, Nazev) VALUES 
('BPC-OOP', 'Objektově orientované programování'),
('BPC-MVT', 'Mikrovlnná technika'),
('BPC-NAO', 'Návrh analogových obvodů'),
('BPC-TMO', 'Trojrozměrné modelování');

INSERT INTO Zapis_Predmetu (ID_Studenta, Zkratka_Predmetu) VALUES 
(256655, 'BPC-OOP'), (256655, 'BPC-NAO'), 
(256758, 'BPC-OOP'), (256758, 'BPC-MVT'), (256758, 'BPC-NAO'),
(265543, 'BPC-OOP'), (265543, 'BPC-TMO'),
(257655, 'BPC-OOP');

INSERT INTO Hodnoceni (ID_Studenta, Zkratka_Predmetu, Datum_Hodnoceni, Znamka) VALUES 
(256655, 'BPC-OOP', '2024-01-15', 2),
(256758, 'BPC-OOP', '2024-01-15', 1),
(257655, 'BPC-MVT', '2024-01-16', 4),
(256655, 'BPC-NAO', '2024-01-20', 3);