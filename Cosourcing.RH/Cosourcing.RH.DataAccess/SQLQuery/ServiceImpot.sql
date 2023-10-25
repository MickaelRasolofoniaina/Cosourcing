-- Table: public.ServiceImpot

-- DROP TABLE IF EXISTS public."ServiceImpot";

CREATE TABLE IF NOT EXISTS public."ServiceImpot"
(
    "Id" integer NOT NULL GENERATED ALWAYS AS IDENTITY ( INCREMENT 1 START 1 MINVALUE 1 MAXVALUE 2147483647 CACHE 1 ),
    "Nom" character varying COLLATE pg_catalog."default" NOT NULL,
    "Adresse" character varying(23) COLLATE pg_catalog."default" NOT NULL,
    "NomImpotObligatoire" character varying(23) COLLATE pg_catalog."default" NOT NULL,
    "BaseCotisationImposableEmployeur" decimal,
    "BaseCotisationImposableSalarie" decimal,
    "BaseTauxImpotEmployeur" decimal,
    "BaseTauxImpotSalarie" decimal,
    "ReductionImpot" decimal,
    "Deleted" boolean NOT NULL DEFAULT false,
    "IdEtablissement" integer NOT NULL,
    CONSTRAINT "ServiceImpot_pkey" PRIMARY KEY ("Id"),
    CONSTRAINT "ServiceImpot_IdEtablissement_fkey" FOREIGN KEY ("IdEtablissement")
        REFERENCES public."Etablissement" ("Id") MATCH SIMPLE
        ON UPDATE NO ACTION
        ON DELETE NO ACTION
)

TABLESPACE pg_default;

ALTER TABLE IF EXISTS public."ServiceImpot"
    OWNER to postgres;
-- Index: fki_FK_ServiceImpot_Etablissement

-- DROP INDEX IF EXISTS public."fki_FK_ServiceImpot_Etablissement";

CREATE INDEX IF NOT EXISTS "fki_FK_ServiceImpot_Etablissement"
    ON public."ServiceImpot" USING btree
    ("IdEtablissement" ASC NULLS LAST)
    TABLESPACE pg_default;