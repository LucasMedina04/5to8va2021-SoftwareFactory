delimiter $$

/**/
SELECT 'Creando Triggers' AS 'Estado';
drop trigger if exists aftInsTarea;
create trigger aftInsTarea after insert on Tarea
for each row
begin
    if (exists (select *
                from requerimiento r
                inner join experiencia e using(idTecnologia)
                where idRequerimiento = new.idRequerimiento
                and cuil = new.cuil
                and calificacion < complejidad)) then
        signal sqlstate '45000'
        set MESSAGE_TEXT = CONCAT("Calificación de insuficiente");
    end if;
end $$

/**/

drop trigger if exists aftInsEmpleado
create trigger aftInsEmpleado after insert on empleado
for each row
begin
    insert into experiencia(cuil, idTecnologia, calificacion)
                    select new.cuil, idTecnologia, 0
                    from tecnologia;
end $$