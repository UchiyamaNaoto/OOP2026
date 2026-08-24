using System.ComponentModel;
using System.Runtime.Serialization.Formatters.Binary;
using System.Xml;
using System.Xml.Serialization;
using static CarReportSystem.CarReport;

namespace CarReportSystem {
    public partial class Form1 : Form {

        //カーレポート管理用リスト
        BindingList<CarReport> listCarReports = new BindingList<CarReport>();

        //設定クラスのオブジェクトを生成
        Settings settings = new Settings();

        public Form1() {
            InitializeComponent();
            dgvRecords.DataSource = listCarReports;
        }

        private void Form1_Load(object sender, EventArgs e) {
            //設定ファイルを読み込み背景色を設定する（逆シリアル化）

            //ファイルが存在するか？
            if (File.Exists("setting.xml")) {
                try {

                    //P286以降を参考にする（ファイル名：setting.xml）
                    using (var reader = XmlReader.Create("setting.xml")) {
                        var serializer = new XmlSerializer(typeof(Settings));
                        settings = serializer.Deserialize(reader) as Settings;
                        //背景色設定
                        BackColor = Color.FromArgb(settings.MainFormBackColor);
                    }
                }
                catch (Exception ex) {
                    tsslbMessage.Text = "設定ファイル読み込みエラー";
                    MessageBox.Show(ex.Message);//←より具体的なエラーを出力         
                }
            } else {
                tsslbMessage.Text = "設定ファイルがありません";
            }
        }

        //追加ボタンイベントハンドラ
        private void btAddRecord_Click(object sender, EventArgs e) {

            tsslbMessage.Text = String.Empty;   //メッセージ領域のクリア

            //記録者と車名が未入力だった場合は追加しない
            //if(cbAuthor.Text == String.Empty || cbCarName.Text == String.Empty) {
            if (String.IsNullOrWhiteSpace(cbAuthor.Text) || String.IsNullOrWhiteSpace(cbCarName.Text)) {
                tsslbMessage.Text = "記録者、または車名が未入力です";
                return;
            }

            var carReport = new CarReport {
                Date = dtpDate.Value.Date,
                Author = cbAuthor.Text.Trim(),
                Maker = GetRadioButtonMaker(),
                CarName = cbCarName.Text.Trim(),
                Report = tbReport.Text,
                Picture = pbPicture.Image,
            };
            listCarReports.Add(carReport);

            //入力履歴を登録
            SetCbAuthor(cbAuthor.Text.Trim());
            SetCbCarName(cbCarName.Text.Trim());

            dgvRecords.ClearSelection(); //セルの選択を解除する
            InputItemsUpdate(); //データグリッドビューを更新したら呼ぶメソッド
        }

        private MakerGroup GetRadioButtonMaker() {
            if (rbToyota.Checked)
                return MakerGroup.トヨタ;
            if (rbNissan.Checked)
                return MakerGroup.日産;
            if (rbHonda.Checked)
                return MakerGroup.ホンダ;
            if (rbSubaru.Checked)
                return MakerGroup.スバル;
            if (rbImport.Checked)
                return MakerGroup.輸入車;

            return MakerGroup.その他;
        }
        private void btOpenPicture_Click(object sender, EventArgs e) {
            if (ofdPicFileOpen.ShowDialog() == DialogResult.OK) {
                pbPicture.Image = Image.FromFile(ofdPicFileOpen.FileName);
            }
        }
        private void btNewInput_Click(object sender, EventArgs e) {
            InputItemsAllClear();
        }
        private void InputItemsAllClear() {
            dtpDate.Value = DateTime.Today;
            cbAuthor.Text = string.Empty;
            rbOther.Checked = true;
            cbCarName.Text = string.Empty;
            tbReport.Text = string.Empty;
            pbPicture.Image = null;

            dgvRecords.ClearSelection();//セルの選択を解除する
        }

