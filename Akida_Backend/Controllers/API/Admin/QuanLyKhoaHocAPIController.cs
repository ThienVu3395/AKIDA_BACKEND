using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Web.Http;
using System.Web.Http.Cors;
using Akida_Backend.Models;
using System.IO;
using System.Web;
using System.Threading.Tasks;

namespace Akida_Backend.Controllers.API.Admin
{
    [RoutePrefix("API/QuanLyKhoaHoc")]
    [EnableCors(origins: "*", headers: "*", methods: "*")]
    public class QuanLyKhoaHocAPIController : ApiController
    {
        AKIDAEntities db = new AKIDAEntities();
        [Route("LayToanBoDanhSachKhoaHoc")]
        [HttpGet]
        public IHttpActionResult LayToanBoDanhSachKhoaHoc()
        {
            try
            {
                var count = db.Managements.Count();
                var dsKhoaHoc = (from a in db.Managements.ToList()
                                 from b in db.Category_Info.ToList()
                                 where a.Category_ID == b.ID_Category
                                 select new
                                 {
                                     IdKhoaHoc = a.ID,
                                     TenKhoaHoc = a.Name,
                                     TenDanhMuc = b.Name,
                                     MaDanhMuc = a.Category_ID,
                                     MoTa = a.Short_Description,
                                     TacGia = a.Author,
                                     SoLuongHocVien = a.Number_Of_Participants,
                                     HinhAnh = a.Image

                                 }).AsEnumerable().Select(x => new DanhSachKhoaHocTheoDanhMuc()
                                 {
                      
                                     ID = x.IdKhoaHoc,
                                     Name = x.TenKhoaHoc,
                                     Category_ID = x.MaDanhMuc,
                                     Category_Name = x.TenDanhMuc,
                                     Short_Description = x.MoTa,
                                     Author = x.TacGia,
                                     Number_Of_Participants = x.SoLuongHocVien,
                                     Image = x.HinhAnh,
                                     Count = count
                                 }).OrderByDescending(x => x.ID).ToList();
                return Ok(dsKhoaHoc);
            }
            catch
            {
                return BadRequest("Có lỗi,xin vui lòng thử lại");
            }
        }


        [Route("LayToanBoDanhSachKhoaHoc_PhanTrang")]
        [HttpGet]
        public IHttpActionResult LayDanhSachKhoaHoc_PhanTrang(int page, int offset)
        {
            try
            {
                var pageIndex = (page - 1) * offset;

                var dsKhoaHoc = (from a in db.Managements.ToList()
                                 from b in db.Category_Info.ToList()
                                 where a.Category_ID == b.ID_Category
                                 select new
                                 {
                                     IdKhoaHoc = a.ID,
                                     TenKhoaHoc = a.Name,
                                     TenDanhMuc = b.Name,
                                     MaDanhMuc = a.Category_ID,
                                     MoTa = a.Short_Description,
                                     TacGia = a.Author,
                                     SoLuongHocVien = a.Number_Of_Participants,
                                     HinhAnh = a.Image

                                 }).AsEnumerable().Select(x => new DanhSachKhoaHocTheoDanhMuc()
                                 {
                                     ID = x.IdKhoaHoc,
                                     Name = x.TenKhoaHoc,
                                     Category_ID = x.MaDanhMuc,
                                     Category_Name = x.TenDanhMuc,
                                     Short_Description = x.MoTa,
                                     Author = x.TacGia,
                                     Number_Of_Participants = x.SoLuongHocVien,
                                     Image = x.HinhAnh
                                 }).OrderByDescending(x => x.ID).Skip(pageIndex).Take(offset).ToList();
                return Ok(dsKhoaHoc);
            }
            catch
            {
                return BadRequest("Có lỗi,xin vui lòng thử lại");
            }
        }

