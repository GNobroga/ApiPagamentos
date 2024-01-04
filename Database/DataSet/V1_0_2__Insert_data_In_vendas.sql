INSERT INTO vendas (nome, preco, pagamento, parcelas, data, status)
VALUES 
('Produto A', 50.00, 'cartao', 3, '2024-01-02', 'pago'),
('Produto B', 75.50, 'boleto', 1, '2024-01-03', 'pago'),
('Produto C', 120.00, 'pix', 2, '2024-01-04', 'falha'),
('Produto C', 120.00, 'pix', 2, '2023-12-04', 'falha'),
('Produto C', 120.00, 'pix', 2, '2023-11-04', 'processado');
