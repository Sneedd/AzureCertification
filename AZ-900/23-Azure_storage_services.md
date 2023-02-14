# Azure storage services

* <https://learn.microsoft.com/en-us/training/modules/describe-azure-storage-services/2-accounts>


## Azure storage redundancy

* <https://learn.microsoft.com/en-us/training/modules/describe-azure-storage-services/3-redundancy>

* Azure Storage always stores multiple copies of the data
  * Always replicated three times in the primary region

* **Primary regions** in Azure storage can be written
* **Secondary regions** in Azure storage can only be read

* Recovery point objective (RPO): Point in time in which the data can be recovered, typically 15 min need the data to be replicated.


### Redundancy in the primary region

* Locally redundant storage (LRS): Provided over a single data center, lowest cost, 11 nines
* Zone-redundant storage (ZRS): Provided over Availablity Zones in the region, 12 nines


### Redundancy in a secondary region

* Geo-redundant storage (GRS): Provided over regions within a datacenter with a primary and secondary region, 16 nines
* Geo-zone-redundant storage (GZRS): Combination ob GRS and ZRS (ZRS only in the primary region). Best option, 16 nines 

* The following options also give **always** read access to the other physical locations:
  * Read-access geo-redundant storage (RA-GRS) 
  * Read-access geo-zone-redundant storage (RA-GZRS)


## Benefits of Azure Storage

* Durable and highly available: Automatic redundancy
* Secure: All data is encrypted
* Scalable
* Managed: Azure handles hardware
* Accessible: Everywhere accessible 


## Blob storage

* Object storage for text or binary data
* Best for
  * Images or documents
  * Files 
  * Streaming video and audio
  * Store backups
  * Store analysis data

### Accessing blob storage

* Anywhere around the world via HTTP(S)


### Blob storage tiers

* Hot access tier: Optimized for frequently used data
* Cold access tier: Infrequently used, stored for at least 30 days
* Archive access tier: Rarely used, stored for at least 180 days

* TODO: Why? At least 30 / 180 days?


## Azure Files

* Offers SMB or NFS protocols to access file shares


## Queue storage

* Storing large number of messages
* Each message con be up to 64 KB in size
* Could be used to trigger Azure Functions


## Disk storage

* Managed disks for Azure VMs


## Azure Migrate

* Helps with migrate on-premises to the cloud.


### Integrated tools

* Azure Migrate - Discovery and assessment: Checks on-premises servers for migrations
* Azure Migrate - Server Migration: Migrate VMs, physical servers, etc.
* Data Migration Assistant: Checks SQL Server migration
* Azure Database Migration Service: Migrate on-premise databases to Azure
* Web app migration assistant: Checks on-premises websites 
* Azure Data Box: Used to move large amounts of offline data, max 80 TBytes, can also export data


## AzCopy

* Commandline utility to copy blobs or files


## Azure Storage Explorer 

* Standalone app with a UI to manage files and blobs in storage account


## Azure File Sync 

* Syncs bi-directionally with a on-premise file server















