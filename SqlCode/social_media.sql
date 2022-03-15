--
-- PostgreSQL database dump
--

-- Dumped from database version 13.6
-- Dumped by pg_dump version 13.6

SET statement_timeout = 0;
SET lock_timeout = 0;
SET idle_in_transaction_session_timeout = 0;
SET client_encoding = 'UTF8';
SET standard_conforming_strings = on;
SELECT pg_catalog.set_config('search_path', '', false);
SET check_function_bodies = false;
SET xmloption = content;
SET client_min_messages = warning;
SET row_security = off;

SET default_tablespace = '';

SET default_table_access_method = heap;

--
-- Name: hash_post; Type: TABLE; Schema: public; Owner: postgres
--

CREATE TABLE public.hash_post (
    hash_post_id integer NOT NULL,
    hash_tag_id bigint NOT NULL,
    post_id bigint NOT NULL
);


ALTER TABLE public.hash_post OWNER TO postgres;

--
-- Name: hash_post_hash_post_id_seq; Type: SEQUENCE; Schema: public; Owner: postgres
--

CREATE SEQUENCE public.hash_post_hash_post_id_seq
    AS integer
    START WITH 1
    INCREMENT BY 1
    NO MINVALUE
    NO MAXVALUE
    CACHE 1;


ALTER TABLE public.hash_post_hash_post_id_seq OWNER TO postgres;

--
-- Name: hash_post_hash_post_id_seq; Type: SEQUENCE OWNED BY; Schema: public; Owner: postgres
--

ALTER SEQUENCE public.hash_post_hash_post_id_seq OWNED BY public.hash_post.hash_post_id;


--
-- Name: hash_tags; Type: TABLE; Schema: public; Owner: postgres
--

CREATE TABLE public.hash_tags (
    hash_tag_id integer NOT NULL,
    hash_name character varying(255)
);


ALTER TABLE public.hash_tags OWNER TO postgres;

--
-- Name: hash_tags_hash_tag_id_seq; Type: SEQUENCE; Schema: public; Owner: postgres
--

CREATE SEQUENCE public.hash_tags_hash_tag_id_seq
    AS integer
    START WITH 1
    INCREMENT BY 1
    NO MINVALUE
    NO MAXVALUE
    CACHE 1;


ALTER TABLE public.hash_tags_hash_tag_id_seq OWNER TO postgres;

--
-- Name: hash_tags_hash_tag_id_seq; Type: SEQUENCE OWNED BY; Schema: public; Owner: postgres
--

ALTER SEQUENCE public.hash_tags_hash_tag_id_seq OWNED BY public.hash_tags.hash_tag_id;


--
-- Name: likes; Type: TABLE; Schema: public; Owner: postgres
--

CREATE TABLE public.likes (
    like_id integer NOT NULL,
    post_id bigint NOT NULL,
    user_id bigint NOT NULL,
    created_at timestamp with time zone DEFAULT '2022-03-14 20:09:28.757845+05:30'::timestamp with time zone
);


ALTER TABLE public.likes OWNER TO postgres;

--
-- Name: likes_like_id_seq; Type: SEQUENCE; Schema: public; Owner: postgres
--

CREATE SEQUENCE public.likes_like_id_seq
    AS integer
    START WITH 1
    INCREMENT BY 1
    NO MINVALUE
    NO MAXVALUE
    CACHE 1;


ALTER TABLE public.likes_like_id_seq OWNER TO postgres;

--
-- Name: likes_like_id_seq; Type: SEQUENCE OWNED BY; Schema: public; Owner: postgres
--

ALTER SEQUENCE public.likes_like_id_seq OWNED BY public.likes.like_id;


--
-- Name: posts; Type: TABLE; Schema: public; Owner: postgres
--

CREATE TABLE public.posts (
    post_id integer NOT NULL,
    post_type character varying(50),
    user_id bigint NOT NULL,
    created_at timestamp with time zone DEFAULT '2022-03-14 18:23:05.159819+05:30'::timestamp with time zone
);


ALTER TABLE public.posts OWNER TO postgres;

--
-- Name: posts_post_id_seq; Type: SEQUENCE; Schema: public; Owner: postgres
--

CREATE SEQUENCE public.posts_post_id_seq
    AS integer
    START WITH 1
    INCREMENT BY 1
    NO MINVALUE
    NO MAXVALUE
    CACHE 1;


ALTER TABLE public.posts_post_id_seq OWNER TO postgres;

--
-- Name: posts_post_id_seq; Type: SEQUENCE OWNED BY; Schema: public; Owner: postgres
--

ALTER SEQUENCE public.posts_post_id_seq OWNED BY public.posts.post_id;


--
-- Name: users; Type: TABLE; Schema: public; Owner: postgres
--

