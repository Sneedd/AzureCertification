
# Core architectural components of Azure 

## Azure accounts

* Azure account: Personal account
* Subscription: ??
* Resource groups: ??
* Resources: Service, Database, ...



## Azure physical infrastructure

Explore the Azure infrastructure in [Global infrastructure map](https://infrastructuremap.microsoft.com/).

* Datacenters: Dedicated power, cooling and network infrastructure
  * Not directly accessible

* Azure Availability Zone (AZ): Physically separate datacenters
  * Isolated from other AZs (own power, cooling and network)
  * IMPORTANT: **To ensure resiliency, a minimum of three separate availability zones are present in all availability zone-enabled regions. However, not all Azure Regions currently support availability zones.**

* Regions: Consists of one or more AZs


* Region pairs
  * IMPORTANT: **Not all Azure services automatically replicate data or automatically fall back from a failed region to cross-replicate to another enabled region. In these scenarios, recovery and replication must be configured by the customer.**
  * Are two regions near each other but so far away to provide reliable services.

* Sovereign regions
  * Are special regions isolated from the main Azure instances.
  * E.g. For governments



## Azure management infrastructure

* Azure resource: VMs, service, databases, virtual networks, etc.
* Azure resource groups: Grouping Azure resources
  * E.g.: When testing group all resources inside a resource group, on deletion all resources are also removed

* Azure subscriptions
  * Subscription types
    * Dev subscription
    * Test subscription
    * Production subscription
  * Boundaries
    * Billing boundary: How to be billed, creates separate billing reports
    * Access control boundary: Allow access for certain subscriptions to a team
  
* Create additional Azure subscriptions
  * Environments: E.g. development and testing
  * Organizational: Different teams get different subscriptions
  * Billing: Create different billing, note that costs are summed up on to the subscription level


### Azure management groups

* Structure
  * Resources are in resource groups
  * Resource groups are in subscriptions
  * Subscriptions are in management groups
  * Management groups are in management groups

