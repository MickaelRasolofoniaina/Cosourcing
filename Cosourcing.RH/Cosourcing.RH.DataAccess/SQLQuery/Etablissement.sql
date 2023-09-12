-- Table: public.Etablissement

-- DROP TABLE IF EXISTS public."Etablissement";

CREATE TABLE IF NOT EXISTS public."Etablissement"
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
    "Nom" character varying COLLATE pg_catalog."default" NOT NULL,
    "Adresse" character varying COLLATE pg_catalog."default" NOT NULL,
    "Activite" character varying COLLATE pg_catalog."default" NOT NULL,
    "Deleted" boolean NOT NULL DEFAULT false,
    "IdSociete" integer NOT NULL,
    "AdresseBanque1" character varying COLLATE pg_catalog."default",
    "AdresseBanque2" character varying COLLATE pg_catalog."default",
    CONSTRAINT "Etablissement_pkey" PRIMARY KEY ("Id"),
    CONSTRAINT "Etablissement_IdSociete_fkey" FOREIGN KEY ("IdSociete")
        REFERENCES public."Societe" ("Id") MATCH SIMPLE
        ON UPDATE NO ACTION
        ON DELETE NO ACTION
)

TABLESPACE pg_default;

ALTER TABLE IF EXISTS public."Etablissement"
    OWNER to postgres;
-- Index: fki_FK_Etablissement_Societe

-- DROP INDEX IF EXISTS public."fki_FK_Etablissement_Societe";

CREATE INDEX IF NOT EXISTS "fki_FK_Etablissement_Societe"
    ON public."Etablissement" USING btree
    ("IdSociete" ASC NULLS LAST)
    TABLESPACE pg_default;