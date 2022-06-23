create database TungStoreDB
go
USE TungStoreDB
go

create table LOAIHANG
(
	IDLoaiHang int identity,
	TenLoaiHang nvarchar(30)
	primary key (IDLoaiHang)
)
create table HANGHOA
(
	IDHangHoa int identity primary key,
	IDLoaiHang int  foreign key references LOAIHANG(IDLoaiHang),
	SoLuongHienCo int,
	TenLoaiHang nvarchar(100),
	GiaBan bigint,
	GiamGia int,
	GiaKhuyenMai bigint
)
create table PHANQUYEN
(
	IDPhanQuyen int primary key,
	TenQuyenHan nvarchar(20)
)
create table LOAIKHACHHANG
(
	IDLoaiKhachHang int identity primary key,
	TenLoaiKhachHang nvarchar(30),
	ChietKhau int
)
create table KHACHHANG
(
	IDKhachHang int identity primary key,
	TenKhachHang nvarchar(100),
	DiaChi nvarchar(100),
	SDT nvarchar(12),
	IDLoaiKhachHang int foreign key references LOAIKHACHHANG(IDLoaiKhachHang),
	IDPhanQuyen int foreign key references PHANQUYEN(IDPhanQuyen)
)
create table NHANVIEN
(
	IDNhanVien int identity primary key,
	TenNhanVien nvarchar(100),
	DiaChi nvarchar(100),
	SDT nvarchar(12),
	NgayVaoLam date,
	IDPhanQuyen int foreign key references PHANQUYEN(IDPhanQuyen)
)
create table HOADONXUAT
(
	idHoaDonXuat int identity primary key,
	IDKhachHang int foreign key references KHACHHANG(IDKhachHang),
	IDNhanVien int foreign key references NHANVIEN(IDNhanVien),
	IDHangHoa int foreign key references HANGHOA(IDHangHoa)
)
create table ChiTietHoaDonXuat
(
	idHoaDonXuat int identity foreign key references HOADONXUAT(IDHOADONXUAT),
	IDHangHoa int foreign key references HangHoa(IDHangHoa),
	SoLuongXuat int,
	GiaBan bigint,
	TongTien bigint,
	NgayXuat datetime,
	DaThanhToan bit
)
create table NhaCungCap
(
	IDNhaCungCap int identity primary key,
	TenNhaCungCap nvarchar(50),
	DiaChiNhaCungCap nvarchar(100),
)

create table HoaDonNhap
(
	idHoaDonNhap int identity primary key,
	IDNhaCungCap int foreign key references NhaCungCap(IDNhaCungCap),
	IDNhanVien int foreign key references NhanVien(IDNhanVien),
	IDHangHoa int foreign key references HANGHOA(IDHangHoa)
)
create table ChiTietHoaDonNhap
(
	idHoaDonNhap int identity foreign key references HoaDonNhap(IDHoaDonNhap),
	IDHangHoa int foreign key references HangHoa(IDHangHoa),
	SoLuongNhap int,
	GiaNhap bigint,
	TongTien bigint,
	NgayNhap datetime
)

go
drop proc sp_selecttop4
go
create proc sp_selecttop4 @idLoaiHang int
as
select top 4 * 
from LOAIHANG join HANGHOA on HANGHOA.IDLoaiHang=LOAIHANG.IDLoaiHang
where LOAIHANG.IDLoaiHang=@idLoaiHang
order by HANGHOA.GiaBan desc
go
exec sp_selecttop4 1