-- Table: public.OrganismeSocial

DROP TABLE IF EXISTS public."OrganismeSocial";

CREATE TABLE IF NOT EXISTS public."OrganismeSocial"
(
    "Id" integer NOT NULL GENERATED ALWAYS AS IDENTITY ( INCREMENT 1 START 1 MINVALUE 1 MAXVALUE 2147483647 CACHE 1 ),
    "Nom" character varying COLLATE pg_catalog."default" NOT NULL,
    "Adresse" character varying(23) COLLATE pg_catalog."default" NOT NULL,
    "BaseCotisationSocialeEmployeur" decimal,
    "BaseCotisationSocialeSalarie" decimal,
    "BaseTauxCotisationSocialeEmployeur" decimal,
    "BaseTauxCotisationSocialeSalarie" decimal,
    "Deleted" boolean NOT NULL DEFAULT false,   
    CONSTRAINT "OrganismeSocial_pkey" PRIMARY KEY ("Id")

)

TABLESPACE pg_default;

ALTER TABLE IF EXISTS public."OrganismeSocial"
    OWNER to postgres;
-- Index: fki_FK_OrganismeSocial_Affiliation

