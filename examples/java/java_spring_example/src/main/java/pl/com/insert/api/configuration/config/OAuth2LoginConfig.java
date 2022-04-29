package pl.com.insert.api.configuration.config;

import org.springframework.context.annotation.Bean;
import org.springframework.context.annotation.Configuration;
import org.springframework.security.oauth2.client.OAuth2AuthorizedClientManager;
import org.springframework.security.oauth2.client.OAuth2AuthorizedClientProvider;
import org.springframework.security.oauth2.client.OAuth2AuthorizedClientProviderBuilder;
import org.springframework.security.oauth2.client.endpoint.DefaultRefreshTokenTokenResponseClient;
import org.springframework.security.oauth2.client.registration.ClientRegistration;
import org.springframework.security.oauth2.client.registration.ClientRegistrationRepository;
import org.springframework.security.oauth2.client.registration.InMemoryClientRegistrationRepository;
import org.springframework.security.oauth2.client.web.DefaultOAuth2AuthorizedClientManager;
import org.springframework.security.oauth2.client.web.OAuth2AuthorizedClientRepository;
import org.springframework.security.oauth2.core.AuthorizationGrantType;
import org.springframework.security.oauth2.core.ClientAuthenticationMethod;
import pl.com.insert.api.configuration.converter.RefreshTokenRequestEntityConverter;

import static pl.com.insert.api.data.Properties.*;

@Configuration
public class OAuth2LoginConfig {

    @Bean
    public ClientRegistrationRepository clientRegistrationRepository() {
        return new InMemoryClientRegistrationRepository(this.devportalClientRegistration());
    }

    private ClientRegistration devportalClientRegistration() {
        return ClientRegistration.withRegistrationId(REGISTRATION_ID)
                .clientId(CLIENT_ID)
                .clientSecret(SECRET_ID)
                .clientAuthenticationMethod(ClientAuthenticationMethod.NONE)
                .authorizationGrantType(AuthorizationGrantType.AUTHORIZATION_CODE)
                .scope(SCOPE)
                .authorizationUri(AUTH_URL)
                .tokenUri(ACCESS_TOKEN_URL)
                .clientName(REGISTRATION_ID)
                .redirectUri(CALLBACK_URI)
                .jwkSetUri(JWK_SET_URI)
                .userInfoUri(USER_INFO_URL)
                .userNameAttributeName(USER_NAME_ATTRIBUTE)
                .build();
    }

    @Bean
    public OAuth2AuthorizedClientManager authorizedClientManager(
            ClientRegistrationRepository clientRegistrationRepository,
            OAuth2AuthorizedClientRepository authorizedClientRepository) {

        OAuth2AuthorizedClientProvider authorizedClientProvider =
                OAuth2AuthorizedClientProviderBuilder.builder()
                        .authorizationCode()
                        .refreshToken(r -> r.accessTokenResponseClient(refreshTokenTokenResponseClient()))
                        .build();
        DefaultOAuth2AuthorizedClientManager authorizedClientManager = new DefaultOAuth2AuthorizedClientManager(
                clientRegistrationRepository, authorizedClientRepository);
        authorizedClientManager.setAuthorizedClientProvider(authorizedClientProvider);

        return authorizedClientManager;
    }

    @Bean
    public DefaultRefreshTokenTokenResponseClient refreshTokenTokenResponseClient() {
        var refreshTokenTokenResponseClient = new DefaultRefreshTokenTokenResponseClient();
        refreshTokenTokenResponseClient.setRequestEntityConverter(new RefreshTokenRequestEntityConverter());
        return refreshTokenTokenResponseClient;
    }
}
