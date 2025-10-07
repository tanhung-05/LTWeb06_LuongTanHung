create database QLSP
use QLSP

create table tbl_NhaSanXuat
(
	MaNSX char(10) primary key,
	TenNSX nvarchar(50)
)

create table tbl_Loai
(
	MaLoai char(10) primary key,
	TenLoai nvarchar(50)
)

create table tbl_SanPham
(
	MaSanPham char(10) primary key,
	TenSP nvarchar(50),
	MaL char(10),
	MaSX char(10),
	Gia money,
	GhiChu nvarchar(100),
	Hinh nvarchar(50)
	constraint fk_SanPham_Loai foreign key(MaL) references tbl_Loai(MaLoai),
	constraint fk_SanPham_NhaSanXuat foreign key(MaSX) references tbl_NhaSanXuat(MaNSX)
)

create table tbl_KhachHang
(
	MaKhachHang char(10) primary key,
	TenKhachHang nvarchar(50),
	SoDienThoai nchar(10),
	MatKhau nchar(50)
)

create table tbl_HoaDon
(
	MaHoaDon char(10) primary key,
	NgayTao date,
	MaKH char(10)
	constraint fk_HoaDon_KhachHang  foreign key(MaKH) references tbl_KhachHang(MaKhachHang)
)

create table tbl_ChiTiet
(
	MaHD char(10),
	MaSP char(10),
	SoLuong int
	constraint pk_ChiTiet primary key(MaHD, MaSP)
	constraint fk_ChiTiet_HoaDon foreign key(MaHD) references tbl_HoaDon(MaHoaDon),
	constraint fk_ChiTiet_SanPham foreign key(MaSP) references tbl_SanPham(MaSanPham)
)

INSERT INTO tbl_NhaSanXuat VALUES
('01', N'NXB Giáo dục'),
('02', N'NXB Từ điển Bách khoa'),
('03', N'NXB Đại học Quốc gia'),
('04', N'NXB Kim Đồng'),
('05', N'NXB Văn học');

insert into tbl_Loai values
('01', N'Sách giáo khoa'),
('02', N'Sách từ điển'),
('03', N'Sách đại học'),
('04', N'Truyện tranh')

INSERT INTO tbl_SanPham(MaSanPham, TenSP, MaL, MaSX, Gia, GhiChu, Hinh) VALUES
('01', N'Toán 12',        '01', '01', 50000,  N'SGK lớp 12',       'toan12.jpg'),
('02', N'Từ điển Anh-Việt','02', '02', 120000, N'Từ điển song ngữ', 'avdict.jpg'),
('03', N'Giải tích A1',   '03', '03', 80000,  N'Sách ĐH Toán',     'giaitica1.jpg'),
('04', N'Doraemon tập 1', '04', '04', 25000,  N'Truyện tranh',     'dora1.jpg'),
('05', N'Ngữ văn 9',      '01', '01', 40000,  N'SGK cấp 2',        'van9.jpg');

INSERT INTO tbl_KhachHang(MaKhachHang, TenKhachHang, SoDienThoai, MatKhau) VALUES
('01', N'Nguyễn Văn A', '0900000001', 'pass1'),
('02', N'Trần Thị B',   '0900000002', 'pass2'),
('03', N'Lê Văn C',     '0900000003', 'pass3'),
('04', N'Phạm Thị D',   '0900000004', 'pass4'),
('05', N'Hồ Văn E',     '0900000005', 'pass5');

INSERT INTO tbl_HoaDon(MaHoaDon, NgayTao, MaKH) VALUES
('01', '2023-11-01', '01'),
('02', '2023-11-02', '02'),
('03', '2023-11-03', '03'),
('04', '2023-11-04', '04'),
('05', '2023-11-05', '05');

INSERT INTO tbl_ChiTiet(MaHD, MaSP, SoLuong) VALUES
('01', '01', 2),
('01', '05', 1),
('02', '02', 1),
('03', '03', 2),
('04', '04', 5);