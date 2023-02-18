# Features and tools for managing and deploying Azure resources

## Tools for interacting with Azure
* <https://learn.microsoft.com/en-us/training/modules/describe-features-tools-manage-deploy-azure-resources/2-describe-interacting-azure>

* Azure Portal = web-based console
* Azure Cloud Shell = web-based shell with Azure PowerShell or Azure CLI (Bash)

* Azure PowerShell = usable over the Cloud Shell; can also be installed on Win, Linux and Mac
* Azure CLI (Bash) = usable over the Cloud Shell; can also be installed on Win, Linux and Mac


## Azure ARC

* Using the ARC allows to extend Azure compliance and monitoring in hybrid and multi-cloud environments

* Allows to manage the following resource types hosted outside of Azure
  * Servers
  * Kubernetes clusters
  * Azure data services
  * SQL Server
  * Virtual machines


## Azure Resource Manager (ARM) and ARM templates

* Allows to create, update and delete resources in Azure
* It is always involved when you change resources


### Benefits

* Manage infrastructure through declarative templates
* Deploy, manage and monitor resources as a group
* Re-deploy your solution in the same state
* Define dependencies between resources
* Apply access control to services 
  * RBAC is integrated
* Apply resource locks
* Apply tags to resources
* Clarify organization billing


### ARM Templates

* Is a JSON description of how to deploy resources 
* Including execution of PowerShell or Bash scripts (before or after a resource is set up)

#### Benefits

* Declarative syntax
* Repeatable results = every deployment is the same
* Orchestration = Create in correct order and if possible parallel
* Modular files = Files can be broken into smaller pieces
* Extensibility = Through scripts
