Create database CSDL_QLNH;
go 
USE CSDL_QLNH;
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
,MaLoaiMonAn char(10)
,DonGia float
)
Create table LoaiMonAn
(
MaLoai char(10)NOT NULL CONSTRAINT PK_MaLoai PRIMARY KEY(MaLoai)
,TenLoai nvarchar(40)
)


go
Create table Bill(
id int IDENTITY NOT NULL CONSTRAINT PK_MaThanhToan PRIMARY KEY(id)
,
MaThanhToan int  


,MaMonAn char(10)
,SoLuong int
,TrangThai int

)




Create table ThanhToan(
MaThanhToan int IDENTITY NOT NULL CONSTRAINT PK_Ma PRIMARY KEY(MaThanhToan)
,MaBan char(10)

,GioVao date NOT NULL default GETDATE()
,TrangThai int default 0

)

go
Create table TaiKhoan(
TenDangNhap nvarchar(50)NOT NULL CONSTRAINT PK_TenDangNhap PRIMARY KEY(TenDangNhap)
,MatKhau nvarchar(30)
,Quyen nvarchar(50)
)
--sp doi mat khau bang tai khoan
go
create proc SP_TaiKhoan_DoiMatKhau(@TenDangNhap nvarchar(50),@MatKhau nvarchar(30),@MatKhauMoi nvarchar(30))
as
	UPDATE TaiKhoan set MatKhau = @MatKhauMoi 
	where TenDangNhap = @TenDangNhap and MatKhau = @MatKhau 
go

Select * from TaiKhoan
Insert into TaiKhoan 
values('admin','12345','admin')
Insert into TaiKhoan 
values('user1','12345','user')
--Khoa Ngoai lien ket cac bang
-- Table ban 
Alter table Ban add CONSTRAINT FK_Ban_MaKhuVuc FOREIGN KEY (MaKhuVuc) REFERENCES KhuVuc(MaKhuVuc)
go
--table Thanh Toan

Alter table ThanhToan add CONSTRAINT FK_ThanhToan_MaBan FOREIGN KEY (MaBan) REFERENCES Ban(MaBan)
go
Alter table Bill add CONSTRAINT FK_ThanhToan_MaMonAn FOREIGN KEY (MaMonAn) REFERENCES MonAn(MaMonAn)
go
Alter table KhachHang add CONSTRAINT FK_KhachHang_maLoai FOREIGN KEY (MaLoaiKH) REFERENCES LoaiKhachHang(MaLoaiKH)
go
Alter table MonAn add CONSTRAINT FK_MonAn_LoaiMonAn FOREIGN KEY (MaLoaiMonAn) REFERENCES LoaiMonAn(MaLoai)
go
Alter table Bill add CONSTRAINT FK_Bill_ID54545 FOREIGN KEY (MaThanhToan) REFERENCES ThanhToan(MaThanhToan)
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
create proc SP_MonAn_Them(@MaMonAn char(10),@TenMonAn nvarchar(30),@MaLoaiMonAn char(10),@DonGia float)
as
	INSERT INTO MonAn(MaMonAn,TenMonAn,MaLoaiMonAn,DonGia)
	VALUES (@MaMonAn,@TenMonAn,@MaLoaiMonAn,@DonGia)
go
Create proc SP_MonAn_Xoa(@MaMonAn char(10))
as
	DELETE MonAn where MaMonAn = @MaMonAn
go
Create proc SP_MonAn_Sua(@MaMonAn char(10),@TenMonAn nvarchar(30),@MaLoaiMonAn char(10),@DonGia float)
as
	UPDATE MonAn set MaMonAn = @MaMonAn,TenMonAn = @TenMonAn ,MaLoaiMonAn = @MaLoaiMonAn ,DonGia = @DonGia
	WHERE MaMonAn = @MaMonAn
go
--Loaimon an
create proc SP_LoaiMonAn_Them(@MaLoai char(10),@TenLoai nvarchar(40))
as
	INSERT INTO LoaiMonAn(MaLoai,TenLoai)
	VALUES (@MaLoai,@TenLoai)
go
--Store procedure them xoa sua cho ban ThanhToan
create proc SP_ThanhToan_Them(@MaMonAn char(10),@SoLuong int,@TrangThai int)
as
	INSERT INTO Bill(MaMonAn,SoLuong,TrangThai)
	VALUES (@MaMonAn,@SoLuong,@TrangThai)
go

Create proc SP_ThanhToan_Xoa(@MaThanhToan int)
as
	DELETE Bill where MaThanhToan = @MaThanhToan
go
create proc SP_ThanhToan_Sua(@MaThanhToan int,@MaMonAn char(10),@SoLuong int ,@TrangThai int)
as
	UPDATE Bill set  MaMonAn =@MaMonAn,SoLuong = @SoLuong,TrangThai = @TrangThai
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
Create proc SP_LoaiMonAn_LayDS
as
	Select * From LoaiMonAn
go
--Thanh Toan
Create proc SP_ThanhToan_LayDS
as
	Select * From Bill
