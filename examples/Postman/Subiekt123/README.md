# Jak skorzystać z rozwiązania

Importujemy pliki **Subiekt123.postman_collection.json** i **Subiekt123.postman_environment.json** do aplikacji Postman. 
Podmieniamy wartości: client_id, client_secret, subscription_key na te uzyskane w [poralu dewelopera](https://developers.insert.com.pl). 

Aby uzyskać token, otwieramy kolekcję **Subiekt123** i korzystamy z opcji **Get New Access Token**.
Otworzona zostanie przeglądarka, w której użytkownik przechodzi proces uwierzytelnienia oraz autoryzacji. 
Po pomyślnie zakończonym procesie zostaniemy przekierowani z powrotem do aplikacji Postman, w której należy skorzystać z opcji **Use Token**.
Od tego momentu możliwe jest działanie z API Subiekta 123.