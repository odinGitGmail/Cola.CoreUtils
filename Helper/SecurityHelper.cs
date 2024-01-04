using System.Security.Cryptography;
using System.Text;
using Cola.CoreUtils.Enums;
using Cola.CoreUtils.Extensions;

namespace Cola.CoreUtils.Helper;

public class SecurityHelper
{
    /// <summary>
    ///     AES加密算法
    /// </summary>
    /// <param name="input">明文字符串</param>
    /// <param name="key">密钥（32位）</param>
    /// <param name="aesAi">加密偏移量</param>
    /// <returns>字符串</returns>
    public static string EncryptByAes(string input, string? key = null, string? aesAi = null)
    {
        byte[]? keyBytes = null;
        byte[]? aiBytes = null;
        if (key != null && !key.StringIsNullOrEmpty() && key.Length != 32)
            throw new Exception(EnumException.EncryptByAesX01.GetDescription());
        if (!aesAi.StringIsNullOrEmpty() && key.StringIsNullOrEmpty())
            throw new Exception(EnumException.EncryptByAesX02.GetDescription());
        if (aesAi != null && !aesAi.IsNormalized() && aesAi.Length != 16)
            throw new Exception(EnumException.EncryptByAesX03.GetDescription());
        if (!key.StringIsNullOrEmpty())
            keyBytes = Encoding.UTF8.GetBytes(key?.Substring(0, 32) ?? string.Empty);
        if (!aesAi.StringIsNullOrEmpty())
            aiBytes = Encoding.UTF8.GetBytes(aesAi?.Substring(0, 16) ?? string.Empty);
        using var aesAlg = Aes.Create();
        if (keyBytes != null)
            aesAlg.Key = keyBytes;
        if (aiBytes != null)
            aesAlg.IV = aiBytes;
        ICryptoTransform? encryptor = null;
        if (key.StringIsNullOrEmpty())
            encryptor = aesAlg.CreateEncryptor();
        else
            encryptor = aesAlg.CreateEncryptor(aesAlg.Key, aesAlg.IV);
        using var msEncrypt = new MemoryStream();
        using var csEncrypt = new CryptoStream(msEncrypt, encryptor, CryptoStreamMode.Write);
        using var swEncrypt = new StreamWriter(csEncrypt);
        swEncrypt.Write(input);
        var bytes = msEncrypt.ToArray();
        return bytes.ConvertByteArrayToHexString();
    }

    /// <summary>
    ///     AES解密
    /// </summary>
    /// <param name="input">密文字节数组</param>
    /// <param name="key">密钥（32位）</param>
    /// <param name="aesAi">加密偏移量</param>
    /// <returns>返回解密后的字符串</returns>
    public static string DecryptByAes(string input, string? key = null, string? aesAi = null)
    {
        byte[]? keyBytes = null;
        byte[]? aiBytes = null;
        if (key != null && !key.StringIsNullOrEmpty() && key.Length != 32)
            throw new Exception(EnumException.DecryptByAesX01.GetDescription());
        if (!aesAi.StringIsNullOrEmpty() && key.StringIsNullOrEmpty())
            throw new Exception(EnumException.DecryptByAesX02.GetDescription());
        if (aesAi != null && !aesAi.IsNormalized() && aesAi.Length != 16)
            throw new Exception(EnumException.DecryptByAesX03.GetDescription());
        if (!key.StringIsNullOrEmpty())
            keyBytes = Encoding.UTF8.GetBytes(key?.Substring(0, 32) ?? string.Empty);
        if (!aesAi.StringIsNullOrEmpty())
            aiBytes = Encoding.UTF8.GetBytes(aesAi?.Substring(0, 16) ?? string.Empty);
        var inputBytes = input.ConvertHexStringToByteArray();
        using var aesAlg = Aes.Create();
        if (keyBytes != null)
            aesAlg.Key = keyBytes;
        if (aiBytes != null)
            aesAlg.IV = aiBytes;
        ICryptoTransform? decryptor = null;
        if (key.StringIsNullOrEmpty())
            decryptor = aesAlg.CreateDecryptor();
        else
            decryptor = aesAlg.CreateDecryptor(aesAlg.Key, aesAlg.IV);
        using (var msEncrypt = new MemoryStream(inputBytes))
        {
            using (var csEncrypt = new CryptoStream(msEncrypt, decryptor, CryptoStreamMode.Read))
            {
                using (var srEncrypt = new StreamReader(csEncrypt))
                {
                    return srEncrypt.ReadToEnd();
                }
            }
        }
    }
}