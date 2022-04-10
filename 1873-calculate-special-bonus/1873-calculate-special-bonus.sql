# Write your MySQL query statement below
select * from (
select employee_id, salary as bonus from Employees where employee_id % 2 = 1 and name not like 'm%'
union
select employee_id, 0 as bonus from Employees where not (employee_id % 2 = 1 and name not like 'm%')
) as E order by E.employee_id