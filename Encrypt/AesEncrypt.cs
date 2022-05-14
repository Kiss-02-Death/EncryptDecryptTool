using System.Text;
using System.Security.Cryptography;

namespace Encrypt
{
    public class AESEncrypt
    {

        public static byte[] Encrypt(byte[] Data, string password)
        {
            byte[] key = new byte[32]; // 采用32位密码加密
            Array.Copy(Encoding.UTF8.GetBytes(password.PadRight(key.Length)), key, key.Length);
            byte[] iv = new byte[16]; // 采用16位密钥向量
            Array.Copy(Encoding.UTF8.GetBytes(password.PadRight(iv.Length)), iv, iv.Length);

            byte[] encryptData;
            Aes aes = Aes.Create();

            try
            {
                using (MemoryStream memoryStream = new MemoryStream())
                {
                    // 把内存流对象包装成加密流对象
                    using (CryptoStream encryptoStream = new CryptoStream(memoryStream, aes.CreateEncryptor(key, iv), CryptoStreamMode.Write))
                    {
                        encryptoStream.Write(Data, 0, Data.Length);
                        encryptoStream.FlushFinalBlock();
                        encryptData = memoryStream.ToArray();
                    }
                }
            }
            catch (Exception)
            {
                throw;
            }
            return encryptData;
        }
    }
}