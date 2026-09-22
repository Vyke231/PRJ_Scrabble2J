CREATE DATABASE IF NOT EXISTS BDD_SCRABLE COLLATE 'utf8mb4_roman_ci';
USE BDD_SCRABLE;

CREATE TABLE Partie(
    id INT NOT NULL AUTO_INCREMENT PRIMARY KEY,
    datePartie DATETIME NOT NULL DEFAULT CURRENT_TIMESTAMP,
    nomJoueur1 VARCHAR (20),
    nomJoueur2 VARCHAR (20),
    scoreJoueur1 int DEFAULT 0,
    scoreJoueur2 int DEFAULT 0
);


INSERT INTO Partie (datePartie, nomJoueur1, nomJoueur2, scoreJoueur1, scoreJoueur2) VALUES
 ('2026-09-01 14:30:00', 'Alice', 'Bob', 342, 280);
INSERT INTO Partie (datePartie, nomJoueur1, nomJoueur2, scoreJoueur1, scoreJoueur2) VALUES 
('2026-09-02 18:15:00', 'Charlie', 'Alice', 410, 395);
INSERT INTO Partie (datePartie, nomJoueur1, nomJoueur2, scoreJoueur1, scoreJoueur2) VALUES 
('2026-09-05 20:00:00', 'David', 'Bob', 275, 310);