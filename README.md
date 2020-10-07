---
page_type: sample
languages:
- csharp
products:
- azure-active-directory
description: "Sample for integrating External Identities self-service sign-up with experian identity verification using API connectors"
urlFragment: "active-directory-dotnet-external-identities-experian-identity-verification"
---

# Experian External Identities self-service sign-up API connector integration

Azure Active Directory (Azure AD) External Identities enable you to provide [self-service sign-up](https://docs.microsoft.com/azure/active-directory/b2b/self-service-sign-up-overview) for external users so that collaboration is seamless and end-user friendly. [API connectors](https://docs.microsoft.com/azure/active-directory/b2b/api-connectors-overview) enable you to leverage web APIs to integrate those self-service sign-up flows with external cloud systems.

Verifying a user's identity can be critical to securing an application from fraudulent and malicious actors and confidently allowing self-service sign-up. To accomplish this, you can use Experian's identity services including continuous and dynamic authentication, fraud risk analytics and identity verification capabilities  through the Experian CrossCore platform.

This integration asks the external user multiple details using a self-service sign-up and uses Experian to determine whether the user should be allowed to successfully sign-up or not. The following attributes are used in making a pass/fail decision:

- Given Name
- MiddleName
- Surname
- Street Address
- City
- State/Province
- Postal Code
- Country/Region
- PhoneNumber

## Contents

| File/folder       | Description                                |
|-------------------|--------------------------------------------|
| `/CrossCoreExtIdApi`             | Sample source code for custom web API.                        |
| `.gitignore`      | Define what to ignore at commit time.      |
| `CHANGELOG.md`    | List of changes to the sample.             |
| `CONTRIBUTING.md` | Guidelines for contributing to the sample. |
| `README.md`       | This README file.                          |
| `LICENSE`         | The license for the sample.                |

## Prerequisites

You must have an [Azure Active Directory tenant](https://docs.microsoft.com/azure/active-directory/develop/quickstart-create-new-tenant).

## Solution Components

The Experian integration is comprised of the following components:

- **Experian** -- A service that can be used to verify a user's identity using information provided by the user.
- **Azure AD External Identities self-service sign-up** - The way to allow external customers to sign-up as external users to your organization.
- **Custom web API** -- The provided API implements the integration
    between the Azure AD self-service sign-up user flow and the Experian service to perform identity verification on sign-up.
- **API connector** - Part of a self-service sign-up, allows you to connect the sign-up flow with the custom web API.

## Create an Experian account

When you are ready to get an Experian account, sign up using [this](https://www.experian.com/decision-analytics/account-opening-fraud/microsoft-integration) web form.

## Deploy the API

Deploy the provided API code to an Azure service. The code can be
published from Visual Studio, following these
[instructions](https://docs.microsoft.com/visualstudio/deployment/quickstart-deploy-to-azure?view=vs-2019).

Note the URL of the deployed service. This will be needed to configure the API connector with the required settings.

### Configure the API

Application settings can be [configured in the App service in
Azure](https://docs.microsoft.com/azure/app-service/configure-common#configure-app-settings).
This allows for settings to be securely configured without checking them
into a repository. The API needs the following settings provided:

  Application Setting Name         | Source                          |
  ---------------------------------| --------------------------------|
  CrossCore:TenantId               | Experian account configuration  |
  CrossCore:OrgCode                | Experian account configuration  |
  CrossCore:ApiEndpoint            | Experian account configuration  |
  CrossCore:ClientReference        | Experian account configuration  |
  CrossCore:ModelCode              | Experian account configuration  |
  CrossCore:HdrRequestType         | Experian account configuration  |
  CrossCore:OrgCode                | Experian account configuration  |
  CrossCore:SignatureKey           | Experian account configuration  |
  CrossCore:TenantId               | Experian account configuration  |
  CrossCore:CertificateThumbprint  | Experian certificate            |
  BasicAuth:ApiUsername            | Set a username for accessing the API.  |
  BasicAuth:ApiPassword            | Set a password for accessing the API.   |

## Integrate the API with External Identities self-service sign-up
Azure AD needs to be configured for use with external identities. 

### Configure a self-service sign-up user flow
[Create a self-service sign-up user flow](https://docs.microsoft.com/azure/active-directory/b2b/self-service-sign-up-user-flow) for registering external users to your tenant.

Before you create the user flow, [create the custom attributes](https://docs.microsoft.com/azure/active-directory/b2b/user-flow-add-custom-attributes) that Experian uses to to verify an identity:
- MiddleName
- PhoneNumber

When creating the user flow, the following must be selected under **User Attributes* in order to collect the relevant information from the user:

- PhoneNumber
- MiddleName
- Given Name
- Postal Code
- Street Address
- State/Province
- Surname
- City
- Country/Region

<!-- <img src="media/user_attributes.png" alt="API connector configuration"
    title="API connector configuration" width="700" /> -->

### Create an API Connector

After the Azure AD tenant has been configured for use with External
Identities self-service sign-up, [create an API connector](https://docs.microsoft.com/azure/active-directory/b2b/self-service-sign-up-add-api-connector#create-an-api-connector)

- **Display Name**: Choose a name such as 'Verify identity with Experian'.
- **Endpoint URL**: Use the URL created when publishing the API service.
- **Username**: Username defined in the API configuration above (BasicAuth:ApiUsername)
- **Password**: Password defined in the API configuration above (BasicAuth:ApiPassword)

<!-- The API connector configuration should look like the following:

<img src="media/api-connector-config-Experian.png" alt="API connector configuration"
    title="API connector configuration" width="400" /> -->

### Enable the API connector in the user flow

Enable the API connector for the user flow. Navigate to **User flows (Preview)**, click the user flow you created, and click on **API connectors**. From here, click on the drop-down menu for **Before creating the user** and select the API connector (e.g. 'Verify identity with Experian').

<!-- <img src="media/api-connector-enable-in-user-flow.png" alt="API connector configuration"
    title="API connector configuration" width="700" /> -->

## End user experience

Your self-service sign-up user flow should now be calling the API when a user signs up. The API uses the Experian service to verify an account. If the user cannot be verified, the user will be shown an error message and asked to review their personal information.

<!-- <img src="media/end-user-experience.png" alt="API connector configuration"
    title="API connector configuration" width="700" /> -->

## Contributing

This project welcomes contributions and suggestions.  Most contributions require you to agree to a
Contributor License Agreement (CLA) declaring that you have the right to, and actually do, grant us
the rights to use your contribution. For details, visit https://cla.opensource.microsoft.com.

When you submit a pull request, a CLA bot will automatically determine whether you need to provide
a CLA and decorate the PR appropriately (e.g., status check, comment). Simply follow the instructions
provided by the bot. You will only need to do this once across all repos using our CLA.

This project has adopted the [Microsoft Open Source Code of Conduct](https://opensource.microsoft.com/codeofconduct/).
For more information see the [Code of Conduct FAQ](https://opensource.microsoft.com/codeofconduct/faq/) or
contact [opencode@microsoft.com](mailto:opencode@microsoft.com) with any additional questions or comments.