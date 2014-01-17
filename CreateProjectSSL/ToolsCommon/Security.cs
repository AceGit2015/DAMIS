/******************************************************************************
 * 
 * Filename:  Security.cs
 * Description: �����ַ����ļ��ܺͽ���
 * Author :  liangjw
 * Created Mark:  2011-08-18
 * E-mail�� liangjw0504@163.com
 * Version:    V1.0.0.0
 * Company: �� Copyright (C) 2011 Create Family Wealth Power By Peter All Rights Reserved
 * Remark: ��
 * Update Author:   liangjw
 * Update Description: ������ ֻ����,�����ܣ����밲ȫ�Բ���
 * Update Mark : getSHA1()һ�����û�ע�ᰲȫ��Ҫ���ܽ����ƽ⣬ֻ���ܲ�����
 * 
*******************************************************************************/
using System;
using System.Security.Cryptography;
using System.IO;
using Microsoft.Win32;
using System.Text;
using System.Text.RegularExpressions;

/// <summary>
/// Security����/�����ࡣ
/// </summary>
public static class Security
{
    /// <summary>
    /// ֻ����,�����ܣ����밲ȫ�Բ���
    /// </summary>
    /// <param name="s"></param>
    /// <returns></returns>
    public static string getSHA1(this string s)
    {
        byte[] value = SHA1.Create().ComputeHash(Encoding.UTF8.GetBytes(s.ToString()));
        return BitConverter.ToString(value);
    }

    //��Կ����
    private static byte[] gDefault_DES_Keys = new byte[] { 42, 16, 93, 156, 78, 4, 218, 32 };
    private static byte[] gDefault_DES_IVs = new byte[] { 55, 103, 246, 79, 36, 99, 167, 3 };

    #region ========�ַ�������========
    /// <summary>
    /// �ַ�������
    /// </summary>
    /// <param name="Text">��ȡ��Ҫ���ܵ��ַ���</param>
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

    #region ========�ַ�������========
    /// <summary>
    /// �ַ�������
    /// </summary>
    /// <param name="Text">��ȡ��Ҫ���ܵ��ַ���</param>
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
