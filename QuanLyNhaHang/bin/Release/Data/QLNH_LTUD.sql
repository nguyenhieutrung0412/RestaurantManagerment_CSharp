Create database QLNhaHang;
go 
USE QLNhaHang;
go
Create table NhanVien(
MaNV char(10) NOT NULL CONSTRAINT PK_MaNV PRIMARY KEY(MaNV)
,HoTen nvarchar(40)
,NgaySinh date
,GioiTinh nvarchar(3)
,DiaChi nvarchar(40)
,SDT char(12)
,Email char(40)
)
go
create table KhachHang(
MaKH char(10) NOT NULL CONSTRAINT PK_MaKH PRIMARY KEY(MaKH)
,HoTen nvarchar(30)
,SDT char(12)
,DiaChi nvarchar(30)
,Email char(30)
,MaLoaiKH char(10)
)

go
Create table LoaiKhachHang(
MaLoaiKH char(10) NOT NULL CONSTRAINT PK_MaLoaiKH PRIMARY KEY(MaLoaiKH)
,TenLoaiKH nvarchar(40)
)

go
Create table KhuVuc(
MaKhuVuc char(10)NOT NULL CONSTRAINT PK_MaKhuVuc PRIMARY KEY(MaKhuVuc)
,TenKhuVuc nvarchar(30)
,TrangThai nvarchar(30)
)
go
Create table Ban(
MaBan char(10)NOT NULL CONSTRAINT PK_MaBan PRIMARY KEY(MaBan)
,TrangThai nvarchar(30)
,MaKhuVuc char(10)
)
go
Create table MonAn(
MaMonAn char(10)NOT NULL CONSTRAINT PK_MaMonAn PRIMARY KEY(MaMonAn)
,TenMonAn nvarchar(30)
,DonGia float
)
go
Create table ThanhToan(
MaThanhToan char(10)NOT NULL CONSTRAINT PK_MaThanhToan PRIMARY KEY(MaThanhToan)
,MaNV char(10)
,MaBan char(10)
,MaMonAn char(10)
,SoLuong int
,TongTien float
)
go

--Khoa Ngoai lien ket cac bang
-- Table ban 
Alter table Ban add CONSTRAINT FK_Ban_MaKhuVuc FOREIGN KEY (MaKhuVuc) REFERENCES KhuVuc(MaKhuVuc)
go
--table Thanh Toan
Alter table ThanhToan add CONSTRAINT FK_ThanhToan_MaNV FOREIGN KEY (MaNV) REFERENCES NhanVien(MaNV)
go
Alter table ThanhToan add CONSTRAINT FK_ThanhToan_MaBan FOREIGN KEY (MaBan) REFERENCES Ban(MaBan)
go
Alter table ThanhToan add CONSTRAINT FK_ThanhToan_MaMonAn FOREIGN KEY (MaMonAn) REFERENCES MonAn(MaMonAn)
go
Alter table KhachHang add CONSTRAINT FK_KhachHang_maLoai FOREIGN KEY (MaLoaiKH) REFERENCES LoaiKhachHang(MaLoaiKH)
go
--stored procedures them xoa sua cho ban NhanVien
create proc SP_NhanVien_Them(@MaNV char(10),@HoTen nvarchar(40),@NgaySinh date,@GioiTinh nvarchar(3),@DiaChi nvarchar(40),@SDT int,@Email char(40))
as
	INSERT INTO NhanVien(MaNV,HoTen,NgaySinh,GioiTinh,DiaChi,SDT,Email)
	VALUES (@MaNV,@HoTen,@NgaySinh,@GioiTinh,@DiaChi,@SDT,@Email)
go

Create proc SP_NhanVien_Xoa(@MaNV char(10))
as
	DELETE NhanVien where MaNV = @MaNV
