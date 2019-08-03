using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.IO;
using System.Net;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Web;
using System.Threading;
using System.Threading.Tasks;
using System.Windows.Forms;
using OpenQA.Selenium;
using OpenQA.Selenium.Chrome;

namespace CariHunter
{
    public partial class CariHunter : Form
    {
        private Dictionary<string, string> contents = new Dictionary<string, string>()
        {
            {"status", "ステータス" },
            {"date", "データ取得日"},
            {"name", "商品名" },
            {"url", "URL" },
            {"price", "価格" },
            {"postage", "送料" },
            {"sum", "合計"},
            {"new_price", "新価格" },
            {"new_postage", "新送料" },
            {"new_sum", "新合計" },
            {"state", "商品状態" },
            {"description", "商品説明" },
            {"asin", "ASIN" },
            {"price_am", "出品価格am" },
            {"exhibition_url", "出品URL" },
            {"price_ed", "出品価格ed" }
        };
        private Dictionary<string, string> xPaths = new Dictionary<string, string>()
        {
            {"name", @"//div[@class='items-box-content clearfix']/section[_$_]/a/div/h3" },
            {"url", @"//div[@class='items-box-content clearfix']/section[_$_]/a" },
            {"price", "//div[@class='items-box-content clearfix']/section[_$_]/a/div/div/div[1]" }
        };
        private dynamic[] datas = new dynamic[48];
        private string[] img_url = new string[48];
        private bool running = true;
        private string file_path = null;

        public CariHunter()
        {
            InitializeComponent();
        }

        private void Form1_Load(object sender, EventArgs e)
        {
            amount_box.Minimum = 1;
            amount_box.Maximum = 48;
            initialize_table();
            this.FormBorderStyle = FormBorderStyle.FixedSingle;
            save_file.Enabled = false;
            update_button.Enabled = false;
        }

        private void initialize_table()
        {
            datas[0] = contents;
            productsTable.ColumnCount = 17;
            productsTable.Columns[0].HeaderText = "No";
            int cnt = 1;
            foreach (KeyValuePair<string, string> kvp in contents)
            {
                productsTable.Columns[cnt].HeaderText = kvp.Value;
                cnt++;
            }
            for (int i = 0; i < 48; i++)
                productsTable.Rows.Add();
            productsTable.ReadOnly = true;
        }

        private void push_table(dynamic data, int n)
        {
            var keys = get_keys(contents);
            productsTable[0, n].Value = (n + 1).ToString();
            for (int i = 0; i < 16; i++)
                productsTable[i + 1, n].Value = data[keys[i]];
            this.Invoke((MethodInvoker)(() => productsTable.Update()));
            Thread.Sleep(10);
        }

        private dynamic get_keys(Dictionary<string, string> dic)
        {
            var ret = new List<string>();
            foreach (KeyValuePair<string, string> kvp in dic)
            {
                ret.Add(kvp.Key);
            }
            return ret;
        }

        private void fetch_button_Click(object sender, EventArgs e)
        {
            string name = product_box.Text;
            int limit = Decimal.ToInt32(amount_box.Value);
            if (name == "")
                return;
            var task = Task.Run(() =>
            {
                running = true;
                this.Invoke((MethodInvoker)(() => fetch_button.Enabled = false));
                this.Invoke((MethodInvoker)(() => update_button.Enabled = false));
                fetch_items(name, limit);
                this.Invoke((MethodInvoker)(() => fetch_button.Enabled = true));
                this.Invoke((MethodInvoker)(() => update_button.Enabled = true));
            });
        }

