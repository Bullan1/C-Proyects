CREATE DATABASE GestionPizzeria;

USE GestionPizzeria;

CREATE TABLE Roles ( 
    IdRol INT PRIMARY KEY IDENTITY,
    NombreRol NVARCHAR(50) NOT NULL
);

CREATE TABLE Usuarios (
    UserId INT PRIMARY KEY IDENTITY,
    NombreUsuario NVARCHAR(50) NOT NULL,
    CorreoElectronico NVARCHAR(100) NOT NULL,
    Clave NVARCHAR(255) NOT NULL,
    ConfirmacionClave NVARCHAR(255) NOT NULL,
    Activo BIT NOT NULL,
    IdRol INT NOT NULL,
    FOREIGN KEY (IdRol) REFERENCES Roles(IdRol)
);

CREATE TABLE Pizzas (
    IdPizza INT PRIMARY KEY IDENTITY,
    NombreP NVARCHAR(100) NOT NULL,
	Descripcion NVARCHAR(100) NOT NULL,
    Precio INT NOT NULL,
	TamañoPizza NVARCHAR(100) NOT NULL,
	Disponible BIT NOT NULL
);

CREATE TABLE ClientesPizzeria (
    IdClientes INT PRIMARY KEY IDENTITY,
    UserId INT NOT NULL,
    IdPizza INT NOT NULL,  
    FOREIGN KEY (UserId) REFERENCES Usuarios(UserId),
    FOREIGN KEY (IdPizza) REFERENCES Pizzas(IdPizza)
);


INSERT INTO Pizzas(NombreP, Descripcion, Precio, TamañoPizza,Disponible) VALUES ('Pepperoni', 'Pizza Con Queso Extra, Pepperoni y Aceitunas', 5500, 'Familiar',1);


Select * from Usuarios;


INSERT INTO Pizzas (NombreP, Descripcion, Precio, TamañoPizza, Disponible) 
VALUES('Pizza Margarita', 'Clásica pizza Margarita con tomate, mozzarella y albahaca', 12990, 'Grande', 1),
('Pizza Pepperoni', 'Pizza con pepperoni extra', 14990, 'Grande', 1), 
('Pizza Hawaiana', 'Pizza con piña, jamón y mozzarella', 13990, 'Grande', 1), 
('Pizza Vegetariana', 'Pizza con vegetales frescos y mozzarella', 11990, 'Grande', 1), 
('Pizza Cuatro Quesos', 'Pizza con mezcla de cuatro quesos: mozzarella, cheddar, parmesano y azul', 15990, 'Grande', 1), 
('Pizza BBQ Chicken', 'Pizza con pollo a la barbacoa, cebolla y mozzarella', 16990, 'Grande', 1), 
('Pizza Mexicana', 'Pizza con carne molida, jalapeños y mozzarella', 14990, 'Grande', 1), 
('Pizza Marinera', 'Pizza con mariscos, ajo y mozzarella', 17990, 'Grande', 1);