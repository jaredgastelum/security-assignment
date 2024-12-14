## Real World Example

At the end of 2023, the ResumeLooters hacker group used SQL injection to steal over 2 million user records from 65 websites. They mainly targeted recruitment and retail sites

## Steps Needed to Fix

- Identify all instances of string concatenation or interpolation in SQL queries
- Replace direct string operations with parameterized queries
- Update database access code to use ORM methods where possible
- Test the fixed endpoints with known SQL injection patterns

## Process and Tools to Prevent in My Project

- Security Code Scan (static code analysis for .NET)
- Update documentation to reflect secure coding practices
- Set up automated security scanning in CI/CD pipeline