CREATE TABLE public.users (
    user_id integer NOT NULL,
    first_name character varying(50) NOT NULL,
    last_name character varying(50),
    user_name character varying(50) NOT NULL,
    email character varying(255) NOT NULL,
    mobile bigint NOT NULL,
    bio character varying(255) NOT NULL,
    address character varying(255) NOT NULL,
    passcode character varying(255) NOT NULL,
    created_at timestamp with time zone DEFAULT '2022-03-13 14:42:39.523945+05:30'::timestamp with time zone
);


ALTER TABLE public.users OWNER TO postgres;

--
-- Name: users_user_id_seq; Type: SEQUENCE; Schema: public; Owner: postgres
--

CREATE SEQUENCE public.users_user_id_seq
    AS integer
    START WITH 1
    INCREMENT BY 1
    NO MINVALUE
    NO MAXVALUE
    CACHE 1;


ALTER TABLE public.users_user_id_seq OWNER TO postgres;

--
-- Name: users_user_id_seq; Type: SEQUENCE OWNED BY; Schema: public; Owner: postgres
--

ALTER SEQUENCE public.users_user_id_seq OWNED BY public.users.user_id;


--
-- Name: hash_post hash_post_id; Type: DEFAULT; Schema: public; Owner: postgres
--

ALTER TABLE ONLY public.hash_post ALTER COLUMN hash_post_id SET DEFAULT nextval('public.hash_post_hash_post_id_seq'::regclass);


--
-- Name: hash_tags hash_tag_id; Type: DEFAULT; Schema: public; Owner: postgres
--

ALTER TABLE ONLY public.hash_tags ALTER COLUMN hash_tag_id SET DEFAULT nextval('public.hash_tags_hash_tag_id_seq'::regclass);


--
-- Name: likes like_id; Type: DEFAULT; Schema: public; Owner: postgres
--

ALTER TABLE ONLY public.likes ALTER COLUMN like_id SET DEFAULT nextval('public.likes_like_id_seq'::regclass);


--
-- Name: posts post_id; Type: DEFAULT; Schema: public; Owner: postgres
--

ALTER TABLE ONLY public.posts ALTER COLUMN post_id SET DEFAULT nextval('public.posts_post_id_seq'::regclass);


--
-- Name: users user_id; Type: DEFAULT; Schema: public; Owner: postgres
--

ALTER TABLE ONLY public.users ALTER COLUMN user_id SET DEFAULT nextval('public.users_user_id_seq'::regclass);


--
-- Data for Name: hash_post; Type: TABLE DATA; Schema: public; Owner: postgres
--

COPY public.hash_post (hash_post_id, hash_tag_id, post_id) FROM stdin;
1	1	1
2	2	1
3	1	2
5	2	4
6	4	4
\.


--
-- Data for Name: hash_tags; Type: TABLE DATA; Schema: public; Owner: postgres
--

COPY public.hash_tags (hash_tag_id, hash_name) FROM stdin;
1	@NithinAppy
2	@Donly
3	@sanjuSandy
4	@TulaiRam
\.


--
-- Data for Name: likes; Type: TABLE DATA; Schema: public; Owner: postgres
--

COPY public.likes (like_id, post_id, user_id, created_at) FROM stdin;
1	1	1	2022-03-14 20:09:28.757845+05:30
2	1	2	2022-03-14 20:09:28.757845+05:30
3	1	1	2022-03-14 20:09:28.757845+05:30
5	1	7	2022-03-14 20:09:28.757845+05:30
6	2	5	2022-03-14 20:09:28.757845+05:30
\.


--
-- Data for Name: posts; Type: TABLE DATA; Schema: public; Owner: postgres
--

COPY public.posts (post_id, post_type, user_id, created_at) FROM stdin;
1	Image	1	2022-03-14 18:23:05.159819+05:30
2	Audio	1	2022-03-14 18:23:05.159819+05:30
3	Music	7	2022-03-14 18:23:05.159819+05:30
4	Image	5	2022-03-14 18:23:05.159819+05:30
\.


--
-- Data for Name: users; Type: TABLE DATA; Schema: public; Owner: postgres
--

COPY public.users (user_id, first_name, last_name, user_name, email, mobile, bio, address, passcode, created_at) FROM stdin;
2	Apple	Appy	AppleAppy	appleappy@gmail.com	8976543210	Trust No One Kill Any One Be Only One	Hyderabad	123	2022-03-13 14:42:39.523945+05:30
1	Nithin	Appy	Donly	nithinappy@gmail.com	9876543210	Trust No One Kill Any One Be Only One	Hyderabad	123	2022-03-13 14:42:39.523945+05:30
5	randy	ran	randy	randy@gmail.com	9876543280	i will kill you	Krim NAgar	123	2022-03-13 14:42:39.523945+05:30
6	sanny	sunju	sanjusanny	sanju@gmail.com	9876543209	I am Sunny Sanju	Karim Nagar	123	2022-03-13 14:42:39.523945+05:30
7	Valli	Ravali	BtsValli	valli@gmail.com	9587643210	I Love BTS	KarimNagar	321	2022-03-13 14:42:39.523945+05:30
\.


