# Write your MySQL query statement below

select * from(
select id, 'Root' as type from Tree where p_id is null
union
select id, 'Inner' as type from Tree where
    id in(select p_id as id from Tree where p_id is not null group by p_id)
    and id not in(select id from Tree where p_id is null)
union
select id, 'Leaf' as type from Tree where 
    id not in(select p_id as id from Tree where p_id is not null group by p_id)
    and id not in(select id from Tree where p_id is null)
) as T order by id;