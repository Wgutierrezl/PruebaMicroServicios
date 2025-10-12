package com.example.demo.Config;

import org.springframework.beans.factory.annotation.Value;
import org.springframework.context.annotation.Bean;
import org.springframework.context.annotation.Configuration;
import org.springframework.web.client.RestTemplate;

@Configuration
public class HttpClientConfig {

    @Value("${api.usuarios.base-url}")
    private String usuariosBaseUrl;

//    @Value("${api.solicitudes.base-url}")
//    private String solicitudesBaseUrl;

    @Bean(name = "usuariosRestTemplate")
    public RestTemplate usuariosRestTemplate() {
        return new RestTemplate();
    }

//    @Bean(name = "solicitudesRestTemplate")
//    public RestTemplate solicitudesRestTemplate() {
//        return new RestTemplate();
//    }

    // ✅ opcional: getters si quieres acceder desde otros beans
    public String getUsuariosBaseUrl() { return usuariosBaseUrl; }
//    public String getSolicitudesBaseUrl() { return solicitudesBaseUrl; }
}
