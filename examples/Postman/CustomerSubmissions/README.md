# CustomerSubmissions postman example

Aby skorzystaæ z rozwi¹zania zaimportuj **CustomerSubmissions_dev.postman_collection.json** i **CustomerSubmissions_dev.postman_environment.json** do aplikacji Postman.
Podmieniamy wartoœæ subscription_key na tê uzyskan¹ w [poralu dewelopera](https://developers.insert.com.pl).

Po dodaniu nowego zg³oszenia klienta w odpowiedzi otzymujemy wartoœæ UrlIdentifier, któr¹ mo¿emy przypisaæ do zmiennej customersubmission_url_identifier.
Aby u¿ywaæ endpointów wymagaj¹cych zmiennej customersubmission_url_identifier, wymagane jest przypisanie wartoœci id zg³oszenia klienta do powy¿szej zmiennej, lub u¿ycie jej bezpoœrednio w adresie.