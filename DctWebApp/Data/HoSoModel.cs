using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Linq;
using System.Text.Json;
using System.Threading.Tasks;

namespace DctWebApp.Data
{
    public class HoSoModel
    {
        public int ShipperId;

        public DateTime? NgaySinh;
        [DefaultValue("")]
        public string GioiTinh;
        [DefaultValue("")]
        public string NgheNghiep;

        // DiaChi
        public DiaChiModel DiaChi;

        // HinhAnh
        public HinhAnhModel Avatar;

        public HinhAnhModel CMNDTruoc;
        public HinhAnhModel CMNDSau;
        [DefaultValue("")]
        public string CMND;
        public DateTime? CMNDNgayCap;
        [DefaultValue("")]
        public string CMNDNoiCap;

        [DefaultValue("")]
        public string BLXSo;
        [DefaultValue("")]
        public string BLXHang;
        public HinhAnhModel BLXTruoc;
        public HinhAnhModel BLXSau;

        [DefaultValue("")]
        public string NganHang;
        [DefaultValue("")]
        public string SoTaiKhoan;

        public HinhAnhModel HinhDauXe;
        public HinhAnhModel HinhDuoiXe;
        public HinhAnhModel GiayKTXe;

        public HinhAnhModel GiayDKXeTruoc;
        public HinhAnhModel GiayDKXeSau;
        [DefaultValue("")]
        public string BienSoXe;
        [DefaultValue("")]
        public string DongXe;
        [DefaultValue(0)]
        public int NamSXXe;

        public HinhAnhModel BaoHiemXeTruoc;
        public HinhAnhModel BaoHiemXeSau;

        public HoSoModel() {
            NgaySinh = null;
            DiaChi = new DiaChiModel();
            Avatar = new HinhAnhModel();
            CMNDTruoc = new HinhAnhModel();
            CMNDSau = new HinhAnhModel();
            CMNDNgayCap = null;
            BLXTruoc = new HinhAnhModel();
            BLXSau = new HinhAnhModel();
            HinhDauXe = new HinhAnhModel();
            HinhDuoiXe = new HinhAnhModel();
            GiayKTXe = new HinhAnhModel();
            GiayDKXeTruoc = new HinhAnhModel();
            GiayDKXeSau = new HinhAnhModel();
            BaoHiemXeSau = new HinhAnhModel();
            BaoHiemXeTruoc = new HinhAnhModel();
        }

        public string toJSON()
        {
            var hoSo = new
            {
                user = new
                {
                    ngaySinh = NgaySinh,
                    gioiTinh = GioiTinh,
                    avatarId = Avatar.Id,
                    diaChi = DiaChi.toJSON()
                },
                shipper = new
                {
                    cMNDSo = CMND,
                    bienSoXe = BienSoXe,
                    dongXe = DongXe
                },
                hoSo = new
                {
                    shipperId = ShipperId,
                    ngheNghiep = NgheNghiep,
                    cMNDMatTruocId = CMNDTruoc.Id,
                    cMNDMatSauId = CMNDSau.Id,
                    cMNDNgayCap = CMNDNgayCap,
                    cMNDNoiCap = CMNDNoiCap,
                    bLXSo = BLXSo,
                    bLXHang = BLXHang,
                    bLXMatTruocId = BLXTruoc.Id,
                    bLXSauId = BLXSau.Id,
                    phuongTienHinhDauId = HinhDauXe.Id,
                    phuongTienHinhDuoiId = HinhDuoiXe.Id,
                    giayKiemTraXeId = GiayKTXe.Id,
                    giayDKXMatTruocId = GiayDKXeTruoc.Id,
                    giayDKXMatSauId = GiayDKXeSau.Id,
                    namSXXe = NamSXXe,
                    bHXMatTruocId = BaoHiemXeTruoc.Id,
                    bHXMatSauId = BaoHiemXeSau.Id
                }
            };
            var settings = new JsonSerializerSettings
            {
                NullValueHandling = NullValueHandling.Ignore,
                DefaultValueHandling = DefaultValueHandling.Ignore
            };
            var jsonString = JsonConvert.SerializeObject(hoSo, settings);
            return jsonString;
        }

        public void SetHinhAnh(string name, HinhAnhModel hinhAnh)
        {
            switch (name) {
                case HoSoSection.ImageInput.Avatar:
                    Avatar = hinhAnh;
                    break;
                case HoSoSection.ImageInput.CMNDTruoc:
                    CMNDTruoc = hinhAnh;
                    break;
                case HoSoSection.ImageInput.CMNDSau:
                    CMNDSau = hinhAnh;
                    break;
                case HoSoSection.ImageInput.BLXTruoc:
                    BLXTruoc = hinhAnh;
                    break;
                case HoSoSection.ImageInput.BLXSau:
                    BLXSau = hinhAnh;
                    break;
                case HoSoSection.ImageInput.HinhDauXe:
                    HinhDauXe = hinhAnh;
                    break;
                case HoSoSection.ImageInput.HinhDuoiXe:
                    HinhDuoiXe = hinhAnh;
                    break;
                case HoSoSection.ImageInput.GiayKTXe:
                    GiayKTXe = hinhAnh;
                    break;
                case HoSoSection.ImageInput.GiayDKXTruoc:
                    GiayDKXeTruoc = hinhAnh;
                    break;
                case HoSoSection.ImageInput.GiayDKXSau:
                    GiayDKXeSau = hinhAnh;
                    break;
                case HoSoSection.ImageInput.BHXeTruoc:
                    BaoHiemXeTruoc = hinhAnh;
                    break;
                case HoSoSection.ImageInput.BHXeSau:
                    BaoHiemXeSau = hinhAnh;
                    break;
            }

        }

    }
}
