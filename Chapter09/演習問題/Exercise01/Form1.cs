using System;
using System.Globalization;

namespace Exercise01 {
    public partial class Form1 : Form {
        public Form1() {
            InitializeComponent();
        }

        private void btButton1_Click(object sender, EventArgs e) {
            var dateTime = DateTime.Now;

            //P200QÆ
            tbOut1.Text = string.Format($"{dateTime:yyyy/MM/dd HH:mm}");
        }

        private void btButton2_Click(object sender, EventArgs e) {
            var dateTime = DateTime.Now;
            tbOut2.Text = dateTime.ToString($"{dateTime:yyyy”NMMŒdd“ú HHmm•ªss•b}");
        }

        private void btButton3_Click(object sender, EventArgs e) {
            var dateTime = DateTime.Now;

            var culture = new CultureInfo("ja-JP");
            culture.DateTimeFormat.Calendar = new JapaneseCalendar();

            var cul = dateTime.ToString("gg", culture); //˜a—ï
            var dayOfWeek = culture.DateTimeFormat.GetDayName(dateTime.DayOfWeek);  //—j“ú

            var year = int.Parse(dateTime.ToString("yy", culture));
            var str2 = string.Format($"{cul}{year,2}”N{dateTime.Month,2}Œ{dateTime.Day,2}“ú({dayOfWeek})");
            tbOut3.Text = str2;
        }
    }
}
