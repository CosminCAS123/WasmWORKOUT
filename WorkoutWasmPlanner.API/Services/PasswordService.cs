using System;
using System.Security.Cryptography;
using System.Text;
using System.Threading.Tasks;

public class PasswordService
{
    private const int SaltSize = 16; // 128-bit

    // Hash the password with a salt (asynchronous)
    public async Task<string> HashPasswordAsync(string password)
    {
        return await Task.Run(() =>
        {
            // Generate a salt using RandomNumberGenerator (recommended in .NET 6+)
            var salt = new byte[SaltSize];
            RandomNumberGenerator.Fill(salt);

            using (var sha256 = SHA256.Create())
            {
                var saltedPassword = Combine(salt, Encoding.UTF8.GetBytes(password));
                var hash = sha256.ComputeHash(saltedPassword);

                // Combine the salt and the hash
                var hashBytes = Combine(salt, hash);
                return Convert.ToBase64String(hashBytes);
            }
        });
    }

    // Verify if the password entered matches the stored hash
    public async Task<bool> VerifyPasswordAsync(string enteredPassword, string storedHashedPassword)
    {
        return await Task.Run(() =>
        {
            var hashBytes = Convert.FromBase64String(storedHashedPassword);

            // Extract the salt from the stored hash
            var salt = new byte[SaltSize];
            Array.Copy(hashBytes, 0, salt, 0, SaltSize);

            // Hash the input password with the extracted salt
            using (var sha256 = SHA256.Create())
            {
                var saltedPassword = Combine(salt, Encoding.UTF8.GetBytes(enteredPassword));
                var hash = sha256.ComputeHash(saltedPassword);

                // Compare the stored hash with the computed hash
                for (int i = 0; i < hash.Length; i++)
                {
                    if (hashBytes[i + SaltSize] != hash[i])
                        return false;
                }

                return true;
            }
        });
    }

    // Helper function to combine salt and hash
    private static byte[] Combine(byte[] first, byte[] second)
    {
        var combined = new byte[first.Length + second.Length];
        Buffer.BlockCopy(first, 0, combined, 0, first.Length);
        Buffer.BlockCopy(second, 0, combined, first.Length, second.Length);
        return combined;
    }
}
