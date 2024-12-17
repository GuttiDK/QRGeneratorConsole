using System.Linq;
using System;
using System.Text;

namespace QRGeneratorProject.QRCode
{
    public class DataEncoding
    {
        public string Encode(string data)
        {
            if (IsNumeric(data))
                return EncodeNumeric(data);
            if (IsAlphanumeric(data))
                return EncodeAlphanumeric(data);
            return EncodeBinary(data);
        }

        private bool IsNumeric(string data) => int.TryParse(data, out _);

        private bool IsAlphanumeric(string data)
        {
            const string charset = "0123456789ABCDEFGHIJKLMNOPQRSTUVWXYZ $%*+-./:";
            foreach (char c in data)
                if (!charset.Contains(c)) return false;
            return true;
        }

        private string EncodeNumeric(string data)
        {
            StringBuilder binary = new StringBuilder();
            for (int i = 0; i < data.Length; i += 3)
            {
                string segment = data.Substring(i, Math.Min(3, data.Length - i));
                binary.Append(Convert.ToString(int.Parse(segment), 2).PadLeft(segment.Length * 3 + 1, '0'));
            }
            return binary.ToString();
        }

        private string EncodeAlphanumeric(string data)
        {
            const string charset = "0123456789ABCDEFGHIJKLMNOPQRSTUVWXYZ $%*+-./:";
            StringBuilder binary = new StringBuilder();
            for (int i = 0; i < data.Length; i += 2)
            {
                int value = charset.IndexOf(data[i]) * 45;
                if (i + 1 < data.Length)
                    value += charset.IndexOf(data[i + 1]);
                binary.Append(Convert.ToString(value, 2).PadLeft(11, '0'));
            }
            return binary.ToString();
        }

        private string EncodeBinary(string data)
        {
            StringBuilder binary = new StringBuilder();
            foreach (char c in data)
                binary.Append(Convert.ToString((int)c, 2).PadLeft(8, '0'));
            return binary.ToString();
        }
    }
}
