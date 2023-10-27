-- Table: public.Inscription

 DROP TABLE IF EXISTS public."Inscription";

CREATE TABLE IF NOT EXISTS public."Inscription"
(
    "Id" integer NOT NULL GENERATED ALWAYS AS IDENTITY ( INCREMENT 1 START 1 MINVALUE 1 MAXVALUE 2147483647 CACHE 1 ),
    "DateAjout" date NOT NULL,
    "IdEtablissement" integer NOT NULL,
    "IdServiceImpot" integer NOT NULL,
    "Deleted" boolean NOT NULL DEFAULT false,
    CONSTRAINT "Inscription_pkey" PRIMARY KEY ("Id"),
    CONSTRAINT "Inscription_IdEtablissement_fkey" FOREIGN KEY ("IdEtablissement")
        REFERENCES public."Etablissement" ("Id") MATCH SIMPLE
        ON UPDATE NO ACTION
        ON DELETE NO ACTION,
    CONSTRAINT "Inscription_IdServiceImpot_fkey" FOREIGN KEY ("IdServiceImpot")
        REFERENCES public."ServiceImpot" ("Id") MATCH SIMPLE
        ON UPDATE NO ACTION
        ON DELETE NO ACTION
)

TABLESPACE pg_default;

ALTER TABLE IF EXISTS public."Inscription"
    OWNER to postgres;
-- Index: fki_FK_Inscription_Etablissement

-- DROP INDEX IF EXISTS public."fki_FK_Inscription_Etablissement";

CREATE INDEX IF NOT EXISTS "fki_FK_Inscription_Etablissement"
    ON public."Inscription" USING btree
    ("IdEtablissement" ASC NULLS LAST)
    TABLESPACE pg_default;
