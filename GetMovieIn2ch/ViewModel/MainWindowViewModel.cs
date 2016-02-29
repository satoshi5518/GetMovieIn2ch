using GetMovieIn2ch.Base;
using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Configuration;
using System.IO;
using System.Linq;
using System.Net;
using System.Text;
using System.Text.RegularExpressions;
using System.Threading.Tasks;
using System.Web;

namespace GetMovieIn2ch.ViewModel
{
    public class MainWindowViewModel : BindableBase
    {

        #region コンストラクター
        public MainWindowViewModel()
        {
            // 初期化
            this.UrlInfoList = new ObservableCollection<UrlInfo>();
            this.Url2ChInfoList = new ObservableCollection<Url2ChInfo>();
        }
        #endregion

        #region フィールド変数
        /// <summary>
        ///  追加サイト名
        /// </summary>
        private String _addName;
        public String AddName
        {
            get { return this._addName; }
            set { this.SetProperty(ref this._addName, value); }
        }

        /// <summary>
        /// 追加URL
        /// </summary>
        private String _addUrl;
        public String AddUrl
        {
            get { return this._addUrl; }
            set { this.SetProperty(ref this._addUrl, value); }
        }

        /// <summary>
        /// 追加識別文字
        /// </summary>
        private String _addIdFront;
        public String AddIdFront
        {
            get { return this._addIdFront; }
            set { this.SetProperty(ref this._addIdFront, value); }
        }

        /// <summary>
        ///  URL情報リスト
        /// </summary>
        private ObservableCollection<UrlInfo> _urlInfoList;
        public ObservableCollection<UrlInfo> UrlInfoList
        {
            get { return this._urlInfoList; }
            set { this.SetProperty(ref this._urlInfoList, value); }
        }

        /// <summary>
        ///  2ちゃんスレ名
        /// </summary>
        private String _addName2Ch;
        public String AddName2Ch
        {
            get { return this._addName2Ch; }
            set { this.SetProperty(ref this._addName2Ch, value); }
        }

        /// <summary>
        /// ２ちゃん追加URL
        /// </summary>
        private String _addUrl2Ch;
        public String AddUrl2Ch
        {
            get { return this._addUrl2Ch; }
            set { this.SetProperty(ref this._addUrl2Ch, value); }
        }

        /// <summary>
        ///  2ちゃんURL情報リスト
        /// </summary>
        private ObservableCollection<Url2ChInfo> _url2ChInfoList;
        public ObservableCollection<Url2ChInfo> Url2ChInfoList
        {
            get { return this._url2ChInfoList; }
            set { this.SetProperty(ref this._url2ChInfoList, value); }
        }

        /// <summary>
        /// エンコード種類
        /// </summary>
        private Encoding encod = Encoding.Unicode;
        #endregion

        #region 処理
        /// <summary>
        /// URL情報Txtの読み込み
        /// </summary>
        public void loadUrlInfoList()
        {
            if (System.IO.File.Exists(@"./InText/UrlInfoList.txt"))
            {

                // StreamReaderでファイルを読み込む
                System.IO.StreamReader reader = (new System.IO.StreamReader(@ConfigurationManager.AppSettings["UrlInfoListPath"], this.encod));

                // 読み込みできる文字がなくなるまで繰り返す
                while (reader.Peek() >= 0)
                {
                    // ファイルを 1 行ずつ読み込む
                    String line = reader.ReadLine();
                    if (line.Length != 0)
                    {
                        string[] stArrayData = line.Split(',');
                        if (3 <= stArrayData.Length)
                        {
                            UrlInfo urlInfo = new UrlInfo();
                            urlInfo.Name = stArrayData[0];
                            urlInfo.Url = stArrayData[1];
                            urlInfo.IdFront = stArrayData[2];
                            this.UrlInfoList.Add(urlInfo);
                        }
                    }
                }

                // 閉じる (オブジェクトの破棄)
                reader.Close();
            }
        }

        /// <summary>
        /// URL情報Txtの書き込み
        /// </summary>
        public void writeUrlInfoList()
        {
            string filePath = @ConfigurationManager.AppSettings["UrlInfoListPath"];
            StreamWriter sw = new StreamWriter(filePath, false, this.encod);

            foreach (UrlInfo urlInfo in this.UrlInfoList)
            {
                sw.WriteLine(urlInfo.Name + "," + urlInfo.Url + "," + urlInfo.IdFront);
            }
            sw.Close();
        }

