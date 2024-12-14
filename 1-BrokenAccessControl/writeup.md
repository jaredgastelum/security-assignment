## Real World Example

- In November 2024, the Helldown ransomware group exploited CVE-2024-42057, which was a command injection vulnerability in Zyxel firewalls' IPSec VPN. They were able to breach 31 organizations' networks

## Steps Needed to Fix

- Implement proper authorization checks:
  - Use the [Authorize] attribute to make sure only authenticated users can access the endpoint.
  - Implement a custom authorization policy to verify that the requesting user has the right to access the info.
- Modify the endpoint to include authorization logic:
  - Implement the custom authorization policy
  - Register the authorization policy in the Startup.cs file

## Process and Tools to Prevent in My Project

- Implement the principle of least privilege throughout the application architecture.
- Implement role-based access control (RBAC) consistently across the application.
- Do regular security code reviews focusing on access control mechanisms.
- Regularly do penetration testing to identify and address access control weaknesses.
- Use security headers like Content Security Policy (CSP) to prevent unauthorized access to resources.
