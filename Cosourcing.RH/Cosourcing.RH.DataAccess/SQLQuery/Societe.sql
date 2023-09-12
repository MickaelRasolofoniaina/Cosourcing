-- Table: public.Societe

-- DROP TABLE IF EXISTS public."Societe";

CREATE TABLE IF NOT EXISTS public."Societe"
(
    "Id" integer NOT NULL GENERATED ALWAYS AS IDENTITY ( INCREMENT 1 START 1 MINVALUE 1 MAXVALUE 2147483647 CACHE 1 ),
    "NomResponsable" character varying COLLATE pg_catalog."default" NOT NULL,
    "PrenomResponsable" character varying COLLATE pg_catalog."default",
    "QualiteResponsable" character varying COLLATE pg_catalog."default" NOT NULL,
    "CodeBanque1" character varying(2) COLLATE pg_catalog."default",
    "NomBanque1" character varying COLLATE pg_catalog."default",
    "Iban1" character varying(23) COLLATE pg_catalog."default",
    "CodeBanque2" character varying(2) COLLATE pg_catalog."default",
    "NomBanque2" character varying COLLATE pg_catalog."default",
    "Iban2" character varying(23) COLLATE pg_catalog."default",
    "NomOrganismeSociale" character varying COLLATE pg_catalog."default" NOT NULL,
    "NumeroOrganismeSociale" character varying COLLATE pg_catalog."default" NOT NULL,
    "NomServiceImpots" character varying COLLATE pg_catalog."default" NOT NULL,
    "NumeroAffiliationImpots" character varying COLLATE pg_catalog."default" NOT NULL,
    "Commentaire" character varying COLLATE pg_catalog."default",
    "RaisonSociale" character varying COLLATE pg_catalog."default" NOT NULL,
    "NomCommercial" character varying COLLATE pg_catalog."default" NOT NULL,
    "Adresse" character varying COLLATE pg_catalog."default" NOT NULL,
    "DateDeCreation" date NOT NULL,
    "FormeJuridique" character varying COLLATE pg_catalog."default" NOT NULL,
    "NumeroStatistique" character varying COLLATE pg_catalog."default" NOT NULL,
    "Nif" character varying(10) COLLATE pg_catalog."default" NOT NULL,
    "Activite" character varying COLLATE pg_catalog."default" NOT NULL,
    "NombreEtablissement" smallint NOT NULL DEFAULT 1,
    "Deleted" boolean NOT NULL DEFAULT false,
    "AdresseBanque1" character varying COLLATE pg_catalog."default",
    "AdresseBanque2" character varying COLLATE pg_catalog."default",
    CONSTRAINT "Societe_pkey" PRIMARY KEY ("Id")
)

TABLESPACE pg_default;

ALTER TABLE IF EXISTS public."Societe"
    OWNER to postgres;