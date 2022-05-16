package pl.com.insert.api.utils;

import org.springframework.security.core.Authentication;

public class AuthenticationUtil {

    public static boolean isAuthenticated(Authentication authentication) {
        return authentication!=null && authentication.isAuthenticated();
    }
}
