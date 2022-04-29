package pl.com.insert.api.configuration.converter;

import org.springframework.core.convert.converter.Converter;
import org.springframework.http.RequestEntity;
import org.springframework.security.oauth2.client.endpoint.OAuth2RefreshTokenGrantRequest;
import org.springframework.security.oauth2.client.endpoint.OAuth2RefreshTokenGrantRequestEntityConverter;
import org.springframework.util.MultiValueMap;

public class RefreshTokenRequestEntityConverter implements
        Converter<OAuth2RefreshTokenGrantRequest, RequestEntity<?>> {


    private final OAuth2RefreshTokenGrantRequestEntityConverter defaultConverter;

    public RefreshTokenRequestEntityConverter() {
        defaultConverter = new OAuth2RefreshTokenGrantRequestEntityConverter();
    }

    @Override
    @SuppressWarnings("unchecked")
    public RequestEntity<?> convert(OAuth2RefreshTokenGrantRequest req) {
        RequestEntity<?> entity = defaultConverter.convert(req);
        MultiValueMap<String, String> params = null;
        try {
            params = (MultiValueMap<String, String>) entity.getBody();
            params.add("client_secret", req.getClientRegistration().getClientSecret());
            params.add("client_id", req.getClientRegistration().getClientId());
        } catch (NullPointerException npe) {
            npe.printStackTrace();
        }
        return new RequestEntity<>(params, entity.getHeaders(),
                entity.getMethod(), entity.getUrl());
    }
}
