/*Antes de hacer un Inset rm Tarea,
si la calificacion del empleado es menor a la complejidad del requerimiento no se tiene que permitir el Insert y 
se tiene que mostrar la leyenda "Calificacion insuficiente".*/

DELIMITER $$
SELECT 'Creando Triggers' AS 'Estado';
DROP trigger IF exists VerificarComplejidad;
CREATE trigger VerificarComplejidad BEFORE INSERT ON Tarea 
FOR EACH ROW
BEGIN
 DECLARE RangoExperiencia tinyint;
 DECLARE RangoComplejidad tinyint;

SELECT calificacion,complejidad INTO RangoExperiencia,RangoComplejidad
FROM Experiencia
INNER JOIN Requerimiento ON Experiencia.idTecnologia=Requerimiento.idTecnologia
WHERE cuil=new.cuil
IF (RangoExperiencia < RangoComplejidad) THEN
SIGNAL SQLSTATE '45000'
	SET MESSAGE_TEXT = 'calificacion del CUIL insuficiente';
    END IF;
END $$


/*Realizar un trigger para que al ingresar un usuario,
le asigne por defecto experiencia en todas las tecnologías disponibles con calificación igual a CERO.*/

DELIMITER $$
DROP FUNCTION IF EXISTS befinsUsuario;
CREATE trigger ExperienciaDefault AFTER INSERT ON Empleado 
FOR EACH ROW
BEGIN
   INSERT INTO Experiencia(Cuil,idTecnologia,calificacion)
   SELECT (new.cuil,Tecnologia.idTecnologia,0)
   FROM Tecnologia
END $$
