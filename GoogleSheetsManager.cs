using System;
using System.Collections.Generic;
using System.IO;

namespace XuatHoaDonAurora
{
    public class GoogleSheetsManager
    {
        static string credentialsPath = Path.GetFullPath(@"C:\Datas\crendentials.json"); // Đường dẫn tới file JSON tải về
        static string spreadsheetId = "1qolBrFZsvfZWk54nozo7_Hlz56GCL9yuT8YAx1_WNkU"; // ID của Google Sheet (lấy từ URL)
        //static string spreadsheetId = "1si87_KViUedIlwLhPtp6WECL0MBsLfpeQAjy-sexc4Q"; // ID của Google Sheet (lấy từ URL)
        public static void AddHoaDonInSheets(string maHD, string date, string time, string finalMoney, TypeBank typeBank, string jsonData)
        {
            try
            {
                var sheetsHelper = new GoogleSheetsHelper(credentialsPath, spreadsheetId);
                string nameSheet = $"T{date.Split('/')[1]}/{date.Split('/')[2]}";
                if (!sheetsHelper.SheetExists(nameSheet))
                {
                    sheetsHelper.CreateSheet(nameSheet);
                    Console.WriteLine($"Sheet '{nameSheet}' đã được tạo.");
                }
                else
                {
                    Console.WriteLine($"Sheet '{nameSheet}' đã tồn tại.");
                }

                var newRow = new List<object> { maHD, date, time, typeBank.ToString().Split('_')[0], finalMoney, jsonData };
                sheetsHelper.InsertRowAtTop(nameSheet, newRow);
            }
            catch
            {
                Console.WriteLine("Lỗi khi thêm hóa đơn vào Google Sheets.");
            }


        }
    }
}
