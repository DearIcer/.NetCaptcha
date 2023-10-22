using WinFormsApp1.common;
using static WinFormsApp1.common.CaptchaUtil;

namespace WinFormsApp1
{
    public partial class Form1 : Form
    {
        //验证码
        private string code { get; set; }
        // 验证码图片
        private CaptchaResult verifyCode { get; set; }

        public Form1()
        {
            InitializeComponent();
        }

        private void Form1_Load(object sender, EventArgs e)
        {
            CreateCaptcha();
        }

        private void pictureBox1_Click(object sender, EventArgs e)
        {
            CreateCaptcha();
        }

        /// <summary>
        /// 创建验证码
        /// </summary>
        private void CreateCaptcha()
        {
            //获取验证码
            code = CaptchaUtil.GetRandomEnDigitalText();
            //生成验证码图片
            verifyCode = CaptchaUtil.GenerateCaptchaImage(code);
            //转成Base64
            var base64String = Convert.ToBase64String(verifyCode.CaptchaMemoryStream.ToArray());
            //将Base64编码的图片解码为字节数组
            byte[] imageBytes = Convert.FromBase64String(base64String);

            //将字节数组转换成MemoryStream对象
            using (MemoryStream ms = new MemoryStream(imageBytes))
            {
                //从MemoryStream中创建Image对象
                Image image = Image.FromStream(ms);

                //将Image对象显示在PictureBox控件上
                pictureBox1.Image = image;

            }
        }

        private void button1_Click(object sender, EventArgs e)
        {
            if (textBox1.Text.ToUpper() != code)
            {
                MessageBox.Show("验证码错误");
                CreateCaptcha();
                return;
            }
            MessageBox.Show("验证码正确");
        }
    }
}