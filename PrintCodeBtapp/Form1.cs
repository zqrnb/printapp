using BarTender;
using KUKAMES.Entity.DomainModels;
using PrintCodeBtapp.Model;
using PrintForms.Helper;
using PrintForms.Model;
using S7.Net;
using System.Diagnostics;

namespace PrintCodeBtapp
{
    public partial class Form1 : Form
    {

        private readonly static string path = Path.GetFullPath(Path.Combine(AppContext.BaseDirectory, AppSetting.GetSettingString("barcode")));      // 标签模板 full path
        private readonly static string softpathPreview = Path.GetFullPath(Path.Combine(AppContext.BaseDirectory, AppSetting.GetSettingString("softpathPreview")));    // 预览图保存目录
        private readonly static string Printer = AppSetting.GetSettingString("Printer");    // 打印机型号
        private readonly static string PLCIP = AppSetting.GetSettingString("PLCIP");    // PLC IP
        private readonly static string PLCPrint = AppSetting.GetSettingString("PLCPrint");

        private ApplicationClass btApp = new ApplicationClass();
        private Format btFmt;
        private string btFmtPath;
        private int maxLogWidth;
        private bool dbErrorLogged;

        public Form1()
        {
            InitializeComponent();
            try
            {
                var productModel = DbSugarContext.Db.Queryable<Basic_ProductModel>().Select(s => new { name = s.ProductCode + "|" + s.ProductModel, value = s.ProductModel }).ToList();
                comboBox1.DataSource = productModel;
                comboBox1.DisplayMember = "name";
                comboBox1.ValueMember = "value";
            }
            catch (Exception ex)
            {
                Logs.Error($"加载产品型号失败：{ex.Message}");
                ListBoxLogs($"加载产品型号失败：{ex.Message}");
            }
            ListBoxLogs($"🖨️🖨️🖨️打印程序启动成功......");
        }

