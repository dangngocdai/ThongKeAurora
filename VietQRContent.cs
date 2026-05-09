using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace XuatHoaDonAurora
{
    public class VietQRContent
    {
        private const string templateVietcombank = "0002010102123857" +
                             "0010A000000727" +
                             "0127000697043601" +
                             "13KINHMATAURORA" +
                             "0208QRIBFTTA" +
                             "5303704" +
                             "54{0}" + // Số tiền (định dạng 54 + độ dài + số tiền + 00)
                             "5802VN" +
                             "62{2}08{1}" +
                             "6304"; // CRC
        private const string templateTPBankNguyenNgocTrien =
                             "0002010102123855" +
                             "0010A000000727" +
                             "0125000697042301" +
                             "1188830101998" +
                             "0208QRIBFTTA" +
                             "5303704" +
                             "54{0}" + // Số tiền (định dạng 54 + độ dài + số tiền + 00)
                             "5802VN" +
                             "62{2}08{1}" +
                             "6304"; // CRC
        //0002010102123855/0010A000000727/0125000697042301/1188830101998/0208QRIBFTTA/5303704/54/06/100000/5802VN/620908/05A1111/6304/E4C0
        private const string templateVPBankDangNgocVien = "0002010102123854" +
                             "0010A000000727" +
                             "0124000697043201" +
                             "100985909968" +
                             "0208QRIBFTTA" +
                             "5303704" +
                             "54{0}" + // Số tiền (định dạng 54 + độ dài + số tiền + 00)
                             "5802VN" +
                             "62{2}08{1}" +
                             "6304"; // CRC
        //0002010102123854/0010A000000727/0124000697043201/100985909968/0208QRIBFTTA/5303704/54/06/100000/5802VN/62/09/08/05A1111/63049A92
        public static string GenerateVietQRContent(decimal amount, string content, TypeBank bankType)
        {
            string template;
            switch (bankType)
            {
                //case TypeBank.Vietcombank_PhamThiHue:
                //    template = templateVietcombank;
                //    break;
                case TypeBank.TPBank_NguyenNgocTrien:
                    template = templateTPBankNguyenNgocTrien;
                    break;
                case TypeBank.VPBank_DangNgocVien:
                    template = templateVPBankDangNgocVien;
                    break;
                default:
                    throw new ArgumentException("Loại ngân hàng không hợp lệ.");
            }
    
            string formattedAmount = amount.ToString("F0").Replace(".", "").Replace(",", "");
            //0002010102123854/0010A000000727/0124000697043601/10/1056311628/0208QRIBFTTA/5303704/54/06/100000/5802VN/620708/03/dai/6304/DF04
            //0002010102123857/0010A000000727/0127000697043601/13/KINHMATAURORA/0208QRIBFTTA/5303704/54/05/50000/5802VN/62/11/08/07/daidzai/6304/D646
            //0002010102123857/0010A000000727/0127000697043601/13/KINHMATAURORA/0208QRIBFTTA/5303704/54/06/150000/5802VN/62/1408/10/daidzaivcl/6304/F5ED
            //0002010102123857/0010A000000727/0127000697043601/13/KINHMATAURORA/0208QRIBFTTA/5303704/54/06/400000/5802VN/62/1408/05/A0013/6304/E95E

            //0002010102123857/0010A000000727/0127000697043601/13/KINHMATAURORA/0208QRIBFTTA/5303704/54/05/50000/5802VN/62/14/08/07/daidzai6304/FEB0
            //0002010102123857/0010A000000727/0127000697043601/13/KINHMATAURORA/0208QRIBFTTA/5303704/54/05/50000/5802VN/62/11/08/07/daidzai6304/D646
            //0002010102123857/0010A000000727/0127000697043601/13/KINHMATAURORA/0208QRIBFTTA/5303704/54/06/432000/5802VN/62/09/08/05/A0014/6304/0AA9
            string contentInput = content.Length.ToString("D2") + content;
            string qrContent = string.Format(template,
                                            formattedAmount.Length.ToString("D2") + formattedAmount,
                                            contentInput, (contentInput.Length+2).ToString("D2"));

            // Tính CRC (bạn cần thêm hàm tính CRC16)
            qrContent += CalculateCRC16(qrContent);

            return qrContent;
        }
        private static string CalculateCRC16(string data)
        {
            // Đa thức CRC-16/CCITT-FALSE: 0x1021 (x^16 + x^12 + x^5 + 1)
            const ushort polynomial = 0x1021;
            ushort crc = 0xFFFF; // Giá trị khởi tạo

            byte[] bytes = System.Text.Encoding.ASCII.GetBytes(data);

            foreach (byte b in bytes)
            {
                crc ^= (ushort)(b << 8);
                for (int i = 0; i < 8; i++)
                {
                    if ((crc & 0x8000) != 0)
                        crc = (ushort)((crc << 1) ^ polynomial);
                    else
                        crc <<= 1;
                }
            }

            return crc.ToString("X4"); // Trả về 4 ký tự hex, viết hoa
        }
    }
}
