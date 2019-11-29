using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Web.Http;
using System.Web.Http.Cors;
using Akida_Backend.Models;

namespace Akida_Backend.Controllers.API.HomePage
{
    [RoutePrefix("API")]
    [EnableCors(origins: "*", headers: "*", methods: "*")]
    public class HomePageAPIController : ApiController
    {
        AKIDAEntities db = new AKIDAEntities();
        // Tìm Kiếm Khóa Học Theo Tên
        [Route("TimKiemKhoaHoc")]
        [HttpGet]
        public IHttpActionResult TimKiemKhoaHoc(string tenKhoaHoc)
        {
                var model = (from a in db.Managements
                             where a.Enabled == 1 && a.Name.Contains(tenKhoaHoc)
                             select new
                             {
                                 ID = a.ID,
                                 Name = a.Name,
                                 Category_ID = a.Category_ID,
                                 Author = a.Author,
                                 Created_Time = a.Created_Time,
                                 Short_Description = a.Short_Description,
                                 Number_Of_Participants = a.Number_Of_Participants,
                                 Video_Info_ID = a.Video_Info_ID,
                                 Cost_Aki = a.Cost_Aki,
                                 Image = a.Image,

                             }).AsEnumerable().Select(x => new DanhSachKhoaHocTheoDanhMuc()
                             {
                                 ID = x.ID,
                                 Name = x.Name,
                                 Category_ID = x.Category_ID,
                                 Author = x.Author,
                                 Created_Time = x.Created_Time,
                                 Short_Description = x.Short_Description,
                                 Number_Of_Participants = x.Number_Of_Participants,
                                 Video_Info_ID = x.Video_Info_ID,
                                 Cost_Aki = x.Cost_Aki,
                                 Image = x.Image,
                             }).ToArray();
            return Ok(model);
        }

        // Lấy Danh Sách Danh Mục
        [Route("LayDanhSachDanhMuc")]
        [HttpGet]
        public IHttpActionResult LayDanhSachDanhMuc()
        {
            var model = (from a in db.Category_Info
                         where a.Enabled == 1
                         select new
                         {
                             ID_Category = a.ID_Category,
                             TenChuyenMuc = a.Name,
                             CreatedTime = a.Created_Time,
                             Description = a.Description

                         }).AsEnumerable().Select(x => new DanhSachDanhMuc()
                         {
                             ID_Category = x.ID_Category,
                             Name = x.TenChuyenMuc,
                             Created_Time = x.CreatedTime,
                             Description = x.Description
                         });
            return Ok(model.ToList());
        }

        // Lấy Danh Sách Khóa Học Theo Danh Mục
        [Route("LayDanhSachKhoaHocTheoDanhMuc")]
        [HttpGet]
        public IHttpActionResult LayDanhSachKhoaHocTheoDanhMuc(int CategoryID)
        {
            var model = (from a in db.Managements
                         where a.Enabled == 1 && a.Category_ID == CategoryID
                         select new
                         {
                             IdKhoaHoc = a.ID,
                             TenKhoaHoc = a.Name,
                             MaDanhMuc = a.Category_ID,
                             MoTa = a.Short_Description,
                             SoLuongHocVien = a.Number_Of_Participants,
                             HinhAnh = a.Image

                         }).AsEnumerable().Select(x => new DanhSachKhoaHocTheoDanhMuc()
                         {
                             ID = x.IdKhoaHoc,
                             Name = x.TenKhoaHoc,
                             Category_ID = x.MaDanhMuc,
                             Short_Description = x.MoTa,
                             Image = x.HinhAnh
                         }).ToList();
            if(model.Count == 0)
            {
                return BadRequest("Đang Cập Nhật Khóa Học Cho Danh Mục Này");
            }
            return Ok(model);
        }

        // Lấy Danh Sách Khóa Học Mới Nhất
        [Route("LayDanhSachKhoaHocMoiNhat")]
        [HttpGet]
        public IHttpActionResult LayDanhSachKhoaHocMoiNhat()
        {
            var model = (from a in db.Managements
                         where a.Enabled == 1
                         select new
                         {
                             IdKhoaHoc = a.ID,
                             TenKhoaHoc = a.Name,
                             MaDanhMuc = a.Category_ID,
                             MoTa = a.Short_Description,
                             SoLuongHocVien = a.Number_Of_Participants,
                             HinhAnh = a.Image

                         }).AsEnumerable().Select(x => new DanhSachKhoaHocTheoDanhMuc()
                         {
                             ID = x.IdKhoaHoc,
                             Name = x.TenKhoaHoc,
                             Category_ID = x.MaDanhMuc,
                             Short_Description = x.MoTa,
                             Number_Of_Participants = x.SoLuongHocVien,
                             Image = x.HinhAnh
                         }).OrderByDescending(x => x.ID).Take(6).ToList();
            if (model.Count == 0)
            {
                return BadRequest("Đang Cập Nhật Khóa Học Cho Danh Mục Này");
            }
            return Ok(model);
        }

