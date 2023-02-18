# Monitoring tools in Azure

## Azure Advisor

* Makes recommendations to improve ...
  * Reliability = improve that apps are running
  * Security = detect threads and vulnerabilities
  * Performance = improve speed of applications
  * Operation excellence = deployment best practices
  * Costs = optimize and reduce costs



## Azure Service Health

* Gets the status of your resources and Azure infrastructure

* Three different services
  * Azure status = Azure globally status
  * Service health = Azure services and regions
  * Resource health = Health of individual cloud resources


## Azure Monitor

* Collecting data fro resources
* Analyses this data and visualize it

* Metrics are stored in central repositories


### Azure Log Analytics

* Allows to write and run queries on the metrics data gathered by Azure Monitor


### Azure Monitor Alerts

* Informs about exceeding thresholds
* Depending on configuration ... an action can be defined to correct


### Application Insights

* Monitors web applications
* Allows monitoring also in Azure, on-premise or different cloud providers

* Monitors
  * Request rates, response times and failure rates
  * Page views and load performance
  * AJAX calls from web pages
  * User and session counts
  * Performance counters