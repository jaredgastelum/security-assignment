## Real World Example

- In April 2022, the Hive ransomware group exploited ProxyShell vulnerability in Microsoft Exchange Server, using pass-the-hash techniques to steal NTLM hashes and deploy ransomware

## Steps Needed to Fix

- Use Security Code Scan static analyzer to detect cryptographic issues
- Implement OWASP ASVS cryptographic requirements in your CI/CD pipeline
- Use dependency scanning to detect outdated cryptographic packages
- Configure .NET's built-in security analyzers

## Process and Tools to Prevent in My Project

- The fix uses ASP.NET Core Identity's password hasher which:
  - Implements PBKDF2 with proper iteration count
  - Automatically handles salt generation
  - Uses cryptographically secure random number generation