        [Route("LayDanhSachKhoaHocTheoDanhMuc")]
        [HttpGet]
        public IHttpActionResult LayDanhSachKhoaHocTheoDanhMuc(int idDanhMuc)
        {
            try
            {
                var dsKhoaHoc = (from a in db.Managements.ToList()
                                 from b in db.Category_Info.ToList()
                                 where a.Category_ID == idDanhMuc && a.Category_ID == b.ID_Category
                                 select new
                                 {
                                     IdKhoaHoc = a.ID,
                                     TenKhoaHoc = a.Name,
                                     TenDanhMuc = b.Name,
                                     MaDanhMuc = a.Category_ID,
                                     MoTa = a.Short_Description,
                                     TacGia = a.Author,
                                     SoLuongHocVien = a.Number_Of_Participants,
                                     HinhAnh = a.Image

                                 }).AsEnumerable().Select(x => new DanhSachKhoaHocTheoDanhMuc()
                                 {
                                     ID = x.IdKhoaHoc,
                                     Name = x.TenKhoaHoc,
                                     Category_ID = x.MaDanhMuc,
                                     Category_Name = x.TenDanhMuc,
                                     Short_Description = x.MoTa,
                                     Author = x.TacGia,
                                     Number_Of_Participants = x.SoLuongHocVien,
                                     Image = x.HinhAnh
                                 }).OrderByDescending(x => x.ID).ToList();
                return Ok(dsKhoaHoc);
            }
            catch
            {
                return BadRequest("Có lỗi,xin vui lòng thử lại");
            }
        }

        [Route("LayDanhSachKhoaHocTheoDanhMuc_PhanTrang")]
        [HttpGet]
        public IHttpActionResult LayDanhSachKhoaHocTheoDanhMuc_PhanTrang(int page,int offset,int idDanhMuc)
        {
            try
            {
                var pageIndex = (page - 1) * offset;
                var dsKhoaHoc = (from a in db.Managements.ToList()
                                 from b in db.Category_Info.ToList()
                                 where a.Category_ID == idDanhMuc && a.Category_ID == b.ID_Category
                                 select new
                                 {
                                     IdKhoaHoc = a.ID,
                                     TenKhoaHoc = a.Name,
                                     TenDanhMuc = b.Name,
                                     MaDanhMuc = a.Category_ID,
                                     MoTa = a.Short_Description,
                                     TacGia = a.Author,
                                     SoLuongHocVien = a.Number_Of_Participants,
                                     HinhAnh = a.Image

                                 }).AsEnumerable().Select(x => new DanhSachKhoaHocTheoDanhMuc()
                                 {
                                     ID = x.IdKhoaHoc,
                                     Name = x.TenKhoaHoc,
                                     Category_ID = x.MaDanhMuc,
                                     Category_Name = x.TenDanhMuc,
                                     Short_Description = x.MoTa,
                                     Author = x.TacGia,
                                     Number_Of_Participants = x.SoLuongHocVien,
                                     Image = x.HinhAnh
                                 }).OrderByDescending(x => x.ID).Skip(pageIndex).Take(offset).ToList();
                return Ok(dsKhoaHoc);
            }
            catch
            {
                return BadRequest("Có lỗi,xin vui lòng thử lại");
            }
        }

        [Route("LayDanhSachKhoaHocTheoTrangThai")]
        [HttpGet]
        public IHttpActionResult LayDanhSachKhoaHocTheoTrangThai(int trangThai)
        {
            try
            {
                var dsKhoaHoc = (from a in db.Managements.ToList()
                                 from b in db.Category_Info.ToList()
                                 where a.Enabled == trangThai && a.Category_ID == b.ID_Category
                                 select new
                                 {
                                     IdKhoaHoc = a.ID,
                                     TenKhoaHoc = a.Name,
                                     TenDanhMuc = b.Name,
                                     MaDanhMuc = a.Category_ID,
                                     MoTa = a.Short_Description,
                                     TacGia = a.Author,
                                     SoLuongHocVien = a.Number_Of_Participants,
                                     HinhAnh = a.Image

                                 }).AsEnumerable().Select(x => new DanhSachKhoaHocTheoDanhMuc()
                                 {
                                     ID = x.IdKhoaHoc,
                                     Name = x.TenKhoaHoc,
                                     Category_ID = x.MaDanhMuc,
                                     Category_Name = x.TenDanhMuc,
                                     Short_Description = x.MoTa,
                                     Author = x.TacGia,
                                     Number_Of_Participants = x.SoLuongHocVien,
                                     Image = x.HinhAnh
                                 }).OrderByDescending(x => x.ID).ToList();
                return Ok(dsKhoaHoc);
            }
            catch
            {
                return BadRequest("Có lỗi,xin vui lòng thử lại");
            }
        }