go
Create proc SP_NhanVien_Sua(@MaNV char(10),@HoTen nvarchar(40),@NgaySinh date,@GioiTinh nvarchar(3),@DiaChi nvarchar(40),@SDT char(12),@Email char(40))
as
	UPDATE NhanVien set MaNV = @MaNV,HoTen = @HoTen,NgaySinh = @NgaySinh, GioiTinh=@GioiTinh ,DiaChi = @DiaChi,SDT = @SDT,Email = @Email
	WHERE MaNV = @MaNV
go
--Store procedure them xoa sua cho ban Khach hang
create proc SP_KhachHang_Them(@MaKH char(10),@HoTen nvarchar(30),@SDT char(12),@DiaChi nvarchar(30),@Email char(30),@MaLoaiKH char(10))
as
	INSERT INTO KhachHang(MaKH,HoTen,SDT,DiaChi,Email,MaLoaiKH)
	VALUES (@MaKH,@HoTen,@SDT,@DiaChi,@Email,@MaLoaiKH)
go
Create proc SP_KhachHang_Xoa(@MaKH char(10))
as
	DELETE KhachHang where MaKH = @MaKH
go
create proc SP_KhachHang_Sua(@MaKH char(10),@HoTen nvarchar(30),@SDT char(12),@DiaChi nvarchar(30),@Email char(30),@MaLoaiKH char(10))
as
	UPDATE KhachHang set MaKH = @MaKH,HoTen = @HoTen,SDT = @SDT,DiaChi = @DiaChi,Email = @Email, MaLoaiKH = @MaLoaiKH
	WHERE MaKH = @MaKH
go
--Store procedure them xoa sua cho ban Khach hang
create proc SP_LoaiKH_Them(@MaLoaiKH char(10),@TenLoaiKH nvarchar(40))
as
	Insert INTO LoaiKhachHang(MaLoaiKH,TenLoaiKH)
	VALUES(@MaLoaiKH,@TenLoaiKH)
go
Create proc SP_LoaiKH_Xoa(@MaLoaiKH char(10))
as
	DELETE LoaiKhachHang where MaLoaiKH = @MaLoaiKH
go
Create proc SP_LoaiKH_Sua(@MaLoaiKH char(10),@TenLoaiKH nvarchar(40))
as
	UPDATE LoaiKhachHang set MaLoaiKH = @MaLoaiKH ,TenLoaiKH = @TenLoaiKH
	where  MaLoaiKH = @MaLoaiKH
go
--Store procedure them xoa sua cho ban Khu Vuc
create proc SP_KhuVuc_Them(@MaKhuVuc char(10),@TenKhuVuc nvarchar(30),@TrangThai nvarchar(30))
as
	INSERT INTO KhuVuc(MaKhuVuc,TenKhuVuc,TrangThai)
	VALUES (@MaKhuVuc,@TenKhuVuc,@TrangThai)
go
Create proc SP_KhuVuc_Xoa(@MaKhuVuc char(10))
as
	DELETE KhuVuc where MaKhuVuc = @MaKhuVuc
go
Create proc SP_KhuVuc_Sua(@MaKhuVuc char(10),@TenKhuVuc nvarchar(30),@TrangThai nvarchar(30))
as
	UPDATE KhuVuc set MaKhuVuc = @MaKhuVuc,TenKhuVuc = @TenKhuVuc,TrangThai = @TrangThai
	WHERE MaKhuVuc = @MaKhuVuc
go
--Store procedure them xoa sua cho ban Ban
create proc SP_Ban_Them(@MaBan char(10),@TrangThai nvarchar(30),@MaKhuVuc char(10))
as
	INSERT INTO Ban(MaBan,TrangThai,MaKhuVuc)
	VALUES (@MaBan,@TrangThai,@MaKhuVuc)
go
Create proc SP_Ban_Xoa(@MaBan char(10))
as
	DELETE Ban where MaBan = @MaBan
