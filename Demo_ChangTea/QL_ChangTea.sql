create database QL_ChangTea
use QL_ChangTea

create table ChucVu(
MaChucVu varchar(10) constraint pk_mcv primary key,
ChucVu nvarchar(50)
)

create table NhanVien(
MaNV varchar(10) constraint pk_mnv primary key,
HoNV nvarchar(30),
TenNV nvarchar(30),
GioiTinh bit,
NgaySinh date,
SoDT varchar(20),
DiaChi nvarchar(100),
MaChucVu nvarchar(10) constraint fk_nv_cv foreign key (MaChucVu) references ChucVu(MaChucVu),
NgayLamViec date
)

create table KhachHang(
MaKH varchar(10) constraint pk_mkh primary key,
HoKH nvarchar(30),
TenKH nvarchar(30),
SoDT varchar(20),
DiaChi nvarchar(100),
DiemTichLuy int
)

create table KichThuoc(
MaKichThuoc varchar(10) constraint pk_mkt primary key,
KichThuoc nvarchar(50)
)

create table Mon(
MaMon varchar(10) constraint pk_mm primary key,
TenMon nvarchar(50),
AnhMon nvarchar(50),
MaKichThuoc nvarchar(10) constraint fk_m_kt foreign key (MaKichThuoc) references KichThuoc(MaKichThuoc),
DonVi nvarchar(10),
DonGia Money,
MoTa nvarchar(100)
)

create table NguyenLieu(
MaNL varchar(10) constraint pk_mnl primary key,
MaNV varchar(10) constraint fk_nl_nv foreign key (MaNV) references NhanVien(MaNV),
TenNL nvarchar(50),
SoLuong int,
DonVi nvarchar(10) null,
DonGia money null,
NgSX date,
HSD date
)

create table ChiTietMon(
MaNL varchar(10) ,
MaMon varchar(10),
SoLuongDaDung int null,
constraint fk_ctm_nl foreign key (MaNL) references NguyenLieu(MaNL),
constraint fk_ctm_m foreign key (MaMon) references Mon(MaMon),
constraint pk_ctm primary key(MaNL, MaMon)
)

create table DonHang(
MaDH varchar(10) constraint pk_mdh primary key,
MaKH varchar(10),
MaNV varchar(10),
ThoiGian datetime,
GhiChu nvarchar(200),
constraint fk_dh_nv foreign key (MaNV) references NhanVien(MaNV),
constraint fk_dh_kh foreign key (MaKH) references KhachHang(MaKH)
)


create table HoaDon(
MaHD varchar(10) constraint pk_mhd primary key,
MaDH varchar(10),
MaNV varchar(10),
MaKH varchar(10),
ThoiGianLap datetime,
GiamGia decimal(4,2),
MaPTTT varchar(10),
constraint fk_ctdh_pttt foreign key (MaPTTT) references PT_ThanhToan(MaPTTT),
constraint fk_hd_nv foreign key (MaNV) references NhanVien(MaNV),
constraint fk_hd_kh foreign key (MaKH) references KhachHang(MaKH),
constraint fk_hd_dh foreign key (MaDH) references DonHang(MaDH)
)

create table PT_ThanhToan(
MaPTTT varchar(10) constraint pk_mpttt primary key,
PhuongThuc nvarchar(50) 
)

create table ChiTietDonHang(
MaDH varchar(10),
MaMon varchar(10),
SoLuong int,
constraint fk_ctdh_m foreign key (MaMon) references Mon(MaMon),
constraint fk_ctdh_dh foreign key (MaDH) references DonHang(MaDH),
constraint pk_ctdh primary key(MaDH, MaMon)
)

--Thêm dữ liệu bảng chức vụ
insert into ChucVu (MaChucVu, ChucVu)
values
('TN', N'Thu ngân'),
('PV', N'Phục Vu'),
('PC', N'Pha chế')

