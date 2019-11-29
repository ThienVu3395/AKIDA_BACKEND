using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Web.Http;
using System.Web.Http.Cors;
using Akida_Backend.Models;

namespace Akida_Backend.Controllers.API.Admin
{
    [RoutePrefix("API/QuanLyNguoiDung")]
    [EnableCors(origins: "*", headers: "*", methods: "*")]
    public class QuanLyNguoiDungAPIController : ApiController
    {
        AKIDAEntities db = new AKIDAEntities();
        [Route("LayDanhSachNguoiDung")]
        [HttpGet]
        public IHttpActionResult LayDanhSachNguoiDung()
        {
            try
            {
                var count = db.Users.Count();
                var dsUser = (from a in db.Users
                              select new
                              {
                                  ID_User = a.ID_User,
                                  Name = a.Name,
                                  Email = a.Email,
                                  Activated = a.Activated,
                                  Created_Time = a.Created_Time,
                                  AKIDA_Number = a.AKIDA_Number,
                                  Phone = a.Phone,

                              }).AsEnumerable().Select(x => new DanhSachNguoiDung()
                              {
                                  ID_User = x.ID_User,
                                  Name = x.Name,
                                  Email = x.Email,
                                  Activated = x.Activated,
                                  Created_Time = x.Created_Time,
                                  AKIDA_Number = x.AKIDA_Number,
                                  Phone = x.Phone,
                                  Count = count
                              }).OrderByDescending(x => x.ID_User).ToList();
                return Ok(dsUser);
            }
            catch
            {
                return BadRequest("Có lỗi,xin vui lòng thử lại");
            }
        }

        [Route("LayDanhSachNguoiDung_PhanTrang")]
        [HttpGet]
        public IHttpActionResult LayDanhSachNguoiDung_PhanTrang(int page, int offset)
        {
            try
            {
                var pageIndex = (page - 1) * offset;
                var dsUser = (from a in db.Users
                              select new
                              {
                                  ID_User = a.ID_User,
                                  Name = a.Name,
                                  Email = a.Email,
                                  Activated = a.Activated,
                                  Created_Time = a.Created_Time,
                                  AKIDA_Number = a.AKIDA_Number,
                                  Phone = a.Phone,

                              }).AsEnumerable().Select(x => new DanhSachNguoiDung()
                              {
                                  ID_User = x.ID_User,
                                  Name = x.Name,
                                  Email = x.Email,
                                  Activated = x.Activated,
                                  Created_Time = x.Created_Time,
                                  AKIDA_Number = x.AKIDA_Number,
                                  Phone = x.Phone,
                              }).OrderByDescending(x => x.ID_User).Skip(pageIndex).Take(offset).ToList();
                return Ok(dsUser);
            }
            catch
            {
                return BadRequest("Có lỗi,xin vui lòng thử lại");
            }
        }

        [Route("TimKiemNguoiDungTheoQuyen")]
        [HttpGet]
        public IHttpActionResult TimKiemNguoiDungTheoQuyen(int Role)
        {
            try
            {
                var dsUser = (from a in db.Users.ToList()
                              from b in db.UserRoles.ToList()
                              where a.ID_User == b.User_ID && b.Role_ID == Role
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
                              }).OrderByDescending(x => x.ID_User).ToList();
                return Ok(dsUser);
            }
            catch
            {
                return BadRequest("Có lỗi,xin vui lòng thử lại");
            }
        }

