-- Ejercicio 3

-- A)
select 
a.proyecto as [Nombre_Proyecto],
b.descripcion as [Producto]
from proyecto a
inner join producto b on a.producto = b.producto
where a.proyecto = 1;


-- B)
select 
b.nombre as [Mensaje],
d.descripcion as [Producto],
e.descripcion as [proyecto]
from Formato_Mensaje a
inner join Tipo b on a.cod_tipo = b.cod_tipo
inner join Mensaje c on a.cod_formato = c.cod_formato 
inner join Producto d on c.producto = d.producto
inner join proyecto e on c.proyecto = e.proyecto;

-- C)
select 
a.cod_mensaje,
b.nombre as proyecto,
case
    when (
        select count(*)
        from producto_proyecto e
        where e.proyecto = c.proyecto
    ) = (
        select count(*)
        from mensaje f
        where f.proyecto = a.proyecto
        and f.cod_mensaje = a.cod_mensaje
    )
    then 'TODOS'
    else d.descripcion
end as producto
from mensaje a
join proyecto b on a.proyecto = b.proyecto
join producto_proyecto c on a.proyecto = c.proyecto and a.producto = c.producto
join producto d on c.producto = d.producto;
