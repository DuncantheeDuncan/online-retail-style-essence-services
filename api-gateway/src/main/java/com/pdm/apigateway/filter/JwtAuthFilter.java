package com.pdm.apigateway.filter;

import com.pdm.userservice.util.JwtUtil;
import org.springframework.beans.factory.annotation.Autowired;
import org.springframework.http.HttpHeaders;
import org.springframework.http.server.reactive.ServerHttpRequest;
import org.springframework.http.server.reactive.ServerHttpResponse;
import org.springframework.stereotype.Component;
import org.springframework.web.server.WebFilter;
import org.springframework.web.server.WebFilterChain;
import org.springframework.web.server.ServerWebExchange;
import reactor.core.publisher.Mono;

@Component
public class JwtAuthFilter implements WebFilter {

    @Autowired
    private JwtUtil jwtUtil;

    @Override
    public Mono<Void> filter(ServerWebExchange exchange, WebFilterChain chain) {
        ServerHttpRequest request = exchange.getRequest();

        if (request.getHeaders().containsKey(HttpHeaders.AUTHORIZATION)) {
            String authHeader = request.getHeaders().getFirst(HttpHeaders.AUTHORIZATION);
            if (authHeader != null && authHeader.startsWith("Bearer ")) {
                String token = authHeader.substring(7);

                String username = jwtUtil.extractUsername(token);
                String role = jwtUtil.extractRole(token);

                if (!jwtUtil.validateToken(token, username)) {
                    ServerHttpResponse response = exchange.getResponse();
                    response.setStatusCode(org.springframework.http.HttpStatus.UNAUTHORIZED);
                    return response.setComplete();
                }

                // Add user info to request headers (to pass it to microservices)
                request = exchange.getRequest().mutate()
                        .header("X-User-Id", username)
                        .header("X-User-Role", role)
                        .build();
            }
        }

        return chain.filter(exchange.mutate().request(request).build());
    }
}
