using Google.Apis.Auth.OAuth2;
using Google.Apis.Services;
using Google.Apis.Sheets.v4;
using Google.Apis.Sheets.v4.Data;
using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;

namespace XuatHoaDonAurora
{
    class GoogleSheetsHelper
    {
        private static readonly string[] Scopes = { SheetsService.Scope.Spreadsheets };
        private const string ApplicationName = "XuatHoaDonAurora";
        private readonly SheetsService _service;
        private readonly string _spreadsheetId;

        public GoogleSheetsHelper(string credentialsPath, string spreadsheetId)
        {
            GoogleCredential credential;
            using (var stream = new FileStream(credentialsPath, FileMode.Open, FileAccess.Read))
            {
                credential = GoogleCredential.FromStream(stream).CreateScoped(Scopes);
            }

            _service = new SheetsService(new BaseClientService.Initializer()
            {
                HttpClientInitializer = credential,
                ApplicationName = ApplicationName,
            });

            _spreadsheetId = spreadsheetId;
        }

        public IList<IList<object>> ReadSheet(string range)
        {
            var request = _service.Spreadsheets.Values.Get(_spreadsheetId, range);
            var response = request.Execute();
            return response.Values;
        }

        public void WriteSheet(string range, IList<IList<object>> values)
        {
            var valueRange = new ValueRange
            {
                Values = values
            };

            var updateRequest = _service.Spreadsheets.Values.Update(valueRange, _spreadsheetId, range);
            updateRequest.ValueInputOption = SpreadsheetsResource.ValuesResource.UpdateRequest.ValueInputOptionEnum.RAW;
            updateRequest.Execute();
        }
        public bool SheetExists(string sheetName)
        {
            var spreadsheet = _service.Spreadsheets.Get(_spreadsheetId).Execute();
            return spreadsheet.Sheets.Any(sheet => sheet.Properties.Title == sheetName);
        }

        public void CreateSheet(string sheetName)
        {
            var addSheetRequest = new AddSheetRequest
            {
                Properties = new SheetProperties
                {
                    Title = sheetName
                }
            };

            var batchUpdateRequest = new BatchUpdateSpreadsheetRequest
            {
                Requests = new List<Request>
            {
            new Request { AddSheet = addSheetRequest }
                }
                    };

                    _service.Spreadsheets.BatchUpdate(batchUpdateRequest, _spreadsheetId).Execute();
                }
        public void InsertRowAtTop(string sheetName, IList<object> newRow)
        {
            // Đọc toàn bộ dữ liệu hiện có
            var range = $"{sheetName}!A1:Z";
            var data = ReadSheet(range) ?? new List<IList<object>>();

            // Thêm hàng mới vào đầu danh sách
            data.Insert(0, newRow);

            // Ghi lại toàn bộ dữ liệu vào sheet
            WriteSheet($"{sheetName}!A1", data);
        }
    }
}
