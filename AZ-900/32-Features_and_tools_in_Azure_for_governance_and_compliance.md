# Features and tools in Azure for governance and compliance

## Azure Blueprints

* Standardize cloud subscriptions and deployments
* Assign blueprint definition to a scope (Management group, subscription, resource group, ...)

### Artifacts

* Component in a blueprint definition is an artifact
* Artifacts can contain zero or more parameters

* Includes definition like
  * Role assignments
  * Policy assignments
  * Azure Resource Manager templates
  * Resource groups


### Monitor deployments

* Blueprints are version-able
* Blueprints definition = what should be deployed
* Blueprint assignment = what was deployed


## Azure Policy

* Ensures that resources are compliant

### Define Azure Policies

* Allows to define ...
  * individual policies
  * group of related policies = initiatives

* Policy highlights resources which are not compliant
* Policies can be applied to resource, resource groups, subscriptions, etc
* Azure Policies are inherited from a higher level
* Monitors current VMs in the environment (even the VMs which are created before)
* Integrates with DevOps (e.g. pipeline policies)

* Example Policies
  * Certain VM sizes
  * Must have tag with name

## Azure policy initiatives

* Can group policies
* Example initiative: "Enable Monitoring in Azure Security Center"
  * Monitors unencrypted SQL Database in Security Center
  * Monitors OS vulnerabilities in Security Center
  * Monitors missing Endpoint Protection in Security Center



## Resource locks

* Because of the risk that a user changes or deletes a resource accidentally a resource lock can be used
* Two types of resource locks
  * Delete = cannot delete
  * ReadOnly = cannot delete or modify

* Locks can be set in Azure portal, PowerShell, Azure CLI or Azure Resource Manager

* To change again the resource the lock must be first removed



## Service trust portal

* Contains information about security, privacy and compliance practices
* Example: GDPR - (European) General data protection regulation










   