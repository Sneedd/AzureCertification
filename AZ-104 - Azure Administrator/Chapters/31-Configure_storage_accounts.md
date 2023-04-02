# Configure storage accounts

* <https://learn.microsoft.com/en-us/training/modules/configure-storage-accounts/>


## Implement Azure Storage

* Virtual machine data
* Unstructured data
* Structured data


### Storage account tiers

* Standard = simple HDD, slower and cheaper
* Premium = SSDs, lower latency 


### Things to consider when using Azure Storage

* Consider durability and availability
* Consider secure access
* Consider scalability
* Consider manageability
* Consider data accessibility


## Explore Azure Storage services

* Azure Blob Storage = Object storage for image, documents, etc.
* Azure Files = Network Shares / SMB or NFS
* Azure Queue Storage = For Messages like message queue
* Azure Table Storage = Table (is now part of Azure Cosmos DB)
* Azure Page Blobs = Collection of 512-byte pages (e.g. data disks, etc)


### Things to consider when choosing Azure Storage services

* Consider storage optimization for massive data = Azure Blob Storage
* Consider storage with high availability = Azure Files supports highly available network file shares. 
* Consider storage for messages = Azure Queue Storage
* Consider storage for structured data = Storage is ideal for storing structured, non-relational data


## Determine storage account types

* Standard general-purpose v2	= All 4 services
* Premium block blobs	= Only Blob Storage
* Premium file shares	= Azure Files	only
* Premium page blobs = Page blobs only


## Determine replication strategies

* Locally redundant storage (LRS)
* Zone redundant storage (ZRS)
* Geo-redundant storage (GRS)
* Geo-zone-redundant storage (GZRS)


## Access storage

* Container service	<https://mystorageaccount.blob.core.windows.net>
* Table service	<https://mystorageaccount.table.core.windows.net>
* Queue service	<https://mystorageaccount.queue.core.windows.net>
* File service	<https://mystorageaccount.file.core.windows.net>


### Configure custom domains

* **Azure Store does not support HTTPS with custom domains**


## Secure storage endpoints

* From All Networks
* From Selected virtual networks and IP addresses
* Disabled



