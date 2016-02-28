using GetMovieIn2ch.Base;
using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

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
        #endregion
    }

    #region URL情報クラス
    public class UrlInfo
    {
        private  String _name;
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
}
