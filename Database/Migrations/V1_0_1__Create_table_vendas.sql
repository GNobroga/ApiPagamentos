CREATE TABLE vendas (
    id VARCHAR(36) PRIMARY KEY,
    nome VARCHAR(255) NOT NULL,
    preco DECIMAL(10, 2) NOT NULL DEFAULT 0,
    status VARCHAR(20) CHECK (status IN ('processando', 'pago', 'falha')),
    pagamento VARCHAR(20) CHECK (pagamento IN ('cartao', 'boleto', 'pix')),
    parcelas INTEGER NOT NULL DEFAULT 1,
    data DATE DEFAULT CURRENT_DATE
);