        private void SetRadioButtonMaker(MakerGroup targetMaker) {

            switch (targetMaker) {

                case MakerGroup.トヨタ:
                    rbToyota.Checked = true;
                    break;
                case MakerGroup.日産:
                    rbNissan.Checked = true;
                    break;
                case MakerGroup.ホンダ:
                    rbHonda.Checked = true;
                    break;
                case MakerGroup.スバル:
                    rbSubaru.Checked = true;
                    break;
                case MakerGroup.輸入車:
                    rbImport.Checked = true;
                    break;
                default:
                    rbOther.Checked = true;
                    break;
            }
        }
        //記録者の入力履歴をコンボボックスへ登録（重複なし）
        private void SetCbAuthor(string author) {
            //未登録なら登録【登録済みなら何もしない】
            if (!cbAuthor.Items.Contains(author))
                cbAuthor.Items.Add(author);
        }
        //車名の入力履歴をコンボボックスへ登録（重複なし）
        private void SetCbCarName(string carName) {
            //未登録なら登録【登録済みなら何もしない】
            if (!cbCarName.Items.Contains(carName))
                cbCarName.Items.Add(carName);

        }
        private void btDeletePicture_Click(object sender, EventArgs e) {
            pbPicture.Image = null;
        }
        private void btDeleteRecord_Click(object sender, EventArgs e) {
            if ((dgvRecords.CurrentRow is null)
                || (!dgvRecords.CurrentRow.Selected)) return;

            //削除したいインデックスを指定してリストから削除
            listCarReports.RemoveAt(dgvRecords.CurrentRow.Index);

            InputItemsUpdate(); //データグリッドビューを更新したら呼ぶメソッド
        }
        //データグリッドビューを更新したら呼ぶメソッド
        private void InputItemsUpdate() {
            if (!dgvRecords.CurrentRow.Selected)
                InputItemsAllClear();
        }
        private void btModifyRecord_Click(object sender, EventArgs e) {

            if (dgvRecords.SelectedRows.Count == 0) {
                tsslbMessage.Text = "修正するレポートを選択してください";
                return;
            }

            if (String.IsNullOrWhiteSpace(cbAuthor.Text)
                    || String.IsNullOrWhiteSpace(cbCarName.Text)) {
                tsslbMessage.Text = "記録者、または車名が未入力です";
                return;
            }

            //カーレポート管理用リストの該当する要素のデータを書き換える
            listCarReports[dgvRecords.CurrentRow.Index].Date = dtpDate.Value.Date;
            listCarReports[dgvRecords.CurrentRow.Index].Author = cbAuthor.Text.Trim();
            listCarReports[dgvRecords.CurrentRow.Index].Maker = GetRadioButtonMaker();
            listCarReports[dgvRecords.CurrentRow.Index].CarName = cbCarName.Text.Trim();
            listCarReports[dgvRecords.CurrentRow.Index].Report = tbReport.Text;
            listCarReports[dgvRecords.CurrentRow.Index].Picture = pbPicture.Image;

            SetCbAuthor(cbAuthor.Text.Trim());
            SetCbCarName(cbCarName.Text.Trim());

            dgvRecords.Refresh();   //データグリッドビューの更新
            tsslbMessage.Text = "レポートを修正しました";
        }

        private void dgvRecords_SelectionChanged(object sender, EventArgs e) {

            if ((dgvRecords.CurrentRow?.DataBoundItem is not CarReport carReport)
                    || (!dgvRecords.CurrentRow.Selected)) return;

            dtpDate.Value = carReport.Date;
            cbAuthor.Text = carReport.Author;
            SetRadioButtonMaker(carReport.Maker);
            cbCarName.Text = carReport.CarName;
            tbReport.Text = carReport.Report;
            pbPicture.Image = carReport.Picture;

            InputItemsUpdate(); //データグリッドビューを更新したら呼ぶメソッド
        }

        private void 終了ToolStripMenuItem_Click(object sender, EventArgs e) {
            Application.Exit();
        }

        private void 色設定ToolStripMenuItem_Click(object sender, EventArgs e) {
            if (cdColor.ShowDialog() == DialogResult.OK) {
                BackColor = cdColor.Color;
                //変更された色の情報を保存
                settings.MainFormBackColor = cdColor.Color.ToArgb();
            }
        }

        //フォームが閉じたら呼ばれるイベントハンドラ
        private void Form1_FormClosed(object sender, FormClosedEventArgs e) {
            //設定ファイルへ色情報を保存する処理（シリアル化）
            //P284以降を参考にする（ファイル名：setting.xml）

            using (var writer = XmlWriter.Create("setting.xml")) {
                var serializer = new XmlSerializer(settings.GetType());
                serializer.Serialize(writer, settings);
            }
        }

        private void 保存ToolStripMenuItem_Click(object sender, EventArgs e) {
            reportSaveFile();
        }

        private void 開くToolStripMenuItem_Click(object sender, EventArgs e) {
            reportOpenFile();
        }

        //ファイルセーブ処理
        private void reportSaveFile() {
            if (sfdReportFileSave.ShowDialog() == DialogResult.OK) {
                try {
                    //バイナリ形式でシリアル化
#pragma warning disable SYSLIB0011
                    var bf = new BinaryFormatter();
#pragma warning restore SYSLIB0011
                    using (FileStream fs = File.Open(sfdReportFileSave.FileName, FileMode.Create)) {
                        bf.Serialize(fs, listCarReports);
                    }
                }
                catch (Exception ex) {
                    tsslbMessage.Text = "ファイル書き出しエラー";
                    MessageBox.Show(ex.Message);
                }
            }
        }

        //ファイルオープン処理
        private void reportOpenFile() {
            if (ofdReportFileOpen.ShowDialog() == DialogResult.OK) {
                try {
                    //逆シリアル化でバイナリ形式を取り込む
#pragma warning disable SYSLIB0011
                    var bf = new BinaryFormatter();
#pragma warning restore SYSLIB0011
                    using (FileStream fs = File.Open(
                        ofdReportFileOpen.FileName, //ファイル名
                        FileMode.Open,  //ファイルモード
                        FileAccess.Read //アクセス
                        )) {

                        listCarReports = (BindingList<CarReport>)bf.Deserialize(fs);
                        dgvRecords.DataSource = listCarReports;
                    }
                    //コンボボックスの履歴をすべて消す
                    cbAuthor.Items.Clear();
                    cbCarName.Items.Clear();

                    //コンボボックスの履歴を再登録
                    foreach (var report in listCarReports) {
                        SetCbAuthor(report.Author);
                        SetCbCarName(report.CarName);
                    }
                }
                catch (Exception ex) {
                    tsslbMessage.Text = "ファイル読み出しエラー";
                    MessageBox.Show(ex.Message);
                }
            }

        }
    }
}
