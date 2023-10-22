using WinFormsApp1.common;
using static WinFormsApp1.common.CaptchaUtil;

namespace WinFormsApp1
{
    public partial class Form1 : Form
    {
        //��֤��
        private string code { get; set; }
        // ��֤��ͼƬ
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
        /// ������֤��
        /// </summary>
        private void CreateCaptcha()
        {
            //��ȡ��֤��
            code = CaptchaUtil.GetRandomEnDigitalText();
            //������֤��ͼƬ
            verifyCode = CaptchaUtil.GenerateCaptchaImage(code);
            //ת��Base64
            var base64String = Convert.ToBase64String(verifyCode.CaptchaMemoryStream.ToArray());
            //��Base64�����ͼƬ����Ϊ�ֽ�����
            byte[] imageBytes = Convert.FromBase64String(base64String);

            //���ֽ�����ת����MemoryStream����
            using (MemoryStream ms = new MemoryStream(imageBytes))
            {
                //��MemoryStream�д���Image����
                Image image = Image.FromStream(ms);

                //��Image������ʾ��PictureBox�ؼ���
                pictureBox1.Image = image;

            }
        }

        private void button1_Click(object sender, EventArgs e)
        {
            if (textBox1.Text.ToUpper() != code)
            {
                MessageBox.Show("��֤�����");
                CreateCaptcha();
                return;
            }
            MessageBox.Show("��֤����ȷ");
        }
    }
}