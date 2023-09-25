-- Table: public.User

-- DROP TABLE IF EXISTS public."User";

CREATE TABLE IF NOT EXISTS public."User"
(
    "Id" integer NOT NULL,
    "LastName" character varying COLLATE pg_catalog."default" NOT NULL,
    "FirstName" character varying COLLATE pg_catalog."default",
    "Birthday" date NOT NULL,
    CONSTRAINT "User_pkey" PRIMARY KEY ("Id")
)

TABLESPACE pg_default;

ALTER TABLE IF EXISTS public."User"
    OWNER to postgres;
