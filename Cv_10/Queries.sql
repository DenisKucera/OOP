USE Vyuka;
GO

--1st QUERY
SELECT s.Jmeno, s.Prijmeni, p.Nazev
FROM Studenti s
LEFT JOIN Zapis_Predmetu z ON s.ID_Studenta = z.ID_Studenta
LEFT JOIN Predmety p ON z.Zkratka_Predmetu = p.Zkratka;

--QUERy
SELECT 
    Prijmeni, 
    COUNT(*) AS Pocet_Studentu
FROM Studenti
GROUP BY Prijmeni
ORDER BY Pocet_Studentu DESC;

--2nd QUERY
SELECT 
    Zkratka_Predmetu, 
    COUNT(ID_Studenta) AS Pocet_Zapsanych
FROM Zapis_Predmetu
GROUP BY Zkratka_Predmetu
HAVING COUNT(ID_Studenta) < 3;


--3rd QUERY
SELECT 
    Zkratka_Predmetu, 
    MIN(Znamka) AS Nejlepsi_Znamka, 
    MAX(Znamka) AS Nejhorsi_Znamka, 
    AVG(Znamka * 1.0) AS Prumerna_Znamka, 
    COUNT(ID_Studenta) AS Pocet_Hodnocenych
FROM Hodnoceni
GROUP BY Zkratka_Predmetu;