using System;
using System.IO;
using System.Security.Cryptography;
using System.Text;

namespace Security
{
    public class SecurityDecoder
    {
        public static string DescriptografarArquivo(string caminhoArquivo, byte[] chaveDescriptografia)
        {
            try
            {
                byte[] conteudoCriptografado = File.ReadAllBytes(caminhoArquivo);

                using (Aes aesAlg = Aes.Create())
                {
                    aesAlg.Key = chaveDescriptografia;
                    aesAlg.IV = new byte[16];

                    ICryptoTransform decryptor = aesAlg.CreateDecryptor(aesAlg.Key, aesAlg.IV);

                    using (MemoryStream msDecrypt = new MemoryStream(conteudoCriptografado))

                    {
                        using (CryptoStream csDecrypt = new CryptoStream(msDecrypt, decryptor, CryptoStreamMode.Read))
                        {
                            using (StreamReader reader = new StreamReader(csDecrypt))
                            {
                                string conteudoDecifrado = reader.ReadToEnd();
                                return conteudoDecifrado;
                            }
                        }
                    }
                }
            }
            catch (Exception ex)
            {
                return "Ocorreu um erro ao ler e decifrar o arquivo: " + ex.Message;
            }
        }
    }
}