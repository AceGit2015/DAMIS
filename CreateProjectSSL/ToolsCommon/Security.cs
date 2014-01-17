/******************************************************************************
 * 
 * Filename:  Security.cs
 * Description: 包含字符串的加密和解密
 * Author :  liangjw
 * Created Mark:  2011-08-18
 * E-mail： liangjw0504@163.com
 * Version:    V1.0.0.0
 * Company: ： Copyright (C) 2011 Create Family Wealth Power By Peter All Rights Reserved
 * Remark: 无
 * Update Author:   liangjw
 * Update Description: 增加了 只加密,不解密，密码安全性操作
 * Update Mark : getSHA1()一般在用户注册安全性要求不能进行破解，只加密操作。
 * 
*******************************************************************************/
using System;
using System.Security.Cryptography;
using System.IO;
using Microsoft.Win32;
using System.Text;
using System.Text.RegularExpressions;

/// <summary>
/// Security加密/解密类。
/// </summary>
public static class Security
{
    /// <summary>
    /// 只加密,不解密，密码安全性操作
    /// </summary>
    /// <param name="s"></param>
    /// <returns></returns>
    public static string getSHA1(this string s)
    {
        byte[] value = SHA1.Create().ComputeHash(Encoding.UTF8.GetBytes(s.ToString()));
        return BitConverter.ToString(value);
    }

    //密钥设置
    private static byte[] gDefault_DES_Keys = new byte[] { 42, 16, 93, 156, 78, 4, 218, 32 };
    private static byte[] gDefault_DES_IVs = new byte[] { 55, 103, 246, 79, 36, 99, 167, 3 };

    #region ========字符串加密========
    /// <summary>
    /// 字符串加密
    /// </summary>
    /// <param name="Text">获取需要加密的字符串</param>
    /// <returns></returns>
    public static string Encode(string source)
    {
        return Encode(source, gDefault_DES_Keys, gDefault_DES_IVs);
    }

    public static string Encode(string source, byte[] desKeys, byte[] desIVs)
    {
        if (source == "")
        {
            return "";
        }
        DESCryptoServiceProvider objDES = new DESCryptoServiceProvider();
        MemoryStream objMemoryStream = new MemoryStream();
        CryptoStream objCryptoStream = new CryptoStream(objMemoryStream, objDES.CreateEncryptor(desKeys, desIVs), CryptoStreamMode.Write);
        StreamWriter objStreamWriter = new StreamWriter(objCryptoStream);
        objStreamWriter.Write(source);
        objStreamWriter.Flush();
        objCryptoStream.FlushFinalBlock();
        objMemoryStream.Flush();
        return Convert.ToBase64String(objMemoryStream.GetBuffer(), 0, System.Convert.ToInt32(objMemoryStream.Length));
    }
    #endregion

    #region ========字符串解密========
    /// <summary>
    /// 字符串解密
    /// </summary>
    /// <param name="Text">获取需要解密的字符串</param>
    /// <returns></returns>
    public static string Decode(string source)
    {
        return Decode(source, gDefault_DES_Keys, gDefault_DES_IVs) as string;
    }

    public static object Decode(string source, byte[] desKeys, byte[] desIVs)
    {
        if (source == "")
        {
            return "";
        }
        DESCryptoServiceProvider objDES = new DESCryptoServiceProvider();
        byte[] arrInput = Convert.FromBase64String(source);
        MemoryStream objMemoryStream = new MemoryStream(arrInput);
        CryptoStream objCryptoStream = new CryptoStream(objMemoryStream, objDES.CreateDecryptor(desKeys, desIVs), CryptoStreamMode.Read);
        StreamReader objStreamReader = new StreamReader(objCryptoStream);
        return objStreamReader.ReadToEnd();
    }
    #endregion
}
