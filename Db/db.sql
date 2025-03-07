
SET search_path TO public;

CREATE SEQUENCE IF NOT EXISTS productos_id_seq START WITH 1 INCREMENT BY 1;
CREATE SEQUENCE IF NOT EXISTS usuarios_id_seq START WITH 1 INCREMENT BY 1;


CREATE TABLE IF NOT EXISTS public.productos (
    id integer NOT NULL DEFAULT nextval('productos_id_seq'::regclass),
    nombre character varying(255) NOT NULL,
    cantidad integer NOT NULL,
    CONSTRAINT productos_pkey PRIMARY KEY (id)
) TABLESPACE pg_default;

ALTER TABLE public.productos OWNER TO postgres;

CREATE TABLE IF NOT EXISTS public.usuarios (
    id integer NOT NULL DEFAULT nextval('usuarios_id_seq'::regclass),
    username character varying(255) NOT NULL,
    password character varying(255) NOT NULL,
    CONSTRAINT usuarios_pkey PRIMARY KEY (id)
) TABLESPACE pg_default;

ALTER TABLE public.usuarios OWNER TO postgres;


GRANT SELECT, INSERT, UPDATE, DELETE ON public.productos TO postgres;
GRANT SELECT, INSERT, UPDATE, DELETE ON public.usuarios TO postgres;

INSERT INTO public.usuarios (username, password) VALUES ('admin', 'admin123');
INSERT INTO public.productos (nombre, cantidad) VALUES ('Producto de prueba', 10);


SELECT setval('productos_id_seq', COALESCE((SELECT MAX(id) FROM public.productos), 1), false);
SELECT setval('usuarios_id_seq', COALESCE((SELECT MAX(id) FROM public.usuarios), 1), false);

INSERT INTO public.usuarios(username, password)
	VALUES ('admin', 'jGl25bVBBBW96Qi9Te4V37Fnqchz/Eu4qB9vKrRIqRg=');