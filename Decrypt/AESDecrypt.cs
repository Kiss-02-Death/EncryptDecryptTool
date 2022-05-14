using System.Text;
using System.Security.Cryptography;

namespace Decrypt
{
    public class AESDecrypt
    {
        public static byte[] Decrypt(byte[] Data, string password)
        {
            byte[] key = new byte[32]; // 采用32位密码加密
            Array.Copy(Encoding.UTF8.GetBytes(password.PadRight(key.Length)), key, key.Length);
            byte[] iv = new byte[16]; // 采用16位密钥向量
            Array.Copy(Encoding.UTF8.GetBytes(password.PadRight(iv.Length)), iv, iv.Length);

            byte[] decryptData;
            Aes aes = Aes.Create();

            try
            {
                using (MemoryStream memoryStream = new MemoryStream(Data))
                {
                    // 把内存流对象包装成解密流对象
                    using (CryptoStream decryptoStream = new CryptoStream(memoryStream, aes.CreateDecryptor(key, iv), CryptoStreamMode.Read))
                    {
                        // 明文存储区
                        using (MemoryStream originalMemory = new MemoryStream())
                        {
                            byte[] buffer = new byte[1024];
                            int readBytes = 0;
                            while ((readBytes = decryptoStream.Read(buffer, 0, buffer.Length)) > 0)
                            {
                                originalMemory.Write(buffer, 0, readBytes);
                            }
                            decryptData = originalMemory.ToArray();
                        }
                    }
                }
            }
            catch (Exception)
            {
                throw;
            }
            return decryptData;
        }
    }
}