using Newtonsoft.Json;
using Newtonsoft.Json.Linq;
using System;
using System.Collections;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace _2212366_Lab5_Dsktop
{
    public partial class Form1 : Form
    {
        public Form1()
        {
            InitializeComponent();
        }

        //Tham số là path
        //Trả về List<Class>
        //Đọc bằng StreamReader và đọc hết lưu vào string
        //Chuyển đổi string thành array bằng cách sử dụng
        //       phương thức deserialize ( code tuần tự ) của lớp JsonConvert và ép kiểu thành JObject
        // Truy cập vào phần tử ví dụ như sinh vien trong FileJson và các phần tử con (mảng) của nó Children()
        // Với từng phần tử con cho truy cập vào các thành phần con trong FileJson, chuyển đổi, và gán vào các thuộc tính cần đọc
        // Tạo  đối tượng, khởi tạo chúng và add list
        // Return list;

        private List<SinhVien> ReadFileJson(string path)
        {
            List<SinhVien> dssv = new List<SinhVien>();
            StreamReader sr = new StreamReader(path);
            string s = sr.ReadToEnd();
            var array = (JObject)JsonConvert.DeserializeObject(s);
            var ds = array["Sinh Vien"].Children();
            foreach (var item in ds)
            {
                string mssv = item["MSSV"].Value<string>();
                string hoten = item["Ho va ten"].Value<string>();
                int tuoi = item["Tuoi"].Value<int>();
                double diem = item["Diem"].Value<double>();
                bool tongiao = item["Ton giao"].Value<bool>();
                SinhVien sv =  new SinhVien(mssv, hoten, tuoi, diem, tongiao);
                dssv.Add(sv);
            }
            return dssv;


        }
        private void btn_ReadJsonFile_Click(object sender, EventArgs e)
        {
            string path = "D:\\2212366\\2212366_Lab5_Dsktop\\2212366_Lab5_Dsktop\\SinhVien.json";
            string s = "";
            
            List<SinhVien> dssv = ReadFileJson(path);
            //foreach (SinhVien item in dssv)
            //{
            //    int i = 0;
            //    s += string.Format("Sinh vien thu {0} co MSSV: {1}, Ho va ten: {2}, Tuoi: {3}, Diem: {4}, TonGiao: {5} \r ", (i+1), item.MSSV, item.HoTen, item.Tuoi, item.Diem, item.TonGiao);
            //}

            for (int i = 0; i < dssv.Count; i++) // Đọc danh sách
            {
                SinhVien info = dssv[i];
                s += string.Format("Sinh viên {0} có MSSV: {1}, họ tên: {2}, điểm TB: { 3} \r\n", (i + 1), info.MSSV, info.HoTen, info.Diem);
            }


            MessageBox.Show(s);



        }

        private void Form1_Load(object sender, EventArgs e)
        {

        }
    }
}
