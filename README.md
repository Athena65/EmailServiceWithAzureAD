# EmailServiceWithAzureAD
Using Microsoft Graph to send email in .net 7
You need to sign in Azure and Register a new application. And Azure will give you some Essentials like "client ID" and "tenant ID" . These are important to use in .net
project in secret.json. To get there right click to your project and click "Manage User Secrets" . Where u type your "client ID" and "tenant ID" . For "clientSecret"
property you need to open "Certificates & secrets" section in your Azure App. And click to "New client secret" after typing random description the site give you 
"Value" for once and you can copy that and just paste it to the "clientSecret" property. And dont forget top add permission in "API permission" section to Mail.Send
type of Application and of course Grant admin consent for Default Directory. 
Note: "You have to have 0365 subscription if you dont, you can got to this 'https://admin.microsoft.com/AdminPortal/Home#/catalog' page and buy subscription" 
