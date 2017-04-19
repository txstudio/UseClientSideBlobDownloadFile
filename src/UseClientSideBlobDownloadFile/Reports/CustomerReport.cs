using Microsoft.AspNetCore.Hosting;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading;
using System.Threading.Tasks;

namespace UseClientSideBlobDownloadFile
{
    public class CustomerReport
    {
        const int sleepSecond = 5;

        private readonly IHostingEnvironment _enviroment;
        private readonly FileStorage _storage;

        public CustomerReport(IHostingEnvironment enviroment)
        {
            this._enviroment = enviroment;

            this._storage = new FileStorage(this._enviroment);
        }


        /// <summary>取得 PDF 格式的報表</summary>
        public FileContent GetPdf(CustomerReportQuery query)
        {
            FileContent _content = new FileContent();

            var _buffer = this._storage.GetDocument();

            _content.content = _buffer;
            _content.filename = string.Format("{0:yyyyMMdd}-{1:yyyyMMdd}.pdf"
                                                , query.DateStart
                                                , query.DateEnd);

            //刻意模擬資料處理的等候時間
            this.Process();

            return _content;
        }

        /// <summary>模擬資料處理過程</summary>
        private void Process()
        {
            Thread.Sleep(sleepSecond * 1000);
        }

        /// <summary>預設查詢物件</summary>
        public CustomerReportQuery DefaultQuery()
        {
            DateTime _currentDate;
            CustomerReportQuery _query;

            _currentDate = DateTime.Now;
            _query = new CustomerReportQuery();

            _query.DateStart = _currentDate.AddMonths(-3).Date;
            _query.DateEnd = _currentDate.AddMonths(-2).Date;

            return _query;
        }
    }
}