--Thêm dữ liệu bảng NhanVien
insert into NHANVIEN(MaNV, HoNV, TenNV, GioiTinh,NgaySinh, SoDT,DiaChi, MaChucVu, NgayLamViec)
values
('NV001', N'Cao', N'Linh Hà', 0, '2004/12/17', '0375864841',N'Ninh Hòa', 'TN', '2023/12/28'),
('NV002', N'Huỳnh', N'Minh Bảo',1,'2002/06/30', '0333535953', N'Diên Khánh','TN', '2023/12/28'),
('NV003', N'Vĩnh', N'Thuận', 1,'2004/08/31', '0702782954', N'Nha Trang', 'PV', '2023/12/30'),
('NV004', N'Phạm', N'Tuấn Kiệt',1, '2004/07/17', '0333535952', N'Diên Khánh', 'PV', '2023/12/31'),
('NV005', N'Nguyễn', N'Hiểu Quyên',0,'2004/10/17', '0333979996', N'Diên Sơn', 'PC', '2024/01/03'),
('NV006', N'Nguyễn', N'Hồ Thanh Bình',0,'2004/04/02', '0703569857',N'Ninh Hòa', 'PC', '2024/01/04'),
('NV007', N'Huỳnh', N'Xuân Nam', 1,'2004/06/24', '0375975907',N'Phú Yên', 'PV', '2024/02/12'),
('NV008', N'Lê', N'Văn Lương', 1,'2004/09/12', '0763972084',N'Phú Yên', 'PC', '2024/03/19'),
('NV009', N'Quách', N'Tấn Phát', 1,'2004/05/11', '0917899463',N'Cam Lâm', 'PV', '2023/11/13'),
('NV010', N'Nguyễn', N'Quốc Kha', 1,'2004/07/19', '0795795799',N'Vạn Ninh', 'PC', '2024/07/20');

--Thêm dữ liệu bảng KhachHang
insert into KhachHang (MaKH, HoKH, TenKH, SoDT, DiaChi, DiemTichLuy)
values 
('KH001', N'Nguyễn', N'Kim Anh', '0912345678', N'Vĩnh Phước, TP Nha Trang', 5),
('KH002', N'Trần', N'Bình', '0923456789', N'Vĩnh Nguyên, TP Nha Trang', 2),
('KH003', N'Lê', 'Cường', '0934567890', N'Phước Tân, TP Nha Trang', 1),
('KH004', N'Phan', N'Dũng', '0945678901', N'Diên An, Diên Khánh',3),
('KH005', N'Hoàng', N'Minh Đức', '0956789012', N'Lộc Thọ, TP Nha Trang', 1),
('KH006', N'Bùi', N'Thị Yến', '0967890123', N'Bến Chợ, Vạn Thạnh, TP Nha Trang', 4),
('KH007', N'Vũ', N'Minh Lam', '0978901234', N'Xương Huân, TP Nha Trang', 1),
('KH008', N'Đặng', N'Minh Tú', '0989012345', N'Đường Trần Phú, Lộc Thọ, TP Nha Trang', 5),
('KH009', N'Đỗ', N'Tuấn Kiệt', '0990123456', N'Vĩnh Hòa, TP Nha Trang', 1),
('KH010', N'Cao', N'Mỹ Linh', '0901234567', N'Phương Sơn, TP Nha Trang', 1);

--Thêm dữ liệu bảng kich thươc
insert into KichThuoc (MaKichThuoc, KichThuoc)
values
('M', N'Nhỏ'),
('L', N'Vừa'),
('XL', N'Lớn')