go
Create proc SP_NhanVien_TruyXuat(@MaNV char(10))
as
	Select * from NhanVien
	where MaNV = @MaNV
go
create proc SP_Bill(@id char(10))
as
	select ma.TenMonAn,tt.SoLuong,ma.DonGia,tt.SoLuong *ma.DonGia as ThanhTien from Bill as tt ,ThanhToan as t,Ban as b , MonAn as ma 
	where  tt.MaThanhToan = t.MaThanhToan AND  t.MaBan = b.MaBan and tt.MaMonAn = ma.MaMonAn and t.TrangThai = 0 and b.MaBan = @id
go

create proc SP_InsertThanhToan(@MaBan char(10))
as
	INSERT ThanhToan(MaBan,GioVao,TrangThai)
	Values (@MaBan,GETDATE(),0)
go

create proc SP_InsertBill(@MaThanhToan int,@MaMonAn char(10),@SoLuong int,@TrangThai int)
as
Begin
	DECLARE @isExitsMaThanhToan int
	DECLARE @SoLuongD int = 1
	SELECT @isExitsMaThanhToan = MaThanhToan,@SoLuongD = b.SoLuong
	FROM Bill as b
	WHERE MaThanhToan = @MaThanhToan AND MaMonAn = @MaMonAn
	
	IF(@isExitsMaThanhToan > 0)
	BEGIN
		DECLARE @NewSoLuong int = @SoLuongD + @SoLuong
		IF(@NewSoLuong > 0)
			UPDATE Bill Set SoLuong = @SoLuongD +@SoLuong
			WHERE MaMonAn = @MaMonAn
		ELSE
			DELETE Bill WHERE MaThanhToan = @MaThanhToan AND MaMonAn = @MaMonAn
	END
	ELSE
	BEGIN 
		INSERT Bill(MaThanhToan,MaMonAn,SoLuong,TrangThai)
		Values (@MaThanhToan,@MaMonAn,@SoLuong,@TrangThai)
	END
			
END

go
Create proc GetMaxIdThanhToan
as
Select MAX(MaThanhToan) from ThanhToan
go

Create Trigger TG_UpdateBill
ON Bill For INSERT, UPDATE
AS
BEGIN
	DECLARE @MaThanhToan INT
	
	SELECT @MaThanhToan = MaThanhToan FROM Inserted
	
	DECLARE @MaBan char(10)
	
	SELECT @MaBan = MaBan FROM ThanhToan WHERE MaThanhToan = @MaThanhToan AND TrangThai = 0
	
	UPDATE Ban SET TrangThai = N'Hoạt động' WHERE MaBan = @MaBan
END
GO

Create Trigger TG_UpdateThanhToan
ON ThanhToan For INSERT, UPDATE
AS
BEGIN
	DECLARE @MaThanhToan INT
	
	SELECT @MaThanhToan = MaThanhToan FROM Inserted
	
	DECLARE @MaBan char(10)
	
	SELECT @MaBan = MaBan FROM ThanhToan WHERE MaThanhToan = @MaThanhToan
	
	DECLARE @count INT = 0
	
	SELECT @count = COUNT(*) from ThanhToan WHERE MaBan = @MaBan AND TrangThai = 0
	
	IF(@count = 0)
		UPDATE Ban Set TrangThai = N'Không Hoạt động ' Where MaBan = @MaBan
END
GO


exec SP_NhanVien_Them 'NV01', N'Hiếu Trung', '04/12/2001', N'Nam', N'Bình Định', 0327949585 ,'nguyenhieutrung@gmail.com'
exec SP_NhanVien_Them 'NV02', N'Trung', '2001', N'Nam', N'TPHCM', 054646546 ,'trung@gmail.com'
exec SP_NhanVien_LayDS
exec SP_NhanVien_Xoa 'NV03'

exec SP_KhachHang_Them 'KH01','Trung','032565656','Binh Dinh','dsafsafsad','VIPLoai1'
exec SP_LoaiKH_Them '01','VIPLoai1'
exec SP_KhuVuc_Them 'KV01',N'Tầng 1',N'Hoạt động'
exec SP_Ban_Them '02',N'Hoạt động','KV01'
exec SP_LoaiMonAn_Them '01',N'Hải sản'
exec SP_LoaiMonAn_Them '02',N'Nước uống'
exec SP_LoaiMonAn_Them '03',N'Nông sản'

exec SP_MonAn_Them 'HS',N'Nghiêu hấp xả','01',250000
exec SP_MonAn_Them 'MN',N'Mực nướng','01',270000
exec SP_MonAn_Them 'MH',N'Mực hấp','01',240000
exec SP_MonAn_Them 'PS',N'Pessi','02',250000
exec SP_MonAn_Them '7U',N'7Up','02',50000
exec SP_MonAn_Them 'GA',N'Gà nướng','03',250000

--exec SP_Bill'02'
exec SP_MonAn_LayDS

Select * from Bill 
Select * from ThanhToan
--exec SP_InsertThanhToan '02'
Select * from ThanhToan WHERE MaBan = '02' And TrangThai = 0



