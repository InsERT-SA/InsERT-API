# CustomerSubmissions postman example

Aby skorzysta� z rozwi�zania zaimportuj **CustomerSubmissions_dev.postman_collection.json** i **CustomerSubmissions_dev.postman_environment.json** do aplikacji Postman.
Podmieniamy warto�� subscription_key na t� uzyskan� w [poralu dewelopera](https://developers.insert.com.pl).

Po dodaniu nowego zg�oszenia klienta w odpowiedzi otzymujemy warto�� UrlIdentifier, kt�r� mo�emy przypisa� do zmiennej customersubmission_url_identifier.
Aby u�ywa� endpoint�w wymagaj�cych zmiennej customersubmission_url_identifier, wymagane jest przypisanie warto�ci id zg�oszenia klienta do powy�szej zmiennej, lub u�ycie jej bezpo�rednio w adresie.