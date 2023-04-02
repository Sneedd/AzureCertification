# Use Azure Resource Manager

* <https://learn.microsoft.com/en-us/training/modules/use-azure-resource-manager/>

## Azure Resource Manager benefits

* All tools like Azure Portal, Azure CLI, etc. accesses the **Azure Resource Manager**.
* Allows to deploy, manager and monitro all resources
* Allows declarative templates (ARM Templates) to quickly setup resources.

### Guidance

* Prefer ARM Template than CLI commands
* Use only CLI Command for example to start/stop an machine
* Resource of the same lifecycle should in their group


## Azure resource terminology

* resource
* resource group 
* resource provider
* template
* declarative syntax


## Create resource groups

* Resources can only exist in one resource group.
* Resource Groups cannot be renamed.
* Resource Groups can have resources of many different types (services).
* Resource Groups can have resources from many different regions.


## Create Azure Resource Manager locks

* You can associate the lock with a subscription, resource group, or resource.
* Locks are inherited by child resources.

### Lock types

* Read-Only locks = which prevent any changes to the resource.
* Delete locks = which prevent deletion.


## Reorganize Azure resources

* **When moving** resources between subscriptions Azure **locks** the resource groups


### Limitations on moving

* See <https://learn.microsoft.com/en-us/azure/azure-resource-manager/management/move-support-resources>


## Remove resources and resource groups

* Use caution when deleting a resource group. Deleting a resource group deletes all the resources contained within it. 


## Determine resource limits

* In the subscription there are **Usage + quotas** which shows the limits of your subscription.
* Or allows to setup own limits up to the Azure limits: 
  * <https://learn.microsoft.com/en-us/azure/azure-resource-manager/management/azure-subscription-service-limits?toc=%2Fazure%2Fnetworking%2Ftoc.json>