        // Lấy Danh Sách Khóa Học Tiêu Biểu
        [Route("LayDanhSachKhoaHocTieuBieu")]
        [HttpGet]
        public IHttpActionResult LayDanhSachKhoaHocTieuBieu()
        {
            var model = (from a in db.Managements
                         where a.Enabled == 1
                         select new
                         {
                             IdKhoaHoc = a.ID,
                             TenKhoaHoc = a.Name,
                             MaDanhMuc = a.Category_ID,
                             MoTa = a.Short_Description,
                             SoLuongHocVien = a.Number_Of_Participants,
                             HinhAnh = a.Image

                         }).AsEnumerable().Select(x => new DanhSachKhoaHocTheoDanhMuc()
                         {
                             ID = x.IdKhoaHoc,
                             Name = x.TenKhoaHoc,
                             Category_ID = x.MaDanhMuc,
                             Short_Description = x.MoTa,
                             Number_Of_Participants = x.SoLuongHocVien,
                             Image = x.HinhAnh
                         }).OrderByDescending(x => x.Number_Of_Participants).Take(6).ToList();
            if (model.Count == 0)
            {
                return BadRequest("Đang Cập Nhật Khóa Học Cho Danh Mục Này");
            }
            return Ok(model);
        }

        // Lấy Chi Tiết Khóa Học
        [Route("LayChiTietKhoaHoc")]
        [HttpGet]
        public IHttpActionResult LayChiTietKhoaHoc(int idKhoaHoc)
        {
            var kh = db.Managements.Where(x => x.ID == idKhoaHoc).FirstOrDefault();
            if (kh != null)
            {
                var ctkh = new DanhSachKhoaHocTheoDanhMuc();
                ctkh.ID = kh.ID;
                ctkh.Name = kh.Name;
                ctkh.Category_ID = kh.Category_ID;
                ctkh.Author = kh.Author;
                ctkh.Created_Time = kh.Created_Time;
                ctkh.Short_Description = kh.Short_Description;
                ctkh.Number_Of_Participants = kh.Number_Of_Participants;
                ctkh.Video_Info_ID = kh.Video_Info_ID;
                ctkh.Cost_Aki = kh.Cost_Aki;
                ctkh.Content = kh.Content;
                ctkh.Image = kh.Image;
                return Ok(ctkh);
            }
            return BadRequest("Khóa Học Này Không Tồn Tại");
        }

        // Lấy Danh Sách Giáo Viên
        [Route("LayDanhSachGiaoVien")]
        [HttpGet]
        public IHttpActionResult LayDanhSachGiaoVien()
        {
            try
            {
                var dsUser = (from a in db.Users.ToList()
                              from b in db.UserRoles.ToList()
                              where a.Activated == 1 && b.Role_ID == 2 && a.ID_User == b.User_ID
                              select new
                              {
                                  ID_User = a.ID_User,
                                  Name = a.Name,
                                  Email = a.Email,
                                  Activated = a.Activated,
                                  Created_Time = a.Created_Time,
                                  AKIDA_Number = a.AKIDA_Number,
                                  Phone = a.Phone

                              }).AsEnumerable().Select(x => new DanhSachNguoiDung()
                              {
                                  ID_User = x.ID_User,
                                  Name = x.Name,
                                  Email = x.Email,
                                  Activated = x.Activated,
                                  Created_Time = x.Created_Time,
                                  AKIDA_Number = x.AKIDA_Number,
                                  Phone = x.Phone
                              }).OrderByDescending(x => x.ID_User);
                return Ok(dsUser.ToList());
            }
            catch
            {
                return BadRequest("Có lỗi,xin vui lòng thử lại");
            }
        }

