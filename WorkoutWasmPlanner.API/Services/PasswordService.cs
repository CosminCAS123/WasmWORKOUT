using System;
using System.Security.Cryptography;
using System.Text;
using System.Threading.Tasks;

public class PasswordService
{


    public async Task<string> HashPasswordAsync(string password)
    {
        using (SHA256 sha256 = SHA256.Create())
        {
            byte[] passwordBytes = Encoding.UTF8.GetBytes(password);
            byte[] hashBytes = await Task.Run(() => sha256.ComputeHash(passwordBytes));
            return Convert.ToBase64String(hashBytes);
        }
    }

    public async Task<bool> VerifyPasswordAsync(string enteredPassword, string storedPassword)
    {
        string enteredPasswordHash = await HashPasswordAsync(enteredPassword);
        return enteredPasswordHash == storedPassword;
    }
}
