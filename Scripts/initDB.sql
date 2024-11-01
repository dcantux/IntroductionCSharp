-- Crear la base de datos
CREATE DATABASE testing;

-- Usar la base de datos
USE testing;

-- Crear la tabla users con las columnas name y lastname
CREATE TABLE users (
    id INT AUTO_INCREMENT PRIMARY KEY,
    name VARCHAR(50),
    lastname VARCHAR(50)
);

-- Insertar datos ficticios en la tabla users
INSERT INTO users (name, lastname) VALUES
    ('John', 'Doe'),
    ('Jane', 'Smith'),
    ('Carlos', 'Garc�a'),
    ('Laura', 'Mart�nez'),
    ('Juan', 'L�pez'),
    ('Mar�a', 'G�mez'),
    ('Peter', 'Johnson'),
    ('Alice', 'Brown'),
    ('David', 'White'),
    ('Sara', 'Black');
