-- Table: public.Affiliation

 DROP TABLE IF EXISTS public."Affiliation";

CREATE TABLE IF NOT EXISTS public."Affiliation"
(
    "Id" integer NOT NULL GENERATED ALWAYS AS IDENTITY ( INCREMENT 1 START 1 MINVALUE 1 MAXVALUE 2147483647 CACHE 1 ),
    "DateAjout" date NOT NULL,
    "IdEtablissement" integer NOT NULL,
    "IdOrganismeSocial" integer NOT NULL,
    "Deleted" boolean NOT NULL DEFAULT false,
    CONSTRAINT "Affiliation_pkey" PRIMARY KEY ("Id"),
    CONSTRAINT "Affiliation_IdEtablissement_fkey" FOREIGN KEY ("IdEtablissement")
        REFERENCES public."Etablissement" ("Id") MATCH SIMPLE
        ON UPDATE NO ACTION
        ON DELETE NO ACTION,
    CONSTRAINT "Affiliation_IdOrganismeSocial_fkey" FOREIGN KEY ("IdOrganismeSocial")
        REFERENCES public."OrganismeSocial" ("Id") MATCH SIMPLE
        ON UPDATE NO ACTION
        ON DELETE NO ACTION
)

TABLESPACE pg_default;

ALTER TABLE IF EXISTS public."Affiliation"
    OWNER to postgres;
-- Index: fki_FK_Affiliation_Etablissement

-- DROP INDEX IF EXISTS public."fki_FK_Affiliation_Etablissement";

CREATE INDEX IF NOT EXISTS "fki_FK_Affiliation_Etablissement"
    ON public."Affiliation" USING btree
    ("IdEtablissement" ASC NULLS LAST)
    TABLESPACE pg_default;
