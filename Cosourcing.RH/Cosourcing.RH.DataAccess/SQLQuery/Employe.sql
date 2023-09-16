-- Table: public.Employe

-- DROP TABLE IF EXISTS public."Employe";

CREATE TABLE IF NOT EXISTS public."Employe"
(
    "Id" integer NOT NULL GENERATED ALWAYS AS IDENTITY ( INCREMENT 1 START 1 MINVALUE 1 MAXVALUE 2147483647 CACHE 1 ),
    "Nom" character varying COLLATE pg_catalog."default" NOT NULL,
    "Prenom" character varying COLLATE pg_catalog."default",
    "Matricule" integer NOT NULL,
    "Genre" character varying(10) COLLATE pg_catalog."default",
    "DateNaissance" date NOT NULL,
    "LieuNaissance" character varying(23) COLLATE pg_catalog."default",
    "PaysNaissance" character varying(23) COLLATE pg_catalog."default",
    "PaysNationalite" character varying(23) COLLATE pg_catalog."default",
    "Situation" character varying(23) COLLATE pg_catalog."default",
    "Adresse" character varying(23) COLLATE pg_catalog."default" NOT NULL,
    "Poste" character varying(23) COLLATE pg_catalog."default" NOT NULL,
    "Categorie" character varying(23) COLLATE pg_catalog."default" NOT NULL,
    "Groupe" character varying(23) COLLATE pg_catalog."default" NOT NULL,
    "DEmbauche" date NOT NULL,
    "DSortie" date NOT NULL,
    "MotifSortie" character varying(23) COLLATE pg_catalog."default" NOT NULL,
    "Salaire" real,
    "Deleted" boolean NOT NULL DEFAULT false,
    "Cin" integer NOT NULL,
    "NumCnaps" character varying COLLATE pg_catalog."default",
    "HeureContractuelle" integer,
    "TypeContrat" character varying(23) COLLATE pg_catalog."default",
    "ModeReglement" character varying(23) COLLATE pg_catalog."default",
    "Iban" integer NOT NULL,
    "LieuTravail" character varying(23) COLLATE pg_catalog."default",
    "Affectation" character varying(23) COLLATE pg_catalog."default",
    "Commentaire" character varying(255) COLLATE pg_catalog."default",
    "IdEtablissement" integer NOT NULL,
    CONSTRAINT "Employe_pkey" PRIMARY KEY ("Id"),
    CONSTRAINT "Employe_IdEtablissement_fkey" FOREIGN KEY ("IdEtablissement")
        REFERENCES public."Etablissement" ("Id") MATCH SIMPLE
        ON UPDATE NO ACTION
        ON DELETE NO ACTION
)

TABLESPACE pg_default;

ALTER TABLE IF EXISTS public."Employe"
    OWNER to postgres;
-- Index: fki_FK_Employe_Etablissement

-- DROP INDEX IF EXISTS public."fki_FK_Employe_Etablissement";

CREATE INDEX IF NOT EXISTS "fki_FK_Employe_Etablissement"
    ON public."Employe" USING btree
    ("IdEtablissement" ASC NULLS LAST)
    TABLESPACE pg_default;