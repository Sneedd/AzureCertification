# Azure identity, access, and security

* <https://learn.microsoft.com/en-us/training/modules/describe-azure-identity-access-security/2-directory-services>


## Azure AD

* Authentication
* Single-sign-on
* Application management: Cloud or on-premise apps could use the AD to authenticate against an app
* Device management: E.g. conditional access for certain devices


### Azure AD connect

* Allows connect your on-premise AD with the Azure AD


### Azure AD DS (Active Directory Domain Services)

* Allows to use applications which used a on-premise AD to have backward compatibility 

* Domain join
* Group Policy
* LDAP
* Kerberos

* Integrates with existing Azure AD
* The DCs (Domain Controllers) are handled by Azure

* Performs only a one-way synchronization from Azure AD to Azure AD DS



## Azure authentication methods

* Standard password
* SSO 
* MFA
* Passwordless 
  * Windows Hello for Business
  * Microsoft Authenticator app
  * FIDO2 security keys


## Azure external identities

* External identity = person, device, etc. that is outside your organization
* Managed with Azure AD or Azure AD B2C
* Capabilities 
  * Business to business (B2B) collaboration: Using external identities to login your applications
  * B2B direct connect: Mutual two way trust
  * Azure AD business to customer: Using Azure AD B2C for identity for custom apps (SaaS)


## Azure conditional access

* Giving allow or deny access to resources based on identity

* Helps to allow users from where ever access to software 
* Helps to protect assets

* Allows also granular multi-factor authentication
  * E.g. in certain locations the user does not need a MFA

* Conditional Access
  * Require MFA
  * Access only with approved clients
  * Access only with approved managed devices
  * Block untrusted sources


## Azure role-based access control (RBAC)

* Role-based access control to resources
* Least-privilege principle = only grant access to what someone need
* Provides build-in roles with rules
* Allows to define your own rules
* Each role has access permissions

### How to apply

* Applies to scope (Management group, Subscription, Resource group or resource)
* Role (Reader, Resource-specific, Custom, Contributor, Owner)
* Roles on a higher scope will grant access to child scopes

### How RBAC is enforced

* Roles are enforced through Resource Manager
* `Resource Manager` service to organize and secure cloud resources
* RBAC does not have roles for application or data
* RBAC uses allow model = meaning roles are merged from top to bottom

## Zero trust

* Zero trust assumes the worst case scenario
* Guidelines 
  * Verify explicitly = Always authenticate and authorize
  * Lest privilege access = Limit user with Just-In-Time and Just-Enought-Access
  * Assume breach = Reduce blast radius


### Adjusting to Zero Trust

* Flip the approach
  * Classic approach = Everything is secure in your network
  * Zero trust = Assume that you cannot trust your network and protect your assets with a central policy

## Defense-in-depth

* Defense-in-depth means that every layer protects the other layer with the last is your data
* If one layer is breached the other is still protecting the next

* Layers (Top to bottom - data)
  * Physical security layer = protect hardware; though  building access
  * Identity and access layer = controls access with identity and roles; logs events
  * Perimeter layer = protects against DDoS
  * Network layer = limits communication between resources; deny by default
  * Compute layer = Secures VMs; Access control; Endpoint protection; and patched systems
  * Application layer = Secures application; applications have no security vulnerabilities; careful with secrets; Security by design
  * Data layer = Secures data


## Microsoft Defender for Cloud

* Monitoring tool for cloud, on-premises, hybrid and multi-cloud environments
* Protections
  * Azure PaaS services
  * Azure data services
  * Networks 

* Azure Arc = bridges Azure cloud with other multi-cloud environments
  * Together with Microsoft Defender allowing also enhance security there

* Features
  * Continuously assess = Identify and track vulnerabilities
  * Secure = Harden resources with Azure Security Benchmark
  * Defend = Detect and resolve threads

* Policies of Defender are build on to of Azure Policies

* Azure Security Benchmark = provides recommendations for security

* Security alerts = can describe details, suggest steps and provides triggers

* Advanced thread protection = 






