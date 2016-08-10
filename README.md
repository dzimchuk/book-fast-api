# book-fast-api

Multitenant facility management and accommodation booking API app protected by Azure AD.

## Configuration

Use environment variables, user-secrets or appsettings.json to configure the project.

```
"Data": {
	"DefaultConnection": {
		"ConnectionString": "<connection string>"
	}
},
"Authentication": {
	"AzureAd": {
		"Audience": "<BookFast API AppId in Azure AD>",
		"Instance": "<Your Azure AD instance, e.g. https://login.microsoftonline.com/>",
		"ValidIssuers": "Comma separated list of tenant identifiers, e.g. https://sts.windows.net/490789ec-b183-4ba5-97cf-e69ec8870130/,https://sts.windows.net/f418e7eb-0dcd-40be-9b81-c58c87c57d9a/",
		"B2C": {
        	"Instance": "",
        	"TenantId": "",
        	"Audience": "",
        	"Policy": ""
      	}
	}
},
"Azure": {
    "Storage": {
      "ConnectionString": ""
    },
    "Search": {
      "QueryKey": "<Your Azure Search service's query key>",
	  "AdminKey": "<Your Azure Search service's admin key>",
      "ServiceName": "<Your Azure Search service name>",
	  "IndexName": "<Your Azure Search index name>"
    }
  }
```

## Database setup

BookFast.Data project contains the necessary EF migrations to provision the database.