        [Route("LayDanhSachKhoaHocTheoTrangThai_PhanTrang")]
        [HttpGet]
        public IHttpActionResult LayDanhSachKhoaHocTheoTrangThai_PhanTrang(int page, int offset, int trangThai)
        {
            try
            {
                var pageIndex = (page - 1) * offset;
                var dsKhoaHoc = (from a in db.Managements.ToList()
                                 from b in db.Category_Info.ToList()
                                 where a.Enabled == trangThai && a.Category_ID == b.ID_Category
                                 select new
                                 {
                                     IdKhoaHoc = a.ID,
                                     TenKhoaHoc = a.Name,
                                     TenDanhMuc = b.Name,
                                     MaDanhMuc = a.Category_ID,
                                     MoTa = a.Short_Description,
                                     TacGia = a.Author,
                                     SoLuongHocVien = a.Number_Of_Participants,
                                     HinhAnh = a.Image

                                 }).AsEnumerable().Select(x => new DanhSachKhoaHocTheoDanhMuc()
                                 {
                                     ID = x.IdKhoaHoc,
                                     Name = x.TenKhoaHoc,
                                     Category_ID = x.MaDanhMuc,
                                     Category_Name = x.TenDanhMuc,
                                     Short_Description = x.MoTa,
                                     Author = x.TacGia,
                                     Number_Of_Participants = x.SoLuongHocVien,
                                     Image = x.HinhAnh
                                 }).OrderByDescending(x => x.ID).Skip(pageIndex).Take(offset).ToList();
                return Ok(dsKhoaHoc);
            }
            catch
            {
                return BadRequest("Có lỗi,xin vui lòng thử lại");
            }
        }

        [Route("LayDanhSachKhoaHocTheoTuyChon")]
        [HttpGet]
        public IHttpActionResult LayDanhSachKhoaHocTheoTuyChon(int idDanhMuc, int trangThai)
        {
            try
            {
                var dsKhoaHoc = (from a in db.Managements.ToList()
                                 from b in db.Category_Info.ToList()
                                 where a.Category_ID == idDanhMuc && a.Enabled == trangThai && a.Category_ID == b.ID_Category
                                 select new
                                 {
                                     IdKhoaHoc = a.ID,
                                     TenKhoaHoc = a.Name,
                                     TenDanhMuc = b.Name,
                                     MaDanhMuc = a.Category_ID,
                                     MoTa = a.Short_Description,
                                     TacGia = a.Author,
                                     SoLuongHocVien = a.Number_Of_Participants,
                                     HinhAnh = a.Image

                                 }).AsEnumerable().Select(x => new DanhSachKhoaHocTheoDanhMuc()
                                 {
                                     ID = x.IdKhoaHoc,
                                     Name = x.TenKhoaHoc,
                                     Category_ID = x.MaDanhMuc,
                                     Category_Name = x.TenDanhMuc,
                                     Short_Description = x.MoTa,
                                     Author = x.TacGia,
                                     Number_Of_Participants = x.SoLuongHocVien,
                                     Image = x.HinhAnh
                                 }).OrderByDescending(x => x.ID).ToList();
                return Ok(dsKhoaHoc);
            }
            catch
            {
                return BadRequest("Có lỗi,xin vui lòng thử lại");
            }
        }

