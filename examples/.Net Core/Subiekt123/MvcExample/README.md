# Jak skorzystać z rozwiązania

W pliku **appsettings.json** zmień wartości **"\<set in user secrets>"**  na te uzyskane w [portalu dewelopera](https://developers.insert.com.pl). 
Aby podmienieć wartości można skorzystać z opcji **Manage User Secrets** w Visual Studio. 
W tym celu kilkamy prawym przyciskiem myszy na projekt **MvcExample** i wybranie z menu kontekstowego **Manage User Secrets**. 
W oknie które się otworzy dodajemy poniższy json:

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

Możliwe jest również wyedytowanie pliku **appsettings.json**

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
