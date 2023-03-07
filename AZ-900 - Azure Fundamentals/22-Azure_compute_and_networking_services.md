# Azure compute and networking services

## Scale definitions

* Scale out => more machines
* Scale in  => less machines

* Scale up  => more hardware power
* Scale down => less hardware power


## Azure Virtual Machines

* Total control over the OS


### Scale VMs in Azure

* Virtual machine scale sets: Identical, load-balanced VMs

* Virtual machine availability sets: Highly available environment
  * Update domain: On update, only one update group will be offline at a time
  * Fault domain: Protects against failure

* Examples of when to use VMs 
  * During testing and development
  * When running applications in the cloud


## Azure Virtual Desktop

* Remote Desktop over the Cloud
* Centralized security
  * With MFA and RBACs


## Azure Containers

* Docker compatible container technology


## Azure Functions

* Function to create small programs
* Serverless (meaning no management of platform or infrastructure)
* Functions scale automatically on demand
* Only charged for CPU time
* Can be stateless or stateful (durable functions)


## Azure App Service (Web App)

* Automatic scaling
* Automated deployments from GitHub, Azure DevOps or other Git repos
* Choosing between Windows or Linux
* Supports
  * Web apps: Hosting a web app using ASP.NET Core, etc
  * API apps: REST-based web APIs
  * WebJobs: Normally used to run background tasks
  * Mobile apps: Backend for mobile apps


## Azure Virtual Networking

* Allows communication between ...
  * resources, 
  * users on the internet or 
  * on-premise client computers.

* Public endpoints: Public IP which can be accessed from anywhere
* Private endpoints: Can be accessed only within the virtual network

* All resources have by default internet access


### Isolation and segmentation

* Isolation: The IP range of the virtual network exists only within the virtual network
* Segmentation: The IP address space can be dived into subnets


### Internet communications

* After assigning a public IP address to an Azure resource the resource can be accessed over the internet


### Communicate between Azure resources

* Over virtual networks
* Service endpoints: allow link multiple Azure resources => more security
  * TODO: But why? <https://learn.microsoft.com/en-us/training/modules/describe-azure-compute-networking-services/8-virtual-network>


### Communicate with on-premise resources 

* Point-to-site: Connect a single computer outside of Azure to connect with the virtual network
* Site-to-site: Links a VPN device or gateway to the Azure VPN Gateway
* Azure ExpressRoute: Dedicated private connection that does not use the internet


### Route network traffic

* Route tables: define how traffic should be directed
* Border Gateway Protocol (BGP) works with Azure VPN, Azure Route Server or Azure ExpressRoute


### Filter network traffic

* Filters traffic between subnets
* Network security groups: Are Azure resources which contain security rules
* Network virtual appliances: Runs a firewall or optimizes WAN


### Connect virtual networks

* Virtual network peering to link virtual networks


## Azure Virtual Private Networks

### VPN gateways

* Connect virtual network with on-premise networks over a site-2-site connection
* Connect individual devices through point-to-site connections

* Policy based: Specifies rules where which packet is going 
* Route based: Preferred von on-premise devices


### High-availability scenarios

* Active/standby: (default) having a second connection if first is not reachable
* Active/active: Allow two always active connections
* ExpressRoute failover: Uses a VPN when ExpressRoute fails
* Zone-redundant gateways: Allow redundant ExpressRoute gateways and VPN gateways


## Azure ExpressRoute

* Connectivity to Microsoft cloud services: Allows certain services to be accessed directly (E.g. Office 265, ...)
* Global connectivity: Allowing two on-premise networks to communicate globally over a local Express route 
* Dynamic routing
* Built-in redundancy


### ExpressRoute connectivity models

* Co-location at a cloud exchange: Your datacenter which is physically co-located
* Point-to-point Ethernet connection
* Any-to-any networks: Use your WAN 
* Directly from ExpressRoute sites: Special sites which allow connections


### Security considerations

* Does not use public internet 


## Azure DNS

* Reliability and performance
* Security
* Ease of use
* Customizable virtual networks with private domains
* Alias records