        [Route("LayDanhSachKhoaHocTheoTuyChon_PhanTrang")]
        [HttpGet]
        public IHttpActionResult LayDanhSachKhoaHocTheoTuyChon_PhanTrang(int page, int offset, int idDanhMuc, int trangThai)
        {
            try
            {
                var pageIndex = (page - 1) * offset;
                var dsKhoaHoc = (from a in db.Managements.ToList()
                                 from b in db.Category_Info.ToList()
                                 where a.Category_ID == idDanhMuc && a.Enabled == trangThai && a.Category_ID == b.ID_Category
                                 select new
                                 {
                                     IdKhoaHoc = a.ID,
                                     TenKhoaHoc = a.Name,
                                     TenDanhMuc = b.Name,
                                     MaDanhMuc = a.Category_ID,
                                     MoTa = a.Short_Description,
                                     TacGia = a.Author,
                                     SoLuongHocVien = a.Number_Of_Participants,
                                     HinhAnh = a.Image

                                 }).AsEnumerable().Select(x => new DanhSachKhoaHocTheoDanhMuc()
                                 {
                                     ID = x.IdKhoaHoc,
                                     Name = x.TenKhoaHoc,
                                     Category_ID = x.MaDanhMuc,
                                     Category_Name = x.TenDanhMuc,
                                     Short_Description = x.MoTa,
                                     Author = x.TacGia,
                                     Number_Of_Participants = x.SoLuongHocVien,
                                     Image = x.HinhAnh
                                 }).OrderByDescending(x => x.ID).Skip(pageIndex).Take(offset).ToList();
                return Ok(dsKhoaHoc);
            }
            catch
            {
                return BadRequest("Có lỗi,xin vui lòng thử lại");
            }
        }

        [Route("ThemKhoaHoc")]
        [HttpPost]
        public IHttpActionResult ThemKhoaHoc(Management objThem)
        {
            try
            {
                db.Managements.Add(objThem);
                db.SaveChanges();
                return Ok("Thêm Khóa Học Thành Công");
            }
            catch
            {
                return BadRequest("Có lỗi,xin vui lòng thử lại");
            }
        }

        //[Route("UploadHinh")]
        //[HttpPost]
        //public IHttpActionResult UploadFiles()
        //{
        //    int iUploadedCnt = 0;
        //    string sPath = "";
        //    sPath = System.Web.Hosting.HostingEnvironment.MapPath("~/ImgTemp/");
        //    string date = DateTime.Now.Year.ToString();
        //    sPath = Path.Combine(sPath, date);
        //    if (!Directory.Exists(sPath)){
        //        Directory.CreateDirectory(sPath);
        //    }

        //    date = DateTime.Now.Month.ToString();

        //    sPath = Path.Combine(sPath, date);

        //    if (!Directory.Exists(sPath)){
        //        Directory.CreateDirectory(sPath);
        //     }

        //    System.Web.HttpFileCollection hfc = System.Web.HttpContext.Current.Request.Files;
        //    for (int iCnt = 0; iCnt <= hfc.Count - 1; iCnt++){
        //        System.Web.HttpPostedFile hpf = hfc[iCnt];
        //        if (hpf.ContentLength > 0){
        //            if (!File.Exists(sPath + Path.GetFileName(hpf.FileName))) {

        //                hpf.SaveAs(sPath + Path.GetFileName(hpf.FileName));

        //                iUploadedCnt = iUploadedCnt + 1;
        //            }
        //            else{
        //                FileInfo f = new FileInfo(sPath + Path.GetFileName(hpf.FileName));

        //                f.Delete();

        //                hpf.SaveAs(sPath + Path.GetFileName(hpf.FileName));

        //                iUploadedCnt = iUploadedCnt + 1;
        //            }
        //        }

