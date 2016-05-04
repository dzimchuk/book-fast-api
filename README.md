# book-fast-api

Facility management and accommodation booking API app protected by Azure AD.

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
		"TenantId": "<Your Azure AD tenant ID>"
	}
},
"Search": {
	"QueryKey": "<Your Azure Search service's query key>",
	"AdminKey": "<Your Azure Search service's admin key>",
	"ServiceName": "<Your Azure Search service name>",
	"IndexName": "<Your Azure Search index name>"
}
```

## Database setup

BookFast.Data project contains the necessary EF migrations to provision the database.