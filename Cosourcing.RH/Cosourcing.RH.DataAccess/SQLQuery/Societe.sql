-- Table: public.Societe

-- DROP TABLE IF EXISTS public."Societe";

CREATE TABLE IF NOT EXISTS public."Societe"
(
    -- Inherited from table public."Etablissement": "Id" integer NOT NULL,
    -- Inherited from table public."Etablissement": "NomResponsable" character varying COLLATE pg_catalog."default" NOT NULL,
    -- Inherited from table public."Etablissement": "PrenomResponsable" character varying COLLATE pg_catalog."default",
    -- Inherited from table public."Etablissement": "QualiteResponsable" character varying COLLATE pg_catalog."default" NOT NULL,
    -- Inherited from table public."Etablissement": "CodeBanque1" character varying(2) COLLATE pg_catalog."default",
    -- Inherited from table public."Etablissement": "NomBanque1" character varying COLLATE pg_catalog."default",
    -- Inherited from table public."Etablissement": "Iban1" character varying(23) COLLATE pg_catalog."default",
    -- Inherited from table public."Etablissement": "CodeBanque2" character varying(2) COLLATE pg_catalog."default",
    -- Inherited from table public."Etablissement": "NomBanque2" character varying COLLATE pg_catalog."default",
    -- Inherited from table public."Etablissement": "Iban2" character varying(23) COLLATE pg_catalog."default",
    -- Inherited from table public."Etablissement": "NomOrganismeSociale" character varying COLLATE pg_catalog."default" NOT NULL,
    -- Inherited from table public."Etablissement": "NumeroOrganismeSociale" character varying COLLATE pg_catalog."default" NOT NULL,
    -- Inherited from table public."Etablissement": "NomServiceImpots" character varying COLLATE pg_catalog."default" NOT NULL,
    -- Inherited from table public."Etablissement": "NumeroAffiliationImpots" character varying COLLATE pg_catalog."default" NOT NULL,
    -- Inherited from table public."Etablissement": "Commentaire" character varying COLLATE pg_catalog."default",
    "RaisonSociale" character varying COLLATE pg_catalog."default" NOT NULL,
    "NomCommercial" character varying COLLATE pg_catalog."default" NOT NULL,
    "Adresse" character varying COLLATE pg_catalog."default" NOT NULL,
    "DateDeCreation" date NOT NULL,
    "FormeJuridique" character varying COLLATE pg_catalog."default" NOT NULL,
    "NumeroStatistique" character varying COLLATE pg_catalog."default" NOT NULL,
    "Nif" character varying(10) COLLATE pg_catalog."default" NOT NULL,
    "Activite" character varying COLLATE pg_catalog."default" NOT NULL,
    "NombreEtablissement" smallint NOT NULL DEFAULT 1,
    "Deleted" boolean NOT NULL DEFAULT false
)
    INHERITS (public."Etablissement")
TABLESPACE pg_default;

ALTER TABLE IF EXISTS public."Societe"
    OWNER to postgres;