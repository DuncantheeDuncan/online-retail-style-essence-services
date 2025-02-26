package com.pdm.apigateway.config;

import org.springframework.context.annotation.Bean;
import org.springframework.context.annotation.Configuration;
import org.springframework.security.config.Customizer;
import org.springframework.security.config.web.server.ServerHttpSecurity;
import org.springframework.security.web.server.SecurityWebFilterChain;

@Configuration
public class SecurityConfig {

    @Bean
    public SecurityWebFilterChain securityWebFilterChain(ServerHttpSecurity http) {
        http
                .csrf(ServerHttpSecurity.CsrfSpec::disable)
                .authorizeExchange(exchange -> exchange
                        .pathMatchers("/api/auth/**").permitAll() // Authentication public endpoints
                        .pathMatchers("/api/admin/**").hasRole("ADMIN") //Only for Admins
                        .anyExchange().authenticated() // All other endpoints require authentication
                )
                .oauth2ResourceServer((oauth) -> oauth.jwt(Customizer.withDefaults())); // Use JWT for authentication

        return http.build();
    }


}
















//
//}
//
