-- Write your query below
SELECT customers.name as name from customers 
WHERE NOT EXISTS (
    SELECT 1 FROM orders WHERE customers.id = orders.customer_id
);