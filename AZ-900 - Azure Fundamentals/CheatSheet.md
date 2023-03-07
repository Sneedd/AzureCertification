# CheatSheet

## Glossary

* Predictability (`Vorhersehbarkeit`): Performance and costs are predictable
* Governance (`Kontrolle, Beherschung`): ??
* Availability (`Verfügbarkeit`): Uptime
  * General availability
* Scalability: Handle demand
  * Vertical: Hardware
  * Horizontal: Machines
* Reliability: Failure recovery
* Durability: Disaster recovery
* ??


## Azure VM

* Scale Sets = Demand-depended scaling of VMs \
  <https://learn.microsoft.com/en-US/azure/virtual-machine-scale-sets/overview>

* Availability sets = Grouping of VMs for redundancy and availability \ 
  <https://learn.microsoft.com/en-us/azure/virtual-machines/availability-set-overview>

## Azure Virtual Network

* Virtual Networking Peering = Connecting 2+ Virual Networks \
  <https://learn.microsoft.com/en-us/azure/virtual-network/virtual-network-peering-overview>


## Azure Storage

* Elastic Pools = Scale of Azure SQL Database for unpredictable demands. \
  <https://learn.microsoft.com/en-us/azure/azure-sql/database/elastic-pool-overview?view=azuresql>


## Azure Security

* Network security groups = Package firewall (`Deny all` at the end) \
  <https://learn.microsoft.com/en-us/azure/virtual-network/network-security-groups-overview>

* Azure Policy = Allow all, deny all ????

* Azure Policy initiatives = Grouping for policy definitions \
  <https://learn.microsoft.com/en-us/azure/governance/policy/concepts/initiative-definition-structure>


## Azure Monitor

* Resource Health = Provides information about outage, etc. \
  <https://learn.microsoft.com/en-us/training/modules/describe-monitoring-tools-azure/3-describe-azure-service-health>

* Activity logs = Access and change log for subscription-level events (found under subscriptions).
  <https://learn.microsoft.com/en-us/azure/azure-monitor/essentials/activity-log?tabs=powershell>


## Azure Subscriptions

* Service Level Agreement (SLA) \
  TODO


## Azure Machine Learning

* Azure Machine Learning Studio = Tool to create ML-models and analyze results \
  <https://learn.microsoft.com/de-de/azure/machine-learning/overview-what-is-azure-machine-learning>
  <
  <https://ml.azure.com/>

* Azure Cognitive Services = Cloud-based AU services (like speech recognition, etc.) \
  <https://learn.microsoft.com/en-us/azure/cognitive-services/what-are-cognitive-services>
  

## Other / TODOs

* Azure Arc = Service to connect Azure, other Cloud Provider or on-premise environments \
  <https://learn.microsoft.com/en-us/azure/azure-arc/overview>


### Evolution

* On-Premise: Buy your own hardware
  * Highest start costs
* Dedicated: Rent a machine
  * High start costs
  * Limited to OS
* VMs: Rent a VM on a machine
  * Hypervisor
* Container: 
  * Docker
* Functions:
  * Server-less compute


### Availability zones

* Zonal services: Specific zone
* Zone redundant services: replicates automatically accoss zones
* Non-regional services: ??

* Region: Min 400 miles away
  * Availability zones: Have their own infrastructure