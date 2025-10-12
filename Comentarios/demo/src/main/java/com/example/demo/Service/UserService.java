package com.example.demo.Service;

import com.example.demo.model.UsuarioDTO;
import org.springframework.beans.factory.annotation.Qualifier;
import org.springframework.beans.factory.annotation.Value;
import org.springframework.http.HttpEntity;
import org.springframework.http.HttpHeaders;
import org.springframework.http.HttpMethod;
import org.springframework.http.ResponseEntity;
import org.springframework.security.core.context.SecurityContextHolder;
import org.springframework.stereotype.Service;
import org.springframework.web.client.RestTemplate;

@Service
public class UserService {

    private final RestTemplate restTemplate;
    private final String baseUrl;

    // ✅ Inyectamos la URL directamente desde el application.yml
    public UserService(
            @Qualifier("usuariosRestTemplate") RestTemplate restTemplate,
            @Value("${api.usuarios.base-url}") String baseUrl) {
        this.restTemplate = restTemplate;
        this.baseUrl = baseUrl;
    }

    public UsuarioDTO getUsuarioById(String id) {
        String url = baseUrl + "/api/Usuario/ObtenerUsuarioPorId/" + id;

        String token = (String) SecurityContextHolder.getContext().getAuthentication().getCredentials();
        HttpHeaders headers = new HttpHeaders();
        headers.set("Authorization","Bearer "+ token); // ⚡ Aquí agregamos el token
        HttpEntity<String> entity = new HttpEntity<>(headers);

        ResponseEntity<UsuarioDTO> response = restTemplate.exchange(
                url,
                HttpMethod.GET,
                entity,
                UsuarioDTO.class
        );

        return response.getBody();
    }
}
