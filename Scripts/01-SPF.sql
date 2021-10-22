delimiter $$

SELECT 'Creando Procedures' AS 'Estado';
/*Cliente*/
create procedure AltaCliente(uncuit int, unaRazonSocial varchar(50))
begin
	insert into cliente (cuit, razonSocial)
				values (uncuit, unaRazonSocial);
end $$

/*Proyecto*/
create procedure AltaProyecto(unidProyecto smallint, cuit int, unadescripcion varchar(50), unpresupuesto decimal(10,2), uninicio date, unfin date)
begin
	insert into proyecto (idProyecto, cuil, descripcion, presupuesto, inicio, fin)
				values (unidProyecto, cuit, unadescripcion, unpresupuesto, uninicio, unfin);
end $$

/*Requerimiento*/
create procedure AltaRequerimiento(unidRequerimiento int, unidProyecto smallint, unidTecnologia tinyint, unadescripcion varchar(50), unacomplejidad tinyint unsigned )
begin
	insert into requerimieto (idRequerimiento, idProyecto, idTecnologia, descripcion, complejidad)
				values (unidRequerimiento, unidProyecto, unidTecnologia, unadescripcion, unacomplejidad);
end $$

/*Tarea*/
create procedure AltaTarea(unidRequerimiento int ,uncuil int, uninicio date, unfin date)
begin
	insert into tarea (idRequerimiento, cuil, inicio, fin)
				values (unidRequerimiento, uncuil, uninicio, unfin);
end $$

/*Empleado*/
create procedure AltaEmpleado(uncuil int, unnombre varchar(50), unapellido varchar(50), unacontratacion date)
begin
	insert into empleado (cuil, nombre, apellido, contratacion)
				values (uncuil, unnombre, unapellido, unacontratacion);
end $$

/*Tecnologia*/
create procedure AltaTecnologia(unidTecnologia tinyint, unatecnologia varchar(50), uncostoBase decimal)
begin
	insert into tecnologia (idTecnologia, tecnologia, costoBase)
				values (unidTecnologia, unatecnologia, uncostoBase);
end $$

/*Experiencia*/
create procedure AltaExperiencia(unucuil int, unidTecnologia tinyint, unacalificacion tinyint unsigned)
begin
	if (not exists(select *
				from Experiencia
                where cuil = uncuil
                and idTecnologia = unidTecnologia)) then
                
		insert into Experiencia (cuil, idTecnologia, calificacion)
					values (uncuil, unidTecnologia, unacalificacion);
	else 
		update Experiencia
		set calificacion = unacalificacion
		where cuil = uncuil
		and idTecnologia = unidTecnologia
		and calificacion != unacalificacion;
    
    end if;
end $$

/*Funciones*/

/*complejidad promedio*/
create function ComplejidadPromedio(unidProyecto int) returns float
begin
	declare promedio float;
    select avg(complejidad) into promedio
    from requerimiento
    where idProyecto = unidProyecto;
    return promedio;
end $$

/*sueldoMensual*/
create function sueldoMensual(uncuil int) returns decimal(10,2)
begin
    declare sueldoMensual decimal(10,2);
    select  (timestampdiff(year, contratacion, curdate()) * 1000 +
            sum(calificacion * costobase)) into sueldoMensual
    from empleado e
    inner join experiencia using (cuil)
    inner join tecnologia using (idTecnologia)
    where e.cuil = uncuil;
    return sueldoMensual;
end $$

/*costoProyecto*/
create function costoProyecto(unidProyecto int) returns decimal(10,2)
begin
    declare costoProyecto decimal(10,2);
    select sum(costoBase * complejidad) into costoProyecto
    from requerimiento
    inner join tecnologia using (idTecnologia)
    where idProyecto = unidProyecto;
    return costoProyecto;
end $$