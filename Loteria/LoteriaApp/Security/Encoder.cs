using System;
using System.Collections.Generic;
using System.IO;
using System.Security.Cryptography;
using System.Text;

namespace Security
{
    public class SecurityEncoder
    {
        public static void CriptografarArquivo(string caminhoArquivo, List<string> conteudo, byte[] chaveCriptografia)
        {
            using (Aes aesAlg = Aes.Create())
            {
                aesAlg.Key = chaveCriptografia;
                aesAlg.IV = new byte[16];

                ICryptoTransform encryptor = aesAlg.CreateEncryptor(aesAlg.Key, aesAlg.IV);

                using (MemoryStream msEncrypt = new MemoryStream())
                {
                    using (CryptoStream csEncrypt = new CryptoStream(msEncrypt, encryptor, CryptoStreamMode.Write))
                    {
                        using (StreamWriter writer = new StreamWriter(csEncrypt))
                        {
                            foreach (var linha in conteudo)
                            {
                                writer.WriteLine(linha);
                            }
                        }
                    }

                    File.WriteAllBytes(caminhoArquivo, msEncrypt.ToArray());
                }
            }
        }
    }
}