        private void fetch_items(string name, int limit)
        {
            string url = string.Format("https://www.mercari.com/jp/search/?keyword={0}", name);
            string html = get_html(url);
            for (int i = 0; i < limit; i++)
            {
                if (running == false)
                    return;
                try
                {
                    DateTime dt = DateTime.Now;
                    datas[i] = new Dictionary<string, string>();
                    datas[i]["status"] = "0";
                    datas[i]["date"] = dt.ToString("yyyy/MM/dd");
                    datas[i]["name"] = get_value(html, xPaths["name"].Replace("_$_", (i + 1).ToString()));
                    datas[i]["url"] = get_url(html, xPaths["url"].Replace("_$_", (i + 1).ToString()));
                    datas[i]["price"] = get_value(html, xPaths["price"].Replace("_$_", (i + 1).ToString()));
                    string datail_html = get_html(datas[i]["url"]);
                    datas[i]["sum"] = get_value(datail_html, @"//div[1]/section/div[2]/span[1]");
                    datas[i]["state"] = get_value(datail_html, @"//div[1]/section/div[1]/table/tbody/tr[4]/td");
                    datas[i]["postage"] = get_value(datail_html, @"//div[1]/section/div[1]/table/tbody/tr[5]/td");
                    datas[i]["description"] = get_value(datail_html, @"//div[1]/section/div[3]/p");
                    datas[i]["new_price"] = "";
                    datas[i]["new_postage"] = "";
                    datas[i]["new_sum"] = "";
                    datas[i]["asin"] = "";
                    datas[i]["price_am"] = "";
                    datas[i]["exhibition_url"] = "";
                    datas[i]["price_ed"] = "";
                    img_url[i] = get_url(html, string.Format(@"//div[1]/section/div/section[{0}]/a/figure/img", i+1), "data-src");
                    push_table(datas[i], i);
                }
                catch (Exception)
                {
                }
            }
        }

        private string get_html(string url)
        {
            if (running == false)
                return "";
            var options = new ChromeOptions();
            options.AddArgument("--headless");
            var driverService = ChromeDriverService.CreateDefaultService();
            driverService.HideCommandPromptWindow = true;
            IWebDriver driver = new ChromeDriver(driverService, options);
            driver.Url = url;
            string html = driver.PageSource;
            driver.Close();
            return html;
        }

        private string get_value(string html, string xpath)
        {
            if (running == false)
                return "";
            var doc = new HtmlAgilityPack.HtmlDocument();
            doc.LoadHtml(html);
            return doc.DocumentNode.SelectSingleNode(xpath).InnerText.Replace(',', '，');
        }

        private string get_url(string html, string xpath, string where="href")
        {
            var doc = new HtmlAgilityPack.HtmlDocument();
            doc.LoadHtml(html);
            return doc.DocumentNode.SelectSingleNode(xpath).Attributes[where].Value;
        }

        private void kill_task_Click(object sender, EventArgs e)
        {
            running = false;
        }

        private void save_images(string url, int n, string dir)
        {
            WebClient wc = new WebClient();
            byte[] b1 = wc.DownloadData(url);
            ImageConverter ic = new ImageConverter();
            Image img = (Image)ic.ConvertFrom(b1);
            img.Save(string.Format(@"{0}\images\{1}.png", dir, n));
        }

        private void save_file_Click(object sender, EventArgs e)
        {
            var keys = get_keys(contents);
            string header = "";
            for (int i = 0; i < 16; i++)
            {
                header += string.Format("{0}, ", contents[keys[i]]);
            }
            using (var sw = new StreamWriter(file_path, false))
            {
                sw.WriteLine(header);
                for (int i = 0; i < 48; i++)
                {
                    if (datas[i] == null)
                        break;
                    string row = "";
                    for (int j = 0; j < 16; j++)
                    {
                        row += string.Format("{0},", datas[i][keys[j]]);
                    }
                    sw.WriteLine(row);
                }
            }
        }