        //// Đăng Nhập
        //[Route("DangNhap")]
        //[HttpPost]
        //public IHttpActionResult DangNhap(User objDangNhap)
        //{
        //    try
        //    {
        //        var User = db.Users.Where(x => x.Email == objDangNhap.Email && x.Password == objDangNhap.Password).FirstOrDefault();
        //        if (User != null)
        //        {
        //            var UserLogin = new UserLogin();
        //            UserLogin.ID_User = User.ID_User;
        //            UserLogin.Name = User.Name;
        //            UserLogin.Password = User.Password;
        //            UserLogin.Email = User.Email;
        //            UserLogin.Activated = User.Activated;
        //            UserLogin.Created_Time = User.Created_Time;
        //            UserLogin.AKIDA_Number = User.AKIDA_Number;
        //            UserLogin.Phone = User.Phone;
        //            return Ok(UserLogin);
        //        }
        //    }
        //    catch
        //    {
        //        return BadRequest();
        //    }
        //    return BadRequest("Đăng Nhập Thất Bại , Xin Vui Lòng Thử Lại");
        //}

        // Đăng Nhập
        [Route("DangNhap")]
        [HttpPost]
        public IHttpActionResult DangNhap(User objDangNhap)
        {
            try
            {
                var _User = db.Users.Where(x => x.Email == objDangNhap.Email && x.Password == objDangNhap.Password).FirstOrDefault();
                if (_User != null)
                {
                    var u = (from b in db.UserRoles
                             where _User.ID_User == b.User_ID
                             select new
                             {
                                    _User.ID_User ,
                                    _User.Name ,
                                    _User.Email ,
                                    _User.Activated ,
                                    _User.AKIDA_Number ,
                                    _User.Created_Time,
                                    _User.Phone ,
                                    b.Role_ID
                                }).FirstOrDefault();
                    return Ok(u);
                }
            }
            catch
            {
                return BadRequest();
            }
            return BadRequest("Đăng Nhập Thất Bại , Xin Vui Lòng Thử Lại");
        }

        // Đăng Ký
        [Route("DangKy")]
        [HttpPost]
        public IHttpActionResult DangKy(UserThemMoi objUser)
        {
                var _User = db.Users.Where(x => x.Email == objUser.Email).FirstOrDefault();
                if (_User == null)
                {
                    var u = new User();
                    u.Name = objUser.Name;
                    u.Password = objUser.Password;
                    u.Email = objUser.Email;
                    u.Activated = objUser.Activated;
                    u.Created_Time = objUser.Created_Time;
                    u.AKIDA_Number = objUser.AKIDA_Number;
                    u.Phone = objUser.Phone;
                    db.Users.Add(u);
                    db.SaveChanges();

                    UserRole r = new UserRole();
                    r.User_ID = u.ID_User;
                    r.Role_ID = objUser.Role_ID;
                    db.UserRoles.Add(r);
                    db.SaveChanges();
                    return Ok("Đăng Ký Thành Công");
                }
                return BadRequest("Có Lỗi,Xin Vui Lòng Thử Lại");
        }

        // Đổi Thông Tin Cá Nhân
        [Route("DoiThongTinCaNhan")]
        [HttpPut]
        public IHttpActionResult DoiThongTinCaNhan(UserThemMoi objUser)
        {
                var _User = db.Users.Where(x => x.ID_User == objUser.ID_User).FirstOrDefault();
                if (_User != null)
                {
                    _User.Email = objUser.Email;
                    _User.Name = objUser.Name;
                    _User.Phone = objUser.Phone;
                    db.SaveChanges();
                    return Ok("Cập Nhật Thông Tin Thành Công");
                }
                return BadRequest("Có Lỗi,Xin Vui Lòng Thử Lại");
        }

        // Đổi Mật Khẩu
        [Route("DoiMatKhau")]
        [HttpPut]
        public IHttpActionResult DoiMatKhau(UserThemMoi objUser)
        {
            try
            {
                var _User = db.Users.FirstOrDefault(x => x.ID_User == objUser.ID_User && x.Password == objUser.Password);
                if (_User != null)
                {
                    _User.Password = objUser.NewPassword;
                    db.SaveChanges();
                    return Ok("Cập Nhật Mật Khẩu Thành Công");
                }
                return BadRequest("Mật Khẩu Cũ Không Đúng,Xin Vui Lòng Nhập Lại");
            }
            catch (Exception ex)
            {
                return BadRequest("Có Lỗi,Xin Vui Lòng Thử Lại");
            }
        }


    }
}
