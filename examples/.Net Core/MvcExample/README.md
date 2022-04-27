# How to run solution

In **appsettings.json** file change **"\<set in user secrets>"** values with those retrieved from [developers portal](https://developers.insert.com.pl). To do that you can right click on **MvcExample** project and select **Manage User Secrets** and in the window that will appear add below json:

``` json
{
  "InsertApiOptions": {
    "ClientId": "[Your client id]",
    "ClientSecret": "[Your client secret]"
  },
  "Subiekt123ApiOptions": {
    "SubscriptionKey": "[Your subscription id]"
  }
}
```

or just edit **appsettings.json**

``` json
...

"InsertApiOptions": {
    "Authority": "https://kontoapi.chmura.insert.pl",
    "Issuer": "https://kontoapi.chmura.insert.pl",
    "ClientId": "<set in user secrets>",
    "ClientSecret": "<set in user secrets>",
    "ResponseType": "code",
    "Scopes": [
      "openid",
      "profile",
      "email",
      "offline_access",
      "subiekt123"
    ]
  },

...

"Subiekt123ApiOptions": {
    "Url": "https://api.subiekt123.pl",
    "SubscriptionKey": "<set in user secrets>"
  }

...
```
