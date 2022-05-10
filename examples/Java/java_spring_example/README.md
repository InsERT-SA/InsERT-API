Przed uruchomieniem należy uzupełnić dane w klasie Properties, na podstawie danych uzyskanych po zarejestrowaniu aplikacji w portalu dewelopera InsERT API.
1. **CLIENT_ID**: Moje aplikacje -> [Twoja aplikacja] -> Client ID
2. **SECRET_ID**: Moje aplikacje -> [Twoja aplikacja] -> Client Secret
3. **MY_APPLICATION**: Moje aplikacje -> [Twoja aplikacja] -> Strona aplikacji
4. **SUBSCRIPTION_KEY**: Subskrypcje -> Subiekt 123 -> Klucz główny


 Uwagi
1. Na potrzeby tego przykładu, do przechowywania informacji o sesji, została użyta baza H2. 
Z tego względu w klasie _OAuth2LoginSecurityConfig_ został wyłączony **CSRF**. 
W rzeczywistym zastosowaniu zalecamy skorzystanie z innej bazy danych, np. Redis, MySQL itp. oraz korzystanie z CSRF.
2. W przypadku zmiany adresu **MY_APPLICATION** należy zmienić/usunąć port z pliku application.yml.