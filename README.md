# UAS_PBO_F6

/*
Transaksi table pemilik
*/
CREATE TABLE pemilik (
  pemilik_id serial PRIMARY KEY,
  nama_pemilik VARCHAR (155)
);

/*login table create*/
CREATE TABLE login(
   login_id serial primary key,
   pemilik_id serial,
   login_email VARCHAR(255) unique NOT NULL,
   login_password VARCHAR(100) not null,
   CONSTRAINT fk_pemilik
      FOREIGN KEY(pemilik_id) 
	  REFERENCES pemilik(pemilik_id)
);

/*
Stock table create
*/

CREATE TABLE stock (
	stock_id serial PRIMARY KEY,
	pemilik_id int not null,
	stock_name varchar(255) not null,
	stock_jenis varchar(255) not null,
	stock_kuantitas int not null,
	CONSTRAINT fk_pemilik_and_transaksi
	FOREIGN KEY(pemilik_id) 
	REFERENCES pemilik(pemilik_id)
);

/*
Transaksi table create
*/

CREATE TABLE transaksi (
	trs_id serial PRIMARY KEY,
	pemilik_id int not null,
	trs_keterangan varchar(255) not null,
	trs_pemasukan int not null,
	trs_pengeluaran int not null,
	CONSTRAINT fk_pemilik_and_transaksi
	FOREIGN KEY(pemilik_id) 
	REFERENCES pemilik(pemilik_id)
);

/*
Karyawan table create
*/
CREATE TABLE karyawan(
   karyawan_id serial primary key,
   pemilik_id int,
   karyawan_nama VARCHAR(255) not NULL,
   karyawan_umur VARCHAR(4) not null,
	karyawan_alamat VARCHAR(255) not NULL,
	karyawan_no_hp VARCHAR(30) not NULL,
	karyawan_gaji int not null,
   CONSTRAINT fk_pemilik_and_karyawan
      FOREIGN KEY(pemilik_id) 
	  REFERENCES pemilik(pemilik_id)
);



