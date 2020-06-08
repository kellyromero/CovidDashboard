CREATE TABLE public.covid_observations
(
    sno integer NOT NULL,
    observationdate date NOT NULL,
    provincestate character varying(50) COLLATE pg_catalog."default",
    countryregion character varying(355) COLLATE pg_catalog."default" NOT NULL,
    lastupdate date NOT NULL,
    confirmed integer NOT NULL,
    deaths integer NOT NULL,
    recovered integer NOT NULL,
    CONSTRAINT covid_observations_pkey PRIMARY KEY (sno)
)