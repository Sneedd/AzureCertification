# Cost management in Azure 


## Factors that can affect costs in Azure

* The costs of a on-premise where you need buy and maintain your hardware = Capital expense = CapEx

* When using the cloud you pay as you go without a high starting expense = Operational expense = OpEx

* Impacting cost factor for Azure
  * Resource type: Depending on the resource there are costs for licenses or costs how much they are used
  * Consumption: Pay only what you consume; also `reserve` can be used to save money, when a resource workload is consistent
  * Maintenance: Resources on demand
  * Geography: Different countries have different costs (e.g. salaries)
  * Subscription type: Azure subscription type differs in costs
  * Azure Marketplace: Third-party vendor licenses affects costs



## Compare the Pricing and Total Cost of Ownership calculators

* <https://learn.microsoft.com/en-us/training/modules/describe-cost-management-azure/3-compare-pricing-total-cost-of-ownership-calculators>



### Pricing calculator

* When using resources the pricing calculator provides an information about costs
* Prices are only estimated
* <https://azure.microsoft.com/en-us/pricing/calculator/>


### TCO calculator

* Allows to compare costs of on-premise vs. Azure cloud
* <https://azure.microsoft.com/en-us/pricing/tco/>



## Azure Cost Management tool

* Tool to check Azure resource costs
* Shows spend and dugets

* Cost analysis provides visuals

* Cost alerts (e.g. Email)
  * Budget alerts = Notifies when cost >= defined amount
  * Credit alerts = Notifies when credit commitments are consumed
  * Department spending quota alerts = when a team reaches a threshold

* Budgets
  * Set spending limit 
  * Set on subscriptions, resource groups, etc


## Purpose of tags

* Way to organize resources
* Allows to locate resource
* Allows to group resource costs
* Allows to group resource priority (e.g. critical availability)
* Allows to group by security level
* Allows to identify regulatory and compliance
* Allow visualize resources in complex deployments

* Can be added through the Windows PowerShell, Azure CLI, Azure Resource Manager Templates, REST API or Portal




