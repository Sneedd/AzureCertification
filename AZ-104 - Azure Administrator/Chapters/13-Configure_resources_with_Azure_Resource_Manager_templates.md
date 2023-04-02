# Configure resources with Azure Resource Manager templates

* <https://learn.microsoft.com/en-us/training/modules/configure-resources-arm-templates/?ns-enrollment-type=learningpath&ns-enrollment-id=learn.az104-admin-prerequisites>

* Azure Resource Manager templates are idempotent means, \
  **when executing a template a second time the resource manager does not make any changes.**
* Azure Resource Manager templates = Infrastructure as Code

## Azure Resource Manager template advantages

* Templates improve consistency
* Templates help express complex deployments
* Templates reduce manual
* Templates are code
* Templates promote reuse
* Templates are linkable
* Templates simplify orchestration


## Azure Resource Manager template schema

* parameters - Allows input
* variables - Variables to simplify expressions
* functions - User-defined functions
* resources = (required) Resources to deploy
* outputs = Values returned after deployment


## Bicep templates

* Alternate to ARM templates
* See <https://learn.microsoft.com/en-us/azure/azure-resource-manager/bicep/overview>
* Will be converted into JSON templates and then executed
* Syntax is much simpler
* Allows separation in modules (files)


## QuickStart templates

* Are templates provided by the Azure community.