go
Create proc SP_Ban_Sua(@MaBan char(10),@TrangThai nvarchar(30),@MaKhuVuc char(10))
as
	UPDATE Ban set MaBan = @MaBan,TrangThai = @TrangThai,MaKhuVuc = @MaKhuVuc
	WHERE MaBan = @MaBan
go
--Store procedure them xoa sua cho ban Mon An
create proc SP_MonAn_Them(@MaMonAn char(10),@TenMonAn nvarchar(30),@DonGia float)
as
	INSERT INTO MonAn(MaMonAn,TenMonAn,DonGia)
	VALUES (@MaMonAn,@TenMonAn,@DonGia)
go
Create proc SP_MonAn_Xoa(@MaMonAn char(10))
as
	DELETE MonAn where MaMonAn = @MaMonAn
go
Create proc SP_MonAn_Sua(@MaMonAn char(10),@TenMonAn nvarchar(30),@DonGia float)
as
	UPDATE MonAn set MaMonAn = @MaMonAn,TenMonAn = @TenMonAn,DonGia = @DonGia
	WHERE MaMonAn = @MaMonAn
go
--Store procedure them xoa sua cho ban ThanhToan
create proc SP_ThanhToan_Them(@MaThanhToan char(10),@MaNV char(10),@MaBan char(10),@MaMonAn char(10),@SoLuong int,@TongTien float)
as
	INSERT INTO ThanhToan(MaThanhToan,MaNV,MaBan,MaMonAn,SoLuong,TongTien)
	VALUES (@MaThanhToan,@MaNV,@MaBan,@MaMonAn,@SoLuong,@TongTien)
go
Create proc SP_ThanhToan_Xoa(@MaThanhToan char(10))
as
	DELETE ThanhToan where MaThanhToan = @MaThanhToan
go
Create proc SP_ThanhToan_Sua(@MaThanhToan char(10),@MaNV char(10),@MaBan char(10),@MaMonAn char(10),@SoLuong int,@TongTien float)
as
	UPDATE ThanhToan set MaThanhToan = @MaThanhToan,MaNV = @MaNV,MaBan = @MaBan,MaMonAn =@MaMonAn,SoLuong = @SoLuong,TongTien =@TongTien
	WHERE MaThanhToan = @MaThanhToan
go

--store procedure layds
--Nhan vien
Create proc SP_NhanVien_LayDS
as
	Select * From NhanVien
go
--Khach hang
Create proc SP_KhachHang_LayDS
as
	Select * From KhachHang
go
--Ban
Create proc SP_Ban_LayDS
as
	Select * From Ban
go
--LoaiKH
Create proc SP_loaiKH_LayDS
as
	Select * From LoaiKhachHang
go
--Khu vuc
Create proc SP_KhuVuc_LayDS
as
	Select * From KhuVuc
go
--Mon an
Create proc SP_MonAn_LayDS
as
	Select * From MonAn
go
--Thanh Toan
Create proc SP_ThanhToan_LayDS
as
	Select * From ThanhToan
go
Create proc SP_NhanVien_TruyXuat(@MaNV char(10))
as
	Select * from NhanVien
	where MaNV = @MaNV
go
exec SP_NhanVien_Them 'NV01', N'Hiếu Trung', '04/12/2001', N'Nam', N'Bình Định', 0327949585 ,'nguyenhieutrung@gmail.com'
exec SP_NhanVien_Them 'NV02', N'Trung', '2001', N'Nam', N'TPHCM', 054646546 ,'trung@gmail.com'
exec SP_NhanVien_LayDS
exec SP_NhanVien_Xoa 'NV03'

exec SP_KhachHang_Them 'KH01','Trung','032565656','Binh Dinh','dsafsafsad','VIPLoai1'
exec SP_LoaiKH_Them '01','VIPLoai1'
exec SP_KhuVuc_Them 'KV01',N'Tầng 1',N'Hoạt động'
exec SP_Ban_Them '01','Hoạt động','KV01'
exec SP_MonAn_Them 'GN',N'Gà nướng',250000