        /// <summary>
        /// 2ちゃんURL情報Txtの読み込み
        /// </summary>
        public void loadUrl2ChInfoList()
        {
            if (System.IO.File.Exists(@ConfigurationManager.AppSettings["Url2ChInfoListPath"]))
            {

                // StreamReaderでファイルを読み込む
                System.IO.StreamReader reader = (new System.IO.StreamReader(@ConfigurationManager.AppSettings["Url2ChInfoListPath"], this.encod));

                // 読み込みできる文字がなくなるまで繰り返す
                while (reader.Peek() >= 0)
                {
                    // ファイルを 1 行ずつ読み込む
                    String line = reader.ReadLine();
                    if (line.Length != 0)
                    {
                        string[] stArrayData = line.Split(',');
                        if (2 <= stArrayData.Length)
                        {
                            Url2ChInfo url2ChInfo = new Url2ChInfo();
                            url2ChInfo.Name2Ch = stArrayData[0];
                            url2ChInfo.Url2Ch = stArrayData[1];
                            this.Url2ChInfoList.Add(url2ChInfo);
                        }
                    }
                }

                // 閉じる (オブジェクトの破棄)
                reader.Close();
            }
        }

        /// <summary>
        /// 2ちゃんURL情報Txtの書き込み
        /// </summary>
        public void writeUrl2ChInfoList()
        {
            string filePath = @ConfigurationManager.AppSettings["Url2ChInfoListPath"];
            StreamWriter sw = new StreamWriter(filePath, false, this.encod);

            foreach (Url2ChInfo url2ChInfo in this.Url2ChInfoList)
            {
                sw.WriteLine(url2ChInfo.Name2Ch + "," + url2ChInfo.Url2Ch);
            }
            sw.Close();
        }

        /// <summary>
        /// HTMLの書き込み
        /// </summary>
        public void writeHtml()
        {
            string filePath = @ConfigurationManager.AppSettings["OutPutHtmlPath"];
            StreamWriter sw = new StreamWriter(filePath, false, this.encod);
            sw.WriteLine("<Html>");
            sw.WriteLine("<Head>");
            sw.WriteLine("<Title>解析一覧</Title>");
            sw.WriteLine("</Head>");
            sw.WriteLine("<Body>");
            foreach (Url2ChInfo url2ChInfo in this.Url2ChInfoList)
            {
                sw.WriteLine("☆★☆★☆"+ url2ChInfo.Name2Ch + "★☆★☆★");
                sw.WriteLine("<table border=1>");
                sw.WriteLine("<tr><th>Url</th><th>日時</th></tr>");
                List<HtmlAnalysisResult> resultList = this.GetHtml(url2ChInfo.Url2Ch);
                foreach (HtmlAnalysisResult result in resultList)
                {
                    Boolean initFlag = true;
                    foreach (String url in result.Url)
                    {
                        if (initFlag)
                        {
                            sw.WriteLine("<tr>");
                            sw.WriteLine("<td><a href=\"" + url + "\" target=\"_blank\">" + url + "</a></td>");
                            sw.WriteLine("<td rowspan=" + result.Url.Count + ">" + result.Date + "</td>");
                            sw.WriteLine("</tr>");
                            initFlag = false;
                        }
                        else
                        {
                            sw.WriteLine("<tr><td><a href=\"" + url + "\" target=\"_blank\">" + url + "</a></td></tr>");
                        }
                    }
                }
                sw.WriteLine("</table>");
            }
            sw.WriteLine("</Body>");
            sw.WriteLine("</Html>");
            sw.Close();
        }

        /// <summary>
        /// 引数urlにアクセスした際に取得できるHTMLを返します。
        /// </summary>
        /// <param name="url">URL(アドレス)</param>
        /// <returns>取得したHTML</returns>
        private List<HtmlAnalysisResult> GetHtml(string url)
        {
            // 指定されたURLに対してのRequestを作成します。
            var req = (HttpWebRequest)WebRequest.Create(url);

            // html取得
            List<HtmlAnalysisResult> resultList = new List<HtmlAnalysisResult>();

            // 指定したURLに対してReqestを投げてResponseを取得します。
            using (var res = (HttpWebResponse)req.GetResponse())
            using (var resSt = res.GetResponseStream())
            // 取得した文字列をUTF8でエンコードします。
            using (var sr = new StreamReader(resSt, Encoding.GetEncoding("Shift_JIS")))
            {
                while (sr.Peek() >= 0)
                {
                    String line = sr.ReadLine();
                    //　前方一致タグチェック
                    if (line.StartsWith("<dt>"))
                    {
                        // <dd>タグ以降の文字列を抜き出し、識別文字が含まれているかチェック
                        String ddTagOrLater = this.GetDdTagEnclosedString(line);
                        if (this.CheckId(ddTagOrLater))
                        {

                            HtmlAnalysisResult result = new HtmlAnalysisResult();
                            // 日にちの抜き出し
                            result.Date = this.GetDayEnclosedString(line);
                            // Urlの抜き出し
                            result.Url = this.GetUrlEnclosedString(line);
                            resultList.Add(result);
                        }
                    }

                }
                // HTMLを取得する。
                //html = sr.ReadToEnd();
            }

            return resultList;
        }