--
-- Name: hash_post_hash_post_id_seq; Type: SEQUENCE SET; Schema: public; Owner: postgres
--

SELECT pg_catalog.setval('public.hash_post_hash_post_id_seq', 6, true);


--
-- Name: hash_tags_hash_tag_id_seq; Type: SEQUENCE SET; Schema: public; Owner: postgres
--

SELECT pg_catalog.setval('public.hash_tags_hash_tag_id_seq', 5, true);


--
-- Name: likes_like_id_seq; Type: SEQUENCE SET; Schema: public; Owner: postgres
--

SELECT pg_catalog.setval('public.likes_like_id_seq', 6, true);


--
-- Name: posts_post_id_seq; Type: SEQUENCE SET; Schema: public; Owner: postgres
--

SELECT pg_catalog.setval('public.posts_post_id_seq', 4, true);


--
-- Name: users_user_id_seq; Type: SEQUENCE SET; Schema: public; Owner: postgres
--

SELECT pg_catalog.setval('public.users_user_id_seq', 7, true);


--
-- Name: hash_post hash_post_pkey; Type: CONSTRAINT; Schema: public; Owner: postgres
--

ALTER TABLE ONLY public.hash_post
    ADD CONSTRAINT hash_post_pkey PRIMARY KEY (hash_post_id);


--
-- Name: hash_tags hash_tags_pkey; Type: CONSTRAINT; Schema: public; Owner: postgres
--

ALTER TABLE ONLY public.hash_tags
    ADD CONSTRAINT hash_tags_pkey PRIMARY KEY (hash_tag_id);


--
-- Name: likes likes_pkey; Type: CONSTRAINT; Schema: public; Owner: postgres
--

ALTER TABLE ONLY public.likes
    ADD CONSTRAINT likes_pkey PRIMARY KEY (like_id);


--
-- Name: posts posts_pkey; Type: CONSTRAINT; Schema: public; Owner: postgres
--

ALTER TABLE ONLY public.posts
    ADD CONSTRAINT posts_pkey PRIMARY KEY (post_id);


--
-- Name: users users_email_key; Type: CONSTRAINT; Schema: public; Owner: postgres
--

ALTER TABLE ONLY public.users
    ADD CONSTRAINT users_email_key UNIQUE (email);


--
-- Name: users users_mobile_key; Type: CONSTRAINT; Schema: public; Owner: postgres
--

ALTER TABLE ONLY public.users
    ADD CONSTRAINT users_mobile_key UNIQUE (mobile);


--
-- Name: users users_pkey; Type: CONSTRAINT; Schema: public; Owner: postgres
--

ALTER TABLE ONLY public.users
    ADD CONSTRAINT users_pkey PRIMARY KEY (user_id);


--
-- Name: hash_post hash_post_hash_tag_id_fkey; Type: FK CONSTRAINT; Schema: public; Owner: postgres
--

ALTER TABLE ONLY public.hash_post
    ADD CONSTRAINT hash_post_hash_tag_id_fkey FOREIGN KEY (hash_tag_id) REFERENCES public.hash_tags(hash_tag_id) ON DELETE CASCADE;


--
-- Name: hash_post hash_post_post_id_fkey; Type: FK CONSTRAINT; Schema: public; Owner: postgres
--

ALTER TABLE ONLY public.hash_post
    ADD CONSTRAINT hash_post_post_id_fkey FOREIGN KEY (post_id) REFERENCES public.posts(post_id) ON DELETE CASCADE;


--
-- Name: likes likes_post_id_fkey; Type: FK CONSTRAINT; Schema: public; Owner: postgres
--

ALTER TABLE ONLY public.likes
    ADD CONSTRAINT likes_post_id_fkey FOREIGN KEY (post_id) REFERENCES public.posts(post_id) ON DELETE CASCADE;


--
-- Name: likes likes_user_id_fkey; Type: FK CONSTRAINT; Schema: public; Owner: postgres
--

ALTER TABLE ONLY public.likes
    ADD CONSTRAINT likes_user_id_fkey FOREIGN KEY (user_id) REFERENCES public.users(user_id) ON DELETE CASCADE;


--
-- Name: posts posts_user_id_fkey; Type: FK CONSTRAINT; Schema: public; Owner: postgres
--

ALTER TABLE ONLY public.posts
    ADD CONSTRAINT posts_user_id_fkey FOREIGN KEY (user_id) REFERENCES public.users(user_id) ON DELETE CASCADE;


--
-- PostgreSQL database dump complete
--

