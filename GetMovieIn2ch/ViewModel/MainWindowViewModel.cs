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
            UrlInfo u1 = new UrlInfo();
            u1.Name = "test1";
            u1.Url = "http://www";
            u1.IdFront = "sm";
            this.UrlInfoList.Add(u1);
        }
        #endregion

        private String _addUrl;
        public String AddUrl
        {
            get { return this._addUrl; }
            set { this.SetProperty(ref this._addUrl, value); }
        }

        private ObservableCollection<UrlInfo> _urlInfoList;
        public ObservableCollection<UrlInfo> UrlInfoList
        {
            get { return this._urlInfoList; }
            set { this.SetProperty(ref this._urlInfoList, value); }
        }
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
}
