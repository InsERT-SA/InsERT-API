package pl.com.insert.api.controller;

import org.springframework.security.oauth2.client.OAuth2AuthorizedClient;
import org.springframework.security.oauth2.client.annotation.RegisteredOAuth2AuthorizedClient;
import org.springframework.stereotype.Controller;
import org.springframework.ui.Model;
import org.springframework.web.bind.annotation.GetMapping;
import pl.com.insert.api.service.InsertApiService;
import pl.com.insert.api.entity.Client;
import pl.com.insert.api.entity.Document;
import pl.com.insert.api.entity.Product;

import java.util.List;

import static pl.com.insert.api.data.Properties.REGISTRATION_ID;

@Controller
public class ApiController {

    private final InsertApiService insertApiService;

    public ApiController(InsertApiService insertApiService) {
        this.insertApiService = insertApiService;
    }

    @GetMapping("/clients")
    public String getClients(@RegisteredOAuth2AuthorizedClient(REGISTRATION_ID)
                                          OAuth2AuthorizedClient authorizedClient,
                             Model model) {
        List<Client> clients = insertApiService.getClients(authorizedClient.getAccessToken().getTokenValue());
        model.addAttribute("clients", clients);
        return "insert-api-clients";
    }

    @GetMapping("/documents")
    public String getDocuments(@RegisteredOAuth2AuthorizedClient(REGISTRATION_ID)
                                      OAuth2AuthorizedClient authorizedClient,
                              Model model) {
        List<Document> documents = insertApiService.getDocuments(authorizedClient.getAccessToken().getTokenValue());
        model.addAttribute("documents", documents);
        return "insert-api-documents";
    }

    @GetMapping("/products")
    public String getProducts(@RegisteredOAuth2AuthorizedClient(REGISTRATION_ID)
                                       OAuth2AuthorizedClient authorizedClient,
                               Model model) {
        List<Product> products = insertApiService.getProducts(authorizedClient.getAccessToken().getTokenValue());
        model.addAttribute("products", products);
        return "insert-api-products";
    }
}
