## Real World Example

- The Verkada breach in 2021 occurred when hackers found hardcoded super admin credentials in an exposed internal development system, leading to unauthorized access of customer camera footage

## Steps Needed to Fix

- Remove plain text password storage from User model
- Implement password complexity requirements
- Add password hashing service using a strong algorithm (like Argon2, PBKDF2, or BCrypt)
- Add input validation for all user fields
- Remove sensitive data from response objects

## Process and Tools to Prevent in My Project

- Use Security Code Scan for static analysis
- Implement OWASP ASVS guidelines for credential handling
- Use .NET Identity framework for built-in security features
- Perform regular security audits using automated tools
- Implement proper logging without exposing sensitive data
