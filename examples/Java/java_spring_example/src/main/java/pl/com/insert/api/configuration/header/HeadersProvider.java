package pl.com.insert.api.configuration.header;

import org.springframework.http.HttpEntity;
import org.springframework.http.HttpHeaders;
import org.springframework.http.MediaType;
import org.springframework.stereotype.Component;

import java.util.List;

import static pl.com.insert.api.data.Properties.SUBSCRIPTION_KEY;

@Component
public class HeadersProvider {

    private HeadersProvider() {
    }

    public static HttpEntity<HttpHeaders> entity(String accessToken) {
        HttpHeaders headers = new HttpHeaders();
        headers.set("Ocp-Apim-Subscription-Key", SUBSCRIPTION_KEY);
        headers.set("Authorization", "Bearer "+ accessToken);
        headers.setAccept(List.of(MediaType.APPLICATION_JSON));
        headers.setContentType(MediaType.APPLICATION_JSON);
        return new HttpEntity<>(headers);
    }
}
