USE Vyuka;
GO

--Reset
DROP TABLE IF EXISTS Hodnoceni;
DROP TABLE IF EXISTS Zapis_Predmetu;
DROP TABLE IF EXISTS Studenti;
DROP TABLE IF EXISTS Predmety;
GO

CREATE TABLE Studenti (
    ID_Studenta INT PRIMARY KEY,
    Jmeno VARCHAR(50),
    Prijmeni VARCHAR(50),
    Datum_Narozeni DATE
);

CREATE TABLE Predmety (
    Zkratka VARCHAR(10) PRIMARY KEY,
    Nazev VARCHAR(100)
);

CREATE TABLE Zapis_Predmetu (
    ID_Studenta INT,
    Zkratka_Predmetu VARCHAR(10),
    PRIMARY KEY (ID_Studenta, Zkratka_Predmetu),
    FOREIGN KEY (ID_Studenta) REFERENCES Studenti(ID_Studenta),
    FOREIGN KEY (Zkratka_Predmetu) REFERENCES Predmety(Zkratka)
);

CREATE TABLE Hodnoceni (
    ID_Studenta INT,
    Zkratka_Predmetu VARCHAR(10),
    Datum_Hodnoceni DATE,
    Znamka INT,
    PRIMARY KEY (ID_Studenta, Zkratka_Predmetu),
    FOREIGN KEY (ID_Studenta) REFERENCES Studenti(ID_Studenta),
    FOREIGN KEY (Zkratka_Predmetu) REFERENCES Predmety(Zkratka)
);