        private void save_new_file_Click(object sender, EventArgs e)
        {
            SaveFileDialog sfd = new SaveFileDialog();
            sfd.FileName = "新しいファイル.csv";
            sfd.InitialDirectory = @"C:\";
            sfd.Title = "保存先のファイルを選択してください";
            sfd.RestoreDirectory = true;
            if (sfd.ShowDialog() == DialogResult.OK)
            {
                save_file.Enabled = true;
                file_path = sfd.FileName;
                Directory.CreateDirectory(Path.GetDirectoryName(file_path)+@"\images");
                DirectoryInfo target = new DirectoryInfo(Path.GetDirectoryName(file_path) + @"\images");
                foreach (FileInfo file in target.GetFiles())
                {
                    file.Delete();
                }
                var keys = get_keys(contents);
                string header = "";
                for (int i = 0; i < 16; i++)
                {
                    header += string.Format("{0}, ", contents[keys[i]]);
                }
                using (var sw = new StreamWriter(sfd.FileName, false))
                {
                    sw.WriteLine(header);
                    for (int i = 0; i < 48; i++)
                    {
                        if (datas[i] == null)
                            break;
                        string row = "";
                        for (int j = 0; j < 16; j++)
                        {
                            row += string.Format("{0},", datas[i][keys[j]]);
                        }
                        sw.WriteLine(row);
                        save_images(img_url[i], i + 1, Path.GetDirectoryName(file_path));
                    }
                }
            }
        }

        private void open_file_Click(object sender, EventArgs e)
        {
            OpenFileDialog ofd = new OpenFileDialog();
            ofd.InitialDirectory = @"C:\";
            ofd.Title = "開くファイルを選択してください";
            ofd.RestoreDirectory = true;
            ofd.Filter = "CSVファイル|*.csv";
            if (ofd.ShowDialog() == DialogResult.OK)
            {
                save_file.Enabled = true;
                update_button.Enabled = true;
                file_path = ofd.FileName;
                datas = new dynamic[48];
                StreamReader reader = (
                    new StreamReader(ofd.FileName, Encoding.UTF8)
                );
                StreamReader reader_ = (
                    new StreamReader(ofd.FileName, Encoding.UTF8)
                );
                int num = CountChar(reader_.ReadToEnd(), ',') / 16 - 1;
                var keys = get_keys(contents);
                reader.ReadLine();
                for (int i = 0; i < num; i++)
                {
                    datas[i] = new Dictionary<string, string>();
                    string row = reader.ReadLine();
                    while (true)
                    {
                        if (CountChar(row, ',') == 16)
                            break;
                        row += "\n" + reader.ReadLine();
                    }
                    string[] columns = row.Split(',');
                    for (int j = 0; j < 16; j++)
                        datas[i][keys[j]] = columns[j];
                    push_table(datas[i], i);
                }
                reader.Close();
                reader_.Close();
            }
        }

        public static int CountChar(string s, char c)
        {
            return s.Length - s.Replace(c.ToString(), "").Length;
        }

        private void update_button_Click(object sender, EventArgs e)
        {
            var task = Task.Run(() =>
            {
                running = true;
                this.Invoke((MethodInvoker)(() => fetch_button.Enabled = false));
                this.Invoke((MethodInvoker)(() => update_button.Enabled = false));
                update_datas();
                this.Invoke((MethodInvoker)(() => fetch_button.Enabled = true));
                this.Invoke((MethodInvoker)(() => update_button.Enabled = true));
            });
        }

        private void update_datas()
        {
            for (int i = 0; i < 48; i++)
            {
                if (running==false || datas[i]==null)
                    return;
                try
                {
                    string html = get_html(datas[i]["url"]);
                    DateTime dt = DateTime.Now;
                    datas[i]["date"] = dt.ToString("yyyy/MM/dd");
                    datas[i]["new_price"] = get_value(html, @"//div[1]/section/div[2]/span[1]");
                    datas[i]["new_sum"] = get_value(html, @"//div[1]/section/div[2]/span[1]");
                    datas[i]["new_postage"] = get_value(html, @"//div[1]/section/div[1]/table/tbody/tr[5]/td");
                    if (datas[i]["price"] != datas[i]["new_price"] || datas[i]["sum"] != datas[i]["new_sum"] || datas[i]["postage"] != datas[i]["new_postage"])
                        datas[i]["state"] = "1";
                    push_table(datas[i], i);
                }
                catch (Exception)
                {
                }

            }
        }
    }
}