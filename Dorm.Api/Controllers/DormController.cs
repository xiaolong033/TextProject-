using Dorm.Api.Models;
using Dorm.Api.Tools;
using Dorm.Dto;
using Dorm.IBLL;
using System;
using System.Collections.Generic;
using System.Drawing;
using System.IO;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Threading.Tasks;
using System.Web;
using System.Web.Http;
using System.Web.Http.Cors;

namespace Dorm.Api.Controllers
{
    [EnableCors(origins: "*", headers: "*", methods: "*")]
    [RoutePrefix("api/Dorm")]

    public class DormController : ApiController
    {
        public IStudentManager studentManager { get; set; }
        public IAdminManager adminManager { get; set; }
        public IDormManager dormManager { get; set; }

        [AllowAnonymous]
        [HttpPost]
        [Route("login")]
        public async Task<string> Login(LoginVm lvm)
        {
            if (await adminManager.Login(lvm.Name, lvm.Pwd) == null)
            {
                return "登陆失败";
            }
            else
            {
                return JwtTools.JwtEncode(new Dictionary<string, object>() {
                    { "loginname",lvm.Name},

                });
            }
        }
        /// <summary>
        /// 获得所有宿舍
        /// </summary>
        /// <returns></returns>
        [HttpGet]
        [Route("GetDorms")]
        public async Task<List<DormDto>> GetDorms()
        {
           var res= await dormManager.GetDorm();
            return res;
        }
        /// <summary>
        /// 获得所有学生
        /// </summary>
        /// <returns></returns>
        [HttpGet]
        [Route("GetStus")]
        public async Task<List<StudentDto>> GetStudents()
        {
            return await studentManager.GetStudents();
        }
        /// <summary>
        /// 获得某个宿舍所有学生
        /// </summary>
        /// <returns></returns>
        [HttpGet]
        [Route("GetStus")]
        public async Task<List<StudentDto>> GetStudents(int dno)
        {
            return await studentManager.GetStudents(dno);
        }
        /// <summary>
        /// 添加学生
        /// </summary>
        /// <returns></returns>
        [HttpPost]
        [Route("AddStu")]
        public async Task AddStu(StuVm stu)
        {
            await studentManager.AddStu(stu.Name, stu.Phone, stu.Dno);
        }
        /// <summary>
        /// 添加宿舍
        /// </summary>
        /// <returns></returns>
        ///  [HttpGet]
        [HttpPost]
        [Route("AddDorm")]
        public async Task AddDorm(DormVm dorm)
        {
            await dormManager.AddDorm(dorm.Dno,dorm.Count);
        }
        [HttpPost]
        [Route("DelDorm")]
        public async Task DelDorm(DormVm dorm)
        {
            await dormManager.Removed(dorm.id);
        }
        [HttpPost]
        [Route("EditDorm")]
        public async Task EditDorm(DormVm dorm)
        {
            await dormManager.Edit(dorm.id,dorm.Dno,dorm.Count);
        }
        [HttpPost]
        [Route("UpFile")]
        public  string  PostFile()
        {
            try
            {

                HttpRequest request = HttpContext.Current.Request;//获取请求对象
                HttpFileCollection fileCollection = request.Files;//获取对象集
                Stream fs = fileCollection[0].InputStream;//获取单一对象
                Byte[] imagebytes = new byte[fs.Length];//读取字符流的长度
                BinaryReader br = new BinaryReader(fs); //文件
                imagebytes = br.ReadBytes(Convert.ToInt32(fs.Length));//赋值字符流

                MemoryStream ms = new MemoryStream(imagebytes);
                Image imageBlob = Image.FromStream(ms, true);//用流创建Image   
                string name = Guid.NewGuid().ToString();//保存用的名字
                string tyle = null;//设置文件格式
                if (imageBlob.RawFormat.Equals(System.Drawing.Imaging.ImageFormat.Jpeg))
                {
                    tyle = ".jpg";
                }
                if (imageBlob.RawFormat.Equals(System.Drawing.Imaging.ImageFormat.Png))
                {
                    tyle = ".png";
                }
                if (imageBlob.RawFormat.Equals(System.Drawing.Imaging.ImageFormat.Gif))
                {
                    tyle = ".Gif";
                }
                if (tyle == null)
                {
                    return null;
                }

                imageBlob.Save(@"D:\WebService\Images\" + name + tyle);//保存本地

                return "http://localhost:10089/images/" + name + tyle;
            }
            catch
            {
                return null;
            }


        }
    }
}
