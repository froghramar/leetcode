# Write your MySQL query statement below
select W1.id from Weather as W1 inner join Weather as W2 on W1.recordDate = DATE_ADD(W2.recordDate, INTERVAL 1 DAY) where W1.temperature > W2.temperature