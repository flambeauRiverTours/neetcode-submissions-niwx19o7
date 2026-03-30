-- Write your query below

SELECT customer_id, customer_name FROM customers AS c
WHERE EXISTS (SELECT 1 FROM orders AS o WHERE c.customer_id = o.customer_id AND product_name = 'A')
AND EXISTS (SELECT 1 FROM orders AS o WHERE c.customer_id = o.customer_id AND product_name = 'B')
AND NOT EXISTS (SELECT 1 FROM orders AS o WHERE c.customer_id = o.customer_id AND product_name = 'C')
ORDER BY customer_name;