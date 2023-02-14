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

* 