        private void button1_Click(object sender, EventArgs e)
        {
            if (MessageBox.Show("手动打印可能会导致条码重复，请妥善处理多余条码，是否继续", "KUKA打印程序",
                            MessageBoxButtons.OKCancel,
                            MessageBoxIcon.Question) != DialogResult.OK)
            {
                return;
            }
            ListBoxLogs("用户开始重新打印条码！！！！");
            var sn = textBox1.Text;
            if (string.IsNullOrEmpty(sn) || comboBox1.SelectedValue == null)
            {
                MessageBox.Show("请输入总成条码并选择当前机型", "KUKA打印程序", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                return;
            }
            var model = comboBox1.SelectedValue.ToString();
            Logs.Write($"人工手动重新打码，SN编号：【{sn}】,选择模板路径：【{path}】");
            ListBoxLogs($"人工手动重新打码，SN编号：【{sn}】,选择模板路径：【{path}】");
           // var productModel = DbSugarContext.Db.Queryable<Basic_ProductModel>().Where(s => s.ProductModel == model).First();

            var btinfo = new BtInfo()
            {
                //productName = productModel.ProductParts,
                sn = sn
            };
            PrintBtPreview(btinfo, path, false);


        }

        private bool PrintBtPreview(BtInfo bt, string path, bool isAuto = true)
        {
            if (!File.Exists(path))
            {
                Logs.Error($"默认模板文件地址:【{path}】未找到，请创建模板后继续...");
                ListBoxLogs($"默认模板文件地址:【{path}】未找到，请创建模板后继续");
                return false;
            }

            try
            {
                string printType = isAuto ? "自动打印" : "手动打印";

                var sw = Stopwatch.StartNew();
                bool reopened = false;

                // 模板常驻复用，仅在首次或模板路径变化时打开，避免每个SN重复Open的开销
                if (btFmt == null || btFmtPath != path)
                {
                    btFmt?.Close(BtSaveOptions.btDoNotSaveChanges);
                    btFmt = btApp.Formats.Open(path, false);
                    btFmt.Printer = Printer;
                    btFmtPath = path;
                    reopened = true;
                }
                long msOpen = sw.ElapsedMilliseconds;

                //btFmt.SetNamedSubStringValue("Name", bt.productName);
                btFmt.SetNamedSubStringValue("SN", bt.sn);

                btApp.Visible = false;

                btFmt.PrintSetup.IdenticalCopiesOfLabel = 1;
                btFmt.PrintOut(false, false);
                long msPrint = sw.ElapsedMilliseconds;
                ListBoxLogs($"【{bt.sn}】{printType}完成");

                string imgPath = $"{softpathPreview}{DateTime.Now.ToString("yyyyMMdd")}\\";

                if (isAuto) imgPath += "自动打印\\";
                else imgPath += "手动打印\\";

                if (!Directory.Exists(imgPath))
                {
                    Directory.CreateDirectory(imgPath);
                }
                var imgFolder = $"{imgPath}{bt.sn}.jpg";
                btFmt.ExportToFile(imgFolder, "JPG", BtColors.btColors24Bit, BtResolution.btResolutionPrinter, BtSaveOptions.btDoNotSaveChanges);
                long msExport = sw.ElapsedMilliseconds;
                pictureBox1.ImageLocation = imgFolder;

                Logs.Write($"【{bt.sn}】耗时(ms)：模板={(reopened ? "重载" : "复用")}{msOpen}，PrintOut={msPrint - msOpen}，预览图={msExport - msPrint}，合计={msExport}");

                return true;
            }
            catch (Exception ex)
            {
                Logs.Error($"打印机程序错误：{ex.Message}");
                ListBoxLogs($"打印机程序错误：{ex.Message}");
                return false;
            }
        }

        private void timer1_Tick(object sender, EventArgs e)
        {
            try
            {
                var printcode = DbSugarContext.Db.Queryable<Basic_Printcode>().OrderByDescending(s => s.CreateDate).Where(s => s.isPrint == false).ToList().FirstOrDefault();
                if (printcode != null)
                {
                    var productModel = DbSugarContext.Db.Queryable<Basic_ProductModel>().Where(s => s.ProductModel == printcode.ProdModel).ToList().FirstOrDefault();
                    if (productModel == null)
                    {
                        Logs.Error($"未找到当前打印条码:【{printcode.Ext}】的产品型号类型：【{printcode.ProdModel}】，请检查产品型号配置");
                        ListBoxLogs($"未找到当前打印条码:【{printcode.Ext}】的产品型号类型：【{printcode.ProdModel}】，请检查产品型号配置");
                        printcode.isPrint = true;
                        DbSugarContext.Db.Updateable(printcode).ExecuteCommand();
                        return;
                    }
                    ListBoxLogs($"开始自动打印：【{printcode.Ext}】条码；当前使用模板：【{path}】");
                    Logs.Write($"开始自动打印：【{printcode.Ext}】条码；当前使用模板：【{path}】");
                    var btinfo = new BtInfo()
                    {
                        //productName = productModel.ProductParts,
                        sn = printcode.Ext
                    };
                    textBox1.Text = btinfo.sn;
                    comboBox1.SelectedValue = productModel.ProductModel;
                    if (PrintBtPreview(btinfo, path))
                    {
                        printcode.isPrint = true;
                        DbSugarContext.Db.Updateable(printcode).ExecuteCommand();
                    }
                    else
                    {
                        Logs.Error($"【{printcode.Ext}】打印失败，本次不标记为已打印，下个周期自动重试");
                        ListBoxLogs($"【{printcode.Ext}】打印失败，本次不标记为已打印，下个周期自动重试");
                    }
                }

                if (dbErrorLogged)
                {
                    dbErrorLogged = false;
                    ListBoxLogs($"数据库连接恢复正常");
                }
            }
            catch (Exception ex)
            {
                if (!dbErrorLogged)
                {
                    dbErrorLogged = true;
                    Logs.Error($"数据库查询异常：{ex.Message}");
                    ListBoxLogs($"数据库查询异常：{ex.Message}");
                }
            }
        }

        /// <summary>
        /// 写入PLC点位
        /// </summary>
        private void WritPlcPrint()
        {
            var plc = new Plc(CpuType.S71200, PLCIP, 0, 1);
            plc.Open();

            // 写 TRUE
            plc.Write(PLCPrint, true);

            plc.Close();
        }

        private void Form1_FormClosing(object sender, FormClosingEventArgs e)
        {
            var result = MessageBox.Show(
            "退出程序会导致条码无法正常打印,请确认是否退出？",
            "退出确认",
            MessageBoxButtons.YesNo,
            MessageBoxIcon.Question);

            if (result == DialogResult.No)
            {
                e.Cancel = true;
                return;
            }

            try
            {
                btFmt?.Close(BtSaveOptions.btDoNotSaveChanges);
            }
            catch (Exception ex)
            {
                Logs.Error($"关闭打印模板失败：{ex.Message}");
            }
        }

        private void button2_Click(object sender, EventArgs e)
        {
            if (MessageBox.Show("日志清空后可在日志文件夹中查看；是否确认清空日志？", "KUKA打印程序",
                            MessageBoxButtons.OKCancel,
                            MessageBoxIcon.Question) == DialogResult.OK)
            {
                listBox1.Items.Clear();
            }
        }

        private void ListBoxLogs(string str)
        {
            listBox1.Items.Add(DateTime.Now.ToString("yyyy-MM-dd HH:mm:ss") + "：" + str);

            listBox1.SelectedIndex = listBox1.Items.Count - 1;

            listBox1.TopIndex = listBox1.Items.Count - 1;

            // 横向滑块范围随日志最长行自适应
            var width = TextRenderer.MeasureText(listBox1.Items[listBox1.Items.Count - 1].ToString(), listBox1.Font).Width;
            if (width > maxLogWidth)
            {
                maxLogWidth = width;
            }
            listBox1.HorizontalExtent = maxLogWidth + 20;
        }
    }
}
