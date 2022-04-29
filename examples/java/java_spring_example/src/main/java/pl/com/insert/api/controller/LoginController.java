package pl.com.insert.api.controller;

import org.springframework.security.core.Authentication;
import org.springframework.stereotype.Controller;
import org.springframework.ui.Model;
import org.springframework.web.bind.annotation.GetMapping;

import static pl.com.insert.api.data.Properties.AUTHENTICATION_URL;
import static pl.com.insert.api.utils.AuthenticationUtil.isAuthenticated;

@Controller
public class LoginController {


    @GetMapping("/plugins")
    public String getLoginPage(Model model, Authentication authentication) {
        String url = (isAuthenticated(authentication)) ? "/subiekt123/api" : AUTHENTICATION_URL;
        model.addAttribute("url", url);
        return "insert-api-connection";
    }

    @GetMapping("")
    public String getLoginPage() {
        return "redirect:plugins";
    }

    @GetMapping("/subiekt123/api")
    public String connectPage() {
        return "insert-api";
    }
}
