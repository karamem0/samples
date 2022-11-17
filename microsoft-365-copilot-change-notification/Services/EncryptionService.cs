//
// Copyright (c) 2011-2026 karamem0
//
// This software is released under the MIT License.
//
// https://github.com/karamem0/samples/blob/main/LICENSE
//

using System.Security.Cryptography;
using System.Security.Cryptography.X509Certificates;

namespace Karamem0.SampleApplication.Services;

public interface IEncryptionService
{

    Task<BinaryData> DecryptResourceDataAsync(BinaryData key, BinaryData data);

    Task<BinaryData> DecryptSymmetricKeyAsync(BinaryData key);

    Task<bool> ValidateSignatureAsync(
        BinaryData key,
        BinaryData payload,
        BinaryData expected
    );

}

public class EncryptionService : IEncryptionService
{

    public async Task<BinaryData> DecryptResourceDataAsync(BinaryData key, BinaryData data)
    {
        var aes = Aes.Create();
        aes.Key = key.ToArray();
        aes.Padding = PaddingMode.PKCS7;
        aes.Mode = CipherMode.CBC;
        var iv = new byte[16];
        Array.Copy(
            key.ToArray(),
            iv,
            iv.Length
        );
        aes.IV = iv;
        using var decryptor = aes.CreateDecryptor();
        using var memoryStream = new MemoryStream(data.ToArray());
        using var cryptoStream = new CryptoStream(
            memoryStream,
            decryptor,
            CryptoStreamMode.Read
        );
        using var streamReader = new StreamReader(cryptoStream);
        return BinaryData.FromString(
            await streamReader
                .ReadToEndAsync()
                .ConfigureAwait(false)
        );
    }

    public Task<BinaryData> DecryptSymmetricKeyAsync(BinaryData key)
    {
        return Task.Run(() =>
            {
                var certificate = X509Certificate2.CreateFromPemFile(Constants.CrtPemPath, Constants.KeyPemPath);
                var rsa = certificate.GetRSAPrivateKey();
                _ = rsa ?? throw new InvalidOperationException();
                return BinaryData.FromBytes(rsa.Decrypt(key.ToArray(), RSAEncryptionPadding.OaepSHA1));
            }
        );
    }

    public Task<bool> ValidateSignatureAsync(
        BinaryData key,
        BinaryData data,
        BinaryData expected
    )
    {
        return Task.Run(() =>
            {
                using var hmac = new HMACSHA256(key.ToArray());
                var actual = hmac.ComputeHash(data.ToArray());
                return actual.SequenceEqual(expected.ToArray());
            }
        );
    }

}
