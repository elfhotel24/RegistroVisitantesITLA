create database AsistITLA

USE AsistITLA

CREATE TABLE Edificios (
    IdEdificio INT PRIMARY KEY IDENTITY(1,1),
    DescripcionEdificio VARCHAR(100) NOT NULL
);

CREATE TABLE Aulas (
    IdAula VARCHAR(50) PRIMARY KEY,
    Edificio INT NOT NULL,
    FOREIGN KEY (Edificio) REFERENCES Edificios(IdEdificio)
);

CREATE TABLE Usuarios (
    IdUsuario INT PRIMARY KEY IDENTITY(1,1),
    CodUsuario VARCHAR(50) UNIQUE NOT NULL,
    Nombre VARCHAR(50) NOT NULL,
    Apellido VARCHAR(50) NOT NULL,
    FechaNacimiento DATE NOT NULL,
    TipoUsuario VARCHAR(20) NOT NULL, 
    Password VARCHAR(100) NOT NULL
);

CREATE TABLE Visitantes (
    IdVisitante INT PRIMARY KEY IDENTITY(1,1),
    Nombre VARCHAR(50) NOT NULL,
    Apellido VARCHAR(50) NOT NULL,
    Carrera VARCHAR(50), 
    Edificio INT NOT NULL,
    HoraEntrada DATETIME NOT NULL,
    HoraSalida DATETIME,
    MotivoVisita VARCHAR(255) NOT NULL,
    IdAula VARCHAR(50) NOT NULL,
    FOREIGN KEY (Edificio) REFERENCES Edificios(IdEdificio),
    FOREIGN KEY (IdAula) REFERENCES Aulas(IdAula)
);



delete edificios

Truncate table aulas