        [Route("TimKiemNguoiDungTheoQuyen_PhanTrang")]
        [HttpGet]
        public IHttpActionResult TimKiemNguoiDungTheoQuyen_PhanTrang(int page, int offset, int Role)
        {
            try
            {
                var pageIndex = (page - 1) * offset;
                var dsUser = (from a in db.Users.ToList()
                              from b in db.UserRoles.ToList()
                              where a.ID_User == b.User_ID && b.Role_ID == Role
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
                              }).OrderByDescending(x => x.ID_User).Skip(pageIndex).Take(offset).ToList();
                return Ok(dsUser);
            }
            catch
            {
                return BadRequest("Có lỗi,xin vui lòng thử lại");
            }
        }

        [Route("TimKiemNguoiDungTheoTrangThai")]
        [HttpGet]
        public IHttpActionResult TimKiemNguoiDungTheoTrangThai(int Activated)
        {
            try
            {
                var dsUser = (from a in db.Users.ToList()
                              where a.Activated == Activated
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
                              }).OrderByDescending(x => x.ID_User).ToList();
                return Ok(dsUser);
            }
            catch
            {
                return BadRequest("Có lỗi,xin vui lòng thử lại");
            }
        }

        [Route("TimKiemNguoiDungTheoTrangThai_PhanTrang")]
        [HttpGet]
        public IHttpActionResult TimKiemNguoiDungTheoTrangThai_PhanTrang(int page, int offset, int Activated)
        {
            try
            {
                var pageIndex = (page - 1) * offset;
                var dsUser = (from a in db.Users.ToList()
                              where a.Activated == Activated
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
                              }).OrderByDescending(x => x.ID_User).Skip(pageIndex).Take(offset).ToList();
                return Ok(dsUser);
            }
            catch
            {
                return BadRequest("Có lỗi,xin vui lòng thử lại");
            }
        }

        [Route("TimKiemNguoiDungTuyChon")]
        [HttpGet]
        public IHttpActionResult TimKiemNguoiDungTuyChon(int Role,int Activated)
        {
            try
            {
                var dsUser = (from a in db.Users.ToList()
                              from b in db.UserRoles.ToList()
                              where a.Activated == Activated && b.Role_ID == Role && a.ID_User == b.User_ID
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
                              }).OrderByDescending(x => x.ID_User).ToList();
                return Ok(dsUser);
            }
            catch
            {
                return BadRequest("Có lỗi,xin vui lòng thử lại");
            }
        }

        [Route("TimKiemNguoiDungTuyChon_PhanTrang")]
        [HttpGet]
        public IHttpActionResult TimKiemNguoiDungTuyChon_PhanTrang(int page, int offset, int Role, int Activated)
        {
            try
            {
                var pageIndex = (page - 1) * offset;
                var dsUser = (from a in db.Users.ToList()
                              from b in db.UserRoles.ToList()
                              where a.Activated == Activated && b.Role_ID == Role && a.ID_User == b.User_ID
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
                              }).OrderByDescending(x => x.ID_User).Skip(pageIndex).Take(offset).ToList();
                return Ok(dsUser);
            }
            catch
            {
                return BadRequest("Có lỗi,xin vui lòng thử lại");
            }
        }


        [Route("ThemNguoiDung")]
        [HttpPost]
        public IHttpActionResult ThemNguoiDung(UserThemMoi objUser)
        {
            try
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
                    return Ok("Thêm Người Dùng Thành Công");
                }
                return BadRequest("Email Đã Tồn Tại,Xin Thử Một Email Khác");
            }
            catch
            {
                return BadRequest("Có Lỗi,Xin Vui Lòng Thử Lại");
            }
        }

        [Route("XoaNguoiDung")]
        [HttpDelete]
        public IHttpActionResult XoaNguoiDung(int idUser)
        {
            var kh = db.Users.Where(x => x.ID_User == idUser).FirstOrDefault();
            if(kh != null)
            {
                var _Role = db.UserRoles.Where(x => x.User_ID == kh.ID_User).FirstOrDefault();
                if(_Role != null)
                {
                    db.UserRoles.Remove(_Role);
                    db.SaveChanges();
                }
                db.Users.Remove(kh);
                db.SaveChanges();
                return Ok("Xóa Người Dùng Thành Công");
            }
            return BadRequest("Có lỗi,Xin vui lòng thử lại");
        }

        [Route("TuyChinhNguoiDung")]
        [HttpPut]
        public IHttpActionResult TuyChinhNguoiDung(UserTuyChinh UserTuyChinh)
        {
            var user = db.Users.Where(x => x.ID_User == UserTuyChinh.ID_User).FirstOrDefault();
            if (user != null)
            {
                user.Activated = UserTuyChinh.Activated;
                db.Entry(user).State = System.Data.EntityState.Modified;
                db.SaveChanges();
                var role = db.UserRoles.Where(j => j.User_ID == UserTuyChinh.ID_User).Single();
                if(role != null)
                {
                    db.UserRoles.Remove(role);
                    db.SaveChanges();
                    UserRole userRole = new UserRole()
                    {
                        User_ID = user.ID_User,
                        Role_ID = UserTuyChinh.Role_ID
                    };
                    db.UserRoles.Add(userRole);
                    
                    db.SaveChanges();
                }
                return Ok("Cập Nhật Trạng Thái Người Dùng Thành Công");
            }
            return BadRequest("Có lỗi,Xin vui lòng thử lại");
        }
    }
}