        //        if (iUploadedCnt > 0){
        //            return Ok(iUploadedCnt + " Files Uploaded Successfully");
        //        }
        //        else{
        //            return BadRequest("Upload Failed");
        //        }
        //    }
        //    return BadRequest();
        //}

        [HttpPost]
        [Route("UpLoadHinh")]
        public async Task<string> UploadFiles()
        {
            var ctx = HttpContext.Current;
            var root = ctx.Server.MapPath("~/Content/Images/KhoaHoc/");
            var provider =
                new MultipartFormDataStreamProvider(root);
            try
            {
                await Request.Content.ReadAsMultipartAsync(provider);
                foreach (var file in provider.FileData)
                {
                    var name = file.Headers
                        .ContentDisposition
                        .FileName;

                    name = name.Trim('"');

                    var localFileName = file.LocalFileName;
                    var filePath = Path.Combine(root, name);
                    File.Move(localFileName, filePath);
                }
            }
            catch (Exception ex)
            {
                return $"Error : {ex.Message}";
            }
            return "File Uploaded";
        }

        [Route("XoaKhoaHoc")]
        [HttpDelete]
        public IHttpActionResult XoaKhoaHoc(int idKhoaHoc)
        {
            try
            {
                var KhoaHoc = db.Managements.Where(x => x.ID == idKhoaHoc).FirstOrDefault();
                if (KhoaHoc != null)
                {
                    db.Managements.Remove(KhoaHoc);
                    db.SaveChanges();
                    return Ok("Xóa Khóa Học Thành Công");
                }
                return BadRequest("Có lỗi,xin vui lòng thử lại");
            }
            catch
            {
                return BadRequest("Có lỗi,xin vui lòng thử lại");
            }
        }

        [Route("SuaKhoaHoc")]
        [HttpPut]
        public IHttpActionResult SuaKhoaHoc(objSuaKhoaHoc objSua)
        {
            try
            {
                var KhoaHoc = db.Managements.Where(x => x.ID == objSua.ID).FirstOrDefault();
                if (KhoaHoc != null)
                {
                    KhoaHoc.Name = objSua.Name;
                    KhoaHoc.Category_ID = objSua.Category_ID;
                    KhoaHoc.Short_Description = objSua.Short_Description;
                    KhoaHoc.Enabled = objSua.Enabled;
                    KhoaHoc.Content = objSua.Content;
                    db.SaveChanges();
                    return Ok(objSua);
                }
                return BadRequest("Có lỗi,xin vui lòng thử lại");
            }
            catch
            {
                return BadRequest("Có lỗi,xin vui lòng thử lại");
            }
        }

        [Route("XemThongTinKhoaHoc")]
        [HttpGet]
        public IHttpActionResult XemThongTinKhoaHoc(int idKH)
        {
            try
            {
                var KhoaHoc = db.Managements.Where(x => x.ID == idKH).FirstOrDefault();
                if (KhoaHoc != null)
                {
                    var ttkh = new ThongTinKhoaHoc();
                    ttkh.ID = KhoaHoc.ID;
                    ttkh.Name = KhoaHoc.Name;
                    ttkh.Category_ID = KhoaHoc.Category_ID;
                    ttkh.Author = KhoaHoc.Author;
                    ttkh.Created_Time = KhoaHoc.Created_Time;
                    ttkh.Short_Description = KhoaHoc.Short_Description;
                    ttkh.Content = KhoaHoc.Content;
                    ttkh.Number_Of_Participants = KhoaHoc.Number_Of_Participants;
                    ttkh.Video_Info_ID = KhoaHoc.Video_Info_ID;
                    ttkh.Cost_Aki = KhoaHoc.Cost_Aki;
                    ttkh.Enabled = KhoaHoc.Enabled;
                    ttkh.Image = KhoaHoc.Image;
                    return Ok(ttkh);
                }
                return BadRequest("Khóa Học Này Không Tồn Tại");
            }
            catch
            {
                return BadRequest("Có lỗi,xin vui lòng thử lại");
            }
        }

    }
}
