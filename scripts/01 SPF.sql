/*Realizar los SP para dar de alta todas las tablas, menos la tabla Experiencia.*/
DELIMITER $$
DROP PROCEDURE IF EXISTS altaTecnologia $$
CREATE PROCEDURE  altaTecnologia  (IN unidTecnologia TINYINT,
IN untecnologia VARCHAR(20), 
IN uncostoBase DECIMAL(10,2) )

BEGIN
INSERT INTO Tecnologia (idTecnologia,tecnologia,costoBase)
VALUES (unidTecnologia,untecnologia,uncostoBase);
END $$

DELIMITER $$
DROP PROCEDURE IF EXISTS altaRequerimiento $$
CREATE PROCEDURE  altaRequerimiento  ( IN unidRequerimiento INT,IN unidProyecto SMALLINT,IN unidTecnologia INT,IN unDescripcion VARCHAR(45),IN  unComplejidad TINYINT UNSIGNED )

BEGIN
INSERT INTO Requerimiento (idRequerimiento,idProyecto,idTecnologia,Descripcion,Complejidad)
VALUES (unidRequerimiento,unidProyecto,unidTecnologia,unDescripcion,unComplejidad);
END $$

DELIMITER $$
DROP PROCEDURE IF EXISTS altaProyecto $$
CREATE PROCEDURE altaProyecto  (IN unidProyecto SMALLINT,
IN unCuit INT,
IN unDescripcion VARCHAR(200),
IN unPresupuesto DECIMAL(10,2),
IN unInicio DATE,
IN unFin DATE)

BEGIN
INSERT INTO Proyecto(idProyecto,Cuit,Descripcion,Presupuesto,Inicio,Fin )
VALUES (unidProyecto,unCuit,unDescripcion,unPresupuesto,unInicio,unFin );
END $$

DELIMITER $$
DROP PROCEDURE IF EXISTS altaTarea $$
CREATE PROCEDURE  altaTarea  (IN unidRequerimiento INT,
    IN unCuil INT,
    IN unInicio DATE,
    IN unFin DATE )

BEGIN
INSERT INTO Tarea ( idRequerimiento,Cuil,Inicio,Fin)
VALUES ( unidRequerimiento,unCuil,unInicio,unFin);
END $$


DELIMITER $$
DROP PROCEDURE IF EXISTS altaCliente $$
CREATE PROCEDURE  altaCliente (IN unCuit INT,IN unRazonSocial VARCHAR(50))

BEGIN
INSERT INTO Cliente (Cuit,RazonSocial )
VALUES (unCuit,unRazonSocial);
END $$


DELIMITER $$
DROP PROCEDURE IF EXISTS altaEmpleado $$
CREATE PROCEDURE altaEmpleado   (IN unCuil INT,IN unNombre VARCHAR(50),IN unApellido VARCHAR(50),
IN unaContratacion DATE )

BEGIN
INSERT INTO Empleado (Cuil,Nombre,Apellido,Contratacion)
VALUES (unCuil,unNombre,unApellido,unaContratacion);
END $$


/*Realizar el SP asignarExperiencia que recibe como parámetros cuil,
idTecnologia y una calificación. El SP tiene que crear un registro en caso de que no exista o 
actualizarlo en caso de que si exista.*/

DELIMITER $$
DROP PROCEDURE IF EXISTS asignarExperiencia $$
CREATE PROCEDURE asignarExperiencia (IN unCuil INT,IN unidTecnologia TINYINT,IN unCalificacion TINYINT UNSIGNED)

BEGIN
DECLARE VerificarRegistro INT;

SELECT COUNT(cuil) INTO VerificarRegistro
FROM Experiencia
WHERE Cuil=unCuil and idTecnologia=unidTecnologia;

IF (VerificarRegistro=1) THEN
UPDATE Experiencia 
SET Calificacion=unCalificacion 
WHERE Cuil=unCuil and idTecnologia=unidTecnologia;
END IF;
IF (VerificarRegistro=0)THEN 
INSERT INTO Experiencia (Cuil,idTecnologia,Calificacion)
VALUES (unCuil ,unidTecnologia,unCalificacion );
END IF;
END $$



/*Crear los SP finalizarTarea que reciba como parámetro un idRequerimiento,
un cuil y una fecha de fin. El SP deberá actualizar la fecha de fin solamente si no tenía valor previo.*/

DELIMITER $$
DROP PROCEDURE IF EXISTS finalizarTarea $$
CREATE PROCEDURE finalizarTarea (  IN unidRequerimiento INT,IN unCuil INT,IN unFechaFin DATE)
BEGIN
UPDATE Tarea
SET Fin=unFechaFin
WHERE Fin is null
AND idRequerimiento=unidRequerimiento
AND cuil=unCuil; 
END $$

/*Realizar la SF complejidadPromedio que reciba como parámetro un idProyecto y 
devuelva un float representando el promedio de  complejidad de los requerimientos para el Proyecto pasado por parámetro.*/

DELIMITER $$
DROP FUNCTION IF EXISTS  ComplejidadPromedio $$
CREATE FUNCTION ComplejidadPromedio(unidProyecto smallint) returns float
BEGIN
DECLARE PromedioComplejidad float;
SELECT AVG(complejidad) INTO PromedioComplejidad
FROM Requerimiento
WHERE idProyecto=unidProyecto;

RETURN PromedioComplejidad;
END $$

/*Realizar la SF sueldoMensual que en base a un cuil devuelva el sueldo a pagar (DECIMAL (10,2))para el mes en curso.
SUELDO MENSUAL = Antigüedad en años * 1000 + SUMATORIA de (calificación de la exp. * costo base de la tecnología).*/

DELIMITER $$
DROP FUNCTION IF EXISTS  SueldoMensual $$
CREATE FUNCTION  SueldoMensual ( unCuil INT) returns decimal (10,2)

BEGIN
DECLARE SueldoMensual decimal (10,2);
SELECT timestampdiff (year,Contratacion,curdate())*1000 + Sum(calificacion*costoBase) into SueldoMensual
FROM Empleado E
INNER JOIN Experiencia using (cuil)
INNER JOIN tecnologia ON Experiencia.idTecnologia=Tecnologia.idTecnologia
WHERE   E.cuil=unCuil;

return SueldoMensual;
END $$

/*Realizar el SF costoProyecto que recibe como parámetro un idProyecto y devuelva el costo en DECIMAL (10,2).
COSTO PROYECTO = SUMATORIA (complejidad del requerimiento * costo base de la tecnología del Requerimiento).*/

DELIMITER $$
DROP FUNCTION IF EXISTS  costoProyecto $$
CREATE FUNCTION  costoProyecto ( unidProyecto INT) RETURNS decimal (10,2)
BEGIN
DECLARE costoProyecto decimal(10,2);
SELECT sum(Complejidad*costoBase) INTO costoProyecto
FROM Requerimiento Requerimiento
INNER JOIN Tecnologia using(idTecnologia)
WHERE R.idProyecto=unidProyecto;
return costoProyecto;
END$$
