CREATE TABLE vendas (
    Id TEXT PRIMARY KEY DEFAULT (lower(hex(randomblob(4))) || '-' || lower(hex(randomblob(2))) || '-4' || substr(lower(hex(randomblob(2))), 2) || '-a' || substr(lower(hex(randomblob(2))), 2) || '-6' || substr(lower(hex(randomblob(2))), 2) || '-' || lower(hex(randomblob(6)))),
    nome VARCHAR(255) NOT NULL,
    preco DECIMAL(10, 2) NOT NULL DEFAULT 0,
    status VARCHAR(20) CHECK (status IN ('processando', 'pago', 'falha')),
    pagamento VARCHAR(20) CHECK (pagamento IN ('cartao', 'boleto', 'pix')),
    parcelas INTEGER NOT NULL DEFAULT 1,
    data DATE DEFAULT CURRENT_DATE
);