--Thêm dữ liệu cho bảng Mon
insert into Mon (MaMon, TenMon, AnhMon, MaKichThuoc, DonVi, DonGia, MoTa) 
values
('M001', N'Cookie đá xay',N'CookieDaXay.jpg', 'M', N'Ly', 34000, NULL),
('M002', N'Chanh tuyết', N'ChanhTuyet.jpg', 'M', N'Ly', 34000, NULL),
('M003', N'Matcha đá xay', N'MatchaDaXay.jpg', 'L', N'Ly', 34000, NULL),
('M004', N'Đá Xay Bóng Đêm',N'DaXayBongDem.jpg', 'M', N'Ly', 37000, NULL),
('M005', N'Trà sữa nguyên lá', N'TraSuaNguyenLa.jpg', 'M', N'Ly', 28000, NULL),
('M006', N'Trà sữa ChangTea', N'TraSuaChangTea.jpg', 'XL', N'Ly', 28000, NULL),
('M007', N'Trà sữa lài hạnh nhân', N'TraSuaLaiHanhNhan.jpg', 'M', N'Ly', 29000, NULL),
('M008', N'Trà sữa olong', N'TraSuaOLong.jpg', 'M', N'Ly', 28000, NULL),
('M009', N'Trà Sữa Lotus', N'TraSuaLotus.jpg', 'L', N'Ly', 29000, NULL),
('M010', N'Trà sữa thiết quan âm', N'TraSuaThietQuanAm.jpg', 'M', N'Ly', 29000, NULL),
('M011', N'Trà sữa lài gạo rang', N'TraSuaLaiGaoRang.jpg', 'L', N'Ly', 29000, NULL);

--Thêm dữ liệu cho bảng NguyenLieu
insert into NguyenLieu (MaNL, MaNV, TenNL, SoLuong, DonVi, DonGia, NgSX, HSD) 
values
('NL001', 'NV001', N'Trân châu phô mai', 2,N'Kg', 2000, '2023-11-01', '2025-02-01'), 
('NL002', 'NV002', N'Thạch cafe', 2, N'Kg', 2000, '2023-11-05', '2025-03-05'),
('NL003', 'NV003', N'Trân châu đen', 2, N'Kg', 2000, '2023-11-07', '2025-02-07'), 
('NL004', 'NV004', N'Trân châu tươi', 2, N'Kg', 2000,'2023-11-10', '2025-02-10'), 
('NL005', 'NV005', N'Sữa', 100, N'Hộp', 7000,'2023-11-15', '2025-05-15'),
('NL006', 'NV006', N'Ly', 1000, N'Cái', 0,'2023-11-20', '2028-06-20'),
('NL007', 'NV007', N'Trà', 50, N'Gói', 3000,'2023-11-22', '2025-07-22'), 
('NL008', 'NV008', N'Đá', 5, N'Bao', 0,'2023-11-25', '2025-08-25'), 
('NL009', 'NV009', N'Gạo rang', 5, N'Bao', 0, '2023-11-27', '2024-09-27'), 
('NL010', 'NV010', N'Trà olong', 100, N'Gói', 5000, '2023-11-29', '2024-10-29'), 
('NL011', 'NV001', N'Hạnh nhân', 5, N'Gói', 0,'2023-12-01', '2024-04-01'), 
('NL012', 'NV002', N'Cookie', 10, N'Hộp', 0,'2023-12-03', '2024-04-03');

--Thêm dữ liệu vào chi tiết món
insert into ChiTietMon (MaNL, MaMon, SoLuongDaDung) 
values
('NL012', 'M001', 1),  
('NL008', 'M001', 1), 
('NL006', 'M001', 1), 
('NL007', 'M002', 1),  
('NL006', 'M002', 1),  
('NL008', 'M003', 1),  
('NL007', 'M003', 1),  
('NL005', 'M003', 1), 
('NL004', 'M004', 1), 
('NL003', 'M004', 1), 
('NL007', 'M006', 14),
('NL005', 'M006', 23),  
('NL007', 'M011', 25), 
('NL005', 'M011', 4),  
('NL008', 'M011', 7),  
('NL009', 'M011', 1) 

