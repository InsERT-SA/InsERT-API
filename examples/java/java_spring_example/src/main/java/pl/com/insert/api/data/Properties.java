package pl.com.insert.api.data;

import org.springframework.beans.factory.annotation.Value;

public class Properties {

    private Properties() {
    }

    public static final String API_ADDRESS = "https://api.subiekt123.pl";
    public static final String MY_APPLICATION = "http://localhost:8081";
    public static final String REGISTRATION_ID = "devportal";
    public static final String CLIENT_ID = ""; /* do uzupełnienia */
    public static final String SECRET_ID = ""; /* do uzupełnienia */
    public static final String SUBSCRIPTION_KEY = ""; /* do uzupełnienia */
    public static final String CALLBACK_URI = MY_APPLICATION + "/callback";
    public static final String[] SCOPE = {"openid", "profile", "email", "subiekt123", "offline_access"};
    public static final String AUTHENTICATION_URL = "oauth2/authorization/" + REGISTRATION_ID;

    public static final String AUTH_URL = "https://kontoapi.chmura.insert.pl/connect/authorize";
    public static final String ACCESS_TOKEN_URL = "https://kontoapi.chmura.insert.pl/connect/token";
    public static final String JWK_SET_URI = "https://kontoapi.chmura.insert.pl/.well-known/openid-configuration/jwks";
    public static final String USER_INFO_URL = "https://kontoapi.chmura.insert.pl/connect/userinfo";
    public static final String USER_NAME_ATTRIBUTE = "email";
}
