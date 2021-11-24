DROP USER IF EXISTS 'Administrador'@'%';
CREATE USER 'Administrador'@'%' IDENTIFIED BY 'passAdministrador';
GRANT INSERT,UPDATE ON SoftwareFactory.Proyecto TO 'Administrador'@'%';
GRANT INSERT ON SoftwareFactory.Tecnologia TO 'Administrador'@'%';
GRANT INSERT ON SoftwareFactory.Cliente  TO 'Administrador'@'%';
GRANT INSERT ON SoftwareFactory.Empleado TO 'Administrador'@'%';




DROP USER IF EXISTS 'PM'@'10.3.45.%';
CREATE USER 'PM'@'10.3.45.%' IDENTIFIED BY 'passPM';
GRANT SELECT ON SoftwareFactory.* TO 'PM'@'10.3.45.%';
GRANT INSERT,UPDATE(Calificacion) ON SoftwareFactory.Experiencia TO 'PM'@'10.3.45.%';
GRANT INSERT ON SoftwareFactory.Empleado  TO 'PM'@'10.3.45.%';
GRANT INSERT ON SoftwareFactory.Requerimiento TO 'PM'@'10.3.45.%';
GRANT INSERT,UPDATE(Fin) ON SoftwareFactory.Tarea TO 'PM'@'10.3.45.%';




DROP USER IF EXISTS 'Empleado'@'10.3.45.%';
CREATE USER 'Empleado'@'10.3.45.%' IDENTIFIED BY 'passEmpleado';
GRANT SELECT ON SoftwareFactory.* TO 'Empleado'@'10.3.45.%';


