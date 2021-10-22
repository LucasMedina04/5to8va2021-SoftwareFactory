use softwarefactory;

SELECT 'Creando Usuarios' AS 'Estado';
Drop user if exists 'Administrador'@'LocalHost';
Create user 'Administrador'@'LocalHost' identified by 'PassAdministrador';

grant insert on proyecto to 'Administrador'@'LocalHost';
grant insert on tecnologia to 'Administrador'@'LocalHost';
grant insert on cliente to 'Administrador'@'LocalHost';
grant insert on Empleado to 'Administrador'@'LocalHost';
grant update on proyecto to 'Administrador'@'LocalHost';

/**/
Drop user if exists 'PM'@'10.3.45.%';
Create user 'PM'@'10.3.45.%' identified by 'PassPM';

grant select on softwarefactory.* to 'PM'@'10.3.45.%';
grant insert, update(calificacion) on Experiencia to 'PM'@'10.3.45.%';
grant insert on Empleado to 'PM'@'10.3.45.%';
grant insert on Requerimiento to 'PM'@'10.3.45.%';
grant insert, update(fin) on Tarea to 'PM'@'10.3.45.%';

/**/
Drop user if exists 'Empleado'@'%';
Create user 'Empleado'@'%' identified by 'PassEmpleado';

grant select on softwarefactory.* to 'Empleado'@'%';