        /// <summary>
        /// 文字列の中に識別文字が含まれているか確認
        /// 含まれている場合 true
        /// 含まれていない場合 false
        /// </summary>
        /// <param name="str">確認する文字列</param>
        /// <returns></returns>
        private bool CheckId(String str)
        {
            if ((str != String.Empty) && (str.Length != 0))
            {
                foreach (UrlInfo urlInfo in this.UrlInfoList)
                {
                    if (str.Contains(urlInfo.IdFront))
                    {
                        return true;
                    }
                }
            }

            return false;

        }

        /// <summary>
        /// "<dd>"タグ以降の文字列の抜き出し
        /// </summary>
        /// <param name="str">マッチングする文字列</param>
        /// <returns></returns>
        private string GetDdTagEnclosedString(string str)
        {
            Regex rgx = new Regex(@"<dd>.*", RegexOptions.IgnoreCase);
            MatchCollection matches = rgx.Matches(str);
            if (0 < matches.Count)
            {
                return matches[0].Value;
            }
            return String.Empty;
        }

        /// <summary>
        /// 文字列に含まれる日にちの抜き出し
        /// </summary>
        /// <param name="str">マッチングする文字列</param>
        /// <returns></returns>
        private string GetDayEnclosedString(string str)
        {
            Regex rgx = new Regex(@"\d\d\d\d/\d\d/\d\d(.*).*\d\d:\d\d:\d\d", RegexOptions.IgnoreCase);
            MatchCollection matches = rgx.Matches(str);
            if (0 < matches.Count)
            {
                return matches[0].Value;
            }
            return String.Empty;
        }

        /// <summary>
        /// 文字列に含まれるurlを抜き出す
        /// </summary>
        /// <param name="str">マッチングする文字列</param>
        /// <returns></returns>
        private List<String> GetUrlEnclosedString(string str)
        {
            List<String> urlList = new List<string>();
            foreach (UrlInfo urlInfo in this.UrlInfoList)
            {
                // 識別文字から閉じタグまでの文字列を抜き出す。
                Regex rgx = new Regex("(" + urlInfo.IdFront + ")(.*?)(<|\"|\\s)", RegexOptions.IgnoreCase);
                MatchCollection matches = rgx.Matches(str);
                if (0 < matches.Count)
                {
                    char[] tagTrim = { '<', ' ', '　', '"' };
                    foreach (Match match in matches)
                    {
                        urlList.Add(urlInfo.Url + match.Value.Trim(tagTrim));
                    }
                }
            }
            return urlList;
        }
        #endregion
    }

    #region URL情報クラス
    public class UrlInfo
    {
        private String _name;
        public String Name
        {
            get { return this._name; }
            set { this._name = value; }
        }

        private String _url;
        public String Url
        {
            get { return this._url; }
            set { this._url = value; }
        }

        private String _idFront;
        public String IdFront
        {
            get { return this._idFront; }
            set { this._idFront = value; }
        }
    }
    #endregion

    #region 2ちゃんURL情報クラス
    public class Url2ChInfo
    {
        private String _name2Ch;
        public String Name2Ch
        {
            get { return this._name2Ch; }
            set { this._name2Ch = value; }
        }

        private String _url2Ch;
        public String Url2Ch
        {
            get { return this._url2Ch; }
            set { this._url2Ch = value; }
        }
    }
    #endregion

    #region Html解析結果クラス
    public class HtmlAnalysisResult
    {

        /// <summary>
        /// URL
        /// </summary>
        private List<String> _url;
        public List<String> Url
        {
            get { return this._url; }
            set { this._url = value; }
        }

        /// <summary>
        /// 投稿日時
        /// </summary>
        private String _date;
        public String Date
        {
            get { return this._date; }
            set { this._date = value; }
        }
    }
    #endregion
}
