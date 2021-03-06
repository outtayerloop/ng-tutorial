DROP TABLE IF EXISTS
    "PRODUCT",
    "SHIPPING"
;

CREATE TABLE "PRODUCT" (
    "ID"            SERIAL PRIMARY KEY,
	"NAME"          VARCHAR(64) NOT NULL UNIQUE,
    "DESCRIPTION"   VARCHAR(128),
	"PRICE"		    DECIMAL NOT NULL,
    "DATE"          TIMESTAMP NOT NULL,
    "SHIPPED"       BOOLEAN NOT NULL
);

CREATE TABLE "SHIPPING" (
    "ID"            SERIAL PRIMARY KEY,
	"PRICE"         DECIMAL NOT NULL,
    "PACKAGE"       INTEGER UNIQUE NOT NULL
);

ALTER TABLE "PRODUCT"
ADD CONSTRAINT CHK_PRODUCT_PRICE
CHECK (
	"PRICE" >= 1
	AND "PRICE" <= 100000
);