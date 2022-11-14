package pl.com.insert.api.service;

import org.springframework.http.*;
import org.springframework.stereotype.Service;
import org.springframework.web.client.HttpClientErrorException;
import org.springframework.web.client.RestTemplate;
import pl.com.insert.api.configuration.header.HeadersProvider;
import pl.com.insert.api.entity.Client;
import pl.com.insert.api.entity.Document;
import pl.com.insert.api.entity.Product;

import java.util.ArrayList;
import java.util.Arrays;
import java.util.List;

import static pl.com.insert.api.data.Properties.API_ADDRESS;

@Service
public class InsertApiService {

    RestTemplate restTemplate = new RestTemplate();

    public List<Client> getClients(String accessToken) {
        try {
            ResponseEntity<Client[]> response = restTemplate.exchange(
                    API_ADDRESS + "/clients?pageSize=10&pageNumber=0",
                    HttpMethod.GET,
                    HeadersProvider.entity(accessToken),
                    Client[].class);
            return Arrays.asList(response.getBody());
        } catch (HttpClientErrorException e) {
            e.printStackTrace();
            return new ArrayList<Client>();
        }
    }

    public List<Document> getDocuments(String accessToken) {
        try {
            ResponseEntity<Document[]> response = restTemplate.exchange(
                    API_ADDRESS + "/documents?pageSize=10&pageNumber=0",
                    HttpMethod.GET,
                    HeadersProvider.entity(accessToken),
                    Document[].class);
            return Arrays.asList(response.getBody());
        } catch (HttpClientErrorException e) {
            e.printStackTrace();
            return new ArrayList<Document>();
        }
    }

    public List<Product> getProducts(String accessToken) {
        try {
            ResponseEntity<Product[]> response = restTemplate.exchange(
                    API_ADDRESS + "/products?pageSize=10&pageNumber=0",
                    HttpMethod.GET,
                    HeadersProvider.entity(accessToken),
                    Product[].class);
            return Arrays.asList(response.getBody());
        } catch (HttpClientErrorException e) {
            e.printStackTrace();
            return new ArrayList<Product>();
        }
    }
}
