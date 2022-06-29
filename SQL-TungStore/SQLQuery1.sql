go
drop database TungStoreDB
go
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
create table HANGSANXUAT
(
	IDHangSanXuat nvarchar(10) primary key,
	IDLoaiHang int foreign key references LOAIHANG(IDLoaiHang),
	TenHangSX nvarchar(50)
)
create table HANGHOA
(
	IDHangHoa int identity primary key,
	IDLoaiHang int  foreign key references LOAIHANG(IDLoaiHang),
	IDHangSanXuat nvarchar(10) foreign key references HANGSANXUAT(IDHangSanXuat),
	SoLuongHienCo int,
	TenLoaiHang nvarchar(100),
	GiaBan bigint,
	GiamGia int,
	GiaKhuyenMai bigint,
	MoTaNgan nvarchar(max),
	MoTaChiTiet nvarchar(max),
	ThongSoKiThuat nvarchar(max)
)

create table PHANQUYEN
(
	IDPhanQuyen int primary key,
	TenQuyenHan nvarchar(40),

)
create table LOAIKHACHHANG
(
	IDLoaiKhachHang int identity primary key,
	TenLoaiKhachHang nvarchar(30),
	ChietKhau int
)
create table TAIKHOAN
(
	IDTaiKhoan int identity primary key,
	IDDangNhap nvarchar(30),
	Pass nvarchar(30),
	Active bit,
	IDPhanQuyen int foreign key references PHANQUYEN(IDPhanQuyen)
)
create table KHACHHANG
(
	IDKhachHang int identity primary key,
	TenKhachHang nvarchar(100),
	DiaChi nvarchar(100),
	SDT nvarchar(12),
	Email nvarchar(100),
	IDLoaiKhachHang int foreign key references LOAIKHACHHANG(IDLoaiKhachHang),
	IDTaiKhoan int foreign key references TAIKHOAN(IDTaiKhoan),
)
create table NHANVIEN
(
	IDNhanVien int identity primary key,
	TenNhanVien nvarchar(100),
	DiaChi nvarchar(100),
	SDT nvarchar(12),
	NgayVaoLam date,
	IDTaiKhoan int foreign key references TAIKHOAN(IDTaiKhoan)
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

insert into LOAIHANG (TenLoaiHang) values ('CPU')
insert into LOAIHANG (TenLoaiHang) values ('Mainboard')
insert into LOAIHANG (TenLoaiHang) values ('VGA')
insert into LOAIHANG (TenLoaiHang) values ('Case')
insert into LOAIHANG (TenLoaiHang) values ('Master Air')
insert into LOAIHANG (TenLoaiHang) values ('Fan Led')
insert into LOAIHANG (TenLoaiHang) values ('Screen')

insert into HANGSANXUAT(IDHangSanXuat,IDLoaiHang,TenHangSX) values ('A1','1','Intel')
insert into HANGSANXUAT(IDHangSanXuat,IDLoaiHang,TenHangSX) values ('A2','1','AMD')
insert into HANGSANXUAT(IDHangSanXuat,IDLoaiHang,TenHangSX) values ('B1','2','Asus')
insert into HANGSANXUAT(IDHangSanXuat,IDLoaiHang,TenHangSX) values ('B2','2','Gigabyte')
insert into HANGSANXUAT(IDHangSanXuat,IDLoaiHang,TenHangSX) values ('B3','2','MSI')
insert into HANGSANXUAT(IDHangSanXuat,IDLoaiHang,TenHangSX) values ('C1','3','Asus')
insert into HANGSANXUAT(IDHangSanXuat,IDLoaiHang,TenHangSX) values ('C2','3','Gigabyte')
insert into HANGSANXUAT(IDHangSanXuat,IDLoaiHang,TenHangSX) values ('C3','3','MSI')
insert into HANGSANXUAT(IDHangSanXuat,IDLoaiHang,TenHangSX) values ('D1','4','Xigmatek')
insert into HANGSANXUAT(IDHangSanXuat,IDLoaiHang,TenHangSX) values ('D2','4','Cooler Master')
insert into HANGSANXUAT(IDHangSanXuat,IDLoaiHang,TenHangSX) values ('E1','5','All IN ONE')
insert into HANGSANXUAT(IDHangSanXuat,IDLoaiHang,TenHangSX) values ('E2','5','Cooler Master')
insert into HANGSANXUAT(IDHangSanXuat,IDLoaiHang,TenHangSX) values ('F1','6','Xigmatek')
insert into HANGSANXUAT(IDHangSanXuat,IDLoaiHang,TenHangSX) values ('G1','7','LG')
insert into HANGSANXUAT(IDHangSanXuat,IDLoaiHang,TenHangSX) values ('G2','7','MSI')
insert into HANGSANXUAT(IDHangSanXuat,IDLoaiHang,TenHangSX) values ('G3','7','Dell')
insert into HANGSANXUAT(IDHangSanXuat,IDLoaiHang,TenHangSX) values ('G4','7','Asus')

--CPU
insert into HANGHOA (IDLoaiHang,TenLoaiHang,IDHangSanXuat,GiaBan,GiamGia) 
values ('1','Intel Core I7-11700K','A1','9900000','25')
insert into HANGHOA (IDLoaiHang,TenLoaiHang,IDHangSanXuat,GiaBan,GiamGia) 
values ('1','Intel Core I5-12600KF','A1','7500000','18')
insert into HANGHOA (IDLoaiHang,TenLoaiHang,IDHangSanXuat,GiaBan,GiamGia) 
values ('1','Intel Core I7-10700','A1','8000000','19')
insert into HANGHOA (IDLoaiHang,TenLoaiHang,IDHangSanXuat,GiaBan,GiamGia) 
values ('1','Intel Core I7-10700K','A1','8200000','11')
insert into HANGHOA (IDLoaiHang,TenLoaiHang,IDHangSanXuat,GiaBan,GiamGia) 
values ('1','Intel Core I9-11900KF','A1','11000000','9')
insert into HANGHOA (IDLoaiHang,TenLoaiHang,IDHangSanXuat,GiaBan,GiamGia) 
values ('1','AMD Ryzen 9 5900X','A2','15000000','22')
insert into HANGHOA (IDLoaiHang,TenLoaiHang,IDHangSanXuat,GiaBan,GiamGia) 
values ('1','AMD Ryzen 9 5950X','A2','21000000','11')
insert into HANGHOA (IDLoaiHang,TenLoaiHang,IDHangSanXuat,GiaBan,GiamGia) 
values ('1','AMD Athlon 3000G','A2','3000000','9')
insert into HANGHOA (IDLoaiHang,TenLoaiHang,IDHangSanXuat,GiaBan,GiamGia) 
values ('1','AMD Ryzen 3 4100 MPK','A2','4000000','11')

--MainBoard
insert into HANGHOA (IDLoaiHang,TenLoaiHang,IDHangSanXuat,GiaBan,GiamGia) 
values ('2','Asus ROG Z590 E Gaming','B1','8500000','12')
insert into HANGHOA (IDLoaiHang,TenLoaiHang,IDHangSanXuat,GiaBan,GiamGia) 
values ('2','Asus ROG Z690 G Gaming Plus','B1','7000000','15')
insert into HANGHOA (IDLoaiHang,TenLoaiHang,IDHangSanXuat,GiaBan,GiamGia) 
values ('2','GiGaByte X 570S AERO G','B2','8300000','18')
insert into HANGHOA (IDLoaiHang,TenLoaiHang,IDHangSanXuat,GiaBan,GiamGia) 
values ('2','GiGaByte Z690 AORUS Ultra','B2','8000000','11')
insert into HANGHOA (IDLoaiHang,TenLoaiHang,IDHangSanXuat,GiaBan,GiamGia) 
values ('2','MSI B360 Gaming Pro Carbon','B3','4100000','8')
insert into HANGHOA (IDLoaiHang,TenLoaiHang,IDHangSanXuat,GiaBan,GiamGia) 
values ('2','MSI MPG Z590 Gaming Edge Wifi','B1','9400000','11')
insert into HANGHOA (IDLoaiHang,TenLoaiHang,IDHangSanXuat,GiaBan,GiamGia) 
values ('2','Asus ProArt B660-Creator','B1','7000000','12')
insert into HANGHOA (IDLoaiHang,TenLoaiHang,IDHangSanXuat,GiaBan,GiamGia) 
values ('2','Gigabyte B550 AORUS MASTER','B3','8300000','16')
insert into HANGHOA (IDLoaiHang,TenLoaiHang,IDHangSanXuat,GiaBan,GiamGia) 
values ('2','Asus PRIME H410M-D','B1','2000000','12')
insert into HANGHOA (IDLoaiHang,TenLoaiHang,IDHangSanXuat,GiaBan,GiamGia) 
values ('2','ASUS ROG MAXIMUS XIII HERO','B1','15000000','14')
insert into HANGHOA (IDLoaiHang,TenLoaiHang,IDHangSanXuat,GiaBan,GiamGia) 
values ('2','MSI B550M-A PRO','B3','4000000','0')

--VGA
insert into HANGHOA (IDLoaiHang,TenLoaiHang,IDHangSanXuat,GiaBan,GiamGia) 
values ('3','Asus ROG Strix RTX 3050 8GB','C1','12000000','0')
insert into HANGHOA (IDLoaiHang,TenLoaiHang,IDHangSanXuat,GiaBan,GiamGia) 
values ('3','Asus 4GB TUF RX 6500 XT O4G Gaming','C1','7000000','0')
insert into HANGHOA (IDLoaiHang,TenLoaiHang,IDHangSanXuat,GiaBan,GiamGia) 
values ('3','Gigabyte 6GB GV-N2060D6-6GD','C2','16000000','32')
insert into HANGHOA (IDLoaiHang,TenLoaiHang,IDHangSanXuat,GiaBan,GiamGia) 
values ('3','Asus TUF GTX 1650 4G','C1','7000000','15')
insert into HANGHOA (IDLoaiHang,TenLoaiHang,IDHangSanXuat,GiaBan,GiamGia) 
values ('3','MSI 1GB GT 710 1GD3H LP','C3','2000000','33')
insert into HANGHOA (IDLoaiHang,TenLoaiHang,IDHangSanXuat,GiaBan,GiamGia) 
values ('3','Gigabyte RADEON RX 6600 XT EAGLE 8G','C2','16000000','22')
insert into HANGHOA (IDLoaiHang,TenLoaiHang,IDHangSanXuat,GiaBan,GiamGia) 
values ('3','Asus PH - GTX 1650-O4G DDR6','C1','8000000','11')
insert into HANGHOA (IDLoaiHang,TenLoaiHang,IDHangSanXuat,GiaBan,GiamGia) 
values ('3','Gigabyte 12GB Radeon RX 6700 XT EAGLE','C2','24000000','9')

--Case
insert into HANGHOA (IDLoaiHang,TenLoaiHang,IDHangSanXuat,GiaBan,GiamGia) 
values ('4','Xigmatek X7','D1','2700000','0')

insert into HANGHOA (IDLoaiHang,TenLoaiHang,IDHangSanXuat,GiaBan,GiamGia) 
values ('4','Xigmatek Venom EN41497','D1','2000000','33')
insert into HANGHOA (IDLoaiHang,TenLoaiHang,IDHangSanXuat,GiaBan,GiamGia) 
values ('4','Cooler Master BOX MB500 ARGB','D2','2100000','0')
insert into HANGHOA (IDLoaiHang,TenLoaiHang,IDHangSanXuat,GiaBan,GiamGia) 
values ('4','Cooler Master Master BOX K500 TG ARGB','D2','2200000','10')
insert into HANGHOA (IDLoaiHang,TenLoaiHang,IDHangSanXuat,GiaBan,GiamGia) 
values ('4','Xigmatek Ventus 3FC','D1','800000','9')
insert into HANGHOA (IDLoaiHang,TenLoaiHang,IDHangSanXuat,GiaBan,GiamGia) 
values ('4','Xigmatek Aquarius S Queen','D1','1700000','9')
insert into HANGHOA (IDLoaiHang,TenLoaiHang,IDHangSanXuat,GiaBan,GiamGia) 
values ('4','Cooler Master Mastercase H500P','D2','4300000','15')
insert into HANGHOA (IDLoaiHang,TenLoaiHang,IDHangSanXuat,GiaBan,GiamGia) 
values ('4','Cooler Master MasterBox TD500','D2','2200000','11')


--Master Air
insert into HANGHOA (IDLoaiHang,TenLoaiHang,IDHangSanXuat,GiaBan,GiamGia) 
values ('5','MSI MAG CoreLiquid 240R','E1','4100000','11')
insert into HANGHOA (IDLoaiHang,TenLoaiHang,IDHangSanXuat,GiaBan,GiamGia) 
values ('5','ID-COOLING ZOOMFLOW 240XT SNOW','E1','2200000','11')
insert into HANGHOA (IDLoaiHang,TenLoaiHang,IDHangSanXuat,GiaBan,GiamGia) 
values ('5','Cooler Master Hyper 212 Spectrum (ARGB)','E2','800000','7')
insert into HANGHOA (IDLoaiHang,TenLoaiHang,IDHangSanXuat,GiaBan,GiamGia) 
values ('5','Cooler Master Hyper 212 Spectrum V2','E2','9600000','14')
insert into HANGHOA (IDLoaiHang,TenLoaiHang,IDHangSanXuat,GiaBan,GiamGia) 
values ('5','Asus Rog Ryujin II 360','E1','9700000','13')
insert into HANGHOA (IDLoaiHang,TenLoaiHang,IDHangSanXuat,GiaBan,GiamGia) 
values ('5','Cooler Master Masterair MA610P','E2','1800000','15')
insert into HANGHOA (IDLoaiHang,TenLoaiHang,IDHangSanXuat,GiaBan,GiamGia) 
values ('5','ID cooling auraflow X 240','E1','1800000','12')

--Fan Led
insert into HANGHOA (IDLoaiHang,TenLoaiHang,IDHangSanXuat,GiaBan,GiamGia) 
values ('6','Xigmatek Galaxy III Starz X20A Arctic White ARGB','F1','460000','0')
insert into HANGHOA (IDLoaiHang,TenLoaiHang,IDHangSanXuat,GiaBan,GiamGia) 
values ('6','Xigmatek GALAXY III ROYAL - BR120 ARGB','F1','790000','0')
insert into HANGHOA (IDLoaiHang,TenLoaiHang,IDHangSanXuat,GiaBan,GiamGia) 
values ('6','Xigmatek Galaxy III Royal ARTIC BR120 ARGB','F1','860000','0')
insert into HANGHOA (IDLoaiHang,TenLoaiHang,IDHangSanXuat,GiaBan,GiamGia) 
values ('6','Xigmatek Galaxy III Essential BX120 ARGB','F1','560000','0')

--Screen
insert into HANGHOA (IDLoaiHang,TenLoaiHang,IDHangSanXuat,GiaBan,GiamGia) 
values ('7','LCD LG 27UL850-W 27 4K','G1','15000000','11')
insert into HANGHOA (IDLoaiHang,TenLoaiHang,IDHangSanXuat,GiaBan,GiamGia) 
values ('7','LCD MSI Optix G272 27 inch','G2','7400000','0')
insert into HANGHOA (IDLoaiHang,TenLoaiHang,IDHangSanXuat,GiaBan,GiamGia) 
values ('7','LCD Dell U2422H','G3','8000000','11')
insert into HANGHOA (IDLoaiHang,TenLoaiHang,IDHangSanXuat,GiaBan,GiamGia) 
values ('7','LCD Dell U2722DE','G3','4300000','0')
insert into HANGHOA (IDLoaiHang,TenLoaiHang,IDHangSanXuat,GiaBan,GiamGia) 
values ('7','LCD LG UltraGear 38GN950','G1','38000000','12')
insert into HANGHOA (IDLoaiHang,TenLoaiHang,IDHangSanXuat,GiaBan,GiamGia) 
values ('7','LCD MSI OPTIX MAG27C 27 inch','G2','8000000','14')
insert into HANGHOA (IDLoaiHang,TenLoaiHang,IDHangSanXuat,GiaBan,GiamGia) 
values ('7','LCD Asus VA326H 32 inch','G4','10000000','17')
insert into HANGHOA (IDLoaiHang,TenLoaiHang,IDHangSanXuat,GiaBan,GiamGia) 
values ('7','LCD Dell UP2516D-25 inch','G3','11000000','18')
insert into HANGHOA (IDLoaiHang,TenLoaiHang,IDHangSanXuat,GiaBan,GiamGia) 
values ('7','LCD Asus VA32AQ IPS 2K','G4','9800000','9')
insert into HANGHOA (IDLoaiHang,TenLoaiHang,IDHangSanXuat,GiaBan,GiamGia) 
values ('7','LCD Asus VA325H 32 inch','G4','8000000','11')
insert into HANGHOA (IDLoaiHang,TenLoaiHang,IDHangSanXuat,GiaBan,GiamGia) 
values ('7','LCD Dell U2422H','G3','15000000','14')
insert into HANGHOA (IDLoaiHang,TenLoaiHang,IDHangSanXuat,GiaBan,GiamGia) 
values ('7','LCD MSI OPTIX MAG271C','G2','8100000','11')

ALTER TABLE KHACHHANG
ADD UrlHinhAnh nvarchar(max);
AlTER TABLE PHANQUYEN
ALTER COLUMN TENQUYENHAN nvarchar(40)

insert into PHANQUYEN values ('1','Admin')
insert into PHANQUYEN values ('2','Nhân Viên Bán Hàng')
insert into PHANQUYEN values ('3','Nhân Viên Quản Lý')
insert into PHANQUYEN values ('4','Khách Hàng')

insert into TAIKHOAN values ('admin','admin','true','1')
insert into TAIKHOAN values ('employee1','employee1','true','2')
insert into TAIKHOAN values ('employee2','employee2','true','2')
insert into TAIKHOAN values ('employee3','employee3','true','2')
insert into TAIKHOAN values ('employee4','employee4','true','3')
insert into TAIKHOAN values ('customer1','customer1','true','4')
insert into TAIKHOAN values ('customer2','customer2','true','4')
insert into TAIKHOAN values ('customer3','customer3','true','4')
insert into TAIKHOAN values ('customer4','customer4','true','4')
insert into TAIKHOAN values ('customer5','customer5','true','4')
--Khách Hàng
insert into KHACHHANG (TenKhachHang,DiaChi,SDT,Email,IDTaiKhoan)
values ('Trần Văn An','245 Âu Cơ Liên Chiểu Đà Nẵng','012345678','vanan69@gmail.com','6')
insert into KHACHHANG (TenKhachHang,DiaChi,SDT,Email,IDTaiKhoan)
values ('Nguyễn Văn B','75 Bạch Đằng Đà Nẵng','012356478','nguyenvanb69@gmail.com','7')
insert into KHACHHANG (TenKhachHang,DiaChi,SDT,Email,IDTaiKhoan)
values ('Mitsuha','Tokyo Japan','0169696969','mitsuha@gmail.com','8')
insert into KHACHHANG (TenKhachHang,DiaChi,SDT,Email,IDTaiKhoan)
values ('Taki','Tokyo Japan','0126555222','taki@gmail.com','9')
insert into KHACHHANG (TenKhachHang,DiaChi,SDT,Email,IDTaiKhoan)
values ('Trần Khách','245 Âu Cơ Liên Chiểu Đà Nẵng','012355544','trankhach@gmail.com','10')
--Nhan Vien
insert into NHANVIEN values ('Tùng Lê','245 Âu Cơ Liên Chiểu Đà Nẵng','011111111','','1')
insert into NHANVIEN values ('Trần Thị Vui','200 Âu Cơ Liên Chiểu Đà Nẵng','0165686238','','2')
insert into NHANVIEN values ('Nguyễn Thắng Lợi','200 Lê Lợi Liên Chiểu Đà Nẵng','0526341235','','3')
insert into NHANVIEN values ('Trần Vội Vàng','80 Trần Nam Trung Cẩm Lệ Đà Nẵng','0145614566','','4')
insert into NHANVIEN values ('Lê Thị Bích Thủy','77 Núi Thành Liên Chiểu Đà Nẵng','0164124655','','5')