--Thêm dữ liệu bảng 
insert into DonHang(MaDH, MaNV, MaKH, ThoiGian, GhiChu)
values
('DH001', 'NV001', 'KH001', '2024-10-01 14:20:00', N'Giao hàng tại nhà'),
('DH002', 'NV002', 'KH002', '2023-12-02 15:10:00', N'Uống tại quán ChangTea'),
('DH003', 'NV003', 'KH003', '2024-10-02 10:30:00', N'Mua mang đi'),
('DH004', 'NV004', 'KH004', '2023-07-05 12:45:00', N'Giao hàng tại nhà'),
('DH005', 'NV005', 'KH005', '2024-09-05 17:00:00', N'Uống tại quán ChangTea'),
('DH006', 'NV006', 'KH006', '2023-10-20 09:20:00', N'Mua mang đi'),
('DH007', 'NV007', 'KH007', '2024-06-15 13:50:00', N'Giao hàng tại nhà'),
('DH008', 'NV008', 'KH008', '2024-11-15 16:15:00', N'Uống tại quán ChangTea'),
('DH009', 'NV009', 'KH009', '2023-04-24 11:25:00', N'Mua mang đi'),
('DH010', 'NV010', 'KH010', '2024-07-18 18:40:00', N'Giao hàng tại nhà')

--Thêm dữ liệu vào bảng PT_ThanhToan
insert into PT_ThanhToan(MaPTTT, PhuongThuc)
values 
('TTTM',N'Tiền mặt'),
('TTCK', N'Chuyển khoản')

--Thêm dữ liệu vào bảng ChiTietDonHang
insert into ChiTietDonHang (MaDH, MaMon, SoLuong) 
values
('DH001', 'M001', 2),
('DH002', 'M003', 3),
('DH003', 'M005', 1),
('DH004', 'M007', 2),
('DH005', 'M010', 3),
('DH006', 'M004', 1),
('DH007', 'M006', 2),
('DH008', 'M008', 2),
('DH009', 'M009', 1),
('DH010', 'M002', 3)

--Thêm dư liệu vào bảng HoaDon
insert into HoaDon (MaHD, MaDH, MaNV, MaKH, ThoiGianLap, GiamGia, MaPTTT)
values
('HD001', 'DH001', 'NV001', 'KH001', '2024-10-01 14:30:00', 0.10, 'TTTM'),
('HD002', 'DH002', 'NV002', 'KH002', '2023-12-02 15:20:00', 0.05, 'TTCK'),
('HD003', 'DH003', 'NV003', 'KH003', '2024-10-02 10:40:00', 0.15, 'TTTM'),
('HD004', 'DH004', 'NV004', 'KH004', '2023-07-05 12:55:00', 0.00, 'TTCK'),
('HD005', 'DH005', 'NV005', 'KH005', '2024-09-05 17:10:00', 0.20, 'TTTM'),
('HD006', 'DH006', 'NV006', 'KH006', '2023-10-20 09:30:00', 0.10, 'TTCK'),
('HD007', 'DH007', 'NV007', 'KH007', '2024-06-15 14:00:00', 0.25, 'TTCK'),
('HD008', 'DH008', 'NV008', 'KH008', '2024-11-15 16:25:00', 0.05, 'TTTM'),
('HD009', 'DH009', 'NV009', 'KH009', '2023-04-24 11:35:00', 0.00, 'TTTM'),
('HD010', 'DH010', 'NV010', 'KH010', '2024-07-18 18:50:00', 0.15, 'TTTM')


select * from ChucVu
select * from NhanVien
select * from KhachHang
select * from KichThuoc
select * from Mon
select * from NguyenLieu
select * from ChiTietMon
select * from DonHang
select * from PT_ThanhToan
select * from ChiTietDonHang
select * from HoaDon


CREATE PROCEDURE TongDoanhThu
AS
BEGIN
    SELECT 
        h.MaHD, 
        h.MaDH, 
        h.MaNV, 
        h.MaKH, 
        h.ThoiGianLap, 
        h.GiamGia, 
        SUM(c.SoLuong * m.DonGia) AS TongBill,
        SUM(c.SoLuong * m.DonGia) * (1 - h.GiamGia) AS TongBillSauGiamGia
    FROM 
        HoaDon h
    JOIN 
        DonHang d ON h.MaDH = d.MaDH
    JOIN 
        ChiTietDonHang c ON d.MaDH = c.MaDH
    JOIN 
        Mon m ON c.MaMon = m.MaMon
    GROUP BY 
        h.MaHD, h.MaDH, h.MaNV, h.MaKH, h.ThoiGianLap, h.GiamGia
    ORDER BY 
        h.MaHD;
END